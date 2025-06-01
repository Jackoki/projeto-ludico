using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_ludico.Utils
{
    public class ParseIntOrDefault{
        public int ParseInt(string input, string fieldName) {
            if (int.TryParse(input, out int result)) {
                return result;
            }

            else if (string.IsNullOrWhiteSpace(input)) {
                return 0;
            }

            else {
                throw new ArgumentException($"O valor fornecido para {fieldName} não é um número válido.");
            }
        }
    }
}
