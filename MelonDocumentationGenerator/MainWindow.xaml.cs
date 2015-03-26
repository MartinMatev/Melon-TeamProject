using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;
using  PathIO = System.IO.Path;
using System.Windows.Media.Imaging;
using WPF.Themes;

namespace MelonDocumentationGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RadioButton rbTypeMember;
        private DocumentationGenerator facade;
        private OpenFileDialog screenshotDialog = new OpenFileDialog();
        private Nullable<bool> screenshotDialogResult;
        private string lastImageChosen;

        public MainWindow()
        {
            InitializeComponent();
            facade = new DocumentationGenerator();
            rbTypeMember = rbTrainee;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            themes.ItemsSource = ThemeManager.GetThemes();
        }
        private void themes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string theme = e.AddedItems[0].ToString();

                // Window Level
                // this.ApplyTheme(theme);

                // Application Level
                // Application.Current.ApplyTheme(theme);
            }
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

        private void SubmitProjectRepositoryInfo(object sender, RoutedEventArgs e)
        {
            if (!this.AllFieldsFilled(tbRepositoryName.Text, tbRepositoryUrl.Text))
            {
                this.statusLabel_projectRepositoryInfo.Content = "Please fill all fields!";
            }
            else
            {
                if (this.facade.GitUrlExist())
                {
                    facade.EditProjectGit(tbRepositoryName.Text, tbRepositoryUrl.Text);
                    this.statusLabel_projectRepositoryInfo.Content = "Edit Done!";
                }
                else
                {
                    facade.CreateNewProjectGit(tbRepositoryName.Text, tbRepositoryUrl.Text);
                    this.statusLabel_projectRepositoryInfo.Content = "Done!";
                }
            }
        }

        private void AddTeamMember(object sender, RoutedEventArgs e)
        {
            if (!this.AllFieldsFilled(tbFName.Text, tbLastName.Text, tbUserName.Text) || (this.rbTypeMember == null))
            {
                this.lblTeamMemberMessage.Content = "Please fill all fields!";
            }

            else
            {
                if (this.facade.TeamMemberExist(tbFName.Text, tbLastName.Text, tbUserName.Text))
                {

                    this.lblTeamMemberMessage.Content = "This member alredy exist!";
                }
                else
                {
                    facade.AddNewTeamMember(tbFName.Text, tbLastName.Text, tbUserName.Text, rbTypeMember.Name.Substring(2), (bool)cxbHasParticipated.IsChecked);

                    this.lblTeamMemberMessage.Content = "Member added!";
                }
            }
        }
        private void HandleCheckTeamMember(object sender, RoutedEventArgs e)
        {
            this.rbTypeMember = sender as RadioButton;
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


        private void SubmitMainDescription(object sender, RoutedEventArgs e)
        {
            facade.ProjectDescriptionChanged(this.tbr_mainProjectDescription.Text);

            MessageBox.Show("Project description saved!", "Description saved", MessageBoxButton.OK);
        }


        private void Btn_screenshotDialog_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog screenshotDialog = new OpenFileDialog();

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

        private void TeamMemberSubmit_OnLostFocus(object sender, RoutedEventArgs e)
        {
            this.lblTeamMemberMessage.Content = String.Empty;
        }

        #region LoadExternalResource
        private void LoadStackResource(object sender, RoutedEventArgs e)
        {
            this.ResourceName.Text = "Stack Overflow";
            this.ResourceURL.Text = "http://stackoverflow.com/";
        }

        private void LoadMsdnResource(object sender, RoutedEventArgs e)
        {
            this.ResourceName.Text = "MSDN";
            this.ResourceURL.Text = "https://msdn.microsoft.com";
        }

        private void LoadCodeProjectResource(object sender, RoutedEventArgs e)
        {
            this.ResourceName.Text = "Code Project";
            this.ResourceURL.Text = "http://www.codeproject.com/";
        }

        private void LoadWikipediaResource(object sender, RoutedEventArgs e)
        {
            this.ResourceName.Text = "Wikipedia";
            this.ResourceURL.Text = "http://www.wikipedia.org/";
        }

        #endregion

        private void ExternalResourceSubmit(object sender, RoutedEventArgs e)
        {
            if (!this.AllFieldsFilled(this.ResourceName.Text, this.ResourceURL.Text))
            {
                if (String.IsNullOrWhiteSpace(this.ResourceName.Text))
                {
                    this.ResourceNameLabel.Foreground = Brushes.Red;
                }
                if (String.IsNullOrWhiteSpace(this.ResourceURL.Text))
                {
                    this.ResourceUrlLabel.Foreground = Brushes.Red;
                }
            }
            else
            {
                this.ResourceUrlLabel.Foreground = Brushes.Black;
                this.ResourceNameLabel.Foreground = Brushes.Black;

                this.facade.AddResource(this.ResourceName.Text, this.ResourceURL.Text);

                MessageBox.Show("Resource added!", "Resource added", MessageBoxButton.OK);
            }
        }

        private void OnStyleComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            var patternCombo = sender as ComboBox;
            var selectedItem = patternCombo.SelectedItem as ComboBoxItem;
            if (selectedItem == null)
            {
                patternCombo.SelectedIndex = 0;
                return;
            }

            if (selectedItem.Content.ToString() == "Default Pattern")
            {
                SetStyleImagePreview("../../Images/Koala.jpg");                
            }
            else
            {
                SetStyleImagePreview("../../Images/Penguins.jpg");
            }
        }

        private void SetStyleImagePreview(string path)
        {
            imgStylePreview.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(path)));
        }

        private void OnStyleButtonClick(object sender, EventArgs e)
        {
            ComboBoxItem comboboxItem = cmbStyle.SelectedItem as ComboBoxItem;

            if (comboboxItem != null)
            {
                MessageBox.Show("I LIED....");
            }

            if (comboboxItem.Content.ToString() == "Default Pattern")
            {
                facade.CreateNewDefaultStyle();
            }
            else
            {
                facade.CreateNewMelonStyle();
            }
        }

        private void GitUrlSubmit_LostFocus(object sender, RoutedEventArgs e)
        {
            this.statusLabel_projectRepositoryInfo.Content = String.Empty;
        }
    }
}
