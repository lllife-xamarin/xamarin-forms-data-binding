### Xamarin.Forms Data Binding Example

- DatabindingExample.xaml

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="DataBinding.DatabindingExample">
    <ContentPage.Content>
        <StackLayout Padding="5,20,5,5">
            <Label Text="Data Binding 101" FontAttributes="Bold" HorizontalOptions="Center"/>
            <Label Text="First Name" />
            <Entry Text="{Binding Forename, Mode=TwoWay}"/>
            <Label Text="Last Name" />
            <Entry Text="{Binding Surename, Mode=TwoWay}"/>
            <StackLayout Orientation="Horizontal">
                <Label Text="{Binding Forename}"/>
                <Label Text="{Binding Surename}"/>
            </StackLayout>
            <StackLayout Padding="0, 20,0,0" IsVisible="{Binding IsJannine}">
                <Image Source="jw.png"/>
            </StackLayout>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

- DatabindingExample.xaml.cs

```csharp
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DataBinding {
    public partial class DatabindingExample : ContentPage {
        public DatabindingExample () {
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
```

- DetailViewModel.cs

```csharp
using System.ComponentModel;

namespace DataBinding {
    public class DetailViewModel: INotifyPropertyChanged {
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

        public bool IsJannine { get {
                return Forename == JannineName && Surename == JannineLastName;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged (string propertyName) {
            var change = PropertyChanged;
            change?.Invoke(this, new PropertyChangedEventArgs (propertyName));
        }
    }
}
```


![](screen/jw.png)

#### Reference

- https://blog.xamarin.com/introduction-to-data-binding

