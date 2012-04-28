' Slot Machine
' Author: Ian P [ippavlin]

Imports System.Drawing

Public Class SlotMachine

    Private Orange1 As Byte = 200
    Private Orange2 As Byte = 20
    Private Grape1 As Byte = 225
    Private Grape2 As Byte = 30
    Private Cherry1 As Byte = 250
    Private Cherry2 As Byte = 40

    Private a, b, c As Byte
    Private rndMultiplier As Byte = 3
    Private Credits As Byte = 5
    Private CreditCost As Byte = 50
    Private Score As Integer

    Private isOrangeS1, isOrangeS2, isOrangeS3 As Boolean
    Private isGrapeS1, isGrapeS2, isGrapeS3 As Boolean
    Private isCherryS1, isCherryS2, isCherryS3 As Boolean

    Private Sub SlotMachine_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lOrange1.Text = Orange1
        lOrange2.Text = Orange2
        lGrape1.Text = Grape1
        lGrape2.Text = Grape2
        lCherry1.Text = Cherry1
        lCherry2.Text = Cherry2

        lCredits.Text = "Credits: " & Credits
        lScore.Text = "Score: " & Score
    End Sub

    Private Sub tmrSpin_Tick(sender As System.Object, e As System.EventArgs) Handles tmrSpin.Tick
        a = 1 + Int(Rnd() * rndMultiplier)
        b = 1 + Int(Rnd() * rndMultiplier)
        c = 1 + Int(Rnd() * rndMultiplier)

        If a = 1 Then
            pSlot1.Image = New Bitmap("res\game\FRUIT_ORANGE.PNG")
            isOrangeS1 = True
            isGrapeS1 = False
            isCherryS1 = False
        ElseIf a = 2 Then
            pSlot1.Image = New Bitmap("res\game\FRUIT_GRAPE.PNG")
            isOrangeS1 = False
            isGrapeS1 = True
            isCherryS1 = False
        ElseIf a = 3 Then

            pSlot1.Image = New Bitmap("res\game\FRUIT_CHERRY.PNG")
            isOrangeS1 = False
            isGrapeS1 = False
            isCherryS1 = True
        End If

        If b = 1 Then
            pSlot2.Image = New Bitmap("res\game\FRUIT_ORANGE.PNG")
            isOrangeS2 = True
            isGrapeS2 = False
            isCherryS2 = False
        ElseIf b = 2 Then
            pSlot2.Image = New Bitmap("res\game\FRUIT_GRAPE.PNG")
            isOrangeS2 = False
            isGrapeS2 = True
            isCherryS2 = False
        ElseIf b = 3 Then
            pSlot2.Image = New Bitmap("res\game\FRUIT_CHERRY.PNG")
            isOrangeS2 = False
            isGrapeS2 = False
            isCherryS2 = True
        End If

        If c = 1 Then
            pSlot3.Image = New Bitmap("res\game\FRUIT_ORANGE.PNG")
            isOrangeS3 = True
            isGrapeS3 = False
            isCherryS3 = False
        ElseIf c = 2 Then
            pSlot3.Image = New Bitmap("res\game\FRUIT_GRAPE.PNG")
            isOrangeS3 = False
            isGrapeS3 = True
            isCherryS3 = False
        ElseIf c = 3 Then
            pSlot3.Image = New Bitmap("res\game\FRUIT_CHERRY.PNG")
            isOrangeS3 = False
            isGrapeS3 = False
            isCherryS3 = True
        End If
    End Sub

    Private Sub bStop_Click(sender As System.Object, e As System.EventArgs) Handles bStop.Click
        If tmrSpin.Enabled = True Then
            tmrSpin.Enabled = False

            If isOrangeS1 = True And isOrangeS2 = True And isOrangeS3 = True Then
                Score = Score + Orange1
            ElseIf isOrangeS1 = True And isOrangeS2 = True Or isOrangeS1 = True And isOrangeS3 = True Or isOrangeS2 = True And isOrangeS3 = True Then
                Score = Score + Orange2
            End If

            If isGrapeS1 = True And isGrapeS2 = True And isGrapeS3 = True Then
                Score = Score + Grape1
            ElseIf isGrapeS1 = True And isGrapeS2 = True Or isGrapeS1 = True And isGrapeS3 = True Or isGrapeS2 = True And isGrapeS3 = True Then
                Score = Score + Grape2
            End If

            If isCherryS1 = True And isCherryS2 = True And isCherryS3 = True Then
                Score = Score + Cherry1
            ElseIf isCherryS1 = True And isCherryS2 = True Or isCherryS1 = True And isCherryS3 = True Or isCherryS2 = True And isCherryS3 = True Then
                Score = Score + Cherry2
            End If

            lScore.Text = "Score: " & Score
        End If
    End Sub

    Private Sub bSpin_Click(sender As System.Object, e As System.EventArgs) Handles bSpin.Click
        If Credits > 0 And tmrSpin.Enabled = False Then
            Credits = Credits - 1
            lCredits.Text = "Credits: " & Credits
            tmrSpin.Enabled = True
        ElseIf Credits > 0 And tmrSpin.Enabled = True Then
            'The slot machine is already spinning.
        ElseIf Credits = 0 Then
            MessageBox.Show("You do not have enough credits!", "Out of Credits!")
        End If
    End Sub

    Private Sub InsertCoinToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InsertCoinToolStripMenuItem.Click
        If Score > 49 Then
            Credits = Credits + 1
            lCredits.Text = "Credits: " & Credits
            Score = Score - CreditCost
            lScore.Text = "Score: " & Score
        Else
            MessageBox.Show("You do not have enough points!", "Insufficient Points")
        End If
    End Sub
End Class
