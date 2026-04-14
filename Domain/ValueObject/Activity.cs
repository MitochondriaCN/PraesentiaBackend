using System.Collections.Immutable;

namespace XianlitiCN.PraesentiaBackend.Domain.ValueObject;

public record Activity(
    Application CurrentApplication,
    ImmutableDictionary<string, object> Metadata,
    DateTimeOffset BeginAt);