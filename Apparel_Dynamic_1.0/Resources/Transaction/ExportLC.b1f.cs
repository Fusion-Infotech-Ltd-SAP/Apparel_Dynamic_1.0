using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;

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

        private SAPbouiCOM.EditText ETBP1BNM, ETBP2BNM, ETHUSBNM, ETCUSTNM,ETCUSTMR, ETSCNO, ETLCNO, ETDOCTRY, ETDOCNUM, ETLCDESC, ETCURR, ETBP1BNK, ETBP2BNK, ETHUSBNK, ETLCVAL, ETDOCDAT, ETISUDAT, ETSHPDAT, ETEXPDAT, ETB2BPER, ETB2BAMT, ETAMDNO;

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
            this.CBSTATCM = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSTATCM").Specific));
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
            this.ETHUSBNK.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETHUSBNK_ChooseFromListAfter);
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
            this.MTXATTCH = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTCH").Specific));
            this.BRWSBTN = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.BRWSBTN.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BRWSBTN_PressedAfter);
            this.DISPBTN = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.DISPBTN.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.DISPBTN_PressedAfter);
            this.DELBTN = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.DELBTN.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.DELBTN_PressedAfter);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNLDATA = ((SAPbouiCOM.Button)(this.GetItem("BTNLDATA").Specific));
            this.BTNAMND = ((SAPbouiCOM.Button)(this.GetItem("BTNAMND").Specific));
            this.GRDAMDTL = ((SAPbouiCOM.Grid)(this.GetItem("GRDAMDTL").Specific));
            this.LKSCNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSCNO").Specific));
            this.LKCUSTMR = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCUSTMR").Specific));
            this.ETBP1BNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBP1BNM").Specific));
            this.ETBP2BNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBP2BNM").Specific));
            this.ETHUSBNM = ((SAPbouiCOM.EditText)(this.GetItem("ETHUSBNM").Specific));
            this.ETCUSTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTNM").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
        }

        private void OnCustomInitialize()
        {

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

                ((SAPbouiCOM.EditText)MTXATTCH.Columns.Item("CLATTACH").Cells.Item(lastRow).Specific).Value = serverFile;

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


        private void ETHUSBNK_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
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
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

            if (dt == null || dt.Rows.Count == 0)
                return;

            string SCNo = dt.GetValue("U_SCNO", 0).ToString().Trim();
            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSCNO").Specific;
            ETCD.Value = SCNo;
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

    }
}
