Imports Interfaces

Public Class TestSampleClass : Implements ISampleClass

    Public Sub New()
    End Sub

    Public Property Id As Integer Implements ISampleClass.Id
    Public Property State As IState Implements ISampleClass.State

End Class