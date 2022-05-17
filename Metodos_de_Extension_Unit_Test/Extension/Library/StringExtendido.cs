using System;

namespace Library
{
    public static class StringExtendido
    {
        public static int ContarPalabras(this String s)
        {
            return s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length; //retorna un array el split. Corto en cada palabra. Saco el length del array, que es, cada palabra
        }
    }
}
