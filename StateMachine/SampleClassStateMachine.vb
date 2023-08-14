Imports Interfaces

Public Class SampleClassStateMachine : Implements IStateMachine(Of ISampleClass)

    Private Property GuardsContainerProp As GuardsContainer
    Private Property Transistions As IList(Of ITransition)

    Public Sub New(_guardsContainer As GuardsContainer,
                   _transitions As IList(Of ITransition))

        GuardsContainerProp = _guardsContainer
        Transistions = _transitions

        'ConfigureStates()
    End Sub

    Public Sub NextState(ByRef sampleClass As ISampleClass) Implements IStateMachine(Of ISampleClass).NextState
        Try
            ' Set ByRef var to local var
            Dim tempSampleClass = sampleClass

            ' Get Next Transition
            Dim transistion = Transistions.FirstOrDefault(Function(f) f.CurrentState.Id = tempSampleClass.State.Id)

            ' If transistion exists, set the object state to next state
            If transistion IsNot Nothing Then

                ' If Guards are implemented
                If GuardsContainerProp.Guards.Count() > 0 Then

                    ' Check Guards
                    For Each guard As IStateGuard(Of ISampleClass) In GuardsContainerProp.Guards
                        If guard.CheckTransistion(tempSampleClass) = False Then
                            Console.WriteLine(String.Format("Guard {0} failed.", guard.Name))
                            Exit Try
                        End If

                        ' Transistion to next state
                        sampleClass.State = transistion.NextState
                        Exit Try
                    Next
                End If

                ' Transistion to next state
                sampleClass.State = transistion.NextState
            Else
                Throw New NotImplementedException()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub
End Class