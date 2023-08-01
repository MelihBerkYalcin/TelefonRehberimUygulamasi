using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tel.WFUI_
{
    public partial class KayitOl : Form
    {
        public KayitOl()
        {
            InitializeComponent();
        }

        private void btn_cikisyap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_kayitol_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            int ReturnValues = bll.KayitOl(txt_kayitol_kullaniciadi.Text, txt_kayitol_sifre.Text);

            if (ReturnValues > 0)
            {
                GirisYap GY = new GirisYap();
                Hide();
                GY.Show();
            }
        }

        private void link_girisyap_MouseClick(object sender, MouseEventArgs e)
        {
            GirisYap GY = new GirisYap();
            Hide();
            GY.Show();
        }
    }
}
