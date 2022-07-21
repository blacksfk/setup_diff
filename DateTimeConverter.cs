using System;
using System.Windows.Data;
using System.Globalization;

namespace SetupDiff {
	// Converts a datetime to the culture-specific representation.
	public class DateTimeConverter : IValueConverter {
		public object Convert(object raw, Type type, object param, CultureInfo ci) {
			// cast raw as a datetime
			DateTime dt = (DateTime) raw;

			// apply the current culture's datetime formatting
			// g: dd MM yyyy HH:mm
			return dt.ToString("g");
		}

		public object ConvertBack(object raw, Type type, object param, CultureInfo ci) {
			throw new NotImplementedException();
		}
	}
}
