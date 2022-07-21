using System;
using System.Windows;
using System.Windows.Controls;

namespace SetupDiff {
	// Custom control to store both the file name and path,
	// but only display the name.
	public partial class SetupTreeNode : UserControl {
		public static readonly DependencyProperty NodeProp =
			DependencyProperty.Register(
				"SetupNode",
				typeof (SetupNode),
				typeof (SetupTreeNode),
				new FrameworkPropertyMetadata(
					new SetupNode("", "", new DateTime(DateTime.MinValue.Ticks))
				)
			);

		public SetupTreeNode() {
			this.InitializeComponent();
			this.sp.DataContext = this;
		}

		public SetupNode SetupNode {
			get {
				return (SetupNode) GetValue(NodeProp);
			}
			set {
				SetValue(NodeProp, value);
			}
		}
	}
}
