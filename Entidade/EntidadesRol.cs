using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Entidade
{
    public class EntidadesRol
    {
        private string nomeCampo;
        private string nomeTabela;
        private double codigoAMB;
        private double codigoCBHPM;
        private double valorIntercambio;
        private double valorHm;
        private double valorCo;
        private string auxiliar;
        private double valorFilme;
        private string descricaoAMB;
        private string descricaoCBHPM;
        private string observacao;
        private string porteAnestesico;
        private string rolSn;
        private string hmSadt;
        private string classificacao;
        private int quantidade;
        private string docRacionalizacao;
        private string executora;
        private string origem;
        private string total;
        private string aba;
        private string diferencaVersao;
        private double taxa_video;
        private string especialidade;
        private string dut;
        private string opme;
        private string desfavoravel;
        private string favoravel;
        private string tabelaSadt;
        private string tabelaHN;
        private string tabelaDut;
        private string tabelaAba;
        //private string codigoPorteMedico;
        //private double valorPorteMedico;
        private string valorIntercambioHM;


        public double CodigoAMB
        {
            get
            {
                return codigoAMB;
            }

            set
            {
                codigoAMB = value;
            }
        }

        public double CodigoCBHPM
        {
            get
            {
                return codigoCBHPM;
            }

            set
            {
                codigoCBHPM = value;
            }
        }

        public double ValorIntercambio
        {
            get
            {
                return valorIntercambio;
            }

            set
            {
                valorIntercambio = value;
            }
        }

        public double ValorHm
        {
            get
            {
                return valorHm;
            }

            set
            {
                valorHm = value;
            }
        }

        public double ValorCo
        {
            get
            {
                return valorCo;
            }

            set
            {
                valorCo = value;
            }
        }

        public string Auxiliar
        {
            get
            {
                return auxiliar;
            }

            set
            {
                auxiliar = value;
            }
        }

        public double ValorFilme
        {
            get
            {
                return valorFilme;
            }

            set
            {
                valorFilme = value;
            }
        }

        public string DescricaoAMB
        {
            get
            {
                return descricaoAMB;
            }

            set
            {
                descricaoAMB = value;
            }
        }

        public string DescricaoCBHPM
        {
            get
            {
                return descricaoCBHPM;
            }

            set
            {
                descricaoCBHPM = value;
            }
        }

        public string Observacao
        {
            get
            {
                return observacao;
            }

            set
            {
                observacao = value;
            }
        }

        public string PorteAnestesico
        {
            get
            {
                return porteAnestesico;
            }

            set
            {
                porteAnestesico = value;
            }
        }

        public string RolSn
        {
            get
            {
                return rolSn;
            }

            set
            {
                rolSn = value;
            }
        }

        public string HmSadt
        {
            get
            {
                return hmSadt;
            }

            set
            {
                hmSadt = value;
            }
        }

        public string Classificacao
        {
            get
            {
                return classificacao;
            }

            set
            {
                classificacao = value;
            }
        }

        public int Quantidade
        {
            get
            {
                return quantidade;
            }

            set
            {
                quantidade = value;
            }
        }

        public string DocRacionalizacao
        {
            get
            {
                return docRacionalizacao;
            }

            set
            {
                docRacionalizacao = value;
            }
        }

        public string Executora
        {
            get
            {
                return executora;
            }

            set
            {
                executora = value;
            }
        }

        public string Origem
        {
            get
            {
                return origem;
            }

            set
            {
                origem = value;
            }
        }

        public string Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public string Aba
        {
            get
            {
                return aba;
            }

            set
            {
                aba = value;
            }
        }

        public string DiferencaVersao
        {
            get
            {
                return diferencaVersao;
            }

            set
            {
                diferencaVersao = value;
            }
        }

        public double Taxa_video
        {
            get
            {
                return taxa_video;
            }

            set
            {
                taxa_video = value;
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

        public string TabelaSadt
        {
            get
            {
                return tabelaSadt;
            }

            set
            {
                tabelaSadt = value;
            }
        }

        public string TabelaHN
        {
            get
            {
                return tabelaHN;
            }

            set
            {
                tabelaHN = value;
            }
        }

        public string TabelaDut
        {
            get
            {
                return tabelaDut;
            }

            set
            {
                tabelaDut = value;
            }
        }

        public string TabelaAba
        {
            get
            {
                return tabelaAba;
            }

            set
            {
                tabelaAba = value;
            }
        }

        //public string CodigoPorteMedico
        //{
        //    get
        //    {
        //        return codigoPorteMedico;
        //    }

        //    set
        //    {
        //        codigoPorteMedico = value;
        //    }
        //}

        //public double ValorPorteMedico
        //{
        //    get
        //    {
        //        return valorPorteMedico;
        //    }

        //    set
        //    {
        //        valorPorteMedico = value;
        //    }
        //}

        public string ValorIntercambioHM
        {
            get
            {
                return valorIntercambioHM;
            }

            set
            {
                valorIntercambioHM = value;
            }
        }
    }
}
