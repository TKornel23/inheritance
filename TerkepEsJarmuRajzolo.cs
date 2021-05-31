using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles
{
    class TerkepEsJarmuRajzolo : TerkepRajzolo
    {
        public Jarmu[] jarmuvek;
 
        protected int jarmuvekN
        {
            get
            {
                int szamolo = 0;
                while (szamolo < jarmuvek.Length && jarmuvek[szamolo] != null)
                {
                    szamolo++;
                }
                return szamolo;
            }           
        }


        public TerkepEsJarmuRajzolo(int maxJarmu,Terkep terkep)
            :base(terkep)
        {
            jarmuvek = new Jarmu[maxJarmu];
        }   

        public void JarmuFelvetel(Jarmu jarmu)
        {
            jarmuvek[jarmuvekN] = jarmu;
        }

        protected override char MiVanItt(int x, int y)
        {
            for (int i = 0; i < jarmuvekN; i++)
            {
                if((int)jarmuvek[i].x == x && (int)jarmuvek[i].y == y)
                {
                    return jarmuvek[i].azonosito;
                }                      
            }
            return base.MiVanItt(x, y);
        }
    }
}
