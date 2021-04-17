Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Newtonsoft.Json
Imports FoodOrderingSystem

Namespace Controllers
    Public Class PaymentController
        Inherits ApiController

        Dim payOp As PaymentOperation
        Dim resp As New HttpResponseMessage


        Public Sub New()
            payOp = New PaymentOperation
        End Sub

        Public Function GetValues() As HttpResponseMessage
            Try
                Dim pays = payOp.GetAll()
                Dim content = JsonConvert.SerializeObject(pays)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NoContent
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function GetValue(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim pay = payOp.GetById(id)
                Dim content = JsonConvert.SerializeObject(pay)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PostValue(<FromBody()> ByVal pay As Payment) As HttpResponseMessage
            Try
                Dim flag As Integer = payOp.Add_Payment(pay)
                resp.StatusCode = HttpStatusCode.Created
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function
    End Class
End Namespace