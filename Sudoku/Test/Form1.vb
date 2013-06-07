Imports Sudoku.Logic

Public Class Form1

    Private Sub display(Board As Board)
        MsgBox(Board.ToString)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim ss As New SudokuSolver

        With ss.Board
            .Cells(1, 1).Value = 8
            .Cells(1, 2).Value = 6
            .Cells(1, 3).Value = 9
        End With

        ss.Solve(AddressOf display)

    End Sub

End Class
