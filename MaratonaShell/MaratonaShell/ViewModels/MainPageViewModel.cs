using MaratonaShell.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using System.Windows.Input;
using MvvmHelpers.Commands;
using MaratonaShell.Services;
using System.Threading.Tasks;

namespace MaratonaShell.ViewModels
{
    public class MainPageViewModel :BaseViewModel
    {

        //commands 
        public ICommand ExcluiTodasCommand { get; }
        public ICommand AdicionaNotaCommand { get; }
        public ICommand CarregaJsonComand { get; }
        public ICommand ExcluiEscolhidaCommand { get; }
        public ICommand EditaNotaCommand { get; }

        //Objetos 
        private JsonBD bD;
        public ObservableRangeCollection<NoteModel> notas { get; private set; }

        string entrada;
        public string Entrada
        {
            get => entrada;
            set => SetProperty(ref entrada, value);
        }

        public MainPageViewModel()
        {
            AdicionaNotaCommand = new Command(NovaNota);
            ExcluiTodasCommand = new Command(ExcluiTodas);
            CarregaJsonComand = new Command(CarregaJson);
            CarregaJsonComand = new AsyncCommand(AsyncRefresh);
            ExcluiEscolhidaCommand = new Command<NoteModel>(ExcluiEscolhida);
            EditaNotaCommand = new Command<NoteModel>(EditaNota);

            notas = new ObservableRangeCollection<NoteModel>();
            bD = new JsonBD();
            CarregaJson();

        }





        //metodos para ser usado pelos Icommand

        void EditaNota(NoteModel recebido)
        {
            Entrada = recebido.Texto;
            ExcluiEscolhida(recebido);
        }
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
         void ExcluiEscolhida(NoteModel recebido)
        {
            //var teste = notas.Where(x=>x.Hora == recebido.Hora);
            if (notas.Contains(recebido)) 
            notas.Remove(recebido);

            bD.Serializador(notas);
            var teste = new ObservableRangeCollection<NoteModel>();
            teste = bD.Deserializador();
            if (teste != null)
            {
                notas.Clear();
                notas.AddRange(teste);
                //notas = teste;
            }

            IsBusy = false;
        }

        async Task AsyncRefresh()
        {

            IsBusy = true;
            await Task.Delay(3000);
            CarregaJson();
            IsBusy = false;
        }

        void CarregaJson()
        {
            var teste = new ObservableRangeCollection<NoteModel>();
            teste = bD.Deserializador();
            if (teste != null)
            {
                notas.Clear();
                notas.AddRange(teste);
                //notas = teste;
            }
        }

    }
}
