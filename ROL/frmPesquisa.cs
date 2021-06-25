using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using Entidade;
using DAO;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace ROL
{
    public partial class frmPesquisa : Form
    {
        string controle;
        //string strCaminho;
        //byte[] buffer;
        EntidadePorteMedico porteMedico = new EntidadePorteMedico();
        EntidadeDutDocumento entidadeDutDocumento = new EntidadeDutDocumento();
        EntidadesRol entidade = new EntidadesRol();
        EntidadeDut entidadeDut = new EntidadeDut();
        DadosConsulta consulta = new DadosConsulta();
        

        public frmPesquisa()
        {
            InitializeComponent();
            entidade.NomeCampo = "Codigo";
                           
        }

        private void frmPesquisa_Load(object sender, EventArgs e)
        {
            ConsultarVersao();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            if (this.txtConsulta.Text == "")
            {
                MessageBox.Show("Digite um código para consulta!");
                return;
            }

            //else
            //{
            //    entidade.NomeCampo = "COD_CBHPM";
            //    if (this.rdbNova.Checked)
            //    {
            //        entidade.NomeTabela = "cbhpm_amb_nov";
            //    }
            //    else
            //    {
            //        entidade.NomeTabela = "cbhpm_amb_ant";
            //    }
            //}
            //this.ConsultaDados();
            LimpaCampos();

            if (ConsultaDadosSadt().Equals(true))
            {
                this.ConsultaDadosSadt();
            }else
            {
                this.ConsultaDadosHM();
            }
            this.ConsultaAba();
            this.ConsultaDut();
            this.ConsultarDocumentoDUT();

        }

        private bool ConsultaDadosHM()
        {
            
            entidade.NomeTabela = "HM";

            List<EntidadesRol> list = consulta.ResgataDadosHM(this.txtConsulta.Text, entidade.NomeTabela, entidade.NomeCampo);
            

            if (list.Count > 0)
            {

                controle = Convert.ToString(list[0].ValorIntercambioHM);
                bool b = controle.Contains(",");
                if (b == true)
                {
                    this.txtVlrIntercambio.Text = list[0].ValorIntercambioHM.ToString();
                }else
                {
                    switch (controle.Trim())
                    {
                        case "1A":
                            this.txtVlrIntercambio.Text = "R$ 15,92";
                            break;

                        case "1B":
                            this.txtVlrIntercambio.Text = "R$ 31,84";
                            break;

                        case "1C":
                            this.txtVlrIntercambio.Text = " R$ 47,77";
                            break;

                        case "2A":
                            this.txtVlrIntercambio.Text = " R$ 63,70";
                            break;

                        case "2B":
                            this.txtVlrIntercambio.Text = " R$ 83,97";
                            break;

                        case "2C":
                            this.txtVlrIntercambio.Text = " R$ 99,37";
                            break;

                        case "3A":
                            this.txtVlrIntercambio.Text = " R$ 135,78";
                            break;

                        case "3B":
                            this.txtVlrIntercambio.Text = " R$ 173,50";
                            break;

                        case "3C":
                            this.txtVlrIntercambio.Text = " R$ 198,73";
                            break;

                        case "4A":
                            this.txtVlrIntercambio.Text = " R$ 236,52";
                            break;

                        case "4B":
                            this.txtVlrIntercambio.Text = " R$ 258,92";
                            break;

                        case "4C":
                            this.txtVlrIntercambio.Text = " R$ 292,50";
                            break;

                        case "5A":
                            this.txtVlrIntercambio.Text = " R$ 314,89";
                            break;

                        case "5B":
                            this.txtVlrIntercambio.Text = " R$ 340,09";
                            break;

                        case "5C":
                            this.txtVlrIntercambio.Text = " R$ 361,07";
                            break;

                        case "6A":
                            this.txtVlrIntercambio.Text = " R$ 393,27";
                            break;
                        case "6B":
                            this.txtVlrIntercambio.Text = " R$ 432,47";
                            break;

                        case "6C":
                            this.txtVlrIntercambio.Text = " R$ 473,04";
                            break;

                        case "7A":
                            this.txtVlrIntercambio.Text = " R$ 510,83";
                            break;

                        case "7B":
                            this.txtVlrIntercambio.Text = " R$ 565,41";
                            break;

                        case "7C":
                            this.txtVlrIntercambio.Text = " R$ 668,97";
                            break;

                        case "8A":
                            this.txtVlrIntercambio.Text = " R$ 722,16";
                            break;

                        case "8B":
                            this.txtVlrIntercambio.Text = " R$ 757,15";
                            break;
                        case "8C":
                            this.txtVlrIntercambio.Text = " R$ 803,33";
                            break;

                        case "9A":
                            this.txtVlrIntercambio.Text = " R$ 853,72";
                            break;
                        case "9B":
                            this.txtVlrIntercambio.Text = " R$ 933,50";
                            break;
                        case "9C":
                            this.txtVlrIntercambio.Text = " R$ 1.028,64";
                            break;
                        case "10A":
                            this.txtVlrIntercambio.Text = " R$ 1.104,23";
                            break;
                        case "10B":
                            this.txtVlrIntercambio.Text = " R$ 1.196,60";
                            break;
                        case "10C":
                            this.txtVlrIntercambio.Text = " R$ 1.328,15";
                            break;
                        case "11A":
                            this.txtVlrIntercambio.Text = " R$ 1.405,13";
                            break;
                        case "11B":
                            this.txtVlrIntercambio.Text = " R$ 1.540,89";
                            break;
                        case "11C":
                            this.txtVlrIntercambio.Text = " R$ 1.690,65";
                            break;
                        case "12A":
                            this.txtVlrIntercambio.Text = " R$ 1.752,22";
                            break;
                        case "12B":
                            this.txtVlrIntercambio.Text = " R$ 1.883,78";
                            break;
                        case "12C":
                            this.txtVlrIntercambio.Text = " R$ 2.307,82";
                            break;
                        case "13A":
                            this.txtVlrIntercambio.Text = " R$ 2.540,15";
                            break;
                        case "13B":
                            this.txtVlrIntercambio.Text = " R$ 2.786,47";
                            break;
                        case "13C":
                            this.txtVlrIntercambio.Text = " R$ 3.081,77";
                            break;
                        case "14A":
                            this.txtVlrIntercambio.Text = " R$ 3.434,45";
                            break;
                        case "14B":
                            this.txtVlrIntercambio.Text = " R$ 3.736,76";
                            break;
                        case "14C":
                            this.txtVlrIntercambio.Text = " R$ 4.121,62";
                            break;

                        default:
                            this.txtVlrIntercambio.Text = "0,0";
                            break;

                    }
                    
                }
                
                this.txtDescTuss.Text = list[0].DescricaoCBHPM;
                this.txtCodigoAmb.Text = list[0].CodigoAMB.ToString();
                this.txtCodigoTuss.Text = list[0].CodigoCBHPM.ToString();
                this.txtAuxiliar.Text = list[0].Auxiliar.ToString();
                this.txtHN.Text = list[0].HmSadt;
                this.txtPorteAnestesico.Text = list[0].PorteAnestesico;
                this.txtValorFilme.Text = list[0].ValorFilme.ToString();
                this.txtValorCO.Text = list[0].ValorCo.ToString();
                this.txtValorHM.Text = txtVlrIntercambio.Text;
                if (txtAba.Text == "Sem Cobertura")
                {
                    this.txtRolSN.Text = "N";
                }
                else
                {
                    this.txtRolSN.Text = "S";
                }
                this.txtClassificacao.Text = list[0].Classificacao.ToString();
                if (list[0].Quantidade.ToString() == "0")
                {
                    this.txtQtdeMax.Text = "";
                }
                else
                {
                    this.txtQtdeMax.Text = list[0].Quantidade.ToString();
                }
                this.txtDocRacionalizacao.Text = list[0].DocRacionalizacao.ToString();
                this.txtExecutora.Text = list[0].Executora.ToString();
                this.txtOrigem.Text = list[0].Origem.ToString();
                this.txtTotal.Text = list[0].Total.ToString();
                this.txtAba.Text = "";
                
                this.txtEspecialidade.Text = "";
                this.txtObservacao.Text = "";
                this.txtOpme.Text = "";
                this.txtFavoravel.Text = "";
                this.txtDesfavoravel.Text = "";


                //this.txt_taxa_video.Text = list[0].Taxa_video.ToString();

                return true;
            }
            else {
                return false;
            }
            

        }

        private bool ConsultaDadosSadt()
        {

            entidade.NomeTabela = "sadt";           

            List<EntidadesRol> list = consulta.ResgataDadosSadt(this.txtConsulta.Text, entidade.NomeTabela, entidade.NomeCampo);
            if (list.Count > 0)
            {

                this.txtDescTuss.Text = list[0].DescricaoCBHPM;
                this.txtCodigoAmb.Text = list[0].CodigoCBHPM.ToString();// Para a tabela sadt o codigo cbhpm é igual ao codigo AMB
                this.txtCodigoTuss.Text = list[0].CodigoCBHPM.ToString();
                this.txtAuxiliar.Text = list[0].Auxiliar.ToString();
                this.txtHN.Text = list[0].HmSadt;
                this.txtPorteAnestesico.Text = list[0].PorteAnestesico;
                //this.txtObservacao.Text = list[0].Observacao.ToString();
                this.txtValorFilme.Text = list[0].ValorFilme.ToString();
                this.txtValorCO.Text = list[0].ValorCo.ToString();
                this.txtValorHM.Text = list[0].ValorHm.ToString();
                this.txtVlrIntercambio.Text = list[0].ValorIntercambio.ToString();
                if (txtAba.Text == "Sem Cobertura")
                {
                    this.txtRolSN.Text = "N";
                }else
                {
                    this.txtRolSN.Text = "S";
                }
                
                this.txtClassificacao.Text = list[0].Classificacao.ToString();
                if (list[0].Quantidade.ToString() == "0")
                {
                    this.txtQtdeMax.Text = "";
                }
                else
                {
                    this.txtQtdeMax.Text = list[0].Quantidade.ToString();
                }
                this.txtDocRacionalizacao.Text = list[0].DocRacionalizacao.ToString();
                this.txtExecutora.Text = list[0].Executora.ToString();
                this.txtOrigem.Text = list[0].Origem.ToString();
                this.txtTotal.Text = list[0].Total.ToString();
                this.txtAba.Text = "";            
                this.txtEspecialidade.Text = "";
                this.txtObservacao.Text = "";
                this.txtOpme.Text = ""; 
                this.txtFavoravel.Text = ""; 
                this.txtDesfavoravel.Text = "";


                //this.txt_taxa_video.Text = list[0].Taxa_video.ToString();

                return true;
            }
            else
            {
                return false;
            }


        }

        private void ConsultaDados()
        {          
            
            List<EntidadesRol> list = consulta.ResgataDadosRol(this.txtConsulta.Text, entidade.NomeTabela, entidade.NomeCampo);
            if (list.Count > 0)
            {
               
                this.txtDescTuss.Text = list[0].DescricaoCBHPM;
                this.txtCodigoAmb.Text = list[0].CodigoAMB.ToString();
                this.txtCodigoTuss.Text = list[0].CodigoCBHPM.ToString();
                this.txtAuxiliar.Text = list[0].Auxiliar.ToString();
                this.txtHN.Text = list[0].HmSadt;
                this.txtPorteAnestesico.Text = list[0].PorteAnestesico;
                //this.txtObservacao.Text = list[0].Observacao.ToString();
                this.txtValorFilme.Text = list[0].ValorFilme.ToString();
                this.txtValorCO.Text = list[0].ValorCo.ToString();
                this.txtValorHM.Text = list[0].ValorHm.ToString();
                this.txtVlrIntercambio.Text = list[0].ValorIntercambio.ToString();
                this.txtRolSN.Text = list[0].RolSn;
                this.txtClassificacao.Text = list[0].Classificacao.ToString();
                if (list[0].Quantidade.ToString() == "0")
                {
                    this.txtQtdeMax.Text = "";
                }
                else
                {
                    this.txtQtdeMax.Text = list[0].Quantidade.ToString();
                }
                this.txtDocRacionalizacao.Text = list[0].DocRacionalizacao.ToString();
                this.txtExecutora.Text = list[0].Executora.ToString();
                this.txtOrigem.Text = list[0].Origem.ToString();
                this.txtTotal.Text = list[0].Total.ToString();
                //this.txtAba.Text = list[0].Aba.ToString();
               
                //this.txt_taxa_video.Text = list[0].Taxa_video.ToString();
                //this.lblMensagem.Text = "";
                return;
            }
            this.LimpaCampos();
            MessageBox.Show("Não existem dados para esta consulta!");
            
        }

        private void ConsultarVersao()
        {
            entidade.TabelaAba = "versao";
            List<EntidadeVersao> listaVersao = consulta.ResgataDadosVersao(this.txtConsulta.Text, entidade.TabelaAba, entidade.NomeCampo);
            if (listaVersao.Count > 0)
            {
                this.rdbAnt.Text = listaVersao[0].VersaoAnt.ToString();
                this.rdbNova.Text = listaVersao[0].VersaoAtual.ToString();
                return;
            }

        }

        private void ConsultaAba()
        {
            
            entidade.TabelaAba = "Aba";
            List<EntidadesRol> listaAba = consulta.ResgataDadosAba(this.txtConsulta.Text, entidade.TabelaAba, entidade.NomeCampo);
            if (listaAba.Count > 0)
            {                
                this.txtObservacao.Text = listaAba[0].Observacao.ToString();                
                this.txtAba.Text = listaAba[0].Aba.ToString();                
                return;
            }          

        }

        private void ConsultaDut()
        {
            
            //entidade.NomeCampo = "Codigo";
            entidade.NomeTabela = "dut";

            List<EntidadesRol> listaDut= consulta.ResgataDadosDut(this.txtConsulta.Text, entidade.NomeTabela, entidade.NomeCampo);
            if (listaDut.Count > 0)
            {
                this.txtEspecialidade.Text = listaDut[0].Especialidade.ToString();
                this.txtOpme.Text = listaDut[0].Opme.ToString();                
                this.txtFavoravel.Text = listaDut[0].Favoravel.ToString();
                this.txtDesfavoravel.Text = listaDut[0].Desfavoravel.ToString();
                return;
            }
                    

        }

        private void ConsultarDocumentoDUT()
        {
            try
            {                
               DataTable listaDocumento = consulta.ResgatarDocumentoDut(this.txtConsulta.Text, "arquivodut", "cod_servico");
               
                    dganexo.DataSource = listaDocumento;
                    FormatarGrid();                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);                
            }
        }

        private void AbrirDocumento()
        {
            try
            {
               byte[] listaDocumento = consulta.AbrirDocumentoDut(Convert.ToString(dganexo.CurrentRow.Cells[0].Value), "arquivodut", "codigo");

                //strCaminho = Path.GetTempFileName();
                //File.Move(strCaminho, Path.ChangeExtension(strCaminho, ".pdf"));
                //strCaminho = Path.ChangeExtension(strCaminho, ".pdf");
                //File.WriteAllBytes(strCaminho, listaDocumento);
                if (listaDocumento != null)
                {
                    var nomeArquivo = dganexo.CurrentRow.Cells["nome_arquivo"].Value.ToString();
                    var arquivoTemp = Path.GetTempFileName();
                    arquivoTemp = Path.ChangeExtension(arquivoTemp, Path.GetExtension(nomeArquivo));
                    File.WriteAllBytes(arquivoTemp, listaDocumento);
                    Process.Start(arquivoTemp);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }         

        private void FormatarGrid()
        {
           this.dganexo.Columns[0].HeaderText = "Controle";
           this.dganexo.Columns[1].HeaderText = "Cod Serviço";
           this.dganexo.Columns[2].HeaderText = "Dut";
            this.dganexo.Columns[0].Visible = false;

        }
         
        private void LimpaCampos()
        {
            
            this.txtDescTuss.Text = "";
            this.txtCodigoAmb.Text = "";
            this.txtCodigoTuss.Text = "";
            this.txtAuxiliar.Text = "";
            this.txtHN.Text = "";
            this.txtPorteAnestesico.Text = "";
            this.txtRolSN.Text = "";
            this.txtValorCO.Text = "";
            this.txtValorFilme.Text = "";
            this.txtValorHM.Text = "";
            this.txtVlrIntercambio.Text = "";
            this.txtClassificacao.Text = "";
            this.txtQtdeMax.Text = "";
            this.txtDocRacionalizacao.Text = "";
            this.txtExecutora.Text = "";
            this.txtOrigem.Text = "";
            this.txtTotal.Text = "";
            this.txtAba.Text = "";
            this.txtFavoravel.Text = "";
            this.txtDesfavoravel.Text = "";
            this.txtEspecialidade.Text = "";            
            this.txtOpme.Clear();
            
            //this.txt_taxa_video.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
           this.Close();           
        }

        private void rbdAdminstrador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdAdminstrador.Checked)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void dganexo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dganexo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //AbrirDocumento();
            try
            {
                using (var com = AbrirConexao())
                {
                    com.Open();
                    using (var comando = com.CreateCommand())
                    {
                        comando.CommandText = "Select documento from arquivodut where (codigo = @codigo)";
                        ConfigurarParametrosAbrir(comando);
                        var bytes = comando.ExecuteScalar() as byte[];
                        if (bytes != null)
                        {
                            var nomeArquivo = dganexo.CurrentRow.Cells["nome_arquivo"].Value.ToString();
                            var arquivoTemp = Path.GetTempFileName();
                            arquivoTemp = Path.ChangeExtension(arquivoTemp, Path.GetExtension(nomeArquivo));
                            File.WriteAllBytes(arquivoTemp, bytes);
                            Process.Start(arquivoTemp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private IDbConnection AbrirConexao()
        {
            //return new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;");
            return new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\arquivodut.mdb;Persist Security Info=False;");
        }

        private void ConfigurarParametrosAbrir(IDbCommand com)
        {
            com.Parameters.Add(new OleDbParameter("codigo", dganexo.CurrentRow.Cells["codigo"].Value));

        }

       
    }
}
    

