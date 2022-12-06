namespace BeelineTask.API.Models;

public class ExchangeRateDto
{
    public string ID { get; set; }
    public string NumCode { get; set; }
    public string CharCode { get; set; }
    public int Nominal { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public double Previous { get; set; }

    public ExchangeRateViewItem GetViewItem()
        => new ExchangeRateViewItem
        {
            Name = Name,
            Value = Value,
            Nominal = Nominal,
        };
}
