using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core.Native;

namespace Sample {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window {
        List<TestData> list;
        public Window1() {
            InitializeComponent();
            list = new List<TestData>();
            list.Add(new TestData() { Number = 1, Text = "row1" });
            list.Add(new TestData() { Number = 2, Text = "row2" });
            list.Add(new TestData() { Number = 3, Text = "row3" });
            list.Add(new TestData() { Number = 1, Text = "row4" });
            list.Add(new TestData() { Number = 2, Text = "row5" });
            list.Add(new TestData() { Number = 3, Text = "row6" });
            list.Add(new TestData() { Number = 1, Text = "row7" });
            list.Add(new TestData() { Number = 2, Text = "row8" });
            list.Add(new TestData() { Number = 3, Text = "row9" });
            list.Add(new TestData() { Number = 1, Text = "row10" });
            list.Add(new TestData() { Number = 2, Text = "row11" });
            list.Add(new TestData() { Number = 3, Text = "row12" });
            grid.DataSource = list;
        }

        IScrollInfo GetScrollInfo() {
            foreach (DependencyObject item in new VisualTreeEnumerable(view)) {
                if (item is DataPresenter)
                    return (DataPresenter)item;
            }
            throw new InvalidOperationException();
        }

        private void view_ScrollChanged(object sender, ScrollChangedEventArgs e) {
            int RowHandle = grid.GetRowHandleByVisibleIndex(Convert.ToInt32(GetScrollInfo().VerticalOffset));
            TestData td = grid.GetRow(RowHandle) as TestData;
            textEdit1.Text = td.Text;
        }
    }
    public class TestData {
        public int Number { get; set; }
        public string Text { get; set; }
    }
}
