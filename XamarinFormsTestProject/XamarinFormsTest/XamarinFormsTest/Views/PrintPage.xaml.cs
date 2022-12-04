using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFormsTest.ViewModels;

namespace XamarinFormsTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrintPage : ContentPage
    {
        PrintViewModel viewModel;
        public PrintPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PrintViewModel();
        }
    }
}