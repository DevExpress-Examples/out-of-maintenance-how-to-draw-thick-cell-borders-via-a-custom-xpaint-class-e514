Imports CellBorder.FocusRectHelper
Imports System
Imports System.Windows.Forms

Namespace CellBorder
    Public NotInheritable Class Program

        Private Sub New()
        End Sub

        <STAThread> _
        Shared Sub Main()
            ThickFocusRectHelper.SetupCustomPainter()
            Application.Run(New Form1())
        End Sub
    End Class
End Namespace
