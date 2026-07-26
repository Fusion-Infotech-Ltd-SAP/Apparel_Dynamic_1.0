using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_Dynamic_1._0.Resources.Master
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Master.SAM", "Resources/Master/SAM.b1f")]
    class SAM : UserFormBase
    {
        public SAM()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("STDESC").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("ETDESC").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("FOLSAM").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("FOLCPM").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSAM").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("GRDCPM").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Grid Grid0;
    }
}
