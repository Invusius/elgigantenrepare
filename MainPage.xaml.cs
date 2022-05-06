using Elgigantenrepare.Models;
using Elgigantenrepare.Services;
using System;
using System.Collections.Generic;
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
using Windows.UI.Popups; 
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Elgigantenrepare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public ApiClient Api = new ApiClient();


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            

            medarbejderloginModel medarbejderlogin = new medarbejderloginModel(Usernamebox.Text , Passwordbox.Text); 

            bool? success = await Api.postMedarbejderlogin(medarbejderlogin);
            if (success == true)
            {
                var popup = new MessageDialog("medarbejder er logget ind");

                await popup.ShowAsync();

                this.Frame.Navigate(typeof(HomePage), null);

            }
            else
            {
                var popup = new MessageDialog("medarbejder findes ikke");

                await popup.ShowAsync();
            }
            //this.Frame.Navigate(typeof(BlankPage1), null);        


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage), null);        

        }
    }
}
