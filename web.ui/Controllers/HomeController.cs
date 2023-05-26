using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using web.ui.Models;

namespace web.ui.Controllers;

public class HomeController : Controller
{

    public async Task<IActionResult> Index()
    {
        var baseUrl = "http://127.0.0.1:8080";
        var httpClientHandler = new HttpClientHandler();
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;
        
        var httpClient = new HttpClient(httpClientHandler) { BaseAddress = new Uri(baseUrl) };

        var response = await httpClient.GetAsync("WeatherForecast");
        var data = response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

        return View(data.Result);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
