using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ClientBusiness : IClientBusiness
    {
        private IClientRepository clientRepository;

        public ClientBusiness(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public List<Client> GetAllClients()
        {
            List<Client> clients = this.clientRepository.GetAllClients();
            if (clients.Count > 0)
            {
                return clients;
            }
            else
            {
                return null;
            }
        }

        public bool InsertClient(Client c)
        {
            if (this.clientRepository.InsertClient(c) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateClient(Client c)
        {
            bool result = false;
            if (c.Identification_number != null && this.clientRepository.UpdateClient(c) > 0)
            {
                result = true;
            }
            return result;
        }

        public List<Client> GetClientByJMBG(string jmbg)
        {
            List<Client> clients = this.clientRepository.GetClientByJMBG(jmbg);
            if (clients.Count > 0)
            {
                return clients;
            }
            else
            {
                return null;
            }
        }
    }
}