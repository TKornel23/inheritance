using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles
{
    class Program
    {
        static void Teszt1()
        {
            Terkep terkep = new Terkep(80, 25);
            Szimulacio szimulacio = new Szimulacio(5, terkep);

            Jarmu jarmu = new Jarmu('X', 10, 10, terkep);
            Helikopter helikopter = new Helikopter(terkep, 5f, 5f);
            Auto auto = new Auto('A', 5f, 6f, terkep);
            Tank tank = new Tank('T', 11f, 9f, terkep, 100);

            szimulacio.JarmuFelvetel(helikopter);
            szimulacio.JarmuFelvetel(jarmu);
            szimulacio.JarmuFelvetel(tank);
            szimulacio.JarmuFelvetel(auto);

            auto.UjIranyVektor(1f, 0f);
            tank.UjIranyVektor(1f, 1f);
            helikopter.UjIranyVektor(1f, 0f);

            szimulacio.Fut();           
        }


        static void Main(string[] args)
        {
            Teszt1();
        }
    }
}
