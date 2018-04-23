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
Imports System.Collections.Generic
Imports System.Data.Linq
Imports System.Collections.ObjectModel

Namespace HierarchicalDataBinding

    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

        End Sub

        Private IsCheckHandled As Boolean = False

        Private Sub CheckEdit_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If IsCheckHandled Then
                Return
            End If
            IsCheckHandled = True
            Dim checkEdit As CheckEdit = (TryCast(sender, CheckEdit))
            If checkEdit Is Nothing Then
                Return
            End If
            CheckChildrenNodes((TryCast(checkEdit.DataContext, TreeListRowData)).Node, True)
            IsCheckHandled = False
        End Sub


        Public Sub CorrectParent(ByVal node As TreeListNode)
            Dim items As IEnumerable(Of BaseObject) = Nothing

            If TypeOf node.Content Is ProjectObject Then
                items = (TryCast(node.Content, ProjectObject)).Stages
            ElseIf TypeOf node.Content Is ProjectStage Then
                items = (TryCast(node.Content, ProjectStage)).Tasks
            End If

            Dim result? As Boolean = (TryCast(node.Content, BaseObject)).Checked
            Dim [iterator] = items.GetEnumerator()
            If [iterator].MoveNext() Then
                result = [iterator].Current.Checked
                Do While [iterator].MoveNext()
                    If Not result.Equals([iterator].Current.Checked) Then
                        result = Nothing
                        Exit Do
                    End If
                Loop
            End If


            TryCast(node.Content, BaseObject).Checked = result
            If node.ParentNode IsNot Nothing Then
                Me.CorrectParent(node.ParentNode)
            End If
        End Sub


        Private Sub CheckEdit_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If IsCheckHandled Then
                Return
            End If
            IsCheckHandled = True
            Dim checkEdit As CheckEdit = (TryCast(sender, CheckEdit))
            If checkEdit Is Nothing Then
                Return
            End If
            CheckChildrenNodes((TryCast(checkEdit.DataContext, TreeListRowData)).Node, False)
            IsCheckHandled = False
        End Sub

        Protected Sub SetProjectObject(ByVal projectObject As ProjectObject, ByVal p As Boolean)
            For Each item In (TryCast(projectObject, ProjectObject)).Stages
                item.Checked = p
                Me.SetProjectStage(item, p)
            Next item
        End Sub

        Protected Sub SetProjectStage(ByVal projectStage As ProjectStage, ByVal p As Boolean)
            For Each item In projectStage.Tasks
                item.Checked = p
            Next item
        End Sub

        Private Sub CheckChildrenNodes(ByVal treeListNode As TreeListNode, ByVal p As Boolean)
            Dim obj = treeListNode.Content
            If TypeOf obj Is ProjectObject Then
                Me.SetProjectObject(TryCast(obj, ProjectObject), p)
            ElseIf TypeOf obj Is ProjectStage Then
                Me.SetProjectStage(TryCast(obj, ProjectStage), p)
            Else
                TryCast(obj, Task).Checked = p
            End If
            If treeListNode.ParentNode IsNot Nothing Then
                Me.CorrectParent(treeListNode.ParentNode)
            End If
        End Sub
    End Class
End Namespace