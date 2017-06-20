using AlphaCorp.DAO;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsClienteBLL
    {
        public bool Insert(clsClienteBLO _cliente)
        {
            try
            {
                clsClienteDAO clienteDAO = new clsClienteDAO();
                return clienteDAO.Insert(_cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Update(clsClienteBLO _cliente)
        {
            try
            {
                clsClienteDAO clienteDAO = new clsClienteDAO();
                return clienteDAO.Update(_cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Delete(clsClienteBLO _cliente)
        {
            try
            {
                clsClienteDAO clienteDAO = new clsClienteDAO();
                return clienteDAO.Delete(_cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsClienteBLO> Find(clsClienteBLO _cliente)
        {
            try
            {
                clsClienteDAO clienteDAO = new clsClienteDAO();
                return clienteDAO.Find(_cliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<clsClienteBLO> FindAll()
        {
            try
            {
                clsClienteDAO clienteDAO = new clsClienteDAO();
                return clienteDAO.FindAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
