using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();

        int InsertOwner(Owner o);

        int UpdateOwner(Owner o);

        Owner GetOwnerLogin(string username, string password);

        Owner CheckDuplicateUsername(string username);

        int DeleteOwner(int id);

        int UpdateOwnerPassword(Owner o);

        List<Owner> GetAllOwnersByRoleOwner();

        List<Owner> GetCheckUsernameBySecQuestion(string username, string secQuestion1, string secQuestion2);

        int UpdateOwnerPasswordByUsername(Owner o);
    }
}