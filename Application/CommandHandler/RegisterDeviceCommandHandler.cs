using FluentResults;
using MediatR;
using XianlitiCN.PraesentiaBackend.Application.Command;
using XianlitiCN.PraesentiaBackend.Domain.Repository;
using XianlitiCN.PraesentiaBackend.Domain.Service;

namespace XianlitiCN.PraesentiaBackend.Application.CommandHandler;

public class RegisterDeviceCommandHandler(
    IDeviceRepository repo,
    DeviceRegistrationService registrationService) : IRequestHandler<RegisterDeviceCommand, Result<long>>
{
    public async Task<Result<long>> Handle(RegisterDeviceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var device = await registrationService.RegisterAsync(
                request.FriendlyName,
                request.ModelName,
                request.Guid,
                cancellationToken);

            await repo.AddAsync(device);
            return Result.Ok(device.Id);
        }
        catch (InvalidOperationException ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}
