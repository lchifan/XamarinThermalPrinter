using Android.Bluetooth;
using Android.Media;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsTest.Droid;
using XamarinFormsTest.Services;
using static System.Net.Mime.MediaTypeNames;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidBluetoothService))]
namespace XamarinFormsTest.Droid
{
    public class AndroidBluetoothService : IBluethoothService
    {
        BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
        BluetoothDevice GetDevice(string name) => bluetoothAdapter?.BondedDevices.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        public IList<string> GetDevices()
        {
            return bluetoothAdapter?.BondedDevices.Select(x=> x.Name).ToList();
        }

        public async Task Print(string deviceName, string text)
        {
            try
            {
                
                BluetoothSocket socket = GetSocket(deviceName);
                await socket.ConnectAsync();

                await PrintByte(socket.OutputStream, Commands.ESC_Init);

                await PrintString(socket.OutputStream, text);
                await PrintByte(socket.OutputStream, Commands.ESC_J);

                socket.Close();

            }
            catch (Exception ex)
            {
                

                throw;
            }
        }

        private BluetoothSocket GetSocket(string deviceName)
        {
            var device = GetDevice(deviceName);

            if (device == null)
            {
                throw new Exception("Device not found");
            }
            return device.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-000-1000-8000-00805f9b34fb"));
        }

        private async Task PrintString(System.IO.Stream stream, string text)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);

            await stream.WriteAsync(buffer, 0, buffer.Length);
            await stream.FlushAsync();
        }

        private async Task PrintByte(System.IO.Stream stream, byte[] buffer)
        {
            await stream.WriteAsync(buffer, 0, buffer.Length);
            await stream.FlushAsync();
        }

        public async Task PrintVertical(string deviceName)
        {
            string text = "adkjdfg  sdfg \nkllldfgjjjj sgf\ndsfjlkfglkdjlkfdg\ntest";
            BluetoothSocket socket = GetSocket(deviceName);
            await socket.ConnectAsync();

            await PrintByte(socket.OutputStream, Commands.ESC_Init);
            await PrintByte(socket.OutputStream, Commands.ESC_V_Enable);

            await PrintString(socket.OutputStream, text);
            await PrintByte(socket.OutputStream, Commands.ESC_J);

            socket.Close();
        }
    }
}