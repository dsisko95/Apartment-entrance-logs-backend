using DataLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IClientBusiness
    {
        List<Client> GetAllClients();

        bool InsertClient(Client c);

        bool UpdateClient(Client c);

        List<Client> GetClientByJMBG(string jmbg);
    }
}