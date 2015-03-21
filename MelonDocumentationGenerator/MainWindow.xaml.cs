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
using  PathIO = System.IO.Path;


namespace MelonDocumentationGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DocumentationGenerator facade;
        private Microsoft.Win32.OpenFileDialog screenshotDialog = new Microsoft.Win32.OpenFileDialog();
        private Nullable<bool> screenshotDialogResult;
        private string lastImageChosen;

        public MainWindow()
        {
            InitializeComponent();
            facade = new DocumentationGenerator();
        }

        private void SubmitGeneralInfo(object sender, RoutedEventArgs e)
        {
            if (!this.AllFieldsFilled(tbCourse.Text,tbNameTeam.Text,tbProjectName.Text,tbProjectTypeInfo.Text))
            {
                this.statusLabel_generlInfo.Content = "Please fill all fields!";
            }
            else
            {
                if (this.facade.GeneralProjectExist())
                {
                    facade.EditGeneralProjectInfo(tbProjectTypeInfo.Text, tbNameTeam.Text, tbCourse.Text,
                        tbProjectName.Text);
                    this.statusLabel_generlInfo.Content = "Edit Done!";
                }
                else
                {
                    facade.CreateNewGeneralProjectInfo(tbProjectTypeInfo.Text, tbNameTeam.Text, tbCourse.Text,
                        tbProjectName.Text);
                    this.statusLabel_generlInfo.Content = "Done!";
                }
            }
        }

        private bool AllFieldsFilled(params string[] fields)
        {
            foreach(string field in fields)
            {
                if (String.IsNullOrWhiteSpace(field))
                {
                    return false;
                }
            }
            return true;
        }

        private void Btn_screenshotDialog_OnClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog screenshotDialog = new Microsoft.Win32.OpenFileDialog();

            screenshotDialog.DefaultExt = ".png";
            screenshotDialog.Filter =
                "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            this.screenshotDialogResult = screenshotDialog.ShowDialog();

            if (this.screenshotDialogResult == true)
            {
                this.lastImageChosen = screenshotDialog.FileName;
            }
        }

        private void Btn_screenshotSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.screenshotDialogResult == true)
            {
                this.facade.AddScreenshot(this.lastImageChosen, this.tb_screenshotDescription.Text);
            }

            MessageBox.Show("Screenshot saved!", "Screenshot saved", MessageBoxButton.OK);

            string fileName = PathIO.GetFileName(this.lastImageChosen);
            string imageDescription = this.tb_screenshotDescription.Text
                .Substring(0, Math.Min(50, this.tb_screenshotDescription.Text.Length));

            this.tbl_screenshotStatus.Text += String.Format("{2}{0} - {1}", fileName,
                imageDescription, Environment.NewLine);

            this.tb_screenshotDescription.Text = String.Empty;
        }
    }
}
