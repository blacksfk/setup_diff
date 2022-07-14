using System.Windows;
using System.Windows.Controls;

namespace SetupDiff {
	// Custom control to store both the file name and path,
	// but only display the name.
	public partial class SetupTreeNode : UserControl {
		public static readonly DependencyProperty FNProp =
			DependencyProperty.Register(
				"FileName",
				typeof (string),
				typeof (SetupTreeNode),
				new FrameworkPropertyMetadata(
					string.Empty));

		public static readonly DependencyProperty FPProp =
			DependencyProperty.Register(
				"FilePath",
				typeof (string),
				typeof (SetupTreeNode),
				new FrameworkPropertyMetadata(
					string.Empty));

		public SetupTreeNode() {
			this.InitializeComponent();
			this.TB.DataContext = this;
		}

		public string FileName {
			get {
				return (string) GetValue(FNProp);
			}
			set {
				SetValue(FNProp, value);
			}
		}

		public string FilePath {
			get {
				return (string) GetValue(FPProp);
			}
			set {
				SetValue(FPProp, value);
			}
		}
	}
}
