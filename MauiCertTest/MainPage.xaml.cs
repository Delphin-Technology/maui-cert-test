using System.Diagnostics;

namespace MauiCertTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void FetchSelfSignedUrlClicked(object sender, EventArgs e)
        {
            try
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
                };
                var httpClient = new HttpClient(handler);
                var response = await httpClient.GetAsync("https://self-signed.badssl.com");
                FetchResult.Text = response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                FetchResult.Text = ex.ToString();
                Debug.WriteLine(ex);
            }
        }
    }

}
