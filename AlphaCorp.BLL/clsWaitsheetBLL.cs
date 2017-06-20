using AlphaCorp.BLO;
using AlphaCorp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsWaitsheetBLL
    {
        public bool Insert(clsWaitsheetBLO _waitsheet)
        {
            try
            {
                clsWaitsheetDAO objDAO = new clsWaitsheetDAO();
                return objDAO.Insert(_waitsheet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Delete(clsWaitsheetBLO _waitsheet)
        {
            try
            {
                clsWaitsheetDAO objDAO = new clsWaitsheetDAO();
                return objDAO.Delete(_waitsheet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Transfere da tblWaitsheet para tblTimesheet e tblHoraExtra
        /// </summary>
        /// <param name="_waitsheet"></param>
        /// <returns></returns>
        public bool Transferir(clsWaitsheetBLO _waitsheet)
        {
            try
            {
                clsWaitsheetDAO objDAO = new clsWaitsheetDAO();
                return objDAO.Transferir(_waitsheet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<clsWaitsheetBLO> Find(clsWaitsheetBLO _waitsheet)
        {
            try
            {
                clsWaitsheetDAO _waitDAO = new clsWaitsheetDAO();                
                return _waitDAO.Find(_waitsheet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsTimePadraoBLO> Find(clsTimePadraoBLO _waitsheet)
        {
            try
            {
                clsWaitsheetDAO _waitDAO = new clsWaitsheetDAO();
                return _waitDAO.Find(_waitsheet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
