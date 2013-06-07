Namespace Logic

    Public Class Board : Implements ICloneable

        Private _Board(9, 9) As Cell
        Private _Rows(9) As Row
        Private _Columns(9) As Row
        Private _Blocks(9) As Row

        Friend Sub New()
            Dim RowIndex As Integer = 1
            Dim ColumnIndex As Integer = 1
            Dim BlockIndex As Integer = 1
            Dim Cell As Cell = Nothing
            Dim Row As Row = Nothing
            Dim Column As Row = Nothing
            Dim Block As Row = Nothing
            Dim LastRow As Row = Nothing
            Dim LastCell As Cell = Nothing
            Dim CellCount As Integer = 0

            '-------------------------------------------------------------
            'Initialize Board and Rows
            '-------------------------------------------------------------
            For RowIndex = 1 To 9

                Row = New Row
                LastCell = Nothing
                CellCount = 0

                For ColumnIndex = 1 To 9
                    Cell = New Cell
                    CellCount += 1

                    Cell.Board = Me
                    Cell.SequenceNumberInRow = CellCount
                    _Rows(RowIndex) = Row
                    Row.Cells(ColumnIndex) = Cell
                    _Board(RowIndex, ColumnIndex) = Cell
                    Cell.Row = Row

                    If LastCell IsNot Nothing Then LastCell.NextNode = Cell
                    LastCell = Cell
                Next

                If LastRow IsNot Nothing Then LastRow.NextNode = Row
                LastRow = Row
            Next
            '-------------------------------------------------------------

            LastRow = Nothing

            '-------------------------------------------------------------
            'Initialize Columns
            '-------------------------------------------------------------
            For ColumnIndex = 1 To 9

                Column = New Row

                If LastRow IsNot Nothing Then LastRow.NextNode = Column

                _Columns(ColumnIndex) = Column

                For RowIndex = 1 To 9

                    Cell = _Board(RowIndex, ColumnIndex)
                    Column.Cells(RowIndex) = Cell
                    Cell.Column = Column

                Next

                LastRow = Column
            Next
            '-------------------------------------------------------------

            LastRow = Nothing

            '-------------------------------------------------------------
            'Initialize Blocks
            '-------------------------------------------------------------
            Dim x As New List(Of Integer())
            Dim CellIndex As Integer = 1
            x.Add({1, 2, 3})
            x.Add({4, 5, 6})
            x.Add({7, 8, 9})

            For Each y() As Integer In x
                For Each z() As Integer In x

                    Block = New Row
                    CellIndex = 1

                    If LastRow IsNot Nothing Then LastRow.NextNode = Block

                    _Blocks(BlockIndex) = Block
                    BlockIndex += 1

                    For Each RowIndex In y
                        For Each ColumnIndex In z

                            Cell = _Board(RowIndex, ColumnIndex)
                            Block.Cells(CellIndex) = Cell
                            Cell.Block = Block
                            CellIndex += 1

                        Next
                    Next

                    LastRow = Block
                Next
            Next
            '-------------------------------------------------------------
        End Sub

        Public Overrides Function ToString() As String
            Dim Value As String = ""

            For I As Integer = 1 To 9
                Value += _Rows(I).ToString & vbNewLine
            Next

            Return Value.Trim(vbNewLine)
        End Function

        Public ReadOnly Property BoardIsSolved As Boolean
            Get
                Dim Value As Boolean = True

                For RowIndex As Integer = 1 To 9
                    For ColumnIndex As Integer = 1 To 9
                        If Cells(RowIndex, ColumnIndex).Value = 0 Then Value = False
                    Next
                Next

                Return Value
            End Get
        End Property

        Public ReadOnly Property Rows() As Row()
            Get
                Return _Rows
            End Get
        End Property

        Public ReadOnly Property Columns() As Row()
            Get
                Return _Columns
            End Get
        End Property

        Public ReadOnly Property Blocks() As Row()
            Get
                Return _Blocks
            End Get
        End Property

        Public ReadOnly Property Cells(ByVal RowIndex As Integer _
                                       , ByVal ColumnIndex As Integer) As Cell
            Get
                Return _Board(RowIndex, ColumnIndex)
            End Get
        End Property

        Public Sub Clear()
            For RowIndex As Integer = 1 To 9
                For ColumnIndex As Integer = 1 To 9
                    Me._Board(RowIndex, ColumnIndex).Value = 0
                Next
            Next
        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim BoardClone As New Board

            For rowIndex As Byte = 1 To 9
                For columnIndex As Byte = 1 To 9
                    BoardClone.Cells(rowIndex, columnIndex).Value = Me.Cells(rowIndex, columnIndex).Value
                Next
            Next

            Return BoardClone
        End Function
    End Class

End Namespace