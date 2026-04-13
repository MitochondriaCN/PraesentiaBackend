namespace XianlitiCN.PraesentiaBackend.Domain.ValueObject;

public record Activity(
    Application CurrentApplication,
    Dictionary<string, object> Metadata,
    DateTimeOffset BeginAt);