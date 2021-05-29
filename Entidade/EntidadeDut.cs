using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class EntidadeDut
    {
        private double codigo;
        private string dut;
        private string especialidade;
        private string favoravel;
        private string desfavoravel;
        private string opme;
        private string nomeTabela;
        private string nomeCampo;
        private string documento;
         

        public string Dut
        {
            get
            {
                return dut;
            }

            set
            {
                dut = value;
            }
        }

        public string Especialidade
        {
            get
            {
                return especialidade;
            }

            set
            {
                especialidade = value;
            }
        }

        public string Favoravel
        {
            get
            {
                return favoravel;
            }

            set
            {
                favoravel = value;
            }
        }

        public string Desfavoravel
        {
            get
            {
                return desfavoravel;
            }

            set
            {
                desfavoravel = value;
            }
        }

        public string Opme
        {
            get
            {
                return opme;
            }

            set
            {
                opme = value;
            }
        }

        public string NomeTabela
        {
            get
            {
                return nomeTabela;
            }

            set
            {
                nomeTabela = value;
            }
        }

        public string NomeCampo
        {
            get
            {
                return nomeCampo;
            }

            set
            {
                nomeCampo = value;
            }
        }

        public double Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Documento
        {
            get
            {
                return documento;
            }

            set
            {
                documento = value;
            }
        }              
        
    }
}
