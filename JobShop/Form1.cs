using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace JobShop
{
    public partial class FormJobShop : Form
    {
        public FileStream file;
        public FormGanttChart GC;

        public FormJobShop()
        {
            InitializeComponent();
        }

        private void ButtonNewPress()
        {
            //fungsi ini digunakan untuk mereset semua field pada GUI bila button New ditekan
            NUDGeneticJmlPopulasi.Value = 2;
            NUDGeneticMaxGenerasi.Value = 1;
            NUDGeneticPc.Value = 0;
            NUDGeneticPm.Value = 0;
            NUDIterasiTS.Value = 0;
            NUDTabuList.Value = 0;
        }

        private void NUDJmlJob_ValueChanged(object sender, EventArgs e)
        {
            DGVJobShop.Rows.Clear();
            int i = (int)NUDJmlJob.Value;
            DGVJobShop.Rows.Add(i);
            for (i = 0; i < NUDJmlJob.Value; i++)
            {
                //DGVJobShop.Rows[i].Cells[0].Value = i + 1;
                DGVJobShop[0, i].Value = i + 1;
            }
        }

        private void NUDJmlMesin_ValueChanged(object sender, EventArgs e)
        {
            DGVJobShop.Columns.Clear();
            DGVJobShop.Columns.Add("Job", "Job");
            DGVJobShop.Columns.Add("ReadyTime", "Ready Time");
            this.NUDJmlJob_ValueChanged(this, e);
            for (int i = 0; i < NUDJmlMesin.Value; i++)
            {
                DGVJobShop.Columns.Add("Operation" + (i + 1), "M" + (i + 1) + ",P" + (i + 1));
            }
        }

        private void BtnNewJadwal_Click(object sender, EventArgs e)
        {
            ButtonNewPress();
            NUDJmlJob.Value = 1;
            NUDJmlMesin.Value = 1;
            this.NUDJmlMesin_ValueChanged(this, e);
        }

        private void BtnLoadJadwal_Click(object sender, EventArgs e)
        {
            //untuk me-load jadwal dari file
            //file extension *.job
            OFDJadwal.FileName = "";
            if (OFDJadwal.ShowDialog() == DialogResult.OK)
            {
                file = new FileStream(OFDJadwal.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                //baca 2 baris pertama set ke jumlah job & jumlah mesin, set data grid view
                NUDJmlJob.Value = Convert.ToInt32(sr.ReadLine());
                NUDJmlMesin.Value = Convert.ToInt32(sr.ReadLine());
                
                string s;
                int line = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    
                    //tiap ada ' ' (spasi), dipisahin, buat di tiap cell dgv
                    string[] temp = s.Split(" ".ToCharArray());
                    for (int i = 0; i < temp.Length; i++)
                    {
                        DGVJobShop[i, line].Value = temp[i];
                    }
                    //turunin 1 line
                    line++;
                }

                sr.Close();
                file.Close();
            }
        }

        private void BtnSaveJadwal_Click(object sender, EventArgs e)
        {
            //untuk men-save jadwal menjadi file
            //file extension *.job
            SFDJadwal.FileName = "";
            if (SFDJadwal.ShowDialog() == DialogResult.OK)
            {
                file = new FileStream(SFDJadwal.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);

                sw.WriteLine(NUDJmlJob.Value);
                sw.WriteLine(NUDJmlMesin.Value);
                for (int i = 0; i < NUDJmlJob.Value; i++)
                {
                    for (int j = 0; j < NUDJmlMesin.Value + 2; j++)
                    {
                        if (j == NUDJmlMesin.Value + 1) //jika ini adalah yang terakhir maka diberi enter
                        {
                            //jika ada proses yang null diisi 0,0 dianggap tidak ada proses
                            if (DGVJobShop[j, i].Value == null)
                                DGVJobShop[j, i].Value = "0,0";
                            sw.WriteLine(DGVJobShop[j, i].Value.ToString());
                        }
                        else
                        {
                            //jika ada no job yang null diisi dengan no job yang sesuai
                            if (DGVJobShop[0, i].Value == null)
                                DGVJobShop[0, i].Value = i + 1;
                            //jika ready time null diisi dengan 0
                            if (DGVJobShop[1, i].Value == null)
                                DGVJobShop[1, i].Value = "0";
                            //jika ada proses yang null diisi 0,0 dianggap tidak ada proses
                            if (DGVJobShop[j, i].Value == null)
                                DGVJobShop[j, i].Value = "0,0";
                            sw.Write(DGVJobShop[j, i].Value.ToString() + " ");
                        }
                    }
                }

                sw.Close();
                file.Close();
            }
        }

        public int[] GetReadyTime()
        {
            int[] ready_time = new int[(int)NUDJmlJob.Value];

            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
            {
                if (DGVJobShop[1, i] == null)
                    DGVJobShop[1, i].Value = 0;
                try
                {
                    ready_time[i] = Convert.ToInt32(DGVJobShop[1, i].Value);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ready time tidak dapat berupa string", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                if (Convert.ToInt32(DGVJobShop[1, i].Value) < 0)
                {
                    MessageBox.Show("Ready time tidak dapat bernilai negatif", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            return ready_time;
        }

        public string[] GetProses()
        {
            string[] proses = new string[(int)NUDJmlJob.Value * (int)NUDJmlMesin.Value];

            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
            {
                for (int j = 0; j < (int)NUDJmlMesin.Value; j++)
                {
                    if (DGVJobShop[j + 2, i].Value == null)
                        DGVJobShop[j + 2, i].Value = "0,0";

                    string[] str = DGVJobShop[j + 2, i].Value.ToString().Split(',');
                    if (str.Length == 2)
                    {
                        for (int k = 0; k < str.Length; k++)
                        {
                            try
                            {
                                Convert.ToInt32(str[k]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Isi data grid view pada cells[" + (j + 2) + "," + i + "] tidak sesuai format\nFormat penulisan : 'integer,integer'", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return null; ;
                            }
                        }
                        if ((Convert.ToInt32(str[0]) < 1 && (Convert.ToInt32(str[1]) < 0 || Convert.ToInt32(str[1]) > 0)) || Convert.ToInt32(str[0]) > (int)NUDJmlMesin.Value)
                        {
                            MessageBox.Show("Nomor mesin pada cells[" + (j + 2) + "," + i + "] harus diantara 1 - " + NUDJmlMesin.Value.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                        if (Convert.ToInt32(str[1]) < 1 && Convert.ToInt32(str[0]) != 0)
                        {
                            MessageBox.Show("Lama proses pada cells[" + (j + 2) + "," + i + "] harus lebih besar dari 0", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Isi data grid view pada cells[" + (j + 2) + "," + i + "] tidak sesuai format\nFormat penulisan : 'integer,integer'", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }

            //dalam satu job tidak boleh ada nomor mesin yang sama
            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
            {
                for (int j = 2; j < (int)NUDJmlMesin.Value + 2; j++)
                {
                    string first = DGVJobShop[j, i].Value.ToString().Split(',')[0];
                    for (int k = j + 1; k < (int)NUDJmlMesin.Value + 2; k++)
                    {
                        string second = DGVJobShop[k, i].Value.ToString().Split(',')[0];
                        if (first == second && (first != "0" || second != "0"))
                        {
                            MessageBox.Show("Dalam 1 job, tidak ada proses yang dikerjakan pada mesin yang sama", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }
            }

            int line = 0;

            //Proses ini digunakan untuk merepresentasikan kromosom
            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
            {
                for (int j = 2; j < (int)NUDJmlMesin.Value + 2; j++)
                {
                    if (DGVJobShop[j, i].Value == null)
                    {
                        proses[line] = "0,0";
                        line++;
                    }
                    else
                    {
                        proses[line] = DGVJobShop[j, i].Value.ToString();
                        line++;
                    }
                }
            }

            return proses;
        }

        public int[][] GetWktProses()
        {
            int[][] waktu_proses = new int[(int)NUDJmlJob.Value][];
            for (int i = 0; i < waktu_proses.Length; i++)
            {
                waktu_proses[i] = new int[(int)NUDJmlMesin.Value];
            }

            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
                for (int j = 0; j < (int)NUDJmlMesin.Value; j++)
                    if (DGVJobShop[j + 2, i] != null)
                        waktu_proses[i][j] = Convert.ToInt32(DGVJobShop[j + 2, i].Value.ToString().Split(',')[1]);

            return waktu_proses;
        }

        public bool CekInputUser()
        {
            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
                for (int j = 0; j < (int)NUDJmlMesin.Value; j++)
                    if (DGVJobShop[j + 2, i].Value == null)
                        DGVJobShop[j + 2, i].Value = "0,0";

            //cek no job
            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
            {
                if (DGVJobShop[0, i].Value == null)
                    DGVJobShop[0, i].Value = i + 1;
                try
                {
                    Convert.ToInt32(DGVJobShop[0, i].Value);
                }
                catch (Exception)
                {
                    DGVJobShop[0, i].Value = i + 1;
                    return false;
                }
                if (Convert.ToInt32(DGVJobShop[0, i].Value) != (i + 1))
                    DGVJobShop[0, i].Value = i + 1;
            }


            //cek start time
            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
            {
                if (DGVJobShop[1, i].Value == null)
                    DGVJobShop[1, i].Value = 0;
                try
                {
                    Convert.ToInt32(DGVJobShop[1, i].Value);
                }
                catch (Exception)
                {
                    //DGVJobShop[1, i].Value = 0;
                    MessageBox.Show("Ready time tidak dapat berupa string", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DGVJobShop[1, i].Selected = true;
                    return false;
                }
                if (Convert.ToInt32(DGVJobShop[1, i].Value) < 0)
                {
                    MessageBox.Show("Ready time tidak dapat bernilai negatif", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //DGVJobShop[1, i].Value = 0;
                    DGVJobShop[1, i].Selected = true;
                    return false;
                }
            }

            //cek isi job&proses
            //setiap job harus mempunyai proses sebelumnya
            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
            {
                for (int j = 0; j < (int)NUDJmlMesin.Value - 1; j++)
                {
                    if (DGVJobShop[j + 2, i].Value == null)
                        DGVJobShop[j + 2, i].Value = "0,0";
                    //MessageBox.Show("Value : " + DGVJobShop[j + 2, i].Value.ToString());
                    if (DGVJobShop[j + 2, i].Value.ToString() == "0,0" && DGVJobShop[j + 3, i].Value.ToString() != "0,0")
                    {
                        MessageBox.Show("Error pada cells[" + (j + 2) + "," + i + "] setiap proses harus mempunyai proses sebelumnya", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DGVJobShop[j + 2, i].Selected = true;
                        return false;
                    }
                }
            }

            //input no mesin dan lama proses harus integer, tidak bisa string dan harus lebih besar 0
            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
            {
                for (int j = 0; j < (int)NUDJmlMesin.Value; j++)
                {
                    if (DGVJobShop[j + 2, i].Value == null)
                        DGVJobShop[j + 2, i].Value = "0,0";
                    string[] str = DGVJobShop[j + 2, i].Value.ToString().Split(',');
                    if (str.Length == 2)
                    {
                        for (int k = 0; k < str.Length; k++)
                        {
                            try
                            {
                                Convert.ToInt32(str[k]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Isi data grid view pada cells[" + (j + 2) + "," + i + "] tidak sesuai format\nFormat penulisan : 'integer,integer'", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                DGVJobShop[j + 2, i].Selected = true;
                                return false;
                            }
                        }
                        if ((Convert.ToInt32(str[0]) < 1 && (Convert.ToInt32(str[1]) < 0 || Convert.ToInt32(str[1]) > 0)) || Convert.ToInt32(str[0]) > (int)NUDJmlMesin.Value)
                        {
                            MessageBox.Show("Nomor mesin pada cells[" + (j + 2) + "," + i + "] harus diantara 1 - " + NUDJmlMesin.Value.ToString(), "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DGVJobShop[j + 2, i].Selected = true;
                            return false;
                        }
                        if (Convert.ToInt32(str[1]) < 1 && Convert.ToInt32(str[0]) != 0)
                        {
                            MessageBox.Show("Lama proses pada cells[" + (j + 2) + "," + i + "] harus lebih besar dari 0", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DGVJobShop[j + 2, i].Selected = true;
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Isi data grid view pada cells[" + (j + 2) + "," + i + "] tidak sesuai format\nFormat penulisan : 'integer,integer'", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DGVJobShop[j + 2, i].Selected = true;
                        return false;
                    }
                }
            }

            //dalam satu job tidak boleh ada nomor mesin yang sama
            for (int i = 0; i < (int)NUDJmlJob.Value; i++)
            {
                for (int j = 2; j < (int)NUDJmlMesin.Value + 2; j++)
                {
                    string first = DGVJobShop[j, i].Value.ToString().Split(',')[0];
                    //string second = DGVJobShop[j + 3, i].Value.ToString().Split(',')[0];
                    for (int k = j + 1; k < (int)NUDJmlMesin.Value + 2; k++)
                    {
                        string second = DGVJobShop[k, i].Value.ToString().Split(',')[0];
                        //MessageBox.Show(first + "\n" + second);
                        if (first == second && (first != "0" || second != "0"))
                        {
                            MessageBox.Show("Dalam 1 job, tidak ada proses yang dikerjakan pada mesin yang sama", "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DGVJobShop[k, i].Selected = true;
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void BtnGenerateJadwal_Click_1(object sender, EventArgs e)
        {
            CMemetic Memetic = new CMemetic();
            if (CekInputUser())
            {
                TimeSpan left = new TimeSpan(DateTime.Now.Ticks);
                BtnGenerateJadwal.Enabled = false;
                Memetic.Waktu_Proses = this.GetWktProses();
                Memetic.Ready_Time = this.GetReadyTime();
                Memetic.Proses = this.GetProses();

                List<string>[][] kromosom = Memetic.MemeticAlgorithm((int)NUDJmlJob.Value, (int)NUDJmlMesin.Value, (int)NUDGeneticMaxGenerasi.Value, (int)NUDGeneticJmlPopulasi.Value, (int)NUDGeneticPc.Value, (int)NUDGeneticPm.Value, (int)NUDIterasiTS.Value, (int)NUDTabuList.Value);
                int idx_kro = Memetic.getIndex(kromosom, (int)NUDJmlJob.Value, (int)NUDJmlMesin.Value);

                GC = new FormGanttChart((int)NUDJmlMesin.Value);

                CDecoding Jadwal = new CDecoding((int)NUDJmlMesin.Value);
                List<string> A = Jadwal.SetHimpunan_A(kromosom[idx_kro]);
                Jadwal.SortHimpunan_A(A);
                List<int> t = new List<int>();
                for (int i = 0; i < Memetic.Ready_Time.Length; i++)
                    t.Add(Memetic.Ready_Time[i]);

                for (int i = 0; i < kromosom[idx_kro].Length; i++)
                {
                    for (int j = 0; j < kromosom[idx_kro][i].Count; j++)
                    {
                        int index = Jadwal.CekTime_t(t, kromosom[idx_kro], A);
                        int mesin = Jadwal.NoMesin_M(kromosom[idx_kro], A, index);
                        List<string> UpdateB = Jadwal.SetHimpunan_B(kromosom[idx_kro], A, index, mesin, t);

                        string index_proses = A[index].Split('-')[1];
                        string index_job = A[index].Split('-')[0];

                        GC.addProcess(UpdateB[0], t[index], Memetic.Waktu_Proses[Convert.ToInt32(index_job) - 1][Convert.ToInt32(index_proses) - 1], mesin);

                        t = Jadwal.UpdateTime_t(t, A, index, mesin, Memetic.Waktu_Proses, kromosom[idx_kro]);
                        A = Jadwal.UpdateHimpunan_A(A, index, kromosom[idx_kro]);
                    }
                }


                BtnGenerateJadwal.Enabled = true;
                TimeSpan right = new TimeSpan(DateTime.Now.Ticks);
                MessageBox.Show("Total time : " + right.Subtract(left));
                GC.ShowDialog();
                MessageBox.Show("Makespan : "+Memetic.Makespan(kromosom[idx_kro],(int)NUDJmlJob.Value,(int)NUDJmlMesin.Value));
            }
        }
    }
}