using System;

namespace SetupDiff {
	// Reference base class. Sub-classes must implement Apply().
	public abstract class Reference {
		public int Fac {get;set;} = 1;

		protected string factorString(int val) {
			string str;

			if (this.Fac == 1) {
				str = val.ToString();
			} else {
				str = (val / (double) this.Fac).ToString();
			}

			return str;
		}

		public abstract Setting Apply(int offset);
	}

	// Represents an individual point from which to calculate the
	// actual value.
	public class ReferencePoint : Reference {
		public int Min {get;set;} = 0;
		public int Inc {get;set;} = 1;

		public override Setting Apply(int offset) {
			int val = this.Min + offset * this.Inc;

			return new Setting(offset, this.factorString(val));
		}
	}

	// Represents a list of actual values and the offset is used
	// as the index.
	public class ReferenceList : Reference {
		// default to one element
		public int[] Vals {get;set;} = new int[1];

		public override Setting Apply(int offset) {
			int len = this.Vals.Length;

			if (offset < 0 || offset >= len) {
				throw new Exception(string.Format(
					"Offset: {0} is out of bounds for list length: {1}.",
					offset, len));
			}

			int val = this.Vals[offset];

			return new Setting(offset, this.factorString(val));
		}
	}
}
