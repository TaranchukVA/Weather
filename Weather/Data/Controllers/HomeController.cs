using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.Data.Interfaces;
using Weather.Data.Implementations;
using Weather.Data.Models;
using System.Net;
using System.Collections.Generic;
using Weather.Data.ResponseParams.ResponseNow;
using Weather.Data.ResponseParams.ResponseFiveDays;

namespace Weather.Data
{
    public class HomeController : Controller
    {

        private readonly DbWeather context;
        private readonly IAdress adress;

        public HomeController(IConfiguration configuration, DbWeather context)
        {
            this.context = context;
            adress = new Adress(configuration.GetConnectionString("ApiWeatherKey"));
        }


        [Route("/")]
        public IActionResult Index()
        {
            return Content("Hello World! Привет мир!");
        }

        [Route("/now")]
        [Route("/now/{city}")]
        [Route("/now/{city}/{country}")]
        public async Task<IActionResult> NowAsync(string city, string country)
        {
            if (String.IsNullOrEmpty(city)) return BadRequest("Город не введён");
            try
            {
                string uri = adress.Now(city, country);

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var responce = await client.SendAsync(request);
                var responceSting = await responce.Content.ReadAsStringAsync();

                var newEntry = new HistoryModel()
                {
                    Id = Guid.NewGuid(),
                    City = city,
                    Request = uri,
                    Response = responceSting,
                    RequestType = RequestType.Now,
                    Date = DateTime.Now,
                    IsSuccess = responce.IsSuccessStatusCode
                };

                context.History.Add(newEntry);
                await context.SaveChangesAsync();

                if (responce.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<Now>(responceSting);
                    return Ok(result);
                }
                else
                {
                    return StatusCode((int)responce.StatusCode, "Извините. Погода не была получена");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [Route("/FiveDays")]
        [Route("/FiveDays/{city}")]
        [Route("/FiveDays/{city}/{country}")]
        public async Task<IActionResult> FiveDaysAsync(string city, string country)
        {
            if (String.IsNullOrEmpty(city)) return BadRequest("Город не введён");
            try
            {
                string uri = adress.FewDays(city, country);

                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                var responce = await client.SendAsync(request);
                var responceSting = await responce.Content.ReadAsStringAsync();

                var newEntry = new HistoryModel()
                {
                    Id = Guid.NewGuid(),
                    City = city,
                    Request = uri,
                    Response = responceSting,

                    RequestType = RequestType.FiveDays,
                    Date = DateTime.Now,
                    IsSuccess = responce.IsSuccessStatusCode
                };

                context.History.Add(newEntry);
                await context.SaveChangesAsync();

                if (responce.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<FiveDays>(responceSting);
                    return Ok(result);
                }
                else
                {
                    return StatusCode((int)responce.StatusCode, "Извините. Погода не была получена");
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        

        [Route("/init")]
        public async Task<IActionResult> InitAsync()
        {
            List<string> cities = new List<string> { "moscow", "sochi", "madrid", "varna" };
            List<string> cities2 = new List<string> { "volgograd", "berlin", "madrid", "minsk" };

            foreach (var city in cities)
                await NowAsync(city, null);
            foreach (var city in cities2)
                await FiveDaysAsync(city, null);

            return Ok("Таблица заполнена");

        }
    }
}
