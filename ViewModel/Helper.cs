using MyStore_MAUI.Base;
using System.Windows.Input;


namespace MyStore_MAUI.ViewModel
{
    class Helper : BaseViewModel
    {
        #region CONSTRUCTOR
        public Helper()
        {

        }
        #endregion


        #region VARIABLES
        string _Text;
        #endregion


        #region OBJETO
        public string Text
        {
            get { return _Text; }
            set { SetValue(ref _Text, value); }
        }
        #endregion


        #region METODOS ASYNC
        public async Task MetodoAsincrono()
        {
            await Task.Delay(1000);
            Text = "Hola Mundo";
        }
        #endregion


        #region METODOS SIMPLE
        public void MetodoSimple()
        {
            Text = "Hola Mundo";
        }
        #endregion


        #region COMANDOS
        public ICommand AlertaAsincrona => new Command(async () => await MetodoAsincrono());
        public ICommand AlertaSimple => new Command(() => MetodoSimple());
        #endregion
    }
}
