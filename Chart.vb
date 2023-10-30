Imports System.Console
Imports System
Imports System.Numerics

Module Program

    Sub lines()
        WriteLine()
        WriteLine("--------------------------------------------------------------------------------------")
        WriteLine()
    End Sub

    Function takeInp() As Integer()

        Dim a(5) As Integer

        For i As Integer = 0 To 5
            a(i) = ReadLine()
        Next

        Return a

    End Function

    Function getMax(a() As Integer) As Integer
        Dim maxx As Integer

        For i As Integer = 0 To 5
            If i = 0 Then
                maxx = a(i)
            Else
                If maxx < a(i) Then
                    maxx = a(i)
                End If
            End If
        Next

        Return maxx

    End Function

    Sub print1(a() As Integer, ch As Char, maxx As Integer)

        For i As Integer = maxx To 1 Step -1

            For j As Integer = 0 To 5

                If a(j) = maxx Then
                    Write(ch)
                    a(j) -= 1
                Else
                    Write(" ")
                End If

            Next

            maxx -= 1
            WriteLine()

        Next
    End Sub

    Sub print2(a() As Integer, b() As Integer, mx1 As Integer, mx2 As Integer, ch As Char, ch2 As Char)
        If mx2 > mx1 Then
            For i As Integer = mx2 To 1 Step -1

                For j As Integer = 0 To 5

                    If b(j) = mx2 Then
                        Write(ch2)
                        b(j) -= 1
                    Else
                        Write(" ")
                    End If

                    If a(j) = mx1 Then
                        Write(ch)
                        a(j) -= 1
                    Else
                        Write(" ")
                    End If

                Next

                mx2 -= 1
                mx1 -= 1
                WriteLine()
            Next
        Else
            For i As Integer = mx1 To 1 Step -1

                For j As Integer = 0 To 5

                    If b(j) = mx2 Then
                        Write(ch2)
                        b(j) -= 1
                    Else
                        Write(" ")
                    End If

                    If a(j) = mx1 Then
                        Write(ch)
                        a(j) -= 1
                    Else
                        Write(" ")
                    End If

                    Write(" ")
                Next

                mx2 -= 1
                mx1 -= 1
                WriteLine()
            Next
        End If
    End Sub

    Sub Main(args As String())

        WriteLine("Enter array one's numbers : ")
        Dim a() As Integer = takeInp()
        Dim maxx As Integer = getMax(a)

        WriteLine()

        Write("Enter character to display in chart : ")
        Dim ch As Char = ReadLine()

        lines()

        WriteLine("Enter array Two's numbers : ")
        Dim b() As Integer = takeInp()
        Dim maxx2 As Integer = getMax(b)

        WriteLine()

        WriteLine("Enter character to display in chart : ")
        Dim ch2 As Char = ReadLine()

        lines()

        Dim aa(5) As Integer
        Dim bb(5) As Integer
        Dim mx1 As Integer = maxx
        Dim mx2 As Integer = maxx2
        Array.Copy(a, aa, 6)
        Array.Copy(b, bb, 6)



        WriteLine("Chart is as follows :- ")

        print1(a, ch, maxx)
        lines()
        print1(b, ch2, maxx2)
        lines()

        print2(aa, bb, mx1, mx2, ch, ch2)

    End Sub
End Module
