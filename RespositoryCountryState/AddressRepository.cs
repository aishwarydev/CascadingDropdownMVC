using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryCountryState
{
    public class AddressRepository:IAddressRepository
    {
        private AddressDataContext _dataContext;

        public AddressRepository()
        {
            _dataContext = new AddressDataContext();
        }

        public IList<Country> GetAllCountries()
        {
            return _dataContext.Countries.ToList<Country>();
        }

        public IList<State> GetAllStatesByCountryId(int countryId)
        {
            return _dataContext.States.Where(x => x.CountryId == countryId).ToList<State>();
        }

        public bool CreateCountry(string name)
        {
            Country ct = new Country();
            ct.Name = name;

            _dataContext.Countries.InsertOnSubmit(ct);

           _dataContext.SubmitChanges();
           return true;
           

        }

    }
}
