using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.ShoesCompany
{
    class Boots : Shoes
    {

        bool waterproof;
        public Boots(bool waterproof, int size, Condition condition, Material material) : base(size, condition, material)
        {
            waterproof = this.waterproof;
        }
        
         public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Boots params: waterproof = {waterproof}");
        }
    }
}
