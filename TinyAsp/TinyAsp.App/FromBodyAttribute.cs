using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyAsp.App
{
  //[AttributeUsage(AttributeTargets.Parameter)]
  public class FromBodyAttribute : Attribute
  {
	//public Object FromBody { get; private set; }
    /*public FromBodyAttribute(Object fromBody)
    {
      FromBody = fromBody;
    }*/
  }
}
