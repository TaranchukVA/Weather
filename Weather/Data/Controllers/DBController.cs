using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Weather.Data.ResponseParams.ResponseNow;
using Weather.Data.ResponseParams.ResponseFiveDays;

namespace Weather.Data
{
    [Route("db/")]
    public class DBController : Controller
    {
        private readonly DbWeather context;

        public DBController(DbWeather context)
        {
            this.context = context;
        }

        [Route("all")]
        public IActionResult ShowAll()
        {
            var data = context.History.ToList();
            return Ok(data);
        }

        [Route("current")]
        [HttpGet("current/{city}")]
        public IActionResult ShowOneDayCity(string city)
        {
            List<Now> data = new List<Now>();
            if (String.IsNullOrEmpty(city))
            {
                data = context.History
                     .Where(elem => elem.IsSuccess & elem.RequestType == RequestType.Now)
                     .OrderBy(elem => elem.Date)
                     .Select(elem => JsonConvert.DeserializeObject<Now>(elem.Response))
                     .ToList();
            }
            else
            {
                data = context.History
                  .Where(elem => elem.City == city & elem.IsSuccess & elem.RequestType == RequestType.Now)
                  .OrderBy(elem => elem.Date)
                  .Select(elem => JsonConvert.DeserializeObject<Now>(elem.Response))
                  .ToList();
            }
            if (data.Count == 0)
                return Ok("В БД нет подходящих записей");
            else
                return Ok(data);
        }

        [Route("FiveDays")]
        [Route("FiveDays/{city}")]
        public IActionResult ShowFiveDaysCity(string city)
        {
            List<FiveDays> data = new List<FiveDays>();
            if (String.IsNullOrEmpty(city))
            {
                data = context.History
                       .Where(elem => elem.IsSuccess & elem.RequestType == RequestType.FiveDays)
                       .Select(elem => JsonConvert.DeserializeObject<FiveDays>(elem.Response))
                       .ToList();
            }
            else
            {
                data = context.History
                    .Where(elem => elem.City == city & elem.IsSuccess & elem.RequestType == RequestType.FiveDays)
                    .Select(elem => JsonConvert.DeserializeObject<FiveDays>(elem.Response))
                    .ToList();
            }
            if (data.Count == 0)
                return Ok("В БД нет подходящих записей");
            else
                return Ok(data);
        }
    }
}
