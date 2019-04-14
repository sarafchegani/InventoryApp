using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.Framwork
{
    public class ViewEngine
    {
        Dictionary<string, Form> openForm = new Dictionary<string, Form>();
        public T ViewInForm<T>(bool DisplayIsDialog = false) where T : ViewBase
        {
            var viewInstance = (ViewBase)Activator.CreateInstance<T>();
            if (openForm.ContainsKey(viewInstance.ViewTitle))
            {
                var currentform = openForm[viewInstance.ViewTitle];
                currentform.Activate();
                return (T)currentform.Controls.OfType<T>().First();
            }
            var form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.RightToLeft = RightToLeft.Yes;
            form.Font = new System.Drawing.Font("Tahoma", 8);
            form.Text = viewInstance.ViewTitle;
            //form.ShowInTaskbar = false;
            form.Controls.Add(viewInstance);
            form.FormClosed += ((obj, e) => openForm.Remove(viewInstance.ViewTitle));
            viewInstance.Dock = DockStyle.Fill;
            openForm.Add(viewInstance.ViewTitle, form);

            if (DisplayIsDialog)
                form.ShowDialog();
            else
                form.Show();

            return (T)viewInstance;
        }

        internal void CloseView(ViewBase viewBase, DialogResult? dialogResult = null)
        {
            if (openForm.ContainsKey(viewBase.ViewIdentifier))
            {
                if (dialogResult.HasValue)
                {
                    viewBase.DialogResult = dialogResult.Value;
                    openForm[viewBase.ViewIdentifier].DialogResult = dialogResult.Value;
                }
                else
                    openForm[viewBase.ViewIdentifier].Close();
                openForm.Remove(viewBase.ViewIdentifier);
            }
        }
    }
}
