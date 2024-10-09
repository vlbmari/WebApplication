using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
namespace WebApplicationTeste2
{
    public class Usuario
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public Usuario(string name, string lastname, string mail, string password)
        {
            Name = name;
            Lastname = lastname;
            Mail = mail;
            Password = password;
        }
    }
}