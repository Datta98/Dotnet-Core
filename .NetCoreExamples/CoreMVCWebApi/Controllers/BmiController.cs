using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BMIValueCalculationLib;

namespace CoreMVCWebApi.Controllers
{
     [ApiController]
     
    [Route("api/[controller]")]
    public class BmiController:ControllerBase
    {
        [HttpGet]       
        public double Get()
        {
         BMIValueCalculationLib.CalculateBMI _calculate = new   BMIValueCalculationLib.CalculateBMI();
        double result = _calculate.Calculator(3.5,58);
        return result;
        }
       
    }
}