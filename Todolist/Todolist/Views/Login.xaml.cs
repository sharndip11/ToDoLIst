using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todolist.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestSharp;
using Newtonsoft.Json;
//using ZXing.Net.Mobile.Forms;

namespace Todolist.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent();
			
			button_Valid.Clicked += Button_Valid_ClickedAsync;
		}

        public class LoginToken
		{
			public string token { get; set; }
		}

		private async void Button_Valid_ClickedAsync(object sender, EventArgs e)
		{
			if(eLogin.Text != null && epassword.Text != null)
			{
				if (eLogin.Text != string.Empty && epassword.Text != string.Empty)
				{
					var client_login = new RestClient("https://reqres.in");
					var request_login = new RestRequest("/api/login", Method.POST);

					request_login.AddParameter("email", eLogin.Text);
					request_login.AddParameter("password", epassword.Text);
                    
                    IRestResponse response_login = client_login.Execute(request_login);
				    LoginToken loginToken = JsonConvert.DeserializeObject<LoginToken>(response_login.Content);

               
				    if (loginToken.token != null)
					{
						Application.Current.Properties["token"] = loginToken.token;
						await Navigation.PushModalAsync(new Master());
					}
					else
					{
						await DisplayAlert("Erreur", "Les informations saisies ne sont pas corrects", "ok");
					}
				}
				else
				{
					await DisplayAlert("Erreur", "Veuillez saisir l'adresse email et le mot de passe", "ok");
				}
			}
			else
			{
				await DisplayAlert("Erreur", "Veuillez saisir l'adresse email et le mot de passe", "ok");
			}
		}
	}
}