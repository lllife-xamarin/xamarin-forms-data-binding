using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace DataBinding
{
	public class DetailViewModel: INotifyPropertyChanged
	{
		private static readonly string JannineName = "Jannine";
		private static readonly string JannineLastName = "Weigel";

		private string _forename = JannineName, _surename = JannineLastName;

		public string Forename {
			get { return _forename; }
			set {
				if (Forename != value) {
					_forename = value;
					OnPropertyChanged ("Forename");
					OnPropertyChanged ("IsJannine");
				}
			}
		}

		public string Surename {
			get { return _surename; }
			set {
				if (Surename != value) {
					_surename = value;
					OnPropertyChanged ("Surename");
					OnPropertyChanged ("IsJannine");
				}
			}
		}

		public bool IsJannine {
			get {
				return Forename == JannineName && Surename == JannineLastName;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged (string propertyName)
		{
			var change = PropertyChanged;
			change?.Invoke(this, new PropertyChangedEventArgs (propertyName));
		}
	}
}

