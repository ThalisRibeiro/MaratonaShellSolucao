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
            CarregaJsonComand = new Command(CarregaJson);

            notas = new ObservableRangeCollection<NoteModel>();
            bD = new JsonBD();
            CarregaJson();

        }

        //commands 
        public ICommand ExcluiTodasCommand { get; }
        public ICommand AdicionaNotaCommand { get; }
        public ICommand CarregaJsonComand { get; }

        private JsonBD bD;
        public ObservableRangeCollection<NoteModel> notas { get; private set; }

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
        void CarregaJson()
        {
            var teste = new ObservableRangeCollection<NoteModel>();
            teste = bD.Deserializador();
            if (teste == null)
                return;
            notas = teste;
        }

    }
}
