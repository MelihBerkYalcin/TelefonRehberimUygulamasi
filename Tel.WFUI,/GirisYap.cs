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
    public partial class GirisYap : Form
    {
        public GirisYap()
        {
            InitializeComponent();
        }

        private void btn_girisyap_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int ReturnValues = BLL.GirisYap(txt_kullaniciadi.Text, txt_sifre.Text);

            if (ReturnValues > 0)
            {
                AnaSayfa AS = new AnaSayfa();
                Hide();
                AS.Show();
            }
            else
            {

            }
        }

        private void btn_cikisyap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void link_kayitol_MouseClick(object sender, MouseEventArgs e)
        {
            KayitOl kayitOl = new KayitOl();
            Hide();
            kayitOl.Show();
        }
    }
}
