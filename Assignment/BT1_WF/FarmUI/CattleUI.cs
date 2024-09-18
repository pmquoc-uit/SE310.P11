using FarmBLL;
using System.Data;

namespace FarmUI
{
    public partial class CattleUI : Form
    {
        private readonly CattleService _cattleService;
        public CattleUI()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this._cattleService = new CattleService();
            this.CattleType.Items.Add("--Select--");
            this.CattleType.Items.Add("Bo");
            this.CattleType.Items.Add("Cuu");
            this.CattleType.Items.Add("De");
            this.CattleType.SelectedIndex = 0;
        }
        private void AddData_Click(object sender, EventArgs e)
        {
            if (int.TryParse(SoBo.Text, out int soBo) &&
                int.TryParse(SoCuu.Text, out int soCuu) &&
                int.TryParse(SoDe.Text, out int soDe))
            {
                try
                {
                    _cattleService.AddCattles(soBo, soCuu, soDe);
                    this.LoadDataGrid();
                    MessageBox.Show("Cattles added and displayed successfully!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding or displaying cattles: {ex.Message}!!!");
                }
            }
            else
            {
                MessageBox.Show("Input invalid!!!");
            }
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadDataGrid();
                MessageBox.Show("Cattles got and displayed successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting or displaying cattles: {ex.Message}!!!");
            }
        }
        private void LoadDataGrid()
        {

            DataTable cattlesData = _cattleService.GetCattles();
            CattleGridView.DataSource = cattlesData;
            CattleGridView.AutoResizeColumns();
            CattleGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
