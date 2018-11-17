using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class OwnerBusiness : IOwnerBusiness
    {
        private IOwnerRepository ownerRepository;

        public OwnerBusiness(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        //

        public List<Owner> GetAllOwners()
        {
            List<Owner> owners = this.ownerRepository.GetAllOwners();
            if (owners.Count > 0)
            {
                return owners;
            }
            else
            {
                return null;
            }
        }

        public bool InsertOwner(Owner o)
        {
            if (this.ownerRepository.InsertOwner(o) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateOwner(Owner o)
        {
            bool result = false;
            if (o.Id != null && this.ownerRepository.UpdateOwner(o) > 0)
            {
                result = true;
            }
            return result;
        }

        public Owner GetOwnerLogin(string username, string password)
        {
            Owner owners = this.ownerRepository.GetOwnerLogin(username, password);
            if (owners != null)
            {
                return owners;
            }
            else
            {
                return null;
            }
        }

        public Owner CheckDuplicateUsername(string username)
        {
            Owner owners = this.ownerRepository.CheckDuplicateUsername(username);
            if (owners != null)
            {
                return owners;
            }
            else
            {
                return null;
            }
        }

        public bool DeleteOwner(int id)
        {
            bool result = false;
            if (id != 0 && this.ownerRepository.DeleteOwner(id) > 0)
            {
                result = true;
            }
            return result;
        }

        public bool UpdateOwnerPassword(Owner o)
        {
            bool result = false;
            if (o.Id != null && this.ownerRepository.UpdateOwnerPassword(o) > 0)
            {
                result = true;
            }
            return result;
        }

        public List<Owner> GetAllOwnersByRoleOwner()
        {
            List<Owner> owners = this.ownerRepository.GetAllOwnersByRoleOwner();
            if (owners.Count > 0)
            {
                return owners;
            }
            else
            {
                return null;
            }
        }

        public List<Owner> GetCheckUsernameBySecQuestion(string username, string secQuestion1, string secQuestion2)
        {
            List<Owner> owners = this.ownerRepository.GetCheckUsernameBySecQuestion(username, secQuestion1, secQuestion2);
            if (owners.Count > 0)
            {
                return owners;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateOwnerPasswordByUsername(Owner o)
        {
            bool result = false;
            if (o.Id != null && this.ownerRepository.UpdateOwnerPasswordByUsername(o) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}