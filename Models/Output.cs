using System.Collections.Generic;

namespace CodeTest.Models
{
    public class Output
    {
        public int number { get; }
        //public List<CountryDetails> countries { get; set; }

        public OutputCountry Country = new OutputCountry();
        public Output(Country ctr, List<CountryDetails> ctd, int id )
        {
            List<OutputCountryDetails> locd = new List<OutputCountryDetails>();
            this.number = id;
            foreach (CountryDetails ele in ctd)
            {
                OutputCountryDetails oele =new OutputCountryDetails();
                oele.ooperator = ele.ooperator;
                oele.operatorCode=ele.operatorCode;
                locd.Add(oele);
            }

            Country.countryCode=ctr.countryCode;
            Country.countryIso = ctr.countryIso;
            Country.name = ctr.name;
            Country.OutputcountryDetails = locd;
        }
    }

    public class OutputCountry
    {
        public string countryCode { get; set; }
        public string name { get; set; }
        public string countryIso { get; set; }
        public List<OutputCountryDetails> OutputcountryDetails { get; set; }
    }

    public class OutputCountryDetails
    {
        public string ooperator { get; set; }
        public string operatorCode { get; set; }
    }
}
