Imports System.Console

Module Program
    Sub getValue(ByRef userInp As String)

        While True
            Write("Enter your move : ")
            userInp = ReadLine()

            If isValidd(userInp) Then
                Exit While
            Else
                WriteLine("Invalid Input, Please Give a valid Input.")

            End If
        End While


    End Sub

    Function isValidd(userInp As String) As Boolean
        If userInp = "stone" Or userInp = "paper" Or userInp = "sizzer" Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub matchResults(ByRef userInp As String, ByRef comp1 As String, ByRef userStr As String, ByRef compStr As String)

        If userInp = comp1 Then
            userStr &= "0"
            compStr &= "0"
            Write("User : " & userInp & " | comp : " & comp1)
            WriteLine(" = Tie!")

        ElseIf (userInp = "stone" And comp1 = "sizzer") Or (userInp = "paper" And comp1 = "stone") Or (userInp = "sizzer" And comp1 = "paper") Then
            userStr &= "1"
            compStr &= "0"
            WriteLine("User wins : " & userInp & " | comp losses : " & comp1)

        Else
            userStr &= "0"
            compStr &= "1"
            WriteLine("User losses : " & userInp & "| comp wins : " & comp1)

        End If

    End Sub

    Sub printResult(userStr, compStr)
        Dim total1, total2 As Integer

        WriteLine("Scores are : ")
        WriteLine("                                               _________________")
        WriteLine("                                               | User  |  Comp |")
        For i As Integer = 0 To userStr.Length - 1
            WriteLine("                                               |   " & userStr(i) & "   |   " & compStr(i) & "   |")
            If userStr(i) = "1" Then
                total1 += 1
            ElseIf compStr(i) = "1" Then
                total2 += 1
            End If
        Next
        WriteLine("                                               |_______|_______|")
        WriteLine("                                       Total :     " & total1 & "        " & total2)
        WriteLine()

        Write("Result :---------------------------------------> ")
        If total1 > total2 Then
            WriteLine("User wins")
        ElseIf total2 > total1 Then
            WriteLine("Comp wins")
        Else
            WriteLine("Match is tied")
        End If

        ReadKey()
    End Sub

    Sub Main(args As String())
        Dim rand As New Random()
        Dim Strings As String() = {"stone", "paper", "sizzer"}
        Dim usr As String = ""
        Dim comp1 As String = ""
        Dim ag As Char = "y"
        Dim userStr As String = ""
        Dim compStr As String = ""

        While ag = "y"
            Dim indx As Integer = rand.Next(0, Strings.Length)
            comp1 = Strings(indx)

            getValue(usr)

            matchResults(usr, comp1, userStr, compStr)

            WriteLine()
            Write("You want to Play again? (Y/N) : ")
            ag = ReadLine()
            WriteLine()

        End While

        printResult(userStr, compStr)
    End Sub
End Module