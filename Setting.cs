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

		// Compare this setting against another. Returns:
		// < 0 if this setting is less than the provided
		// > 0 if this setting is greater than the provided
		// 0 if they're identical
		public int Diff(Setting s) {
			return this.offset - s.offset;
		}
	}
}
