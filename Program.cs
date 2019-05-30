using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace RazerKiller {
	internal static class Program {

		private static void Main(string[] args) {
			Console.Write($"[{DateTime.Now.ToLongTimeString()}] Starting ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("Razer");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Killer ");
			Console.ResetColor();

			var versionString = Assembly.GetExecutingAssembly().GetName().Version.ToString().TrimEnd('0', '.');
			Console.Write($"v{versionString}");
			Console.WriteLine("...");

			WinApi.ShowWindow(Process.GetCurrentProcess().MainWindowHandle, WinApi.SW_MINIMIZE);

			while (true) {
				var gameManagerProcesses = Process.GetProcessesByName("GameManagerService");
				foreach (var process in gameManagerProcesses) {
					process.Kill();
				}

				if (gameManagerProcesses.Length > 0) {
					var plural = gameManagerProcesses.Length == 1 ? "process" : "processes";
					Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] Killed {gameManagerProcesses.Length} {plural}");
				}

				Thread.Sleep(500);
			}
		}
	}
}