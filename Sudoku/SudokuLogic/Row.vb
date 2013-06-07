Namespace Logic

    Public Class Row

        Public PossibleValues() As Boolean = {True, True, True, True, True, True, True, True, True, True}

        Public NextNode As Row = Nothing

        Private _Cells(9) As Cell

        Friend Sub New()

        End Sub

        Public ReadOnly Property Cells() As Cell()
            Get
                Return _Cells
            End Get
        End Property

        Public Property Cells(ByVal CellIndex As Integer) As Cell
            Get
                Return _Cells(CellIndex)
            End Get
            Set(ByVal Cell As Cell)
                _Cells(CellIndex) = Cell
            End Set
        End Property

        Public Overrides Function ToString() As String
            Dim Value As String = ""

            For I As Integer = 1 To 9
                Value += _Cells(I).Value & " "
            Next

            Return Value.Trim
        End Function

        Public ReadOnly Property PossibleValuesCount As Integer
            Get
                Dim Count As Integer

                For i As Integer = 1 To 9
                    Count += _Cells(i).PossibleValuesCount
                Next

                Return Count
            End Get
        End Property

    End Class

End Namespace