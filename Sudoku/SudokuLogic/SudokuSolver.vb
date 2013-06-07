Namespace Logic

    Public Class SudokuSolver

        Private _Board As New Board
        Public ReadOnly Property Board As Board
            Get
                Return _Board
            End Get
        End Property

        Public Delegate Sub SolutionFoundDelegate(ByVal Board As Board)

        ''' <summary>
        ''' <para>Summary: Finds the first solution to the board.</para>
        ''' <para>Returns: Boolean value indicating if a solution was found.</para>
        ''' <para>Remarks: The SolutionFound delegate is invoked when a solution has been found.</para>
        ''' </summary>
        Public Function Solve(Optional SolutionFound As SolutionFoundDelegate = Nothing) As Boolean

            Dim OriginalBoard As Board = _Board.Clone

            'Use common sudoku strategies to fill board 
            FindValues()

            'Was that enough?
            If Board.BoardIsSolved Then
                If SolutionFound <> Nothing Then SolutionFound.Invoke(Me.Board)
                _Board = OriginalBoard
                Return True
            Else
                'Nope ok, we will use brute force 
                Return SolveByBruteForce(False, SolutionFound)
            End If

        End Function

        ''' <summary>
        ''' <para>Summary: Finds the all solutions to the board.</para>
        ''' <para>Returns: Boolean value indicating if a solution was found.</para>
        ''' <para>Remarks: The SolutionFound delegate is invoked when a solution has been found.</para>
        ''' </summary>
        Public Function SolveForAllSolutions(Optional SolutionFound As SolutionFoundDelegate = Nothing) As Boolean

            'Use Brute force to find all possible solutions
            Return SolveByBruteForce(True, SolutionFound)

        End Function

        Private Sub FindValues()

            Dim ValueFound As Boolean = True

            While ValueFound

                ValueFound = False

                For i As Integer = 1 To 9

                    If FindValues(Board.Blocks(i)) Then ValueFound = True
                    If FindValues(Board.Rows(i)) Then ValueFound = True
                    If FindValues(Board.Columns(i)) Then ValueFound = True
                    If FillInCellsWithOnlyOneValue() Then ValueFound = True

                Next

            End While

        End Sub

        Private Function FillInCellsWithOnlyOneValue() As Boolean

            Dim ValueFound As Boolean

            For RowIndex As Integer = 1 To 9
                For ColumnIndex As Integer = 1 To 9
                    With Board.Cells(RowIndex, ColumnIndex)
                        If .Value = 0 AndAlso .PossibleValuesCount = 1 Then
                            For i As Integer = 1 To 9
                                If .PossibleValues(i) Then
                                    .Value = i
                                    ValueFound = True
                                End If
                            Next
                        End If
                    End With
                Next
            Next

            Return ValueFound

        End Function

        Private Function FindValues(ByRef Value As Row) As Boolean

            Dim ValueFound As Boolean
            Dim ValuesFound(2, 9) As Boolean

            For Cell As Integer = 1 To 9
                If Value.Cells(Cell).Value > 0 Then
                    ValuesFound(2, Value.Cells(Cell).Value) = True
                Else
                    For i As Integer = 1 To 9
                        If Value.Cells(Cell).PossibleValues(i) Then
                            If ValuesFound(1, i) Then
                                ValuesFound(2, i) = True
                            Else
                                ValuesFound(1, i) = True
                            End If
                        End If
                    Next
                End If
            Next

            For i As Integer = 1 To 9
                If Not ValuesFound(2, i) Then
                    For Cell As Integer = 1 To 9
                        If Value.Cells(Cell).PossibleValues(i) Then
                            ValueFound = True
                            Value.Cells(Cell).Value = i
                        End If
                    Next
                End If
            Next

            Return ValueFound

        End Function

        Private Function SolveByBruteForce(ByRef FindAllSolutions As Boolean, ByRef SolutionFound As SolutionFoundDelegate) As Boolean

            Dim Last As Row = Nothing

            'Adjust Next Row Pointers to optimize performance
            Dim OptimizedRowOrder = (From Row As Row In _Board.Rows Where Row IsNot Nothing _
                                     Order By Row.PossibleValuesCount Ascending)

            For i As Integer = 0 To 8

                OptimizedRowOrder(i).NextNode = Nothing
                If Last IsNot Nothing Then Last.NextNode = OptimizedRowOrder(i)
                Last = OptimizedRowOrder(i)

            Next

            Return SolveByBruteForce(OptimizedRowOrder(0).Cells(1), OptimizedRowOrder(0), FindAllSolutions, False, False, SolutionFound)

        End Function

        Private Function SolveByBruteForce(ByRef Cell As Cell, ByRef Row As Row _
                          , ByRef FindAllSolutions As Boolean _
                          , ByRef Quit As Boolean _
                          , ByRef AtLeastOneSolutionFound As Boolean _
                          , ByRef SolutionFound As SolutionFoundDelegate) As Boolean

            If Cell Is Nothing Then
                If Row.NextNode Is Nothing Then
                    AtLeastOneSolutionFound = True
                    If SolutionFound <> Nothing Then SolutionFound.Invoke(Me.Board)
                    Quit = Not FindAllSolutions
                Else
                    SolveByBruteForce(Row.NextNode.Cells(1), Row.NextNode, FindAllSolutions, Quit, AtLeastOneSolutionFound, SolutionFound)
                End If
            Else
                If Cell.Value <> 0 Then
                    SolveByBruteForce(Cell.NextNode, Cell.Row, FindAllSolutions, Quit, AtLeastOneSolutionFound, SolutionFound)
                Else
                    For PossibleValue As Integer = 1 To 9
                        If Cell.PossibleValues(PossibleValue) Then
                            Dim OriginalValue As Integer = Cell.Value
                            Cell.Value = PossibleValue
                            SolveByBruteForce(Cell.NextNode, Cell.Row, FindAllSolutions, Quit, AtLeastOneSolutionFound, SolutionFound)
                            Cell.Value = OriginalValue
                        End If
                        If Quit Then Return AtLeastOneSolutionFound
                    Next
                End If
            End If

            Return AtLeastOneSolutionFound

        End Function

    End Class

End Namespace


