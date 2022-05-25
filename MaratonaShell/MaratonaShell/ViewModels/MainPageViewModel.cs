using MaratonaShell.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using System.Windows.Input;
using MvvmHelpers.Commands;
using MaratonaShell.Services;

namespace MaratonaShell.ViewModels
{
    public class MainPageViewModel :BaseViewModel
    {
        public MainPageViewModel()
        {
            AdicionaNotaCommand = new Command(NovaNota);
            ExcluiTodasCommand = new Command(ExcluiTodas);
            notas = new ObservableRangeCollection<NoteModel>();
            bD = new JsonBD();
        }

        //commands 
        public ICommand ExcluiTodasCommand { get; }
        public ICommand AdicionaNotaCommand { get; }


        private JsonBD bD;
        public ObservableRangeCollection<NoteModel> notas { get; }

        string entrada;
        public string Entrada
        {
            get=> entrada;
            set => SetProperty(ref entrada, value);
        }


        //metodos para ser usado pelos Icommand

        void NovaNota()
        {
            notas.Add(new NoteModel(entrada,DateTime.Now));
            Entrada = string.Empty;
            bD.Serializador(notas);
        }
        private void ExcluiTodas()
        {
            notas.Clear();
        }

    }
}
