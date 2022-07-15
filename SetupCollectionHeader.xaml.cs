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

		public static readonly DependencyProperty CellWidthProp =
			DependencyProperty.Register(
				"CellWidth",
				typeof (int),
				typeof (SetupCollectionHeader),
				new FrameworkPropertyMetadata(
					200));

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

		public int CellWidth {
			get {
				return (int) GetValue(CellWidthProp);
			}
			set {
				SetValue(CellWidthProp, value);
			}
		}
	}
}
