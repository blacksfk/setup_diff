using System.Collections.Generic;

namespace SetupDiff {
	// Represents a track directory.
	public class Track {
		private string name;
		public List<Setup> setups;

		public Track(string name) {
			this.name = name;
			this.setups = new List<Setup>();
		}

		// Track name.
		public string Name {
			get {
				return this.name;
			}
		}

		// List of setup files.
		public List<Setup> Setups {
			get {
				return this.setups;
			}
		}
	}
}
