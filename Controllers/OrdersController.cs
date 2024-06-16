using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public IActionResult PlaceOrder([FromHeader(Name = "x-api-key")] string apiKey, [FromBody] OrderRequest orderRequest)
    {
        if (apiKey != "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf")
        {
            return StatusCode(403, new ErrorResponse { Error = "x-api-key header missing or invalid" });
        }

        if (string.IsNullOrEmpty(orderRequest.BrothId) || string.IsNullOrEmpty(orderRequest.ProteinId))
        {
            return StatusCode(400, new ErrorResponse { Error = "both brothId and proteinId are required" });
        }

        if (string.IsNullOrEmpty(orderRequest.BrothId) || string.IsNullOrEmpty(orderRequest.ProteinId))
        {
            return StatusCode(500, new ErrorResponse { Error = "could not place order" });
        }

        var orderId = GenerateOrderId();

        var orderResponse = new OrderResponse
        {
            Id = orderId,
            Description = $"Order for {orderRequest.BrothId} with {orderRequest.ProteinId}",
            Image = "https://tech.redventures.com.br/icons/order.png"
        };

        if (orderId == null)
        {
            return StatusCode(500, new ErrorResponse { Error = "could not place order" });
        }

        return StatusCode(201, orderResponse);
    }
    private string GenerateOrderId()
    {
        return Guid.NewGuid().ToString();
    }
}
