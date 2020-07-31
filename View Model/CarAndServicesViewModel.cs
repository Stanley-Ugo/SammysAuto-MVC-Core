using SammysAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.View_Model
{
    public class CarAndServicesViewModel
    {
        public int carId { get; set; }
       
        public string Make { get; set; }
        
        public string Model { get; set; }
        public string Style { get; set; }
        
        public string VIN { get; set; }
        public int Year { get; set; }
        
        public Service NewServiceObj { get; set; }
        public IEnumerable<Service> PastServiceObj { get; set; }
        public List<ServiceType> ServiceTypesObj { get; set; }
    }
}
