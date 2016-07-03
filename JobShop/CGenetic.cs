using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JobShop
{
    public class CGenetic
    {
        private List<string>[][] kromosom;
        private int fitness;

        public CGenetic()
        {
        }

        public List<string>[] Representation(int jml_job, int jml_mesin, string[] isi)
        {
            //keterangan parameter
            //jml_job : jumlah job yang diinput user di interface
            //jml_mesin : jumlah mesin yang diinput user di interface
            //string[] isi : isi dari DGV yang diinput user, yang akan digunakan untuk representasi kromosom

            List<string>[] representasiKromosom = new List<string>[jml_mesin];

            for (int i = 0; i < jml_mesin; i++)
            {
                representasiKromosom[i] = new List<string>();
            }

            int idx;
            int line = 0;
            int no_job = 1;
            int proses = 1;

            for (int i = 0; i < jml_job; i++)
            {
                proses = 1;
                for (int j = 2; j < jml_mesin + 2; j++)
                {
                    if (isi[line] == "0,0" || isi[line] == null)
                    {
                        line++;
                    }
                    else if (isi[line] != null || isi[line] != "0,0")
                    {
                        idx = Convert.ToInt32(isi[line].Split(",".ToCharArray())[0]);
                        //karena menggunakan list, tidak perlu dipisah menggunakan separator apapun
                        representasiKromosom[idx - 1].Add(no_job.ToString() + "-" + proses.ToString());
                        line++;
                        proses++;
                    }
                }
                no_job++;
            }

            return representasiKromosom;
        }

        public List<string>[][] GenerateRandomKromosom(List<string>[] representasi, int jml_mesin, int jml_populasi)
        {
            kromosom = new List<string>[jml_populasi][];
            for (int i = 0; i < jml_populasi; i++)
            {
                kromosom[i] = new List<string>[jml_mesin];
                for (int j = 0; j < jml_mesin; j++)
                {
                    kromosom[i][j] = new List<string>();
                }
            }

            Random rand = new Random();
            int a, b;   //buat tampung angka random

            for (int j = 0; j < jml_populasi; j++)
            {
                for (int i = 0; i < representasi.Length; i++)
                {
                    for (int k = 0; k < 2; k++) //for yang ini cuma buat random
                    {
                        
                        a = rand.Next(0, representasi[i].Count - 1);
                        b = rand.Next(0, representasi[i].Count - 1);

                        //buat tukar posisi kromosom
                        if (a != b)
                        {
                            string s = representasi[i][a];
                            representasi[i][a] = representasi[i][b];
                            representasi[i][b] = s;
                        }
                    }
                }

                for (int x = 0; x < representasi.Length; x++)
                    for (int y = 0; y < representasi[x].Count; y++)
                        kromosom[j][x].Add(representasi[x][y]);
            }

            return kromosom;
        }

        public int HitFitness(int jml_mesin, int no_kromosom, int[][] wkt_proses, int[] ready_time)
        {
            CDecoding Jadwal = new CDecoding(jml_mesin);
            fitness = 0;

            List<string> A = Jadwal.SetHimpunan_A(kromosom[no_kromosom]);
            Jadwal.SortHimpunan_A(A);

            List<int> t = new List<int>();
            for (int i = 0; i < ready_time.Length; i++)
                t.Add(ready_time[i]);

            for (int i = 0; i < kromosom[no_kromosom].Length; i++)
            {
                for (int j = 0; j < kromosom[no_kromosom][i].Count; j++)
                {
                    int index = Jadwal.CekTime_t(t, kromosom[no_kromosom], A);
                    int mesin = Jadwal.NoMesin_M(kromosom[no_kromosom], A, index);
                    List<string> B = Jadwal.SetHimpunan_B(kromosom[no_kromosom], A, index, mesin, t);

                    t = Jadwal.UpdateTime_t(t, A, index, mesin, wkt_proses, kromosom[no_kromosom]);
                    A = Jadwal.UpdateHimpunan_A(A, index, kromosom[no_kromosom]);
                }
            }
            fitness = Jadwal.GetMakespan(ready_time);

            return fitness;
        }

        public List<string>[][] DeleteParentCrossOver(int idx_parent_1, int idx_parent_2, int jml_mesin)
        {
            //hapus kromosom_parent dari List<string> kromosom
            //inisialisasi newKromosom
            List<string>[][] newKromosom = new List<string>[kromosom.Length - 2][];
            for (int i = 0; i < newKromosom.Length; i++)
            {
                newKromosom[i] = new List<string>[jml_mesin];
                for (int j = 0; j < newKromosom[i].Length; j++)
                {
                    newKromosom[i][j] = new List<string>();
                }
            }

            bool isSame = false;
            for (int i = 0, index = 0; i < kromosom.Length; i++, index++)
            {
                isSame = false;
                for (int j = 0; j < kromosom[i].Length && !isSame; j++)
                {
                    if (kromosom[i][j].Count > 0)
                    {
                        for (int k = 0; k < kromosom[i][j].Count && !isSame; k++)
                        {
                            if (i == idx_parent_1 || i == idx_parent_2)
                            {
                                isSame = true;
                                index--;
                            }
                            else
                            {
                                newKromosom[index][j].Add(kromosom[i][j][k]);
                            }
                        }
                    }
                    else
                    {
                        index--;
                        isSame = true;
                    }
                }
            }

            return kromosom = newKromosom;
        }

        public List<string>[][] AddOffSpringCrossOver(List<string>[] offspring, int jml_mesin)
        {
            //add offspring ke List<string> kromosom
            List<string>[][] newKromosom = new List<string>[kromosom.Length + 1][];
            for (int i = 0; i < newKromosom.Length; i++)
            {
                newKromosom[i] = new List<string>[jml_mesin];
                for (int j = 0; j < newKromosom[i].Length; j++)
                {
                    newKromosom[i][j] = new List<string>();
                }
            }

            for (int i = 0; i < kromosom.Length; i++)
            {
                for (int j = 0; j < kromosom[i].Length; j++)
                {
                    for (int k = 0; k < kromosom[i][j].Count; k++)
                    {
                        newKromosom[i][j].Add(kromosom[i][j][k]);
                    }
                }
            }

            for (int i = 0; i < offspring.Length; i++)
            {
                for (int j = 0; j < offspring[i].Count; j++)
                {
                    newKromosom[newKromosom.Length - 1][i].Add(offspring[i][j]);
                }
            }

            return kromosom = newKromosom;
        }
    }
}
