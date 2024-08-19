using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuExpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        // POST api/<PersonaController>
        [HttpPost]
        public List<Client> Post(Client client)
        {
            List<Client> lista = new List<Client>();
            for (int i = 0; i < 10; i++)
            {
                lista.Add(client);
            }
            return lista;
        }

    }
}
