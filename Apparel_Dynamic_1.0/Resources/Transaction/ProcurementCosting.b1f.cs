using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_Dynamic_1._0.Resources.Transaction
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Transaction.ProcurementCosting", "Resources/Transaction/ProcurementCosting.b1f")]
    class ProcurementCosting : UserFormBase
    {
        public ProcurementCosting()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLCD").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("STYLDESC").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTCD").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTNM").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("STDRFTNO").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("STCADNO").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("STVERSON").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("STODRQTY").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("STOLRNCE").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("STTLQTY").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_12").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLCD").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("ETYLDESC").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("ETSLNTRY").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTCD").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTNM").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("ETDRFTNO").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("ETDFNTRY").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("ETCADNO").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("ETCDNTRY").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("ETVERSON").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("ETODRQTY").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("ETOLRNCE").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("ETTLQTY").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSTYLCD").Specific));
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCUSTCD").Specific));
            this.LinkedButton2 = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCADNO").Specific));
            this.LinkedButton3 = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKDRFTNO").Specific));
            this.EditText15 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("TABFAB").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_36").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_37").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_38").Specific));
            this.Folder2 = ((SAPbouiCOM.Folder)(this.GetItem("Item_39").Specific));
            this.Folder3 = ((SAPbouiCOM.Folder)(this.GetItem("Item_40").Specific));
            this.Folder4 = ((SAPbouiCOM.Folder)(this.GetItem("Item_41").Specific));
            this.Folder5 = ((SAPbouiCOM.Folder)(this.GetItem("Item_42").Specific));
            this.Folder6 = ((SAPbouiCOM.Folder)(this.GetItem("Item_43").Specific));
            this.Folder7 = ((SAPbouiCOM.Folder)(this.GetItem("Item_44").Specific));
            this.Folder8 = ((SAPbouiCOM.Folder)(this.GetItem("Item_45").Specific));
            this.Folder9 = ((SAPbouiCOM.Folder)(this.GetItem("Item_46").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_47").Specific));
            this.EditText16 = ((SAPbouiCOM.EditText)(this.GetItem("Item_48").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_49").Specific));
            this.Matrix1 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_50").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_51").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_52").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_53").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_54").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_55").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_56").Specific));
            this.EditText17 = ((SAPbouiCOM.EditText)(this.GetItem("Item_57").Specific));
            this.EditText18 = ((SAPbouiCOM.EditText)(this.GetItem("Item_58").Specific));
            this.Matrix2 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_35").Specific));
            this.Matrix3 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_59").Specific));
            this.Matrix4 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_60").Specific));
            this.Matrix5 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_61").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_62").Specific));
            this.EditText19 = ((SAPbouiCOM.EditText)(this.GetItem("Item_63").Specific));
            this.Matrix6 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_64").Specific));
            this.EditText20 = ((SAPbouiCOM.EditText)(this.GetItem("Item_65").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_66").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_67").Specific));
            this.Matrix7 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_68").Specific));
            this.Matrix8 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_69").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_70").Specific));
            this.Matrix9 = ((SAPbouiCOM.Matrix)(this.GetItem("Item_71").Specific));
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_72").Specific));
            this.OnCustomInitialize();

        }

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
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.EditText EditText13;
        private SAPbouiCOM.EditText EditText14;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.LinkedButton LinkedButton2;
        private SAPbouiCOM.LinkedButton LinkedButton3;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Folder Folder2;
        private SAPbouiCOM.Folder Folder3;
        private SAPbouiCOM.Folder Folder4;
        private SAPbouiCOM.Folder Folder5;
        private SAPbouiCOM.Folder Folder6;
        private SAPbouiCOM.Folder Folder7;
        private SAPbouiCOM.Folder Folder8;
        private SAPbouiCOM.Folder Folder9;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.EditText EditText16;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Matrix Matrix1;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.EditText EditText17;
        private SAPbouiCOM.EditText EditText18;
        private SAPbouiCOM.Matrix Matrix2;
        private SAPbouiCOM.Matrix Matrix3;
        private SAPbouiCOM.Matrix Matrix4;
        private SAPbouiCOM.Matrix Matrix5;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.EditText EditText19;
        private SAPbouiCOM.Matrix Matrix6;
        private SAPbouiCOM.EditText EditText20;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.Matrix Matrix7;
        private SAPbouiCOM.Matrix Matrix8;
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.Matrix Matrix9;
        private SAPbouiCOM.Button Button4;
    }
}
