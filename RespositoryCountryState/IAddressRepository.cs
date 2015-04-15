using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryCountryState
{
    public interface IAddressRepository
    {
        IList<Country> GetAllCountries();
        IList<State> GetAllStatesByCountryId(int countryId);
        bool CreateCountry(string name);

    }
}
