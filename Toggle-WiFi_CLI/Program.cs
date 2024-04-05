// See https://aka.ms/new-console-template for more information
using Toggle_WiFi;



var wifi = NetworkAdapterUtil.IsAdpapterEnabled("Wi-Fi");
var ethernet = NetworkAdapterUtil.IsAdpapterEnabled("Ethernet");



if (wifi)
{
    var enable_tsk = NetworkAdapterUtil.EnableAdapterAsync("Ethernet");
    enable_tsk.Wait();
    var disable_tsk = NetworkAdapterUtil.DisableAdapterAsync("Wi-Fi");
    disable_tsk.Wait();
}
else
{
    var enable_tsk = NetworkAdapterUtil.EnableAdapterAsync("Wi-Fi");
    enable_tsk.Wait();
    var disable_tsk = NetworkAdapterUtil.DisableAdapterAsync("Ethernet");
    disable_tsk.Wait();
}

