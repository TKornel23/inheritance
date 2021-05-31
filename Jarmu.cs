using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles
{
    class Jarmu
    {
        public char azonosito;
        public float x { get; protected set; }
        public float y { get; protected set; }

        public Terkep terkep;

        public Jarmu(char az, float x, float y, Terkep terkep)
        {
            this.azonosito = az;
            this.x = x;
            this.y = y;
            this.terkep = terkep;
        }

        protected virtual bool IdeLephet(float x,float y)
        {
            if (x < terkep.MeretX && y < terkep.MeretY && x > 0 && y > 0)
            {             
                return true;               
            }
            else
            {
                return false;
            }   
        }

    }
}
