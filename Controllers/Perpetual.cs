using Microsoft.AspNetCore.Mvc;
using System.IO;
using YamlDotNet.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class Perpetual : ControllerBase
    {
        // GET: api/<Perpetual>
        [HttpGet]
        public object Get()
        {
            var yamlfile = new StreamReader("ConfigurationSettings\\Perpetual\\provision_perpetual_config.yml");
            var yaml = new Deserializer();
            var Resultobject = yaml.Deserialize(yamlfile);

            return Resultobject;
        }
    }
}
