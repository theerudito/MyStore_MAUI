namespace MyStore_MAUI.ViewModel
{
    public class Calculates
    {
        private int _cant;
        private float _p_unitary;
        private float _p_total;
        private float _subtotal;
        private float _descuent;
        private float _subtotal12;
        private float _subtotal0;
        private float _iva;
        private float _total;

        public Calculates()
        {
        }

        public float Result_Cant_P_Unitary(int cant, float vUnitary)
        {
            this._cant = cant;
            this._p_unitary = vUnitary;
            return _cant * _p_unitary;
        }

        public int Result_Quantity(int cant)
        {
            this._cant = cant;
            return cant;
        }

        public float Result_Subtotal(float subtotal)
        {
            this._subtotal = subtotal;
            return _subtotal;
        }

        public float Result_Descuent(float desc)
        {
            this._descuent = desc;
            return _descuent;
        }

        public float Result_Subtotal12(float subtotal12)
        {
            this._subtotal12 = subtotal12;
            return _subtotal12;
        }

        public float Result_Subtotal0(float subtotal0)
        {
            this._subtotal0 = subtotal0;
            return _subtotal0;
        }

        public float Result_Iva(float iva)
        {
            this._iva = iva;
            return _iva + _total;
        }

        public float Result_Total_Final(float total)
        {
            this._total = total;
            return _total + _iva;
        }
    }
}