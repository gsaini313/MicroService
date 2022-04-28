using Microsoft.AspNetCore.Mvc;
using System.IO;
using YamlDotNet.Serialization;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class Ephemeral : ControllerBase
    {
        // GET: api/<EphemeralController>
        [HttpGet]
        public object Get()
        {
            new WebClient().DownloadFile("https://raw.githubusercontent.com/gsaini313/configsettings/main/provision_ephemeral_config.yml", "EphemeralConfig.yaml");
        
            var yamlfile = new StreamReader("EphemeralConfig.yaml");
            var yaml = new Deserializer();
            var Resultobject = yaml.Deserialize(yamlfile);
            yamlfile.Close();

            System.IO.FileInfo ConfigFile = new System.IO.FileInfo("EphemeralConfig.yaml");
            ConfigFile.Delete();

            return Resultobject;
        }
    }
}
