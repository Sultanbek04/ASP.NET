using MVCDBCountryDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDBCountryDapper.Abstract
{
  interface ICountry
  {
    List<Country> GetCountries();
    Country Get(int? id);
    void Create(Country country);
    void Delete(int id);

    void Update(Country country);
  }
}
