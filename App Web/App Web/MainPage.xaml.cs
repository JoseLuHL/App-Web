using Foundation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace App_Web
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //GetDetail();
            TasAsync();
            //TasAsync();
            //Webview.Source = "http://192.168.1.10:8080/prueba/prueba.php";
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await progress.ProgressTo(0.9, 900, Easing.SpringIn);
        }

        protected void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            progress.IsVisible = true;
        }

        protected void OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            progress.IsVisible = false;
        }
        public async void GetDetail()
        {
            HttpClient client = new HttpClient();
            var RestURL = "http://192.168.1.10:8080/prueba/prueba.php";
            client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(RestURL);
            HttpContent _Hcontent = response.Content;
            var result = await _Hcontent.ReadAsStringAsync();
            var Items = JsonConvert.DeserializeObject(result);
            //Webview.Source = new HtmlWebViewSource
            //{
            //    Html = Items.
            //}
        }


       
        //public MainPage()
        //{
        //    InitializeComponent();
        //    //TasAsync();
        //}
        async Task TasAsync()
        {
            // Create a request using a URL that can receive a post.
            //WebRequest request = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ");
            //// Set the Method property of the request to POST.
            //request.Method = "POST";

            //// Create POST data and convert it to a byte array.
            //string postData = "This is a test that posts this string to a Web server.";
            //byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //// Set the ContentType property of the WebRequest.
            //request.ContentType = "application/x-www-form-urlencoded";
            //// Set the ContentLength property of the WebRequest.
            //request.ContentLength = byteArray.Length;

            //// Get the request stream.
            //Stream dataStream = request.GetRequestStream();
            //// Write the data to the request stream.
            //dataStream.Write(byteArray, 0, byteArray.Length);
            //// Close the Stream object.
            //dataStream.Close();

            //// Get the response.
            //WebResponse response = request.GetResponse();
            //// Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            //// Get the stream containing content returned by the server.
            //// The using block ensures the stream is automatically closed.
            //using (dataStream = response.GetResponseStream())
            //{
            //    // Open the stream using a StreamReader for easy access.
            //    StreamReader reader = new StreamReader(dataStream);
            //    // Read the content.
            //    string responseFromServer = reader.ReadToEnd();
            //    // Display the content.
            //    Console.WriteLine(responseFromServer);

            //    var web = new WebView();
            //    var html = new HtmlWebViewSource
            //    {
            //        Html = responseFromServer
            //    };

            //    var url = new UrlWebViewSource
            //    {
            //        Url = "http://192.168.1.10:8080/prueba/prueba.php"
            //    };
            
            //    bool useHtml = true;
            //progress.IsVisible = true;
            Webview.IsVisible = false;
            await Task.Delay(2000);
            //progress.IsVisible = false;
            Webview.IsVisible = true;
            Webview.Source = "http://192.168.1.10:8080/prueba/prueba.php?precio=10000&descripcion=Reserva%20de%20cancha%20real%20madrid%20por%20el%20precio%20de%2020.000";
            //Webview.Source = "http://192.168.1.10:8080/prueba/prueba.php?prueba=Hola%20mundo";
            //}
            // Close the response.
            //response.Close();


        }
    }
}
