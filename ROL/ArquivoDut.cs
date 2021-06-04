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
        EntidadeDutDocumento entidadeDutDocumento = new EntidadeDutDocumento();
       
        int codigo;
       
        public ArquivoDut(double codigo)
        {       
            InitializeComponent();
            lblCodigo.Text = Convert.ToString(codigo);
            CarregarGrid();
        }

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

            if (codigo == 0)
            {
                entidadeDutDocumento.Codigo_servico = Convert.ToInt32(lblCodigo.Text);
                entidadeDutDocumento.Documento = txtdocumentodut.Text;
                entidadeDutDocumento.Descricao = txtDescricao.Text;
                entidadeDutDocumento.NomeArquivo = txtdocumentodut.Text;
                dadosConsultaArquivoDUT.InserirArquivoDut(entidadeDutDocumento);

                //txtCodigo.Text = String.Empty;
                txtdocumentodut.Text = String.Empty;
                txtDescricao.Text = String.Empty;
                MessageBox.Show("Arquivo Gravado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                entidadeDutDocumento.Codigo_servico = Convert.ToInt32(lblCodigo.Text);
                entidadeDutDocumento.Documento = txtdocumentodut.Text;
                entidadeDutDocumento.Descricao = txtDescricao.Text;
                entidadeDutDocumento.NomeArquivo = txtdocumentodut.Text;
                dadosConsultaArquivoDUT.AlterarArquivoDut(entidadeDutDocumento,codigo);

                //txtCodigo.Text = String.Empty;
                txtdocumentodut.Text = String.Empty;
                txtDescricao.Text = String.Empty;
                MessageBox.Show("Arquivo Gravado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }          

           
        }

        public void CarregarGrid()
        {
            try
            {
                DataTable listaDocumento = dadosConsultaArquivoDUT.ResgatarDocumentoDut(this.lblCodigo.Text, "arquivodut", "cod_servico");

                dgDut.DataSource = listaDocumento;
                FormatarGrid();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FormatarGrid()
        {
            this.dgDut.Columns[0].Visible = true;
            this.dgDut.Columns[1].Visible = true;
            this.dgDut.Columns[2].Visible = true;
            this.dgDut.Columns[2].HeaderText = "Código";
            this.dgDut.Columns[3].HeaderText = "Código do Serviço";
            this.dgDut.Columns[4].HeaderText = "DUT";
            this.dgDut.Columns[5].HeaderText = "Caminho";

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Hide();           
        }

        private void btnGravarArquivo_Click(object sender, EventArgs e)
        {
            //GravarArquivoDUT();

            if (String.IsNullOrEmpty(lblCodigo.Text) & String.IsNullOrEmpty(txtDescricao.Text) & String.IsNullOrEmpty(txtdocumentodut.Text))
            {
                MessageBox.Show("Favor Preencher Todos os campos!");
            }
            else
            {
                if (codigo == 0) // Aqui grava arquivo
                {
                    var arquivo = txtdocumentodut.Text;
                    int cod = Convert.ToInt32(lblCodigo.Text);
                    string descricao = txtDescricao.Text;
                    SalvarArquivo(arquivo, cod, descricao);

                    //txtCodigo.Text = String.Empty;
                    txtdocumentodut.Text = String.Empty;
                    txtDescricao.Text = String.Empty;

                    MessageBox.Show("Arquivo Gravado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarGrid();
                }
                else if(codigo > 0)  // Aqui Altera arquivo
                {
                    var arquivo = txtdocumentodut.Text;
                    int cod = Convert.ToInt32(lblCodigo.Text);
                    string descricao = txtDescricao.Text;
                    AlterarArquivo(arquivo, cod, descricao,codigo);

                    //txtCodigo.Text = String.Empty;
                    txtdocumentodut.Text = String.Empty;
                    txtDescricao.Text = String.Empty;

                    codigo = 0; //resetando codigo
                    MessageBox.Show("Arquivo Alterado com Sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGravarArquivo.Text = "Gravar Arquivo";
                    CarregarGrid();
                }
                
            }
        }

        private void ConfigurarParametros(IDbCommand com, string arquivo, Int32 cod, string descricao)
        {
            com.Parameters.Add(new OleDbParameter("cod_servico", (cod)));
            com.Parameters.Add(new OleDbParameter("descricao", (descricao)));
            com.Parameters.Add(new OleDbParameter("documento", File.ReadAllBytes(arquivo)));
            com.Parameters.Add(new OleDbParameter("nome_arquivo", (arquivo)));

        }

        private void ConfigurarParametrosII(IDbCommand com, string arquivo, Int32 cod, string descricao, int codigo)
        {
            com.Parameters.Add(new OleDbParameter("codigo", (codigo)));
            com.Parameters.Add(new OleDbParameter("cod_servico", (cod)));
            com.Parameters.Add(new OleDbParameter("descricao", (descricao)));
            com.Parameters.Add(new OleDbParameter("documento", File.ReadAllBytes(arquivo)));
            com.Parameters.Add(new OleDbParameter("nome_arquivo", (arquivo)));

        }

        private IDbConnection AbrirConexao()
        {
            return new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;");
            //return new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\arquivodut.mdb;Persist Security Info=False;");
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
                    CarregarGrid();
                }
            }
        }

        private void AlterarArquivo(string arquivo, Int32 cod, string descricao, int codigo)
        {
            var strQuery = "";
            strQuery += "update arquivodut set";
            strQuery += string.Format(" cod_servico =  '{0}', ", cod);
            strQuery += string.Format(" descricao =  '{0}' ,", descricao);
            strQuery += string.Format(" documento =  '{0}' ,", File.ReadAllBytes(arquivo));
            strQuery += string.Format(" nome_arquivo =  '{0}' ", arquivo);
            strQuery += string.Format(" WHERE codigo =  {0} ", codigo);

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\dut.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(strQuery, oleDbConnection);

            try
            {
                oleDbConnection.Open();
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            //using (var con = AbrirConexao())
            //{
            //    con.Open();
            //    using (var comando = con.CreateCommand())
            //    {
            //        var strQuery = "";
            //        strQuery += "update arquivodut set";
            //        strQuery += string.Format(" codigo_servico =  '{0}', ", cod);
            //        strQuery += string.Format(" descricao =  '{0}' ,", descricao);
            //        strQuery += string.Format(" documento =  '{0}' ,", arquivo);
            //        strQuery += string.Format(" WHERE Codigo =  {0} ", codigo);


            //        comando.CommandText = @"update arquivodut set cod_servico = @cod_servico, descricao = @descricao, documento = @arquivo, nome_arquivo = @nome_arquivo where codigo = @codigo";
            //        ConfigurarParametrosII(comando, arquivo, cod, descricao,codigo);
            //        comando.ExecuteNonQuery();
            //        CarregarGrid();
            //    }
            //}
        }

        private void dgDut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                codigo = Convert.ToInt32(dgDut.Rows[e.RowIndex].Cells[2].Value.ToString());
                dadosConsultaArquivoDUT.ExcluirArquivoDut(codigo);
                CarregarGrid();
            }else if(e.ColumnIndex == 1)//sobe informações para os campos nos textbox para alteração
            {
                btnGravarArquivo.Text = "Alterar";
                codigo = Convert.ToInt32(dgDut.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtdocumentodut.Text = dgDut.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtDescricao.Text = dgDut.Rows[e.RowIndex].Cells[4].Value.ToString();
                
                //entidadeDutDocumento.Codigo_servico = Convert.ToInt32(lblCodigo.Text);
                //entidadeDutDocumento.Documento = txtdocumentodut.Text;
                //entidadeDutDocumento.Descricao = txtDescricao.Text;
                //entidadeDutDocumento.NomeArquivo = txtdocumentodut.Text;
                //dadosConsultaArquivoDUT.InserirArquivoDut(entidadeDutDocumento);
                
               
               // CarregarGrid();
            }
            
           
        }

        private void dgDut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        //private void ArquivoDut_Load(object sender, EventArgs e)
        //{
        //    // TODO: This line of code loads data into the 'bdDataSet.arquivodut' table. You can move, or remove it, as needed.
        //    this.arquivodutTableAdapter.Fill(this.bdDataSet.arquivodut);

        //}
    }    
}
