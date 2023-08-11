Imports Interfaces

Public Class SampleClass : Implements ISampleClass

    Public Sub New()
    End Sub

    Public Property Id As Integer Implements Interfaces.ISampleClass.Id
    Public Property State As IState Implements Interfaces.ISampleClass.State
End Class