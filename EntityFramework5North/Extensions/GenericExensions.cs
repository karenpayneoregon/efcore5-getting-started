using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace NorthEntityLibrary.Extensions
{
    public static class GenericExensions
    {
        public static void ModeListToJson<TModel>(List<TModel> list, string fileName)
        {
            var json = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            File.WriteAllText(fileName, json);
        }
    }
}
