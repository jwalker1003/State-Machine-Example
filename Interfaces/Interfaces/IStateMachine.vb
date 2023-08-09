Public Interface IStateMachine(Of T)

    ' ***********
    ' Properties 
    ' ***********
    Property Transistions As IList(Of ITransition)

    ' **********
    ' Functions 
    ' **********
    Sub NextState(ByRef obj As T)
    Sub ConfigureStates()

End Interface
