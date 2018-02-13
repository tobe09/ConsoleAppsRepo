Public Module VbModule

    Public Class VbClass

        Public Shared Sub Main()
            Run()
        End Sub

        Public Shared Function encrptPassword(ByVal password As String) As String
            Dim I As Integer
            Dim strtemppassword As String = ""
            For I = 1 To Len(password)
                Dim midChar As String = Mid(password, I, 1)
                Dim ascii As String = Asc(midChar)
                Dim value As String = Chr(ascii + 1)  'Note: Method Chr's argument must be between 0 and 255
                strtemppassword = strtemppassword + Chr(Asc(Mid(password, I, 1)) + 1) & "-" 'main encryption, VB accepts + selectively and & for concatenation
            Next I
            encrptPassword = strtemppassword 'same as using return keyword
        End Function

        Public Shared Sub Test()
            Console.WriteLine("A PROGRAM TO ENCRYPT TEXT")
            Dim repeat As String = "y"
            While repeat.ToUpper() = "Y" Or repeat.ToUpper = "YES"    'VB does not need brackets for parameterless methods
                Console.WriteLine()
                Console.Write("Enter the value you wish to encrypt: ")
                Dim value As String = Console.ReadLine
                Console.WriteLine("The encypted value is: " & encrptPassword(value))
                Console.WriteLine("")
                Console.Write("Enter 'y' to encrypt another value or 'n' to exit: ")
                repeat = Console.ReadLine()
            End While
            Console.WriteLine()
            Console.WriteLine("THE END...")
            Console.ReadKey()
        End Sub

        Public Sub RuntimeBinding()
            Dim obj As Object = 5 + 2
            Console.WriteLine("An object casted directly into an integer by VB" & vbNewLine & Math.Pow(obj, 2))
            Console.ReadKey()
        End Sub

        Public Shared Sub Run()
            Test()
        End Sub

    End Class

End Module
