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
using System.Collections.Generic;
using System.Data.Linq;
using System.Collections.ObjectModel;

namespace HierarchicalDataBinding {

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

        }

        bool IsCheckHandled = false;

        private void CheckEdit_Checked(object sender, RoutedEventArgs e) {
            if(IsCheckHandled) {
                return;
            }
            IsCheckHandled = true;
            CheckEdit checkEdit = (sender as CheckEdit);
            if(checkEdit == null) return;
            CheckChildrenNodes((checkEdit.DataContext as TreeListRowData).Node, true);
            IsCheckHandled = false;
        }


        public void CorrectParent(TreeListNode node) {
            IEnumerable<BaseObject> items = null;
            
            if(node.Content is ProjectObject) {
                items = (node.Content as ProjectObject).Stages;
            } else if(node.Content is ProjectStage) {
                items = (node.Content as ProjectStage).Tasks;
            }

            bool? result = (node.Content as BaseObject).Checked;
            var iterator = items.GetEnumerator();
            if(iterator.MoveNext()) {
                result = iterator.Current.Checked;
                while(iterator.MoveNext()) {
                    if(result != iterator.Current.Checked) {
                        result = null;
                        break;
                    }
                }
            }
            

            (node.Content as BaseObject).Checked = result;
            if(node.ParentNode != null) {
                this.CorrectParent(node.ParentNode);
            }
        }
        
    
        private void CheckEdit_Unchecked(object sender, RoutedEventArgs e) {
            if(IsCheckHandled) {
                return;
            }
            IsCheckHandled = true;
            CheckEdit checkEdit = (sender as CheckEdit);
            if(checkEdit == null) return;
            CheckChildrenNodes((checkEdit.DataContext as TreeListRowData).Node, false);
            IsCheckHandled = false;
        }

        protected void SetProjectObject(ProjectObject projectObject, bool p) {
            foreach(var item in (projectObject as ProjectObject).Stages) {
                item.Checked = p;
                this.SetProjectStage(item, p);
            }
        }

        protected void SetProjectStage(ProjectStage projectStage, bool p) {
            foreach(var item in projectStage.Tasks) {
                item.Checked = p;
            }
        }

        private void CheckChildrenNodes(TreeListNode treeListNode, bool p) {
            var obj = treeListNode.Content;
            if(obj is ProjectObject) {
                this.SetProjectObject(obj as ProjectObject, p);
            } else if(obj is ProjectStage) {
                this.SetProjectStage(obj as ProjectStage, p);
            } else {
                (obj as Task).Checked = p;
            }
            if(treeListNode.ParentNode != null) {
                this.CorrectParent(treeListNode.ParentNode);
            }
        }
    }
}