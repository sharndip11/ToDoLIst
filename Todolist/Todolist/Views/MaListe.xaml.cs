using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Todolist.Models;
using Todolist.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todolist.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MaListe : ContentPage
	{
		MaListeViewModel viewModel;
		public MaListe ()
		{
			InitializeComponent (); 	
			BindingContext = viewModel = new MaListeViewModel();

		}

		private async Task ToolbarItem_ClickedAsync(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewItem());
		}
		
		public async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as Item;
			if (item != null)
			{
				await Navigation.PushAsync(new ItemSelectedPage(item));
			}
		}
	}
}