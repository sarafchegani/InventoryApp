using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.WinUi.view.systemform
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
        }
        private async Task<bool> CheckSqlConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["InventoryDBContext"].ConnectionString;
            var connectionstringBuilder = new SqlConnectionStringBuilder(connectionString);
            connectionstringBuilder.InitialCatalog = "master";
            try
            {
                using (var connection = new SqlConnection(connectionstringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                }
                return true;
            }
            catch
            {
                var DbFormSetting = new view.systemform.DBconnectionSettingsForm();
                this.Hide();
                var result = DbFormSetting.ShowDialog();
                this.Show();
                return result == DialogResult.OK;
            }
        }
        private async Task<bool> CheckExitDataBase()
        {
            lblstatus.Text = "در حال بررسی بانک اطلاعات ...";
            var connectionString = ConfigurationManager.ConnectionStrings["InventoryDBContext"].ConnectionString;
            var connectionstringBuilder = new SqlConnectionStringBuilder(connectionString);
            try
            {
                using (var connection = new SqlConnection(connectionstringBuilder.ConnectionString))
                {
                    await connection.OpenAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> CreateDatabase()
        {
            lblstatus.Text = "در حال ایجاد بانک اطلاعات ...";
            return await DataLayer.DatabaseMgmt.InitialDataBase();
        }
        private void lblExitApp_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private async void SplashScreenForm_Load(object sender, EventArgs e)
        {
            lblstatus.Text = "در حال بررسی ارتباط با سرور  ...";
            var ServerIsConnect = await CheckSqlConnection();
            if (!ServerIsConnect)
                DialogResult = DialogResult.Cancel;

            if (!await CheckExitDataBase())
                await CreateDatabase();
            DialogResult = DialogResult.OK;



        }
    }
}
