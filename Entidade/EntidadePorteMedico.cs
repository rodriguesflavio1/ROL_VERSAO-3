using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class EntidadePorteMedico
    {
        private string codigoPorteMedico;
        private double valorPorteMedico;
       

        public string CodigoPorteMedico
        {
            get
            {
                return codigoPorteMedico;
            }

            set
            {
                codigoPorteMedico = value;
            }
        }

        public double ValorPorteMedico
        {
            get
            {
                return valorPorteMedico;
            }

            set
            {
                valorPorteMedico = value;
            }
        }       

    }
}
