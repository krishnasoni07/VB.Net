Imports System.Console

Module Program

    Sub u1(ByRef map(,) As Integer, ByRef u1String As String, ByRef u2String As String)
        Dim i As Integer = 1

        While i <= 9
            If i Mod 2 <> 0 Then
                takeInpU1(map)
            Else
                takeInpU2(map)
            End If
            i += 1

            If i >= 5 Then
                Dim result As Integer = checkResult(map)
                If result = 1 Then
                    u1String &= 1
                    u2String &= 0
                    Exit While
                ElseIf result = 2 Then
                    u1String &= 0
                    u2String &= 1
                    Exit While
                End If
            End If

        End While

    End Sub

    Sub u2(ByRef map(,) As Integer, ByRef u1String As String, ByRef u2String As String)
        Dim i As Integer = 1

        While i <= 9
            If i Mod 2 = 0 Then
                takeInpU1(map)
            Else
                takeInpU2(map)
            End If
            i += 1

            If i >= 5 Then
                Dim result As Integer = checkResult(map)
                If result = 1 Then
                    u1String &= 1
                    u2String &= 0
                    Exit While
                ElseIf result = 2 Then
                    u1String &= 0
                    u2String &= 1
                    Exit While
                End If
            End If
        End While
    End Sub

    Function checkResult(map(,) As Integer) As Integer
        If u1Wins(map) Then
            WriteLine("User 1 Wins")
            Return 1
        ElseIf u2Wins(map) Then
            WriteLine("User 2 Wins")
            Return 2
        End If
    End Function

    Sub takeInpU1(ByRef map(,) As Integer)
        Dim response As String

        While True
            Write("user 1's chance : ")
            response = ReadLine()
            Dim a As Integer = Integer.Parse(response(0))
            Dim b As Integer = Integer.Parse(response(2))

            If isValid(a, b, map) Then
                map(a, b) = 1
                Exit While
            Else
                WriteLine("This block is already occupied By Cross , please choose another block.")
                ReadKey()
            End If
        End While

    End Sub

    Sub takeInpU2(ByRef map(,) As Integer)
        Dim response As String

        While True

            Write("User 2's chance : ")
            response = ReadLine()
            Dim a As Integer = Integer.Parse(response(0))
            Dim b As Integer = Integer.Parse(response(2))

            If isValid(a, b, map) Then
                map(a, b) = 2
                Exit While
            Else
                WriteLine("This block is already occupied By O , please choose another block. ")
                ReadKey()
            End If

        End While

    End Sub

    Function isValid(a As Integer, b As Integer, map(,) As Integer) As Boolean

        If map(a, b) = 1 Then
            Return False
        Else
            Return True
        End If

    End Function

    Function checkResult(map(,) As Integer, result As Integer, ByRef u1String As String, ByRef u2String As String) As Integer
        If u1Wins(map) Then
            Return 1
        ElseIf u2Wins(map) Then
            Return 2
        Else
            WriteLine("Match is Tied!")
            u1String &= 0
            u2String &= 0
            Return result
        End If
    End Function

    Function u1Wins(map(,) As Integer) As Boolean
        Return checkRow(map, 1) Or checkColoumn(map, 1) Or checkDiagonals(map, 1)
    End Function

    Function u2Wins(map(,) As Integer) As Boolean
        Return checkRow(map, 2) Or checkColoumn(map, 2) Or checkDiagonals(map, 2)
    End Function

    Function checkRow(map(,) As Integer, symbol As Integer) As Boolean
        Dim cnt As Integer

        For i As Integer = 0 To 2
            cnt = 0
            For j As Integer = 0 To 2
                If map(i, j) = symbol Then
                    cnt += 1
                End If
            Next
            If cnt = 3 Then
                Return True
            End If
        Next

    End Function

    Function checkColoumn(map(,) As Integer, symbol As Integer) As Boolean
        Dim cnt As Integer

        For i As Integer = 0 To 2
            cnt = 0
            For j As Integer = 0 To 2
                If map(j, i) = symbol Then
                    cnt += 1
                End If
            Next
            If cnt = 3 Then
                Return True
            End If
        Next

    End Function

    Function checkDiagonals(map(,) As Integer, symbol As Integer) As Boolean
        If map(0, 0) = symbol And map(1, 1) = symbol And map(2, 2) = symbol Then
            Return True
        ElseIf map(0, 2) = symbol And map(1, 1) = symbol And map(2, 0) = symbol Then
            Return True
        End If
    End Function

    Sub printResult(u1String, u2String)
        Dim total1, total2 As Integer

        WriteLine("Scores are : ")
        WriteLine("                                               _________________")
        WriteLine("                                               | User1 | User2 |")
        For i As Integer = 0 To u1String.Length - 1
            WriteLine("                                               |   " & u1String(i) & "   |   " & u2String(i) & "   |")
            If u1String(i) = "1" Then
                total1 += 1
            ElseIf u2String(i) = "1" Then
                total2 += 1
            End If
        Next
        WriteLine("                                               |_______|_______|")
        WriteLine("                                       Total :     " & total1 & "        " & total2)
        WriteLine()

        Write("Result :---------------------------------------> ")
        If total1 > total2 Then
            WriteLine("User 1 wins")
        ElseIf total2 > total1 Then
            WriteLine("User 2 wins")
        Else
            WriteLine("The whole Match is tied")
        End If

    End Sub

    Sub Main(args As String())
        Dim i As Integer
        Dim ch As Char = "y"
        Dim rand As New Random()
        Dim result As Integer = 1
        Dim u1String As String = ""
        Dim u2String As String = ""

        While ch = "y"
            Dim map(2, 2) As Integer
            i = 0
            WriteLine("User " & result & " Will Play First : ")

            If result = 1 Then
                u1(map, u1String, u2String)
            Else
                u2(map, u1String, u2String)
            End If

            result = checkResult(map, result, u1String, u2String)

            Write("Do you want to Play Again?(Y/N) : ")
            ch = ReadLine()
        End While

        printResult(u1String, u2String)

    End Sub
End Module