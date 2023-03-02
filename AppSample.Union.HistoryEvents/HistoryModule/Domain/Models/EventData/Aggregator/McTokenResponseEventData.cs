﻿using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct McTokenResponseEventData(
    [property: JsonPropertyName("e"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] string? Error,
    [property: JsonPropertyName("ed"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] string? ErrorDescription) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.McTokenResponse;
}
