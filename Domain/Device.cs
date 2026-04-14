using XianlitiCN.PraesentiaBackend.Domain.ValueObject;

namespace XianlitiCN.PraesentiaBackend.Domain;

/// <summary>
/// 设备
/// </summary>
public class Device
{
    public long Id { get; private set; }

    public Guid Guid { get; private set; }

    public long? UserId { get; private set; }

    public string FriendlyName { get; private set; }

    public string ModelName { get; private set; }

    /// <summary>
    /// 设备偏好设置
    /// </summary>
    public DevicePrefs Prefs { get; private set; } = new();

    /// <summary>
    /// 设备当前正在进行的活动
    /// </summary>
    public Activity? CurrentActivity { get; private set; }

    public DateTimeOffset? LastPulse { get; private set; }

    private Device(string friendlyName, string modelName, Guid guid)
    {
        Guid = guid;
        FriendlyName = string.IsNullOrWhiteSpace(friendlyName)
            ? throw new ArgumentException("Friendly name is required.", nameof(friendlyName))
            : friendlyName;
        ModelName = string.IsNullOrWhiteSpace(modelName)
            ? throw new ArgumentException("Model name is required.", nameof(modelName))
            : modelName;
    }

    private Device()
    {
        FriendlyName = null!;
        ModelName = null!;
    }

    public static Device Register(string friendlyName, string modelName, Guid guid)
    {
        return new Device(friendlyName, modelName, guid);
    }

    public void BindToUser(long userId)
    {
        Unbind();
        UserId = userId;
    }

    public void Unbind()
    {
        UserId = null;
    }

    /// <summary>
    /// 切换当前设备正在进行的活动
    /// </summary>
    /// <param name="activity"></param>
    public void SwitchActivity(Activity activity)
    {
        CurrentActivity = activity;
    }

    /// <summary>
    /// 发送一次设备脉冲，表示设备当前状态正常
    /// </summary>
    public void Pulse(DateTimeOffset pulseAt)
    {
        LastPulse = pulseAt;
    }

    /// <summary>
    /// 设置设备偏好设置
    /// </summary>
    public void SetPrefs(DevicePrefs prefs)
    {
        Prefs = prefs;
    }

    /// <summary>
    /// 判断设备是否离线
    /// </summary>
    public bool IsOffline(DateTimeOffset now)
    {
        return LastPulse is null ||
               now - LastPulse.Value > TimeSpan.FromSeconds(Prefs.OfflinePulseTimeoutSec);
    }
}
