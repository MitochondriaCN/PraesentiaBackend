using FluentResults;
using MediatR;

namespace XianlitiCN.PraesentiaBackend.Application.Command;

public record RegisterDeviceCommand(
    string FriendlyName,
    string ModelName,
    Guid Guid) : IRequest<Result<long>>;