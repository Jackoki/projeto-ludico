using System;

namespace projeto_ludico.Utils
{
    //Função auxiliar para evitar mandar NULL para as classes, ao invés disso analisa os valores, em que se for 0 ou vazia, será enviado DBNull
    internal class DbNullUtil
    {
        public static object GetDBNullIfEmpty(string value) {
            if (string.IsNullOrEmpty(value)) {
                return DBNull.Value;
            }

            else {
                return value;
            }
        }

        public static object GetDBNullIfEmpty(int value) {
            if (value == 0) {
                return DBNull.Value;
            }

            else {
                return value;
            }
        }
    }
}
