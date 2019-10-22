Public Class notification

    Private Sub notification_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 60
        Me.Left = Screen.PrimaryScreen.Bounds.Width - Me.Width - 60
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity > 0 Then
            Me.Opacity -= 0.05
        Else
            Me.Close()

        End If
    End Sub
End Class