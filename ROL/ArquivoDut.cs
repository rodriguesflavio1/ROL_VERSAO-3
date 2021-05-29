using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using DAO;
using Entidade;
using System.IO;

namespace ROL
{
    public partial class ArquivoDut : Form
    {
        
        DadosConsulta dadosConsultaArquivoDUT = new DadosConsulta();
        
        
        public ArquivoDut()
        {
            InitializeComponent();
        }

        private void btnBuscarArquivo_Click(object sender, EventArgs e)
        {
            BuscarArquivoDUT();
        }
        
        public void BuscarArquivoDUT() {
            ofd.Title = "Selecione Arquivo";
            ofd.Filter = "Arquivos (*.pdf) | *.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(ofd.FileName))
                {
                    return;
                }
                try
                {
                    txtdocumentodut.Text = ofd.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocorreu um erro ao tentar selecionar o arquivo");
                }
            }
        }
        
        public void GravarArquivoDUT()
        {
            EntidadeDutDocumento entidadeDutDocumento= new EntidadeDutDocumento();
            DadosConsulta dadosConsulta = new DadosConsulta();

            entidadeDutDocumento.Codigo_servico = Convert.ToInt32(txtCodigo.Text);
            entidadeDutDocumento.Documento = txtdocumentodut.Text;
            entidadeDutDocumento.Descricao = txtDescricao.Text;
            entidadeDutDocumento.NomeArquivo = txtdocumentodut.Text;
            dadosConsulta.InserirArquivoDut(entidadeDutDocumento);
            
            txtCodigo.Text = String.Empty;
            txtdocumentodut.Text = String.Empty;
            txtDescricao.Text = String.Empty;

            MessageBox.Show("Arquivo Gravado com Sucesso!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        
        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manutencao manutencao = new Manutencao();
            //ArquivoDut arquivoDut = new ArquivoDut();
            //arquivoDut.Hide();
            manutencao.Show();
        }

        private void btnGravarArquivo_Click(object sender, EventArgs e)
        {
            //GravarArquivoDUT();

            if (String.IsNullOrEmpty(txtCodigo.Text) & String.IsNullOrEmpty(txtDescricao.Text) & String.IsNullOrEmpty(txtdocumentodut.Text))
            {
                MessageBox.Show("Favor Preencher Todos os campos!");
            }
            else
            {
                var arquivo = txtdocumentodut.Text;
                int cod = Convert.ToInt32(txtCodigo.Text);
                string descricao = txtDescricao.Text;
                SalvarArquivo(arquivo, cod, descricao);

                txtCodigo.Text = String.Empty;
                txtdocumentodut.Text = String.Empty;
                txtDescricao.Text = String.Empty;

                MessageBox.Show("Arquivo Gravado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfigurarParametros(IDbCommand com, string arquivo, Int32 cod, string descricao)
        {
            com.Parameters.Add(new OleDbParameter("cod_servico", (cod)));
            com.Parameters.Add(new OleDbParameter("descricao", (descricao)));
            com.Parameters.Add(new OleDbParameter("documento", File.ReadAllBytes(arquivo)));
            com.Parameters.Add(new OleDbParameter("nome_arquivo", (arquivo)));

        }

        private IDbConnection AbrirConexao()
        {
            return new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\arquivodut.mdb;Persist Security Info=False;");
        }

        private string EscolherArquivo()
        {
            var retorno = string.Empty;

            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    retorno = dialog.FileName;
                    txtdocumentodut.Text = retorno;
                }
            }
           
            return retorno;
        }

        private void SalvarArquivo(string arquivo, Int32 cod, string descricao)
        {

            using (var con = AbrirConexao())
            {
                con.Open();
                using (var comando = con.CreateCommand())
                {
                    comando.CommandText = @"insert into arquivodut(cod_servico,descricao,documento, nome_arquivo) values(@cod_servico,@descricao,@arquivo,@nome_arquivo)";
                    ConfigurarParametros(comando, arquivo, cod, descricao);
                    comando.ExecuteNonQuery();
                    //CarregarGrid();
                }
            }
        }
    }    
}
