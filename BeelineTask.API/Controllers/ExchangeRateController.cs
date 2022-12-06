using BeelineTask.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BeelineTask.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ExchangeRateController : ControllerBase
{
    private HttpClient _httpClient;

    public ExchangeRateController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Получение списка доступных валют
    /// </summary>
    /// <returns>Список доступных валют</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExchangeRateViewItem>>> GetAvalableList()
    {
        var data = await GetData();
        var result = data?.ExchangeRateByCode?.Values.Select(er => er.GetViewItem());
        if (result == null)
        {
            return NotFound();
        }
        return new (result);
    }

    /// <summary>
    /// Получение текущего курса валюты по названию
    /// </summary>
    /// <param name="name">Название валюты на русском языке</param>
    /// <returns>Данные о курсе</returns>
    /// <response code="200">Успешный запрос</response>
    /// <response code="404">Валюта не найдена</response>
    [HttpGet]
    [ProducesResponseType(typeof(ExchangeRateViewItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExchangeRateViewItem>> GetByName([Required]string name)
    {
        var data = await GetData();
        var result = data?.ExchangeRateByCode?.Values
            ?.FirstOrDefault(er => er.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            ?.GetViewItem();

        if (result == null)
        {
            return NotFound();
        }
        return result;
    }

    private async Task<CbrResponse> GetData() 
        => await _httpClient.GetFromJsonAsync<CbrResponse>("https://www.cbr-xml-daily.ru/daily_json.js");
}
