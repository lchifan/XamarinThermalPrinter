using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinFormsTest.ViewModels;
using XamarinFormsTest.Views;

namespace XamarinFormsTest
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
