using IMEX.Services;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMEX
{
    public partial class Form1 : Form
    {
        private readonly RevendedorService _service = new RevendedorService();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMunicipio.Text) || string.IsNullOrWhiteSpace(cmbUF.Text))
            {
                MessageBox.Show("Informe a UF e o município!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnBuscar.Enabled = false;
                lblStatus.Text = "Buscando...";

                var lista = await _service.BuscarAsync(cmbUF.Text, txtMunicipio.Text);

                if (lista.Count == 0)
                {
                    dgvPostos.DataSource = null;
                    lblStatus.Text = "Nenhum revendedor encontrado.";
                    MessageBox.Show("Nenhum revendedor encontrado para os filtros informados.",
                        "Resultado da busca",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("CodigoSIMP");
                    table.Columns.Add("RazaoSocial");
                    table.Columns.Add("Cnpj");
                    table.Columns.Add("Endereco");
                    table.Columns.Add("Bairro");
                    table.Columns.Add("Cep");
                    table.Columns.Add("Uf");
                    table.Columns.Add("Municipio");
                    table.Columns.Add("Distribuidora");
                    table.Columns.Add("Classe");

                    foreach (var r in lista)
                    {
                        table.Rows.Add(
                            r.CodigoSIMP,
                            r.RazaoSocial,
                            r.Cnpj,
                            r.Endereco,
                            r.Bairro,
                            r.Cep,
                            r.Uf,
                            r.Municipio,
                            r.Distribuidora,
                            r.Classe
                        );
                    }

                    dgvPostos.DataSource = table;

                    // habilita ordenação automática em todas as colunas
                    foreach (DataGridViewColumn col in dgvPostos.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.Automatic;
                    }

                    lblStatus.Text = $"Encontrados {lista.Count} registros.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Erro na busca.";
            }
            finally
            {
                btnBuscar.Enabled = true;
            }
        }
    }
}