using System;
using System.Collections.Generic;
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
using Elgigantenrepare.Models;
using Elgigantenrepare.Services;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Elgigantenrepare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OpretSagPage : Page
    {

        
        public ApiClient Api = new ApiClient();

        // lister som kan bindes til front end 
        ObservableCollection<medarbejdereModel> medarbejderBinding = new ObservableCollection<medarbejdereModel>(); 
        ObservableCollection<kundeModel> kundeBinding = new ObservableCollection<kundeModel>(); 
        ObservableCollection<ProduktModel> produktBinding = new ObservableCollection<ProduktModel>(); 
        ObservableCollection<StatusModel> statusBinding = new ObservableCollection<StatusModel>(); 
        ObservableCollection<SagTypeModel> sagTypeBinding = new ObservableCollection<SagTypeModel>(); 
        ObservableCollection<LeveringsTypeModel> leveringstypeBindin = new ObservableCollection<LeveringsTypeModel>();

        public OpretSagPage()
        {
            fillComboBox(); 
            this.InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
           // fyld text fra beskrivelses boksen ind i beskrivelse variablen 
           string beskrivelse = this.beskrivelse.Text;

            // fyld text fra chip_id boksen ind i chip_id variablen og konvater den til int 
            int chip_id = Convert.ToInt32( this.chip_id.Text) ;
         
            // fyld verdiger ind i en instans af opretsagmodel 
            opretSagModel sag = new opretSagModel(beskrivelse,chip_id, Convert.ToInt32(Medarbejder_drop.SelectedValue) , Convert.ToInt32(Kunder_drop.SelectedValue) , Convert.ToInt32(Produkt_drop.SelectedValue),Convert.ToInt32(Status_drop.SelectedValue),Convert.ToInt32(Type_drop.SelectedValue), Convert.ToInt32(Leverings_drop.SelectedValue));

            // send http request og check om den var en OK
            bool? success = await Api.postSag(sag);
            if (success == true)
            {   
                // lav text til popup 
                var popup = new MessageDialog("sag blev oprettet");
                // vis popup
                await popup.ShowAsync();
            }
            else
            {
                var popup = new MessageDialog("sag blev ikke oprettet");

                await popup.ShowAsync();
            }

           

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void test_drop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }

        private async void fillComboBox()
        {
            // fyld værdiger fra databasen ind i comboboxsene 
            List<medarbejdereModel> medarbejdere = await Api.getMedarbejdere(); 
            foreach (var i in medarbejdere)
            {
                medarbejderBinding.Add(i); 
            }
            List<kundeModel> kunder = await Api.getKunder();
            foreach (var i in kunder)
            {
                kundeBinding.Add(i);
            }
            List<ProduktModel> produkter = await Api.getProdukter();
            foreach (var i in produkter)
            {
                produktBinding.Add(i);
            }
            List<StatusModel> statuser = await Api.getStatuser();
            foreach (var i in statuser)
            {
                statusBinding.Add(i);
            }
            List<SagTypeModel> sagTyper = await Api.getSagstyper();
            foreach (var i in sagTyper)
            {
                sagTypeBinding.Add(i);
            }
            List<LeveringsTypeModel> leveringsTyper = await Api.getLeveringsTyper();
            foreach (var i in leveringsTyper)
            {
                leveringstypeBindin.Add(i);
            }
            
        }

        private void produkt_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        // naviger til ny side når der bliver klikket på knappen 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage), null);

        }
    }
}
