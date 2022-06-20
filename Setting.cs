namespace SetupDiff {
	// Represents a setup item's value.
	public class Setting<T> {
		// Clicks away from the minimum.
		private int offset;

		// The actual calculated value (as shown in the game).
		private T val;

		public Setting(int offset, T val) {
			this.offset = offset;
			this.val = val;
		}

		public T Value {
			get {
				return this.val;
			}
		}

		// Compare this setting against another. Returns false
		// if they're identical and true otherwise.
		public bool Diff(Setting<T> s) {
			return this.offset != s.offset;
		}
	}
}
