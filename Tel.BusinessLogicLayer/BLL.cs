using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tel.Entities;

namespace Tel.BusinessLogicLayer
{
    public class BLL
    {
        DataAccessLayer.DAL dal;

        public BLL()
        {
            dal = new DataAccessLayer.DAL();
        }

        public int GirisYap(string _KullaniciAdi, string _Sifre)
        {
            if (_KullaniciAdi != string.Empty && _Sifre != string.Empty)
            {
                return dal.GirisYap(new Entities.Kullanici()
                {
                    KullaniciAdi = _KullaniciAdi,
                    Sifre = _Sifre,
                });
            }
            else
            {
                return -1;
            }
        }

        public int KayitOl(string _KullaniciAdi, string _Sifre)
        {
            if (_KullaniciAdi != string.Empty && _KullaniciAdi.Length > 4 && _Sifre != string.Empty && _Sifre.Length > 6)
            {
                return dal.KayitOl(new Entities.Kullanici()
                {
                    ID = Guid.NewGuid(),
                    KullaniciAdi = _KullaniciAdi,
                    Sifre = _Sifre,
                });
            }
            else
            {
                return -1;
            }
        }

        public int KayitEkle(string _Isim, string _Soyisim, string _GozukecekIsim, string _TelefonNumarasi, string _EMailAdres, string _Adres, string _Aciklama)
        {
            if (_Isim != string.Empty && _Soyisim != string.Empty && _GozukecekIsim != string.Empty && _TelefonNumarasi != string.Empty)
            {
                return dal.KayitEkle(new Entities.Rehber()
                {
                    ID = Guid.NewGuid(),
                    Isim = _Isim,
                    Soyisim = _Soyisim,
                    GozukecekIsim = _GozukecekIsim,
                    TelefonNumarasi = _TelefonNumarasi,
                    EMailAdres = _EMailAdres,
                    Adres = _Adres,
                    Aciklama = _Aciklama,
                });
            }
            else
            {
                return -1;
            }
        }

        public int KayitDuzenle(Guid _ID, string _Isim, string _Soyisim, string _GozukecekIsim, string _TelefonNumarasi, string _EMailAdres, string _Adres, string _Aciklama)
        {
            if (_ID != Guid.Empty)
            {
                return dal.KayitDuzenle(new Entities.Rehber()
                {
                    ID = _ID,
                    Isim = _Isim,
                    Soyisim = _Soyisim,
                    GozukecekIsim = _GozukecekIsim,
                    TelefonNumarasi = _TelefonNumarasi,
                    EMailAdres = _EMailAdres,
                    Adres = _Adres,
                    Aciklama = _Aciklama,
                });
            }
            else
            {
                return -1;
            }
        }

        public int KayitSil(Guid _ID)
        {
            if (_ID != Guid.Empty)
            {
                return dal.KayitSil(_ID);
            }
            else
            {
                return -1;
            }
        }

        public List<Rehber> KayitListele()
        {
            List<Rehber> Rehberim = new List<Rehber>();

            try
            {
                SqlDataReader Reader = dal.KayitListele();

                while (Reader.Read())
                {
                    Rehberim.Add(new Rehber()
                    {
                        ID = Reader.IsDBNull(0) ? Guid.Empty : Reader.GetGuid(0),
                        Isim = Reader.IsDBNull(1) ? string.Empty : Reader.GetString(1),
                        Soyisim = Reader.IsDBNull(2) ? string.Empty : Reader.GetString(2),
                        GozukecekIsim = Reader.IsDBNull(3) ? string.Empty : Reader.GetString(3),
                        TelefonNumarasi = Reader.IsDBNull(4) ? string.Empty : Reader.GetString(4),
                        EMailAdres = Reader.IsDBNull(5) ? string.Empty : Reader.GetString(5),
                        Adres = Reader.IsDBNull(6) ? string.Empty : Reader.GetString(6),
                        Aciklama = Reader.IsDBNull(7) ? string.Empty : Reader.GetString(7),
                    });
                }
                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dal.BaglantiAyarla();
            }
            return Rehberim;
        }

        public Rehber KayitListeleID(Guid _ID)
        {
            Rehber Rehberim = new Rehber();

            try
            {
                SqlDataReader Reader = dal.KayitListeleID(_ID);

                while (Reader.Read())
                {
                    Rehberim = new Rehber()
                    {
                        ID = Reader.IsDBNull(0) ? Guid.Empty : Reader.GetGuid(0),
                        Isim = Reader.IsDBNull(1) ? string.Empty : Reader.GetString(1),
                        Soyisim = Reader.IsDBNull(2) ? string.Empty : Reader.GetString(2),
                        GozukecekIsim = Reader.IsDBNull(3) ? string.Empty : Reader.GetString(3),
                        TelefonNumarasi = Reader.IsDBNull(4) ? string.Empty : Reader.GetString(4),
                        EMailAdres = Reader.IsDBNull(5) ? string.Empty : Reader.GetString(5),
                        Adres = Reader.IsDBNull(6) ? string.Empty : Reader.GetString(6),
                        Aciklama = Reader.IsDBNull(7) ? string.Empty : Reader.GetString(7),
                    };
                }
                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dal.BaglantiAyarla();
            }
            return Rehberim;
        }

    }
}
