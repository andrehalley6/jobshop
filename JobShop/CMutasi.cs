using System;
using System.Collections.Generic;
using System.Text;

namespace JobShop
{
    public class CMutasi
    {
        private int locus_1;
        private int locus_2;
        private int no_mesin;
        private int[] randomPm;
        private Random fixRand;

        public CMutasi()
        {
        }

        public int RandomMesin(int jml_mesin)
        {
            //int jml_mesin : jumlah mesin

            //method untuk merandom nomor mesin,no mesin yg dirandom antara no.1 - jml mesin yg ada
            fixRand = new Random();
            return no_mesin = fixRand.Next(0, jml_mesin - 1);
        }

        public int RandomLocus1(int pjg_locus)
        {
            //int pjg_locus : panjang locus

            locus_1 = -1;
            //method untuk merandom nomor locus 1
            fixRand = new Random();
            return locus_1 = fixRand.Next(0, pjg_locus - 1);
        }

        public int RandomLocus2(int pjg_locus)
        {
            //int pjg_locus : panjang locus

            locus_2 = -1;
            fixRand = new Random();
            return locus_2 = fixRand.Next(0, pjg_locus - 1);
        }

        public int[] RandomizePm(int jml_generasi)
        {
            //int jml_generasi : maksimum generasi

            Random fixRand = new Random();
            randomPm = new int[jml_generasi];

            for (int i = 0; i < randomPm.Length; i++)
            {
                randomPm[i] = fixRand.Next(0, 100);
            }

            return randomPm;
        }

        public List<string>[] OrderChanging(List<string>[] kromosom)
        {
            //keterangan parameter
            //List<string>[] kromosom : kromosom yang akan dimutasi, kromosom[no_mesin]
            //int no_mesin : nomor mesin kromosom yang akan dimutasi

            string swap;
            swap = kromosom[no_mesin][locus_1];
            kromosom[no_mesin][locus_1] = kromosom[no_mesin][locus_2];
            kromosom[no_mesin][locus_2] = swap;

            return kromosom;
        }
    }
}