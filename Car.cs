using System.Collections.Generic;

namespace SetupDiff {
	// Represents a Car directory.
	public class Car {
		private string id;
		private string name;
		private List<Track> tracks;

		// Provide the car ID to match it to a known car.
		public Car(string id) {
			this.id = id;
			this.tracks = new List<Track>();
		}

		// Car ID.
		public string Id {
			get {
				return this.id;
			}
		}

		// Known car name.
		public string Name {
			get {
				return this.name;
			}
		}

		// Track directories present.
		public List<Track> Tracks {
			get {
				return this.tracks;
			}
		}

		// Add a track directory to the track directory list.
		public void AddTrack(Track track) {
			this.tracks.Add(track);
		}
	}
}
