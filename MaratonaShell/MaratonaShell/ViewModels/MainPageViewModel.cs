using MaratonaShell.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using System.Windows.Input;
using MvvmHelpers.Commands;

namespace MaratonaShell.ViewModels
{
    public class MainPageViewModel :BaseViewModel
    {
        public MainPageViewModel()
        {
            AdicionaNotaCommand = new Command(NovaNota);
            ExcluiTodasCommand = new Command(ExcluiTodas);
            notas = new ObservableRangeCollection<NoteModel>();
            //listaNotas = new ObservableRangeCollection<Grouping<string, NoteModel>>();
        }

        //commands 
        public ICommand ExcluiTodasCommand { get; }
        public ICommand AdicionaNotaCommand { get; }


        //public List<NoteModel> listaNotas = new List<NoteModel>();
        //public ObservableRangeCollection<Grouping<string,NoteModel>> listaNotas { get; }

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
            //listaNotas.Add(new NoteModel(Entrada));
            notas.Add(new NoteModel(entrada));
            Entrada = string.Empty;
        }
        private void ExcluiTodas()
        {
            notas.Clear();
        }

    }
}
