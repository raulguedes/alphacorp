using AlphaCorp.BLO;
using AlphaCorp.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsEmpresaBLL
    {
        public bool Insert(clsEmpresaBLO _empresa)
        {
            try
            {
                clsEmpresaDAO empresa = new clsEmpresaDAO();
                return empresa.Insert(_empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(clsEmpresaBLO _empresa)
        {
            try
            {
                clsEmpresaDAO empresa = new clsEmpresaDAO();
                return empresa.Update(_empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<clsEmpresaBLO> Find(clsEmpresaBLO _empresa)
        {
            try
            {
                clsEmpresaDAO empresa = new clsEmpresaDAO();
                return empresa.Find(_empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsEmpresaBLO> FindAll()
        {
            try
            {

                clsEmpresaDAO empresa = new clsEmpresaDAO();
                return empresa.FindAll();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
