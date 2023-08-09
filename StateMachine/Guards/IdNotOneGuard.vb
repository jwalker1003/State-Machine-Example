Imports Interfaces

Public Class IdNotOneGuard : Implements IStateGuard(Of ISampleClass)

    Public Sub New()
    End Sub

    Public ReadOnly Property Name As String = "IdNotOneGuard" Implements IStateGuard(Of ISampleClass).Name

    Public Function CheckTransistion(sampleClass As ISampleClass) As Boolean Implements IStateGuard(Of ISampleClass).CheckTransistion
        Try

            If sampleClass.Id = 1 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Return False
        End Try
    End Function
End Class
