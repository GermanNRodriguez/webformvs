using Producto;

namespace Logic
{
    public class LP
    {
        public bool ValidarTxt(Product p)
        {
            if ((p.nombre==null) || (p.descripcion==null) || (p.precio==0) || (p.stock==0))
            {
                return true;
            } else if (!p.precio.Equals(typeof(int)) || (!p.stock.Equals(typeof(int))))
            {
                return true;
            }
            {
                return false;
            }

        }
    }
}
