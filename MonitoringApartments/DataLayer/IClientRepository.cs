using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IClientRepository
    {
        List<Client> GetAllClients();

        int InsertClient(Client c);

        int UpdateClient(Client c);

        List<Client> GetClientByJMBG(string jmbg);
    }
}