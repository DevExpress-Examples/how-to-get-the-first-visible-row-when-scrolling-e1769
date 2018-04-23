Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Controls.Primitives
Imports DevExpress.Wpf.Grid
Imports DevExpress.Wpf.Core.Native

Namespace Sample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Public Partial Class Window1
		Inherits Window
		Private list As List(Of TestData)
		Public Sub New()
			InitializeComponent()
			list = New List(Of TestData)()
            Dim td As TestData = New TestData()
            With td
                .Text = "row1"
                .Number = 1
            End With
            list.Add(td)

            td = New TestData()
            With td
                .Text = "row2"
                .Number = 2
            End With
            list.Add(td)

            td = New TestData()
            With td
                .Text = "row3"
                .Number = 3
            End With
            list.Add(td)

            td = New TestData()
            With td
                .Text = "row4"
                .Number = 4
            End With
            list.Add(td)

            td = New TestData()
            With td
                .Text = "row5"
                .Number = 5
            End With
            list.Add(td)
            td = New TestData()
            With td
                .Text = "row6"
                .Number = 6
            End With

            list.Add(td)

            td = New TestData()
            With td
                .Text = "row7"
                .Number = 7
            End With

            list.Add(td)

			grid.DataSource = list
		End Sub

		Private Function GetScrollInfo() As IScrollInfo
			For Each item As DependencyObject In New VisualTreeEnumerable(view)
				If TypeOf item Is DataPresenter Then
					Return CType(item, DataPresenter)
				End If
			Next item
			Throw New InvalidOperationException()
		End Function

        Private Sub view_ScrollChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.ScrollChangedEventArgs)
            Dim RowHandle As Integer = grid.GetRowHandleByVisibleIndex(Convert.ToInt32(GetScrollInfo().VerticalOffset))
            Dim td As TestData = TryCast(grid.GetRow(RowHandle), TestData)
            textEdit1.Text = td.Text
        End Sub
    End Class
	Public Class TestData
        Private _number As Integer
        Public Property Number() As Integer
            Get
                Return _number
            End Get
            Set(ByVal value As Integer)
                _number = value
            End Set
        End Property

        Private _text As String
        Public Property Text() As String
            Get
                Return _text
            End Get
            Set(ByVal value As String)
                _text = value
            End Set
        End Property
    End Class

End Namespace
