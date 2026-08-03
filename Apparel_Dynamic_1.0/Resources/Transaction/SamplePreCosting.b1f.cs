using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;
using Apparel_Dynamic_1._0.Resources.Master;
using Apparel_Dynamic_1._0.Resources.Version;

namespace Apparel_Dynamic_1._0.Resources.Transaction
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Transaction.SamplePreCosting", "Resources/Transaction/SamplePreCosting.b1f")]
    class SamplePreCosting : UserFormBase
    {
        public SamplePreCosting()
        {
        }

        private SAPbouiCOM.StaticText STSMPLCD, STCMTAMT, STOCTAMT, STCURR, STTCNAMT, STDOCNUM, STDATE, STVERSON,
                                       STPRFPER, STPRFAMT , STFOBAMT, STBUYER, STDOCDAT;

        private SAPbouiCOM.ComboBox CBNO;

        private SAPbouiCOM.EditText ETCURR, ETTCNAMT, ETPRFPER, ETCMTAMT,ETNO, ETOCTAMT, ETBYRNM, ETPRFAMT, ETFOBAMT,
                                        ETSMPLNM, ETDOCNUM, ETDOCDAT, ETVERSON, ETBUYER, ETDOCTRY, ETSMPLCD;

        private SAPbouiCOM.Folder FOLCMPNT, FOLOTCST, FOLVERSN;


        private SAPbouiCOM.Button ADDButton, CancelButton, BTNVRNUP, BTNLCSTH;

        private SAPbouiCOM.Matrix MTXCMPNT, MTXOTCST;

        private SAPbouiCOM.LinkedButton LKBUYER, LKSMPLCD;



        private SAPbouiCOM.Grid GRDVERSN;
        private string SelDocEntry = "";
        private string SelDocNum = "";
        private string SelVersion = "";
        private string SelLogInst = "";


        private bool _isProfitCalculationRunning = false;
        private string _lastProfitInput = "PERCENT";
        private bool _hasInvalidProfitValue = false;

        public override void OnInitializeComponent()
        {
            this.STSMPLCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSMPLCD").Specific));
            this.STCURR = ((SAPbouiCOM.StaticText)(this.GetItem("STCURR").Specific));
            this.STTCNAMT = ((SAPbouiCOM.StaticText)(this.GetItem("STTCNAMT").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STDOCDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.STVERSON = ((SAPbouiCOM.StaticText)(this.GetItem("STVERSON").Specific));
            this.STBUYER = ((SAPbouiCOM.StaticText)(this.GetItem("STBUYER").Specific));
            this.CBNO = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            this.CBNO.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBNO_ComboSelectAfter);
            this.ETCURR = ((SAPbouiCOM.EditText)(this.GetItem("ETCURR").Specific));
            this.ETCURR.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCURR_ChooseFromListAfter);
            this.ETTCNAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETTCNAMT").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETDOCDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.ETDOCDAT.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETDOCDAT_LostFocusAfter);
            this.ETVERSON = ((SAPbouiCOM.EditText)(this.GetItem("ETVERSON").Specific));
            this.ETBUYER = ((SAPbouiCOM.EditText)(this.GetItem("ETBUYER").Specific));
            this.ETBUYER.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBUYER_ChooseFromListAfter);
            this.FOLCMPNT = ((SAPbouiCOM.Folder)(this.GetItem("FOLCMPNT").Specific));
            this.FOLOTCST = ((SAPbouiCOM.Folder)(this.GetItem("FOLOTCST").Specific));
            this.FOLOTCST.ClickAfter += new SAPbouiCOM._IFolderEvents_ClickAfterEventHandler(this.FOLOTCST_ClickAfter);
            // this.FOLOTCST.ClickAfter += new SAPbouiCOM._IFolderEvents_ClickAfterEventHandler(this.FOLOTCST_ClickAfter);
            this.FOLVERSN = ((SAPbouiCOM.Folder)(this.GetItem("FOLVERSN").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNVRNUP = ((SAPbouiCOM.Button)(this.GetItem("BTNVRNUP").Specific));
            this.BTNVRNUP.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNVRNUP_PressedAfter);
            this.MTXCMPNT = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCMPNT").Specific));
            this.MTXCMPNT.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXCMPNT_LostFocusAfter);
            this.MTXCMPNT.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXCMPNT_ChooseFromListAfter);
            this.MTXCMPNT.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXCMPNT_ChooseFromListBefore);
            this.MTXCMPNT.ComboSelectAfter += new SAPbouiCOM._IMatrixEvents_ComboSelectAfterEventHandler(this.MTXCMPNT_ComboSelectAfter);
            this.MTXOTCST = ((SAPbouiCOM.Matrix)(this.GetItem("MTXOTCST").Specific));
            this.MTXOTCST.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXOTCST_LostFocusAfter);
            this.LKBUYER = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKBUYER").Specific));
            this.LKSMPLCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSMPLCD").Specific));
            this.LKSMPLCD.PressedAfter += new SAPbouiCOM._ILinkedButtonEvents_PressedAfterEventHandler(this.LKSMPLCD_PressedAfter);
            this.ETSMPLNM = ((SAPbouiCOM.EditText)(this.GetItem("ETSMPLNM").Specific));
            this.ETBYRNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBYRNM").Specific));
            this.GRDVERSN = ((SAPbouiCOM.Grid)(this.GetItem("GRDVERSN").Specific));
            this.GRDVERSN.DoubleClickAfter += new SAPbouiCOM._IGridEvents_DoubleClickAfterEventHandler(this.GRDVERSN_DoubleClickAfter);
            this.BTNLCSTH = ((SAPbouiCOM.Button)(this.GetItem("BTNLCSTH").Specific));
            this.BTNLCSTH.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNLCSTH_PressedAfter);
            this.ETSMPLCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSMPLCD").Specific));
            this.ETSMPLCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSMPLCD_ChooseFromListAfter);
            this.STPRFPER = ((SAPbouiCOM.StaticText)(this.GetItem("STPRFPER").Specific));
            this.STPRFAMT = ((SAPbouiCOM.StaticText)(this.GetItem("STPRFAMT").Specific));
            this.STFOBAMT = ((SAPbouiCOM.StaticText)(this.GetItem("STFOBAMT").Specific));
            this.ETPRFPER = ((SAPbouiCOM.EditText)(this.GetItem("ETPRFPER").Specific));
            this.ETPRFPER.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETPRFPER_LostFocusAfter);
            this.ETPRFAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETPRFAMT").Specific));
            this.ETPRFAMT.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETPRFAMT_LostFocusAfter);
            this.ETFOBAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETFOBAMT").Specific));
            this.ETFOBAMT.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETFOBAMT_LostFocusAfter);
            this.STCMTAMT = ((SAPbouiCOM.StaticText)(this.GetItem("STCMTAMT").Specific));
            this.ETCMTAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETCMTAMT").Specific));
            this.STOCTAMT = ((SAPbouiCOM.StaticText)(this.GetItem("STOCTAMT").Specific));
            this.ETOCTAMT = ((SAPbouiCOM.EditText)(this.GetItem("ETOCTAMT").Specific));
            this.OnCustomInitialize();

        }



        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.DataUpdateAfter += new DataUpdateAfterHandler(this.Form_DataUpdateAfter);

        }



        private void OnCustomInitialize()
        {

        }


        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                // Enable / Disable Items
                Global.GFunc.SetItemsEnabled(oForm, false, "ETSMPLCD", "ETTCNAMT", "ETSMPLNM", "ETBYRNM", "ETDOCNUM", "ETDOCDAT", "ETVERSON", "CBSERIES");
                Global.GFunc.SetItemsEnabled(oForm, true, "BTNLCSTH", "BTNVRNUP");

                Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXCMPNT", "@FIL_DR_PRECOSTCOMP", "U_ROUTSTAG");

                string route = GetRouteFromSampleCode(oForm);
                LoadRouteWiseComboToMatrixColumn(oForm, "MTXCMPNT", "CLRSTGCD", route);

                LoadVersionGrid(oForm);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Form Data Load Error: " + ex.Message);
            }
        }

        private string GetRouteFromSampleCode(SAPbouiCOM.Form oForm)
        {
            try
            {
                string sampleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSMPLCD").Specific).Value.Trim();

                if (string.IsNullOrEmpty(sampleCode))
                    return string.Empty;

                // Prepare SQL Query
                string query = $@"SELECT TOP 1 ""U_ROUTSTAG"" 
                          FROM ""@FIL_DH_SMPLMAST"" 
                          WHERE ""U_SMPLCODE"" = '{sampleCode}'";

                SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)
                    Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                oRec.DoQuery(query);

                if (!oRec.EoF)
                {
                    return oRec.Fields.Item("U_ROUTSTAG").Value.ToString();
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private void LKSMPLCD_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.EditText ETSMPLCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSMPLCD").Specific;
            string sampleCode = ETSMPLCD.Value.Trim();
            SampleMaster sampleMaster = new SampleMaster();
            sampleMaster.Show();
            //styleMaster. = Global.G_UI_Application.Forms.ActiveForm;
            SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_SMPLMSTR");
            try
            {
                cForm.Freeze(true);
                cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                cForm.Items.Item("ETSLCODE").Enabled = true;
                SAPbouiCOM.EditText cETSLCODE = (SAPbouiCOM.EditText)cForm.Items.Item("ETSLCODE").Specific;
                cETSLCODE.Value = sampleCode;
                cForm.Items.Item("1").Click();
                cForm.Items.Item("FOLSIZE").Click();
                cForm.Freeze(false);
            }
            catch (Exception ex)
            {
                cForm.Freeze(false);
            }

        }

        private void GRDVERSN_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            try
            {
                if (pVal.Row < 0)
                    return;

                int ret = Application.SBO_Application.MessageBox(
                    "Are you sure you want see the Version Details?",
                    1, "OK", "Cancel");

                if (ret != 1)
                    return;

                SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("GRDVERSN").Specific;
                SAPbouiCOM.DataTable oDT = oGrid.DataTable;
                int row = pVal.Row;

                string selDocEntry = oDT.GetValue("DocEntry", row).ToString().Trim();
                string selDocNum = oDT.GetValue("DocNum", row).ToString().Trim();
                string selVersion = oDT.GetValue("Version", row).ToString().Trim();
                string selLogInst = oDT.GetValue("MAX_LOGINST", row).ToString().Trim();

                string check = $@"
                        SELECT 
                            CASE 
                                WHEN MAX(""LogInst"") = '{selLogInst}' THEN 1 
                                ELSE 0
                            END AS ""IsEqual""
                        FROM ""@AFIL_DH_PRECOSTING""
                        WHERE ""DocEntry"" = '{selDocEntry}'";

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(check);

                if (!rs.EoF)
                {
                    int isEqual = Convert.ToInt32(rs.Fields.Item("IsEqual").Value);

                    if (isEqual == 1)
                    {
                        Application.SBO_Application.MessageBox("You are currently in this version.");
                        return;
                    }

                    Application.SBO_Application.StatusBar.SetText(
                        $"Opening Version {selVersion} in new form...",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                    OpenVersionInNewForm(selDocEntry, selDocNum, selVersion, selLogInst);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "GRDVERSN_DoubleClickAfter Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Long,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void OpenVersionInNewForm(string docEntry, string docNum, string version, string logInst)
        {
            SAPbouiCOM.Form newForm = null;

            try
            {
                // Open same form in new instance
                SamplePreCostVersionLog frm = new SamplePreCostVersionLog();   // <-- replace with your actual form class name
                frm.Show();

                newForm = (SAPbouiCOM.Form)frm.UIAPIRawForm;

                if (newForm == null)
                    throw new Exception("New form could not be opened.");

                newForm.Freeze(true);

                // Optional form title change
                newForm.Title = $"PreCosting - Version {version}";

                // Clear form first
                ClearForm(newForm);

                // Set pane if needed
                newForm.PaneLevel = 1;

                // Load selected version data into new form
                LoadHeaderVersion(newForm, docEntry, docNum, version, logInst);
                LoadComponentMatrix(newForm, docEntry, version, logInst);
                LoadOtherCostMatrix(newForm, docEntry, version, logInst);

                // Open in view mode
                newForm.Mode = SAPbouiCOM.BoFormMode.fm_VIEW_MODE;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "OpenVersionInNewForm Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Long,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                if (newForm != null)
                    newForm.Freeze(false);
            }
        }

        private void ClearForm(SAPbouiCOM.Form oForm)
        {
            // Clear EditTexts
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETSMPLCD").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETSMPLNM").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETBUYER").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETBYRNM").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETTCNAMT").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETOCTAMT").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETCMTAMT").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETFOBAMT").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETPRFAMT").Specific).Value = "";
            ((SAPbouiCOM.EditText)oForm.Items.Item("ETPRFPER").Specific).Value = "";

            // Clear Matrices
            SAPbouiCOM.Matrix mtxComp = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;
            SAPbouiCOM.Matrix mtxOth = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;
            SAPbouiCOM.DataTable oDT = oForm.DataSources.DataTables.Item("DT_VERSN");
            mtxComp.Clear();
            mtxOth.Clear();
            oDT.Clear();
        }
        private void LoadHeaderVersion(SAPbouiCOM.Form oForm, string docEntry, string docNum, string version, string log)
        {
            string sql = $@"
                            SELECT 
                                T0.""DocEntry"",
                                T0.""DocNum"",
                                T0.""Series"",
                                T1.""SeriesName"",
                                T0.""U_VERSION"",
                                T0.""U_SMPLCODE"",
                                T0.""U_SMPLDESC"",
                                T0.""U_CARDCODE"",
                                T0.""U_CARDNAME"",
                                T0.""U_CURRENCY"",
                                T0.""U_TOTCONAMT"",
                                T0.""U_DOCDATE"",
                                T0.""U_PROFITPC"",
                                T0.""U_PROFITAM"",
                                T0.""U_FOBAMUNT"",
                                T0.""U_TOTCAMNT"",
                                T0.""U_TOTOAMNT""
    
                            FROM ""@AFIL_DH_PRECOSTING"" T0
                            LEFT JOIN ""NNM1"" T1 ON T0.""Series"" = T1.""Series""
                            WHERE T0.""DocEntry"" = '{docEntry}'
                              AND T0.""DocNum"" = '{docNum}'
                              AND T0.""U_VERSION"" = '{version}'
                              AND T0.""LogInst"" = '{log}'";

            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs.DoQuery(sql);

            if (!rs.EoF)
            {
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value = rs.Fields.Item("DocEntry").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value = rs.Fields.Item("DocNum").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSERIES").Specific).Value = rs.Fields.Item("SeriesName").Value.ToString();

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value = rs.Fields.Item("U_VERSION").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSMPLCD").Specific).Value = rs.Fields.Item("U_SMPLCODE").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSMPLNM").Specific).Value = rs.Fields.Item("U_SMPLDESC").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETBUYER").Specific).Value = rs.Fields.Item("U_CARDCODE").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETBYRNM").Specific).Value = rs.Fields.Item("U_CARDNAME").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCURR").Specific).Value = rs.Fields.Item("U_CURRENCY").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETTCNAMT").Specific).Value = rs.Fields.Item("U_TOTCONAMT").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETPRFPER").Specific).Value = rs.Fields.Item("U_PROFITPC").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETPRFAMT").Specific).Value = rs.Fields.Item("U_PROFITAM").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETFOBAMT").Specific).Value = rs.Fields.Item("U_FOBAMUNT").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCMTAMT").Specific).Value = rs.Fields.Item("U_TOTCAMNT").Value.ToString();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETOCTAMT").Specific).Value = rs.Fields.Item("U_TOTOAMNT").Value.ToString();

                DateTime docDate = Convert.ToDateTime(rs.Fields.Item("U_DOCDATE").Value);
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = docDate.ToString("yyyyMMdd");
            }
        }
        private void LoadComponentMatrix(SAPbouiCOM.Form oForm, string docEntry, string version, string log)
        {
            SAPbouiCOM.Matrix mtx =
                (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;

            // Clear matrix
            mtx.Clear();

            string sql = $@"
                            SELECT
                                ""LineId"",
                                ""U_ROUTSTAG"",
                                ""U_ROUTSTAGN"",
                                ""U_COMPSTAG"",
                                ""U_COMPSTAGN"",
                                ""U_UOM"",
                                ""U_QTY"",
                                ""U_CONAMT"",
                                ""U_VERSION""
                            FROM ""@AFIL_DR_PRECOSTCOMP""
                            WHERE ""DocEntry""='{docEntry}'
                              AND ""U_VERSION""='{version}'
                              AND ""LogInst""='{log}'";

            SAPbobsCOM.Recordset rs =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            rs.DoQuery(sql);

            int row = 1;

            while (!rs.EoF)
            {
                mtx.AddRow();

                ((SAPbouiCOM.EditText)mtx.Columns.Item("#").Cells.Item(row).Specific).Value = rs.Fields.Item("LineId").Value.ToString();
                SAPbouiCOM.ComboBox cb = (SAPbouiCOM.ComboBox)mtx.Columns.Item("CLRSTGCD").Cells.Item(row).Specific;

                string val = rs.Fields.Item("U_ROUTSTAG").Value.ToString().Trim();

                if (!string.IsNullOrEmpty(val))
                {
                    cb.Select(val, SAPbouiCOM.BoSearchKey.psk_ByValue);
                }

                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLRSTGDS").Cells.Item(row).Specific).Value = rs.Fields.Item("U_ROUTSTAGN").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLCSTGCD").Cells.Item(row).Specific).Value = rs.Fields.Item("U_COMPSTAG").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLCSTGNM").Cells.Item(row).Specific).Value = rs.Fields.Item("U_COMPSTAGN").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLUOM").Cells.Item(row).Specific).Value = rs.Fields.Item("U_UOM").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLQTY").Cells.Item(row).Specific).Value = rs.Fields.Item("U_QTY").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLAMT").Cells.Item(row).Specific).Value = rs.Fields.Item("U_CONAMT").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLVERSN").Cells.Item(row).Specific).Value = rs.Fields.Item("U_VERSION").Value.ToString();

                row++;
                rs.MoveNext();
            }
            mtx.AutoResizeColumns();
        }


        private void LoadOtherCostMatrix(SAPbouiCOM.Form oForm, string docEntry, string version, string log)
        {
            SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;
            mtx.Clear();

            string sql = $@"
                            SELECT 
                                    ""LineId"",
                                    ""U_ALCCODE"",
                                    ""U_ALCNAME"",
                                    ""U_OHCONAMT"",
                                    ""U_VERSION""
                            FROM ""@AFIL_DR_PRECOSTOTHR"" 
                            WHERE ""DocEntry""='{docEntry}' 
                                AND ""U_VERSION""='{version}'
                                AND ""LogInst""='{log}'";

            SAPbobsCOM.Recordset rs =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            rs.DoQuery(sql);

            int row = 1;

            while (!rs.EoF)
            {
                mtx.AddRow();

                ((SAPbouiCOM.EditText)mtx.Columns.Item("#").Cells.Item(row).Specific).Value = rs.Fields.Item("LineId").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLCSTHCD").Cells.Item(row).Specific).Value = rs.Fields.Item("U_ALCCODE").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLCSTHNM").Cells.Item(row).Specific).Value = rs.Fields.Item("U_ALCNAME").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLAMT").Cells.Item(row).Specific).Value = rs.Fields.Item("U_OHCONAMT").Value.ToString();
                ((SAPbouiCOM.EditText)mtx.Columns.Item("CLVERSN").Cells.Item(row).Specific).Value = rs.Fields.Item("U_VERSION").Value.ToString();
                row++;
                rs.MoveNext();
            }
            mtx.AutoResizeColumns();
        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            // Series Initialization
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");
                Global.GFunc.SetItemsEnabled(oForm, false, "ETSMPLNM", "ETBUYER", "ETBYRNM", "ETDOCNUM", "ETVERSON");

                string today = DateTime.Now.ToString("yyyyMMdd");
                SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING");
                oDBH.SetValue("U_DOCDATE", 0, today);

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                Global.GFunc.UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_PRECOSTING");
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value = "1"; //Default version 
            }
            else if(oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
            {
                Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXCMPNT", "@FIL_DR_PRECOSTCOMP", "U_ROUTSTAG");
            }
                  
        }

        private void CBNO_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            Global.GFunc.UpdateDocNumberBySeries(oForm, "FIL_D_PRECOSTING");

        }

      

        private void Form_DataUpdateAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            LoadVersionGrid(oForm);
        }

        private void ETDOCDAT_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    return;

                string docDate = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value.Trim();
                if (string.IsNullOrWhiteSpace(docDate))
                    return;

                SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING");
                Global.GFunc.UpdateSeriesAndDocNumByDate(oForm, oDBH, docDate, "FIL_D_PRECOSTING");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Doc Date Series Error: " + ex.Message);
            }

        }

        //private void BTNVRNUP_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

        //    try
        //    {
        //        //Confirmation
        //        int ret = Application.SBO_Application.MessageBox(
        //            "Are you sure you want to increase the version?",
        //            1, "OK", "Cancel");

        //        if (ret != 1)
        //            return;

        //        //Read values from edit texts
        //        string docEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value.Trim();
        //        string docNum = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value.Trim();
        //        string version = ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value.Trim();

        //        if (string.IsNullOrWhiteSpace(docEntry) || string.IsNullOrWhiteSpace(docNum) || string.IsNullOrWhiteSpace(version))
        //        {
        //            Application.SBO_Application.StatusBar.SetText(
        //                "DocEntry, DocNum, and Version are required.",
        //                SAPbouiCOM.BoMessageTime.bmt_Short,
        //                SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
        //            return;
        //        }

        //        //Check if current version exists in DB
        //        string sql = $@"
        //                        Select 1 from ""@FIL_DH_PRECOSTING"" 
        //                            where ""DocEntry"" = '{docEntry}'
        //                            and ""DocNum""   = '{docNum}'
        //                            and ""U_VERSION""= '{version}'";

        //        SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        //        rs.DoQuery(sql);

        //        //If exists
        //        if (rs.RecordCount > 0)
        //        {
        //            if (!int.TryParse(version, out int v))
        //            {
        //                Application.SBO_Application.StatusBar.SetText(
        //                    "Version is not numeric, cannot increment.",
        //                    SAPbouiCOM.BoMessageTime.bmt_Short,
        //                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //                return;
        //            }

        //            v++;

        //            //SAPbouiCOM.DBDataSource dsH = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING");
        //            //dsH.SetValue("U_VERSION", 0, v.ToString());


        //            ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value = v.ToString();
        //            // Matrix Other Cost
        //            SAPbouiCOM.Matrix mtxOtherCost = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;
        //            UpdateMatrixVersion(mtxOtherCost, "CLVERSN", v);

        //            // Matrix Component
        //            SAPbouiCOM.Matrix mtxComponent = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;
        //            UpdateMatrixVersion(mtxComponent, "CLVERSN", v);

        //            // =================================================


        //            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
        //            {
        //                oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
        //            }

        //            Application.SBO_Application.StatusBar.SetText(
        //                "Version increased successfully.",
        //                SAPbouiCOM.BoMessageTime.bmt_Short,
        //                SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        //        }
        //        else
        //        {
        //            //Otherwise message
        //            Application.SBO_Application.MessageBox(
        //                "You have to update/save this version to DB first, then you can increase the version.",
        //                1, "OK");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            "BTNVRNUP_PressedAfter Error: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

        private void BTNVRNUP_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            SAPbobsCOM.Recordset rs = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                int confirmation = Application.SBO_Application.MessageBox("Are you sure you want to increase the version?", 1, "OK", "Cancel");

                if (confirmation != 1)
                    return;

                string docEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value.Trim();
                string docNum = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value.Trim();
                string version = ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(docEntry) || string.IsNullOrWhiteSpace(docNum) || string.IsNullOrWhiteSpace(version))
                {
                    Global.GFunc.ShowError("DocEntry, DocNum and Version are required.");
                    return;
                }

                if (!int.TryParse(docEntry, out int parsedDocEntry))
                {
                    Global.GFunc.ShowError("DocEntry is invalid.");
                    return;
                }

                if (!int.TryParse(docNum, out int parsedDocNum))
                {
                    Global.GFunc.ShowError("DocNum is invalid.");
                    return;
                }

                if (!int.TryParse(version, out int currentVersion))
                {
                    Global.GFunc.ShowError("Version is not numeric and cannot be increased.");
                    return;
                }

                string safeVersion = version.Replace("'", "''");

                string sql = $@"
                                SELECT COUNT(*) AS ""CNT""
                                FROM ""@FIL_DH_PRECOSTING""
                                WHERE ""DocEntry"" = {parsedDocEntry}
                                  AND ""DocNum"" = {parsedDocNum}
                                  AND TRIM(IFNULL(""U_VERSION"", '')) = '{safeVersion}'";

                rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(sql);

                int recordCount = Convert.ToInt32(rs.Fields.Item("CNT").Value);

                if (recordCount <= 0)
                {
                    Global.GFunc.ShowError("The current version was not found in the database. Save or update it first, then increase the version.");
                    return;
                }

                int newVersion = currentVersion + 1;

                oForm.Freeze(true);

                try
                {
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value = newVersion.ToString();

                    SAPbouiCOM.Matrix otherCostMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;
                    SAPbouiCOM.Matrix componentMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;

                    UpdateMatrixVersion(otherCostMatrix, "CLVERSN", newVersion);
                    UpdateMatrixVersion(componentMatrix, "CLVERSN", newVersion);

                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                        oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                }
                finally
                {
                    oForm.Freeze(false);
                }

                Global.GFunc.ShowSuccess("Version increased from " + currentVersion + " to " + newVersion + " successfully.");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("BTNVRNUP_PressedAfter Error: " + ex.Message);
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

        private void ETPRFPER_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (_isProfitCalculationRunning)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE &&
                    oForm.Mode != SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                    return;

                _lastProfitInput = "PERCENT";
                CalculateProfitFields(oForm, "PERCENT");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Profit Percentage Calculation Error: " + ex.Message);
            }
        }

        private void ETPRFAMT_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (_isProfitCalculationRunning)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE &&
                    oForm.Mode != SAPbouiCOM.BoFormMode.fm_UPDATE_MODE )
                    return;

                _lastProfitInput = "AMOUNT";
                CalculateProfitFields(oForm, "AMOUNT");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Profit Amount Calculation Error: " + ex.Message);
            }
        }

        private void ETFOBAMT_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (_isProfitCalculationRunning)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE &&
                    oForm.Mode != SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                    return;

                _lastProfitInput = "FOB";
                CalculateProfitFields(oForm, "FOB");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("FOB Amount Calculation Error: " + ex.Message);
            }
        }

        private void UpdateMatrixVersion(SAPbouiCOM.Matrix oMatrix, string colId, int version)
        {
            if (oMatrix == null || oMatrix.RowCount == 0)
                return;

            for (int i = 1; i <= oMatrix.RowCount; i++)
            {
                SAPbouiCOM.EditText et =
                    (SAPbouiCOM.EditText)oMatrix.Columns.Item(colId).Cells.Item(i).Specific;

                et.Value = version.ToString();
            }

            // Flush if matrix is bound
            oMatrix.FlushToDataSource();
        }



        private void BTNLCSTH_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            try
            {
                // Confirmation
                int ret = Application.SBO_Application.MessageBox(
                    "Are you sure you want to refresh Other Cost Head list?",
                    1, "OK", "Cancel");

                if (ret != 1) // 1 = OK
                    return;

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;

                //Backup existing user inputs 
                Dictionary<string, string> amtByCode = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    string code = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCSTHCD").Cells.Item(i).Specific).Value.Trim();
                    if (string.IsNullOrWhiteSpace(code)) continue;

                    string amt = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLAMT").Cells.Item(i).Specific).Value.Trim();

                    //duplicate filter
                    if (!amtByCode.ContainsKey(code))
                        amtByCode.Add(code, amt);
                    else if (!string.IsNullOrWhiteSpace(amt))
                        amtByCode[code] = amt;
                }

                string sql = @"Select ""AlcCode"",""AlcName"" from ""OALC""";
                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(sql);

                if (rs.RecordCount == 0)
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "No active cost head found.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                    return;
                }

                oForm.Freeze(true);

                // 4) Clear matrix rows (we will rebuild from query) BUT restore CLAMT from backup
                // Safer clear:
                while (oMatrix.RowCount > 0)
                    oMatrix.DeleteRow(1);

                int row = 1;
                rs.MoveFirst();
                while (!rs.EoF)
                {
                    oMatrix.AddRow();

                    string code = Convert.ToString(rs.Fields.Item("AlcCode").Value).Trim();
                    string name = Convert.ToString(rs.Fields.Item("AlcName").Value).Trim();

                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("#").Cells.Item(row).Specific).Value = row.ToString();
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCSTHCD").Cells.Item(row).Specific).Value = code;
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCSTHNM").Cells.Item(row).Specific).Value = name;

                    // 5) Restore amount if user already entered earlier
                    if (amtByCode.TryGetValue(code, out string oldAmt) && !string.IsNullOrWhiteSpace(oldAmt))
                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLAMT").Cells.Item(row).Specific).Value = oldAmt;

                    row++;
                    rs.MoveNext();
                }

                oMatrix.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "BTNLCSTH_PressedAfter Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                try { oForm.Freeze(false); } catch { }
            }
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

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string sampleCode = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING").GetValue("U_SMPLCODE", 0);
            string buyer = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING").GetValue("U_CARDCODE", 0);
            string curr = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING").GetValue("U_CURRENCY", 0);

            if (sampleCode == "")
            {
                Global.GFunc.ShowError("Enter Sample Code");
                oForm.ActiveItem = "ETSMPLCD";
                return BubbleEvent = false;
            }
            else if (buyer == "")
            {
                Global.GFunc.ShowError("Enter Buyer");
                oForm.ActiveItem = "ETBUYER";
                return BubbleEvent = false;
            }
            else if (curr == "")
            {
                Global.GFunc.ShowError("Enter Currency");
                oForm.ActiveItem = "ETCURR";
                return BubbleEvent = false;
            }

            if (!ValidateCostTotals(oForm))
                return BubbleEvent = false;

            if (!ValidateProfitFields(oForm)) 
                return BubbleEvent = false;

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                //unique combination validation (Sample + Buyer)
                if (IsDuplicateSampleBuyer(oForm, sampleCode, buyer))
                {
                    Global.GFunc.ShowError($"Duplicate not allowed: Sample [{sampleCode}] + Buyer [{buyer}] already exists.");
                    oForm.ActiveItem = "ETBUYER";
                    return BubbleEvent = false;
                }
            }
           

            PreventEmptyLastRow(oForm, "@FIL_DR_PRECOSTCOMP", MTXCMPNT, "U_ROUTSTAG");
            ValidateRouteCompStage(oForm, ref BubbleEvent);
            if (!BubbleEvent)
            {
                Global.GFunc.ShowError("Route Stage or Component Stage Missing");
                //AddLineIfLastRowHasValue(oForm, "MTXCMPNT", "@FIL_DR_PRECOSTCOMP", "U_ROUTSTAG");
                Global.GFunc.EnsureLine(oForm, "MTXCMPNT", "@FIL_DR_PRECOSTCOMP");
                return BubbleEvent;
            }

            return BubbleEvent;
        }

        private bool IsDuplicateSampleBuyer(SAPbouiCOM.Form oForm, string sampleCode, string buyerCode)
        {
            sampleCode = (sampleCode ?? "").Replace("\0", "").Trim();
            buyerCode = (buyerCode ?? "").Replace("\0", "").Trim();

            if (string.IsNullOrWhiteSpace(sampleCode) || string.IsNullOrWhiteSpace(buyerCode))
                return false;

            // Read current DocEntry from your edittext ETDOCTRY
            string curDocEntry = "";
            try
            {
                curDocEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value;
                curDocEntry = (curDocEntry ?? "").Replace("\0", "").Trim();
            }
            catch { curDocEntry = ""; }

            string safeSample = sampleCode.Replace("'", "''");
            string safeBuyer = buyerCode.Replace("'", "''");

            string q;

            // If ADD MODE (no docentry yet) -> block if any exists
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || string.IsNullOrEmpty(curDocEntry))
            {
                q = $@"
                    SELECT COUNT(*) AS ""CNT""
                    FROM ""@FIL_DH_PRECOSTING""
                    WHERE ""U_SMPLCODE"" = '{safeSample}'
                      AND ""U_CARDCODE"" = '{safeBuyer}'";
            }
            else
            {
                // UPDATE MODE -> exclude this DocEntry
                q = $@"
                        SELECT COUNT(*) AS ""CNT""
                        FROM ""@FIL_DH_PRECOSTING""
                        WHERE ""U_SMPLCODE"" = '{safeSample}'
                          AND ""U_CARDCODE"" = '{safeBuyer}'
                          AND ""DocEntry"" <> {curDocEntry}";
            }

            SAPbobsCOM.Recordset rs =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            rs.DoQuery(q);

            int cnt = 0;
            if (!rs.EoF)
                int.TryParse(rs.Fields.Item("CNT").Value.ToString(), out cnt);

            return cnt > 0;
        }

        private bool ValidateRouteCompStage(SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;

                oMatrix.FlushToDataSource();
                SAPbouiCOM.DBDataSource ds = oForm.DataSources.DBDataSources.Item("@FIL_DR_PRECOSTCOMP");


                if (ds.Size == 0 ||
                    (ds.Size == 1 &&
                     string.IsNullOrWhiteSpace((ds.GetValue("U_ROUTSTAG", 0) ?? "").Trim()) &&
                     string.IsNullOrWhiteSpace((ds.GetValue("U_COMPSTAG", 0) ?? "").Trim())))
                {
                    Global.GFunc.ShowError("Component matrix is empty. Please add at least one row.");
                    oForm.Items.Item("MTXCMPNT").Click();
                    BubbleEvent = false;
                    return BubbleEvent;
                }

                for (int i = 0; i < ds.Size; i++)
                {
                    string routeStag = (ds.GetValue("U_ROUTSTAG", i) ?? "").Trim();
                    string compStag = (ds.GetValue("U_COMPSTAG", i) ?? "").Trim();

                    if (string.IsNullOrWhiteSpace(routeStag))
                    {
                        Global.GFunc.ShowError($"Route Stage is mandatory. (Row: {i + 1})");
                        oForm.Items.Item("MTXCMPNT").Click();
                        oMatrix.Columns.Item("U_ROUTSTAG").Cells.Item(i + 1).Click();
                        BubbleEvent = false;
                        return BubbleEvent;
                    }

                    if (string.IsNullOrWhiteSpace(compStag))
                    {
                        Global.GFunc.ShowError($"Component Stage is mandatory. (Row: {i + 1})");
                        oForm.Items.Item("MTXCMPNT").Click();
                        oMatrix.Columns.Item("U_COMPSTAG").Cells.Item(i + 1).Click();
                        BubbleEvent = false;
                        return BubbleEvent;
                    }
                }

                return BubbleEvent;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "ValidateRouteCompStage Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                BubbleEvent = false;
                return BubbleEvent;
            }
        }



        private void PreventEmptyLastRow(SAPbouiCOM.Form oForm, string dbDatasourceUID, SAPbouiCOM.Matrix matrix, string columnName)
        {
            SAPbouiCOM.DBDataSource oDB = oForm.DataSources.DBDataSources.Item(dbDatasourceUID);
            int rowCount = matrix.VisualRowCount;
            if (rowCount > 0)
            {
                string lastValue = oDB.GetValue(columnName, rowCount - 1).Trim();
                if (string.IsNullOrEmpty(lastValue) || lastValue.Equals("0.0"))
                {
                    matrix.DeleteRow(rowCount);
                    oDB.RemoveRecord(rowCount - 1);
                }
            }
        }

        private void FOLOTCST_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            try
            {
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    return;

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;
                bool isEmpty = (oMatrix.RowCount == 0);
                if (!isEmpty)
                {
                    var firstCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCSTHCD").Cells.Item(1).Specific).Value;
                    isEmpty = string.IsNullOrWhiteSpace(firstCode);
                }
                if (!isEmpty)
                    return;
                string version = ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value.Trim();
                string sql = @"Select ""AlcCode"",""AlcName"" from ""OALC""";
                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(sql);

                if (rs.RecordCount == 0)
                    return;

                oForm.Freeze(true);
                int row = 1;
                rs.MoveFirst();
                while (!rs.EoF)
                {
                    if (row > oMatrix.RowCount)
                        oMatrix.AddRow();

                    string code = Convert.ToString(rs.Fields.Item("AlcCode").Value).Trim();
                    string name = Convert.ToString(rs.Fields.Item("AlcName").Value).Trim();
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("#").Cells.Item(row).Specific).Value = row.ToString();
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCSTHCD").Cells.Item(row).Specific).Value = code;
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCSTHNM").Cells.Item(row).Specific).Value = name;
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVERSN").Cells.Item(row).Specific).Value = version;

                    row++;
                    rs.MoveNext();
                }
                oForm.Freeze(false);
                oMatrix.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                oForm.Freeze(false);
                Application.SBO_Application.StatusBar.SetText(
                    "FOLOTCST_ClickAfter Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }



        }


        //private void MTXOTCST_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    try
        //    {
        //        if (pVal.ColUID != "CLAMT") return;
        //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        UpdateTotalAmountBothMatrices(oForm);
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            "Error on Amount Calculation: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

        //
        //private bool _isAmtQtyClearRunning = false;
        //private void MTXCMPNT_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    if (_isAmtQtyClearRunning) return;

        //    try
        //    {
        //        if (pVal.Row <= 0) return;

        //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;

        //        string routeStage = ((SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLRSTGCD")
        //                                .Cells.Item(pVal.Row).Specific).Value.Trim();

        //        SAPbouiCOM.EditText oAmt =
        //            (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLAMT").Cells.Item(pVal.Row).Specific;

        //        SAPbouiCOM.EditText oQty =
        //            (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLQTY").Cells.Item(pVal.Row).Specific;

        //        // Quantity Lost Focus
        //        if (pVal.ColUID == "CLQTY")
        //        {
        //            string qtyValue = oQty.Value.Trim();

        //            if (string.IsNullOrWhiteSpace(routeStage) &&
        //                !string.IsNullOrWhiteSpace(qtyValue) &&
        //                qtyValue != "0" && qtyValue != "0.00")
        //            {
        //                _isAmtQtyClearRunning = true;

        //                oQty.Value = "";
        //                oAmt.Value = "";

        //                UpdateTotalAmountBothMatrices(oForm);
        //            }

        //            return;
        //        }

        //        // Amount Lost Focus
        //        if (pVal.ColUID == "CLAMT")
        //        {
        //            string amtValue = oAmt.Value.Trim();

        //            if (string.IsNullOrWhiteSpace(routeStage) &&
        //                !string.IsNullOrWhiteSpace(amtValue) &&
        //                amtValue != "0" && amtValue != "0.00")
        //            {
        //                _isAmtQtyClearRunning = true;

        //                oAmt.Value = "";
        //                oQty.Value = "";

        //                UpdateTotalAmountBothMatrices(oForm);
        //            }

        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //    finally
        //    {
        //        _isAmtQtyClearRunning = false;
        //    }
        //}


        //private void UpdateTotalAmountBothMatrices(SAPbouiCOM.Form oForm)
        //{
        //    double total = 0;

        //    total += GetMatrixColumnSum(oForm, "MTXCMPNT", "CLAMT");
        //    total += GetMatrixColumnSum(oForm, "MTXOTCST", "CLAMT");

        //    ((SAPbouiCOM.EditText)oForm.Items.Item("ETTCNAMT").Specific).Value =
        //        total.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
        //}


        private void MTXOTCST_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                if (pVal.Row <= 0 || (pVal.ColUID != "CLQTY" && pVal.ColUID != "CLAMT"))
                    return;

                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE && oForm.Mode != SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                    return;

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;
                SAPbouiCOM.EditText oEditText = (SAPbouiCOM.EditText)oMatrix.Columns.Item(pVal.ColUID).Cells.Item(pVal.Row).Specific;

                double value = GetEditTextDouble(oEditText);

                if (value < 0)
                {
                    oEditText.Value = "0.00";

                    Global.GFunc.ShowError(pVal.ColUID == "CLQTY" ? "Other Cost Quantity cannot be negative." : "Other Cost Amount cannot be negative.");
                }

                if (pVal.ColUID == "CLAMT")
                {
                    oMatrix.FlushToDataSource();
                    UpdateAllCostTotals(oForm);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Other Cost Validation Error: " + ex.Message);
            }
        }
        //private void MTXOTCST_LostFocusAfter(object sboObject,SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    try
        //    {
        //        if (pVal.Row <= 0)
        //            return;

        //        if (pVal.ColUID != "CLAMT")
        //            return;

        //        SAPbouiCOM.Form oForm =
        //            Application.SBO_Application.Forms.Item(pVal.FormUID);

        //        UpdateAllCostTotals(oForm);
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError("Other Cost Amount Calculation Error: " + ex);
        //    }
        //}

        private bool _isAmtQtyClearRunning = false;

        private void MTXCMPNT_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (_isAmtQtyClearRunning)
                return;

            SAPbouiCOM.Form oForm = null;

            try
            {
                if (pVal.Row <= 0 || (pVal.ColUID != "CLQTY" && pVal.ColUID != "CLAMT"))
                    return;

                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE && oForm.Mode != SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                    return;

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;
                string routeStage = ((SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLRSTGCD").Cells.Item(pVal.Row).Specific).Value.Trim();
                SAPbouiCOM.EditText oQty = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLQTY").Cells.Item(pVal.Row).Specific;
                SAPbouiCOM.EditText oAmt = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLAMT").Cells.Item(pVal.Row).Specific;

                SAPbouiCOM.EditText currentEditText = pVal.ColUID == "CLQTY" ? oQty : oAmt;
                double currentValue = GetEditTextDouble(currentEditText);

                if (currentValue < 0)
                {
                    _isAmtQtyClearRunning = true;
                    currentEditText.Value = "0.00";

                    Global.GFunc.ShowError(pVal.ColUID == "CLQTY" ? "Quantity cannot be negative." : "Component Amount cannot be negative.");

                    if (pVal.ColUID == "CLAMT")
                        UpdateAllCostTotals(oForm);

                    return;
                }

                if (pVal.ColUID == "CLQTY")
                {
                    if (string.IsNullOrWhiteSpace(routeStage) && HasNonZeroValue(oQty.Value))
                    {
                        _isAmtQtyClearRunning = true;
                        oQty.Value = "";
                        oAmt.Value = "";
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(routeStage) && HasNonZeroValue(oAmt.Value))
                    {
                        _isAmtQtyClearRunning = true;
                        oAmt.Value = "";
                        oQty.Value = "";
                    }

                    UpdateAllCostTotals(oForm);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Component Amount Calculation Error: " + ex.Message);
            }
            finally
            {
                _isAmtQtyClearRunning = false;
            }
        }




        private void UpdateAllCostTotals(SAPbouiCOM.Form oForm)
        {
            bool isFrozen = false;

            try
            {
                oForm.Freeze(true);
                isFrozen = true;

                double componentTotal = GetMatrixColumnSum(oForm, "MTXCMPNT", "CLAMT");
                double otherCostTotal = GetMatrixColumnSum(oForm, "MTXOTCST", "CLAMT");
                double grandTotal = componentTotal + otherCostTotal;

                string componentValue = componentTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                string otherCostValue = otherCostTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                string grandTotalValue = grandTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                SAPbouiCOM.DBDataSource headerDB = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING");

                headerDB.SetValue("U_TOTCAMNT", 0, componentValue);
                headerDB.SetValue("U_TOTOAMNT", 0, otherCostValue);
                headerDB.SetValue("U_TOTCONAMT", 0, grandTotalValue);

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCMTAMT").Specific).Value = componentValue;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETOCTAMT").Specific).Value = otherCostValue;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETTCNAMT").Specific).Value = grandTotalValue;

                CalculateProfitFields(oForm, _lastProfitInput, false);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Cost Total Calculation Error: " + ex.Message);
            }
            finally
            {
                if (isFrozen)
                {
                    try
                    {
                        oForm.Freeze(false);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private bool HasNonZeroValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            value = value.Trim().Replace(",", "");

            if (double.TryParse(value,System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,
                out double amount))
            {
                return amount != 0;
            }

            return double.TryParse(value, out amount) && amount != 0;
        }

        //private double GetMatrixColumnSum(SAPbouiCOM.Form oForm, string matrixId, string colId)
        //{
        //    double sum = 0;

        //    if (!oForm.Items.Item(matrixId).Visible) { /* optional */ }

        //    SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixId).Specific;

        //    for (int i = 1; i <= mtx.RowCount; i++)
        //    {
        //        string valStr = ((SAPbouiCOM.EditText)mtx.Columns.Item(colId).Cells.Item(i).Specific).Value;
        //        if (string.IsNullOrWhiteSpace(valStr)) continue;

        //        valStr = valStr.Trim().Replace(",", "");

        //        if (double.TryParse(valStr, System.Globalization.NumberStyles.Any,
        //                            System.Globalization.CultureInfo.InvariantCulture, out double amt))
        //            sum += amt;
        //        else if (double.TryParse(valStr, out amt))
        //            sum += amt;
        //    }

        //    return sum;
        //}

        private double GetMatrixColumnSum(SAPbouiCOM.Form oForm, string matrixId, string colId)
        {
            double sum = 0;
            SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixId).Specific;

            for (int i = 1; i <= mtx.RowCount; i++)
            {
                // Special rule only for MTXCMPNT:
                // if route stage (CLRSTGCD) is blank, skip this row
                if (matrixId == "MTXCMPNT")
                {
                    SAPbouiCOM.ComboBox oCombo = (SAPbouiCOM.ComboBox)mtx.Columns.Item("CLRSTGCD").Cells.Item(i).Specific;
                    string routeStage = oCombo.Value.Trim();

                    if (string.IsNullOrWhiteSpace(routeStage))
                        continue;
                }

                string valStr = ((SAPbouiCOM.EditText)mtx.Columns.Item(colId).Cells.Item(i).Specific).Value;
                if (string.IsNullOrWhiteSpace(valStr))
                    continue;

                valStr = valStr.Trim().Replace(",", "");

                if (double.TryParse(valStr,
                                    System.Globalization.NumberStyles.Any,
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    out double amt))
                {
                    sum += amt;
                }
                else if (double.TryParse(valStr, out amt))
                {
                    sum += amt;
                }
            }

            return sum;
        }

        private void MTXCMPNT_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_CMPN")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_ACTIVE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering Size CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }


        }

        private void MTXCMPNT_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;
            SAPbouiCOM.DBDataSource DBDataSourceLine = oForm.DataSources.DBDataSources.Item("@FIL_DR_PRECOSTCOMP");
            int row = pVal.Row;

            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0) return;

            string Code = dt.GetValue("Code", 0).ToString().Trim();
            string Name = dt.GetValue("Name", 0).ToString().Trim();
            string upmApl = dt.GetValue("U_UOMAPPLY", 0).ToString().Trim();

            if (upmApl.Equals("Y"))
            {
                string uom = dt.GetValue("U_UOM", 0).ToString().Trim();
                oMatrix.SetCellWithoutValidation(row, "CLUOM", uom);
            }

            oMatrix.SetCellWithoutValidation(row, "CLCSTGCD", Code);
            oMatrix.SetCellWithoutValidation(row, "CLCSTGNM", Name);

            Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXCMPNT", "@FIL_DR_PRECOSTCOMP", "U_COMPSTAG");

        }

        private void ETSMPLCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0) return;

            try
            {
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                {
                    string Code = dt.GetValue("U_SMPLCODE", 0).ToString().Trim();
                    string Name = dt.GetValue("U_SMPLDESC", 0).ToString().Trim();
                    string buyCode = dt.GetValue("U_CARDCODE", 0).ToString().Trim();
                    string buyName = dt.GetValue("U_CARDNAME", 0).ToString().Trim();
                    string route = dt.GetValue("U_ROUTSTAG", 0).ToString().Trim();

                    ETSMPLCD.Value = Code;
                    ETSMPLNM.Value = Name;
                    ETBUYER.Value = buyCode;
                    ETBYRNM.Value = buyName;

                    Global.GFunc.EnsureLine(oForm, "MTXCMPNT", "@FIL_DR_PRECOSTCOMP");
                    Global.GFunc.EnsureLine(oForm, "MTXOTCST", "@FIL_DR_PRECOSTOTHR");
                    LoadRouteWiseComboToMatrixColumn(oForm, "MTXCMPNT", "CLRSTGCD", route);

                    SAPbouiCOM.Item ETCUSCOD = oForm.Items.Item("ETBUYER");
                    ETCUSCOD.Enabled = true;
                    SAPbouiCOM.EditText ECUSCOD = (SAPbouiCOM.EditText)ETCUSCOD.Specific;
                    ECUSCOD.ChooseFromListUID = "CFL_OCRD";
                    ECUSCOD.ChooseFromListAlias = "CardCode";
                }

            }
            catch (Exception ex)
            {
               // Application.SBO_Application.MessageBox("Error: " + ex.Message);
            }
        }

        private void MTXCMPNT_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;
                string version = ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value.Trim();
                if (pVal.Row <= 0) return;

                if (pVal.ColUID == "CLRSTGCD")
                {
                    int row = pVal.Row;
                    SAPbouiCOM.ComboBox cb = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLRSTGCD").Cells.Item(row).Specific;
                    string desc = cb.Selected.Description.Trim();
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLRSTGDS").Cells.Item(row).Specific).Value = desc;
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVERSN").Cells.Item(row).Specific).Value = version;
                    oMatrix.FlushToDataSource();

                    Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXCMPNT", "@FIL_DR_PRECOSTCOMP", "U_ROUTSTAG");
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Error: " + ex.Message);
            }
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

        private void ETBUYER_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;


            string buyCode = dt.GetValue("CardCode", 0).ToString().Trim();
            string buyName = dt.GetValue("CardName", 0).ToString().Trim();

            SAPbouiCOM.EditText ETBCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETBUYER").Specific;
            ETBCD.Value = buyCode;
            SAPbouiCOM.EditText ETBNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETBYRNM").Specific;
            ETBNM.Value = buyName;

        }


        private void LoadRouteWiseComboToMatrixColumn(SAPbouiCOM.Form oForm, string matrixId, string comboColId, string routeCode)
        {
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixId).Specific;
            SAPbouiCOM.Column oCol = oMatrix.Columns.Item(comboColId);

            if (oCol.Type != SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX)
                throw new Exception($"Column {comboColId} is not a ComboBox column.");

            //Remove Prev Values
            while (oCol.ValidValues.Count > 0)
                oCol.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);


            string query = $@"Select Distinct ""U_STAGECODE"", ""U_STAGENAME""
                                from ""@FIL_MR_RSM1""
                                where ""Code"" = '{routeCode}'";

            SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs.DoQuery(query);
            oCol.ValidValues.Add("", "");

            while (!rs.EoF)
            {
                string v = rs.Fields.Item("U_STAGECODE").Value.ToString().Trim();
                string d = rs.Fields.Item("U_STAGENAME").Value.ToString().Trim();

                if (!ValidValueExists(oCol, v))
                    oCol.ValidValues.Add(v, d);

                rs.MoveNext();
            }

            System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);
        }

        private bool ValidValueExists(SAPbouiCOM.Column col, string value)
        {
            for (int i = 0; i < col.ValidValues.Count; i++)
            {
                if (col.ValidValues.Item(i).Value == value)
                    return true;
            }
            return false;
        }

        private void CalculateProfitFields(SAPbouiCOM.Form oForm, string changedField, bool useFreeze = true)
        {
            if (_isProfitCalculationRunning) return;

            try
            {
                _isProfitCalculationRunning = true;
                if (useFreeze) oForm.Freeze(true);

                SAPbouiCOM.EditText etTotalCost = (SAPbouiCOM.EditText)oForm.Items.Item("ETTCNAMT").Specific;
                SAPbouiCOM.EditText etProfitPercent = (SAPbouiCOM.EditText)oForm.Items.Item("ETPRFPER").Specific;
                SAPbouiCOM.EditText etProfitAmount = (SAPbouiCOM.EditText)oForm.Items.Item("ETPRFAMT").Specific;
                SAPbouiCOM.EditText etFobAmount = (SAPbouiCOM.EditText)oForm.Items.Item("ETFOBAMT").Specific;

                double totalCost = GetEditTextDouble(etTotalCost);
                double profitPercent = GetEditTextDouble(etProfitPercent);
                double profitAmount = GetEditTextDouble(etProfitAmount);
                double fobAmount = GetEditTextDouble(etFobAmount);

                _hasInvalidProfitValue = false;

                switch (changedField)
                {
                    case "PERCENT":
                        if (profitPercent < 0)
                        {
                            _hasInvalidProfitValue = true;
                            //Global.GFunc.ShowError("Profit Percentage cannot be negative.");
                            profitPercent = 0;
                        }
                        profitAmount = totalCost * profitPercent / 100;
                        fobAmount = totalCost + profitAmount;
                        break;

                    case "AMOUNT":
                        if (profitAmount < 0)
                        {
                            _hasInvalidProfitValue = true;
                            //Global.GFunc.ShowError("Profit Amount cannot be negative.");
                            profitAmount = 0;
                        }
                        profitPercent = totalCost == 0 ? 0 : (profitAmount / totalCost) * 100;
                        fobAmount = totalCost + profitAmount;
                        break;

                    case "FOB":
                        if (fobAmount < totalCost)
                        {
                            _hasInvalidProfitValue = true;
                            //Global.GFunc.ShowError("FOB Amount cannot be less than Total Cost.");
                            profitAmount = 0;
                            profitPercent = 0;
                        }
                        else
                        {
                            profitAmount = fobAmount - totalCost;
                            profitPercent = totalCost == 0 ? 0 : (profitAmount / totalCost) * 100;
                        }
                        break;
                }

                etProfitPercent.Value = profitPercent.ToString("0.####", System.Globalization.CultureInfo.InvariantCulture);
                etProfitAmount.Value = profitAmount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                if (!_hasInvalidProfitValue || changedField != "FOB") etFobAmount.Value = fobAmount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING");
                db.SetValue("U_PROFITPC", 0, etProfitPercent.Value);
                db.SetValue("U_PROFITAM", 0, etProfitAmount.Value);
                db.SetValue("U_FOBAMUNT", 0, etFobAmount.Value);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE) oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
            }
            catch (Exception ex)
            {
                _hasInvalidProfitValue = true;
                Global.GFunc.ShowError("Profit Calculation Error: " + ex.Message);
            }
            finally
            {
                if (useFreeze)
                {
                    try { oForm.Freeze(false); } catch { }
                }
                _isProfitCalculationRunning = false;
            }
        }


        private bool ValidateProfitFields(SAPbouiCOM.Form oForm)
        {
            try
            {
                double totalCost = GetEditTextDouble((SAPbouiCOM.EditText)oForm.Items.Item("ETTCNAMT").Specific);
                double profitPercent = GetEditTextDouble((SAPbouiCOM.EditText)oForm.Items.Item("ETPRFPER").Specific);
                double profitAmount = GetEditTextDouble((SAPbouiCOM.EditText)oForm.Items.Item("ETPRFAMT").Specific);
                double fobAmount = GetEditTextDouble((SAPbouiCOM.EditText)oForm.Items.Item("ETFOBAMT").Specific);

                if (_hasInvalidProfitValue)
                {
                    Global.GFunc.ShowError("Correct the invalid Profit or FOB value before saving.");
                    oForm.ActiveItem = _lastProfitInput == "PERCENT" ? "ETPRFPER" : _lastProfitInput == "AMOUNT" ? "ETPRFAMT" : "ETFOBAMT";
                    return false;
                }

                if (profitPercent < 0)
                {
                    Global.GFunc.ShowError("Profit Percentage cannot be negative.");
                    oForm.ActiveItem = "ETPRFPER";
                    return false;
                }

                if (profitAmount < 0)
                {
                    Global.GFunc.ShowError("Profit Amount cannot be negative.");
                    oForm.ActiveItem = "ETPRFAMT";
                    return false;
                }

                if (fobAmount < totalCost)
                {
                    Global.GFunc.ShowError("FOB Amount cannot be less than Total Cost.");
                    oForm.ActiveItem = "ETFOBAMT";
                    return false;
                }

                double expectedFob = totalCost + profitAmount;
                if (Math.Abs(fobAmount - expectedFob) > 0.01)
                {
                    Global.GFunc.ShowError("FOB Amount must equal Total Cost plus Profit Amount.");
                    oForm.ActiveItem = "ETFOBAMT";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Profit Validation Error: " + ex.Message);
                return false;
            }
        }


        private double GetEditTextDouble(SAPbouiCOM.EditText editText)
        {
            if (editText == null || string.IsNullOrWhiteSpace(editText.Value))
                return 0;

            string value = editText.Value.Trim().Replace(",", "");

            if (double.TryParse(value,System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,
                out double result))
            {
                return result;
            }

            if (double.TryParse(value, out result))
                return result;

            return 0;
        }

        private void LoadVersionGrid(SAPbouiCOM.Form oForm)
        {
            if (oForm == null)
                return;

            try
            {
                string docEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific).Value.Trim();
                string docNum = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific).Value.Trim();
                string versionValue = ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value.Trim();

                SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("GRDVERSN").Specific;
                SAPbouiCOM.DataTable oDT = oForm.DataSources.DataTables.Item("DT_VERSN");

                if (string.IsNullOrWhiteSpace(docEntry) || string.IsNullOrWhiteSpace(docNum))
                {
                    oDT.Clear();
                    return;
                }

                if (!int.TryParse(versionValue, out int version) || version <= 1)
                {
                    oDT.Clear();

                    Application.SBO_Application.StatusBar.SetText(
                        "Version must be greater than 1.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

                    return;
                }

                string safeDocEntry = docEntry.Replace("'", "''");
                string safeDocNum = docNum.Replace("'", "''");

                string sQuery = $@"
                                SELECT
                                    T.""DocEntry"",
                                    T.""DocNum"",
                                    T.""Creator"",
                                    T.""CreateDate"",
                                    T.""UpdateDate"",
                                    T.""U_VERSION"" AS ""Version"",
                                    T.""LogInst"" AS ""MAX_LOGINST""
                                FROM ""@AFIL_DH_PRECOSTING"" T
                                INNER JOIN
                                (
                                    SELECT
                                        ""DocEntry"",
                                        ""DocNum"",
                                        ""U_VERSION"",
                                        MAX(""LogInst"") AS ""MAX_LOGINST""
                                    FROM ""@AFIL_DH_PRECOSTING""
                                    WHERE ""DocEntry"" = '{safeDocEntry}'
                                      AND ""DocNum"" = '{safeDocNum}'
                                    GROUP BY
                                        ""DocEntry"",
                                        ""DocNum"",
                                        ""U_VERSION""
                                ) M
                                    ON T.""DocEntry"" = M.""DocEntry""
                                   AND T.""DocNum"" = M.""DocNum""
                                   AND T.""U_VERSION"" = M.""U_VERSION""
                                   AND T.""LogInst"" = M.""MAX_LOGINST""
                                WHERE T.""DocEntry"" = '{safeDocEntry}'
                                  AND T.""DocNum"" = '{safeDocNum}'
                                ORDER BY T.""U_VERSION""";

                oForm.Freeze(true);

                oDT.ExecuteQuery(sQuery);
                oGrid.DataTable = oDT;
                oGrid.AutoResizeColumns();
                oGrid.Columns.Item("MAX_LOGINST").Visible = false;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Load Version Grid Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Long,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                try
                {
                    oForm.Freeze(false);
                }
                catch
                {
                }
            }
        }
        private void HideGridColumn(SAPbouiCOM.Grid oGrid, string columnId)
        {
            try
            {
                if (oGrid != null && oGrid.Columns.Count > 0)
                    oGrid.Columns.Item(columnId).Visible = false;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Hide Grid Column Error: " + ex.Message);
            }
        }
        private bool ValidateCostTotals(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.EditText etComponentTotal = (SAPbouiCOM.EditText)oForm.Items.Item("ETCMTAMT").Specific;
                SAPbouiCOM.EditText etOtherCostTotal = (SAPbouiCOM.EditText)oForm.Items.Item("ETOCTAMT").Specific;
                SAPbouiCOM.EditText etTotalCost = (SAPbouiCOM.EditText)oForm.Items.Item("ETTCNAMT").Specific;

                double componentTotal = GetEditTextDouble(etComponentTotal);
                double otherCostTotal = GetEditTextDouble(etOtherCostTotal);
                double totalCost = GetEditTextDouble(etTotalCost);
                double expectedTotal = componentTotal + otherCostTotal;

                if (componentTotal < 0 || otherCostTotal < 0 || totalCost < 0)
                {
                    Global.GFunc.ShowError("Component Total, Other Cost Total and Total Cost cannot be negative.");
                    return false;
                }

                if (Math.Abs(expectedTotal - totalCost) > 0.01)
                {
                    Global.GFunc.ShowError(
                        "Total Cost mismatch." +
                        "\nComponent Total: " + componentTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +
                        "\nOther Cost Total: " + otherCostTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +
                        "\nExpected Total Cost: " + expectedTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +
                        "\nCurrent Total Cost: " + totalCost.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));

                    oForm.ActiveItem = "ETTCNAMT";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Cost Total Validation Error: " + ex.Message);
                return false;
            }
        }

      

    }
}
