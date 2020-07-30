using SammysAuto.Data;
using SammysAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.View_Model
{
    public class CarAndCustomerViewModel
    {
        public SammysAutoUser UserObj { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
