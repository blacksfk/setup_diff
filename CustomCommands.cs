using System.Windows.Input;

namespace SetupDiff {
	public static class CustomCommands {
		public static readonly RoutedUICommand RemoveSetup =
			new RoutedUICommand(
				"RemoveSetup", "RemoveSetup", typeof (CustomCommands));
	}
}
