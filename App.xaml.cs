using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows;

namespace SetupDiff {
	public partial class App : Application {
		// default file is in the working directory of the executable
		private static string CARS_FILE = "cars.json";

		public App() {
			this.InitializeComponent();
		}

		// Main method. A path that can be understood by the System.IO.File
		// class can be provided as a command line argument to point this
		// program to a custom cars file. Otherwise, the program will
		// default to using CARS_FILE instead.
		[STAThread]
		public static void Main(string[] args) {
			string path = CARS_FILE;

			if (args.Length > 0) {
				// use file specified in arguments
				path = args[0];
			}

			List<Car> cars;
			List<CarNode> tree;

			try {
				// load the cars configuration file
				cars = loadCars(path);
			} catch (Exception ex) {
				// failed locating or parsing the JSON cars file
				string output = String.Format("Could not load {0}: {1}",
					path, ex.Message);

				MessageBox.Show(output);

				return;
			}

			try {
				// load the directories into the tree
				tree = loadDirTree(cars);
			} catch (Exception ex) {
				string output = String.Format("Could not load setups: {0}",
					ex.Message);

				MessageBox.Show(output);

				return;
			}

			// create a new instance of the application and main window
			App app = new App();
			MainWindow wnd = new MainWindow(tree, cars);

			// anchors aweigh!
			app.Run(wnd);
		}

		// Load cars and their respective setup minimums from the given file.
		// An empty file throws an exception.
		private static List<Car> loadCars(string path) {
			var options = new JsonSerializerOptions() {
				// why isn't this the default??
				PropertyNameCaseInsensitive = true
			};

			// read the contents of the cars file into a string
			// and de-serialise it into a list of cars
			string raw = File.ReadAllText(path);
			List<Car>? cars = JsonSerializer.Deserialize<List<Car>>(raw, options);

			if (cars == null) {
				throw new Exception(string.Format("{0} is empty!", path));
			}

			return cars;
		}

		// Find a car in the list matching by ID. Returns null
		// if no match was found.
		private static Car? findCar(List<Car> cars, string id) {
			foreach (Car car in cars) {
				if (car.ID == id) {
					return car;
				}
			}

			return null;
		}

		// Load the directory tree of cars, tracks, and setup files.
		private static List<CarNode> loadDirTree(List<Car> cars) {
			List<CarNode> tree = new List<CarNode>();

			// this shouldn't ever need to be dynamic so just hard
			// code the path to the Setups directory
			string root = Path.Join(
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				"Assetto Corsa Competizione",
				"Setups"
			);

			// car sub-directories in ...\ACC\Setups
			var carDirs = new List<string>(Directory.EnumerateDirectories(root));

			foreach (var cd in carDirs) {
				// get the final directory name without the path and use it
				// to match to known car
				string id = Path.GetFileName(cd);
				var car = findCar(cars, id);

				if (car == null) {
					// unknown car; set as unsupported
					tree.Add(new CarNode(id, true));
					continue;
				}

				// car found
				var cn = new CarNode(car.Name);

				// get a list of track sub-directories
				var trackDirs = new List<string>(Directory.EnumerateDirectories(cd));
				var tracks = cn.Children;

				foreach (var td in trackDirs) {
					// extract the final directory name from the path
					// and use it as the track name
					var tn = new TrackNode(Path.GetFileName(td));

					// get a list of json files
					var files = new List<string>(Directory.EnumerateFiles(td, "*.json"));
					var setups = tn.Children;

					foreach (var file in files) {
						// append the setup to the track.
						// same deal with the file name
						setups.Add(new SetupNode(Path.GetFileName(file), file));
					}

					if (setups.Count > 0) {
						// only append the track if it contains
						// at least one setup
						tracks.Add(tn);
					}
				}

				if (tracks.Count > 0) {
					// only append the car node if it contains at least one
					// track with at least one setup
					tree.Add(cn);
				}
			}

			return tree;
		}
	}
}
