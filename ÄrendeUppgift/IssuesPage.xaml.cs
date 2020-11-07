using DataAccess.Data;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ÄrendeUppgift
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IssuesPage : Page
    {

        private Comment comment { get; set; }
        private IEnumerable<Issue> issues { get; set; }
        private long _customerId { get; set; }



        public IssuesPage()
        {
            this.InitializeComponent();
            LoadIssuesAsync().GetAwaiter();
            LoadStatusAsync().GetAwaiter();
        }

        private async Task LoadIssuesAsync()
        {
            issues = await SqliteContext.GetIssuesAsync();

            LoadActiveIssueAsync();
            LoadClosedIssueAsync();
        }

        private async Task LoadStatusAsync()
        {
            cmbStatus.ItemsSource = await SettingContext.GetStatus();
        }
        private async Task LoadCustomersAsync()
        {
            cmbCustomers.ItemsSource = await SqliteContext.GetCustomerNamesAsync();
        }


        private void LoadActiveIssueAsync()
        {
            LvActiveIssues.ItemsSource = issues.Where(i => i.Status != "closed").Take(SettingContext.GetMaxItemsCount()).ToList();
        }

        private void LoadClosedIssueAsync()
        {
            LvClosedIssues.ItemsSource = issues.Where(i => i.Status == "closed").ToList();
        }

        
        private async void CreateCase_Click(object sender, RoutedEventArgs e)
        {
            
            await SqliteContext.CreateIssueAsync(
                new Issue
                {
                    GuidId = Guid.NewGuid(),
                    Title =  TitleBox.ToString(),                                       
                    Status = cmbStatus.SelectedItem.ToString(),

                    CustomerId = await SqliteContext.GetCustomerIdByNameAsync(cmbCustomers.SelectedItem.ToString())

                }

                );

            await LoadIssuesAsync();
        }
    }
}
