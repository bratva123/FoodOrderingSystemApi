Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Newtonsoft.Json
Imports FoodOrderingSystem

Namespace Controllers
    Public Class OrderController
        Inherits ApiController
        Dim orderOP As OrderOperation
        Dim resp As New HttpResponseMessage

        Public Sub New()
            orderOP = New OrderOperation
        End Sub

        'Public Function CreateOrder(ord As Order) As Integer Implements IOrderOperation.CreateOrder
        'Public Function UpdateOrder(ord As Order) As Integer Implements IOrderOperation.UpdateOrder
        'Public Function GetOrderById(id As Integer) As Order Implements IOrderOperation.GetOrderById
        'Public Function GetByUserId(userId As Integer) As List(Of Order) Implements IOrderOperation.GetByUserId
        'Public Function GetByPaymentId(userId As Integer) As Order Implements IOrderOperation.GetByPaymentId
        'Public Function GetByDate(orderDate As Date) As List(Of Order) Implements IOrderOperation.GetByDate
        'Public Function GetByUserIdAndDate(userId As Integer, orderDate As Date) As List(Of Order) Implements IOrderOperation.GetByUserIdAndDate
        <Route("api/Order/getByOrderId/{id}")>
        Public Function GetVaueByOrderId(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim order = orderOP.GetOrderById(id)
                Dim content = JsonConvert.SerializeObject(order)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        <Route("api/Order/getByUserIdDate/{id}/{dt}")>
        Public Function GetVaueByUserIdAndDate(ByVal id As Integer, dt As Date) As HttpResponseMessage
            Try
                Dim orders = orderOP.GetByUserIdAndDate(id, dt)
                Dim content = JsonConvert.SerializeObject(orders)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function
        <Route("api/Order/getByDate/{dt}")>
        Public Function GetVaueByOrderDate(ByVal dt As Date) As HttpResponseMessage
            Try
                Dim orders = orderOP.GetByDate(dt)
                Dim content = JsonConvert.SerializeObject(orders)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function
        <Route("api/Order/getByPaymentId/{id}")>
        Public Function GetValueByPayId(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim orders = orderOP.GetByPaymentId(id)
                Dim content = JsonConvert.SerializeObject(orders)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function
        <Route("api/Order/getByUserId/{id}")>
        Public Function GetValueByUserId(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim orders = orderOP.GetByUserId(id)
                Dim content = JsonConvert.SerializeObject(orders)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PostValue(<FromBody()> ByVal order As Order) As HttpResponseMessage
            Try
                Dim flag As Integer = orderOP.CreateOrder(order)
                resp.StatusCode = HttpStatusCode.Created
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PutValue(<FromBody()> ByVal order As Order) As HttpResponseMessage
            Try
                Dim flag As Integer = orderOP.UpdateOrder(order)
                resp.StatusCode = HttpStatusCode.Accepted
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try

            Return resp
        End Function

    End Class
End Namespace