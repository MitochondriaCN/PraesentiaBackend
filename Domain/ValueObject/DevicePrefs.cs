namespace XianlitiCN.PraesentiaBackend.Domain.ValueObject;

/// <summary>
/// 设备偏好设置
/// </summary>
/// <param name="OfflinePulseTimeoutSec">设备离线脉冲超时时间，单位秒，超过该时间未收到脉冲，认为设备离线</param>
public record DevicePrefs(
    int OfflinePulseTimeoutSec = 60);