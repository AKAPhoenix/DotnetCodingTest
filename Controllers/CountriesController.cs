using CodeTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        //[HttpGet]
        //public Country CountryJsonById()
        //{
        //    //string code = getCountry(7);
        //    Country country = _context.Countries.Where(x => x.countryIso == "234").SingleOrDefault();
        //    return country;
        //}

        [HttpGet]
        public string CountryJson()
        {
            //string code = getCountry(7);
            //CountryDetails country = _context.Countries.Where(x => x.countryIso == "234").Include(s => s.countryDetails).SingleOrDefault();
            Country country = _context.Countries.Where(x => x.Id == 1).SingleOrDefault();
            List<CountryDetails> countryDetails = _context.CountryDetails.Where(x => x.CountryId == 1).ToList();
            
            Output output=new Output(country,countryDetails, 23465798);
            string outputstring = JsonConvert.SerializeObject(output);
            return outputstring;
        }

        //[HttpGet(" {id}")]
        //public Country CountryJsonById(int id)
        //{
        //    string code = getCountry(id);
        //    Country country = _context.Countries.Where(x => x.countryIso == code).SingleOrDefault();
        //    return country;
        //}

        //THIS IS THE ASSIGNMENT
        //-----------------------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("{id:int}")]
        public string CountryJsonById(int id)
        {
            string code = getCountry(id);
            if (code == "Invalid")
            {
                return "Number must be 3 digits or more";

            }
            Country country = _context.Countries.Where(x => x.countryIso == code).SingleOrDefault();
            List<CountryDetails> countryDetails = _context.CountryDetails.Where(x => x.CountryId == country.Id).ToList();
            Output output = new Output(country,countryDetails,id);
            string outputstring = JsonConvert.SerializeObject(output);
            return outputstring;
        }
//-----------------------------------------------------------------------------------------------------

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
        
        [NonAction]
        public IActionResult Update(int id, Country cntr)
        {
            return Ok();
        }

        [NonAction]
        public string getCountry(int id)
        {
            List<int> arr = new List<int>();
            double num = id;
            int mod;
            //To ensure iso is 3 digits or more
            if (id < 99)
            {
                return "Invalid";
            }
            while (num != 0)
            {
                mod = (int)(num % 10);
                arr.Add(mod);
                num = Math.Floor(num / 10);

            }
            int arrlength = arr.Count;

            List<int> trois = arr.GetRange(arrlength - 3, 3);
            trois.Reverse(0, 3);
            string s = string.Join("", trois.Select(x => x.ToString()).ToArray());
            //int sint = Int16.Parse(s);

            return s;
        }
    }
}
