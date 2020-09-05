using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private IDataAccess<ClientUser> ctx;
     
        public ClientController(ILogger<ClientController> logger, IDataAccess<ClientUser> dataAccess)
        {
            _logger = logger;
            ctx = dataAccess;
        }
        [HttpGet]
        public IEnumerable<ClientUser> GetClients()
        {
            return ctx.GetAll();
        }
        [HttpPost]
        public void PostClient(ClientUser a)
        {
            ctx.Insert(a);
        }
        [HttpPut]
        public void updateClient(ClientUser b)
        {
            ctx.Update(b);
        }
        [HttpDelete]
        public void DeleteCleint(int Id)
        {
            ctx.Delete(Id);
        }
    }
}
