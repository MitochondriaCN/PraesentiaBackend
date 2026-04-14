using XianlitiCN.PraesentiaBackend.Domain.Repository;

namespace XianlitiCN.PraesentiaBackend.Domain.Service;

public class DeviceRegistrationService(IDeviceRepository deviceRepository)
{
    public async Task<Device> RegisterAsync(
        string friendlyName,
        string modelName,
        Guid guid,
        CancellationToken cancellationToken)
    {
        var existingDevice = await deviceRepository.GetByGuidAsync(guid);
        if (existingDevice is not null)
        {
            throw new InvalidOperationException("Device already exists.");
        }

        cancellationToken.ThrowIfCancellationRequested();
        return Device.Register(friendlyName, modelName, guid);
    }
}
