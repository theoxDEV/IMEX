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

        private void dgvPostos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvPostos.Rows[e.RowIndex];
                var detalhe = $"Razão Social: {row.Cells["RazaoSocial"].Value}\n" +
                              $"CNPJ: {row.Cells["Cnpj"].Value}\n" +
                              $"Endereço: {row.Cells["Endereco"].Value}\n" +
                              $"Bairro: {row.Cells["Bairro"].Value}\n" +
                              $"CEP: {row.Cells["Cep"].Value}\n" +
                              $"Distribuidora: {row.Cells["Distribuidora"].Value}\n" +
                              $"Classe: {row.Cells["Classe"].Value}";

                MessageBox.Show(detalhe, "Detalhes do Revendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvPostos.DataSource is DataTable table)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "revendedores.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        // cabeçalho
                        var colunas = table.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
                        sw.WriteLine(string.Join(";", colunas));

                        // linhas
                        foreach (DataRow row in table.Rows)
                        {
                            var valores = row.ItemArray.Select(v => v?.ToString());
                            sw.WriteLine(string.Join(";", valores));
                        }
                    }
                    MessageBox.Show("Exportado com sucesso!");
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dgvPostos.DataSource is DataTable table)
            {
                string coluna = cmbColuna.SelectedItem?.ToString();
                string valor = txtFiltro.Text.Trim();

                if (!string.IsNullOrEmpty(coluna) && !string.IsNullOrEmpty(valor))
                    (dgvPostos.DataSource as DataTable).DefaultView.RowFilter = $"{coluna} LIKE '%{valor}%'";
                else
                    (dgvPostos.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
        }

    }
}