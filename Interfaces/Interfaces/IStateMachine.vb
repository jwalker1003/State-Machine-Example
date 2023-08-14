Public Interface IStateMachine(Of T)

    ' **********
    ' Functions
    ' **********
    Sub NextState(ByRef obj As T)

End Interface