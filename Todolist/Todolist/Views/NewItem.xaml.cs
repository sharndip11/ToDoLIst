using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Todolist.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todolist.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewItem : ContentPage
	{
		public NewItem ()
		{
			InitializeComponent ();
		}

		private async Task ToolbarItem_ClickedAsync(object sender, EventArgs e)
		{
			
			
		}

		private async Task bEnregistrer_ClickedAsync(object sender, EventArgs e)
		{
			if (eItemDescription.Text != null && eItemText.Text != null && eItemText.Text.Length > 1 && eItemDescription.Text.Length > 1)
			{
				Item newItem = new Item();
				newItem.text = eItemText.Text;
				newItem.description = eItemDescription.Text;


				var uri = new Uri("http://formation-roomy.inow.fr/api/todoitems/");
				var client = new HttpClient();

				var formContent = new FormUrlEncodedContent(new[]
				{
				new KeyValuePair<string, string>("text", newItem.text),
				new KeyValuePair<string, string>("description", newItem.description),
				});


				HttpResponseMessage response;
				response = await client.PostAsync(uri, formContent);
				if (response.IsSuccessStatusCode)
				{
					await DisplayAlert("Validation", "Tâche enregistrée avec succès", "Ok");
					Navigation.PopModalAsync();
				}
				else
				{
					await DisplayAlert("Erreur", "Impossible d'enregistrer la tâche", "Ok");
				}
			}
		}
	}
}