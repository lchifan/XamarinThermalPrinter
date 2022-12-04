using System.ComponentModel;
using Xamarin.Forms;
using XamarinFormsTest.ViewModels;

namespace XamarinFormsTest.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}