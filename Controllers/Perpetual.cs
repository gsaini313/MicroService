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
    public class Perpetual : ControllerBase
    {
        // GET: api/<Perpetual>
        [HttpGet]
        public object Get()
        {
            new WebClient().DownloadFile("https://raw.githubusercontent.com/gsaini313/configsettings/main/provision_perpetual_config.yml", "PerpetualConfig.yaml");

            var yamlfile = new StreamReader("PerpetualConfig.yaml");
            var yaml = new Deserializer();
            var Resultobject = yaml.Deserialize(yamlfile);
            yamlfile.Close();

            System.IO.FileInfo ConfigFile = new System.IO.FileInfo("PerpetualConfig.yaml");
            ConfigFile.Delete();

            return Resultobject;
        }
    }
}
