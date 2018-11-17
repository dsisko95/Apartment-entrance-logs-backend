using DataLayer;
using DataLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ApartmentBusiness : IApartmentBusiness
    {
        private IApartmentRepository apartmentRepository;

        public ApartmentBusiness(IApartmentRepository apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
        }

        public List<Apartment> GetAllApartments()
        {
            List<Apartment> apartments = this.apartmentRepository.GetAllApartments();
            if (apartments.Count > 0)
            {
                return apartments;
            }
            else
            {
                return null;
            }
        }

        public bool InsertApartment(Apartment a)
        {
            if (this.apartmentRepository.InsertApartment(a) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateApartment(Apartment a)
        {
            bool result = false;
            if (a.Id != 0 && this.apartmentRepository.UpdateApartment(a) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}