using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace SetupDiff {
	public partial class SetupCollectionHeader {
		public static readonly DependencyProperty ValsProp =
			DependencyProperty.Register(
				"Values",
				typeof (ObservableCollection<string>),
				typeof (SetupCollectionHeader),
				new FrameworkPropertyMetadata(
					new ObservableCollection<string>()));

		public SetupCollectionHeader() {
			this.InitializeComponent();
			this.sp.DataContext = this;
		}

		public ObservableCollection<string> Values {
			get {
				return (ObservableCollection<string>) GetValue(ValsProp);
			}
			set {
				SetValue(ValsProp, value);
			}
		}
	}
}
