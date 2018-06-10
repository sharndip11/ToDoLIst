using Newtonsoft.Json;
using RestSharp;
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
	public partial class ItemSelectedPage : ContentPage
	{
		Item monItem;
		public ItemSelectedPage ()
		{
			InitializeComponent ();
		}

		public ItemSelectedPage(Item item) : this()
		{
			if(item != null)
			{
				monItem = item;
				lText.Text += item.text;
				lDescription.Text += item.description;
				lDate.Text += item.createdDate;
				if (monItem.isDone == true)
				{
					bIsDone.IsVisible = false;
				}
			}
		}

		private async Task bIsDone_ClickedAsync(object sender, EventArgs e)
		{
			monItem.isDone = true;
			var uri = new Uri("http://formation-roomy.inow.fr/api/todoitems/" + monItem.id);
			var client = new HttpClient();
			var json = JsonConvert.SerializeObject(monItem);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			
			HttpResponseMessage response;
			response = await client.PutAsync(uri, content);
			if (response.IsSuccessStatusCode)
			{
				bIsDone.IsVisible = false;
			}
		}
	}
}