$wifi = (Get-NetAdapter -Name "Wi-Fi").Status
$ethernet = (Get-NetAdapter -Name "Ethernet").Status
if($ethernet -eq "Up")
{
    Enable-NetAdapter -Name "Wi-Fi"
    Start-Sleep -Milliseconds 100
    Disable-NetAdapter -Name "Ethernet" -Confirm:$false

}
elseif ($wifi -eq "Up") 
{
    Enable-NetAdapter -Name "Ethernet"
    Disable-NetAdapter -Name "Wi-Fi" -Confirm:$false
}