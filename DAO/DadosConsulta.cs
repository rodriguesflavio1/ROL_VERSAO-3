using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Entidade;
using System.Data;
using System.IO;

namespace DAO
{
    public class DadosConsulta {

        EntidadeLogin dadosEntidadeLogin = new EntidadeLogin();
        EntidadeDut dadosConsultaDut = new EntidadeDut();
        EntidadesRol dadosConsulta = new EntidadesRol();
        EntidadeVersao dadosVersao = new EntidadeVersao();
        EntidadePorteMedico porteMedico = new EntidadePorteMedico();
        EntidadeDutDocumento dadosEntidadeDutDocumento = new EntidadeDutDocumento();
        byte[] buffer;

        public List<EntidadesRol> ResgataDadosRol(string codigo, string tabela, string campo)
        {
            List<EntidadesRol> list = new List<EntidadesRol>();
            string cmdText = string.Concat(new string[]
            {
                "SELECT * FROM ",
                tabela,
                " WHERE ",
                campo,
                " = ",
                codigo
            });
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\bd.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            OleDbDataReader oleDbDataReader = null;
            try
            {
                oleDbConnection.Open();
                oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (oleDbDataReader.Read())
                {
                   
                    if (tabela.Equals("amb_cbhpm_nov") || tabela.Equals("amb_cbhpm_ant"))
                    {
                        if (!oleDbDataReader.IsDBNull(8))
                        {
                            dadosConsulta.CodigoAMB = oleDbDataReader.GetDouble(8);
                        }
                        else
                        {
                            dadosConsulta.CodigoAMB = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(9))
                        {
                            dadosConsulta.DescricaoAMB = oleDbDataReader.GetString(9);
                        }
                        else
                        {
                            dadosConsulta.DescricaoAMB = "";
                        }
                        if (!oleDbDataReader.IsDBNull(0))
                        {
                            dadosConsulta.CodigoCBHPM = oleDbDataReader.GetDouble(0);
                        }
                        else
                        {
                            dadosConsulta.CodigoCBHPM = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(1))
                        {
                            dadosConsulta.DescricaoCBHPM = oleDbDataReader.GetString(1);
                        }
                        else
                        {
                            dadosConsulta.DescricaoCBHPM = "";
                        }
                    }
                    if (tabela.Equals("cbhpm_amb_nov") || tabela.Equals("cbhpm_amb_ant"))
                    {
                        if (!oleDbDataReader.IsDBNull(0))
                        {
                            dadosConsulta.CodigoAMB = oleDbDataReader.GetDouble(0);
                        }
                        else
                        {
                            dadosConsulta.CodigoAMB = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(1))
                        {
                            dadosConsulta.DescricaoAMB = oleDbDataReader.GetString(1);
                        }
                        else
                        {
                            dadosConsulta.DescricaoAMB = "";
                        }
                        if (!oleDbDataReader.IsDBNull(8))
                        {
                            dadosConsulta.CodigoCBHPM = oleDbDataReader.GetDouble(8);
                        }
                        else
                        {
                            dadosConsulta.CodigoCBHPM = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(9))
                        {
                            dadosConsulta.DescricaoCBHPM = oleDbDataReader.GetString(9);
                        }
                        else
                        {
                            dadosConsulta.DescricaoCBHPM = "";
                        }
                    }
                    if (!oleDbDataReader.IsDBNull(2))
                    {
                        dadosConsulta.ValorIntercambio = oleDbDataReader.GetDouble(2);
                    }
                    else
                    {
                        dadosConsulta.ValorIntercambio = 0.0;
                    }
                    if (!oleDbDataReader.IsDBNull(3))
                    {
                        dadosConsulta.ValorHm = oleDbDataReader.GetDouble(3);
                    }
                    else
                    {
                        dadosConsulta.ValorHm = 0.0;
                    }
                    if (!oleDbDataReader.IsDBNull(4))
                    {
                        dadosConsulta.ValorCo = oleDbDataReader.GetDouble(4);
                    }
                    else
                    {
                        dadosConsulta.ValorCo = 0.0;
                    }
                    if (!oleDbDataReader.IsDBNull(5))
                    {
                        dadosConsulta.Auxiliar = oleDbDataReader.GetString(5);
                    }
                    else
                    {
                        dadosConsulta.Auxiliar = "Não se aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(6))
                    {
                        dadosConsulta.PorteAnestesico = oleDbDataReader.GetString(6);
                    }
                    else
                    {
                        dadosConsulta.PorteAnestesico = "Não se aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(7))
                    {
                        dadosConsulta.ValorFilme = oleDbDataReader.GetDouble(7);
                    }
                    else
                    {
                        dadosConsulta.ValorFilme = 0.0;
                    }
                    if (!oleDbDataReader.IsDBNull(12))
                    {
                        dadosConsulta.Observacao = oleDbDataReader.GetString(12);
                    }
                    else
                    {
                        dadosConsulta.Observacao = "";
                    }
                    if (!oleDbDataReader.IsDBNull(11))
                    {
                        dadosConsulta.RolSn = oleDbDataReader.GetString(11);
                    }
                    else
                    {
                        dadosConsulta.RolSn = "Não se aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(10))
                    {
                        dadosConsulta.HmSadt = oleDbDataReader.GetString(10);
                    }
                    else
                    {
                        dadosConsulta.HmSadt = "Não se aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(13))
                    {
                        dadosConsulta.Classificacao = oleDbDataReader.GetString(13);
                    }
                    else
                    {
                        dadosConsulta.Classificacao = "Não se aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(14))
                    {
                        dadosConsulta.Quantidade = oleDbDataReader.GetInt32(14);
                    }
                    else
                    {
                        dadosConsulta.Quantidade = 0;
                    }
                    if (!oleDbDataReader.IsDBNull(15))
                    {
                        dadosConsulta.DocRacionalizacao = oleDbDataReader.GetString(15);
                    }
                    else
                    {
                        dadosConsulta.DocRacionalizacao = "";
                    }
                    if (!oleDbDataReader.IsDBNull(16))
                    {
                        dadosConsulta.Executora = oleDbDataReader.GetString(16);
                    }
                    else
                    {
                        dadosConsulta.Executora = "Não se aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(17))
                    {
                        dadosConsulta.Origem = oleDbDataReader.GetString(17);
                    }
                    else
                    {
                        dadosConsulta.Origem = "Não se aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(18))
                    {
                        dadosConsulta.Total = oleDbDataReader.GetString(18);
                    }
                    else
                    {
                        dadosConsulta.Total = "Não se aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(19))
                    {
                        dadosConsulta.Aba = oleDbDataReader.GetString(19);
                    }
                    else
                    {
                        dadosConsulta.Aba = "Não se aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(20))
                    {
                        dadosConsulta.DiferencaVersao = oleDbDataReader.GetString(20);
                    }
                    else
                    {
                        dadosConsulta.DiferencaVersao = "";
                    }
                    if (!oleDbDataReader.IsDBNull(21))
                    {
                        dadosConsulta.Taxa_video = oleDbDataReader.GetDouble(21);
                    }
                    else
                    {
                        dadosConsulta.Taxa_video = 0.0;
                    }
                    list.Add(dadosConsulta);
                }
            }
            finally
            {
                if (oleDbDataReader != null)
                {
                    oleDbDataReader.Close();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return list;
        }

        public List<EntidadesRol> ResgataDadosSadt(string codigo, string tabela, string campo)
        {
            List<EntidadesRol> list = new List<EntidadesRol>();
            string cmdText = string.Concat(new string[]
            {
                "SELECT * FROM ",
                tabela,
                " WHERE ",
                campo,
                " = ",
                codigo
            });
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\sadt.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            OleDbDataReader oleDbDataReader = null;
            try
            {
                oleDbConnection.Open();
                oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (oleDbDataReader.Read())
                {

                    if (tabela.Equals("sadt") || tabela.Equals("sadt_ant"))
                    {

                        if (!oleDbDataReader.IsDBNull(0))
                        {
                            dadosConsulta.CodigoCBHPM = oleDbDataReader.GetDouble(0);
                        }
                        else
                        {
                            dadosConsulta.CodigoCBHPM = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(1))
                        {
                            dadosConsulta.DescricaoCBHPM = oleDbDataReader.GetString(1);
                        }
                        else
                        {
                            dadosConsulta.DescricaoCBHPM = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(2))
                        {
                            dadosConsulta.ValorIntercambio = oleDbDataReader.GetDouble(2);
                        }
                        else
                        {
                            dadosConsulta.ValorIntercambio = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(3))
                        {
                            dadosConsulta.ValorHm = oleDbDataReader.GetDouble(3);
                        }
                        else
                        {
                            dadosConsulta.ValorHm = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(4))
                        {
                            dadosConsulta.ValorCo = oleDbDataReader.GetDouble(4);
                        }
                        else
                        {
                            dadosConsulta.ValorCo = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(5))
                        {
                            dadosConsulta.Auxiliar = oleDbDataReader.GetString(5);
                        }
                        else
                        {
                            dadosConsulta.Auxiliar = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(6))
                        {
                            dadosConsulta.PorteAnestesico = oleDbDataReader.GetString(6);
                            switch (Convert.ToInt32(dadosConsulta.PorteAnestesico))
                            {

                                case 1:
                                    dadosConsulta.PorteAnestesico = "R$ 135,78";
                                    break;
                                case 2:
                                    dadosConsulta.PorteAnestesico = "R$ 198,73";
                                    break;
                                case 3:
                                    dadosConsulta.PorteAnestesico = "R$ 292,50";
                                    break;
                                case 4:
                                    dadosConsulta.PorteAnestesico = " R$ 432,47";
                                    break;
                                case 5:
                                    dadosConsulta.PorteAnestesico = "R$ 668,97";
                                    break;
                                case 6:
                                    dadosConsulta.PorteAnestesico = "R$ 933,50";
                                    break;
                                case 7:
                                    dadosConsulta.PorteAnestesico = "R$ 1.328,15";
                                    break;
                                case 8:
                                    dadosConsulta.PorteAnestesico = " R$ 1.752,22";
                                    break;
                                default:
                                    dadosConsulta.PorteAnestesico = "0";
                                    break;

                            }
                        }
                        else
                        {
                            dadosConsulta.PorteAnestesico = "0";
                        }
                        if (!oleDbDataReader.IsDBNull(7))
                        {
                            dadosConsulta.ValorFilme = oleDbDataReader.GetDouble(7);
                        }
                        else
                        {
                            dadosConsulta.ValorFilme = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(8))
                        {
                            dadosConsulta.Taxa_video = oleDbDataReader.GetDouble(8);
                        }
                        else
                        {
                            dadosConsulta.Taxa_video = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(9))
                        {
                            dadosConsulta.Classificacao = oleDbDataReader.GetString(9);
                        }
                        else
                        {
                            dadosConsulta.Classificacao = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(10))
                        {
                            dadosConsulta.Quantidade = (Int16)oleDbDataReader.GetDouble(10);
                        }
                        else
                        {
                            dadosConsulta.Quantidade = 0;
                        }
                        if (!oleDbDataReader.IsDBNull(11))
                        {
                            dadosConsulta.DocRacionalizacao = oleDbDataReader.GetString(11);
                        }
                        else
                        {
                            dadosConsulta.DocRacionalizacao = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(12))
                        {
                            dadosConsulta.Executora = oleDbDataReader.GetString(12);
                        }
                        else
                        {
                            dadosConsulta.Executora = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(13))
                        {
                            dadosConsulta.Origem = oleDbDataReader.GetString(13);
                        }
                        else
                        {
                            dadosConsulta.Origem = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(14))
                        {
                            dadosConsulta.Total = oleDbDataReader.GetString(14);
                        }
                        else
                        {
                            dadosConsulta.Total = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(15))
                        {
                            dadosConsulta.HmSadt = oleDbDataReader.GetString(15);
                        }
                        else
                        {
                            dadosConsulta.HmSadt = "Não se Aplica";
                        }
                    }
                    
                    
                    list.Add(dadosConsulta);
                }
            }
            finally
            {
                if (oleDbDataReader != null)
                {
                    oleDbDataReader.Close();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return list;
        }

        public List<EntidadesRol> ResgataDadosHM(string codigo, string tabela, string campo)
        {
            List<EntidadesRol> list = new List<EntidadesRol>();
            string cmdText = string.Concat(new string[]
            {
                "SELECT * FROM ",
                tabela,
                " WHERE ",
                campo,
                " = ",
                codigo
            });
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\HM.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            OleDbDataReader oleDbDataReader = null;
            try
            {
                oleDbConnection.Open();
                oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (oleDbDataReader.Read())
                {

                    if (tabela.Equals("HM") || tabela.Equals("HM_ant"))
                    {

                        if (!oleDbDataReader.IsDBNull(0))
                        {
                            dadosConsulta.CodigoCBHPM = oleDbDataReader.GetDouble(0);
                        }
                        else
                        {
                            dadosConsulta.CodigoCBHPM = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(1))
                        {
                            dadosConsulta.DescricaoCBHPM = oleDbDataReader.GetString(1);
                        }
                        else
                        {
                            dadosConsulta.DescricaoCBHPM = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(2))
                        {
                            dadosConsulta.ValorIntercambioHM = oleDbDataReader.GetString(2);
                        }
                        else
                        {
                            dadosConsulta.ValorIntercambioHM = "Não se Aplica";
                        }
                        //if (!oleDbDataReader.IsDBNull(3))
                        //{
                        //    dadosConsulta.ValorHm = oleDbDataReader.GetDouble(3);
                        //}
                        //else
                        //{
                        //    dadosConsulta.ValorHm = 0.0;
                        //}
                        //if (!oleDbDataReader.IsDBNull(4))
                        //{
                        //    dadosConsulta.ValorCo = oleDbDataReader.GetDouble(4);
                        //}
                        //else
                        //{
                        //    dadosConsulta.ValorCo = 0.0;
                        //}
                        if (!oleDbDataReader.IsDBNull(3))
                        {
                            dadosConsulta.Auxiliar = oleDbDataReader.GetString(3);
                        }
                        else
                        {
                            dadosConsulta.Auxiliar = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(4))
                        {
                            dadosConsulta.PorteAnestesico = oleDbDataReader.GetString(4);
                            switch (Convert.ToInt32(dadosConsulta.PorteAnestesico)) {

                                case 1:
                                    dadosConsulta.PorteAnestesico = "R$ 135,78";
                                    break;
                                case 2:
                                    dadosConsulta.PorteAnestesico = "R$ 198,73";
                                    break;
                                case 3:
                                    dadosConsulta.PorteAnestesico = "R$ 292,50";
                                    break;
                                case 4:
                                    dadosConsulta.PorteAnestesico = " R$ 432,47";
                                    break;
                                case 5:
                                    dadosConsulta.PorteAnestesico = "R$ 668,97";
                                    break;
                                case 6:
                                    dadosConsulta.PorteAnestesico = "R$ 933,50";
                                    break;
                                case 7:
                                    dadosConsulta.PorteAnestesico = "R$ 1.328,15";
                                    break;
                                case 8:
                                    dadosConsulta.PorteAnestesico = " R$ 1.752,22";
                                    break;
                                default:
                                    dadosConsulta.PorteAnestesico = "0";
                                    break;
                            }
                        }
                        else
                        {
                            dadosConsulta.PorteAnestesico = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(5))
                        {
                            dadosConsulta.ValorFilme = oleDbDataReader.GetDouble(5);
                        }
                        else
                        {
                            dadosConsulta.ValorFilme = 0.0;
                        }
                        if (!oleDbDataReader.IsDBNull(6))
                        {
                            dadosConsulta.CodigoAMB = Convert.ToDouble(oleDbDataReader.GetString(6));
                        }
                        else
                        {
                            dadosConsulta.CodigoAMB = 0;
                        }
                        if (!oleDbDataReader.IsDBNull(7))
                        {
                            dadosConsulta.Classificacao = oleDbDataReader.GetString(7);
                        }
                        else
                        {
                            dadosConsulta.Classificacao = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(8))
                        {
                            dadosConsulta.Quantidade = Convert.ToInt32(oleDbDataReader.GetDouble(8));
                        }
                        else
                        {
                            dadosConsulta.Quantidade = 0;
                        }
                        if (!oleDbDataReader.IsDBNull(9))
                        {
                            dadosConsulta.DocRacionalizacao = oleDbDataReader.GetString(9);
                        }
                        else
                        {
                            dadosConsulta.DocRacionalizacao = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(10))
                        {
                            dadosConsulta.Executora = oleDbDataReader.GetString(10);
                        }
                        else
                        {
                            dadosConsulta.Executora = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(11))
                        {
                            dadosConsulta.Origem = oleDbDataReader.GetString(11);
                        }
                        else
                        {
                            dadosConsulta.Origem = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(12))
                        {
                            dadosConsulta.Total = oleDbDataReader.GetString(12);
                        }
                        else
                        {
                            dadosConsulta.Total = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(13))
                        {
                            dadosConsulta.HmSadt = oleDbDataReader.GetString(13);
                        }
                        else
                        {
                            dadosConsulta.HmSadt = "Não se Aplica";
                        }
                    }


                    list.Add(dadosConsulta);
                }
            }
            finally
            {
                if (oleDbDataReader != null)
                {
                    oleDbDataReader.Close();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return list;
        }

        public List<EntidadesRol> ResgataDadosAba(string codigo, string tabela, string campo)
        {
            List<EntidadesRol> list = new List<EntidadesRol>();
            string cmdText = string.Concat(new string[]
            {
                "SELECT * FROM ",
                tabela,
                " WHERE ",
                campo,
                " = ",
                codigo
            });
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
           // string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\Aba.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            OleDbDataReader oleDbDataReader = null;            
            try
            {
                oleDbConnection.Open();               
                oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (oleDbDataReader.Read())
                {                   
                        if (!oleDbDataReader.IsDBNull(1))
                        {
                            dadosConsulta.Observacao = oleDbDataReader.GetString(2);
                        }
                        else
                        {
                            dadosConsulta.Observacao = "Não se Aplica";
                        }
                        if (!oleDbDataReader.IsDBNull(2))
                        {
                            dadosConsulta.Aba = oleDbDataReader.GetString(1);
                        }
                        else
                        {
                        dadosConsulta.Aba = "Não se Aplica";
                        }                                     
                   
                    list.Add(dadosConsulta);
                }
            }
            finally
            {
                if (oleDbDataReader != null)
                {
                    oleDbDataReader.Close();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return list;
        }

        public List<EntidadeVersao> ResgataDadosVersao(string codigo, string tabela, string campo)
        {
            List<EntidadeVersao> list = new List<EntidadeVersao>();
            string cmdText = string.Concat(new string[]
            {
                "SELECT * FROM ",
                "versao" //,
                //" WHERE ",
                //campo,
                //" = ",
                //codigo
            });
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\Aba.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            OleDbDataReader oleDbDataReader = null;
            try
            {
                oleDbConnection.Open();
                oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (oleDbDataReader.Read())
                {
                    if (!oleDbDataReader.IsDBNull(1))
                    {
                        dadosVersao.VersaoAnt = oleDbDataReader.GetString(1);
                    }
                    else
                    {
                        dadosVersao.VersaoAtual = "Não se Aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(2))
                    {
                        dadosVersao.VersaoAtual = oleDbDataReader.GetString(2);
                    }
                    else
                    {
                        dadosVersao.VersaoAtual = "Não se Aplica";
                    }

                    list.Add(dadosVersao);
                }
            }
            finally
            {
                if (oleDbDataReader != null)
                {
                    oleDbDataReader.Close();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return list;
        }

        public List<EntidadesRol> ResgataDadosDut(string codigo, string tabela, string campo)
        {
            List<EntidadesRol> list = new List<EntidadesRol>();
            string cmdText = string.Concat(new string[]
            {
                "SELECT * FROM ",
                tabela,
                " WHERE ",
                campo,
                " = ",
                codigo
            });
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\dut.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            OleDbDataReader oleDbDataReader = null;
            try
            {
                oleDbConnection.Open();
                oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (oleDbDataReader.Read())
                {


                    if (!oleDbDataReader.IsDBNull(1))
                    {
                        dadosConsulta.Dut = oleDbDataReader.GetString(1);
                        
                    }
                    else
                    {
                        dadosConsulta.Dut = "Não se Aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(2))
                    {
                        dadosConsulta.Opme = oleDbDataReader.GetString(2);
                    }
                    else
                    {
                        dadosConsulta.Opme = "Não se Aplica";
                    }

                    if (!oleDbDataReader.IsDBNull(3))
                    {
                        dadosConsulta.Especialidade = oleDbDataReader.GetString(3);
                    }
                    else
                    {
                        dadosConsulta.Especialidade = "Não se Aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(4))
                    {
                        dadosConsulta.Favoravel = oleDbDataReader.GetString(4);
                    }
                    if (!oleDbDataReader.IsDBNull(5))
                    {
                        dadosConsulta.Desfavoravel = oleDbDataReader.GetString(5);
                    }
                    else
                    {
                        dadosConsulta.Aba = "Não se Aplica";
                    }



                    list.Add(dadosConsulta);
                }
            }
            finally
            {
                if (oleDbDataReader != null)
                {
                    oleDbDataReader.Close();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return list;
        }

        public DataTable ResgatarDocumentoDut(string codigo, string tabela, string campo)
        {
            List<EntidadeDutDocumento> list = new List<EntidadeDutDocumento>();
            string cmdText = string.Concat(new string[]
            {
                "SELECT codigo,cod_servico,descricao,nome_arquivo FROM ",
                tabela,
                " WHERE ",
                campo,
                " = ",
                codigo
            });
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\arquivodut.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            OleDbDataAdapter oleDBDataAdapter = new OleDbDataAdapter(oleDbCommand);
            DataTable dataTable = new DataTable();
                       
            try
            {
                oleDbConnection.Open();               
                oleDBDataAdapter.Fill(dataTable);               
            }
            finally
            {
                if (oleDBDataAdapter != null)
                {
                    oleDBDataAdapter.Dispose();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return dataTable;
        }

        public byte[] AbrirDocumentoDut(string codigo, string tabela, string campo)
        {
            List<EntidadeDutDocumento> list = new List<EntidadeDutDocumento>();
            string cmdText = string.Concat(new string[]
            {
                "SELECT documento FROM ",
                tabela,
                " WHERE ",
                campo,
                " = ",
                codigo
            });
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\arquivodut.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            
            try
            {
                oleDbConnection.Open();                
                buffer = oleDbCommand.ExecuteScalar() as byte[];
            }
            finally
            {
                if (oleDbCommand != null)
                {
                    oleDbCommand.Dispose();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return buffer;
        }

        public List<EntidadeDut> ResgatarDadosManutencaoDut(string codigo, string tabela, string campo)
        {
            List<EntidadeDut> list = new List<EntidadeDut>();
            string cmdText = string.Concat(new string[]
            {
                "SELECT * FROM ",
                tabela,
                " WHERE ",
                campo,
                " = ",
                codigo
            });
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\dut.mdb;Persist Security Info=False;";
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            OleDbDataReader oleDbDataReader = null;
            try
            {
                oleDbConnection.Open();
                oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (oleDbDataReader.Read())
                {

                    if (!oleDbDataReader.IsDBNull(0))
                    {
                        dadosConsultaDut.Codigo = oleDbDataReader.GetDouble(0);
                    }
                    else
                    {
                        dadosConsultaDut.Codigo = 0;
                    }
                    if (!oleDbDataReader.IsDBNull(1))
                    {
                        dadosConsultaDut.Dut = oleDbDataReader.GetString(1);
                    }
                    else
                    {
                        dadosConsultaDut.Dut = "Não se Aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(2))
                    {
                        dadosConsultaDut.Opme = oleDbDataReader.GetString(2);
                    }
                    else
                    {
                        dadosConsultaDut.Opme = "Não se Aplica";
                    }

                    if (!oleDbDataReader.IsDBNull(3))
                    {
                        dadosConsultaDut.Especialidade = oleDbDataReader.GetString(3);
                    }
                    else
                    {
                        dadosConsultaDut.Especialidade = "Não se Aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(4))
                    {
                        dadosConsultaDut.Favoravel = oleDbDataReader.GetString(4);
                    }
                    if (!oleDbDataReader.IsDBNull(5))
                    {
                        dadosConsultaDut.Desfavoravel = oleDbDataReader.GetString(5);
                    }
                    else
                    {
                        dadosConsulta.Aba = "Não se Aplica";
                    }
                    list.Add(dadosConsultaDut);
                }
            }
            finally
            {
                if (oleDbDataReader != null)
                {
                    oleDbDataReader.Close();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return list;
        }

        public List<EntidadePorteMedico> ResgataDadosPorteMedico(string codigo)
        {
            List<EntidadePorteMedico> list = new List<EntidadePorteMedico>();
            string stringWithEscapes = $"SELECT * FROM PorteMedico WHERE Porte = {codigo.Trim()} ";
               
            string cmdText = string.Concat(new string[]
           {
                "SELECT * FROM PorteMedico WHERE Porte",
                " = ",
                codigo
           });
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\HM.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(stringWithEscapes, oleDbConnection);
            //OleDbDataAdapter adapter = new OleDbDataAdapter();
            //adapter.SelectCommand = new OleDbCommand(cmdText, oleDbConnection);
           
            OleDbDataReader oleDbDataReader = null;
            try
            {
                oleDbConnection.Open();
                oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                

                while (oleDbDataReader.Read())
                {

                    if (!oleDbDataReader.IsDBNull(0))
                    {
                        porteMedico.CodigoPorteMedico = oleDbDataReader.GetString(0);
                    }
                    else
                    {
                        porteMedico.CodigoPorteMedico = "Não se Aplica";
                    }
                    if (!oleDbDataReader.IsDBNull(1))
                    {
                        porteMedico.ValorPorteMedico = oleDbDataReader.GetDouble(1);
                    }
                    else
                    {
                        porteMedico.ValorPorteMedico = 0.0;
                    }

                    list.Add(porteMedico);
                }
            }
            finally
            {
                if (oleDbDataReader != null)
                {
                    oleDbDataReader.Dispose();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return list;
        }

        public List<EntidadeLogin> ResgatarUsuario(string nome, string senha) {

            List<EntidadeLogin> listaEntidade = new List<EntidadeLogin>();
            string cmdText = $"SELECT * FROM Usuario WHERE nome = \'{nome.Trim()}\' and senha = \'{senha.Trim()}\' ";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\Usuario.mdb;Persist Security Info=False;";
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            OleDbDataReader oleDbDataReader = null;
            try
            {
                oleDbConnection.Open();
                oleDbDataReader = oleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (oleDbDataReader.Read())
                {
                    if (!oleDbDataReader.IsDBNull(1))
                    {
                        dadosEntidadeLogin.Usuario = oleDbDataReader.GetString(1);

                    }
                    
                    if (!oleDbDataReader.IsDBNull(2))
                    {
                        dadosEntidadeLogin.Senha = oleDbDataReader.GetString(2);
                    }
                    listaEntidade.Add(dadosEntidadeLogin);
                }
            }
            finally
            {
                if (oleDbDataReader != null)
                {
                    oleDbDataReader.Close();
                }
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
            return listaEntidade;

        }

        public void InserirDut(EntidadeDut entidadeDut) {
            var cmdText = "";
            cmdText += "INSERT INTO dut(Codigo,DUT,OPME,Especialidade,Favoravel,Desfavoravel)";
            cmdText += string.Format(" values ('{0}','{1}','{2}','{3}','{4}','{5}') ", entidadeDut.Codigo,entidadeDut.Dut,entidadeDut.Opme,entidadeDut.Especialidade,entidadeDut.Favoravel,entidadeDut.Desfavoravel);

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
           //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\dut.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
           
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
        }

        public void AlterarDut(EntidadeDut entidadeDut)
        {
            var strQuery = "";
            strQuery += "update dut set";
            strQuery += string.Format(" DUT =  '{0}', ", entidadeDut.Dut);
            strQuery += string.Format(" OPME =  '{0}' ,", entidadeDut.Opme);
            strQuery += string.Format(" Especialidade =  '{0}' ,", entidadeDut.Especialidade);
            strQuery += string.Format(" Favoravel =  '{0}' ,", entidadeDut.Favoravel);
            strQuery += string.Format(" Desfavoravel =  '{0}' ", entidadeDut.Desfavoravel);
            strQuery += string.Format(" WHERE Codigo =  {0} ", entidadeDut.Codigo);

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
        }

        public void AlterarArquivoDut(EntidadeDutDocumento entidadeDutDocumento,int codigo)
        {
            var strQuery = "";
            strQuery += "update dut set";
            strQuery += string.Format(" codigo_servico =  '{0}', ", entidadeDutDocumento.Codigo_servico);
            strQuery += string.Format(" descricao =  '{0}' ,", entidadeDutDocumento.Descricao);
            strQuery += string.Format(" documento =  '{0}' ,", entidadeDutDocumento.Documento);
            strQuery += string.Format(" WHERE Codigo =  {0} ", codigo);

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
        }

        public void InserirArquivoDut(EntidadeDutDocumento entidadeDutDocumento)
        {
            var cmdText = "";
            cmdText += "INSERT INTO arquivodut(cod_servico,documento,descricao,nome_arquivo)";
            cmdText += string.Format("values ('{0}','{1}','{2}','{3}')", entidadeDutDocumento.Codigo_servico, entidadeDutDocumento.Documento, entidadeDutDocumento.Descricao, entidadeDutDocumento.NomeArquivo);

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\arquivodut.mdb;Persist Security Info=False;";
            OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
            
            try
            {
                oleDbConnection.Open();

                oleDbCommand.Parameters.Add(new OleDbParameter("@documento", File.ReadAllBytes(entidadeDutDocumento.Documento)));
                oleDbCommand.Parameters.Add(new OleDbParameter("@codigo_servico", entidadeDutDocumento.Codigo_servico));
                oleDbCommand.Parameters.Add(new OleDbParameter("@descricao", entidadeDutDocumento.Descricao));
                oleDbCommand.Parameters.Add(new OleDbParameter("@nome_arquivo", Path.GetFileName(entidadeDutDocumento.NomeArquivo)));
                oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            oleDbConnection.Dispose();
            oleDbConnection.Close();
        }

        public void ExcluirArquivoDut(int codigo)
        {
            var strQuery = "";
            strQuery += "delete from arquivodut";
            strQuery += string.Format(" WHERE Codigo =  {0} ", codigo);
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\flavio.barbosa\Desktop\ROL_VERSAO 3\ROL\bin\Debug\bd.mdb;Persist Security Info=False;";
            //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.10.0.25\ROL\arquivodut.mdb;Persist Security Info=False;";
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
        }
    }
}
