using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;
using Apparel_Dynamic_1._0.Resources.Version;
using Apparel_Dynamic_1._0.Resources.Master;

namespace Apparel_Dynamic_1._0.Resources.Transaction
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Transaction.ExportLC", "Resources/Transaction/ExportLC.b1f")]
    class ExportLC : UserFormBase
    {
        public ExportLC()
        {
        }

        private SAPbouiCOM.StaticText STSTATMR, STREMRKS, STSTATCM, STCOMPNY, STCUSTMR, STSCNO, STLCNO, STLCDESC, STCURR, STBP1BNK, STBP2BNK, STHUSBNK, STLCVAL, STDOCNUM, STDOCDAT, STISUDAT, STSHPDAT, STEXPDAT, STB2BPER, STB2BAMT, STLCTRMS, STPYTRMS, STINTRMS, STAMDNO;

        

        private SAPbouiCOM.ComboBox CBSTATMR, CBSTATCM, CBCOMPNY, CBSERIES, CBINTRMS, CBPYTRMS, CBLCTRMS;

       

        private SAPbouiCOM.EditText ETBP1BNM, ETREMRKS, ETBP2BNM, ETHUSBNM, ETCUSTNM,ETCUSTMR, ETSCNO, ETLCNO, ETDOCTRY, ETDOCNUM, ETLCDESC, ETCURR, ETBP1BNK, ETBP2BNK, ETHUSBNK, ETLCVAL, ETDOCDAT, ETISUDAT, ETSHPDAT, ETEXPDAT, ETB2BPER, ETB2BAMT, ETAMDNO;

        

        private SAPbouiCOM.Folder TABSODR, TABAMDTL, TABATTCH;

        private SAPbouiCOM.Matrix MTXSLODR, MTXATTCH;

        

        private SAPbouiCOM.Button BRWSBTN, DISPBTN, DELBTN, ADDButton, CancelButton, BTNLDATA, BTNAMND;



        private SAPbouiCOM.Grid GRDAMDTL;

        private SAPbouiCOM.LinkedButton LKSCNO, LKCUSTMR;

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
            this.CBSTATMR.LostFocusAfter += new SAPbouiCOM._IComboBoxEvents_LostFocusAfterEventHandler(this.CBSTATMR_LostFocusAfter);
            this.CBSTATMR.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBSTATMR_ComboSelectAfter);
            this.CBSTATCM = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSTATCM").Specific));
            this.CBSTATCM.LostFocusAfter += new SAPbouiCOM._IComboBoxEvents_LostFocusAfterEventHandler(this.CBSTATCM_LostFocusAfter);
            this.CBSTATCM.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBSTATCM_ComboSelectAfter);
            this.CBCOMPNY = ((SAPbouiCOM.ComboBox)(this.GetItem("CBCOMPNY").Specific));
            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            this.CBINTRMS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBINTRMS").Specific));
            this.CBPYTRMS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBPYTRMS").Specific));
            this.CBLCTRMS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBLCTRMS").Specific));
            this.ETCUSTMR = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTMR").Specific));
            this.ETCUSTMR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSTMR_ChooseFromListAfter);
            this.ETSCNO = ((SAPbouiCOM.EditText)(this.GetItem("ETSCNO").Specific));
            this.ETSCNO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSCNO_ChooseFromListAfter);
            this.ETSCNO.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETSCNO_ChooseFromListBefore);
            this.ETLCNO = ((SAPbouiCOM.EditText)(this.GetItem("ETLCNO").Specific));
            this.ETLCNO.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETLCNO_LostFocusAfter);
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETLCDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETLCDESC").Specific));
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETCURR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCURR_ChooseFromListAfter);
            this.ETBP1BNK = ((SAPbouiCOM.EditText)(this.GetItem("ETBP1BNK").Specific));
            this.ETBP1BNK.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBP1BNK_ChooseFromListAfter);
            this.ETBP2BNK = ((SAPbouiCOM.EditText)(this.GetItem("ETBP2BNK").Specific));
            this.ETBP2BNK.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBP2BNK_ChooseFromListAfter);
            this.ETBP2BNK.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBP2BNK_ChooseFromListBefore);
            this.ETHUSBNK = ((SAPbouiCOM.EditText)(this.GetItem("ETHUSBNK").Specific));
            this.ETLCVAL = ((SAPbouiCOM.EditText)(this.GetItem("ETLCVAL").Specific));
            this.ETDOCDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.ETISUDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETISUDAT").Specific));
            this.ETSHPDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETSHPDAT").Specific));
            this.ETEXPDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETEXPDAT").Specific));
            this.ETB2BPER = ((SAPbouiCOM.EditText)(this.GetItem("ETB2BPER").Specific));
            this.ETB2BPER.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETB2BPER_LostFocusAfter);
            this.ETB2BAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETB2BAMT").Specific));
            this.ETAMDNO = ((SAPbouiCOM.EditText)(this.GetItem("ETAMDNO").Specific));
            this.TABSODR = ((SAPbouiCOM.Folder)(this.GetItem("TABSODR").Specific));
            this.TABAMDTL = ((SAPbouiCOM.Folder)(this.GetItem("TABAMDTL").Specific));
            this.TABATTCH = ((SAPbouiCOM.Folder)(this.GetItem("TABATTCH").Specific));
            this.MTXSLODR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSLODR").Specific));
            this.MTXSLODR.ValidateAfter += new SAPbouiCOM._IMatrixEvents_ValidateAfterEventHandler(this.MTXSLODR_ValidateAfter);
            this.MTXSLODR.LinkPressedAfter += new SAPbouiCOM._IMatrixEvents_LinkPressedAfterEventHandler(this.MTXSLODR_LinkPressedAfter);
            this.MTXSLODR.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXSLODR_ChooseFromListAfter);
            this.MTXSLODR.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXSLODR_ChooseFromListBefore);
            this.MTXATTCH = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTCH").Specific));
            this.BRWSBTN = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.BRWSBTN.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BRWSBTN_PressedAfter);
            this.DISPBTN = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.DISPBTN.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.DISPBTN_PressedAfter);
            this.DELBTN = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.DELBTN.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.DELBTN_PressedAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNLDATA = ((SAPbouiCOM.Button)(this.GetItem("BTNLDATA").Specific));
            this.BTNLDATA.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNLDATA_PressedAfter);
            this.BTNAMND = ((SAPbouiCOM.Button)(this.GetItem("BTNAMND").Specific));
            this.BTNAMND.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTNAMND_PressedBefore);
            this.BTNAMND.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNAMND_PressedAfter);
            this.GRDAMDTL = ((SAPbouiCOM.Grid)(this.GetItem("GRDAMDTL").Specific));
            this.GRDAMDTL.DoubleClickAfter += new SAPbouiCOM._IGridEvents_DoubleClickAfterEventHandler(this.GRDAMDTL_DoubleClickAfter);
            this.LKSCNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSCNO").Specific));
            this.LKSCNO.PressedAfter += new SAPbouiCOM._ILinkedButtonEvents_PressedAfterEventHandler(this.LKSCNO_PressedAfter);
            this.LKCUSTMR = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCUSTMR").Specific));
            this.ETBP1BNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBP1BNM").Specific));
            this.ETBP2BNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBP2BNM").Specific));
            this.ETHUSBNM = ((SAPbouiCOM.EditText)(this.GetItem("ETHUSBNM").Specific));
            this.ETHUSBNM.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETHUSBNM_ChooseFromListAfter);
            this.ETCUSTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTNM").Specific));
            this.STREMRKS = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRKS").Specific));
            this.ETREMRKS = ((SAPbouiCOM.EditText)(this.GetItem("ETREMRKS").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.RightClickBefore += new SAPbouiCOM.Framework.FormBase.RightClickBeforeHandler(this.Form_RightClickBefore);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.DataUpdateAfter += new DataUpdateAfterHandler(this.Form_DataUpdateAfter);

        }

        private void OnCustomInitialize()
        {

        }

        private void MTXSLODR_ValidateAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID != "CLSLORDR" || pVal.Row <= 0)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;

                string soNo = ((SAPbouiCOM.EditText)mtx.Columns.Item("CLSLORDR").Cells.Item(pVal.Row).Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(soNo))
                    CleanSalesOrderMatrix(oForm);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sales Order clear error: " + ex.Message);
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


        private void LKSCNO_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
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

        //private void BTNLDATA_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    SAPbouiCOM.Form oForm = null;

        //    try
        //    {
        //        oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        oForm.Freeze(true);

        //        SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
        //        SAPbouiCOM.DBDataSource dbDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");

        //        mtx.FlushToDataSource();

        //        List<SalesOrderMismatch> mismatches = GetSalesOrderMismatches(oForm);

        //        if (mismatches.Count == 0)
        //        {
        //            Global.GFunc.ShowSuccess("Sales Order Quantity and Total Value are already up to date.");
        //            return;
        //        }

        //        foreach (SalesOrderMismatch item in mismatches)
        //        {
        //            dbDetail.SetValue("U_QUANTITY", item.Row, item.CurrentQty.ToString());
        //            dbDetail.SetValue("U_VALUE", item.Row, item.CurrentValue.ToString());
        //        }

        //        mtx.LoadFromDataSource();

        //        CalculateLCValue(oForm, mtx);

        //        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
        //            oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

        //        StringBuilder message = new StringBuilder();
        //        message.AppendLine("Latest Sales Order data loaded successfully.");
        //        message.AppendLine("");

        //        foreach (SalesOrderMismatch item in mismatches)
        //            message.AppendLine("Sales Order: " + item.SONo);

        //        Application.SBO_Application.MessageBox(message.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError("Load Sales Order data error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (oForm != null)
        //            oForm.Freeze(false);
        //    }
        //}

        private void BTNLDATA_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);

                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.DBDataSource dbDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");

                mtx.FlushToDataSource();

                List<SalesOrderMismatch> mismatches = GetSalesOrderMismatches(oForm);

                if (mismatches.Count == 0)
                {
                    Global.GFunc.ShowSuccess("Sales Order data is already up to date.");
                    return;
                }

                foreach (SalesOrderMismatch item in mismatches)
                {
                    dbDetail.SetValue("U_CUSTREFNO", item.Row, item.CurrentCustRefNo);
                    dbDetail.SetValue("U_QUANTITY", item.Row, item.CurrentQty.ToString());
                    dbDetail.SetValue("U_VALUE", item.Row, item.CurrentValue.ToString());
                }

                mtx.LoadFromDataSource();

                CalculateLCValue(oForm, mtx);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                StringBuilder message = new StringBuilder();
                message.AppendLine("Latest Sales Order data loaded successfully.");
                message.AppendLine("");

                foreach (SalesOrderMismatch item in mismatches)
                    message.AppendLine("Sales Order: " + item.SONo);

                Application.SBO_Application.MessageBox(message.ToString());
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Load Sales Order data error: " + ex.Message);
            }
            finally
            {
                if (oForm != null)
                    oForm.Freeze(false);
            }
        }

        private void GRDAMDTL_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            try
            {
                if (pVal.Row < 0)
                    return;

                int result = Application.SBO_Application.MessageBox("Are you sure you want to see the Amendment Details?", 1, "OK", "Cancel");

                if (result != 1)
                    return;

                SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("GRDAMDTL").Specific;
                SAPbouiCOM.DataTable oDT = oGrid.DataTable;

                string docEntry = oDT.GetValue("DocEntry", pVal.Row).ToString().Trim();
                string docNum = oDT.GetValue("DocNum", pVal.Row).ToString().Trim();
                string amendNo = oDT.GetValue("Amendment No", pVal.Row).ToString().Trim();
                string logInst = oDT.GetValue("LogInst", pVal.Row).ToString().Trim();

                OpenLCAmendmentInNewForm(docEntry, docNum, amendNo, logInst);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Amendment Details Error: " + ex.Message);
            }
        }

        private void BTNAMND_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                
                int result = Application.SBO_Application.MessageBox("Are you sure you want to create a new amendment?", 1, "OK", "Cancel");

                if (result != 1)
                {
                    BubbleEvent = false;
                    return;
                }
                SAPbouiCOM.ComboBox cbStatMR = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;
                SAPbouiCOM.ComboBox cbStatCM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

                string mrStatus = cbStatMR.Selected == null ? "" : cbStatMR.Selected.Value.Trim();
                string cmStatus = cbStatCM.Selected == null ? "" : cbStatCM.Selected.Value.Trim();

                if (mrStatus != "C" || cmStatus != "C")
                {
                    Global.GFunc.ShowError("MR Status and CM Status must be Confirmed before amendment.");
                    BubbleEvent = false;
                    return;
                }

                SAPbouiCOM.EditText ETAMDNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific;

                int currentAmendNo = 0;
                if (!int.TryParse(ETAMDNO.Value.Trim(), out currentAmendNo))
                    currentAmendNo = 0;

                int newAmendNo = currentAmendNo + 1;
                ETAMDNO.Value = newAmendNo.ToString();

                SAPbouiCOM.Matrix MTXSLODR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;

                for (int i = 1; i <= MTXSLODR.VisualRowCount; i++)
                {
                    string soNo = ((SAPbouiCOM.EditText)MTXSLODR.Columns.Item("CLSLORDR").Cells.Item(i).Specific).Value.Trim();

                    if (string.IsNullOrEmpty(soNo))
                        continue;

                    ((SAPbouiCOM.EditText)MTXSLODR.Columns.Item("CLAMDNO").Cells.Item(i).Specific).Value = newAmendNo.ToString();
                }

                MTXSLODR.FlushToDataSource();

                SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                for (int i = 1; i <= MTXATTCH.VisualRowCount; i++)
                {
                    string attachment = ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTACH").Cells.Item(i).Specific).Value.Trim();

                    if (string.IsNullOrEmpty(attachment))
                        continue;

                    ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLAMDNO").Cells.Item(i).Specific).Value = newAmendNo.ToString();
                }

                MTXATTCH.FlushToDataSource();

                
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Amendment Error: " + ex.Message);
                BubbleEvent = false;
            }
        }

        //private void BTNAMND_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    try
        //    {
        //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        SAPbouiCOM.ComboBox cbStatMR = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;
        //        SAPbouiCOM.ComboBox cbStatCM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

        //        oForm.Items.Item("CBSTATMR").Enabled = true;
        //        oForm.Items.Item("CBSTATCM").Enabled = true;

        //        cbStatCM.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
        //        cbStatMR.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);

        //        oForm.Items.Item("CBSTATMR").Enabled = true;
        //        oForm.Items.Item("CBSTATCM").Enabled = false;

        //        SetLCNoStatus(oForm);

        //        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
        //            oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError("Amendment status reset error: " + ex.Message);
        //    }
        //}

        private void BTNAMND_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ComboBox cbStatMR = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;
                SAPbouiCOM.ComboBox cbStatCM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

                oForm.Items.Item("CBSTATMR").Enabled = true;
                oForm.Items.Item("CBSTATCM").Enabled = true;

                cbStatMR.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
                cbStatCM.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                ApplyExportLCStatusState(oForm);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Amendment status reset error: " + ex.Message);
            }
        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            // Series Initialization
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM");
                Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                string today = DateTime.Now.ToString("yyyyMMdd");
                SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM");
                oDBH.SetValue("U_DOCDATE", 0, today);
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                Global.GFunc.UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_OLCM");

                //Amendment No
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific).Value = "0";

                // Branch combo
                Global.GFunc.LoadUserBranches(oForm, "CBCOMPNY");
                SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBCOMPNY").Specific;
                oCombo.Select(oCombo.ValidValues.Item(0).Value, SAPbouiCOM.BoSearchKey.psk_ByValue);

                //Load Payment Terms
                string payTerms = @"SELECT ""GroupNum"", ""PymntGroup"" FROM ""OCTG""";
                SAPbouiCOM.ComboBox CBPYTRMS = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPYTRMS").Specific;
                Global.GFunc.setComboBoxValue(CBPYTRMS, payTerms);

                //Load FOB
                string fob = @"SELECT ""Code"", ""Name"" FROM ""@FIL_MH_INCOTRMS"" WHERE ""U_ACTIVE"" = 'Y'";
                SAPbouiCOM.ComboBox CBINTRMS = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBINTRMS").Specific;
                Global.GFunc.setComboBoxValue(CBINTRMS, fob);

                //Currencey Load
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific).Value = "USD";
            }
            Global.GFunc.SetItemsEnabled(oForm, false, "CBSTATCM", "ETCUSTNM",
                                                           "ETLCVAL", "ETBP1BNM", "ETBP2BNM", "ETHUSBNK", "ETDOCNUM", "ETB2BAMT");
            Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETHUSBNM", "ETCUSTMR");

        }

        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                ValidateForm(ref oForm, ref BubbleEvent);
            }

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM", "CBSERIES", "CBCOMPNY", "ETCUSTNM", "ETCUSTMR",
                                         "ETLCVAL", "ETB2BAMT", "ETBP1BNM", "ETBP2BNM", "ETHUSBNK");
           
            Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXSLODR", "@FIL_DR_LCM1", "U_SONO");

            //SetStatusFields(oForm);
            //SetLCNoStatus(oForm);

            ApplyExportLCStatusState(oForm);
            CheckAndLoadAmendmentGrid(oForm);
        }

        private void Form_DataUpdateAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            CheckAndLoadAmendmentGrid(oForm);
            //SetLCNoStatus(oForm);
            ApplyExportLCStatusState(oForm);
            Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXSLODR", "@FIL_DR_LCM1", "U_SONO");
        }

        private void Form_RightClickBefore(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(eventInfo.FormUID);
                if (eventInfo.ItemUID != "MTXSLODR" || eventInfo.Row <= 0)
                    return;
                oForm.EnableMenu("1293", true);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Form_RightClickBefore Error: {ex.Message}");
                BubbleEvent = false;
            }
        }


        //private void CBSTATCM_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    try
        //    {
        //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

        //        string selectedValue = oCmb.Selected == null ? "" : oCmb.Selected.Value.Trim();

        //        if (selectedValue == "C")
        //        {
        //            oForm.Items.Item("CBSTATCM").Enabled = false;
        //        }

        //        SetLCNoStatus(oForm);
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError("Error in CM LostFocus Error: " + ex.Message);
        //    }
        //}

        private void CBSTATCM_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                ApplyExportLCStatusState(oForm);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error in CM LostFocus: " + ex.Message);
            }
        }

        private void CBSTATCM_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

                string selectedValue = oCmb.Selected == null ? "" : oCmb.Selected.Value.Trim();

                if (selectedValue == "C")
                {
                    string lcNo = ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCNO").Specific).Value.Trim();

                    if (string.IsNullOrWhiteSpace(lcNo))
                    {
                        Global.GFunc.ShowError("Enter LC No before confirming Commercial Status.");
                        oCmb.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
                        return;
                    }

                    int result = Application.SBO_Application.MessageBox("Are you sure want to confirm Commercial Status?", 1, "Yes", "No");

                    if (result != 1)
                        oCmb.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error in CM Status selection: " + ex.Message);
            }
        }

        //private void CBSTATCM_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    try
        //    {
        //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

        //        string selectedValue = "";
        //        if (oCmb.Selected != null)
        //            selectedValue = oCmb.Selected.Value.Trim();

        //        if (selectedValue == "C")
        //        {
        //            string lcNo = ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCNO").Specific).Value.Trim();

        //            if (string.IsNullOrWhiteSpace(lcNo))
        //            {
        //                Global.GFunc.ShowError("Enter LC No before confirming CM Status.");
        //                oCmb.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
        //                return;
        //            }

        //            int result = Application.SBO_Application.MessageBox(
        //                "Are you sure want to confirm?",
        //                1,
        //                "Yes",
        //                "No"
        //            );

        //            if (result != 1)
        //            {
        //                oCmb.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError("Error in CM Status selection: " + ex.Message);
        //    }
        //}
        //private void CBSTATMR_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    try
        //    {
        //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;

        //        string selectedValue = "";
        //        if (oCmb.Selected != null)
        //            selectedValue = oCmb.Selected.Value.Trim();

        //        if (selectedValue == "C")
        //        {
        //            int result = Application.SBO_Application.MessageBox(
        //                "Are you sure want to change?",
        //                1,
        //                "Yes",
        //                "No"
        //            );

        //            if (result == 1)
        //            {
        //                oForm.Items.Item("CBSTATCM").Enabled = true;
        //            }
        //            else
        //            {
        //                oCmb.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
        //                oForm.Items.Item("CBSTATCM").Enabled = false;
        //            }
        //        }
        //        else
        //        {
        //            oForm.Items.Item("CBSTATCM").Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError("Error in MR Status selection: " + ex.Message);
        //    }
        //}

        private void CBSTATMR_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;

                string selectedValue = oCmb.Selected == null ? "" : oCmb.Selected.Value.Trim();

                if (selectedValue == "C")
                {
                    int result = Application.SBO_Application.MessageBox("Are you sure want to confirm Marketing Status?", 1, "Yes", "No");

                    if (result != 1)
                        oCmb.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error in MR Status selection: " + ex.Message);
            }
        }

        private void CBSTATMR_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                ApplyExportLCStatusState(oForm);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error in MR LostFocus: " + ex.Message);
            }
        }

        //private void CBSTATMR_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    try
        //    {
        //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;

        //        string selectedValue = oCmb.Selected == null ? "" : oCmb.Selected.Value.Trim();

        //        if (selectedValue == "C")
        //        {
        //            oForm.Items.Item("CBSTATMR").Enabled = false;
        //            oForm.Items.Item("CBSTATCM").Enabled = true;
        //        }

        //        SetLCNoStatus(oForm);
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError("Error in MR LostFocus Error: " + ex.Message);
        //    }
        //}

        private void ETB2BPER_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                CalculateB2BAmount(oForm);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("B2B Percentage calculation error: " + ex.Message);
            }
        }

        private void ETLCNO_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                {
                    string code = ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCNO").Specific).Value.Trim();
                    string UCode = Global.GFunc.ToUpperCase(code);

                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCNO").Specific).Value = UCode;
                    if (!string.IsNullOrEmpty(UCode))
                    {
                        SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string query = $@"SELECT 1 FROM ""@FIL_DH_OLCM"" WHERE ""U_LCNO"" = '{UCode.Replace("'", "''")}'";
                        oRS.DoQuery(query);
                        if (!oRS.EoF)
                        {
                            Global.GFunc.ShowError("Code already exists!");
                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCNO").Specific).Value = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error: Sales Contract Code  " + ex.Message);
            }

        }


        private void DELBTN_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);

                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM2");
                SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                MTXATTCH.FlushToDataSource();

                for (int i = 1; i <= MTXATTCH.RowCount; i++)
                {
                    if (!MTXATTCH.IsRowSelected(i))
                        continue;

                    int rowIndex = i - 1;

                    if (rowIndex < 0 || rowIndex >= DBDataSourceLine.Size)
                    {
                        Application.SBO_Application.MessageBox("Invalid row index.");
                        return;
                    }

                    string filePath = ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTACH").Cells.Item(i).Specific).Value.Trim();

                    int result = Application.SBO_Application.MessageBox(
                        "Are you sure you want to delete this attachment?",
                        1,
                        "Yes",
                        "No"
                    );

                    if (result != 1)
                        return;

                    string rootPath = @"\\192.168.162.227\Attachment";
                    string username = @"192.168.162.227\Administrator";
                    string password = "Fu1@#sion";

                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        NetworkShareHelper.DeleteFile(
                            filePath,
                            rootPath,
                            username,
                            password
                        );
                    }

                    DBDataSourceLine.RemoveRecord(rowIndex);

                    for (int j = 0; j < DBDataSourceLine.Size; j++)
                    {
                        DBDataSourceLine.Offset = j;
                        DBDataSourceLine.SetValue("LineId", j, (j + 1).ToString());
                    }

                    MTXATTCH.LoadFromDataSource();

                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                        oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                    Global.GFunc.ShowSuccess("Attachment deleted successfully.");

                    break;
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Attachment Delete Error: " + ex.Message);
            }
            finally
            {
                if (oForm != null)
                    oForm.Freeze(false);
            }

        }

        private void DISPBTN_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            try
            {
                SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                for (int i = 1; i <= MTXATTCH.RowCount; i++)
                {
                    if (!MTXATTCH.IsRowSelected(i))
                        continue;

                    string filePath = ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTACH").Cells.Item(i).Specific).Value.Trim();

                    if (string.IsNullOrWhiteSpace(filePath))
                    {
                        Global.GFunc.ShowError("Attachment path is empty.");
                        return;
                    }

                    string rootPath = @"\\192.168.162.227\Attachment";
                    string username = @"192.168.162.227\Administrator";
                    string password = "Fu1@#sion";

                    NetworkShareHelper.OpenFile(filePath, rootPath, username, password);

                    return;
                }

                Global.GFunc.ShowWarning("Select an attachment row first.");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Unable to open attachment: " + ex.Message);
            }

        }

        private void BRWSBTN_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            try
            {
                string lcCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCNO").Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(lcCode))
                {
                    Global.GFunc.ShowError("Enter LC No first.");
                    return;
                }

                string sourceFile = FileDialogHelper.ShowFileDialog();

                if (string.IsNullOrWhiteSpace(sourceFile))
                    return;

                oForm.Freeze(true);

                SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM2");
                SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                int lastRow = MTXATTCH.VisualRowCount;

                bool needNewRow = lastRow == 0 ||
                                  !string.IsNullOrWhiteSpace(((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTACH").Cells.Item(lastRow).Specific).Value);

                if (needNewRow)
                {
                    Global.GFunc.SetNewLine(MTXATTCH, DBDataSourceLine, 1, "");
                    lastRow = MTXATTCH.VisualRowCount;
                }

                string rootPath = @"\\192.168.162.227\Attachment";
                string username = @"192.168.162.227\Administrator";
                string password = "Fu1@#sion";

                string formTitle = oForm.Title;
                string documentCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCNO").Specific).Value.Trim();
                string serverFile = NetworkShareHelper.CopyFile(sourceFile, rootPath, username, password, formTitle, documentCode, lastRow);
                string amendmentNo = ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific).Value.Trim();

                ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTACH").Cells.Item(lastRow).Specific).Value = serverFile;
                ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLAMDNO").Cells.Item(lastRow).Specific).Value = amendmentNo;
                MTXATTCH.FlushToDataSource();

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                Global.GFunc.ShowSuccess("Attachment copied successfully.");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Attachment Error: " + ex.Message);
            }
            finally
            {
                if (oForm != null)
                    oForm.Freeze(false);
            }

        }

        private void MTXSLODR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID != "CLSLORDR")
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;

                int docEntry = Convert.ToInt32(dt.GetValue("DocEntry", 0));
                string scNo = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSCNO").Specific).Value.Trim();
                string safeSCNo = scNo.Replace("'", "''");

                SAPbouiCOM.Matrix MTXSLODR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.DBDataSource oDBDSDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");

                string qStr = @"
                                SELECT
                                    A.""DocNum"",
                                    A.""DocEntry"",
                                    A.""NumAtCard"",
                                    A.""U_STYLECODE"",
                                    A.""U_STYLENM"",
                                    A.""U_STYLENTRY"",
                                    SUM(B.""Quantity"") AS ""Quantity"",
                                    CASE
                                        WHEN A.""DocCur"" = 'BDT' THEN A.""DocTotal""
                                        ELSE A.""DocTotalFC""
                                    END AS ""TotalValue""
                                FROM ORDR A
                                INNER JOIN RDR1 B ON A.""DocEntry"" = B.""DocEntry""
                                WHERE A.""DocEntry"" = " + docEntry + @" AND A.""U_SCNO"" = '" + safeSCNo + @"'
                                GROUP BY
                                    A.""DocNum"",
                                    A.""DocEntry"",
                                    A.""NumAtCard"",
                                    A.""U_STYLECODE"",
                                    A.""U_STYLENM"",
                                    A.""U_STYLENTRY"",
                                    A.""DocCur"",
                                    A.""DocTotal"",
                                    A.""DocTotalFC""";

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(qStr);

                if (rs.EoF)
                {
                    Global.GFunc.ShowError("Selected Sales Order data not found.");
                    return;
                }

                MTXSLODR.FlushToDataSource();

                int rowIndex = pVal.Row - 1;
                string amendmentNo = ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific).Value.Trim();

                if (oDBDSDetail.Size <= rowIndex)
                    oDBDSDetail.InsertRecord(oDBDSDetail.Size);

                oDBDSDetail.SetValue("LineId", rowIndex, pVal.Row.ToString());
                oDBDSDetail.SetValue("U_SONO", rowIndex, Convert.ToString(rs.Fields.Item("DocNum").Value));
                oDBDSDetail.SetValue("U_SOENTRY", rowIndex, Convert.ToString(rs.Fields.Item("DocEntry").Value));
                oDBDSDetail.SetValue("U_CUSTREFNO", rowIndex, Convert.ToString(rs.Fields.Item("NumAtCard").Value));
                oDBDSDetail.SetValue("U_STYLECODE", rowIndex, Convert.ToString(rs.Fields.Item("U_STYLECODE").Value));
                oDBDSDetail.SetValue("U_STYLENM", rowIndex, Convert.ToString(rs.Fields.Item("U_STYLENM").Value));
                oDBDSDetail.SetValue("U_STYLENTRY", rowIndex, Convert.ToString(rs.Fields.Item("U_STYLENTRY").Value));
                oDBDSDetail.SetValue("U_QUANTITY", rowIndex, Convert.ToString(rs.Fields.Item("Quantity").Value));
                oDBDSDetail.SetValue("U_VALUE", rowIndex, Convert.ToString(rs.Fields.Item("TotalValue").Value));
                oDBDSDetail.SetValue("U_AMNDMNT", rowIndex, amendmentNo);

                oDBDSDetail.Offset = rowIndex;
                MTXSLODR.SetLineData(pVal.Row);

                CalculateLCValue(oForm, MTXSLODR);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                if (pVal.Row == MTXSLODR.VisualRowCount)
                    Global.GFunc.SetNewLine(MTXSLODR, oDBDSDetail);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Sales Order load error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

       
     

        private void MTXSLODR_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.ColUID != "CLSLORDR")
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                string scNo = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSCNO").Specific).Value.Trim();

                if (string.IsNullOrEmpty(scNo))
                {
                    Global.GFunc.ShowError("Please select Sales Contract first.");
                    BubbleEvent = false;
                    return;
                }

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;

                List<string> usedSOEntries = new List<string>();

                for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                {
                    string soEntry = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSONTRY").Cells.Item(i).Specific).Value.Trim();

                    if (!string.IsNullOrWhiteSpace(soEntry) && !usedSOEntries.Contains(soEntry))
                        usedSOEntries.Add(soEntry);
                }

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflArg.ChooseFromListUID);

                SAPbouiCOM.Conditions oConditions = (SAPbouiCOM.Conditions)Application.SBO_Application.CreateObject(
                    SAPbouiCOM.BoCreatableObjectType.cot_Conditions);

                SAPbouiCOM.Condition oCondition = oConditions.Add();
                oCondition.Alias = "U_SCNO";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = scNo;

                foreach (string soEntry in usedSOEntries)
                {
                    oCondition.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    oCondition = oConditions.Add();
                    oCondition.Alias = "DocEntry";
                    oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_NOT_EQUAL;
                    oCondition.CondVal = soEntry;
                }

                oCFL.SetConditions(oConditions);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sales Order CFL Error: " + ex.Message);
                BubbleEvent = false;
            }
        }


        private void ETHUSBNM_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("BankCode", 0).ToString().Trim();
            string Name = dt.GetValue("Account", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETHUSBNK").Specific;
            ETCD.Value = Code;

            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETHUSBNM").Specific;
            ETNM.Value = Name;

        }

        private void ETBP2BNK_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("BankCode", 0).ToString().Trim();
            string Name = dt.GetValue("BankName", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETBP2BNK").Specific;
            ETCD.Value = Code;

            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETBP2BNM").Specific;
            ETNM.Value = Name;

        }

        private void ETBP2BNK_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                string selectedBank = ((SAPbouiCOM.EditText)oForm.Items.Item("ETBP1BNK").Specific).Value.Trim();

                if (string.IsNullOrEmpty(selectedBank))
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Please select Bank 1 first.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error
                    );
                    BubbleEvent = false;
                    return;
                }

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_DSC2")
                {
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon = oCons.Add();

                    oCon.Alias = "BankCode";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_NOT_EQUAL;
                    oCon.CondVal = selectedBank;

                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering Bank CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }
        }

        private void ETBP1BNK_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("BankCode", 0).ToString().Trim();
            string Name = dt.GetValue("BankName", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETBP1BNK").Specific;
            ETCD.Value = Code;

            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETBP1BNM").Specific;
            ETNM.Value = Name;

        }


        private void ETCURR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("CurrCode", 0).ToString().Trim();
            SAPbouiCOM.EditText ETBCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific;
            ETBCD.Value = Code;

        }
        private void ETSCNO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                    return;

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;

                string SCNo = dt.GetValue("U_SCNO", 0).ToString().Trim();

                SAPbouiCOM.EditText ETSCNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETSCNO").Specific;
                ETSCNO.Value = SCNo;

                SAPbouiCOM.Matrix MTXSLODR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.DBDataSource oDBDSDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");

                if (MTXSLODR.RowCount == 0)
                {
                    Global.GFunc.SetNewLine(MTXSLODR, oDBDSDetail, 1, "");
                }
                //Global.GFunc.SetNewLine(MTXSLODR, oDBDSDetail,1,"");
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void ETSCNO_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                string customerCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCUSTMR").Specific).Value.Trim();

                if (string.IsNullOrEmpty(customerCode))
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Please select Customer first.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error
                    );
                    BubbleEvent = false;
                    return;
                }

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_OSCM")
                {
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon = oCons.Add();
                    oCon.Alias = "U_CARDCODE";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = customerCode;
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering Customer CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }
        }

        private void ETCUSTMR_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("CardCode", 0).ToString().Trim();
            string Name = dt.GetValue("CardName", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSTMR").Specific;
            ETCD.Value = Code;

            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSTNM").Specific;
            ETNM.Value = Name;

        }
        //_____________________________________________________________________________________________________ User Define Function_____________________________

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                if (!ValidateConfirmedAmendmentBeforeUpdate(oForm))
                    return BubbleEvent = false;

                SAPbouiCOM.DBDataSource oHeader = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM");

                string branch = oHeader.GetValue("U_BRANCH", 0).Trim();
                string customer = oHeader.GetValue("U_CARDCODE", 0).Trim();
                string scNo = oHeader.GetValue("U_SCNO", 0).Trim();
                string lcNo = oHeader.GetValue("U_LCNO", 0).Trim();

                if (branch == "")
                {
                    Global.GFunc.ShowError("Select Branch");
                    oForm.ActiveItem = "CBCOMPNY";
                    return BubbleEvent = false;
                }

                bool bothConfirmed = IsBothStatusConfirmed(oForm);

                if (customer == "")
                {
                    Global.GFunc.ShowError("Enter Customer Code");
                    oForm.ActiveItem = "ETCUSTMR";
                    return BubbleEvent = false;
                }
                else if (scNo == "")
                {
                    Global.GFunc.ShowError("Enter Sales Contract No");
                    oForm.ActiveItem = "ETSCNO";
                    return BubbleEvent = false;
                }
                else if (bothConfirmed && string.IsNullOrWhiteSpace(lcNo))
                {
                    Global.GFunc.ShowError("Enter LC No");
                    return BubbleEvent = false;
                }

                if (!string.IsNullOrWhiteSpace(lcNo) && IsDuplicateLCNo(oForm, lcNo))
                {
                    Global.GFunc.ShowError("LC No already exists.");

                    if (oForm.Items.Item("ETLCNO").Enabled)
                        oForm.ActiveItem = "ETLCNO";

                    return BubbleEvent = false;
                }

                if (!ValidateDuplicateSalesOrderInMatrix(oForm))
                    return BubbleEvent = false;

                if (!ValidateSalesOrderSalesContract(oForm))
                    return BubbleEvent = false;

                if (!ValidateSalesOrderAlreadyUsed(oForm))
                    return BubbleEvent = false;

                if (!ValidateSalesOrderCurrentValues(oForm))
                    return BubbleEvent = false;

                Global.GFunc.PreventEmptyLastRow(oForm, "@FIL_DR_LCM1", MTXSLODR, "U_SONO");
                Global.GFunc.PreventEmptyLastRow(oForm, "@FIL_DR_LCM2", MTXATTCH, "U_ATCHMENT");
            }

            return BubbleEvent;
        }

        private void CheckAndLoadAmendmentGrid(SAPbouiCOM.Form oForm)
        {
            try
            {
                string amendNoStr = ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific).Value.Trim();

                int amendNo = 0;
                int.TryParse(amendNoStr, out amendNo);

                if (amendNo > 0)
                {
                    LoadAmendmentGrid(oForm);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Amendment check error: " + ex.Message);
            }
        }

        private void OpenLCAmendmentInNewForm(string docEntry, string docNum, string amendNo, string logInst)
        {
            SAPbouiCOM.Form newForm = null;

            try
            {
                ExportLCAmendment frm = new ExportLCAmendment();
                frm.Show();

                newForm = (SAPbouiCOM.Form)frm.UIAPIRawForm;

                if (newForm == null)
                    throw new Exception("Export LC Amendment form could not be opened.");

                newForm.Freeze(true);

                newForm.Title = "Export LC No: "+docNum +"- Amendment " + amendNo;
                newForm.PaneLevel = 1;

                LoadLCAmendmentHeader(newForm, docEntry, docNum, amendNo, logInst);
                LoadLCAmendmentSalesOrderMatrix(newForm, docEntry, amendNo, logInst);
                LoadLCAmendmentAttachmentMatrix(newForm, docEntry, amendNo, logInst);

                newForm.Mode = SAPbouiCOM.BoFormMode.fm_VIEW_MODE;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Open Export LC Amendment Error: " + ex.Message);
            }
            finally
            {
                if (newForm != null)
                    newForm.Freeze(false);
            }
        }
        //private void LoadLCAmendmentHeader(SAPbouiCOM.Form oForm, string docEntry, string docNum, string amendNo, string logInst)
        //{
        //    string sql = $@"
        //                    SELECT
        //                        T0.""DocEntry"",
        //                        T0.""DocNum"",
        //                        T0.""Series"",
        //                        T0.""U_BRANCH"",
        //                        T0.""U_MLCSTATUS"",
        //                        T0.""U_CLCSTATUS"",
        //                        T0.""U_CARDCODE"",
        //                        T0.""U_CARDNAME"",
        //                        T0.""U_SCNO"",
        //                        T0.""U_LCNO"",
        //                        T0.""U_LCDESC"",
        //                        T0.""U_CURRENCY"",
        //                        T0.""U_BNK1CODE"",
        //                        T0.""U_BNK1NAME"",
        //                        T0.""U_BNK2CODE"",
        //                        T0.""U_BNK2NAME"",
        //                        T0.""U_HBNKCODE"",
        //                        T0.""U_HBNKNAME"",
        //                        T0.""U_LCVALUE"",
        //                        T0.""U_DOCDATE"",
        //                        T0.""U_ISSUEDATE"",
        //                        T0.""U_SHIPDATE"",
        //                        T0.""U_EXPDATE"",
        //                        T0.""U_BTOBLCPER"",
        //                        T0.""U_BTOBLCVALUE"",
        //                        T0.""U_LCTERMS"",
        //                        T0.""U_PAYTERMS"",
        //                        T0.""U_INCOTRMS"",
        //                        T0.""U_AMNDMNT"",
        //                        T0.""U_Remarks""
        //                    FROM ""@AFIL_DH_OLCM"" T0
        //                    WHERE T0.""DocEntry"" = '{docEntry}'
        //                    AND T0.""DocNum"" = '{docNum}'
        //                    AND T0.""U_AMNDMNT"" = '{amendNo}'
        //                    AND T0.""LogInst"" = '{logInst}'";

        //    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        //    rs.DoQuery(sql);

        //    if (rs.EoF)
        //    {
        //        Global.GFunc.ShowError("Export LC amendment header data not found.");
        //        return;
        //    }

        //    string mrStatus = Convert.ToString(rs.Fields.Item("U_MLCSTATUS").Value).Trim();
        //    string cmStatus = Convert.ToString(rs.Fields.Item("U_CLCSTATUS").Value).Trim();

        //    SetEdit(oForm, "ETDOCTRY", rs.Fields.Item("DocEntry").Value);
        //    SetEdit(oForm, "ETDOCNUM", rs.Fields.Item("DocNum").Value);
        //    SetEdit(oForm, "ETSERIES", rs.Fields.Item("Series").Value);
        //    SetEdit(oForm, "ETCOMPNY", rs.Fields.Item("U_BRANCH").Value);

        //    SetEdit(oForm, "ETSTATMR", mrStatus == "C" ? "Confirmed" : mrStatus == "D" ? "Draft" : mrStatus);
        //    SetEdit(oForm, "ETSTATCM", cmStatus == "C" ? "Confirmed" : cmStatus == "D" ? "Draft" : cmStatus);

        //    SetEdit(oForm, "ETCUSTMR", rs.Fields.Item("U_CARDCODE").Value);
        //    SetEdit(oForm, "ETCUSTNM", rs.Fields.Item("U_CARDNAME").Value);
        //    SetEdit(oForm, "ETSCNO", rs.Fields.Item("U_SCNO").Value);
        //    SetEdit(oForm, "ETLCNO", rs.Fields.Item("U_LCNO").Value);
        //    SetEdit(oForm, "ETLCDESC", rs.Fields.Item("U_LCDESC").Value);
        //    SetEdit(oForm, "ETCURR", rs.Fields.Item("U_CURRENCY").Value);

        //    SetEdit(oForm, "ETBP1BNK", rs.Fields.Item("U_BNK1CODE").Value);
        //    SetEdit(oForm, "ETBP1BNM", rs.Fields.Item("U_BNK1NAME").Value);
        //    SetEdit(oForm, "ETBP2BNK", rs.Fields.Item("U_BNK2CODE").Value);
        //    SetEdit(oForm, "ETBP2BNM", rs.Fields.Item("U_BNK2NAME").Value);
        //    SetEdit(oForm, "ETHUSBNK", rs.Fields.Item("U_HBNKCODE").Value);
        //    SetEdit(oForm, "ETHUSBNM", rs.Fields.Item("U_HBNKNAME").Value);

        //    SetEditAmountFormat(oForm, "ETLCVAL", rs.Fields.Item("U_LCVALUE").Value);

        //    SetEditDateFormat(oForm, "ETDOCDAT", rs.Fields.Item("U_DOCDATE").Value);
        //    SetEditDateFormat(oForm, "ETISUDAT", rs.Fields.Item("U_ISSUEDATE").Value);
        //    SetEditDateFormat(oForm, "ETSHPDAT", rs.Fields.Item("U_SHIPDATE").Value);
        //    SetEditDateFormat(oForm, "ETEXPDAT", rs.Fields.Item("U_EXPDATE").Value);

        //    SetEdit(oForm, "ETB2BPER", rs.Fields.Item("U_BTOBLCPER").Value);
        //    SetEditAmountFormat(oForm, "ETB2BAMT", rs.Fields.Item("U_BTOBLCVALUE").Value);

        //    SetEdit(oForm, "ETLCTRMS", rs.Fields.Item("U_LCTERMS").Value);
        //    SetEdit(oForm, "ETPYTRMS", rs.Fields.Item("U_PAYTERMS").Value);
        //    SetEdit(oForm, "ETINTRMS", rs.Fields.Item("U_INCOTRMS").Value);

        //    SetEdit(oForm, "ETAMDNO", rs.Fields.Item("U_AMNDMNT").Value);
        //    SetEdit(oForm, "ETREMRKS", rs.Fields.Item("U_Remarks").Value);
        //}
        private void LoadLCAmendmentHeader(SAPbouiCOM.Form oForm, string docEntry, string docNum, string amendNo, string logInst)
        {
            SAPbobsCOM.Recordset rs = null;

            try
            {
                string safeDocEntry = docEntry.Replace("'", "''");
                string safeDocNum = docNum.Replace("'", "''");
                string safeAmendNo = amendNo.Replace("'", "''");
                string safeLogInst = logInst.Replace("'", "''");

                string sql = $@"
                                SELECT
                                    T0.""DocEntry"",
                                    T0.""DocNum"",

                                    T0.""Series"",
                                    IFNULL(S.""SeriesName"", TO_NVARCHAR(T0.""Series"")) AS ""SeriesDesc"",

                                    T0.""U_BRANCH"",
                                    IFNULL(B.""BPLName"", TO_NVARCHAR(T0.""U_BRANCH"")) AS ""BranchDesc"",

                                    T0.""U_MLCSTATUS"",
                                    CASE
                                        WHEN T0.""U_MLCSTATUS"" = 'C' THEN 'Confirmed'
                                        WHEN T0.""U_MLCSTATUS"" = 'D' THEN 'Draft'
                                        ELSE IFNULL(T0.""U_MLCSTATUS"", '')
                                    END AS ""MarketingStatusDesc"",

                                    T0.""U_CLCSTATUS"",
                                    CASE
                                        WHEN T0.""U_CLCSTATUS"" = 'C' THEN 'Confirmed'
                                        WHEN T0.""U_CLCSTATUS"" = 'D' THEN 'Draft'
                                        ELSE IFNULL(T0.""U_CLCSTATUS"", '')
                                    END AS ""CommercialStatusDesc"",

                                    T0.""U_CARDCODE"",
                                    T0.""U_CARDNAME"",
                                    T0.""U_SCNO"",
                                    T0.""U_LCNO"",
                                    T0.""U_LCDESC"",
                                    T0.""U_CURRENCY"",

                                    T0.""U_BNK1CODE"",
                                    T0.""U_BNK1NAME"",
                                    T0.""U_BNK2CODE"",
                                    T0.""U_BNK2NAME"",
                                    T0.""U_HBNKCODE"",
                                    T0.""U_HBNKNAME"",

                                    T0.""U_LCVALUE"",
                                    T0.""U_DOCDATE"",
                                    T0.""U_ISSUEDATE"",
                                    T0.""U_SHIPDATE"",
                                    T0.""U_EXPDATE"",
                                    T0.""U_BTOBLCPER"",
                                    T0.""U_BTOBLCVALUE"",

                                    T0.""U_LCTERMS"",
                                    IFNULL(LV.""Descr"", T0.""U_LCTERMS"") AS ""LCTermsDesc"",

                                    T0.""U_PAYTERMS"",
                                    IFNULL(P.""PymntGroup"", TO_NVARCHAR(T0.""U_PAYTERMS"")) AS ""PaymentTermsDesc"",

                                    T0.""U_INCOTRMS"",
                                    IFNULL(I.""Name"", T0.""U_INCOTRMS"") AS ""IncoTermsDesc"",

                                    T0.""U_AMNDMNT"",
                                    T0.""U_Remarks""

                                FROM ""@AFIL_DH_OLCM"" T0

                                LEFT JOIN ""NNM1"" S
                                    ON TO_NVARCHAR(T0.""Series"") = TO_NVARCHAR(S.""Series"")

                                LEFT JOIN ""OBPL"" B
                                    ON TO_NVARCHAR(T0.""U_BRANCH"") = TO_NVARCHAR(B.""BPLId"")

                                LEFT JOIN ""OCTG"" P
                                    ON TO_NVARCHAR(T0.""U_PAYTERMS"") = TO_NVARCHAR(P.""GroupNum"")

                                LEFT JOIN ""@FIL_MH_INCOTRMS"" I
                                    ON TO_NVARCHAR(T0.""U_INCOTRMS"") = TO_NVARCHAR(I.""Code"")

                                LEFT JOIN ""CUFD"" FLC
                                    ON FLC.""TableID"" = '@FIL_DH_OLCM'
                                    AND FLC.""AliasID"" = 'LCTERMS'

                                LEFT JOIN ""UFD1"" LV
                                    ON LV.""TableID"" = FLC.""TableID""
                                    AND LV.""FieldID"" = FLC.""FieldID""
                                    AND TO_NVARCHAR(LV.""FldValue"") = TO_NVARCHAR(T0.""U_LCTERMS"")

                                WHERE T0.""DocEntry"" = '{safeDocEntry}'
                                AND T0.""DocNum"" = '{safeDocNum}'
                                AND T0.""U_AMNDMNT"" = '{safeAmendNo}'
                                AND T0.""LogInst"" = '{safeLogInst}'";

                rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(sql);

                if (rs.EoF)
                {
                    Global.GFunc.ShowError("Export LC amendment header data not found.");
                    return;
                }

                // Document
                SetEdit(oForm, "ETDOCTRY", rs.Fields.Item("DocEntry").Value);
                SetEdit(oForm, "ETDOCNUM", rs.Fields.Item("DocNum").Value);

                // Former ComboBoxes - show description instead of code
                SetEdit(oForm, "ETSERIES", rs.Fields.Item("SeriesDesc").Value);
                SetEdit(oForm, "ETCOMPNY", rs.Fields.Item("BranchDesc").Value);
                SetEdit(oForm, "ETSTATMR", rs.Fields.Item("MarketingStatusDesc").Value);
                SetEdit(oForm, "ETSTATCM", rs.Fields.Item("CommercialStatusDesc").Value);

                // Customer / LC
                SetEdit(oForm, "ETCUSTMR", rs.Fields.Item("U_CARDCODE").Value);
                SetEdit(oForm, "ETCUSTNM", rs.Fields.Item("U_CARDNAME").Value);
                SetEdit(oForm, "ETSCNO", rs.Fields.Item("U_SCNO").Value);
                SetEdit(oForm, "ETLCNO", rs.Fields.Item("U_LCNO").Value);
                SetEdit(oForm, "ETLCDESC", rs.Fields.Item("U_LCDESC").Value);
                SetEdit(oForm, "ETCURR", rs.Fields.Item("U_CURRENCY").Value);

                // Banks
                SetEdit(oForm, "ETBP1BNK", rs.Fields.Item("U_BNK1CODE").Value);
                SetEdit(oForm, "ETBP1BNM", rs.Fields.Item("U_BNK1NAME").Value);
                SetEdit(oForm, "ETBP2BNK", rs.Fields.Item("U_BNK2CODE").Value);
                SetEdit(oForm, "ETBP2BNM", rs.Fields.Item("U_BNK2NAME").Value);
                SetEdit(oForm, "ETHUSBNK", rs.Fields.Item("U_HBNKCODE").Value);
                SetEdit(oForm, "ETHUSBNM", rs.Fields.Item("U_HBNKNAME").Value);

                // Amount
                SetEditAmountFormat(oForm, "ETLCVAL", rs.Fields.Item("U_LCVALUE").Value);
                SetEdit(oForm, "ETB2BPER", rs.Fields.Item("U_BTOBLCPER").Value);
                SetEditAmountFormat(oForm, "ETB2BAMT", rs.Fields.Item("U_BTOBLCVALUE").Value);

                // Dates
                SetEditDateFormat(oForm, "ETDOCDAT", rs.Fields.Item("U_DOCDATE").Value);
                SetEditDateFormat(oForm, "ETISUDAT", rs.Fields.Item("U_ISSUEDATE").Value);
                SetEditDateFormat(oForm, "ETSHPDAT", rs.Fields.Item("U_SHIPDATE").Value);
                SetEditDateFormat(oForm, "ETEXPDAT", rs.Fields.Item("U_EXPDATE").Value);

                // Former ComboBoxes - show description
                SetEdit(oForm, "ETLCTRMS", rs.Fields.Item("LCTermsDesc").Value);
                SetEdit(oForm, "ETPYTRMS", rs.Fields.Item("PaymentTermsDesc").Value);
                SetEdit(oForm, "ETINTRMS", rs.Fields.Item("IncoTermsDesc").Value);

                // Amendment / Remarks
                SetEdit(oForm, "ETAMDNO", rs.Fields.Item("U_AMNDMNT").Value);
                SetEdit(oForm, "ETREMRKS", rs.Fields.Item("U_Remarks").Value);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Export LC amendment header load error: " + ex.Message);
            }
            finally
            {
                if (rs != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);
                    rs = null;
                }
            }
        }
        private void LoadLCAmendmentSalesOrderMatrix(SAPbouiCOM.Form oForm, string docEntry, string amendNo, string logInst)
        {
            SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
            mtx.Clear();

            string sql = $@"
                            SELECT
                                ""LineId"",
                                ""U_SONO"",
                                ""U_SOENTRY"",
                                ""U_CUSTREFNO"",
                                ""U_STYLENTRY"",
                                ""U_STYLECODE"",
                                ""U_STYLENM"",
                                ""U_QUANTITY"",
                                ""U_VALUE"",
                                ""U_AMNDMNT""
                            FROM ""@AFIL_DR_LCM1""
                            WHERE ""DocEntry"" = '{docEntry}'
                            AND ""LogInst"" = '{logInst}'
                            AND ""U_AMNDMNT"" = '{amendNo}'
                            ORDER BY ""LineId""";

            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs.DoQuery(sql);

            int row = 1;

            while (!rs.EoF)
            {
                mtx.AddRow();

                SetMatrixValue(mtx, "#", row, rs.Fields.Item("LineId").Value);
                SetMatrixValue(mtx, "CLSLORDR", row, rs.Fields.Item("U_SONO").Value);
                SetMatrixValue(mtx, "CLSONTRY", row, rs.Fields.Item("U_SOENTRY").Value);
                SetMatrixValue(mtx, "CLCUSRNO", row, rs.Fields.Item("U_CUSTREFNO").Value);
                SetMatrixValue(mtx, "CLSLENTRY", row, rs.Fields.Item("U_STYLENTRY").Value);
                SetMatrixValue(mtx, "CLSTYLCD", row, rs.Fields.Item("U_STYLECODE").Value);
                SetMatrixValue(mtx, "CLSTYLDS", row, rs.Fields.Item("U_STYLENM").Value);
                SetMatrixValue(mtx, "CLTTLQTY", row, rs.Fields.Item("U_QUANTITY").Value);
                SetMatrixValue(mtx, "CLTTLAMT", row, rs.Fields.Item("U_VALUE").Value);
                SetMatrixValue(mtx, "CLAMDNO", row, rs.Fields.Item("U_AMNDMNT").Value);

                row++;
                rs.MoveNext();
            }

            mtx.AutoResizeColumns();
        }
        private void LoadLCAmendmentAttachmentMatrix(SAPbouiCOM.Form oForm, string docEntry, string amendNo, string logInst)
        {
            SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;
            mtx.Clear();

            string sql = $@"
                            SELECT
                                ""LineId"",
                                ""U_ATCHMENT"",
                                ""U_REMARKS"",
                                ""U_AMNDMNT""
                            FROM ""@AFIL_DR_LCM2""
                            WHERE ""DocEntry"" = '{docEntry}'
                            AND ""LogInst"" = '{logInst}'
                            AND ""U_AMNDMNT"" = '{amendNo}'
                            ORDER BY ""LineId""";

            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs.DoQuery(sql);

            int row = 1;

            while (!rs.EoF)
            {
                mtx.AddRow();

                SetMatrixValue(mtx, "#", row, rs.Fields.Item("LineId").Value);
                SetMatrixValue(mtx, "CLATTACH", row, rs.Fields.Item("U_ATCHMENT").Value);
                SetMatrixValue(mtx, "CLREMRKS", row, rs.Fields.Item("U_REMARKS").Value);
                SetMatrixValue(mtx, "CLAMDNO", row, rs.Fields.Item("U_AMNDMNT").Value);

                row++;
                rs.MoveNext();
            }
            mtx.AutoResizeColumns();
        }

        private void SetEdit(SAPbouiCOM.Form oForm, string itemId, object value)
        {
            try
            {
                ((SAPbouiCOM.EditText)oForm.Items.Item(itemId).Specific).Value = value == null ? "" : value.ToString();
            }
            catch { }
        }

        private void SetEditDateFormat(SAPbouiCOM.Form oForm, string itemId, object value)
        {
            try
            {
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                    return;

                DateTime dt;
                if (!DateTime.TryParse(value.ToString(), out dt))
                    return;

                ((SAPbouiCOM.EditText)oForm.Items.Item(itemId).Specific).Value = dt.ToString("yyyyMMdd");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Date load error for " + itemId + ": " + ex.Message);
            }
        }

        private void SetEditAmountFormat(SAPbouiCOM.Form oForm, string itemId, object value)
        {
            try
            {
                if (value == null)
                    return;

                decimal amount;
                if (!decimal.TryParse(value.ToString(), out amount))
                    amount = 0;

                ((SAPbouiCOM.EditText)oForm.Items.Item(itemId).Specific).Value = amount.ToString("#,##0.00");
            }
            catch { }
        }

        private void SetMatrixValue(SAPbouiCOM.Matrix mtx, string colId, int row, object value)
        {
            try
            {
                ((SAPbouiCOM.EditText)mtx.Columns.Item(colId).Cells.Item(row).Specific).Value = value == null ? "" : value.ToString();
            }
            catch { }
        }

        private void LoadAmendmentGrid(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                string docEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value.Trim();
                string docNum = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(docEntry) || string.IsNullOrWhiteSpace(docNum))
                    return;

                SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("GRDAMDTL").Specific;

                SAPbouiCOM.DataTable oDT;
                try
                {
                    oDT = oForm.DataSources.DataTables.Item("DT_AMDTL");
                }
                catch
                {
                    oDT = oForm.DataSources.DataTables.Add("DT_AMDTL");
                }

                oDT.Clear();

                string query = $@"
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY TO_INTEGER(""U_AMNDMNT"") DESC) AS ""#"",
                            ""DocEntry"",
                            ""DocNum"",
                            ""Creator"",
                            ""CreateDate"",
                            ""UpdateDate"",
                            ""LogInst"",
                            ""U_AMNDMNT"" AS ""Amendment No""
                        FROM
                        (
                            SELECT 
                                ""DocEntry"",
                                ""DocNum"",
                                ""Creator"",
                                ""CreateDate"",
                                ""UpdateDate"",
                                ""LogInst"",
                                ""U_AMNDMNT"",
                                ROW_NUMBER() OVER (
                                    PARTITION BY ""DocEntry"", ""DocNum"", ""U_AMNDMNT""
                                    ORDER BY ""LogInst"" DESC
                                ) AS ""RN""
                            FROM ""@AFIL_DH_OLCM""
                            WHERE ""DocEntry"" = {docEntry}
                              AND ""DocNum"" = {docNum}
                        ) T
                        WHERE ""RN"" = 1
                        ORDER BY TO_INTEGER(""U_AMNDMNT"") DESC";

                oDT.ExecuteQuery(query);
                oGrid.DataTable = oDT;

                for (int i = 0; i < oGrid.Columns.Count; i++)
                    oGrid.Columns.Item(i).Editable = false;

                oGrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error loading amendment grid: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }


        //private void SetStatusFields(SAPbouiCOM.Form oForm)
        //{
        //    try
        //    {
        //        SAPbouiCOM.ComboBox cbStatMR = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;
        //        SAPbouiCOM.ComboBox cbStatCM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

        //        string mrStatus = cbStatMR.Selected == null ? "" : cbStatMR.Selected.Value.Trim();
        //        string cmStatus = cbStatCM.Selected == null ? "" : cbStatCM.Selected.Value.Trim();

        //        if (mrStatus == "D" && cmStatus == "D")
        //        {
        //            oForm.Items.Item("CBSTATMR").Enabled = true;
        //            oForm.Items.Item("CBSTATCM").Enabled = false;
        //        }
        //        else if (mrStatus == "C" && cmStatus == "D")
        //        {
        //            oForm.Items.Item("CBSTATMR").Enabled = false;
        //            oForm.Items.Item("CBSTATCM").Enabled = true;
        //        }
        //        else if (mrStatus == "C" && cmStatus == "C")
        //        {
        //            oForm.Items.Item("CBSTATMR").Enabled = false;
        //            oForm.Items.Item("CBSTATCM").Enabled = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError("Status field control error: " + ex.Message);
        //    }
        //}

        private void CalculateB2BAmount(SAPbouiCOM.Form oForm)
        {
            try
            {
                string lcValueStr = ((SAPbouiCOM.EditText)oForm.Items.Item("ETLCVAL").Specific).Value.Trim();
                string b2bPerStr = ((SAPbouiCOM.EditText)oForm.Items.Item("ETB2BPER").Specific).Value.Trim();

                decimal lcValue = 0;
                decimal b2bPercent = 0;

                decimal.TryParse(lcValueStr, out lcValue);
                decimal.TryParse(b2bPerStr, out b2bPercent);

                if (b2bPercent < 0 || b2bPercent > 100)
                {
                    Global.GFunc.ShowError("B2B Percentage must be between 0 and 100.");
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETB2BPER").Specific).Value = "";
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETB2BAMT").Specific).Value = "0.00";
                    return;
                }

                decimal b2bAmount = (lcValue * b2bPercent) / 100;

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETB2BAMT").Specific).Value = b2bAmount.ToString("0.00");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("B2B Amount calculation error: " + ex.Message);
            }
        }
        private bool IsDuplicateLCNo(SAPbouiCOM.Form oForm, string lcNo)
        {
            SAPbobsCOM.Recordset oRS = null;
            try
            {
                SAPbouiCOM.DBDataSource oHeader = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM");
                string safeLCNo = lcNo.Replace("'", "''");
                string query = "";

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    query = $@"SELECT ""DocEntry"" FROM ""@FIL_DH_OLCM"" WHERE TRIM(""U_LCNO"") = TRIM('{safeLCNo}')";
                else if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                {
                    string docEntry = oHeader.GetValue("DocEntry", 0).Trim();
                    query = $@"SELECT ""DocEntry"" FROM ""@FIL_DH_OLCM"" WHERE TRIM(""U_LCNO"") = TRIM('{safeLCNo}') AND ""DocEntry"" <> {docEntry}";
                }

                oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                oRS.DoQuery(query);

                return !oRS.EoF;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("LC No validation error: " + ex.Message);
                return true;
            }
            finally
            {
                if (oRS != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRS);
                    oRS = null;
                }
            }
        }

        private void CalculateLCValue(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix)
        {
            try
            {
                decimal totalLCValue = 0;

                for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                {
                    SAPbouiCOM.EditText txtTotalAmount = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLTTLAMT").Cells.Item(i).Specific;
                    string value = txtTotalAmount.Value.Trim();

                    decimal rowValue;
                    if (decimal.TryParse(value, out rowValue))
                        totalLCValue += rowValue;
                }

                SAPbouiCOM.EditText ETLCVAL = (SAPbouiCOM.EditText)oForm.Items.Item("ETLCVAL").Specific;
                ETLCVAL.Value = totalLCValue.ToString("0.00");

                CalculateB2BAmount(oForm);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("LC Value calculation error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private class SalesOrderMismatch
        {
            public int Row { get; set; }
            public string SONo { get; set; }
            public string SOEntry { get; set; }

            public string MatrixCustRefNo { get; set; }
            public string CurrentCustRefNo { get; set; }

            public decimal MatrixQty { get; set; }
            public decimal CurrentQty { get; set; }

            public decimal MatrixValue { get; set; }
            public decimal CurrentValue { get; set; }

            public bool CustRefMismatch { get; set; }
            public bool QtyMismatch { get; set; }
            public bool ValueMismatch { get; set; }
        }

        private decimal ParseDecimal(string value)
        {
            decimal result = 0;

            if (string.IsNullOrWhiteSpace(value))
                return 0;

            decimal.TryParse(value.Replace(",", "").Trim(), out result);
            return result;
        }

        //private List<SalesOrderMismatch> GetSalesOrderMismatches(SAPbouiCOM.Form oForm)
        //{
        //    List<SalesOrderMismatch> mismatches = new List<SalesOrderMismatch>();
        //    SAPbobsCOM.Recordset rs = null;

        //    try
        //    {
        //        SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
        //        SAPbouiCOM.DBDataSource dbDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");

        //        mtx.FlushToDataSource();

        //        rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

        //        for (int i = 0; i < dbDetail.Size; i++)
        //        {
        //            string soNo = dbDetail.GetValue("U_SONO", i).Trim();
        //            string soEntry = dbDetail.GetValue("U_SOENTRY", i).Trim();


        //            if (string.IsNullOrWhiteSpace(soNo) || string.IsNullOrWhiteSpace(soEntry))
        //                continue;

        //            decimal matrixQty = ParseDecimal(dbDetail.GetValue("U_QUANTITY", i));
        //            decimal matrixValue = ParseDecimal(dbDetail.GetValue("U_VALUE", i));

        //            string query = $@"
        //                            SELECT
        //                                SUM(B.""Quantity"") AS ""Quantity"",
        //                                CASE
        //                                    WHEN A.""DocCur"" = 'BDT' THEN A.""DocTotal""
        //                                    ELSE A.""DocTotalFC""
        //                                END AS ""TotalValue""
        //                            FROM ORDR A
        //                            INNER JOIN RDR1 B ON A.""DocEntry"" = B.""DocEntry""
        //                            WHERE A.""DocEntry"" = {soEntry}
        //                            GROUP BY
        //                                A.""DocCur"",
        //                                A.""DocTotal"",
        //                                A.""DocTotalFC""";

        //            rs.DoQuery(query);

        //            if (rs.EoF)
        //            {
        //                mismatches.Add(new SalesOrderMismatch
        //                {
        //                    Row = i,
        //                    SONo = soNo,
        //                    SOEntry = soEntry,
        //                    MatrixQty = matrixQty,
        //                    CurrentQty = 0,
        //                    MatrixValue = matrixValue,
        //                    CurrentValue = 0,
        //                    QtyMismatch = true,
        //                    ValueMismatch = true
        //                });

        //                continue;
        //            }

        //            decimal currentQty = Convert.ToDecimal(rs.Fields.Item("Quantity").Value);
        //            decimal currentValue = Convert.ToDecimal(rs.Fields.Item("TotalValue").Value);

        //            bool qtyMismatch = Math.Abs(matrixQty - currentQty) > 0.000001M;
        //            bool valueMismatch = Math.Abs(matrixValue - currentValue) > 0.01M;

        //            if (qtyMismatch || valueMismatch)
        //            {
        //                mismatches.Add(new SalesOrderMismatch
        //                {
        //                    Row = i,
        //                    SONo = soNo,
        //                    SOEntry = soEntry,
        //                    MatrixQty = matrixQty,
        //                    CurrentQty = currentQty,
        //                    MatrixValue = matrixValue,
        //                    CurrentValue = currentValue,
        //                    QtyMismatch = qtyMismatch,
        //                    ValueMismatch = valueMismatch
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError("Sales Order validation error: " + ex.Message);
        //        throw;
        //    }
        //    finally
        //    {
        //        if (rs != null)
        //        {
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);
        //            rs = null;
        //        }
        //    }

        //    return mismatches;
        //}
        private List<SalesOrderMismatch> GetSalesOrderMismatches(SAPbouiCOM.Form oForm)
        {
            List<SalesOrderMismatch> mismatches = new List<SalesOrderMismatch>();
            SAPbobsCOM.Recordset rs = null;

            try
            {
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.DBDataSource dbDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");

                mtx.FlushToDataSource();

                rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                for (int i = 0; i < dbDetail.Size; i++)
                {
                    string soNo = dbDetail.GetValue("U_SONO", i).Trim();
                    string soEntry = dbDetail.GetValue("U_SOENTRY", i).Trim();

                    if (string.IsNullOrWhiteSpace(soNo) || string.IsNullOrWhiteSpace(soEntry))
                        continue;

                    string matrixCustRefNo = dbDetail.GetValue("U_CUSTREFNO", i).Trim();
                    decimal matrixQty = ParseDecimal(dbDetail.GetValue("U_QUANTITY", i));
                    decimal matrixValue = ParseDecimal(dbDetail.GetValue("U_VALUE", i));

                    string query = $@"
                            SELECT
                                IFNULL(A.""NumAtCard"", '') AS ""CustRefNo"",
                                SUM(B.""Quantity"") AS ""Quantity"",
                                CASE
                                    WHEN A.""DocCur"" = 'BDT' THEN A.""DocTotal""
                                    ELSE A.""DocTotalFC""
                                END AS ""TotalValue""
                            FROM ORDR A
                            INNER JOIN RDR1 B ON A.""DocEntry"" = B.""DocEntry""
                            WHERE A.""DocEntry"" = {soEntry}
                            GROUP BY
                                A.""NumAtCard"",
                                A.""DocCur"",
                                A.""DocTotal"",
                                A.""DocTotalFC""";

                    rs.DoQuery(query);

                    if (rs.EoF)
                    {
                        mismatches.Add(new SalesOrderMismatch
                        {
                            Row = i,
                            SONo = soNo,
                            SOEntry = soEntry,
                            MatrixCustRefNo = matrixCustRefNo,
                            CurrentCustRefNo = "",
                            MatrixQty = matrixQty,
                            CurrentQty = 0,
                            MatrixValue = matrixValue,
                            CurrentValue = 0,
                            CustRefMismatch = !string.IsNullOrWhiteSpace(matrixCustRefNo),
                            QtyMismatch = true,
                            ValueMismatch = true
                        });

                        continue;
                    }

                    string currentCustRefNo = Convert.ToString(rs.Fields.Item("CustRefNo").Value).Trim();
                    decimal currentQty = Convert.ToDecimal(rs.Fields.Item("Quantity").Value);
                    decimal currentValue = Convert.ToDecimal(rs.Fields.Item("TotalValue").Value);

                    bool custRefMismatch = !string.Equals(matrixCustRefNo, currentCustRefNo, StringComparison.Ordinal);
                    bool qtyMismatch = Math.Abs(matrixQty - currentQty) > 0.000001M;
                    bool valueMismatch = Math.Abs(matrixValue - currentValue) > 0.01M;

                    if (custRefMismatch || qtyMismatch || valueMismatch)
                    {
                        mismatches.Add(new SalesOrderMismatch
                        {
                            Row = i,
                            SONo = soNo,
                            SOEntry = soEntry,
                            MatrixCustRefNo = matrixCustRefNo,
                            CurrentCustRefNo = currentCustRefNo,
                            MatrixQty = matrixQty,
                            CurrentQty = currentQty,
                            MatrixValue = matrixValue,
                            CurrentValue = currentValue,
                            CustRefMismatch = custRefMismatch,
                            QtyMismatch = qtyMismatch,
                            ValueMismatch = valueMismatch
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sales Order validation error: " + ex.Message);
                throw;
            }
            finally
            {
                if (rs != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);
                    rs = null;
                }
            }

            return mismatches;
        }

        private bool IsBothStatusConfirmed(SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.ComboBox cbStatMR = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;
            SAPbouiCOM.ComboBox cbStatCM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

            string mrStatus = cbStatMR.Selected == null ? "" : cbStatMR.Selected.Value.Trim();
            string cmStatus = cbStatCM.Selected == null ? "" : cbStatCM.Selected.Value.Trim();

            return mrStatus == "C" && cmStatus == "C";
        }


        private void CleanSalesOrderMatrix(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");

                oForm.Freeze(true);
                mtx.FlushToDataSource();

                for (int i = db.Size - 1; i >= 0; i--)
                {
                    string soNo = db.GetValue("U_SONO", i).Trim();

                    if (string.IsNullOrWhiteSpace(soNo))
                        db.RemoveRecord(i);
                }

                for (int i = 0; i < db.Size; i++)
                    db.SetValue("LineId", i, (i + 1).ToString());

                mtx.LoadFromDataSource();

                Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXSLODR", "@FIL_DR_LCM1", "U_SONO");

                CalculateLCValue(oForm, mtx);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sales Order matrix cleanup error: " + ex.Message);
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        //private void SetLCNoStatus(SAPbouiCOM.Form oForm)
        //{
        //    bool bothConfirmed = IsBothStatusConfirmed(oForm);

        //    string amendNoStr = ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific).Value.Trim();

        //    int amendNo = 0;
        //    int.TryParse(amendNoStr, out amendNo);

        //    SAPbouiCOM.StaticText stLCNo = (SAPbouiCOM.StaticText)oForm.Items.Item("STLCNO").Specific;

        //    if (amendNo > 0)
        //    {
        //        // Once amendment starts, LC No cannot be changed
        //        oForm.Items.Item("ETLCNO").Enabled = false;

        //        // Existing LC No remains mandatory
        //        stLCNo.Caption = "LC No*";

        //        return;
        //    }

        //    // Original document: Amendment No = 0
        //    stLCNo.Caption = bothConfirmed ? "LC No*" : "LC No";
        //    oForm.Items.Item("ETLCNO").Enabled = !bothConfirmed;
        //}

        private void ApplyExportLCStatusState(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.ComboBox cbStatMR = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;
                SAPbouiCOM.ComboBox cbStatCM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;
                SAPbouiCOM.StaticText stLCNo = (SAPbouiCOM.StaticText)oForm.Items.Item("STLCNO").Specific;

                string mrStatus = cbStatMR.Selected == null ? "" : cbStatMR.Selected.Value.Trim();
                string cmStatus = cbStatCM.Selected == null ? "" : cbStatCM.Selected.Value.Trim();
                string amendNoStr = ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific).Value.Trim();

                int amendNo = 0;
                int.TryParse(amendNoStr, out amendNo);

                bool bothConfirmed = mrStatus == "C" && cmStatus == "C";

                if (mrStatus == "D" && cmStatus == "D")
                {
                    oForm.Items.Item("CBSTATMR").Enabled = true;
                    oForm.Items.Item("CBSTATCM").Enabled = false;
                }
                else if (mrStatus == "C" && cmStatus == "D")
                {
                    oForm.Items.Item("CBSTATMR").Enabled = false;
                    oForm.Items.Item("CBSTATCM").Enabled = true;
                }
                else if (bothConfirmed)
                {
                    oForm.Items.Item("CBSTATMR").Enabled = false;
                    oForm.Items.Item("CBSTATCM").Enabled = false;
                }
                else
                {
                    oForm.Items.Item("CBSTATMR").Enabled = true;
                    oForm.Items.Item("CBSTATCM").Enabled = false;
                }

                if (amendNo > 0)
                {
                    stLCNo.Caption = "LC No*";
                    oForm.Items.Item("ETLCNO").Enabled = false;
                }
                else
                {
                    stLCNo.Caption = bothConfirmed ? "LC No*" : "LC No";
                    oForm.Items.Item("ETLCNO").Enabled = !bothConfirmed;
                }

                oForm.Items.Item("BTNAMND").Enabled = bothConfirmed && oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Export LC status control error: " + ex.Message);
            }
        }

        private bool ValidateDuplicateSalesOrderInMatrix(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.DBDataSource dbDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");

                mtx.FlushToDataSource();

                HashSet<string> usedSOEntries = new HashSet<string>();
                List<string> duplicateSONos = new List<string>();

                for (int i = 0; i < dbDetail.Size; i++)
                {
                    string soNo = dbDetail.GetValue("U_SONO", i).Trim();
                    string soEntry = dbDetail.GetValue("U_SOENTRY", i).Trim();

                    if (string.IsNullOrWhiteSpace(soNo) || string.IsNullOrWhiteSpace(soEntry))
                        continue;

                    if (!usedSOEntries.Add(soEntry) && !duplicateSONos.Contains(soNo))
                        duplicateSONos.Add(soNo);
                }

                if (duplicateSONos.Count > 0)
                {
                    StringBuilder message = new StringBuilder();
                    message.AppendLine("Duplicate Sales Order found in the matrix.");
                    message.AppendLine("");

                    foreach (string soNo in duplicateSONos)
                        message.AppendLine("Sales Order: " + soNo);

                    message.AppendLine("");
                    message.AppendLine("The same Sales Order cannot be selected more than once.");

                    Application.SBO_Application.MessageBox(message.ToString());
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sales Order duplicate validation error: " + ex.Message);
                return false;
            }
        }

        private bool ValidateSalesOrderSalesContract(SAPbouiCOM.Form oForm)
        {
            SAPbobsCOM.Recordset rs = null;

            try
            {
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.DBDataSource dbDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");
                SAPbouiCOM.DBDataSource dbHeader = oForm.DataSources.DBDataSources.Item("@FIL_DH_OLCM");

                mtx.FlushToDataSource();

                string currentSCNo = dbHeader.GetValue("U_SCNO", 0).Trim();

                if (string.IsNullOrWhiteSpace(currentSCNo))
                    return true;

                rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                StringBuilder message = new StringBuilder();
                bool mismatchFound = false;

                for (int i = 0; i < dbDetail.Size; i++)
                {
                    string soNo = dbDetail.GetValue("U_SONO", i).Trim();
                    string soEntry = dbDetail.GetValue("U_SOENTRY", i).Trim();

                    if (string.IsNullOrWhiteSpace(soNo) || string.IsNullOrWhiteSpace(soEntry))
                        continue;

                    string query = $@"SELECT IFNULL(""U_SCNO"", '') AS ""SCNo"" FROM ORDR WHERE ""DocEntry"" = {soEntry}";
                    rs.DoQuery(query);

                    if (rs.EoF)
                        continue;

                    string salesOrderSCNo = Convert.ToString(rs.Fields.Item("SCNo").Value).Trim();

                    if (!string.Equals(currentSCNo, salesOrderSCNo, StringComparison.OrdinalIgnoreCase))
                    {
                        if (!mismatchFound)
                        {
                            message.AppendLine("Sales Order and Sales Contract mismatch found.");
                            message.AppendLine("");
                            message.AppendLine("Selected Sales Contract: " + currentSCNo);
                            message.AppendLine("");
                        }

                        message.AppendLine("Sales Order: " + soNo + " | Sales Order SC No: " + (string.IsNullOrWhiteSpace(salesOrderSCNo) ? "Not Assigned" : salesOrderSCNo));
                        mismatchFound = true;
                    }
                }

                if (mismatchFound)
                {
                    message.AppendLine("");
                    message.AppendLine("Please select Sales Orders that belong to the selected Sales Contract.");
                    Application.SBO_Application.MessageBox(message.ToString());
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sales Order Sales Contract validation error: " + ex.Message);
                return false;
            }
            finally
            {
                if (rs != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);
                    rs = null;
                }
            }
        }

        private bool ValidateSalesOrderAlreadyUsed(SAPbouiCOM.Form oForm)
        {
            SAPbobsCOM.Recordset rs = null;

            try
            {
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSLODR").Specific;
                SAPbouiCOM.DBDataSource dbDetail = oForm.DataSources.DBDataSources.Item("@FIL_DR_LCM1");

                mtx.FlushToDataSource();

                string currentDocEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value.Trim();

                rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                HashSet<string> checkedSOEntries = new HashSet<string>();
                StringBuilder message = new StringBuilder();
                bool conflictFound = false;

                for (int i = 0; i < dbDetail.Size; i++)
                {
                    string soNo = dbDetail.GetValue("U_SONO", i).Trim();
                    string soEntry = dbDetail.GetValue("U_SOENTRY", i).Trim();

                    if (string.IsNullOrWhiteSpace(soNo) || string.IsNullOrWhiteSpace(soEntry))
                        continue;

                    if (!checkedSOEntries.Add(soEntry))
                        continue;

                    string safeSOEntry = soEntry.Replace("'", "''");

                    string query = $@"
                            SELECT DISTINCT
                                T1.""U_SONO"",
                                T0.""DocEntry"",
                                T0.""DocNum""
                            FROM ""@FIL_DH_OLCM"" T0
                            INNER JOIN ""@FIL_DR_LCM1"" T1 ON T0.""DocEntry"" = T1.""DocEntry""
                            WHERE T1.""U_SOENTRY"" = '{safeSOEntry}'";

                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE && !string.IsNullOrWhiteSpace(currentDocEntry))
                        query += $@" AND T0.""DocEntry"" <> '{currentDocEntry.Replace("'", "''")}'";

                    rs.DoQuery(query);

                    while (!rs.EoF)
                    {
                        if (!conflictFound)
                        {
                            message.AppendLine("The following Sales Order(s) are already used in another Export LC.");
                            message.AppendLine("");
                        }

                        string existingSONo = Convert.ToString(rs.Fields.Item("U_SONO").Value).Trim();
                        string exportLCDocNum = Convert.ToString(rs.Fields.Item("DocNum").Value).Trim();

                        message.AppendLine("Sales Order: " + existingSONo + " | Export LC DocNum: " + exportLCDocNum);

                        conflictFound = true;
                        rs.MoveNext();
                    }
                }

                if (conflictFound)
                {
                    message.AppendLine("");
                    message.AppendLine("Please remove the Sales Order(s) before continuing.");
                    Application.SBO_Application.MessageBox(message.ToString());
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sales Order usage validation error: " + ex.Message);
                return false;
            }
            finally
            {
                if (rs != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);
                    rs = null;
                }
            }
        }
        private bool ValidateConfirmedAmendmentBeforeUpdate(SAPbouiCOM.Form oForm)
        {
            SAPbobsCOM.Recordset rs = null;

            try
            {
                // Validation is required only while updating an existing Export LC
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                    return true;

                string docEntryStr =
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value.Trim();

                string formAmendNoStr =
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMDNO").Specific).Value.Trim();

                // No existing document
                if (string.IsNullOrWhiteSpace(docEntryStr))
                    return true;

                // DocEntry must be numeric
                int docEntry = 0;

                if (!int.TryParse(docEntryStr, out docEntry))
                {
                    Global.GFunc.ShowError("Invalid Export LC DocEntry.");
                    return false;
                }

                // Current amendment number shown on form
                int formAmendNo = 0;
                int.TryParse(formAmendNoStr, out formAmendNo);

                string query = $@"
                        SELECT
                            IFNULL(TO_NVARCHAR(""U_MLCSTATUS""), '') AS ""MRStatus"",
                            IFNULL(TO_NVARCHAR(""U_CLCSTATUS""), '') AS ""CMStatus"",
                            IFNULL(TO_NVARCHAR(""U_AMNDMNT""), '') AS ""AmendmentNo""
                        FROM ""@FIL_DH_OLCM""
                        WHERE ""DocEntry"" = {docEntry}";

                rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(
                    SAPbobsCOM.BoObjectTypes.BoRecordset);

                rs.DoQuery(query);

                // Existing document not found
                if (rs.EoF)
                    return true;

                string savedMRStatus =
                    Convert.ToString(rs.Fields.Item("MRStatus").Value).Trim();

                string savedCMStatus =
                    Convert.ToString(rs.Fields.Item("CMStatus").Value).Trim();

                string savedAmendNoStr =
                    Convert.ToString(rs.Fields.Item("AmendmentNo").Value).Trim();

                int savedAmendNo = 0;
                int.TryParse(savedAmendNoStr, out savedAmendNo);

                bool savedBothConfirmed =
                    savedMRStatus == "C" &&
                    savedCMStatus == "C";

                if (!savedBothConfirmed)
                    return true;

                if (formAmendNo > savedAmendNo)
                    return true;

                // Existing amendment is already fully confirmed.
                // User cannot directly update it.
                if (formAmendNo == savedAmendNo)
                {
                    Global.GFunc.ShowError(
                        "This Export LC is already confirmed by both Marketing and Commercial. " +
                        "Please amend the form first before updating.");

                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError(
                    "Confirmed Export LC validation error: " + ex.Message);

                return false;
            }
            finally
            {
                if (rs != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);
                    rs = null;
                }
            }
        }

        //private bool ValidateSalesOrderCurrentValues(SAPbouiCOM.Form oForm)
        //{
        //    try
        //    {
        //        List<SalesOrderMismatch> mismatches = GetSalesOrderMismatches(oForm);

        //        if (mismatches.Count == 0)
        //            return true;

        //        StringBuilder message = new StringBuilder();
        //        message.AppendLine("Sales Order data has changed.");
        //        message.AppendLine("");

        //        foreach (SalesOrderMismatch item in mismatches)
        //        {
        //            message.AppendLine("Sales Order: " + item.SONo);

        //            if (item.QtyMismatch)
        //                message.AppendLine("Quantity: LC = " + item.MatrixQty.ToString("0.######") + ", Current SO = " + item.CurrentQty.ToString("0.######"));

        //            if (item.ValueMismatch)
        //                message.AppendLine("Total Value: LC = " + item.MatrixValue.ToString("0.00") + ", Current SO = " + item.CurrentValue.ToString("0.00"));

        //            message.AppendLine("");
        //        }

        //        message.AppendLine("Please press Load Data to update the changed Sales Order row(s).");

        //        Application.SBO_Application.MessageBox(message.ToString());

        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        private bool ValidateSalesOrderCurrentValues(SAPbouiCOM.Form oForm)
        {
            try
            {
                List<SalesOrderMismatch> mismatches = GetSalesOrderMismatches(oForm);

                if (mismatches.Count == 0)
                    return true;

                StringBuilder message = new StringBuilder();
                message.AppendLine("Sales Order data has changed.");
                message.AppendLine("");

                foreach (SalesOrderMismatch item in mismatches)
                {
                    message.AppendLine("Sales Order: " + item.SONo);

                    if (item.CustRefMismatch)
                        message.AppendLine("Customer Ref No: LC = " + item.MatrixCustRefNo + ", Current SO = " + item.CurrentCustRefNo);

                    if (item.QtyMismatch)
                        message.AppendLine("Quantity: LC = " + item.MatrixQty.ToString("0.######") + ", Current SO = " + item.CurrentQty.ToString("0.######"));

                    if (item.ValueMismatch)
                        message.AppendLine("Total Value: LC = " + item.MatrixValue.ToString("0.00") + ", Current SO = " + item.CurrentValue.ToString("0.00"));

                    message.AppendLine("");
                }

                message.AppendLine("Please press Load Data to update the changed Sales Order row(s).");

                Application.SBO_Application.MessageBox(message.ToString());

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
