using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tel.Entities;

namespace Tel.WFUI_
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void btn_cikisyap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void KayitListele()
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            lst_liste.DataSource = bll.KayitListele();
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            KayitListele();
        }

        private void btn_kayitekle_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            int ReturnValues = bll.KayitEkle(txt_ekle_isim.Text, txt_ekle_soyisim.Text, txt_ekle_gozukecekisim.Text, txt_ekle_telefonnumarasi.Text, txt_ekle_emailadres.Text, txt_ekle_adres.Text, txt_ekle_aciklama.Text);

            if (ReturnValues > 0)
            {
                KayitListele();
            }
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            Guid ID = ((Rehber)lst_liste.SelectedItem).ID;

            int ReturnValues = bll.KayitDuzenle(ID, txt_ds_isim.Text, txt_ds_soyisim.Text, txt_ds_gozukecekisim.Text, txt_ds_telefonnumarasi.Text, txt_ds_emailadres.Text, txt_ds_adres.Text, txt_ds_aciklama.Text);

            if (ReturnValues > 0)
            {
                KayitListele();
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            Guid ID = ((Rehber)lst_liste.SelectedItem).ID;

            int ReturnValues = bll.KayitSil(ID);

            if (ReturnValues > 0)
            {
                KayitListele();
            }
        }

        private void lst_liste_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();

            ListBox ID = (ListBox)sender;
            Rehber Rehberim = (Rehber)lst_liste.SelectedItem;

            if (Rehberim != null)
            {
                txt_ds_isim.Text = Rehberim.Isim;
                txt_ds_soyisim.Text = Rehberim.Soyisim;
                txt_ds_gozukecekisim.Text = Rehberim.GozukecekIsim;
                txt_ds_telefonnumarasi.Text = Rehberim.TelefonNumarasi;
                txt_ds_emailadres.Text = Rehberim.EMailAdres;
                txt_ds_adres.Text = Rehberim.Adres;
                txt_ds_aciklama.Text = Rehberim.Aciklama;
            }
        }
    }
}
