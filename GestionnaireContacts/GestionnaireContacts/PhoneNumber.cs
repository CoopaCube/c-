using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireContacts
{
    class PhoneNumber
    {
        private String number;
        private PhoneNumberType type;

        public String Number
        {
            get { return number; }
            set { if (number != value) {
                    number = value;
                }
            }
        }

        public PhoneNumberType Type
        {
            get { return type; }
            set { if (type != value) {
                    type = value;
                }
            }
        }

        public PhoneNumber(){}

        public PhoneNumber(String csvString)
        {
            FromCsvString(csvString);
        }

        public PhoneNumber(String number, PhoneNumberType type)
        {
            Number = number;
            Type = type;
        }

        public PhoneNumber(PhoneNumber num)
        {

        }

        public void FromCsvString(String tabString)
        {
            String[] split = tabString.Split(',');
            this.Number = split[0];
        }

        public String ToCsvString()
        {
            return Number + ',' + Type.Types;
        }
    }
}
