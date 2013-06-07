Namespace Logic

    Public Class Cell

        Friend Sub New()

        End Sub

        Public Overrides Function ToString() As String
            Return _Value
        End Function

        'Value of Cell
        Private _Value As Integer = 0

        Public Function PossibleValues(ByRef value As Integer) As Boolean

            If Me.Value = 0 Then
                Return Row.PossibleValues(value) AndAlso Column.PossibleValues(value) AndAlso Block.PossibleValues(value)
            Else
                Return Me.Value = value
            End If

        End Function

        Public Function PossibleValues() As List(Of Integer)

            Dim Values As New List(Of Integer)

            For i As Integer = 1 To 9
                If Me.PossibleValues(i) Then
                    Values.Add(i)
                End If
            Next

            Return Values

        End Function

        Public Function PossibleValuesCount() As Integer

            Dim Count As Integer = 0

            For i As Integer = 1 To 9
                If PossibleValues(i) Then
                    Count += 1
                End If
            Next

            Return Count

        End Function


        Public Property Value As Integer
            Get
                Return _Value
            End Get
            Set(ByVal value As Integer)

                If value = _Value Then
                    Exit Property
                ElseIf value > 0 Then
                    Me.Row.PossibleValues(value) = False
                    Me.Column.PossibleValues(value) = False
                    Me.Block.PossibleValues(value) = False
                End If

                Me.Row.PossibleValues(_Value) = True
                Me.Column.PossibleValues(_Value) = True
                Me.Block.PossibleValues(_Value) = True

                _Value = value
            End Set
        End Property

        'Point to the Row, Column and Block that this cell belongs to.
        Public Property Row As Row = Nothing
        Public Property Column As Row = Nothing
        Public Property Block As Row = Nothing
        Public Property Board As Board = Nothing
        Public Property SequenceNumberInRow As Integer = 0
        Public Property NextNode As Cell = Nothing

    End Class

End Namespace


