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

        private SAPbouiCOM.StaticText STSTATMR, STSTATCM, STCOMPNY, STCUSTMR, STSCNO, STLCNO, STLCDESC, STCURR, STBP1BNK, STBP2BNK, STHUSBNK, STLCVAL, STDOCNUM, STDOCDAT, STISUDAT, STSHPDAT, STEXPDAT, STB2BPER, STB2BAMT, STLCTRMS, STPYTRMS, STINTRMS, STAMDNO;

        private SAPbouiCOM.ComboBox CBSTATMR, CBSTATCM, CBCOMPNY, CBSERIES, CBINTRMS, CBPYTRMS, CBLCTRMS;

        private SAPbouiCOM.EditText CBCUSTMR, ETSCNO, ETLCNO, ETDOCTRY, ETDOCNUM, ETLCDESC, ETCURR, ETBP1BNK, ETBP2BNK, ETHUSBNK, ETLCVAL, ETDOCDAT, ETISUDAT, ETSHPDAT, ETEXPDAT, ETB2BPER, ETB2BAMT, ETAMDNO;

        private SAPbouiCOM.Folder TABSODR, TABAMDTL, TABATTCH;

        private SAPbouiCOM.Matrix MTXSLODR, MTXATTAC;

        private SAPbouiCOM.Button BRWSBTN, DISPBTN, DELBTN, BTNOK, BTNCANCEL, BTNLDATA, BTNAMND;

        private SAPbouiCOM.Grid GRDAMDTL;

        public override void OnInitializeComponent()
        {

            this.STSTATMR = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATMR").Specific));
            this.STSTATCM = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATCM").Specific));
            this.STCOMPNY = ((SAPbouiCOM.StaticText)(this.GetItem("STCOMPNY").Specific));
            this.STCUSTMR = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTMR").Specific));
            this.STSCNO = ((SAPbouiCOM.StaticText)(this.GetItem("STSCNO").Specific));
            this.STLCNO = ((SAPbouiCOM.StaticText)(this.GetItem("STLCNO").Specific));
            this.STLCDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STLCDESC").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STBP1BNK = ((SAPbouiCOM.StaticText)(this.GetItem("STBP1BNK").Specific));
            this.STBP2BNK = ((SAPbouiCOM.StaticText)(this.GetItem("STBP2BNK").Specific));
            this.STHUSBNK = ((SAPbouiCOM.StaticText)(this.GetItem("STHUSBNK").Specific));
            this.STLCVAL = ((SAPbouiCOM.StaticText)(this.GetItem("STLCVAL").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STDOCDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.STISUDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STISUDAT").Specific));
            this.STSHPDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STSHPDAT").Specific));
            this.STEXPDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STEXPDAT").Specific));
            this.STB2BPER = ((SAPbouiCOM.StaticText)(this.GetItem("STB2BPER").Specific));
            this.STB2BAMT = ((SAPbouiCOM.StaticText)(this.GetItem("STB2BAMT").Specific));
            this.STLCTRMS = ((SAPbouiCOM.StaticText)(this.GetItem("STLCTRMS").Specific));
            this.STPYTRMS = ((SAPbouiCOM.StaticText)(this.GetItem("STPYTRMS").Specific));
            this.STINTRMS = ((SAPbouiCOM.StaticText)(this.GetItem("STINTRMS").Specific));
            this.STAMDNO = ((SAPbouiCOM.StaticText)(this.GetItem("STAMDNO").Specific));

            this.CBSTATMR = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSTATMR").Specific));
            this.CBSTATCM = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSTATCM").Specific));
            this.CBCOMPNY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCOMPNY").Specific));
            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            this.CBINTRMS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBINTRMS").Specific));
            this.CBPYTRMS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPYTRMS").Specific));
            this.CBLCTRMS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBLCTRMS").Specific));

            this.CBCUSTMR = ((SAPbouiCOM.EditText)(this.GetItem("CBCUSTMR").Specific));
            this.ETSCNO = ((SAPbouiCOM.EditText)(this.GetItem("ETSCNO").Specific));
            this.ETLCNO = ((SAPbouiCOM.EditText)(this.GetItem("ETLCNO").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETLCDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETLCDESC").Specific));
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETBP1BNK = ((SAPbouiCOM.EditText)(this.GetItem("ETBP1BNK").Specific));
            this.ETBP2BNK = ((SAPbouiCOM.EditText)(this.GetItem("ETBP2BNK").Specific));
            this.ETHUSBNK = ((SAPbouiCOM.EditText)(this.GetItem("ETHUSBNK").Specific));
            this.ETLCVAL = ((SAPbouiCOM.EditText)(this.GetItem("ETLCVAL").Specific));
            this.ETDOCDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.ETISUDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETISUDAT").Specific));
            this.ETSHPDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETSHPDAT").Specific));
            this.ETEXPDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETEXPDAT").Specific));
            this.ETB2BPER = ((SAPbouiCOM.EditText)(this.GetItem("ETB2BPER").Specific));
            this.ETB2BAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETB2BAMT").Specific));
            this.ETAMDNO = ((SAPbouiCOM.EditText)(this.GetItem("ETAMDNO").Specific));

            this.TABSODR = ((SAPbouiCOM.Folder)(this.GetItem("TABSODR").Specific));
            this.TABAMDTL = ((SAPbouiCOM.Folder)(this.GetItem("TABAMDTL").Specific));
            this.TABATTCH = ((SAPbouiCOM.Folder)(this.GetItem("TABATTCH").Specific));

            this.MTXSLODR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSLODR").Specific));
            this.MTXATTAC = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTAC").Specific));

            this.BRWSBTN = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.DISPBTN = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.DELBTN = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.BTNOK = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.BTNCANCEL = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));

            this.GRDAMDTL = ((SAPbouiCOM.Grid)(this.GetItem("GRDAMDTL").Specific));

            this.BTNLDATA = ((SAPbouiCOM.Button)(this.GetItem("BTNLDATA").Specific));
            this.BTNAMND = ((SAPbouiCOM.Button)(this.GetItem("BTNAMND").Specific));
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
