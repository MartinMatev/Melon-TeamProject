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
namespace MelonDocumentationGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DocumentationGenerator facade;
        public MainWindow()
        {
            InitializeComponent();
            facade = new DocumentationGenerator();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!AllFieldsFilled(tbCourse.Text,tbNameTeam.Text,tbProjectName.Text,tbProjectTypeInfo.Text))
            {
                lblError.Content = "Please fill all fields!";
            }
            else
            {
                if (facade.GeneralProjectExist())
                {
                    facade.EditGeneralProjectInfo(tbProjectTypeInfo.Text, tbNameTeam.Text, tbCourse.Text, tbProjectName.Text);
                    lblError.Content = "Edit Done!";
                }
                else
                {
                    facade.CreateNewGeneralProjectInfo(tbProjectTypeInfo.Text, tbNameTeam.Text, tbCourse.Text, tbProjectName.Text);
                    lblError.Content = "Done!";
                }
            }
        }

        private bool AllFieldsFilled(params string[] fields)
        {
            foreach(string field in fields)
            {
                if (String.IsNullOrWhiteSpace(field))
                    return false;           
            }
            return true;
        }
    }
}
