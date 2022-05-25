using System;
using System.Collections.Generic;
using System.Text;
namespace MaratonaShell.Models
{
    public class NoteModel
    {
        public string Texto { get; set; }
        public DateTime Hora{get; set;}

        public NoteModel(string textoRecebido)
        {
            Hora = DateTime.Now;
            Texto = textoRecebido;
        }
        public NoteModel(string texto, DateTime hora)
        {
            Texto = texto;
            Hora = hora;
        }
    }
}
