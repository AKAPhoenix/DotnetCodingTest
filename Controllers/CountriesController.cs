using CodeTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CountriesController(AppDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public Country CountryJsonById()
        {
            string code = getCountry(7);
            Country country = _context.Countries.Where(x => x.countryCode == code).SingleOrDefault();
            return country;
        }
        [HttpGet(" {id}")]
        public Country CountryJsonById(int id)
        {
            string code = getCountry(id);
            Country country = _context.Countries.Where(x => x.countryCode == code).SingleOrDefault();
            return country;
        }
        [HttpPost]
        public Country CountryJsonById(Country cntr)
        {
            return cntr;
        }
        [HttpDelete("{id}")]
        public IActionResult CountryById(int id)
        {
            return Ok();
        }
        
        public IActionResult Delete(int id, Country cntr)
        {
            return Ok();
        }

        public string getCountry(int id)
        {
            List<int> arr = null;
            double num = id;
            int mod;
            while (num != 0)
            {
                mod = (int)(num % 10);
                arr.Add(mod);
                num = (num / 10);
                num = Math.Floor(num / 10);

            }
            List<int> trois = arr.GetRange(0, 3);
            string s = string.Join(",", trois.Select(x => x.ToString()).ToArray());
            //int sint = Int16.Parse(s);

            return s;
        }
    }
}
