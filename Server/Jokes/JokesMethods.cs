using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class JokesMethods
    {
        private string path = System.IO.Path.GetFullPath($@"..\..\Jokes\jokes.json");
        private Random rnd;
        private List<Jokes> roots;
        private static int number;

        public string GetJokesSetup()
        {
            rnd = new Random();
            number = rnd.Next(0, 29);

            using (StreamReader file = new StreamReader(path))
            {
                string json = file.ReadToEnd();

                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                roots = JsonConvert.DeserializeObject<List<Jokes>>(json);

                return roots[number].setup;
            }
        }

        public string GetJokesPunchline()
        {
            using (StreamReader file = new StreamReader(path))
            {
                string json = file.ReadToEnd();

                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                roots = JsonConvert.DeserializeObject<List<Jokes>>(json);

                return roots[number].punchline;
            }
        }
    }
}
