using Mvc4PhoneCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc4PhoneCatalog.Data
{
    public class PhoneRepository
    {
        private PhoneDbContext _db = new PhoneDbContext();

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }

        }

        /// <summary>
        /// Lists all items in the database
        /// </summary>
        /// <returns>List<Phone></Phone></returns>
        public List<Phone> ListPhone()
        {
            try
            {
                return _db.Phone.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Search entity by its ModelName field.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Phone> ListPhoneSearch(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return new List<Phone>();
                }

                return _db.Phone.Where(
                    r => r.ModelName.Contains(searchTerm)
                    ).ToList();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Search entity by its ID field.
        /// </summary>
        /// <param name="phoneId"></param>
        /// <returns></returns>
        public Phone PhoneSearch(int phoneId)
        {

            try
            {
                return _db.Phone.FirstOrDefault(
                    r => r.ID == phoneId
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert a new entity in the database.
        /// </summary>
        /// <param name="phone"></param>
        public void CreatePhone(Phone phone)
        {

            try
            {
                _db.Phone.Add(phone);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Modifies an existing entity.
        /// </summary>
        /// <param name="phone"></param>
        public void EditPhone(Phone phone)
        {

            try
            {
                Phone original = _db.Phone.Find(phone.ID);

                if (original == null)
                {
                    throw new Exception();
                }
                
                original.LaunchYear = phone.LaunchYear;
                original.ModelCode = phone.ModelCode;
                original.ModelName = phone.ModelName;
                original.OperatingSystem = phone.OperatingSystem;
                original.Price = phone.Price;

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="id"></param>
        public void DeletePhone(int id)
        {
            try
            {
                Phone phone = _db.Phone.Find(id);

                if (phone == null)
                {
                    throw new Exception();
                }

                _db.Phone.Remove(phone);

                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
