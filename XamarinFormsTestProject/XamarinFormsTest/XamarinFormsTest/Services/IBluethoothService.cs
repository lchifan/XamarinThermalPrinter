using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsTest.Services
{
    public interface IBluethoothService
    {
        IList<string> GetDevices();
        Task Print(string deviceName, string text);
        Task PrintVertical(string deviceName);
    }
}
