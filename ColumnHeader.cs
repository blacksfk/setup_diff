using System;

namespace SetupDiff {
	// Represents the information to be displayed as the column header.
	public class ColumnHeader {
		private string id;
		private string car;
		private string setup;
		private DateTime lwt;

		public ColumnHeader(string id, string car, string setup, DateTime lastWriteTime) {
			this.id = id;
			this.car = car;
			this.setup = setup;
			this.lwt = lastWriteTime;
		}

		// Unique ID.
		public string Id {
			get {
				return this.id;
			}
		}

		// Car name.
		public string Car {
			get {
				return this.car;
			}
		}

		// Setup file name.
		public string Setup {
			get {
				return this.setup;
			}
		}

		// Last modified time.
		public DateTime LastWriteTime {
			get {
				return this.lwt;
			}
		}
	}
}
