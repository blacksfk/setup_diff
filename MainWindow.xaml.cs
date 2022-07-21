using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.Generic;

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
		private SetupCollection setups;

		public MainWindow(List<CarNode> tree, List<Car> cars) {
			this.tree = tree;
			this.cars = cars;
			this.setups = new SetupCollection();
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

		public SetupCollection Setups {
			get {
				return this.setups;
			}
		}

		// TreeView setup node click event handler. Adds the clicked
		// setup to the collection for comparison.
		private void addSetup(object sender, MouseButtonEventArgs args) {
			if (args.ClickCount < 2) {
				// double clicks only please
				return;
			}

			// assert the sender as a SetupTreeNode and try to load the setup
			SetupNode sn = ((SetupTreeNode) sender).SetupNode;
			Setup setup;

			try {
				setup = Setup.FromFile(sn.Path, sn.LastWriteTime);
			} catch (Exception ex) {
				MessageBox.Show(string.Format("Could not load setup: {0}", ex.Message));

				return;
			}

			// match the setup to a known car
			Car? car = null;

			foreach (Car c in this.cars) {
				if (c.ID == setup.CarName) {
					car = c;
					break;
				}
			}

			if (car == null) {
				// car not found
				MessageBox.Show(string.Format(
					"Car: {0} is not currently supported", setup.CarName));

				return;
			}

			// add it to the collection
			try {
				this.setups.Append(setup, car);
			} catch (Exception ex) {
				MessageBox.Show(string.Format(
					"Could not append setup: {0}", ex.Message));
			}
		}

		// RemoveSetup command handler. Expects the setup ID to be stored
		// as a string in the args' Parameter property.
		private void removeSetupExecuted(object sender, ExecutedRoutedEventArgs e) {
			string id = (string) e.Parameter;

			if (!this.setups.Remove(id)) {
				MessageBox.Show(string.Format(
					"Could not remove setup {0} from comparison table", id));
			}
		}
	}
}
