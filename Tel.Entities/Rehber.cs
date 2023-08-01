using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tel.Entities
{
    public class Rehber
    {
        public Guid ID { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public string GozukecekIsim { get; set; }
        public string TelefonNumarasi { get; set; }
        public string EMailAdres { get; set; }
        public string Adres { get; set; }
        public string Aciklama { get; set; }

        public override string ToString()
        {
            return $"{GozukecekIsim}";
        }
    }
}
