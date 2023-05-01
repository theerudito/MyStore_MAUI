using MyStore_MAUI.Base;
using System.Windows.Input;

namespace MyStore_MAUI.ViewModel
{
    internal class Helper : BaseViewModel
    {
        #region CONSTRUCTOR

        public Helper()
        {
        }

        #endregion CONSTRUCTOR

        #region VARIABLES

        private string _Text;

        #endregion VARIABLES

        #region OBJETO

        public string Text
        {
            get { return _Text; }
            set { SetValue(ref _Text, value); }
        }

        #endregion OBJETO

        #region METODOS ASYNC

        public async Task MetodoAsincrono()
        {
            await Task.Delay(1000);
            Text = "Hola Mundo";
        }

        #endregion METODOS ASYNC

        #region METODOS SIMPLE

        public void MetodoSimple()
        {
            Text = "Hola Mundo";
        }

        #endregion METODOS SIMPLE

        #region COMANDOS

        public ICommand AlertaAsincrona => new Command(async () => await MetodoAsincrono());
        public ICommand AlertaSimple => new Command(() => MetodoSimple());

        #endregion COMANDOS
    }
}