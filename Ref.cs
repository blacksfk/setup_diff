namespace SetupDiff {
	// Represents a reference point for a setup value.
	// Eg.: Pressure minimum = 20.3, therefore:
	// min = 203, factor = 10, increment = 1
	public class Ref {
		public int Min {get;set;} = 0;
		public int Fac {get;set;} = 1;
		public int Inc {get;set;} = 1;

		// Create a setting from this reference point.
		public Setting Apply(int offset) {
			int val = this.Min + offset * this.Inc;
			string str = string.Empty;

			if (this.Fac == 1) {
				str = val.ToString();
			} else {
				str = (val / (double) this.Fac).ToString();
			}

			return new Setting(offset, str);
		}
	}
}
