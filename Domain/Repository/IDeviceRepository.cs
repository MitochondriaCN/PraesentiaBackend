namespace XianlitiCN.PraesentiaBackend.Domain.Repository;

public interface IDeviceRepository
{
    Task<Device?> GetByIdAsync(long id);

    Task<Device?> GetByGuidAsync(Guid guid);

    Task AddAsync(Device device);
}