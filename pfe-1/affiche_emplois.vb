Public Class affiche_emplois

    Private Sub affiche_emplois_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Close()

    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panelm.Paint, Panel1.Paint

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