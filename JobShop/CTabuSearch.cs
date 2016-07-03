using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JobShop
{
    public class CTabuSearch
    {
        private int ukr_tabu_list;
        private int aspiration_criteria;
        private int jumlah_candidate;
        private int[] evaluation;
        private List<string>[][] candidate;

        public struct CElemTabuList
        {
            public int no_job1;
            public int no_job2;
            public int no_mesin;

            public CElemTabuList(int job1, int job2, int mesin)
            {
                no_job1 = job1;
                no_job2 = job2;
                no_mesin = mesin;
            }
        }

        private List<CElemTabuList> tabu_list;

        public CTabuSearch()
        {
        }

        public CTabuSearch(int ukr_tabu_list)
        {
            jumlah_candidate = 0;
            this.ukr_tabu_list = ukr_tabu_list;
            tabu_list = new List<CElemTabuList>();
        }

        public int Aspiration_Criteria
        {
            get { return this.aspiration_criteria; }
            set { this.aspiration_criteria = value; }
        }

        public List<string>[] GenerateMove(List<string>[] kromosom, int jml_mesin, int[][] wkt_proses, int[] ready_time)
        {
            //keterangan parameter
            //List<string>[] kromosom : kromosom yang akan digenerate move-nya
            //int jml_mesin : jumlah mesin

            List<CCandidate> isi_tabu_list = new List<CCandidate>();
            //isi_tabu_list = new List<CCandidate>();
            jumlah_candidate = 0;

            for (int i = 0; i < kromosom.Length; i++)
            {
                jumlah_candidate += (kromosom[i].Count - 1);
            }

            evaluation = new int[jumlah_candidate];

            candidate = new List<string>[jumlah_candidate][];
            for (int i = 0; i < candidate.Length; i++)
            {
                candidate[i] = new List<string>[jml_mesin];
                for (int j = 0; j < jml_mesin; j++)
                {
                    candidate[i][j] = new List<string>();
                }
            }

            if (jumlah_candidate != 0)
            {

                for (int i = 0; i < candidate.Length; i++)
                {
                    for (int j = 0; j < kromosom.Length; j++)
                    {
                        for (int k = 0; k < kromosom[j].Count; k++)
                        {
                            //isi candidate = isi kromosom, selanjutnya baru ditukar dengan sebelahnya
                            candidate[i][j].Add(kromosom[j][k]);
                        }
                    }
                }

                int mesin = 0;
                for (int i = 0; i < jumlah_candidate; )
                {
                    for (int j = 0; mesin < jml_mesin; mesin++, j = 0)
                    {
                        for (; j < kromosom[mesin].Count - 1; j++)
                        {
                            string swap = candidate[i][mesin][j];
                            candidate[i][mesin][j] = candidate[i][mesin][j + 1];
                            candidate[i][mesin][j + 1] = swap;
                            isi_tabu_list.Add(new CCandidate(Convert.ToInt32(candidate[i][mesin][j].Split('-')[0]), Convert.ToInt32(candidate[i][mesin][j + 1].Split('-')[0]), mesin, false));
                            i++;
                        }
                    }
                }

                for (int i = 0; i < jumlah_candidate; i++)
                    evaluation[i] = this.HitNilaiEvaluasi(i, jml_mesin, wkt_proses, ready_time);

                if (ukr_tabu_list > jumlah_candidate)
                    ukr_tabu_list = jumlah_candidate - 1;

                if (ukr_tabu_list == 0)
                    return kromosom;

                int index = -1;
                index = this.LocalOptimum(jml_mesin, isi_tabu_list, index);
                this.AddTabuList(isi_tabu_list[index].Job1, isi_tabu_list[index].Job2, isi_tabu_list[index].Mesin);
                //this.AddTabuList(isi_tabu_list[index].job1, isi_tabu_list[index].job2, isi_tabu_list[index].mesin);

                return candidate[index];
            }

            else
            {
                return kromosom;
            }
        }

        public int HitNilaiEvaluasi(int idx, int jml_mesin, int[][] wkt_proses, int[] ready_time)
        {
            CDecoding Jadwal = new CDecoding(jml_mesin);
            evaluation[idx] = 0;

            List<string> A = Jadwal.SetHimpunan_A(candidate[idx]);
            Jadwal.SortHimpunan_A(A);

            List<int> t = new List<int>();
            for (int i = 0; i < ready_time.Length; i++)
                t.Add(ready_time[i]);

            for (int i = 0; i < candidate[idx].Length; i++)
            {
                for (int j = 0; j < candidate[idx][i].Count; j++)
                {
                    int index = Jadwal.CekTime_t(t, candidate[idx], A);
                    int mesin = Jadwal.NoMesin_M(candidate[idx], A, index);
                    List<string> B = Jadwal.SetHimpunan_B(candidate[idx], A, index, mesin, t);

                    t = Jadwal.UpdateTime_t(t, A, index, mesin, wkt_proses, candidate[idx]);
                    A = Jadwal.UpdateHimpunan_A(A, index, candidate[idx]);
                }
            }

            return evaluation[idx] = Jadwal.GetMakespan(ready_time);
        }

        public int LocalOptimum(int jml_mesin, List<CCandidate> cek_tabu, int index)
        {
            //List<string>[][] candidate : candidate yang akan optimasi menggunakan tabu search
            //int jml_mesin : jumlah mesin
            //List<CCandidate> cek_tabu : untuk mengecek move yang diambil admissible atau inadmissible
            //int index : mengembalikan indeks candidate terbaik

            bool notTabu = false;
            int tabuCount;
            //int index = -1;
            while (!notTabu)
            {
                tabuCount = 0;
                index = this.BestMakeSpan(cek_tabu);
                if (tabu_list.Count != 0)
                {
                    for (int i = 0; i < tabu_list.Count; i++)
                    {
                        if (cek_tabu[index].Job1 == tabu_list[i].no_job1 && cek_tabu[index].Job2 == tabu_list[i].no_job2 && cek_tabu[index].Mesin == tabu_list[i].no_mesin && evaluation[index] > aspiration_criteria)
                        {
                            tabuCount++;
                        }
                    }
                }
                if (tabuCount == 0)
                    notTabu = true;
            }

            return index;
        }

        public int BestMakeSpan(List<CCandidate> cek_tabu)
        {
            //int[] evaluation : kumpulan nilai evaluasi dari n kromosom yang akan dioptimasi
            //List<CCandidate> cek_Tabu : untuk mengecek nilai evaluasi yang diambil admissible atau inadmissible

            int index = -1;
            int minimum = 999999;
            int temp = aspiration_criteria;

            for (int i = 0; i < evaluation.Length; i++)
            {
                //cek yang paling minimum & dicek jg apakah yang paling minimum sudah pernah dicoba
                if (evaluation[i] < minimum && cek_tabu[i].IsTabu == false)
                {
                    minimum = evaluation[i];
                    index = i;
                }
                else if (cek_tabu[i].IsTabu == true && evaluation[i] < temp)
                {
                    index = i;
                    temp = evaluation[i];
                }
            }

            cek_tabu[index].IsTabu = true;
                        
            return index;
        }

        public void AddTabuList(int job1, int job2, int mesin)
        {
            //int job1 : job pertama yang akan ditambahkan ke tabu list
            //int job2 : job kedua yang akan ditambahkan ke tabu list
            //int mesin : nomor mesin yang akan ditambahkan ke tabu list
            //int ukr_tabu_list : ukuran maksimum tabu list

            if (tabu_list.Count < ukr_tabu_list)
            {
                tabu_list.Add(new CElemTabuList(job1, job2, mesin));
            }
            else
            {
                tabu_list.RemoveAt(0);
                tabu_list.Add(new CElemTabuList(job1, job2, mesin));
            }
        }

        public int AspirationCriteriaUpdate(int new_aspiration_criteria)
        {
            //int new_aspiration_criteria : kriteria aspirasi baru

            if (new_aspiration_criteria < aspiration_criteria)
                return aspiration_criteria = new_aspiration_criteria;
            else
                return aspiration_criteria;
        }
    }
}
