namespace SetupDiff {
	// Represents a setup file.
	public class Setup {
		private string name;
		private string path;

		public Setup(string name, string path) {
			this.name = name;
			this.path = path;
		}

		// Setup file name.
		public string Name {
			get {
				return this.name;
			}
		}

		// Absolute path to setup file.
		public string Path {
			get {
				return this.path;
			}
		}
	}
}
