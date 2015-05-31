using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
  public  class Phone
    {
        public int Id { get; set; }
        public int ParentContactId { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return this.PhoneNumber;
        }
    }
}
