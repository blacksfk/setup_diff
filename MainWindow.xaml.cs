using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SetupDiff {
	public partial class MainWindow : Window {
		// heirachy of directories and setup files in following structure:
		// -> car dir
		// 		-> track dir
		// 			-> setup file (JSON)
		// 			-> setup file (JSON)
		// 		-> track dir
		// 		...
		// -> car dir
		// etc.
		private List<CarNode> tree;

		// known cars (and their setup minimums)
		private List<Car> cars;

		// setups being compared
		private ObservableCollection<Setup> setups;

		public MainWindow(List<CarNode> tree, List<Car> cars) {
			this.tree = tree;
			this.cars = cars;
			this.setups = new ObservableCollection<Setup>();
			this.InitializeComponent();

			// DataContext defaults to null so bind it to this instance
			// in order to make use of its properties
			this.DataContext = this;
		}

		public List<CarNode> Tree {
			get {
				return this.tree;
			}
		}

		public ObservableCollection<Setup> Setups {
			get {
				return this.setups;
			}
		}
	}
}
