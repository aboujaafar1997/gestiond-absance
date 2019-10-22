Public Class fiche__profvb

    Private Sub fiche__profvb_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Panelm_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panelm.MouseDown 'changer le mouvement dans le bureau..tal la fin'
        drag = True
        mousex = Windows.Forms.Cursor.Position.X
        mousey = Windows.Forms.Cursor.Position.Y

    End Sub

    Private Sub Panelm_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panelm.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey

            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If

    End Sub

    Private Sub Panelm_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panelm.MouseUp
        drag = False

    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        Dim a As New Bitmap(Me.Width, Panel1.Height) 'fait une photo egal a ma lon et lar'
        Dim b As String = "C:\Users\othmane\Desktop\" + BunifuCustomLabel12.Text 'l endroit d'enregi de la screen'
        Me.DrawToBitmap(a, New Rectangle(0, 0, Me.Width, Panel1.Height)) 'pour ne pas afficher les 2 barres'
        a.Save(b)
        MsgBox("save in desktop sous le nom:   " + BunifuCustomLabel12.Text)
    End Sub

    Private Sub BunifuThinButton22_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton22.Click
        Close()

    End Sub
End Class