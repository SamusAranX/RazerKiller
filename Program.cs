using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RazerKiller {
	internal static class Program {
		private static void Main(string[] args) {
			Console.Write($"[{DateTime.Now.ToLongTimeString()}] Starting ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("Razer");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Killer");
			Console.ResetColor();
			Console.WriteLine("...");

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