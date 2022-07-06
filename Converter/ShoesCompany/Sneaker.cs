using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.ShoesCompany
{
    internal class Sneaker : Shoes
    {

        Base Base;
        public Sneaker(int size, Condition condition, Material material, Base Base) : base(size, condition, material)
        {
            Base = this.Base;

        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Sneaker params: Base type = {Base}");
        }
    }

    enum Base
    {
        Rubber,
        Foam,
        Air
    }
}
