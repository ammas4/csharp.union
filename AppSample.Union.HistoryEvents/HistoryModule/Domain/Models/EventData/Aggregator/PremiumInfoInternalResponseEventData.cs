﻿using System.Text.Json.Serialization;

namespace AppSample.Union.HistoryEvents.HistoryModule.Domain.Models.EventData.Aggregator;

public record struct PremiumInfoInternalResponseEventData(
    [property: JsonPropertyName("sc")] int StatusCode) : IHistoryEventData
{
    [JsonIgnore]
    public HistoryEventType EventType => HistoryEventType.PremiumInfoInternalResponse;
}