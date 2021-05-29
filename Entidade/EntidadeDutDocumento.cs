using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class EntidadeDutDocumento
    {
        private double codigo_servico;
        private string documento;
        private string descricao;
        private string nomeArquivo;

        public double Codigo_servico
        {
            get
            {
                return codigo_servico;
            }

            set
            {
                codigo_servico = value;
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

        public string Descricao
        {
            get
            {
                return descricao;
            }

            set
            {
                descricao = value;
            }
        }

        public string NomeArquivo
        {
            get
            {
                return nomeArquivo;
            }

            set
            {
                nomeArquivo = value;
            }
        }
    }
}
