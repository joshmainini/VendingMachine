using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Drink : VendingMachineItems
    {
        public Drink(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return "Glug Glug Yum!";
        }
    }
}
