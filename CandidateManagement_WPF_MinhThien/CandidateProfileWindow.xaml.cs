using Candidate_BusinessObjects;
using Candidate_Services;
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
using System.Windows.Shapes;

namespace CandidateManagement_WPF_MinhThien
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private ICandidateProfileService profileService;
        private IJobPostingService jobPostingService;
        public CandidateProfileWindow()
        {
            InitializeComponent();
            profileService = new CandidateProfileService();
            jobPostingService = new JobPostingService();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadDataInit();
        }

        private void loadDataInit()
        {
            this.dtgCandidateProfile.ItemsSource = profileService.GetCandidateProfiles();
            this.cmbPostID.ItemsSource = jobPostingService.GetJobPostings();
            this.cmbPostID.DisplayMemberPath = "JobPostingTitle";
            this.cmbPostID.SelectedValuePath = "PostingId";

            txtCandidateID.Text = "";
            txtBirthDay.Text = "";
            txtDescription.Text = "";
            txtImageURL.Text = "";
            txtFullName.Text = "";
            cmbPostID.SelectedValue = "";
        }

        private void dtgCandidateProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex) as DataGridRow;
            if (row != null)
            {
                DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent
                    as DataGridCell;
                string id = ((TextBlock)RowColumn.Content).Text;
                CandidateProfile profile = profileService.GetCandidateProfileById(id);
                if (profile != null)    
                {
                    txtCandidateID.Text = profile.CandidateId;
                    txtBirthDay.Text = profile.Birthday.ToString();
                    txtDescription.Text = profile.ProfileShortDescription;
                    txtImageURL.Text = profile.ProfileUrl;
                    txtFullName.Text = profile.Fullname;
                    cmbPostID.ItemsSource = jobPostingService.GetJobPostings();
                    cmbPostID.SelectedValue = profile.PostingId;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = new CandidateProfile();
            candidate.CandidateId = txtCandidateID.Text;
            candidate.Fullname = txtFullName.Text;
            candidate.Birthday = DateTime.Parse(txtBirthDay.Text);
            candidate.ProfileUrl = txtImageURL.Text;
            candidate.PostingId = cmbPostID.SelectedValue.ToString();
            candidate.ProfileShortDescription = txtDescription.Text;
            if (profileService.AddCandidateProfile(candidate))
            {
                MessageBox.Show("Add Successfully");
                loadDataInit();
            }
            else
            {
                MessageBox.Show("Create Fail!!!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            CandidateProfile candidate = new CandidateProfile();
            candidate.CandidateId = txtCandidateID.Text;
            candidate.Fullname = txtFullName.Text;
            candidate.Birthday = DateTime.Parse(txtBirthDay.Text);
            candidate.ProfileUrl = txtImageURL.Text;
            candidate.PostingId = cmbPostID.SelectedValue.ToString();
            candidate.ProfileShortDescription = txtDescription.Text;
            if (profileService.UpdateCandidateProfile(candidate))
            {
                MessageBox.Show("Update Successfully");
                loadDataInit();
            }
            else
            {
                MessageBox.Show("Update Fail!!!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dtgCandidateProfile.SelectedItem is CandidateProfile selectedProfile)
            {
                var result = MessageBox.Show("Are you sure you want to delete this profile?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    bool isDeleted = profileService.DeleteCandidateProfile(selectedProfile.CandidateId);
                    if (isDeleted)
                    {
                        MessageBox.Show("Profile deleted successfully!");
                        loadDataInit();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the profile.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a profile to delete.");
            }
        }
    }
}
