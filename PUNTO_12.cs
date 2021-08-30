using System;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACTIVIDAD_12

{
    class Program
    {
        static void Main(string[] args)
        {
            int v1=0, v2=0, v3=0, voto, max;
            double total, ov1, ov2, ov3;
            string ganador;

            Console.WriteLine("(1)Juan Zidane(2)Benet Solar");
            Console.WriteLine("(3)Juan Gutierrez(4)Salir");

            do
            {
                Console.Write("Ingrese el voto:");
                voto = int.Parse(Console.ReadLine());
                if (voto == 1)
                {
                    v1 = v1 + 1;
                }
                else if (voto == 2)
                {
                    v2 = v2 + 1;
                }
                else if (voto == 3)
                {
                    v3 = v3 + 1;
                }

            } while (voto != 4);
            
            
            total = v1 + v2 + v3;
            ov1 = (v1 / total) * 100;
            ov2 = (v2 / total) * 100;
            ov3 = (v3 / total) * 100;

            Console.WriteLine("Juan Zidane tiene : {0}", ov1);
            Console.WriteLine("SBenet Solar tiene : {0}", ov2);
            Console.WriteLine("Juan Gutierrez : {0}", ov3);

            max = v1;
            ganador = "Juan Zidane";
            if (v2 > max)
            {
                ganador = "Benet Solar";
            }
            if (v3 > max)
            {
                ganador = "Juan Gutierrez";
            }

            Console.WriteLine("Felicidades a : {0} es el nuevo ganador", ganador);
                    
            Console.ReadLine();
        }
    }
}