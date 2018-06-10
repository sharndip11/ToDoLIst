using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Todolist.Models;
using Xamarin.Forms;

namespace Todolist.ViewModels
{
    class MaListeViewModel : BaseViewModel
    {
		public ObservableCollection<Item> Items { get; set; }
		public Command LoadItemsCommand { get; set; }

		private bool isBusy;
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); /*isBusy = value;*/ }
		}

		public MaListeViewModel()
		{
			Items = new ObservableCollection<Item>();
			LoadItemsCommand = new Command(async () => await ExecuteLoadItem());
		}

		protected async Task ExecuteLoadItem()
		{
			isBusy = true;
			Items.Clear();
			var items = await GetAllItem();
			try
			{
				foreach (var element in items)
				{
					Items.Add(element);
				}
			}
			catch (Exception)
			{

				throw;
			}
			isBusy = false;
			
		}

		public async Task<List<Item>> GetAllItem()
		{

			var uri = new Uri("http://formation-roomy.inow.fr/api/todoitems");
			var client = new HttpClient();
			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var listItem = JsonConvert.DeserializeObject<List<Item>>(content);
				return listItem;
			}

			return null;
		}
	}
}
