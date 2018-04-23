// Developer Express Code Central Example:
// How to show check boxes near nodes and check child nodes when a parent node is checked
// 
// Modify our template to add the check edit near a node. Handle checked/unchecked
// events of this check edit and iterate via nodes to check/uncheck child nodes.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3466

using System.Windows;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.TreeList;

namespace HierarchicalDataBinding {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

        }
        private void CheckEdit_Checked(object sender, RoutedEventArgs e) {
            CheckEdit checkEdit = (sender as CheckEdit);
            if(checkEdit == null) return;
            CheckChildrenNodes((checkEdit.DataContext as TreeListRowData).Node, true);
        }

        private void CheckEdit_Unchecked(object sender, RoutedEventArgs e) {
            CheckEdit checkEdit = (sender as CheckEdit);
            if(checkEdit == null) return;
            CheckChildrenNodes((checkEdit.DataContext as TreeListRowData).Node, false);
        }

        private void CheckChildrenNodes(TreeListNode treeListNode, bool p) {
            foreach(TreeListNode node in new TreeListNodeIterator(treeListNode))
                (node.Content as BaseObject).Checked = p;
        }
    }
}