using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace Toggle_WiFi
{

    static public class NetworkAdapterUtil
    {

        private static void ExecuteWaitProcess(string cmd, string args)
        {

            ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();
        }

        public static Task<bool> EnableAdapterAsync(string interfaceName, int timeOut = 10000)
        {
            bool enabled = false;
            int timeElapsed = 0;
            int timeWait = 100;
            var locker = new object();

            return Task.Run(() =>
            {

                ExecuteWaitProcess("netsh", "interface set interface \"" + interfaceName + "\" enable");

                do
                {
                    lock (locker) enabled = IsAdpapterEnabled(interfaceName);
                    Thread.Sleep(timeWait);
                    lock (locker) timeElapsed += timeWait;

                } while (!enabled && timeElapsed < timeOut);
                return enabled;
            });
        }

        public static Task<bool> DisableAdapterAsync(string interfaceName, int timeOut = 10000)
        {
            bool disabled = false;
            int timeElapsed = 0;
            int timeWait = 100;
            var locker = new object();


            return Task.Run(() =>
            {
                ExecuteWaitProcess("netsh", "interface set interface \"" + interfaceName + "\" disable");

                do
                {
                    lock (locker) disabled = IsAdpapterDisabled(interfaceName);
                    Thread.Sleep(timeWait);
                    lock (locker) timeElapsed += timeWait;

                } while (!disabled && timeElapsed < timeOut);
                return disabled;
            });
        }



        public static bool IsAdpapterEnabled(string interfaceName)
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface selectedInterface = networkInterfaces.FirstOrDefault(n => n.Name == interfaceName);
            if (selectedInterface == null)
            {
                return false;
            }
            return selectedInterface.OperationalStatus == OperationalStatus.Up;
        }

        public static bool IsAdpapterDisabled(string interfaceName)
        {
            var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface selectedInterface = networkInterfaces.FirstOrDefault(n => n.Name == interfaceName);
            if (selectedInterface == null)
            {
                return true;
            }
            return selectedInterface.OperationalStatus != OperationalStatus.Up;
        }
    }
}