using Elgigantenrepare.Models;
using Elgigantenrepare.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Elgigantenrepare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SagListPage : Page
    {

        public ApiClient Api = new ApiClient();


        ObservableCollection<SagModel> sagBinding = new ObservableCollection<SagModel>();

        public SagListPage()
        {
            fillList(); 
            this.InitializeComponent();
        }

        private async void fillList()
        {

            
            List<SagModel> sager = await Api.getSager();
            foreach (var i in sager)
            {
                sagBinding.Add(i);
            }
        }

        
        private async void sagClick(object sender, RoutedEventArgs e)
        {
            var tester = (sender as Button).Tag; 

           


            this.Frame.Navigate(typeof(SagsPage), tester);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage), null);

        }
    }
}
