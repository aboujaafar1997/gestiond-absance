Imports MySql.Data.MySqlClient
Imports System.Threading
Imports System.IO
Imports System.Speech.Synthesis
Public Class fiche_etudiant

    Private Sub fiche_etudiant_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub BunifuGauge1_Load(sender As System.Object, e As System.EventArgs) Handles BunifuGauge1.Load


    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click 'screen shoot du fiche'
        Dim a As New Bitmap(Me.Width, Panel2.Height) 'fait une photo egal a ma lon et lar'
        Dim b As String = "C:\Users\othmane\Desktop\" + BunifuCustomLabel5.Text 'l endroit d'enregi de la screen'
        Me.DrawToBitmap(a, New Rectangle(0, 0, Me.Width, Panel2.Height)) 'pour ne pas afficher les 2 barres'
        a.Save(b)
        MsgBox("save in desktop sous le nom:   " + BunifuCustomLabel5.Text)








    End Sub

    Private Sub BunifuThinButton22_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton22.Click
        Close()

    End Sub


    Private Sub Panelm_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panelm.Paint

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
End Class