using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess.Repository
{
   public class RepositoryFactory//? по-добра изолация на кода от презентационната част 
    {

         public static UsersRepository GetUserRepository()
        {
            string path = ConfigurationManager.AppSettings["dataPath"];
            return new UsersRepository(path + @"\users.txt");

        }
         public static ContactsRepository GetContactsRepository()
         {
             string path = ConfigurationManager.AppSettings["dataPath"];
             return new ContactsRepository(path + @"\contacts.txt");

         }
         public static PhonesRepository GetPhonesRepository()
         {
             string path = ConfigurationManager.AppSettings["dataPath"];
             return new PhonesRepository(path + @"\phones.txt");

         }

        
    }
}