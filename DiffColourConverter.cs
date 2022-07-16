using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace SetupDiff {
	// Converts between the result of Setting.Diff and pre-defined colours.
	public class DiffColourConverter : IMultiValueConverter {
		private static Color ABOVE = (Color) ColorConverter.ConvertFromString("#1dad41");
		private static Color BELOW = (Color) ColorConverter.ConvertFromString("#e02f2f");

		// The second element of rawVals is expected to be the primary setting. I.e.
		// the setting that is in the first column.
		public object Convert(object[] rawVals, Type type, object param, CultureInfo ci) {
			// cast the raw values as settings
			Setting setting = (Setting) rawVals[0];
			Setting primary = (Setting) rawVals[1];

			// create a brush and get the result of the diff
			SolidColorBrush brush = new SolidColorBrush(SystemColors.WindowTextColor);
			int diff = setting.Diff(primary);

			if (diff > 0) {
				brush.Color = ABOVE;
			} else if (diff < 0) {
				brush.Color = BELOW;
			}

			return brush;
		}

		public object[] ConvertBack(object raw, Type[] types, object param, CultureInfo ci) {
			throw new NotImplementedException();
		}
	}
}
