﻿using SurveyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMVC.Abstract
{
  public interface IResult
  {
     int InsertResult(Result result);
  }
}