using AlphaCorp.DAO;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsMembroEventoBLL
    {
        public bool Insert(clsMembroEventoBLO _membroEvento)
        {
            try
            {
                clsMembroEventoDAO membroEventoDAO = new clsMembroEventoDAO();
                return membroEventoDAO.Insert(_membroEvento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(clsMembroEventoBLO _membroEvento)
        {
            try
            {
                clsMembroEventoDAO membroEventoDAO = new clsMembroEventoDAO();
                return membroEventoDAO.Update(_membroEvento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(clsMembroEventoBLO _membroEvento)
        {
            try
            {
                clsMembroEventoDAO membroEventoDAO = new clsMembroEventoDAO();
                return membroEventoDAO.Delete(_membroEvento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<clsMembroEventoBLO> Find(clsMembroEventoBLO _membroEvento)
        {
            try
            {
                clsMembroEventoDAO membroEventoDAO = new clsMembroEventoDAO();
                return membroEventoDAO.Find(_membroEvento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
