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
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Core.Native

Namespace Sample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
		Inherits Window
		Private list As List(Of TestData)
		Public Sub New()
			InitializeComponent()
			list = New List(Of TestData)()
			list.Add(New TestData() With {.Number = 1, .Text = "row1"})
			list.Add(New TestData() With {.Number = 2, .Text = "row2"})
			list.Add(New TestData() With {.Number = 3, .Text = "row3"})
			list.Add(New TestData() With {.Number = 1, .Text = "row4"})
			list.Add(New TestData() With {.Number = 2, .Text = "row5"})
			list.Add(New TestData() With {.Number = 3, .Text = "row6"})
			list.Add(New TestData() With {.Number = 1, .Text = "row7"})
			list.Add(New TestData() With {.Number = 2, .Text = "row8"})
			list.Add(New TestData() With {.Number = 3, .Text = "row9"})
			list.Add(New TestData() With {.Number = 1, .Text = "row10"})
			list.Add(New TestData() With {.Number = 2, .Text = "row11"})
			list.Add(New TestData() With {.Number = 3, .Text = "row12"})
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

		Private Sub view_ScrollChanged(ByVal sender As Object, ByVal e As ScrollChangedEventArgs)
			Dim RowHandle As Integer = grid.GetRowHandleByVisibleIndex(Convert.ToInt32(GetScrollInfo().VerticalOffset))
			Dim td As TestData = TryCast(grid.GetRow(RowHandle), TestData)
			textEdit1.Text = td.Text
		End Sub
	End Class
	Public Class TestData
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateText As String
		Public Property Text() As String
			Get
				Return privateText
			End Get
			Set(ByVal value As String)
				privateText = value
			End Set
		End Property
	End Class
End Namespace
