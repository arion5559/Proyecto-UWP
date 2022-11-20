using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_blend__UWP_.Clases
{
    internal class Usuario
    {
        public String username { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public DateTime bornDate { get; set; }
        public string photo { get; set; }
        public bool session { get; set; }

        public Usuario(string username, string password, DateTime bornDate, string email, bool session, string photo)
        {
            this.username = username;
            this.password = password;
            this.bornDate = bornDate;
            this.email = email;
            this.session = session;
            this.photo = photo;
        }
    }
}
