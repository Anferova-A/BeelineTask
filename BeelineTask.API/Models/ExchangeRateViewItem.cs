namespace BeelineTask.API.Models;

public class ExchangeRateViewItem
{
    /// <summary>
    /// Номинал
    /// </summary>
    public int Nominal { get; set; }
    /// <summary>
    /// Название валюты
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Стоимость валюты
    /// </summary>
    public double Value { get; set; }
}
