using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamarinFormsTest.Services;

namespace XamarinFormsTest.ViewModels
{
    public class PrintViewModel: BaseViewModel
    {
        private readonly IBluethoothService bluethoothService;
        private IList<string> deviceList;
        public IList<string> DeviceList
        {
            get
            {
                if (deviceList == null)
                {
                    deviceList = new ObservableCollection<string>();
                }
                return deviceList;
            }
            set
            {
                SetProperty<IList<string>>(ref deviceList, value);
            }
        }

            private string printMsg;
        public string PrintMsg
        {
            get => printMsg; 
            set
            {
                SetProperty(ref printMsg, value);
            }
        }

        private string selectedDevice;
        public string SelectedDevice
        {
            get => selectedDevice;
            set
            {
                SetProperty(ref selectedDevice, value);
            }
        }

        public ICommand PrintCommand => new Command(async () =>
        {
            await bluethoothService.Print(SelectedDevice, PrintMsg);
        });

        public ICommand PrintVerticalCommand => new Command(async () =>
        {
            await bluethoothService.PrintVertical(SelectedDevice);
        });

        public PrintViewModel()
        {
            bluethoothService = DependencyService.Get<IBluethoothService>();
            var list = bluethoothService.GetDevices();
            DeviceList.Clear();
            list.ForEach(x => DeviceList.Add(x));

        }
    }
}
