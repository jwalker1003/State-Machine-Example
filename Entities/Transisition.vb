Imports Interfaces

Public Class Transisition : Implements ITransition

    Public Sub New()
    End Sub

    Public Property CurrentState As IState Implements ITransition.CurrentState
    Public Property NextState As IState Implements ITransition.NextState

End Class