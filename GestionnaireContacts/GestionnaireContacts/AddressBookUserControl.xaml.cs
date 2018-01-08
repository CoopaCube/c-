using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionnaireContacts
{
    /// <summary>
    /// Logique d'interaction pour AddressBookUserControl.xaml
    /// test
    /// </summary>
    public partial class AddressBookUserControl : UserControl
    {
        private AdressBook tcontacts;

        internal AdressBook Tcontacts
        {
            get { return tcontacts; }
            set { tcontacts = value; }
        }


        public AddressBookUserControl()
        {
            InitializeComponent();
            tcontacts = new AdressBook();
            this.DataContext = tcontacts;
        }
    }
}
