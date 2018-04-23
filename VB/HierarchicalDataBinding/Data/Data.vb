' Developer Express Code Central Example:
' How to show check boxes near nodes and check child nodes when a parent node is checked
' 
' Modify our template to add the check edit near a node. Handle checked/unchecked
' events of this check edit and iterate via nodes to check/uncheck child nodes.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3466

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Collections
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.Windows.Media.Imaging
Imports System.Windows.Media

Namespace HierarchicalDataBinding
    Public Class BaseObject
        Implements INotifyPropertyChanged

        Private nameCore As String
        Public Property Name() As String
            Get
                Return nameCore
            End Get
            Set(ByVal value As String)
                If Name = value Then
                    Return
                End If
                nameCore = value
                OnPropertyChanged("Name")
            End Set
        End Property

        Private checkedCore? As Boolean = False
        Public Property Checked() As Boolean?
            Get
                Return checkedCore
            End Get
            Set(ByVal value As Boolean?)
                If Checked = value Then
                    Return
                End If
                checkedCore = value
                OnPropertyChanged("Checked")
            End Set
        End Property

        Private executorCore As String
        Public Property Executor() As String
            Get
                Return executorCore
            End Get
            Set(ByVal value As String)
                If ReferenceEquals(Executor, value) Then
                    Return
                End If
                executorCore = value
                OnPropertyChanged("Executor")
            End Set
        End Property

        Private stateCore As State
        Public Property State() As State
            Get
                Return stateCore
            End Get
            Set(ByVal value As State)
                If ReferenceEquals(State, value) Then
                    Return
                End If
                stateCore = value
                OnPropertyChanged("State")
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Name
        End Function

        Protected Sub OnPropertyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    End Class

    Public Class ProjectObject
        Inherits BaseObject

        Public Property Stages() As ObservableCollection(Of ProjectStage)
    End Class

    Public Class ProjectStage
        Inherits BaseObject

        Public Property Tasks() As ObservableCollection(Of Task)
    End Class

    Public Class Task
        Inherits BaseObject

        Private startDateCore As Date
        Public Property StartDate() As Date
            Get
                Return startDateCore
            End Get
            Set(ByVal value As Date)
                If StartDate = value Then
                    Return
                End If
                startDateCore = value
                OnPropertyChanged("StartDate")
            End Set
        End Property
        Private endDateCore As Date
        Public Property EndDate() As Date
            Get
                Return endDateCore
            End Get
            Set(ByVal value As Date)
                If EndDate = value Then
                    Return
                End If
                endDateCore = value
                OnPropertyChanged("EndDate")
            End Set
        End Property
    End Class

    Public Class State
        Implements IComparable

        Public Property Image() As ImageSource
        Public Property TextValue() As String
        Public Property StateValue() As Integer
        Public Overrides Function ToString() As String
            Return TextValue
        End Function

        Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo
            Return Comparer(Of Integer).Default.Compare(StateValue, DirectCast(obj, State).StateValue)
        End Function
    End Class

    Public Class States
        Inherits List(Of State)

        Private Shared src As List(Of State)
        Public Shared ReadOnly Property DataSource() As List(Of State)
            Get
                If src Is Nothing Then
                    src = New List(Of State)()
                    src.Add(New State() With {.TextValue = "Not started", .StateValue = 0})
                    src.Add(New State() With {.TextValue = "In progress", .StateValue = 1})
                    src.Add(New State() With {.TextValue = "Completed", .StateValue = 2})
                End If
                Return src
            End Get
        End Property
    End Class
End Namespace