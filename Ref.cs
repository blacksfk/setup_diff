namespace SetupDiff {
	// Represents a reference point for a setup value.
	// Eg.: Pressure minimum = 20.3, therefore:
	// start = 203, factor = 10, increment = 1
	public class Ref {
		public int Start {get;set;} = 0;
		public int Factor {get;set;} = 1;
		public int Increment {get;set;} = 1;

		public int Calculate(int offset) {
			return this.Start + offset * this.Increment;
		}

		public float CalculateFloat(int offset) {
			return this.Calculate(offset) / (float) this.Factor;
		}
	}
}
