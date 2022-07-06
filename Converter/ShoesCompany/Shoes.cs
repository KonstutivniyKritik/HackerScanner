using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Shoes
{
    protected int size;
    protected Condition condition;
    protected Material material;

    public Shoes(int size, Condition condition, Material material)
    {
        Size = size;
        condition = this.condition;
        material = this.material;
    }
    int Size
    {
        get { return size; }
        set
        {
            if (value < 35 || value > 50)
                Console.WriteLine("Incorrect size");
            else size = value;
        }


    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Parent class: {this.GetType().BaseType.Name}");
        Console.WriteLine($"Shoes params: size = {size}, condition = {condition}, material = {material}");
    }




    public enum Condition
    {
        New,
        Weary,
        Garbage
    }

    public enum Material
    {
        Leather,
        Textile,
        Suede,      //замша
        Plastic   
    }
}

