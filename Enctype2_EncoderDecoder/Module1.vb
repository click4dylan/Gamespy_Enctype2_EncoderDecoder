Module Module1

    Sub Main()
        Console.WriteLine("Encode or Decode?")
        Dim line = Console.ReadLine.ToLower
        If line = "encode" Then
            Console.WriteLine("Enter source filename")
            line = Console.ReadLine()
            Dim data = IO.File.ReadAllBytes(line)
            Console.WriteLine("Enter secret key")
            line = Console.ReadLine
            Dim encoder As New Gamespy_Encoder
            Dim encoded As Byte() = encoder.enctype2_encoder(data, data.Length, line)
            WriteByteOutput("output.txt", encoded)
        ElseIf line = "decode" Then
            Console.WriteLine("Enter source filename")
            line = Console.ReadLine()
            Dim data As Byte() = IO.File.ReadAllBytes(line)
            Console.WriteLine("Enter secret key")
            line = Console.ReadLine
            Dim decoder As New Gamespy_Decoder
            Dim decoded As String = decoder.enctype2_decoder(data, data.Length, line)
            WriteStringOutput("output.txt", decoded)
        End If
        Console.WriteLine("Done!")
        Threading.Thread.Sleep(2000)
    End Sub
    Private Sub WriteByteOutput(ByVal filename As String, ByVal output As Byte())
        Console.WriteLine("Number of bytes: " & output.Length)
        IO.File.Delete(filename)
        IO.File.WriteAllBytes(filename, output)
    End Sub
    Private Sub WriteStringOutput(ByVal filename As String, ByVal output As String)
        IO.File.Delete(filename)
        Dim sw As New IO.StreamWriter(filename)
        sw.Write(output)
        sw.Flush()
        sw.Close()
    End Sub
End Module
