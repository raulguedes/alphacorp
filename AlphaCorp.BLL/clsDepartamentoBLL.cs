using AlphaCorp.DAO;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsDepartamentoBLL
    {
        public bool Insert(clsDepartamentoBLO _departamento)
        {
            try
            {
                clsDepartamentoDAO departamentoDAO = new clsDepartamentoDAO();
                return departamentoDAO.Insert(_departamento);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Update(clsDepartamentoBLO _departamento)
        {
            try
            {
                clsDepartamentoDAO departamentoDAO = new clsDepartamentoDAO();
                return departamentoDAO.Update(_departamento);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Delete(clsDepartamentoBLO _departamento)
        {
            try
            {
                clsDepartamentoDAO departamentoDAO = new clsDepartamentoDAO();
                return departamentoDAO.Delete(_departamento);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsDepartamentoBLO> Find(clsDepartamentoBLO _departamento)
        {
            try
            {
                clsDepartamentoDAO departamentoDAO = new clsDepartamentoDAO();
                return departamentoDAO.Find(_departamento);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsDepartamentoBLO> FindAll()
        {
            try
            {
                clsDepartamentoDAO departamentoDAO = new clsDepartamentoDAO();
                return departamentoDAO.FindAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
