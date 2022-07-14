namespace SetupDiff {
	// Represents a reference point for a setup value.
	// Eg.: Pressure minimum = 20.3, therefore:
	// start = 203, factor = 10, increment = 1
	public class Ref {
		public int Start {get;set;} = 0;
		public int Factor {get;set;} = 1;
		public int Increment {get;set;} = 1;

		// Create a setting from this reference point.
		public Setting Apply(int offset) {
			int val = this.Start + offset * this.Increment;
			string str = string.Empty;

			if (this.Factor == 1) {
				str = val.ToString();
			} else {
				str = (val / this.Factor).ToString("N2");
			}

			return new Setting(offset, str);
		}
	}
}
