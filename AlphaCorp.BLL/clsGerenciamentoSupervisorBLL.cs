using AlphaCorp.DAO;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsGerenciamentoSupervisorBLL
    {
        public bool Insert(clsGerenciamentoSupervisorBLO _gerenciamento)
        {
            try
            {
                clsGerenciamentoSupervisorDAO gerenciamentoDAO = new clsGerenciamentoSupervisorDAO();
                return gerenciamentoDAO.Insert(_gerenciamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(clsGerenciamentoSupervisorBLO _gerenciamento)
        {
            try
            {
                clsGerenciamentoSupervisorDAO gerenciamentoDAO = new clsGerenciamentoSupervisorDAO();
                return gerenciamentoDAO.Update(_gerenciamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(clsGerenciamentoSupervisorBLO _gerenciamento)
        {
            try
            {
                clsGerenciamentoSupervisorDAO gerenciamentoDAO = new clsGerenciamentoSupervisorDAO();
                return gerenciamentoDAO.Delete(_gerenciamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<clsGerenciamentoSupervisorBLO> Find(clsGerenciamentoSupervisorBLO _gerenciamento)
        {
            try
            {
                clsGerenciamentoSupervisorDAO gerenciamentoDAO = new clsGerenciamentoSupervisorDAO();
                return gerenciamentoDAO.Find(_gerenciamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
