using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FingerPrintMTWDM
{
    using Plugin.Fingerprint;
    using Plugin.Fingerprint.Abstractions;

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);
            if (result)
            {
                var dialogConfig = new AuthenticationRequestConfiguration("Mensaje", "Toca el sensor")
                {
                    CancelTitle = null,
                    FallbackTitle = null
                };

                var auth = await CrossFingerprint.Current.AuthenticateAsync(dialogConfig);
                if (auth.Authenticated)
                    Resultado.Text = "Autenticado!";
                else
                    Resultado.Text = "Huella digital no reconocida";
            }
            else
                await DisplayAlert("ooops", "Dispositivo no compatible", "OK");
        }
    }
}
