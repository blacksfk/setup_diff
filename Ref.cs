namespace SetupDiff {
	// Represents a reference point for a setup value.
	// Eg.: Pressure minimum = 20.3, therefore:
	// start = 203, factor = 10, increment = 1
	public class Ref {
		private int start = 0;
		private int factor = 1;
		private int increment = 1;

		public Ref() {}

		public Ref(int start) {
			this.start = start;
		}

		public Ref(int start, int factor) : this(start) {
			this.factor = factor;
		}

		public Ref(int start, int factor, int inc) : this(start, factor) {
			this.increment = inc;
		}

		public int Calculate(int offset) {
			return this.start + offset * this.increment;
		}

		public float CalculateFloat(int offset) {
			return this.Calculate(offset) / (float) this.factor;
		}
	}
}
