using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace JobShop
{
    public class CMemetic
    {
        private int[] ready_time;
        private string[] proses;
        private int[][] waktu_proses;
        CGenetic GA;
        CCrossOver CO;
        CMutasi Mutasi;
        CRouletteWheel RW;

        public CMemetic()
        {
            GA = new CGenetic();
            CO = new CCrossOver();
            Mutasi = new CMutasi();
            RW = new CRouletteWheel();
        }

        public int[] Ready_Time
        {
            get { return this.ready_time; }
            set { this.ready_time = value; }
        }

        public string[] Proses
        {
            get { return this.proses; }
            set { this.proses = value; }
        }

        public int[][] Waktu_Proses
        {
            get { return this.waktu_proses; }
            set { this.waktu_proses = value; }
        }

        public List<string>[][] MemeticAlgorithm(int jml_job, int jml_mesin, int max_generasi, int jml_populasi, int PC, int PM, int max_iterasi, int tabu_list)
        {

            List<string>[] isiKromosom = GA.Representation(jml_job, jml_mesin, proses);

            List<string>[][] kromosom = GA.GenerateRandomKromosom(isiKromosom, jml_mesin, jml_populasi);
            int[] prob_crossover = CO.RandomizePc(max_generasi);
            int[] prob_mutasi = Mutasi.RandomizePm(max_generasi);

            //jika ukuran iterasi tabu search > 0, maka setiap kromosom akan dioptimasi menggunakan tabu search
            if (max_iterasi != 0)
            {
                //for ini untuk local search menggunakan tabu search
                for (int j = 0; j < kromosom.Length; j++)
                {
                    //pruning digunakan untuk memotong local search apabila dalam 5 kali iterasi tidak ditemukan solusi lebih baik
                    int count = 0;
                    bool pruning = false;

                    CTabuSearch TabuSearch = new CTabuSearch(tabu_list);
                    List<string>[] new_move = kromosom[j];
                    TabuSearch.Aspiration_Criteria = this.Makespan(kromosom[j], jml_job, jml_mesin);
                    for (int k = 0; k < max_iterasi && !pruning; k++)
                    {
                        new_move = TabuSearch.GenerateMove(new_move, jml_mesin, waktu_proses, ready_time);

                        //setiap generate new move count++
                        count++;
                        //kromosom[j] dianggap sebagai best move yang diambil dan akan dioptimasi
                        if (this.Makespan(new_move, jml_job, jml_mesin) < this.Makespan(kromosom[j], jml_job, jml_mesin))
                        {
                            //tiap kali move diupdate count direset
                            count = 0;
                            kromosom[j] = new_move;
                            TabuSearch.AspirationCriteriaUpdate(this.Makespan(kromosom[j], jml_job, jml_mesin));
                        }
                        if (count == 5)
                        {
                            //jika setelah 5 kali iterasi tidak ditemukan move yang lebih baik, local search dipruning
                            //lanjutkan iterasi next kromosom
                            pruning = true;
                        }
                    }
                }
            }

            for (int i = 0; i < max_generasi; i++)
            {

                int[] fitness = new int[kromosom.Length];
                double[] roulette_wheel = new double[kromosom.Length];
                for (int j = 0; j < kromosom.Length; j++)
                {
                    fitness[j] = 0;
                    roulette_wheel[j] = 0;
                }

                //hit nilai fitness tiap individu
                int tot_fitness = 0;
                for (int j = 0; j < kromosom.Length; j++)
                {
                    fitness[j] = GA.HitFitness(jml_mesin, j, waktu_proses, ready_time);
                    tot_fitness += fitness[j];
                }

                for (int j = 0; j < kromosom.Length; j++)
                {
                    roulette_wheel[j] = RW.Reproduction(fitness[j], tot_fitness);
                    //MessageBox.Show("fitness : " + fitness[j].ToString() + "\ntot_fitness : " + tot_fitness.ToString());
                    //MessageBox.Show("Wilayah kromosom [" + j + "] : " + roulette_wheel[j].ToString());
                }

                //pilih individu yang akan direkombinasi
                //individu dipilih menggunakan roulette wheel selection
                if (prob_mutasi[i] < PM)
                {
                    //lakukan mutasi
                    int index_mutasi = RW.RouletteWheelSelection(roulette_wheel);
                    int mesin = Mutasi.RandomMesin(jml_mesin);
                    int locus1 = Mutasi.RandomLocus1(kromosom[index_mutasi][mesin].Count);
                    int locus2 = Mutasi.RandomLocus2(kromosom[index_mutasi][mesin].Count);
                    if (locus1 != locus2)
                        kromosom[index_mutasi] = Mutasi.OrderChanging(kromosom[index_mutasi]);
                }

                if (prob_crossover[i] < PC)
                {
                    //lakukan crossover
                    int[] PPX = CO.RandomizePPX(proses.Length);
                    int parent_1 = RW.RouletteWheelSelection(roulette_wheel);
                    int parent_2 = RW.RouletteWheelSelection(roulette_wheel);
                    if (parent_1 != parent_2)
                    {
                        List<string>[] offSpring = CO.CrossOverPPX(kromosom[parent_1], kromosom[parent_2], jml_mesin);
                        kromosom = GA.DeleteParentCrossOver(parent_1, parent_2, jml_mesin);
                        kromosom = GA.AddOffSpringCrossOver(offSpring, jml_mesin);
                    }
                }

                //setelah proses selection & mutasi, setiap kromosom dioptimasi lagi oleh local search
                if (max_iterasi != 0)
                {
                    //for ini untuk local search menggunakan tabu search
                    for (int j = 0; j < kromosom.Length; j++)
                    {
                        //pruning digunakan untuk memotong local search apabila dalam 5 kali iterasi tidak ditemukan solusi lebih baik
                        int count = 0;
                        bool pruning = false;

                        CTabuSearch TabuSearch = new CTabuSearch(tabu_list);
                        List<string>[] new_move = kromosom[j];
                        TabuSearch.Aspiration_Criteria = this.Makespan(kromosom[j], jml_job, jml_mesin);
                        for (int k = 0; k < max_iterasi && !pruning; k++)
                        {
                            new_move = TabuSearch.GenerateMove(new_move, jml_mesin, waktu_proses, ready_time);

                            //setiap generate new move count++
                            count++;

                            //kromosom[j] dianggap sebagai best move yang diambil dan akan dioptimasi
                            if (this.Makespan(new_move, jml_job, jml_mesin) < this.Makespan(kromosom[j], jml_job, jml_mesin))
                            {
                                //tiap kali move diupdate, count direset
                                count = 0;
                                kromosom[j] = new_move;
                                TabuSearch.AspirationCriteriaUpdate(this.Makespan(kromosom[j], jml_job, jml_mesin));
                            }
                            if (count == 5)
                            {
                                //jika setelah 5 kali iterasi tidak ditemukan move yang lebih baik, local search dipruning
                                //lanjutkan iterasi next kromosom
                                pruning = true;
                            }
                        }
                    }
                }
            }

            return kromosom;
        }

        public int Makespan(List<string>[] kromosom, int jml_job, int jml_mesin)
        {
            CDecoding Jadwal = new CDecoding(jml_mesin);
            List<string> A = Jadwal.SetHimpunan_A(kromosom);

            Jadwal.SortHimpunan_A(A);

            List<int> t = new List<int>();
            for (int i = 0; i < ready_time.Length; i++)
                t.Add(ready_time[i]);

            for (int i = 0; i < kromosom.Length; i++)
            {
                for (int j = 0; j < kromosom[i].Count; j++)
                {
                    int index = Jadwal.CekTime_t(t, kromosom, A);
                    int mesin = Jadwal.NoMesin_M(kromosom, A, index);
                    List<string> UpdateB = Jadwal.SetHimpunan_B(kromosom, A, index, mesin, t);

                    t = Jadwal.UpdateTime_t(t, A, index, mesin, waktu_proses, kromosom);
                    A = Jadwal.UpdateHimpunan_A(A, index, kromosom);
                }
            }

            return Jadwal.GetMakespan(ready_time);
        }

        public int getIndex(List<string>[][] kromosom, int jml_job, int jml_mesin)
        {
            //getIndex digunakan untuk menentukan indeks kromosom dengan makespan paling kecil
            int[] newFitness = new int[kromosom.Length];

            for (int i = 0; i < newFitness.Length; i++)
            {
                newFitness[i] = this.Makespan(kromosom[i], jml_job, jml_mesin);
            }

            int index = -1;
            int finalMakespan = 999999;
            for (int i = 0; i < newFitness.Length; i++)
            {
                if (newFitness[i] < finalMakespan)
                {
                    finalMakespan = newFitness[i];
                    index = i;
                }
            }

            return index;
        }
    }
}
