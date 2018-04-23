' Developer Express Code Central Example:
' How to show check boxes near nodes and check child nodes when a parent node is checked
' 
' Modify our template to add the check edit near a node. Handle checked/unchecked
' events of this check edit and iterate via nodes to check/uncheck child nodes.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3466

Imports System
Imports System.Collections.ObjectModel
Imports System.Collections
Imports DevExpress.Xpf.Grid

Namespace HierarchicalDataBinding
    Public Class ViewModel
        Public Property DataItems() As ObservableCollection(Of ProjectObject)

        Public Sub New()
            DataItems = InitData()
        End Sub

        Private Function InitData() As ObservableCollection(Of ProjectObject)
            Dim projects As New ObservableCollection(Of ProjectObject)()
            Dim betaronProject As New ProjectObject() With {.Name = "Project: Betaron", .Stages = New ObservableCollection(Of ProjectStage)()}
            Dim stantoneProject As New ProjectObject() With {.Name = "Project: Stanton", .Stages = New ObservableCollection(Of ProjectStage)()}

            InitBetaronProjectData(betaronProject)
            InitStantoneProjectData(stantoneProject)

            projects.Add(betaronProject)
            projects.Add(stantoneProject)

            Return projects
        End Function

        Private Sub InitBetaronProjectData(ByVal betaronProject As ProjectObject)
            betaronProject.Executor = "Mcfadyen Ball"
            Dim stage21 As New ProjectStage() With {.Name = "Information Gathering", .Executor = "Kaiden Savastano", .Tasks = New ObservableCollection(Of Task)()}

            stage21.Tasks.Add(New Task() With {.Name = "Market research", .Executor = "Carmine Then", .StartDate = New Date(2011, 10, 1), .EndDate = New Date(2011, 10, 5), .State = States.DataSource(2)})
            stage21.Tasks.Add(New Task() With {.Name = "Making specification", .Executor = "Seto Kober", .StartDate = New Date(2011, 10, 5), .EndDate = New Date(2011, 10, 10), .State = States.DataSource(1)})
            Dim stage22 As New ProjectStage() With {.Name = "Planning", .Executor = "Manley Difrancesco", .Tasks = New ObservableCollection(Of Task)()}

            stage22.Tasks.Add(New Task() With {.Name = "Documentation", .Executor = "Martez Gollin", .StartDate = New Date(2011, 10, 15), .EndDate = New Date(2011, 10, 16), .State = States.DataSource(0)})
            Dim stage23 As New ProjectStage() With {.Name = "Design", .Executor ="Clint Mary", .Tasks = New ObservableCollection(Of Task)()}

            stage23.Tasks.Add(New Task() With {.Name = "Design of a web pages", .Executor = "Gasper Hartsell", .StartDate = New Date(2011, 10, 13), .EndDate = New Date(2011, 10, 14), .State = States.DataSource(0)})
            stage23.Tasks.Add(New Task() With {.Name = "Pages layout", .Executor = "Shirish Huminski", .StartDate = New Date(2011, 10, 13), .EndDate = New Date(2011, 10, 14), .State = States.DataSource(0)})
            Dim stage24 As New ProjectStage() With {.Name = "Development", .Executor = "Edwin Thone", .Tasks = New ObservableCollection(Of Task)()}

            stage24.Tasks.Add(New Task() With {.Name = "Design", .Executor = "Zarko Knill", .StartDate = New Date(2011, 10, 27), .EndDate = New Date(2011, 10, 28), .State = States.DataSource(0)})
            stage24.Tasks.Add(New Task() With {.Name = "Coding", .Executor = "Harley Kirckof", .StartDate = New Date(2011, 10, 29), .EndDate = New Date(2011, 10, 30), .State = States.DataSource(0)})
            Dim stage25 As New ProjectStage() With {.Name = "Testing and Delivery", .Executor ="Boucher Hislop", .Tasks = New ObservableCollection(Of Task)()}

            stage25.Tasks.Add(New Task() With {.Name = "Testing", .Executor = "Sarah Ragas", .StartDate = New Date(2011, 10, 13), .EndDate = New Date(2011, 10, 14), .State = States.DataSource(0)})
            stage25.Tasks.Add(New Task() With {.Name = "Content", .Executor = "Rashid Terinoni", .StartDate = New Date(2011, 10, 13), .EndDate = New Date(2011, 10, 14), .State = States.DataSource(0)})

            betaronProject.Stages.Add(stage21)
            betaronProject.Stages.Add(stage22)
            betaronProject.Stages.Add(stage23)
            betaronProject.Stages.Add(stage24)
            betaronProject.Stages.Add(stage25)
        End Sub

        Private Sub InitStantoneProjectData(ByVal stantoneProject As ProjectObject)
            stantoneProject.Executor = "Ruben Ackerman"
            Dim stage11 As New ProjectStage() With {.Name = "Information Gathering", .Executor = "Huyen Trinklein", .Tasks = New ObservableCollection(Of Task)()}

            stage11.Tasks.Add(New Task() With {.Name = "Market research", .Executor = "Tanner Crittendon", .StartDate = New Date(2011, 10, 1), .EndDate = New Date(2011, 10, 5), .State = States.DataSource(2)})
            stage11.Tasks.Add(New Task() With {.Name = "Making specification", .Executor = "Carmine Then", .StartDate = New Date(2011, 10, 5), .EndDate = New Date(2011, 10, 10), .State = States.DataSource(2)})
            Dim stage12 As New ProjectStage() With {.Name = "Planning", .Executor = "Alfredo Sookoo", .Tasks = New ObservableCollection(Of Task)()}

            stage12.Tasks.Add(New Task() With {.Name = "Documentation", .Executor = "Gorf Wobbe", .StartDate = New Date(2011, 10, 13), .EndDate = New Date(2011, 10, 14), .State = States.DataSource(2)})

            Dim stage13 As New ProjectStage() With {.Name = "Design", .Executor = "Saphire Plump", .Tasks = New ObservableCollection(Of Task)()}

            stage13.Tasks.Add(New Task() With {.Name = "Design of a web pages", .Executor = "Dominic Minden", .StartDate = New Date(2011, 10, 13), .EndDate = New Date(2011, 10, 14), .State = States.DataSource(1)})
            stage13.Tasks.Add(New Task() With {.Name = "Pages layout", .Executor = "Pinkerton Trezise", .StartDate = New Date(2011, 10, 13), .EndDate = New Date(2011, 10, 14), .State = States.DataSource(1)})
            Dim stage14 As New ProjectStage() With {.Name = "Development", .Executor = "Lauren Partain", .Tasks = New ObservableCollection(Of Task)()}

            stage14.Tasks.Add(New Task() With {.Name = "Design", .Executor = "Delilah Beamer", .StartDate = New Date(2011, 10, 23), .EndDate = New Date(2011, 10, 24), .State = States.DataSource(1)})
            stage14.Tasks.Add(New Task() With {.Name = "Coding", .Executor = "Dunaway Dupriest", .StartDate = New Date(2011, 10, 25), .EndDate = New Date(2011, 10, 26), .State = States.DataSource(0)})
            Dim stage15 As New ProjectStage() With {.Name = "Testing and Delivery", .Executor = "Christos Arrant", .Tasks = New ObservableCollection(Of Task)()}

            stage15.Tasks.Add(New Task() With {.Name = "Testing", .Executor = "Grice Ohora", .StartDate = New Date(2011, 10, 13), .EndDate = New Date(2011, 10, 14), .State = States.DataSource(0)})
            stage15.Tasks.Add(New Task() With {.Name = "Content", .Executor = "Christos Arrant", .StartDate = New Date(2011, 10, 13), .EndDate = New Date(2011, 10, 14), .State = States.DataSource(0)})

            stantoneProject.Stages.Add(stage11)
            stantoneProject.Stages.Add(stage12)
            stantoneProject.Stages.Add(stage13)
            stantoneProject.Stages.Add(stage14)
            stantoneProject.Stages.Add(stage15)
        End Sub
    End Class

    Public Class CustomChildrenSelector
        Implements IChildNodesSelector
        Public Function SelectChildren(ByVal item As Object) As IEnumerable Implements IChildNodesSelector.SelectChildren
            If TypeOf item Is Task Then
                Return Nothing
            ElseIf TypeOf item Is ProjectStage Then
                Return (TryCast(item, ProjectStage)).Tasks
            ElseIf TypeOf item Is ProjectObject Then
                Return (TryCast(item, ProjectObject)).Stages
            End If
            Return Nothing
        End Function
    End Class
End Namespace