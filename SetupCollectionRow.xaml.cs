using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace SetupDiff {
	public partial class SetupCollectionRow : UserControl {
		public static readonly DependencyProperty HeaderProp =
			DependencyProperty.Register(
				"Header",
				typeof (string),
				typeof (SetupCollectionRow),
				new FrameworkPropertyMetadata(
					string.Empty));

		public static readonly DependencyProperty ValsProp =
			DependencyProperty.Register(
				"Values",
				typeof (ObservableCollection<Setting>),
				typeof (SetupCollectionRow),
				new FrameworkPropertyMetadata(
					new ObservableCollection<Setting>()));

		public SetupCollectionRow() {
			this.InitializeComponent();
			this.sp.DataContext = this;
		}

		public string Header {
			get {
				return (string) GetValue(HeaderProp);
			}
			set {
				SetValue(HeaderProp, value);
			}
		}

		public ObservableCollection<Setting> Values {
			get {
				return (ObservableCollection<Setting>) GetValue(ValsProp);
			}
			set {
				SetValue(ValsProp, value);
			}
		}
	}
}
