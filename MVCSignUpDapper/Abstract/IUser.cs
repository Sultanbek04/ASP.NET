using MVCSignUpDapper.Implementations;
using MVCSignUpDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSignUpDapper.Abstract
{
  interface IUser
  {
    //bool IsAvaliableEmail { get; set; }
    User Get(string email);
    void Create(User country);
    void Delete(int id);
    void Update(User country);

  }
}
