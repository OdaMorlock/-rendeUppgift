using DataAccess.Data;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class CustomersPage : Page
    {
        private long _customerId { get; set; }

        public CustomersPage()
        {
            this.InitializeComponent();
        }
        private async void CreateCustomer_Click(object sender, RoutedEventArgs e)
        {

            _customerId = (int)(long)await SqliteContext.CreateCustomerAsync(new Customer { Name = CustomersName.ToString(), GuidId = Guid.NewGuid(), Created = DateTime.Now, Email = CustomersEmail.ToString() });
            
        }

    }
}
