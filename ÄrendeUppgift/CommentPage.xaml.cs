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
    public sealed partial class CommentPage : Page
    {
        public static Issue Issue;
        private static int _issueId { get; set; }

        public CommentPage()
        {
            this.InitializeComponent();
            LoadIssueByTitleAsync().GetAwaiter();
        }

        private async Task LoadIssueByTitleAsync()
        {
            cmbIssueTitle.ItemsSource = await SqliteContext.GetIssuesByTitleAsync();
        }




        private async void CreateComment_Click(object sender, RoutedEventArgs e)
        {
            await SqliteContext.CreateCommentAsync(
               new Comment
               {
                   Description = CommentBox.ToString(),
                   IssueId = await SqliteContext.GetIssuesAsync(cmbIssueTitle.SelectedItem.ToString())

               }

               );

            await LoadIssueByTitleAsync();
        }
    }
}
