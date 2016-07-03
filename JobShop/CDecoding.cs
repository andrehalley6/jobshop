using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JobShop
{
    public class CDecoding
    {
        private int[] kerja_mesin;

        public CDecoding(int jml_mesin)
        {
            kerja_mesin = new int[jml_mesin];
            for (int i = 0; i < kerja_mesin.Length; i++)
            {
                kerja_mesin[i] = 0;
            }
        }

        //method pertama, buat himpunan A
        public List<string> SetHimpunan_A(List<string>[] input)
        {
            List<string> A = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Count; j++)
                {
                    if (input[i][j].Split("-".ToCharArray())[1] == "1")
                    {
                        A.Add(input[i][j]);
                    }
                }
            }

            return A;
        }

        public void SortHimpunan_A(List<string> A)
        {
            for (int i = 0; i < A.Count; i++)
            {
                for (int j = i + 1; j < A.Count; j++)
                {
                    if (Convert.ToInt32(A[j].Split("-".ToCharArray())[0]) < Convert.ToInt32(A[i].Split("-".ToCharArray())[0]))
                    {
                        //swap
                        string s = A[i];
                        A[i] = A[j];
                        A[j] = s;
                    }
                }
            }
        }

        //method kedua, cek start time, yang paling kecil diambil, bila sama ambil yang paling kiri di kromosom
        public int CekTime_t(List<int> t, List<string>[] kromosom, List<string> A)
        {
            int index = 0;  //index diisi 0 karena pada saat awal min dianggap pada t[0]
            int min = t[0];

            for (int i = 1; i < t.Count; i++)
            {
                if (t[i] < min)
                {
                    index = i;
                    min = t[i];
                }
            }

            List<string> temp = new List<string>();
            for (int i = 0; i < A.Count; i++)
            {
                if (t[i] == min)
                {
                    temp.Add(A[i]);
                }
            }

            bool isLeft = false;
            int foundAt = -1;
            for (int i = 0; i < kromosom.Length && !isLeft; i++)
            {
                for (int j = 0; j < kromosom[i].Count && !isLeft; j++)
                {
                    for (int k = 0; k < temp.Count && !isLeft; k++)
                    {
                        if (kromosom[i][j] == temp[k])
                        {
                            isLeft = true;
                            foundAt = k;
                        }
                    }
                }
            }

            bool isFound = false;
            if (isLeft)
            {
                for (int i = 0; i < A.Count && !isFound; i++)
                {
                    if (temp[foundAt] == A[i])
                    {
                        index = i;
                        isFound = true;
                    }
                }
            }

            return index;
        }

        public int NoMesin_M(List<string>[] kromosom, List<string> A, int index)
        {
            int no_mesin = -1;

            for (int i = 0; i < kromosom.Length; i++)
            {
                for (int j = 0; j < kromosom[i].Count; j++)
                {
                    if (A[index] == kromosom[i][j])
                    {
                        no_mesin = i;
                    }
                }
            }
            //MessageBox.Show("No mesin : " + no_mesin.ToString());

            return no_mesin;
        }

        public List<string> SetHimpunan_B(List<string>[] kromosom, List<string> A, int index, int no_mesin, List<int> t)
        {
            List<int> time_B = new List<int>();
            List<string> B = new List<string>();

            for (int j = 0; j < A.Count; j++)
            {
                for (int i = 0; i < kromosom[no_mesin].Count; i++)
                {
                    if (A[j] == kromosom[no_mesin][i])
                    {
                        B.Add(A[j]);
                        time_B.Add(t[j]);
                    }
                }
            }

            return this.UpdateHimpunan_B(B, A, t[index], time_B, kromosom);
        }

        public List<string> UpdateHimpunan_B(List<string> B, List<string> A, int wkt_min, List<int> time_B, List<string>[] kromosom)
        {
            if (B.Count > 1)
            {
                //kalo isi B > 1, dicek
                //bila ada isi di B, yang memiliki start time > B[index] dibuang
                //bila masih lebih dari 1, cek yang muncul paling kiri
                for (int i = B.Count - 1; i >= 0; i--)
                {
                    if (time_B[i] > wkt_min)
                    {
                        //MessageBox.Show("yang diremove : " + B[i]);
                        B.RemoveAt(i);
                    }
                }
            }

            bool isFinish = false;
            if (B.Count > 1)
            {
                for (int i = 0; i < kromosom.Length && !isFinish; i++)
                {
                    for (int j = 0; j < kromosom[i].Count && !isFinish; j++)
                    {
                        for (int k = 0; k < B.Count; k++)
                        {
                            if (kromosom[i][j] == B[k])
                            {
                                string isi = B[k];
                                B.Clear();
                                B.Add(isi);
                                isFinish = true;
                                break;
                            }
                        }
                    }
                }
            }

            return B;
        }


        public List<string> UpdateHimpunan_A(List<string> A, int index, List<string>[] kromosom)
        {
            string isiA = A[index];
            A.RemoveAt(index);

            string[] splitA = isiA.Split('-');
            int newA = Convert.ToInt32(splitA[1]) + 1;

            isiA = splitA[0] + "-" + newA;

            bool isFound = false;
            for (int i = 0; i < kromosom.Length && !isFound; i++)
            {
                for (int j = 0; j < kromosom[i].Count && !isFound; j++)
                {
                    if (isiA == kromosom[i][j])
                    {
                        A.Add(isiA);
                        isFound = true;
                    }
                }
            }

            return A;
        }

        public List<int> UpdateTime_t(List<int> t, List<string> A, int index, int no_mesin, int[][] wkt_proses, List<string>[] kromosom)
        {
            //method ini harus dipanggil sebelum method updateA dipanggil, karena method ini butuh job yang akan dibuang
            //cek proses yang akan dibuang
            string job_dibuang = A[index];

            //cek waktu proses yang akan dibuang, update total waktu kerja_mesin
            string index_proses = A[index].Split('-')[1];
            string index_job = A[index].Split('-')[0];
            kerja_mesin[no_mesin] = wkt_proses[Convert.ToInt32(index_job) - 1][Convert.ToInt32(index_proses) - 1] + t[index];

            string[] splitA = A[index].Split('-');
            string nextProcess = splitA[0] + "-" + Convert.ToString(Convert.ToInt32(splitA[1]) + 1);
            //MessageBox.Show("Next Process : " + nextProcess);

            //cek apakah next proses ada di kromosom
            bool isFound = false;
            List<string> nextA = new List<string>();
            for (int i = 0; i < kromosom.Length && !isFound; i++)
            {
                for (int j = 0; j < kromosom[i].Count && !isFound; j++)
                {
                    if (nextProcess == kromosom[i][j])
                    {
                        isFound = true;
                        //harus ditambahkan ke nextA
                        nextA.Add(nextProcess);
                    }
                }
            }

            //kemudian cek no mesin
            int nextMachine = -1;
            if (isFound)
            {
                nextMachine = this.NoMesin_M(kromosom, nextA, 0);
                //MessageBox.Show("next machine : " + nextMachine.ToString());
            }

            for (int i = 0; i < A.Count; i++)
            {
                int mesinA = this.NoMesin_M(kromosom, A, i);
                if (mesinA == no_mesin)
                {
                    t[i] = Math.Max(kerja_mesin[no_mesin], t[i]);
                }
            }

            //buang t[index], ditambah t yang baru isinya max
            if (nextMachine == -1)
            {
                t.RemoveAt(index);
            }
            else
            {
                int max = Math.Max(kerja_mesin[no_mesin], kerja_mesin[nextMachine]);
                t.RemoveAt(index);
                t.Add(max);
            }

            return t;
        }

        public int GetMakespan(int[] ready_time)
        {
            int max = kerja_mesin[0];
            int min = ready_time[0];
            for (int i = 1; i < ready_time.Length; i++)
            {
                if (ready_time[i] < min)
                {
                    min = ready_time[i];
                }
            }

            for (int i = 1; i < kerja_mesin.Length; i++)
            {
                if (kerja_mesin[i] > max)
                {
                    max = kerja_mesin[i];
                }
            }
            int makespan = max - min;

            return makespan;
        }
    }
}