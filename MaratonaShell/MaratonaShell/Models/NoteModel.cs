using System;
using System.Collections.Generic;
using System.Text;
namespace MaratonaShell.Models
{
    public class NoteModel
    {
        string texto;
        DateTime hora;
        public string Texto
        {
            get { return texto; }
        }
        public string Hora
        {
            get { return hora.ToString(); }
        }

        public NoteModel(string textoRecebido)
        {
            hora = DateTime.Now;
            texto = textoRecebido;
        }
    }
}
