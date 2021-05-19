using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MoneyWatcher.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient {BaseAddress = new Uri("https://localhost:44311/")};
            var response = await client.GetAsync("api/login");
            var jsonResponse = await  response.Content.ReadAsStringAsync();
            return Ok();
        }
    }
}