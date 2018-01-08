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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        AddressBookUserControl ad = new AddressBookUserControl();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void cmdOpen_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void cmdOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Text documents (.txt)|*.txt";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                int index = 1;

                var uc = new AddressBookUserControl();
                String filname = dlg.FileName;
                uc.Tcontacts.Load(filname);
                uc.Tcontacts.Path = filname;

                var ti = new TabItem();
                ti.Content = uc;

                foreach (TabItem tab in tabContact.Items)
                {
                    String THeader = (String)tab.Header;
                    if (THeader.Split('\u0028')[0].Equals(dlg.SafeFileName.Split('\u0028')[0]))
                    {
                        index++;
                    }

                }
                if (index == 1)
                {
                    ti.Header = dlg.SafeFileName;
                }
                else
                {
                    ti.Header = dlg.SafeFileName + "("+index+")";
                    
                }
                tabContact.Items.Add(ti);     // ajout de l’onglet
                tabContact.SelectedItem = ti;   // sélection de l’onglet
            }
        }

        private void cmdSave_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ad.Tcontacts != null)
            {
                e.CanExecute = true;
            }
        }

        private void cmdSave_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            TabItem ti = (TabItem)tabContact.SelectedItem;
            AddressBookUserControl adbuc = (AddressBookUserControl)ti.Content;

            adbuc.Tcontacts.Save();
            
        }

        private void cmdSaveAs_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ad.Tcontacts != null)
            {
                e.CanExecute = true;
            }
        }

        private void cmdSaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.Filter = "Text documents (.txt)|*.txt";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                String filename = dlg.FileName;
                TabItem ti = (TabItem)tabContact.SelectedItem;
                AddressBookUserControl adbuc = (AddressBookUserControl)ti.Content;
                adbuc.Tcontacts.SaveAs(filename);
            }
        }

        private void cmdHelp_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void cmdHelp_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void cmdNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void cmdNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int index = 1;

            var uc = new AddressBookUserControl();
            uc.Tcontacts.Clear();
             
            var ti = new TabItem();
            ti.Content = uc;

            foreach (TabItem tab in tabContact.Items)
            {
                String THeader = (String)tab.Header;
                if (THeader.Split('\u0028')[0].Equals("*New"))
                {
                    index++;
                }
                
            }
            if(index == 1)
            {
                ti.Header = "*New";
            }
            else
            {
                ti.Header = "*New(" + index + ")";
            }
            
            tabContact.Items.Add(ti);     // ajout de l’onglet
            tabContact.SelectedItem = ti;   // sélection de l’onglet
            uc.Tcontacts.Clear();

        }

        private void tabContact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem ti = (TabItem)tabContact.SelectedItem;
            AddressBookUserControl adbuc = (AddressBookUserControl)ti.Content;
            NbrContacts.Content = adbuc.Tcontacts.Count + " contact(s)";
        }
    }
}
