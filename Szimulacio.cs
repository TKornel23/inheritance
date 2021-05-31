using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles
{
    class Szimulacio : TerkepEsJarmuRajzolo
    {
        public Szimulacio(int maxJarmu, Terkep terkep) 
            :base(5, terkep)
        {

        }

        private void EgyIdoEgysegEltelt()
        {
            for (int i = 0; i < jarmuvekN; i++)
            {
                if (jarmuvek[i] is MozgoJarmu)
                {
                    MozgoJarmu mozgoJarmu = jarmuvek[i] as MozgoJarmu;
                    mozgoJarmu.Mozog();
                    
                } 
            }
        }

        public void Fut()
        {
            while (true)
            {
                Kirajzol();
                EgyIdoEgysegEltelt();
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
