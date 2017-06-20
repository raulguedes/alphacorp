using AlphaCorp.BLO;
using AlphaCorp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsTimesheetBLL
    {
        public bool Insert(clsTimesheetBLO _timesheet)
        {
            try
            {
                clsTimesheetDAO objDAO = new clsTimesheetDAO();
                return objDAO.Insert(_timesheet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }        
        public bool Delete(clsTimesheetBLO _timesheet)
        {
            try
            {
                clsTimesheetDAO objDAO = new clsTimesheetDAO();
                return objDAO.Delete(_timesheet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Transfere da tblWaitsheet para tblWait com o status em aguarde
        /// </summary>
        /// <param name="_waitsheet"></param>
        /// <returns></returns>
        public bool Transferir(clsTimePadraoBLO _timesheet)
        {
            try
            {
                clsTimesheetDAO objDAO = new clsTimesheetDAO();
                return objDAO.Transferir(_timesheet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<clsTimePadraoBLO> Find(clsTimePadraoBLO _timesheet)
        {
            try
            {
                clsTimesheetDAO _timeDAO = new clsTimesheetDAO();
                return _timeDAO.Find(_timesheet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
