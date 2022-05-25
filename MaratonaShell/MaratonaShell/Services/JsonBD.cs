using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using MaratonaShell.Models;

namespace MaratonaShell.Services
{
    public class JsonBD
    {
        readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Arquivo.json");
        public void Serializador(ObservableRangeCollection<NoteModel> colecao)
        {
            string json = JsonConvert.SerializeObject(colecao);
            SalvaJson(json);

        }
        void SalvaJson(string json)
        {
            File.WriteAllText(path, json);
        }


        public void Deserializador()
        {

        }
    }
}
