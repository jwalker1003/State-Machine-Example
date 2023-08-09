Public Interface IStateGuard(Of T)

    ReadOnly Property Name As String

    Function CheckTransistion(obj As T) As Boolean

End Interface
