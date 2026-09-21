using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_Dynamic_1._0.Resources.Transaction
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Transaction.ExportLC", "Resources/Transaction/ExportLC.b1f")]
    class ExportLC : UserFormBase
    {
        public ExportLC()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATMR").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATCM").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("STCOMPNY").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTMR").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("STSCNO").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("STLCNO").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("STLCDESC").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("STBP1BNK").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("STBP2BNK").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("STHUSBNK").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("STLCVAL").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("STISUDAT").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("STSHPDAT").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("STEXPDAT").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("STB2BPER").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("STB2BAMT").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("STLCTRMS").Specific));
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("STPYTRMS").Specific));
            this.StaticText21 = ((SAPbouiCOM.StaticText)(this.GetItem("STINTRMS").Specific));
            this.StaticText22 = ((SAPbouiCOM.StaticText)(this.GetItem("STAMDNO").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSTATMR").Specific));
            this.ComboBox1 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSTATCM").Specific));
            this.ComboBox2 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCOMPNY").Specific));
            this.ComboBox3 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            this.ComboBox4 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBINTRMS").Specific));
            this.ComboBox5 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPYTRMS").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("CBCUSTMR").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("ETSCNO").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("ETLCNO").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("ETLCDESC").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("ETBP1BNK").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("ETBP2BNK").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("ETHUSBNK").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("ETLCVAL").Specific));
            this.ComboBox6 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBLCTRMS").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("ETISUDAT").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("ETSHPDAT").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("ETEXPDAT").Specific));
            this.EditText15 = ((SAPbouiCOM.EditText)(this.GetItem("ETB2BPER").Specific));
            this.EditText16 = ((SAPbouiCOM.EditText)(this.GetItem("ETB2BAMT").Specific));
            this.EditText17 = ((SAPbouiCOM.EditText)(this.GetItem("ETAMDNO").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("TABSODR").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("TABAMDTL").Specific));
            this.Folder2 = ((SAPbouiCOM.Folder)(this.GetItem("TABATTCH").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSLODR").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTAC").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("GRDAMDTL").Specific));
            this.Button5 = ((SAPbouiCOM.Button)(this.GetItem("BTNLDATA").Specific));
            this.Button6 = ((SAPbouiCOM.Button)(this.GetItem("BTNAMND").Specific));
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
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.StaticText StaticText21;
        private SAPbouiCOM.StaticText StaticText22;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.ComboBox ComboBox1;
        private SAPbouiCOM.ComboBox ComboBox2;
        private SAPbouiCOM.ComboBox ComboBox3;
        private SAPbouiCOM.ComboBox ComboBox4;
        private SAPbouiCOM.ComboBox ComboBox5;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.ComboBox ComboBox6;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.EditText EditText13;
        private SAPbouiCOM.EditText EditText14;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.EditText EditText16;
        private SAPbouiCOM.EditText EditText17;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Folder Folder2;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button5;
        private SAPbouiCOM.Button Button6;
    }
}
