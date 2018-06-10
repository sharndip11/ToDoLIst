using System;
using Todolist.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Todolist
{
	public partial class App : Application
	{
		//string token = "1szD6CDHvhZ7yHVuo2XjU2vOt65UPdpsiivmAxpNJiKqtzIC7v9FHS6NYtIuqLE7gFTJUrbKc5aNmZ61-gphUP9BraL5kESamgih-xGA6PyinQmaFCu3EzVQgjqzoXcK0uuTR2PXojA_x9BjWAWf8BMVEplH6X1J7FZ9LayP1vxZjxo1C1Dgiy9vmuubCR2qb6BS6tCfNJsth2Bk72B3LThdi2I67YN_3UMLhHNpJ6c";
		public App ()
		{
			InitializeComponent();		
			
			MainPage = new Login(); 
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
