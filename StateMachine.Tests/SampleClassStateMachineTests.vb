Imports Entities
Imports Interfaces
Imports NUnit.Framework

<TestFixture>
Public Class SampleClassStateMachineTests

    ''' <summary>
    ''' Test the NextState function sufficiently transistions to the next appropriate state
    ''' </summary>
    ''' <param name="value"></param>
    <TestCase(0)>
    Public Sub TestStateIsChanged(value As Integer)
        Dim testState = New TestState With {.Id = States.Start, .Name = States.Start.ToString()}
        Dim testSampleClass As ISampleClass = New TestSampleClass With {.Id = value, .State = testState}

        Dim state1 = New State() With {.Id = States.Start, .Name = [Enum].GetName(GetType(States), States.Start)}
        Dim state2 = New State() With {.Id = States.InProgress, .Name = [Enum].GetName(GetType(States), States.InProgress)}
        Dim state3 = New State() With {.Id = States.Complete, .Name = [Enum].GetName(GetType(States), States.Complete)}

        Dim transitions = New List(Of ITransition) From {
            New Transisition With {
                .CurrentState = state1,
                .NextState = state2
            },
            New Transisition With {
                .CurrentState = state2,
                .NextState = state3
            }
        }
        Dim sampleClassStateMachine = New SampleClassStateMachine(New GuardsContainer(), transitions)

        sampleClassStateMachine.NextState(testSampleClass)

        Assert.AreEqual(States.InProgress.ToString, testSampleClass.State.Name)

    End Sub

End Class