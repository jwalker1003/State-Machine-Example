Imports Interfaces

Public Class State : Implements IState

    Public Sub New()
    End Sub

    Public Property Id As Integer Implements IState.Id
    Public Property Name As String Implements IState.Name

End Class
