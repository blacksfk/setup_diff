﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SetupDiff {
	public partial class App : Application {
		public App() {
			this.InitializeComponent();
		}

		[STAThread]
		public static void Main(string[] args) {
			App app = new App();
			MainWindow wnd = new MainWindow();

			app.Run(wnd);
		}
	}
}
