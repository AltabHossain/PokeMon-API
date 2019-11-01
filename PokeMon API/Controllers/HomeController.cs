using Newtonsoft.Json.Linq;
using PokeMon_API.Models;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace PokeMon_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Create the request to the API
            WebRequest request = WebRequest.Create("http://pokeapi.co/api/v2/pokemon/534/");
            //Send the request off
            WebResponse response = request.GetResponse();
            //Get back the response stream
            Stream stream = response.GetResponseStream();
            //Make it accessible
            StreamReader reader = new StreamReader(stream);
            //Put into string which is json formatted
            string responseFromServer = reader.ReadToEnd();

            JObject parsedString = JObject.Parse(responseFromServer);

            Pokemon myPokemon = parsedString.ToObject<Pokemon>();

            //Debug.WriteLine(myPokemon.moves[0].move.name);

            return View(myPokemon);
        }
    }
}