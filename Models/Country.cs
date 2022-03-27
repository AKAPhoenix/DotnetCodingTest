using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeTest.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string countryCode { get; set; }
        public string name { get; set; }
        public string countryIso { get; set; }
        public List<CountryDetails> countryDetails { get; set; }
    }
}
