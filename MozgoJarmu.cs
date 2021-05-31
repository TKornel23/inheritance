using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orokles
{
    abstract class MozgoJarmu : Jarmu
    {
        protected float iranyX, iranyY;

        public MozgoJarmu(char az, float x, float y, Terkep terkep)
            : base(az, x, y, terkep)
        {
        }

        public void UjIranyVektor(float iranyX, float iranyY)
        {
            this.iranyX = iranyX;
            this.iranyY = iranyY;
        }

        public abstract void Mozog();
    }

    class Auto : MozgoJarmu
    {
        public Auto(char az, float x, float y, Terkep terkep)
            :base(az, x, y, terkep)
        {

        }

        protected override bool IdeLephet(float x, float y)
        {
            if (x < terkep.MeretX && terkep.Magassag(x,y) > 0 && y < terkep.MeretY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Mozog()
        {
            float xProba = x;
            float yProba = y;
            xProba += iranyX;
            yProba += iranyY;
            Console.WriteLine(azonosito.ToString() + ':' + this.iranyX + "-" + this.iranyY);
            if (IdeLephet(xProba, yProba))
            {
                if(terkep.Magassag(x, y) < terkep.Magassag(xProba, yProba))
                {
                    x += iranyX * 0.5f;
                    y += iranyY * 0.5f;
                }
                else if(terkep.Magassag(x,y) > terkep.Magassag(xProba, yProba))
                {
                    x += iranyX * 1.5f;
                    y += iranyY * 1.5f;
                }
                else if(terkep.Magassag(x,y) == terkep.Magassag(xProba, yProba))
                {
                    x += iranyX;
                    y += iranyY;
                }
            }
        }
    }

    sealed class Tank : Auto
    {
        private int uzemanyag;

        public Tank(char az, float x, float y, Terkep terkep, int üzemanyag)
            :base(az, x,y, terkep)
        {
            this.uzemanyag = üzemanyag;
        }

        protected override bool IdeLephet(float x,float y)
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

        public override void Mozog()
        {
            float xProba = x;
            float yProba = y;
            xProba += iranyX;
            yProba += iranyY;
            Console.WriteLine(azonosito.ToString() + ':' + this.iranyX + "-" + this.iranyY);
            if (IdeLephet(xProba, yProba) && this.uzemanyag >= 10 )
            {
                x += iranyX;
                y += iranyY;
                this.uzemanyag -= 10;
            }
        }
    }


    class Helikopter : MozgoJarmu
    {
        float sebesség;

        public Helikopter(Terkep terkep, float iranyX, float iranyY) 
            :base('H', iranyX, iranyY, terkep)
        {
            sebesség = 1.0f;
        }

        public void Gyorsít()
        {
            sebesség += .1f;
        }

        public void Lassit()
        {
            if ((sebesség - .1f) > 0)
            {
                sebesség -= .1f;
            }
        }

        public override void Mozog()
        {
            float xProba = x;
            float yProba = y;
            xProba += iranyX * this.sebesség;
            yProba += iranyY * this.sebesség;
            Console.WriteLine(azonosito.ToString() + ':' + this.iranyX +  "-" + this.iranyY);
            if (IdeLephet(xProba,  yProba))
            {
                x += iranyX * this.sebesség;
                y += iranyY * this.sebesség;
            }            
        }
    }
}
