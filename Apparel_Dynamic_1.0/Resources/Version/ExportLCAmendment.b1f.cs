using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_Dynamic_1._0.Resources.Version
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Version.ExportLCAmendment", "Resources/Version/ExportLCAmendment.b1f")]
    class ExportLCAmendment : UserFormBase
    {
        public ExportLCAmendment()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTCH").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.Matrix Matrix0;
    }
}
