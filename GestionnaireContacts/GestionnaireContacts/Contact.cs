using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireContacts
{
    class Contact
    {
        Char delimiter = '\u0009';

        public String Nom { get; set; }
        public String Prenom { get; set; }
        public String Adresse { get; set; }
        public String Npa { get; set; }
        public String Localite { get; set; }
        public String Email { get; set; }

        public Contact() { }

        public Contact(string tab) {
            String[] substr = tab.Split(delimiter);
            Nom = substr[0];
            Prenom = substr[1];
            Adresse = substr[2];
            Npa = substr[3];
            Localite = substr[4];
            Email = substr[5];

        }

        public Contact(String nom, String prenom, String adresse, String npa, String localite, String email)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Npa = npa;
            Localite = localite;
            Email = email;
        }

        public String ToTabString
        {
            get{
                return Nom + delimiter + Prenom + delimiter + Adresse + delimiter + Npa + delimiter + Localite + delimiter + Email;
            }
        }

        public void FromTabString(string tabString) {

        }
    }
}
