
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Management;
namespace _5700BIOS刷写工具
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in objvide.Get())
            {
                System.Console.WriteLine("Name - " + obj["Name"] + "</br>");
                System.Console.WriteLine("DeviceID - " + obj["DeviceID"] + "</br>");
                System.Console.WriteLine("AdapterRAM - " + obj["AdapterRAM"] + "</br>");
                System.Console.WriteLine("AdapterDACType - " + obj["AdapterDACType"] + "</br>");
                System.Console.WriteLine("Monochrome - " + obj["Monochrome"] + "</br>");
                System.Console.WriteLine("InstalledDisplayDrivers - " + obj["InstalledDisplayDrivers"] + "</br>");
                System.Console.WriteLine("DriverVersion - " + obj["DriverVersion"] + "</br>");
                System.Console.WriteLine("VideoProcessor - " + obj["VideoProcessor"] + "</br>");
                System.Console.WriteLine("VideoArchitecture - " + obj["VideoArchitecture"] + "</br>");
                System.Console.WriteLine("VideoMemoryType - " + obj["VideoMemoryType"] + "</br>");
            }
            InitializeComponent();
            Process p = new Process();

            string dir = System.AppDomain.CurrentDomain.BaseDirectory;
            MessageBox.Show(dir);
            //设置要启动的应用程序
            p.StartInfo.FileName = "cmd.exe";
            //是否使用操作系统shell启动
            p.StartInfo.UseShellExecute = false;
            // 接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardInput = true;
            //输出信息
            p.StartInfo.RedirectStandardOutput = true;
            // 输出错误
            p.StartInfo.RedirectStandardError = true;
            //不显示程序窗口
            p.StartInfo.CreateNoWindow = true;
            //启动程序
            p.Start();

            p.StandardInput.WriteLine( "amdvbflash.exe -i");


            //获取输出信息
            string strOuput = p.StandardOutput.ReadToEnd();

            MessageBox.Show(strOuput);

            //等待程序执行完退出进程
            p.WaitForExit();
            p.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}