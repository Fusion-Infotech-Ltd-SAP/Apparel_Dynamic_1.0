using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_Dynamic_1._0.Resources.Master
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Master.CPMMaster", "Resources/Master/CPMMaster.b1f")]
    class CPMMaster : UserFormBase
    {
        public CPMMaster()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNDCD").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("STPDGPCD").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("STFRMDAT").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("STTODATE").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDCD").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDNM").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPCD").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPNM").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("ETFRMDAT").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("ETTODATE").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("TABSAMRN").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("TABCPM").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSAMRN").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("BTNWLN").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("BTNLDCPM").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCPM").Specific));
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
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.Matrix Matrix1;
    }
}
