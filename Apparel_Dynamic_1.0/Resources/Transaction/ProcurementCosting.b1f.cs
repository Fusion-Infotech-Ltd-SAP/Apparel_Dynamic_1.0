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



        private SAPbouiCOM.StaticText STSTYLCD, STYLDESC, STCUSTCD, STCUSTNM, STDRFTNO, STCADNO, STDOCNUM, STDOCDAT, STVERSON, STODRQTY, STOLRNCE, STTLQTY, STFOB, STREMRKS, STCOLOR, STCONTNT, STSLFOB, STSLCLR, STLPRCST, STTLCSEL;

       

        private SAPbouiCOM.EditText ETSTYLCD, ETYLDESC, ETSLNTRY, ETCUSTCD, ETCUSTNM, ETDRFTNO, ETDFNTRY, ETCADNO, ETCDNTRY, ETDOCNUM, ETDOCDAT, ETVERSON, ETODRQTY, ETOLRNCE, ETTLQTY, ETDOCTRY, ETREMRKS, ETSLFOB, ETSLCLR, ETLPRCST, ETTLCSEL;

        private SAPbouiCOM.ComboBox CBSERIES;

        private SAPbouiCOM.LinkedButton LKSTYLCD, LKCUSTCD, LKCADNO, LKDRFTNO;

        private SAPbouiCOM.Folder TABFAB, TABTRMS, TABOTCST, TABPRCST, TABCSTEL, TABCOMM, TABSUMM, TABVRSN, TABTMFAB, TABTPTRM;

        private SAPbouiCOM.Matrix MTXFOB, MTXCOLOR, MTXTMFAB, MTXTRMS, MTXOTCST, MTXPRCST, MTXCSTEL, MTXSUMRY, MTXCOMSN, MTXTMTRM;

        private SAPbouiCOM.Grid GRDFAB, GRDVRSN;

        private SAPbouiCOM.Button ADDButton, BTNCANCEL, BTNLDFAB, BTNLDCEL, BTNSAVE;


        public override void OnInitializeComponent()
        {
            //StaticText

            this.STSTYLCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLCD").Specific));
            this.STYLDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STYLDESC").Specific));
            this.STCUSTCD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTCD").Specific));
            this.STCUSTNM = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTNM").Specific));
            this.STDRFTNO = ((SAPbouiCOM.StaticText)(this.GetItem("STDRFTNO").Specific));
            this.STCADNO = ((SAPbouiCOM.StaticText)(this.GetItem("STCADNO").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STDOCDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.STVERSON = ((SAPbouiCOM.StaticText)(this.GetItem("STVERSON").Specific));
            this.STODRQTY = ((SAPbouiCOM.StaticText)(this.GetItem("STODRQTY").Specific));
            this.STOLRNCE = ((SAPbouiCOM.StaticText)(this.GetItem("STOLRNCE").Specific));
            this.STTLQTY = ((SAPbouiCOM.StaticText)(this.GetItem("STTLQTY").Specific));
            this.STFOB = ((SAPbouiCOM.StaticText)(this.GetItem("STFOB").Specific));
            this.STREMRKS = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRKS").Specific));
            this.STCOLOR = ((SAPbouiCOM.StaticText)(this.GetItem("STCOLOR").Specific));
            this.STCONTNT = ((SAPbouiCOM.StaticText)(this.GetItem("STCONTNT").Specific));
            this.STSLFOB = ((SAPbouiCOM.StaticText)(this.GetItem("STSLFOB").Specific));
            this.STSLCLR = ((SAPbouiCOM.StaticText)(this.GetItem("STSLCLR").Specific));
            this.STLPRCST = ((SAPbouiCOM.StaticText)(this.GetItem("STLPRCST").Specific));
            this.STTLCSEL = ((SAPbouiCOM.StaticText)(this.GetItem("STTLCSEL").Specific));
            
            //EditText

            this.ETSTYLCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLCD").Specific));
            this.ETYLDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETYLDESC").Specific));
            this.ETSLNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETSLNTRY").Specific));
            this.ETCUSTCD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTCD").Specific));
            this.ETCUSTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTNM").Specific));
            this.ETDRFTNO = ((SAPbouiCOM.EditText)(this.GetItem("ETDRFTNO").Specific));
            this.ETDFNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDFNTRY").Specific));
            this.ETCADNO = ((SAPbouiCOM.EditText)(this.GetItem("ETCADNO").Specific));
            this.ETCDNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETCDNTRY").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETDOCDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.ETVERSON = ((SAPbouiCOM.EditText)(this.GetItem("ETVERSON").Specific));
            this.ETODRQTY = ((SAPbouiCOM.EditText)(this.GetItem("ETODRQTY").Specific));
            this.ETOLRNCE = ((SAPbouiCOM.EditText)(this.GetItem("ETOLRNCE").Specific));
            this.ETTLQTY = ((SAPbouiCOM.EditText)(this.GetItem("ETTLQTY").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETREMRKS = ((SAPbouiCOM.EditText)(this.GetItem("ETREMRKS").Specific));
            this.ETSLFOB = ((SAPbouiCOM.EditText)(this.GetItem("ETSLFOB").Specific));
            this.ETSLCLR = ((SAPbouiCOM.EditText)(this.GetItem("ETSLCLR").Specific));
            this.ETLPRCST = ((SAPbouiCOM.EditText)(this.GetItem("ETLPRCST").Specific));
            this.ETTLCSEL = ((SAPbouiCOM.EditText)(this.GetItem("ETTLCSEL").Specific));



            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));

           // LinkedButton

            this.LKSTYLCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSTYLCD").Specific));
            this.LKCUSTCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCUSTCD").Specific));
            this.LKCADNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCADNO").Specific));
            this.LKDRFTNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKDRFTNO").Specific));


            //Folder

            this.TABFAB = ((SAPbouiCOM.Folder)(this.GetItem("TABFAB").Specific));
            this.TABTRMS = ((SAPbouiCOM.Folder)(this.GetItem("TABTRMS").Specific));
            this.TABOTCST = ((SAPbouiCOM.Folder)(this.GetItem("TABOTCST").Specific));
            this.TABPRCST = ((SAPbouiCOM.Folder)(this.GetItem("TABPRCST").Specific));
            this.TABCSTEL = ((SAPbouiCOM.Folder)(this.GetItem("TABCSTEL").Specific));
            this.TABCOMM = ((SAPbouiCOM.Folder)(this.GetItem("TABCOMM").Specific));
            this.TABSUMM = ((SAPbouiCOM.Folder)(this.GetItem("TABSUMM").Specific));
            this.TABVRSN = ((SAPbouiCOM.Folder)(this.GetItem("TABVRSN").Specific));
            this.TABTMFAB = ((SAPbouiCOM.Folder)(this.GetItem("TABTMFAB").Specific));
            this.TABTPTRM = ((SAPbouiCOM.Folder)(this.GetItem("TABTPTRM").Specific));
            
            //Matrix

            this.MTXFOB = ((SAPbouiCOM.Matrix)(this.GetItem("MTXFOB").Specific));
            this.MTXCOLOR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCOLOR").Specific));
            this.MTXTMFAB = ((SAPbouiCOM.Matrix)(this.GetItem("MTXTMFAB").Specific));
            this.MTXTRMS = ((SAPbouiCOM.Matrix)(this.GetItem("MTXTRMS").Specific));
            this.MTXOTCST = ((SAPbouiCOM.Matrix)(this.GetItem("MTXOTCST").Specific));
            this.MTXPRCST = ((SAPbouiCOM.Matrix)(this.GetItem("MTXPRCST").Specific));
            this.MTXCSTEL = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCSTEL").Specific));
            this.MTXSUMRY = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSUMRY").Specific));
            this.MTXCOMSN = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCOMSN").Specific));
            this.MTXTMTRM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXTMTRM").Specific));


            //Grid

            this.GRDFAB = ((SAPbouiCOM.Grid)(this.GetItem("GRDFAB").Specific));
            this.GRDVRSN = ((SAPbouiCOM.Grid)(this.GetItem("GRDVRSN").Specific));



            //Button

            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.BTNCANCEL = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNLDFAB = ((SAPbouiCOM.Button)(this.GetItem("BTNLDFAB").Specific));
            this.BTNLDCEL = ((SAPbouiCOM.Button)(this.GetItem("BTNLDCEL").Specific));
            this.BTNSAVE = ((SAPbouiCOM.Button)(this.GetItem("BTNSAVE").Specific));

            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new ResizeAfterHandler(this.Form_ResizeAfter);

        }



        private void OnCustomInitialize()
        {

        }



        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            

        }
    }
}
