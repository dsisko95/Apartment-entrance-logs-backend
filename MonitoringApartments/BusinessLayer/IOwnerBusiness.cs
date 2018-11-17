using DataLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IOwnerBusiness
    {
        List<Owner> GetAllOwners();

        bool InsertOwner(Owner o);

        bool UpdateOwner(Owner o);

        Owner GetOwnerLogin(string username, string password);

        Owner CheckDuplicateUsername(string username);

        bool DeleteOwner(int id);

        bool UpdateOwnerPassword(Owner o);

        List<Owner> GetAllOwnersByRoleOwner();

        List<Owner> GetCheckUsernameBySecQuestion(string username, string secQuestion1, string secQuestion2);

        bool UpdateOwnerPasswordByUsername(Owner o);
    }
}