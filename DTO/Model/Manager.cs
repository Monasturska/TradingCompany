using System;
using System.Security.Cryptography;
using System.Text;

namespace DTO.Model
{
    public class Manager
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = "";
        //public byte[] Password { get; set; }
        //public Guid Salt { get; set; }
        public string Email { get; set; } = "";
        public DateTime TimeInsert { get; set; }
        public DateTime TimeUpdate { get; set; }

        public bool Equals(Manager obj)
        {
            return obj != null
                && obj.ID == this.ID
                && obj.Name == this.Name
                && obj.TimeUpdate == this.TimeUpdate
                && obj.TimeInsert == this.TimeInsert;
        }
       
        public Manager CopyElem()
        {
            Manager other = new Manager();
            other.Email = this.Email;
            other.ID = this.ID;
            other.Name = this.Name;
            
            other.TimeInsert = this.TimeInsert;
            other.TimeUpdate = this.TimeUpdate;
            return other;
        }
    }
}

