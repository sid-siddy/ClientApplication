using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ClientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientResponseController : ControllerBase
    {
        private readonly ILogger<ClientResponseController> _logger;
        private IDataAccess<AuditRequest> ctx;
        public ClientResponseController(ILogger<ClientResponseController> logger, IDataAccess<AuditRequest> dataAccess)
        {
            _logger = logger;
            ctx = dataAccess;
        }
        [HttpGet]
        public IEnumerable<AuditRequest> GetResponses()
        {
            return ctx.GetAll();
        }
        [HttpPost]
        public void PostResponse(AuditRequest a)
        {
            ctx.Insert(a);
        }
        [HttpPut]
        public void updateResponse(AuditRequest b)
        {
            ctx.Update(b);
            Addresponsetotheaudit(b);
        }
        [HttpDelete]
        public void DeleteResponse(int Id)
        {
            ctx.Delete(Id);
        }
        [NonAction]
        public void Addresponsetotheaudit(AuditRequest areq)
        {
            string connectionStringServiceBus = "Endpoint=sb://auditclientsvcbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gdscIK81jFx39jlud7mcAXPw7WdftY4YqTAJvElo7KM=";
            string queueName = "clienttoauditqueue";

            SendMessage(connectionStringServiceBus, queueName, areq).GetAwaiter().GetResult();
        }
        [NonAction]
        static async Task SendMessage(string connectionStringServiceBus, string queueName, AuditRequest areq)
        {
            QueueClient queueClient = new QueueClient(connectionStringServiceBus, queueName);

            string messageBody = JsonConvert.SerializeObject(areq);//+"|"+areq.RequestId;
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            await queueClient.SendAsync(message);
            await queueClient.CloseAsync();
        }
    }
}
