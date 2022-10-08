using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ShopDto
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Budget { get; set; }
    }
}
