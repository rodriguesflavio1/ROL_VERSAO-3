using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class EntidadeVersao
    {
        string versaoAnt;
        string versaoAtual;

        public string VersaoAnt
        {
            get
            {
                return versaoAnt;
            }

            set
            {
                versaoAnt = value;
            }
        }

        public string VersaoAtual
        {
            get
            {
                return versaoAtual;
            }

            set
            {
                versaoAtual = value;
            }
        }
    }
}
