

namespace Toggle_WiFi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var form = new StatusForm();
            var wifi = NetworkAdapterUtil.IsAdpapterEnabled("Wi-Fi");
            var ethernet = NetworkAdapterUtil.IsAdpapterEnabled("Ethernet");

            if (wifi)
            {
                form.TextOut.Text = "Switiching From Wi-Fi to Ethernet...";
                form.Show();
                var enable_tsk = NetworkAdapterUtil.EnableAdapterAsync("Ethernet");
                enable_tsk.Wait();
            }
            else
            {
                form.TextOut.Text = "Switiching From Ethernet to Wi-Fi...";
                form.Show();
                var disable_tsk = NetworkAdapterUtil.DisableAdapterAsync("Ethernet");
                disable_tsk.Wait();
            }

            form.Hide();


        }
    }
}