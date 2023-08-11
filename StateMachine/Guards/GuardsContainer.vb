Imports Interfaces

Public Class GuardsContainer

    Public Sub New()
        Guards = New List(Of IStateGuard(Of ISampleClass)) From {
            New IdNotOneGuard()
        }
    End Sub

    Public Property Guards As IList(Of IStateGuard(Of ISampleClass))

End Class