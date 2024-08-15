// WebhookController.cs
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

[Route("api/[controller]")]
[ApiController]
public class WebhookController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromBody] JObject request)
    {
        var queryResult = request["queryResult"];
        var intent = queryResult["intent"]["displayName"].ToString();

        string responseText = "Bunu anlayamadım, lütfen tekrar deneyin.";

        if (intent == "Merhaba")
        {
            responseText = "Merhaba! Size nasıl yardımcı olabilirim?";
        }
        else if (intent == "Bağış Nasıl Yapılır")
        {
            responseText = "Bağış yapmak için bağış yapmak istediğiniz gönderinin üzerindeki 'Bağış Yap' butonuna tıklayabilirsiniz.";
        }

        var response = new
        {
            fulfillmentText = responseText
        };

        return Ok(response);
    }
}
