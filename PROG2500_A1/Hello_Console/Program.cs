using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Program
    {
        /*
* Run this code in the debugger and look at where it
* goes step-by-step, and what the internal data structures
* look like after each step.
* 
* Remember...console writes go to the DOS prompt.
* 
*/
        static void Main(string[] args)
        {
            Dog d1 = new Dog(10);
            d1.moveShape(100, 200);

            SuperDog sd1 = new SuperDog(20);
            sd1.moveShape(500, 600);

            Chicken c1 = new Chicken(30);
            c1.moveShape(100, 200);

            // get the location of the animals
            Console.WriteLine("Dog d1 X=" + d1.getX() + "  Y=" + d1.getY());
            Console.WriteLine("SuperDog sd1 X=" + sd1.getX() + "  Y=" + sd1.getY());
            Console.WriteLine("Chicken c1 X=" + c1.getX() + "  Y=" + c1.getY());

            Console.WriteLine("==========================================");
            Console.WriteLine("Waiting for you to press enter");
            Console.ReadLine();

        }
    }
}
