using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;


namespace DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class EvolDataAccess
    {
        public EvolPOCEntities objEvolPOCEntities;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EvolDataAccess()
        {
            
        }

        /// <summary>
        /// Get all contacts
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetAllContact()
        {
            List<Contact> lstContact;

            using (objEvolPOCEntities = new EvolPOCEntities())
            {
                try
                {
                    if (objEvolPOCEntities.Contacts.Count() > 0)
                    {
                        lstContact = objEvolPOCEntities.Contacts.ToList();
                    }
                    else
                    {
                        lstContact = null;
                    }
                }
                catch (SqlException exc)
                {
                    log.Error(exc);
                    throw;
                }
            }

            return lstContact;

        }

        /// <summary>
        /// Addd new contact to database
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public bool AddContact(Contact contact)
        {
            using (objEvolPOCEntities = new EvolPOCEntities())
            {
                try
                {
                    objEvolPOCEntities.Contacts.Add(contact);
                    int count  = objEvolPOCEntities.SaveChanges();
                    if (count > 0)
                        return true;
                    else
                        return false;
                }
                catch (SqlException exc)
                {
                    log.Error(exc);
                    throw;
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public Contact GetContactById(int contactId)
        {
            Contact objContact;
            using (objEvolPOCEntities = new EvolPOCEntities())
            {
                try
                {
                    objContact = objEvolPOCEntities.Contacts.Where(a=>a.ContactId == contactId).SingleOrDefault();
                }
                catch (SqlException exc)
                {
                    log.Error(exc);
                    throw;
                }
            }

            return objContact;
        }

        public bool UpdateContact(Contact objContact)
        {
            using (objEvolPOCEntities = new EvolPOCEntities())
            {
                try
                {
                    var entity = objEvolPOCEntities.Contacts.Find(objContact.ContactId);
                    if (entity == null)
                    {
                        return false;
                    }

                    objEvolPOCEntities.Entry(entity).CurrentValues.SetValues(objContact);
                    int count = objEvolPOCEntities.SaveChanges();
                    if (count > 0)
                        return true;
                    else
                        return false;
                }
                catch (SqlException exc)
                {
                    log.Error(exc);
                    throw;
                }
            }
        }

        public bool DeleteContact(int Id)
        {
            using (objEvolPOCEntities = new EvolPOCEntities())
            {
                try
                {
                    var entity = objEvolPOCEntities.Contacts.Find(Id);
                    if (entity == null)
                    {
                        return false;
                    }

                    objEvolPOCEntities.Entry(entity).State = EntityState.Deleted;
                    int count = objEvolPOCEntities.SaveChanges();
                    if (count > 0)
                        return true;
                    else
                        return false;
                }
                catch (SqlException exc)
                {
                    log.Error(exc);
                    throw;
                }
            }
        }

      }
}
