using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DataBinding
{
	public partial class DatabindingExample : ContentPage
	{
		public DatabindingExample ()
		{
			InitializeComponent ();
			BindingContext = new DetailViewModel ();

			Resources = new ResourceDictionary ();
			Resources.Add (new Style (typeof (Image)) {
				Setters = {
					new Setter { Property = Image.OpacityProperty, Value = .5 }
				}
			});
		}
	}
}

