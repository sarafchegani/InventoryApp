using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.WinUi.view.Corporation
{
    public class Add : Framwork.EntityEditor<Entities.Corporation>
    {
        RepositortAbstracts.ICorporation Corps;
        public Add(RepositortAbstracts.ICorporation CorporationRepository)
        {
            this.Corps = CorporationRepository;
            ViewTitle = "تعریف شرکت";
        }
        protected override void OnLoad(EventArgs e)
        {
            TextBox(p => p.Title, "نام شرکت");
            TextBox(p => p.Telephone, "شماره تماس");
            TextBox(p => p.Address, "آدرس");
            TextBox(p => p.Description, "توضیحات",true);
            AdjustControls();
            base.OnLoad(e);
        }
    }
}
