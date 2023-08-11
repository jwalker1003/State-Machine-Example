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
        Dim sampleClassStateMachine = New SampleClassStateMachine(New GuardsContainer)

        sampleClassStateMachine.NextState(testSampleClass)

        Assert.AreEqual(States.InProgress.ToString, testSampleClass.State.Name)

    End Sub

End Class