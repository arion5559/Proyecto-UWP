using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Proyecto_blend__UWP_.Clases;

namespace Proyecto_blend__UWP_.Clases
{
    internal class Usuarios
    {
        public List < Usuario > Users { get; set; } = new List<Usuario>()
        {
            new Usuario(username: "Admin", password: "1234", bornDate: DateTime.Now)
        };
        
        public void AddUser(Usuario user)
        {
            Users.Add(user);
        }

        public int LookForUser(String username)
        {
            bool encontrado = false;
            int contador = 0;
            do
            {
                if (Users[contador].Username == username)
                {
                    encontrado = true;
                }
                contador++;
            } while (contador < Users.Count && encontrado == false);
            if (encontrado)
            {
                return contador;
            } else {
                return -1;
            }
        }

        public bool matchesPassword(String password, int user)
        {
            return Users[user].Password == password;
        }
    }
}
