namespace SetupDiff {
	// Represents a directory. In this case either a car or circuit directory.
	public class Dir {
		// Name of the directory.
		private string name;

		// List of sub-directories within the directory.
		private List<Dir> subdirs;

		// List of files within the directory.
		private List<File> files;

		public Dir(string name) {
			this.name = name;
			this.subdirs = new List<Dir>();
			this.files = new List<File>();
		}

		public string Name {
			get {
				return this.name;
			}
		}

		public List<Dir> Subdirs {
			get {
				return this.subdirs;
			}
		}

		public List<File> Files {
			get {
				return this.files;
			}
		}
	}
}
