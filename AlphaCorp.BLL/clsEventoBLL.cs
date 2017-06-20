using AlphaCorp.DAO;
using AlphaCorp.BLO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaCorp.BLL
{
    public class clsEventoBLL
    {
        public bool Insert(clsEventoBLO _Evento)
        {
            try
            {
                clsEventoDAO eventoDAO = new clsEventoDAO();
                return eventoDAO.Insert(_Evento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(clsEventoBLO _Evento)
        {
            try
            {
                clsEventoDAO eventoDAO = new clsEventoDAO();
                return eventoDAO.Update(_Evento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(clsEventoBLO _Evento)
        {
            try
            {
                clsEventoDAO eventoDAO = new clsEventoDAO();
                return eventoDAO.Delete(_Evento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<clsEventoBLO> Find(clsEventoBLO _Evento)
        {
            try
            {
                clsEventoDAO eventoDAO = new clsEventoDAO();
                return eventoDAO.Find(_Evento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<clsEventoBLO> FindEvento(clsEventoBLO _Evento)
        {
            try
            {
                clsEventoDAO eventoDAO = new clsEventoDAO();
                return eventoDAO.FindEvento(_Evento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<clsEventoBLO> FindAll()
        {
            try
            {
                clsEventoDAO eventoDAO = new clsEventoDAO();
                return eventoDAO.FindAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
