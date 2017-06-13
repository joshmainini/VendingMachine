using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy : VendingMachineItems
    {
        public Candy(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return "Munch Munch Yum!";
        }
    }
}
