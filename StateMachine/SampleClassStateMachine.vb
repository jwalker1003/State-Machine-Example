Imports Entities
Imports Interfaces

Public Class SampleClassStateMachine : Implements IStateMachine(Of ISampleClass)

    Public Property GuardsContainerProp As GuardsContainer

    Public Sub New(_guardsContainer As GuardsContainer)
        GuardsContainerProp = _guardsContainer

        ConfigureStates()
    End Sub

    Private Property Transistions As IList(Of ITransition) Implements IStateMachine(Of ISampleClass).Transistions

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

    Private Sub ConfigureStates() Implements IStateMachine(Of ISampleClass).ConfigureStates

        Dim name As String = [Enum].GetName(GetType(States), States.Start)

        Dim state1 = New State() With {.Id = States.Start, .Name = [Enum].GetName(GetType(States), States.Start)}
        Dim state2 = New State() With {.Id = States.InProgress, .Name = [Enum].GetName(GetType(States), States.InProgress)}
        Dim state3 = New State() With {.Id = States.Complete, .Name = [Enum].GetName(GetType(States), States.Complete)}

        Transistions = New List(Of ITransition) From {
            New Transisition With {
                .CurrentState = state1,
                .NextState = state2
            },
            New Transisition With {
                .CurrentState = state2,
                .NextState = state3
            }
        }
    End Sub

End Class