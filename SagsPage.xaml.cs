using Elgigantenrepare.Models;
using Elgigantenrepare.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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


    public sealed partial class SagsPage : Page , INotifyPropertyChanged
    {

        public ApiClient Api = new ApiClient();
        ObservableCollection<SagModel> sagsBinding = new ObservableCollection<SagModel>();


        ObservableCollection<medarbejdereModel> medarbejderBinding = new ObservableCollection<medarbejdereModel>();
        ObservableCollection<kundeModel> kundeBinding = new ObservableCollection<kundeModel>();
        ObservableCollection<ProduktModel> produktBinding = new ObservableCollection<ProduktModel>();
        ObservableCollection<StatusModel> statusBinding = new ObservableCollection<StatusModel>();
        ObservableCollection<SagTypeModel> sagTypeBinding = new ObservableCollection<SagTypeModel>();
        ObservableCollection<LeveringsTypeModel> leveringstypeBindin = new ObservableCollection<LeveringsTypeModel>();



        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isenabled; 

        public bool isenabled 
            {
            get { return _isenabled;  }
            set 
            { 
                _isenabled = value;
                NotifyPropertyChanged("isenabled"); 
            } 
        }
        
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int sagid; 

      


        public SagsPage()
        {
    

        }
        
    

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            sagid = Convert.ToInt32(e.Parameter);


            SagModel singlesag = await Api.getSag(sagid);

            sagsBinding.Add(singlesag);

            isenabled = false;

            fillComboBox(); 

            this.InitializeComponent();


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void chip_id_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void test_drop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isenabled == false)
            {
                isenabled = true;

                editButton.Content = "Save"; 

            }
            else
            {

                string beskrivelse = this.beskrivelse.Text;

                int chip_id = Convert.ToInt32(this.chip_id.Text);

                opretSagModel sag = new opretSagModel(beskrivelse, chip_id, Convert.ToInt32(Medarbejder_drop.SelectedValue), Convert.ToInt32(Kunder_drop.SelectedValue), Convert.ToInt32(Produkt_drop.SelectedValue), Convert.ToInt32(Status_drop.SelectedValue), Convert.ToInt32(Type_drop.SelectedValue), Convert.ToInt32(Leverings_drop.SelectedValue));

                bool? success = await Api.putSag( sagid , sag);
                if (success == true)
                {
                    var popup = new MessageDialog("sag blev rettet");

                    await popup.ShowAsync();
                }
                else
                {
                    var popup = new MessageDialog("sag blev ikke rettet");

                    await popup.ShowAsync();
                }


                isenabled = false;

                editButton.Content = "Edit";
            }

        }

        private async void fillComboBox()
        {

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

            Medarbejder_drop.SelectedValue = sagsBinding[0].medarbejder.id; 
            Kunder_drop.SelectedValue = sagsBinding[0].kunde.id;
            Produkt_drop.SelectedValue = sagsBinding[0].produkt.id;
            Status_drop.SelectedValue = sagsBinding[0].status.id;
            Type_drop.SelectedValue = sagsBinding[0].sagstype.id;
            Leverings_drop.SelectedValue = sagsBinding[0].afhentningstype.id;


        }

        private async void deleteBTN_Click(object sender, RoutedEventArgs e)
        {

            bool? success = await Api.deleteSag(sagid);
            if (success == true)
            {
                var popup = new MessageDialog("sag blev slettet");

                await popup.ShowAsync();
                this.Frame.Navigate(typeof(SagListPage), null);

            }
            else
            {
                var popup = new MessageDialog("sag blev ikke slettet");

                await popup.ShowAsync();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SagListPage), null);

        }
    }
}
