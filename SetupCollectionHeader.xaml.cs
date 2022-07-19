using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace SetupDiff {
	public partial class SetupCollectionHeader {
		public static readonly DependencyProperty ValsProp =
			DependencyProperty.Register(
				"Values",
				typeof (ObservableCollection<ColumnHeader>),
				typeof (SetupCollectionHeader),
				new FrameworkPropertyMetadata(
					new ObservableCollection<ColumnHeader>()));

		public SetupCollectionHeader() {
			this.InitializeComponent();
			this.sp.DataContext = this;
		}

		public ObservableCollection<ColumnHeader> Values {
			get {
				return (ObservableCollection<ColumnHeader>) GetValue(ValsProp);
			}
			set {
				SetValue(ValsProp, value);
			}
		}
	}
}
