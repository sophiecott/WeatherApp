using Newtonsoft.Json.Linq;
using System.Net;

namespace WeatherApp;

public partial class MainPage : ContentPage
{
	int count = 0;
	const string API_KEY = "40a7361d3ed692022ef5da1fd852829f";

    public MainPage()
	{
		InitializeComponent();
	}


	private void BtnShowTemp_Clicked(object sender, EventArgs e)
	{
		if (EntryZip.Text != null)
		{
			using (WebClient wc = new WebClient())
			{
				string jsonResponse = wc.DownloadString($"https://api.openweathermap.org/data/2.5/weather?zip={EntryZip.Text}&appid={API_KEY}");

				JObject jo = JObject.Parse(jsonResponse);
				string cityName = jo["name"].ToString();
				DisplayAlert("City", cityName, "Close");
			}
		}
		else
		{
			DisplayAlert("Invalid Input","Please enter a zip code","Close");
		}

	}
}

