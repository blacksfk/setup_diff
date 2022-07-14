namespace SetupDiff {
	// Represents a setup item's value.
	public class Setting {
		// Number of clicks away from the minimum.
		private int offset;

		// The actual calculated value (as shown in the game).
		private string val;

		public Setting(int offset, string val) {
			this.offset = offset;
			this.val = val;
		}

		public string Value {
			get {
				return this.val;
			}
		}

		// Compare this setting against another. Returns false if they're
		// identical and true otherwise. I.e. there's difference between
		// the values if true is returned.
		public bool Diff(Setting s) {
			return this.offset != s.offset;
		}
	}
}
