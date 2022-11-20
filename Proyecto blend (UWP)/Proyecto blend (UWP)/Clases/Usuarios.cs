using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Proyecto_blend__UWP_.Clases;

namespace Proyecto_blend__UWP_.Clases
{
    class Usuarios
    {
        public static List <Usuario> Users { get; set; } = new List<Usuario>()
        {
            new Usuario(username: "admin", password: "1234", bornDate: DateTime.Now, email: "ejemplo@nada.com", session: false, photo: "..\\img\\img_206976.png")
        };
        
        public static void AddUser(Usuario user)
        {
            Users.Add(user);
        }

        public static int LookForUser(String username)
        {
            bool encontrado = false;
            int contador = 0;
            do
            {
                if (Users[contador].username == username || Users[contador].email == username)
                {
                    encontrado = true;
                }
                else
                {
                    contador++;
                }
            } while (contador < Users.Count && encontrado == false);
            if (encontrado)
            {
                return contador;
            } else {
                return -1;
            }
        }

        public static bool matchesPassword(String password, int user)
        {
            System.Diagnostics.Debug.WriteLine(password);
            if (Users[user].password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}