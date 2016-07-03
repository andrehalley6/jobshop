using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JobShop
{
    public class CRouletteWheel
    {
        private Random fixRand;
        private double region;

        public CRouletteWheel()
        {
            fixRand = new Random();
        }

        public double Reproduction(int fitness, int tot_fitness)
        {
            //int fitness : nilai fitness kromosom tertentu
            //int tot_fitness : total fitness dari keseluruhan kromosom

            //method untuk melakukan reproduksi roulette wheel
            region = 0;
            region = ((double)fitness / (double)tot_fitness) * 360.0;

            return region;
        }

        public int RouletteWheelSelection(double[] result)
        {
            //double[] result : daerah-daerah yang dihasilkan oleh method Reproduction(int fitness, int tot_fitness)

            //pertama generate angka random dari 0 - 360
            int rand = fixRand.Next(0, 360);
            double temp = 0;
            int index = -1;

            bool isFound = false;
            for (int i = 0; i < result.Length && !isFound; i++)
            {
                temp += result[i];
                if (rand <= temp)
                {
                    index = i;
                    isFound = true;
                }
            }

            return index;
        }
    }
}