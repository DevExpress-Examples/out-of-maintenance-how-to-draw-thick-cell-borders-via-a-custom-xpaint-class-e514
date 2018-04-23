Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Reflection
Imports DevExpress.Utils.Paint

Namespace CellBorder
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.EmbeddedNavigator.Name = ""
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(460, 264)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' gridView1
			' 
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(460, 264)
			Me.Controls.Add(Me.gridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			ThickFocusRectHelper.SetGraphics()
			Application.Run(New Form1())
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim TempXViewsPrinting As DevExpress.XtraGrid.Design.XViewsPrinting = New DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1)
		End Sub
	End Class

	Friend NotInheritable Class ThickFocusRectHelper
		Private Sub New()
		End Sub
		Public Shared Sub SetGraphics()
			Dim fi As FieldInfo = GetType(XPaint).GetField("graphics", BindingFlags.Static Or BindingFlags.NonPublic)
			Dim xPaint As XPaint = Nothing

			Select Case Environment.OSVersion.Platform
				Case PlatformID.Win32S, PlatformID.Win32Windows
					xPaint = New MyXPaint()
				Case Else
					xPaint = New MyXPaintMixed()
			End Select
			fi.SetValue(Nothing, xPaint)
		End Sub

		Public Shared Sub DrawThickFocusRectangle(ByVal g As Graphics, ByVal r As Rectangle)
			Dim hb As Brush = Brushes.Black
			g.FillRectangle(hb, New Rectangle(r.X, r.Y, 2, r.Height - 2)) ' left
			g.FillRectangle(hb, New Rectangle(r.X, r.Y, r.Width - 2, 2)) ' top
			g.FillRectangle(hb, New Rectangle(r.Right - 2, r.Y, 2, r.Height - 2)) ' right
			g.FillRectangle(hb, New Rectangle(r.X, r.Bottom - 2, r.Width, 2)) ' bottom
		End Sub
	End Class


	Public Class MyXPaint
		Inherits XPaint
		Public Overrides Sub DrawFocusRectangle(ByVal g As Graphics, ByVal r As Rectangle, ByVal foreColor As Color, ByVal backColor As Color)
			If (Not CanDraw(r)) Then
				Return
			End If
			ThickFocusRectHelper.DrawThickFocusRectangle(g, r)
		End Sub
	End Class
	Public Class MyXPaintMixed
		Inherits XPaintMixed
		Public Overrides Sub DrawFocusRectangle(ByVal g As Graphics, ByVal r As Rectangle, ByVal foreColor As Color, ByVal backColor As Color)
			If (Not CanDraw(r)) Then
				Return
			End If
			ThickFocusRectHelper.DrawThickFocusRectangle(g, r)
		End Sub
	End Class

End Namespace
