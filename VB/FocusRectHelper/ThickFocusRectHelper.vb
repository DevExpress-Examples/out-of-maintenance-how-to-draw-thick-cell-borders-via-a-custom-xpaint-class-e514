Imports DevExpress.Utils.Paint
Imports System
Imports System.Drawing
Imports System.Reflection

Namespace CellBorder.FocusRectHelper
    Friend NotInheritable Class ThickFocusRectHelper

        Private Sub New()
        End Sub

        Public Shared Sub SetupCustomPainter()
            XPaint.CreateCustomPainter(New MyXPaint())
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
            If Not CanDraw(r) Then
                Return
            End If
            ThickFocusRectHelper.DrawThickFocusRectangle(g, r)
        End Sub
    End Class
    Public Class MyXPaintMixed
        Inherits XPaintMixed

        Public Overrides Sub DrawFocusRectangle(ByVal g As Graphics, ByVal r As Rectangle, ByVal foreColor As Color, ByVal backColor As Color)
            If Not CanDraw(r) Then
                Return
            End If
            ThickFocusRectHelper.DrawThickFocusRectangle(g, r)
        End Sub
    End Class
End Namespace
