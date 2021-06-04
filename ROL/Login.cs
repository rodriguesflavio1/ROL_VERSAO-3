using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidade;
using DAO;



namespace ROL
{
    public partial class Login : Form
    {
        
        DadosConsulta consulta = new DadosConsulta();
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            ConsultaUsuario();
        }

        private void ConsultaUsuario()
        {
            Manutencao formManutencao = new Manutencao();
            List<EntidadeLogin> listaAba = consulta.ResgatarUsuario(this.txtLogin.Text.ToUpper(), this.txtSenha.Text.ToUpper());
            if (listaAba.Count > 0)
            {
               // MessageBox.Show("Bem-Vindo a Manutenção do Sistema Rol");
                this.Hide();
                formManutencao.Show();
            }
            else {
                MessageBox.Show("Usuário ou Senha incorreta!");
            }         
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            frmPesquisa pesquisa = new frmPesquisa();
            this.Hide();
            pesquisa.Show();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ConsultaUsuario();
            }
        }
    }
}
