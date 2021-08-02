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
    public partial class Manutencao : Form
    {
        DadosConsulta dadosConsultaDUT = new DadosConsulta();
        public string codigo;
        public string banco;


        public Manutencao()
        {
            InitializeComponent();
        }

        public Manutencao(string Banco)
        {
            InitializeComponent();
            banco = Banco;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ConsultaDut();
            //txtCodigo.Enabled = false;
        }
        private void ConsultaDut()
        {
            DadosConsulta dadosConsultaDut = new DadosConsulta();
                       
            EntidadeDut entidade = new EntidadeDut();
            entidade.NomeCampo = "Codigo";
            entidade.NomeTabela = "dut";

            if (!string.IsNullOrEmpty(txtConsulta.Text))
            {
                List<EntidadeDut> listaDut = dadosConsultaDut.ResgatarDadosManutencaoDut(this.txtConsulta.Text, entidade.NomeTabela, entidade.NomeCampo, banco);
                if (listaDut.Count > 0)
                {
                    codigo = listaDut[0].Codigo.ToString();


                    this.txtCodigo.Text = listaDut[0].Codigo.ToString();
                    this.txtEspecialidade.Text = listaDut[0].Especialidade.ToString();
                    this.txtOpme.Text = listaDut[0].Opme.ToString();                    
                    this.txtFavoravel.Text = listaDut[0].Favoravel.ToString();
                    this.txtDesfavoravel.Text = listaDut[0].Desfavoravel.ToString();
                    return;
                }
                else
                {
                    codigo = string.Empty;
                    MessageBox.Show("Não existe valores para o código pesquisado!");
                }
            }else
            {
                MessageBox.Show("Campo Código precisa ser preenchido!");
                txtCodigo.Focus();
            }
           
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            frmPesquisa formPesquisa = new frmPesquisa();
            this.Hide();
            formPesquisa.Show();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                InserirDut();
                MessageBox.Show("Cadastro com Sucesso!");
            }else
            {
                AlterarDut();
                MessageBox.Show("Alteração realizada com Sucesso!");
            }
            
        }

        public void InserirDut()
        {
            EntidadeDut entidadeDut = new EntidadeDut();
            try
            {                
                entidadeDut.Codigo = Convert.ToDouble(txtCodigo.Text);                
                entidadeDut.Especialidade = txtEspecialidade.Text;
                entidadeDut.Opme = txtOpme.Text;
                entidadeDut.Desfavoravel = txtDesfavoravel.Text;
                entidadeDut.Favoravel = txtFavoravel.Text;
                dadosConsultaDUT.InserirDut(entidadeDut, banco);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AlterarDut()
        {
            DadosConsulta dadosConsultaDut = new DadosConsulta();
            EntidadeDut entidade = new EntidadeDut();
            entidade.NomeCampo = "Codigo";
            entidade.NomeTabela = "dut";

          
                entidade.Codigo = Convert.ToDouble(txtCodigo.Text); 
                entidade.Especialidade = txtEspecialidade.Text;  
                entidade.Opme = txtOpme.Text;               
                entidade.Favoravel = txtFavoravel.Text; 
                entidade.Desfavoravel = txtDesfavoravel.Text;

                dadosConsultaDUT.AlterarDut(entidade, banco);
           
        }        

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                ArquivoDut arquivoDut = new ArquivoDut(txtCodigo.Text,banco);
                arquivoDut.Show();
            }else
            {
                MessageBox.Show("Obrigatório realiza a consulta do Codigo de Serviço!");
                txtConsulta.Focus();
            }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = String.Empty;
            txtCodigo.Enabled = true;
            txtConsulta.Text = String.Empty;
            txtDesfavoravel.Text = String.Empty;            
            txtEspecialidade.Text = String.Empty;
            txtFavoravel.Text = String.Empty;
            txtOpme.Text = String.Empty;
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ConsultaDut();                
            }            
        }
    }
}
