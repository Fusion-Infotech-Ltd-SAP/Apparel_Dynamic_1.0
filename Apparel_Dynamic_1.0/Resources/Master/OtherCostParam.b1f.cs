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

        private SAPbouiCOM.StaticText STCUSCOD, STCUSNAM;
        private SAPbouiCOM.EditText ETCUSCOD, ETDOCTRY, ETCUSNAM;

        private SAPbouiCOM.Matrix MTXCSPRM;
        private SAPbouiCOM.Button ADDButton, CancelButton;


        public override void OnInitializeComponent()
        {
            this.STCUSCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSCOD").Specific));
            this.STCUSNAM = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSNAM").Specific));
            this.ETCUSCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSCOD").Specific));
            this.ETCUSNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSNAM").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.MTXCSPRM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCSPRM").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
        }


        private void OnCustomInitialize()
        {

        }
        
    }
}
