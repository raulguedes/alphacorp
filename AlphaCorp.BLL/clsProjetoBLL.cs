using AlphaCorp.BLO;
using AlphaCorp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsProjetoBLL
    {
        public bool Insert(clsProjetoBLO _Projeto)
        {
            try
            {
                clsProjetoDAO ProjetoDAO = new clsProjetoDAO();
                return ProjetoDAO.Insert(_Projeto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Update(clsProjetoBLO _Projeto)
        {
            try
            {
                clsProjetoDAO ProjetoDAO = new clsProjetoDAO();
                return ProjetoDAO.Update(_Projeto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Delete(clsProjetoBLO _Projeto)
        {
            try
            {
                clsProjetoDAO ProjetoDAO = new clsProjetoDAO();
                return ProjetoDAO.Delete(_Projeto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsProjetoBLO> Find(clsProjetoBLO _Projeto)
        {
            try
            {
                clsProjetoDAO ProjetoDAO = new clsProjetoDAO();
                return ProjetoDAO.Find(_Projeto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
