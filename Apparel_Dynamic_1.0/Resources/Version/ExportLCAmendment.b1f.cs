using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Resources.Transaction;
using Apparel_Dynamic_1._0.Helper;
using Apparel_Dynamic_1._0.Resources.Master;
namespace Apparel_Dynamic_1._0.Resources.Version
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Version.ExportLCAmendment", "Resources/Version/ExportLCAmendment.b1f")]
    class ExportLCAmendment : UserFormBase
    {
        public ExportLCAmendment()
        {
        }

        private SAPbouiCOM.StaticText STSTATMR, STREMRKS, STSTATCM, STCOMPNY, STCUSTMR, 
                                      STSCNO, STLCNO, STLCDESC, STCURR, STBP1BNK, STBP2BNK, 
                                      STHUSBNK, STLCVAL, STDOCNUM, STDOCDAT, STISUDAT, STSHPDAT, STEXPDAT, STB2BPER, 
                                      STB2BAMT, STLCTRMS, STPYTRMS, STINTRMS, STAMDNO;

        

        private SAPbouiCOM.EditText ETCOMPNY, ETPYTRMS, ETINTRMS, ETLCTRMS, ETSERIES, ETSTATCM, ETSTATMR, 
                                    ETBP1BNM, ETREMRKS, ETBP2BNM, ETHUSBNM, ETCUSTNM, ETCUSTMR, ETSCNO, ETLCNO, 
                                    ETDOCTRY, ETDOCNUM, ETLCDESC, ETCURR, ETBP1BNK, ETBP2BNK, ETHUSBNK, ETLCVAL, 
                                    ETDOCDAT, ETISUDAT, ETSHPDAT, ETEXPDAT, ETB2BPER, ETB2BAMT, ETAMDNO;



        private SAPbouiCOM.Folder TABSODR, TABATTCH;

        private SAPbouiCOM.Matrix MTXSLODR, MTXATTCH;

        private SAPbouiCOM.Button  ADDButton, CancelButton;


        private SAPbouiCOM.LinkedButton LKCUSTMR;


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
            this.ETCUSTMR = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTMR").Specific));
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
            this.TABATTCH = ((SAPbouiCOM.Folder)(this.GetItem("TABATTCH").Specific));
            this.MTXSLODR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSLODR").Specific));
            this.MTXSLODR.LinkPressedAfter += new SAPbouiCOM._IMatrixEvents_LinkPressedAfterEventHandler(this.MTXSLODR_LinkPressedAfter);
            this.MTXATTCH = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTCH").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.LKCUSTMR = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCUSTMR").Specific));
            this.ETBP1BNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBP1BNM").Specific));
            this.ETBP2BNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBP2BNM").Specific));
            this.ETHUSBNM = ((SAPbouiCOM.EditText)(this.GetItem("ETHUSBNM").Specific));
            this.ETCUSTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTNM").Specific));
            this.STREMRKS = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRKS").Specific));
            this.ETREMRKS = ((SAPbouiCOM.EditText)(this.GetItem("ETREMRKS").Specific));
            this.ETCOMPNY = ((SAPbouiCOM.EditText)(this.GetItem("ETCOMPNY").Specific));
            this.ETSTATMR = ((SAPbouiCOM.EditText)(this.GetItem("ETSTATMR").Specific));
            this.ETSTATCM = ((SAPbouiCOM.EditText)(this.GetItem("ETSTATCM").Specific));
            this.ETSERIES = ((SAPbouiCOM.EditText)(this.GetItem("ETSERIES").Specific));
            this.ETLCTRMS = ((SAPbouiCOM.EditText)(this.GetItem("ETLCTRMS").Specific));
            this.ETPYTRMS = ((SAPbouiCOM.EditText)(this.GetItem("ETPYTRMS").Specific));
            this.ETINTRMS = ((SAPbouiCOM.EditText)(this.GetItem("ETINTRMS").Specific));
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSCNO").Specific));
            this.LinkedButton0.PressedAfter += new SAPbouiCOM._ILinkedButtonEvents_PressedAfterEventHandler(this.LinkedButton0_PressedAfter);
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
        }

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.LinkedButton LinkedButton0;
        private void LinkedButton0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.EditText ETSMPLCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSCNO").Specific;
            string sampleCode = ETSMPLCD.Value.Trim();
            SalesContract salescon = new SalesContract();
            salescon.Show();
            //styleMaster. = Global.G_UI_Application.Forms.ActiveForm;
            SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_SLCNTRCT");
            try
            {
                cForm.Freeze(true);
                cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                cForm.Items.Item("ETSCNO").Enabled = true;
                SAPbouiCOM.EditText cETSLCODE = (SAPbouiCOM.EditText)cForm.Items.Item("ETSCNO").Specific;
                cETSLCODE.Value = sampleCode;
                cForm.Items.Item("1").Click();
                cForm.Items.Item("FOLORDTL").Click();
                cForm.Freeze(false);
            }
            catch (Exception ex)
            {
                cForm.Freeze(false);
            }
        }
        private void MTXSLODR_LinkPressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID != "CLSTYLCD" || pVal.Row <= 0)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.EditText oETStyleNo = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTYLCD").Cells.Item(pVal.Row).Specific;
                string styleNo = oETStyleNo.Value.Trim();

                if (string.IsNullOrEmpty(styleNo))
                {
                    Global.GFunc.ShowError("Style No. is empty.");
                    return;
                }

                StyleMaster styleMaster = new StyleMaster();
                styleMaster.Show();

                SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_STYLMSTR");

                try
                {
                    cForm.Freeze(true);
                    cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                    cForm.Items.Item("ETSLCODE").Enabled = true;

                    SAPbouiCOM.EditText cETSLCODE = (SAPbouiCOM.EditText)cForm.Items.Item("ETSLCODE").Specific;
                    cETSLCODE.Value = styleNo;

                    cForm.Items.Item("1").Click();
                }
                finally
                {
                    cForm.Freeze(false);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError(ex.Message);
            }

        }
    }
}
