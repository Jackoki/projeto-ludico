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

            else {
                MessageBox.Show($"Por favor, insira um número válido para {fieldName}.");
                return 0;
            }
        }
    }
}
