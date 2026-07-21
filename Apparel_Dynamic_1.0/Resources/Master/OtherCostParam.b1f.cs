using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_Dynamic_1._0.Resources.Master
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Master.OtherCostParam", "Resources/Master/OtherCostParam.b1f")]
    class OtherCostParam : UserFormBase
    {
        public OtherCostParam()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSCOD").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSNAM").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSCOD").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSNAM").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCSPRM").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
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
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
    }
}
