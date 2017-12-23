
Imports System.Speech
Imports System.Speech.Recognition

Public Class Form1

    Dim REC As New SpeechRecognitionEngine
    Dim SYNT As New Speech.Synthesis.SpeechSynthesizer
    Dim PALABRA As String

    Public Sub RECONOCE(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        Dim RESULTADO As RecognitionResult
        RESULTADO = e.Result
        Dim PALABRA As String
        PALABRA = RESULTADO.Text
        If (PALABRA = "prende sala") Then
            Panel1.BackgroundImage = My.Resources.sala_prendi

            SerialPort1.Write("1")

        ElseIf (PALABRA = "apaga sala") Then
            Panel1.BackgroundImage = My.Resources.sala_apagado



            SerialPort1.Write("0")


        ElseIf (PALABRA = "prende cocina") Then

            Panel2.BackgroundImage = My.Resources.cocina_prendida


            SerialPort1.Write("3")


        ElseIf (PALABRA = "apaga cocina") Then
            Panel2.BackgroundImage = My.Resources.cocina_apagado



            SerialPort1.Write("2")

        ElseIf (PALABRA = "prende comedor") Then
            Panel3.BackgroundImage = My.Resources.comedor_prendido


            SerialPort1.Write("5")

        ElseIf (PALABRA = "apaga comedor") Then
            Panel3.BackgroundImage = My.Resources.comedor_apagado



            SerialPort1.Write("4")

        ElseIf (PALABRA = "prende cuarto") Then
            Panel4.BackgroundImage = My.Resources.cuarto_prendido




            SerialPort1.Write("7")

        ElseIf (PALABRA = "apaga cuarto") Then
            Panel4.BackgroundImage = My.Resources.cuarto_apagado



            SerialPort1.Write("6")

        ElseIf (PALABRA = "prende cochera") Then
            Panel10.BackgroundImage = My.Resources.cochera_prendido




            SerialPort1.Write("9")

        ElseIf (PALABRA = "apaga cochera") Then
            Panel10.BackgroundImage = My.Resources.cochera_apagado



            SerialPort1.Write("8")





        End If
    End Sub




    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Try
            SerialPort1.PortName = TextBox1.Text
            SerialPort1.Open()

            SerialPort1.Write("0")

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SerialPort1.Write("1")
        Panel1.BackgroundImage = My.Resources.sala_prendi

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.Write("0")
        Panel1.BackgroundImage = My.Resources.sala_apagado


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Button8.Text = "POR VOZ" Then
            Try

                Dim VOCABULARIO As New GrammarBuilder
                VOCABULARIO.Append(New Choices("prende sala", "apaga sala", "prende cocina", "apaga cocina", "prende comedor", "apaga comedor", "prende cuarto", "apaga cuarto", "prende cochera", "apaga cochera"))
                REC.LoadGrammar(New Grammar(VOCABULARIO))

                REC.SetInputToDefaultAudioDevice()
                REC.RecognizeAsync(RecognizeMode.Multiple)
                AddHandler REC.SpeechRecognized, AddressOf RECONOCE

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Button8.Text = "HABLE AHORA"

            Panel5.BackgroundImage = My.Resources.microfono2

        ElseIf Button8.Text = "HABLE AHORA" Then

            Panel5.BackgroundImage = My.Resources.microfono1

            Button8.Text = "POR VOZ"

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SerialPort1.Write("3")
        Panel2.BackgroundImage = My.Resources.cocina_prendida


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SerialPort1.Write("2")

        Panel2.BackgroundImage = My.Resources.cocina_apagado


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SerialPort1.Write("5")
        Panel3.BackgroundImage = My.Resources.comedor_prendido


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SerialPort1.Write("4")
        Panel3.BackgroundImage = My.Resources.comedor_apagado


    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        SerialPort1.Write("7")
        Panel4.BackgroundImage = My.Resources.cuarto_prendido


    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        SerialPort1.Write("6")
        Panel4.BackgroundImage = My.Resources.cuarto_apagado


    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        SerialPort1.Write("9")
        Panel10.BackgroundImage = My.Resources.cochera_prendido


    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        SerialPort1.Write("8")
        Panel10.BackgroundImage = My.Resources.cochera_apagado


    End Sub
End Class
