using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tel.DataAccessLayer.HataBlogu;
using Tel.Entities;

namespace Tel.DataAccessLayer
{
    public class DAL
    {
        TryCatchFinally TCF = new TryCatchFinally();

        SqlConnection Con;
        SqlCommand Cmd;
        SqlDataReader Reader;
        int ReturnValues;

        public DAL()
        {
            Con = new SqlConnection(@"data source=LENOVO\SQLEXPRESS;initial catalog=TelefonRehberi1;user id=sa;password=123;");
        }

        public void BaglantiAyarla()
        {
            if (Con.State == System.Data.ConnectionState.Closed)
            {
                Con.Open();
            }
            else
            {
                Con.Close();
            }
        }

        public int GirisYap(Kullanici K)
        {
            TCF.HataBlogum(() =>
            {
                Cmd = new SqlCommand("Select Count(*) From Kullanici Where KullaniciAdi=@KullaniciAdi And Sifre=@Sifre", Con);
                Cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = K.KullaniciAdi;
                Cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = K.Sifre;
                BaglantiAyarla();
                ReturnValues = (int)Cmd.ExecuteScalar();
            });
            return ReturnValues;
        }

        public int KayitOl(Kullanici K)
        {
            TCF.HataBlogum(() =>
            {
                Cmd = new SqlCommand("insert into Kullanici (ID,KullaniciAdi,Sifre) values (@ID,@KullaniciAdi,@Sifre)", Con);
                Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = K.ID;
                Cmd.Parameters.Add("@KullaniciAdi", SqlDbType.NVarChar).Value = K.KullaniciAdi;
                Cmd.Parameters.Add("@Sifre", SqlDbType.NVarChar).Value = K.Sifre;
                BaglantiAyarla();
                ReturnValues = Cmd.ExecuteNonQuery();
            });
            return ReturnValues;
        }

        public int KayitEkle(Rehber R)
        {
            TCF.HataBlogum(() =>
            {
                Cmd = new SqlCommand("insert into Rehber (ID,Isim,Soyisim,GozukecekIsim,TelefonNumarasi,EMailAdres,Adres,Aciklama) Values (@ID,@Isim,@Soyisim,@GozukecekIsim,@TelefonNumarasi,@EMailAdres,@Adres,@Aciklama)", Con);
                Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                Cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = R.Isim;
                Cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = R.Soyisim;
                Cmd.Parameters.Add("@GozukecekIsim", SqlDbType.NVarChar).Value = R.GozukecekIsim;
                Cmd.Parameters.Add("@TelefonNumarasi", SqlDbType.NVarChar).Value = R.TelefonNumarasi;
                Cmd.Parameters.Add("@EMailAdres", SqlDbType.NVarChar).Value = R.EMailAdres;
                Cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = R.Adres;
                Cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                ReturnValues = Cmd.ExecuteNonQuery();
            });
            return ReturnValues;
        }

        public int KayitDuzenle(Rehber R)
        {
            TCF.HataBlogum(() =>
            {
                Cmd = new SqlCommand("Update Rehber Set Isim=@Isim,Soyisim=@Soyisim,GozukecekIsim=@GozukecekIsim,TelefonNumarasi=@TelefonNumarasi,EMailAdres=@EMailAdres,Adres=@Adres,Aciklama=@Aciklama where ID=@ID", Con);
                Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = R.ID;
                Cmd.Parameters.Add("@Isim", SqlDbType.NVarChar).Value = R.Isim;
                Cmd.Parameters.Add("@Soyisim", SqlDbType.NVarChar).Value = R.Soyisim;
                Cmd.Parameters.Add("@GozukecekIsim", SqlDbType.NVarChar).Value = R.GozukecekIsim;
                Cmd.Parameters.Add("@TelefonNumarasi", SqlDbType.NVarChar).Value = R.TelefonNumarasi;
                Cmd.Parameters.Add("@EMailAdres", SqlDbType.NVarChar).Value = R.EMailAdres;
                Cmd.Parameters.Add("@Adres", SqlDbType.NVarChar).Value = R.Adres;
                Cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = R.Aciklama;
                BaglantiAyarla();
                ReturnValues = Cmd.ExecuteNonQuery();
            });
            return ReturnValues;
        }

        public int KayitSil(Guid ID)
        {
            TCF.HataBlogum(() =>
            {
                Cmd = new SqlCommand("Delete Rehber Where ID=@ID", Con);
                Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
                BaglantiAyarla();
                ReturnValues = Cmd.ExecuteNonQuery();
            });
            return ReturnValues;
        }

        public SqlDataReader KayitListele()
        {
            Cmd = new SqlCommand("Select * From Rehber", Con);
            BaglantiAyarla();
            return Cmd.ExecuteReader();
        }

        public SqlDataReader KayitListeleID(Guid ID)
        {
            Cmd = new SqlCommand("Select * From Rehber Where ID=@ID", Con);
            Cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID;
            BaglantiAyarla();
            return Cmd.ExecuteReader();
        }

    }
}
