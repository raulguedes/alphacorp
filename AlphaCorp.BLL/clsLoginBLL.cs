using AlphaCorp.BLO;
using AlphaCorp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsLoginBLL
    {
        public List<clsLoginBLO> Find(clsLoginBLO _empresa)
        {
            try
            {
                clsLoginDAO empresa = new clsLoginDAO();
                return empresa.Find(_empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
