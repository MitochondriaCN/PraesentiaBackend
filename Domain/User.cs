namespace XianlitiCN.PraesentiaBackend.Domain;

/// <summary>
/// 用户
/// </summary>
public class User
{
    public long Id { get; private set; }

    public long[] DeviceIds { get; private set; } = [];

    public void AddDevice(Device device)
    {
        DeviceIds = DeviceIds.Append(device.Id).ToArray();
    }
}