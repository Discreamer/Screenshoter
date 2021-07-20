using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
namespace Program{
	class Program{
			[DllImport("kernel32.dll")]
			static extern bool FreeConsole();
		static void Screenshot(string Path,string Name,bool DoPath){
			Bitmap prtscr=new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			Graphics graph=Graphics.FromImage(prtscr as Image);
			graph.CopyFromScreen(0,0,0,0, prtscr.Size);
			DirectoryInfo fCreate = new DirectoryInfo(Path);
			if (DoPath){
				Path=Path+"/"+Name[0]+Name[1]+Name[2]+Name[3]+"/"+Name[5]+Name[6]+"/"+Name[8]+Name[9];
				fCreate = new DirectoryInfo(Path);
			}
			if (!fCreate.Exists){
				fCreate.Create();
			}
			prtscr.Save(Path+"//"+Name+".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
		}
		static void Main(string[] args){
			FreeConsole();
			string path="C:/Screenshots";
			int FPS=60;
			int Count=0;
			FPS+=1;
			for (;;){
				DateTime date=DateTime.Now;
				string Name=date.ToString("yyyy-MM-dd hh-mm-ss");
				Count++;
				Screenshot(path,Name,true);
				Thread.Sleep(FPS*1000);
			}
		}
	}
}
