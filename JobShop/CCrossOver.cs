using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JobShop
{
    public class CCrossOver
    {
        private int[] random_Pc;
        private int[] random_PPX;
        private Random fixRand;

        public CCrossOver()
        {
        }

        public int[] RandomizePc(int jml_generasi)
        {
            //Method buat me-random isi Pc, nilai yang dibawah nilai input Pc user di crossover
            fixRand = new Random();
            random_Pc = new int[jml_generasi];

            for (int i = 0; i < random_Pc.Length; i++)
            {
                random_Pc[i] = fixRand.Next(1, 100);
            }

            return random_Pc;
        }

        public int[] RandomizePPX(int pjg_kromosom)
        {
            //method buat me-random nilai PPX, nilainya antara 1 atau 2
            fixRand = new Random();
            random_PPX = new int[pjg_kromosom];

            for (int i = 0; i < random_PPX.Length; i++)
            {
                random_PPX[i] = fixRand.Next(1, 2);
            }

            return random_PPX;
        }

        public List<string>[] CrossOverPPX(List<string>[] kromosom1, List<string>[] kromosom2, int jml_mesin)
        {
            List<string>[] offSpring = new List<string>[jml_mesin];
            for (int i = 0; i < jml_mesin; i++)
            {
                offSpring[i] = new List<string>();
            }
            
            int linePPX = 0;
            for (int i = 0; i < jml_mesin; i++)
            {
                while (kromosom1[i].Count > 0)
                {
                    if (random_PPX[linePPX] == 1)
                    {
                        offSpring[i].Add(kromosom1[i][0]);
                        for (int k = 0; k < kromosom2[i].Count; k++)
                        {
                            if (kromosom1[i][0] == kromosom2[i][k])
                            {
                                kromosom2[i].RemoveAt(k);
                                break;
                            }
                        }

                        kromosom1[i].RemoveAt(0);
                    }
                    else
                    {
                        offSpring[i].Add(kromosom2[i][0]);

                        for (int k = 0; k < kromosom1[i].Count; k++)
                        {
                            if (kromosom2[i][0] == kromosom1[i][k])
                            {
                                kromosom1[i].RemoveAt(k);
                                break;
                            }
                        }

                        kromosom2[i].RemoveAt(0);
                    }
                    linePPX++;
                }
            }

            return offSpring;
        }
    }
}
