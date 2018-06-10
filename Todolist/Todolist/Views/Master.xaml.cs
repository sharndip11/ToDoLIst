using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todolist.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : TabbedPage
	{
		public Master ()
		{
			InitializeComponent ();
		}
	}
}