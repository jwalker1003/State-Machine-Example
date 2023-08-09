Imports Interfaces
Imports NUnit.Framework

<TestFixture>
Public Class GuardTests

    Public Property IdNotOneGuard As IdNotOneGuard = New IdNotOneGuard()

    ''' <summary>
    ''' Test the guard always returns true when Id is not 1
    ''' </summary>
    ''' <param name="value"></param>
    <TestCase(-1)>
    <TestCase(2)>
    Public Sub TestIdNotOneGuard(value As Integer)
        Dim testSampleClass As ISampleClass = New TestSampleClass With {.Id = value}

        Dim result As Boolean = IdNotOneGuard.CheckTransistion(testSampleClass)

        Assert.IsTrue(result)
    End Sub

    ''' <summary>
    ''' Test the guard returns false when the Id is 1
    ''' </summary>
    <Test>
    Public Sub TestIdIsOneGuard()
        Dim testSampleClass As ISampleClass = New TestSampleClass With {.Id = 1}

        Dim result As Boolean = IdNotOneGuard.CheckTransistion(testSampleClass)

        Assert.IsFalse(result)
    End Sub

End Class
