using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_blend__UWP_.Clases
{
    internal class Usuario
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String email { get; set; }
        public DateTime bornDate { get; set; }

        public Usuario(string username, string password, DateTime bornDate)
        {
            this.Username = username;
            this.Password = password;
            this.bornDate = bornDate;
        }
    }
}
