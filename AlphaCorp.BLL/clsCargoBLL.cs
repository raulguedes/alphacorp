using AlphaCorp.BLO;
using AlphaCorp.DAO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsCargoBLL
    {
        public bool Insert(clsCargoBLO _cargo)
        {
            try
            {
                clsCargoDAO cargoDAO = new clsCargoDAO();
                return cargoDAO.Insert(_cargo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Update(clsCargoBLO _cargo)
        {
            try
            {
                clsCargoDAO cargoDAO = new clsCargoDAO();
                return cargoDAO.Update(_cargo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Delete(clsCargoBLO _cargo)
        {
            try
            {
                clsCargoDAO cargoDAO = new clsCargoDAO();
                return cargoDAO.Delete(_cargo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsCargoBLO> Find(clsCargoBLO _cargo)
        {
            try
            {
                clsCargoDAO cargoDAO = new clsCargoDAO();
                return cargoDAO.Find(_cargo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
