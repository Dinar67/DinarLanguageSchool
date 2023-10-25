using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LanguageSchool.Base;
using Microsoft.Win32;


namespace LanguageSchool.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        private Service service;
        public AddEditServicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service; 
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if(App.db.Service.Any(x => x.Title == service.Title))
                error.AppendLine("Услуга с таким именем уже существует! ");

            if (service.DurationInSeconds > 14400)
                error.AppendLine("Услуга не может превышать 4 часа! ");

            if(error.Length > 0)
            {
                System.Windows.Forms.MessageBox.Show(error.ToString());
                return;
            }
            if(service.ID == 0)
            {
                Service newService = App.db.Service.Add(service);

            }
            App.db.SaveChanges();
            Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
        }

        private void EditImageBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile = new System.Windows.Forms.OpenFileDialog() {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            openFile.ShowDialog();
            if(openFile.FileName != null)
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
    }
}
