using System.Text.Json.Serialization;

namespace BeelineTask.API.Models;

public class CbrResponse
{
    public DateTime Date { get; set; }
    public DateTime PreviousDate { get; set; }
    public string PreviousURL { get; set; }
    public DateTime Timestamp { get; set; }

    [JsonPropertyName("Valute")]
    public Dictionary<string, ExchangeRateDto> ExchangeRateByCode { get; set; }
}
