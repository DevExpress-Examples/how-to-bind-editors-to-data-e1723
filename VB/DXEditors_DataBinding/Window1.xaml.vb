Imports Microsoft.VisualBasic
Imports System.Windows

Namespace DXEditors_DataBinding
	Partial Public Class Window1
		Inherits Window
		Private dt As DXEditors_DataBinding.nwindDataSet.ProductsDataTable
		Private currentRecord As Integer
		Public Sub New()
			InitializeComponent()
			currentRecord = 0
			dt = New nwindDataSetTableAdapters.ProductsTableAdapter().GetData()
			DataContext = dt(currentRecord)
			comboBoxEdit1.ItemsSource = _
				New nwindDataSetTableAdapters.CategoriesTableAdapter().GetData()
		End Sub

		Private Sub prevButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			currentRecord -= 1
			UpdateData()
			UpdateButtonState()
		End Sub
		Private Sub nextButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			currentRecord += 1
			UpdateData()
			UpdateButtonState()
		End Sub
		Private Sub UpdateData()
			DataContext = dt(currentRecord)
		End Sub
		Private Sub UpdateButtonState()
			prevButton.IsEnabled = currentRecord <> 0
			nextButton.IsEnabled = currentRecord <> dt.Rows.Count - 1
		End Sub
	End Class
End Namespace
