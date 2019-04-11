using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace InventoryApp.WinUi.view.systemform
{
    public partial class DBconnectionSettingsForm : Form
    {
        public DBconnectionSettingsForm()
        {
            InitializeComponent();
        }
        private SqlConnectionStringBuilder connectionString;
        private void DBconnectionSettingsForm_Load(object sender, EventArgs e)
        {
            progressBarStatus.Visible = false;
            connectionString = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["InventoryDBContext"].ConnectionString);
            txtInitialCatalog.Text = connectionString.InitialCatalog;
            txtDataSource.Text = connectionString.DataSource;
            if (connectionString.IntegratedSecurity)
                txtUsername.Enabled = txtPassword.Enabled = lblPassword.Enabled = chkIntegratedSecurity.Checked = false;
            else
            {
                txtUsername.Enabled = txtPassword.Enabled = lblPassword.Enabled = chkIntegratedSecurity.Checked = true;
                txtUsername.Text = connectionString.UserID;
                txtPassword.Text = connectionString.Password;
            }

        }
        private void chkIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = txtPassword.Enabled = lblPassword.Enabled = chkIntegratedSecurity.Checked;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private async Task<bool> CheckServer()
        {
            SetData("master");
            try
            {
                using (var connection = new SqlConnection(connectionString.ConnectionString))
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
        private void SetData(string InitialCatalog)
        {
            connectionString.InitialCatalog = InitialCatalog;
            connectionString.DataSource = txtDataSource.Text;
            if (chkIntegratedSecurity.Checked)
            {
                connectionString.UserID = txtUsername.Text;
                connectionString.Password = txtPassword.Text;
                connectionString.IntegratedSecurity = false;
            }
            else
            {
                connectionString.IntegratedSecurity = true;
            }
            connectionString.MultipleActiveResultSets = true;
        }
        public void visiblecontrols(bool value)
        {
            btnSave.Visible = btnCancel.Visible = btnTestConnection.Visible =
                 txtDataSource.Enabled = txtInitialCatalog.Enabled=chkIntegratedSecurity.Enabled = value;
            if (!connectionString.IntegratedSecurity)
                txtUsername.Enabled = txtPassword.Enabled = lblPassword.Enabled = chkIntegratedSecurity.Checked =value ;
            progressBarStatus.Visible = !value;
        }
        private async void btnTestConnection_Click(object sender, EventArgs e)
        {
            visiblecontrols(false);
            try
            {
                if (await CheckServer() == true)
                {
                    MessageBox.Show("اتصال با موفقیت بر قرار شد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("اتصال با سرور بر قرار نشد", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
            finally
            {
                visiblecontrols(true);
            }



        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetData(txtInitialCatalog.Text);
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionstrings = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionstrings.ConnectionStrings["InventoryDBContext"].ConnectionString = connectionString.ConnectionString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("مشکل در ذخیره اطلاعات", "پیام سیستم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
