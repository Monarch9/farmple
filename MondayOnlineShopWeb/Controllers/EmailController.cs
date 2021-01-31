/*using System.IO;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using BOL;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Net.Http;

namespace MondayOnlineShopWeb.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/email")]
    public class EmailController : ApiController
    {
        [HttpPost]
        [Route("send-email")]
        public async Task SendEmail([FromBody] JObject objData)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(objData["toname"].ToString() + " <" + objData["toemail"].ToString() + ">"));
            message.From = new MailAddress("farmple <farmpletheemy@email.com>");
            message.Bcc.Add(new MailAddress("farmple <farmpletheemy@email.com>"));
            message.Subject = objData["subject"].ToString();
            message.Body = createEmailBody(objData["toname"].ToString(), objData["message"].ToString());
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())//
            {
                await smtp.SendMailAsync(message);
                await Task.FromResult(0);
            }
        }

        private string createEmailBody(string userName, string message)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/htmlTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);
            body = body.Replace("{message}", message);
            return body;
        }



        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EmailModel model)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url    
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format    
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service using HttpClient    
                HttpResponseMessage Res = await client.PostAsJsonAsync("api/email/send-email", model);

                //Checking the response is successful or not which is sent using HttpClient    
                if (Res.IsSuccessStatusCode)
                {
                    return View("Success");
                }
                else
                {
                    return View("Error");
                }
            }
        }
    }
}*/