using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JobShop
{
    public partial class FormGanttChart : Form
    {
        public struct CGanttChart
        {
            public string nama;
            public int start_time;
            public int lama_proses;

            public CGanttChart(string nama, int start_time, int lama_proses)
            {
                this.nama = nama;
                this.start_time = start_time;
                this.lama_proses = lama_proses;
            }
        }

        int maxWidth = 0;

        List<CGanttChart>[] CElemOperation;
        Font font;
        StringFormat sf;
        Pen p;

        int sumbuHorizontal = 0;
        int sumbuVertikal = 0;

        public FormGanttChart(int jml_mesin)
        {
            InitializeComponent();
            PanelGanttChart.Paint += new PaintEventHandler(PanelGanttChart_Paint);

            CElemOperation = new List<CGanttChart>[jml_mesin];
            for (int i = 0; i < CElemOperation.Length; i++)
            {
                CElemOperation[i] = new List<CGanttChart>();
            }

            //40 * jml_mesin, buat ukuran dalam mesin & jarak antar mesin
            //40, untuk tulisan 'mesin' di bagian kiri atas gantt chart
            //60, buat jarak garis horizontal & tulisan angka
            //20 * 2, untuk border atas-bawah
            sumbuVertikal = (60 * jml_mesin) + (20 * 2);
            PanelGanttChart.Size = new Size(PanelGanttChart.Size.Width, (60 * jml_mesin) + 40 + 100 + (20 * 2));

            //buat set tipe font
            font = new Font("times new roman", 8);

            //buat set alignment string jadi align center
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //buat scroll horizontal
            maxWidth = 0;

            //set pen buat border kotak
            p = new Pen(Brushes.Black, 2);
        }

        void PanelGanttChart_Paint(object sender, PaintEventArgs e)
        {
            //1 satuan waktu 25 pixel
            //1 mesin 20 pixel
            //jarak antar mesin 20 pixel

            //gambar sumbu x dan y, sumbu x waktu, sumbu y mesin
            e.Graphics.DrawLine(p, 60, 20, 60, sumbuVertikal);
            e.Graphics.DrawLine(p, 60, sumbuVertikal, sumbuHorizontal, sumbuVertikal);

            //buat nulis mesin
            int noMesin = 60;
            for (int i = 1; i <= CElemOperation.Length; i++)
            {
                e.Graphics.DrawString(i.ToString(), font, Brushes.Black, 15, noMesin, sf);
                noMesin += 60;
            }

            //buat naruh tulisan 'mesin'
            e.Graphics.DrawString("Mesin", font, Brushes.Black, 10, 20);

            //buat buat garis yang nunjuking satuan waktu
            int satuanWaktu = 60;   //diset 60, karena mulai di titik x awal di koord 60
            for (int i = 0; i <= maxWidth; i++)
            {
                e.Graphics.DrawLine(p, satuanWaktu, sumbuVertikal, satuanWaktu, sumbuVertikal + 10);
                e.Graphics.DrawString(i.ToString(), font, Brushes.Black, satuanWaktu, sumbuVertikal + 20, sf);
                //satuan waktu di + 25, karena 1 satuan waktu 25pixel, buat maju ke depan
                satuanWaktu += 25;
            }

            //buat nulis 'waktu'
            e.Graphics.DrawString("Waktu", font, Brushes.Black, sumbuHorizontal, sumbuVertikal + 10, sf);

            //mulai membuat kotak per operasi mesin
            for (int i = 0; i < CElemOperation.Length; i++)
            {
                for (int j = 0; j < CElemOperation[i].Count; j++)
                {
                    //urutannya fill rectangle, draw rectangle (buat border), draw string
                    //(start time * 25) + 60 buat x awal
                    //(i* 40) + 60
                    e.Graphics.FillRectangle(Brushes.White, (CElemOperation[i][j].start_time * 25) + 60, (i * 60) + 50, (CElemOperation[i][j].lama_proses * 25), 25);
                    e.Graphics.DrawRectangle(p, (CElemOperation[i][j].start_time * 25) + 60, (i * 60) + 50, (CElemOperation[i][j].lama_proses * 25), 25);
                    e.Graphics.DrawString(CElemOperation[i][j].nama, font, Brushes.Black, new RectangleF((CElemOperation[i][j].start_time * 25) + 60, (i * 60) + 50, (CElemOperation[i][j].lama_proses * 25), 25), sf);
                }
            }
        }

        public void addProcess(string nama, int start_time, int lama_proses, int no_mesin)
        {
            CElemOperation[no_mesin].Add(new CGanttChart(nama, start_time, lama_proses));
            //width panel diisi maxWidth * 25, karena 1 satuan waktu = 25pixel
            //space buat tulisan mesin di kiri, 40 pixel
            //garis vertikal untuk sumbu no mesin, 10 pixel
            //space buat tulisan 'waktu' di kanan, harus liat ukuran dulu, kira2, tambah 40 pixel
            //beri border biar ga nempel ke panel, 20 pixel
            if (start_time + lama_proses > maxWidth)
            {
                maxWidth = start_time + lama_proses;
                sumbuHorizontal = (25 * maxWidth) + 30 + 10 + 30 + 20;
                PanelGanttChart.Size = new Size((25 * maxWidth) + 30 + 10 + 30 + (20 * 2), PanelGanttChart.Size.Height);
                //MessageBox.Show("maxWidth : " + sumbuHorizontal);
            }
        }
    }
}