Imports System.Speech
Public Class Form1
    Dim WithEvents SRE As New Recognition.SpeechRecognitionEngine
    Dim RDocument As New Recognition.SrgsGrammar.SrgsDocument
    Dim RRule As New Recognition.SrgsGrammar.SrgsRule("words")
    Dim RWords As New Recognition.SrgsGrammar.SrgsOneOf("left", "right", "close", "enter")
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SRE.SetInputToDefaultAudioDevice()
        RRule.Add(RWords)
        RDocument.Rules.Add(RRule)
        RDocument.Root = RRule
        SRE.LoadGrammar(New Recognition.Grammar(RDocument))
        SRE.RecognizeAsync()
    End Sub

    Private Sub SRE_RecognizeCompleted(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognizeCompletedEventArgs) Handles SRE.RecognizeCompleted
        SRE.RecognizeAsync()
    End Sub

    Private Sub SRE_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles SRE.SpeechRecognized
        Select Case e.Result.Text
            Case "left"
                SendKeys.Send("{LEFT}")
            Case "right"
                SendKeys.Send("{RIGHT}")
            Case "close"
                SendKeys.Send("%{F4}")
            Case "enter"
                SendKeys.Send("~")
        End Select

    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Hide()
        Timer1.Enabled = False
    End Sub
End Class
