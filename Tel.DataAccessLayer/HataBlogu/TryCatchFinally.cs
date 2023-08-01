using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tel.DataAccessLayer.HataBlogu
{
    public class TryCatchFinally
    {
        public void HataBlogum(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DAL dal = new DAL();
                dal.BaglantiAyarla();
            }
        }
    }
}
