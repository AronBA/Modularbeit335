using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace ModularbeitM335
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }
       

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                try
                {
                    await App.Database.SavePersonAsync(new Game
                    {
                        name =  nameEntry.Text,
                        developer = devEntry.Text,
                        releasedate = releaseDatePicker.Date
                    });
                    _ = DisplayAlert("Notification", "the game got succesfully insterted into the database", "ok");
                }
                catch (Exception ex)
                {
                    _ = DisplayAlert("Notification", "an unexpected error has occurd: " + ex, "ok");

                }
                finally
                {


                    nameEntry.Text = string.Empty;
                    devEntry.Text = string.Empty;
                    releaseDatePicker.Date = DateTime.Now;
                    collectionView.ItemsSource = await App.Database.GetPeopleAsync();
                }


             
                
                
                
            }
        }
    }
}