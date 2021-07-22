Public Class Form1
    Dim inte As Integer = 0
    Dim proba As Integer = 0
    Dim czasReakcjiMin As Integer = 100000
    Dim czasReakcjiMax As Integer = 0
    Dim czasReakcjiAll As Integer = 0
    Dim iloscProb As Integer = -1
    Dim bledy As Integer = 0

    Dim dtStartTime As Date

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()

        iloscProb = InputBox("Wprowadź liczbę prób", "Ilość prób")

        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""

        Label5.Text = 1
        Label6.Text = 0 & "ms"
        Label8.Text = 0 & "ms"
        Label10.Text = 0 & "ms"
        Label12.Text = 0

        Label1.BackColor = Color.White
        Label2.BackColor = Color.White
        Label3.BackColor = Color.White

        If MessageBox.Show("Start", "Start") = DialogResult.OK Then
            Timer1.Start()
            Timer3.Start()
            Timer5.Start()
        End If
    End Sub

    Sub odswiez()
        Label6.Text = Math.Round((czasReakcjiAll / (proba)), 3) & "ms"
        Label8.Text = czasReakcjiMin & "ms"
        Label10.Text = czasReakcjiMax & "ms"
        Label12.Text = bledy

        If proba >= iloscProb Then
            Timer1.Stop()
            Timer3.Stop()
            Timer5.Stop()
            MsgBox("Koniec. Twoje wyniki są w oknie.")
        Else
            Label5.Text = proba + 1
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim los As Integer = CInt(Int((100 * Rnd()) + 1))

        If los Mod 3 = 0 Then
            dtStartTime = Now

            Timer2.Start()
            Timer1.Stop()
            Timer3.Stop()
            Timer5.Stop()

            Label1.BackColor = Color.Red
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim tsDiff As TimeSpan = Now.Subtract(dtStartTime)
        Label1.Text = tsDiff.TotalMilliseconds & "ms"
        inte = tsDiff.TotalMilliseconds
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Dim los As Integer = CInt(Int((100 * Rnd()) + 1))

        If los Mod 3 = 0 Then
            dtStartTime = Now

            Timer4.Start()
            Timer1.Stop()
            Timer3.Stop()
            Timer5.Stop()

            Label2.BackColor = Color.Green
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Dim tsDiff As TimeSpan = Now.Subtract(dtStartTime)
        Label2.Text = tsDiff.TotalMilliseconds & "ms"
        inte = tsDiff.TotalMilliseconds
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        Dim los As Integer = CInt(Int((100 * Rnd()) + 1))

        If los Mod 3 = 0 Then
            dtStartTime = Now

            My.Computer.Audio.Play(My.Resources.aaa, AudioPlayMode.Background)

            Timer6.Start()
            Timer1.Stop()
            Timer3.Stop()
            Timer5.Stop()
        End If
    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        Dim tsDiff As TimeSpan = Now.Subtract(dtStartTime)
        Label3.Text = tsDiff.TotalMilliseconds & "ms"
        inte = tsDiff.TotalMilliseconds
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Timer2.Enabled Then
            If e.KeyCode = Keys.Left Then
                Timer2.Stop()
                Threading.Thread.Sleep(2000)
                Label1.Text = ""
                Label1.BackColor = Color.White
                czasReakcjiAll = czasReakcjiAll + inte

                If inte < czasReakcjiMin Then
                    czasReakcjiMin = inte
                End If

                If inte > czasReakcjiMax Then
                    czasReakcjiMax = inte
                End If

                inte = 0
                Timer1.Start()
                Timer3.Start()
                Timer5.Start()
                proba = proba + 1
                odswiez()
            Else
                My.Computer.Audio.Play(My.Resources.blad, AudioPlayMode.Background)
                bledy = bledy + 1
                Label12.Text = bledy
            End If
        End If

        If Timer4.Enabled Then
            If e.KeyCode = Keys.Right Then
                Timer4.Stop()
                Threading.Thread.Sleep(2000)
                Label2.Text = ""
                Label2.BackColor = Color.White
                czasReakcjiAll = czasReakcjiAll + inte

                If inte < czasReakcjiMin Then
                    czasReakcjiMin = inte
                End If

                If inte > czasReakcjiMax Then
                    czasReakcjiMax = inte
                End If

                inte = 0
                Timer1.Start()
                Timer3.Start()
                Timer5.Start()
                proba = proba + 1
                odswiez()
            Else
                My.Computer.Audio.Play(My.Resources.blad, AudioPlayMode.Background)
                bledy = bledy + 1
                Label12.Text = bledy
            End If
        End If

        If Timer6.Enabled Then
            If e.KeyCode = Keys.Space Then
                Timer6.Stop()
                Threading.Thread.Sleep(2000)
                Label3.Text = ""
                Label3.BackColor = Color.White
                czasReakcjiAll = czasReakcjiAll + inte

                If inte < czasReakcjiMin Then
                    czasReakcjiMin = inte
                End If

                If inte > czasReakcjiMax Then
                    czasReakcjiMax = inte
                End If

                inte = 0
                Timer1.Start()
                Timer3.Start()
                Timer5.Start()
                proba = proba + 1
                odswiez()
            Else
                My.Computer.Audio.Play(My.Resources.blad, AudioPlayMode.Background)
                bledy = bledy + 1
                Label12.Text = bledy
            End If
        End If
    End Sub
End Class
