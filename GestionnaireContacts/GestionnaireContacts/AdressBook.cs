using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireContacts
{
    class AdressBook : ObservableCollection<Contact>
    {
        private string path = @"C:\jub\contact.txt";

        public string Path { get; set; }


        public AdressBook() { }

        public AdressBook(String path)
        {
            this.Path = path;
        }
   
        public void Load(String filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    this.Add(new Contact(line));
                }
            }

        }

        public void Save()
        {
            SaveAs(this.Path);
            //using (StreamWriter sw = new StreamWriter(path))
            //{
            //    foreach (var sub in this)
            //    {
            //        sw.WriteLine(sub.ToTabString);
            //    }

            //}

        }

        public void SaveAs(String filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var sub in this)
                {
                    sw.WriteLine(sub.ToTabString);
                }

            }

        }
    }
}
