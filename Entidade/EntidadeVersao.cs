using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class EntidadeVersao
    {
        int idVersao;
        string versao;
        string banco;
        string bancoDefault;

        public string Versao
        {
            get
            {
                return versao;
            }

            set
            {
                versao = value;
            }
        }       

        public string Banco
        {
            get
            {
                return banco;
            }

            set
            {
                banco = value;
            }
        }

        public int IdVersao
        {
            get
            {
                return idVersao;
            }

            set
            {
                idVersao = value;
            }
        }

        public string BancoDefault
        {
            get
            {
                return bancoDefault;
            }

            set
            {
                bancoDefault = value;
            }
        }
    }
}
