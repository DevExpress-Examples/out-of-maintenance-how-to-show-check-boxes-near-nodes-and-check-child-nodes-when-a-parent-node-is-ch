' Developer Express Code Central Example:
' How to show check boxes near nodes and check child nodes when a parent node is checked
' 
' Modify our template to add the check edit near a node. Handle checked/unchecked
' events of this check edit and iterate via nodes to check/uncheck child nodes.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3466

Imports System.Windows
Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Grid.TreeList

Namespace HierarchicalDataBinding

    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

        End Sub
        Private Sub CheckEdit_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim checkEdit As CheckEdit = (TryCast(sender, CheckEdit))
            If checkEdit Is Nothing Then
                Return
            End If
            CheckChildrenNodes((TryCast(checkEdit.DataContext, TreeListRowData)).Node, True)
        End Sub

        Private Sub CheckEdit_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim checkEdit As CheckEdit = (TryCast(sender, CheckEdit))
            If checkEdit Is Nothing Then
                Return
            End If
            CheckChildrenNodes((TryCast(checkEdit.DataContext, TreeListRowData)).Node, False)
        End Sub

        Private Sub CheckChildrenNodes(ByVal treeListNode As TreeListNode, ByVal p As Boolean)
            For Each node As TreeListNode In New TreeListNodeIterator(treeListNode)
                TryCast(node.Content, BaseObject).Checked = p
            Next node
        End Sub
    End Class
End Namespace