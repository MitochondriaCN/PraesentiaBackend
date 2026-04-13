using XianlitiCN.PraesentiaBackend.Domain.ValueObject;

namespace XianlitiCN.PraesentiaBackend.Domain;

/// <summary>
/// 设备
/// </summary>
public class Device(long id, string friendlyName, string modelName)
{
    public long Id { get; private set; } = id;

    public string FriendlyName { get; private set; } = friendlyName;

    public string ModelName { get; private set; } = modelName;

    /// <summary>
    /// 设备偏好设置
    /// </summary>
    public DevicePrefs Prefs { get; private set; } = new();

    /// <summary>
    /// 设备当前正在进行的活动
    /// </summary>
    public Activity? CurrentActivity { get; private set; }

    public DateTimeOffset? LastPulse { get; private set; }

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
    public void Pulse()
    {
        LastPulse = DateTimeOffset.Now;
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
    public bool IsOffline()
    {
        return LastPulse is null ||
               DateTimeOffset.Now - LastPulse.Value > TimeSpan.FromSeconds(Prefs.OfflinePulseTimeoutSec);
    }
}