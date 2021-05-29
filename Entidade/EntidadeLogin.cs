using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade
{
    public class EntidadeLogin
    {
        private string usuario;
        private string senha;
        private bool controle;

        public string Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public bool Controle
        {
            get
            {
                return controle;
            }

            set
            {
                controle = value;
            }
        }
    }
}
