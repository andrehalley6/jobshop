using System;
using System.Collections.Generic;
using System.Text;

namespace JobShop
{
    public class CCandidate
    {
        private int job1;
        private int job2;
        private int mesin;
        private bool isTabu;

        public CCandidate(int job1, int job2, int mesin, bool isTabu)
        {
            this.job1 = job1;
            this.job2 = job2;
            this.mesin = mesin;
            this.isTabu = isTabu;
        }

        public int Job1
        {
            get { return this.job1; }
            set { this.job1 = value; }
        }

        public int Job2
        {
            get { return this.job2; }
            set { this.job2 = value; }
        }

        public int Mesin
        {
            get { return this.mesin; }
            set { this.mesin = value; }
        }

        public bool IsTabu
        {
            get { return this.isTabu; }
            set { this.isTabu = value; }
        }
    }
}
