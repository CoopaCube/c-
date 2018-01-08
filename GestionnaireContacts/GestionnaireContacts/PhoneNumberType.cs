using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireContacts
{
    class PhoneNumberType
    {
        public static List<PhoneNumberType> PhoneNumberTypes { get; set; }

        public String Description { get; set; }
        public String Name { get; set; }
        public int Types { get; set; }

        public PhoneNumberType() { }

        static PhoneNumberType()
        {
            PhoneNumberTypes = new List<PhoneNumberType>();
            PhoneNumberTypes.Add(new PhoneNumberType(1, "Tel.Priv.", "Téléphone privé"));
            PhoneNumberTypes.Add(new PhoneNumberType(2, "Fax", "Télécopie"));
            PhoneNumberTypes.Add(new PhoneNumberType(3, "Tel.Prof.", "Téléphone professionnel"));
            PhoneNumberTypes.Add(new PhoneNumberType(4, "Mobile", "Téléphone mobile"));
        }

        public PhoneNumberType(int id, String name, String description)
        {
            Types = id;
            Name = name;
            Description = description;
        }

    }
}
