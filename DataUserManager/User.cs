using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUserManager
{
    class User
    {
        public string ID;
        public string Name;
        public string Status;
        public Coordinate BaseLocaltion;

        public User(string iD, string name, string status, Coordinate baseLocaltion)
        {
            ID = iD;
            Name = name;
            Status = status;
            BaseLocaltion = baseLocaltion;
        }

        public User()
        {
        }
        ~User()
        {
        }
    }
}
