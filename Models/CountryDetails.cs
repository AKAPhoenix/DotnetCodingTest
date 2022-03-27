using System.ComponentModel.DataAnnotations;

namespace CodeTest.Models
{
    public class CountryDetails
    {
        [Key]
        public int Id { get; set; }
        public string ooperator { get; set; }
        public string operatorCode { get; set; }
    }
}
