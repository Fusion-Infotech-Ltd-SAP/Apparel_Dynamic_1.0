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
            this.ETHUSBNK.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETHUSBNK_ChooseFromListAfter);
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
            this.BTNAMND = ((SAPbouiCOM.Button)(this.GetItem("BTNAMND").Specific));
            this.GRDAMDTL = ((SAPbouiCOM.Grid)(this.GetItem("GRDAMDTL").Specific));
            this.LKSCNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSCNO").Specific));
            this.LKCUSTMR = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCUSTMR").Specific));
            this.ETBP1BNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBP1BNM").Specific));
            this.ETBP2BNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBP2BNM").Specific));
            this.ETHUSBNM = ((SAPbouiCOM.EditText)(this.GetItem("ETHUSBNM").Specific));
            this.ETCUSTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTNM").Specific));
            this.STREMRKS = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRKS").Specific));
            this.ETREMRKS = ((SAPbouiCOM.EditText)(this.GetItem("ETREMRKS").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.RightClickBefore += new SAPbouiCOM.Framework.FormBase.RightClickBeforeHandler(this.Form_RightClickBefore);
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private void OnCustomInitialize()
        {

        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            

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

            Global.GFunc.SetItemsEnabled(oForm, false, "ETLCNO", "ETDOCNUM", "CBSERIES", "CBCOMPNY");
            Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXSLODR", "@FIL_DR_LCM1", "U_SONO");

            SetStatusFields(oForm);
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


        private void CBSTATCM_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

                string selectedValue = oCmb.Selected == null ? "" : oCmb.Selected.Value.Trim();

                if (selectedValue == "C")
                {
                    oForm.Items.Item("CBSTATCM").Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error in CM LostFocus Error: " + ex.Message);
            }
        }

        private void CBSTATCM_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

                string selectedValue = "";
                if (oCmb.Selected != null)
                    selectedValue = oCmb.Selected.Value.Trim();

                if (selectedValue == "C")
                {
                    int result = Application.SBO_Application.MessageBox(
                        "Are you sure want to confirm?",
                        1,
                        "Yes",
                        "No"
                    );

                    if (result != 1)
                    {
                        oCmb.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error in CM Status selection: " + ex.Message);
            }
        }
        private void CBSTATMR_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;

                string selectedValue = "";
                if (oCmb.Selected != null)
                    selectedValue = oCmb.Selected.Value.Trim();

                if (selectedValue == "C")
                {
                    int result = Application.SBO_Application.MessageBox(
                        "Are you sure want to change?",
                        1,
                        "Yes",
                        "No"
                    );

                    if (result == 1)
                    {
                        oForm.Items.Item("CBSTATCM").Enabled = true;
                    }
                    else
                    {
                        oCmb.Select("D", SAPbouiCOM.BoSearchKey.psk_ByValue);
                        oForm.Items.Item("CBSTATCM").Enabled = false;
                    }
                }
                else
                {
                    oForm.Items.Item("CBSTATCM").Enabled = false;
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
                SAPbouiCOM.ComboBox oCmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;

                string selectedValue = oCmb.Selected == null ? "" : oCmb.Selected.Value.Trim();

                if (selectedValue == "C")
                {
                    oForm.Items.Item("CBSTATMR").Enabled = false;
                    oForm.Items.Item("CBSTATCM").Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error in MR LostFocus Error: " + ex.Message);
            }
        }

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

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg =(SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.ChooseFromList oCFL =oForm.ChooseFromLists.Item(cflArg.ChooseFromListUID);
                SAPbouiCOM.Conditions oConditions =(SAPbouiCOM.Conditions)Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_Conditions);
                SAPbouiCOM.Condition oCondition = oConditions.Add();

                oCondition.Alias = "U_SCNO";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = scNo;

                oCFL.SetConditions(oConditions);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sales Order CFL Error: " + ex.Message);
                BubbleEvent = false;
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
                else if (lcNo == "")
                {
                    Global.GFunc.ShowError("Enter LC No");
                    oForm.ActiveItem = "ETLCNO";
                    return BubbleEvent = false;
                }

                if (IsDuplicateLCNo(oForm, lcNo))
                {
                    Global.GFunc.ShowError("LC No already exists.");
                    oForm.ActiveItem = "ETLCNO";
                    return BubbleEvent = false;
                }

                Global.GFunc.PreventEmptyLastRow(oForm, "@FIL_DR_LCM1", MTXSLODR, "U_SONO");
                Global.GFunc.PreventEmptyLastRow(oForm, "@FIL_DR_LCM2", MTXATTCH, "U_ATCHMENT");
            }

            return BubbleEvent;
        }
        private void SetStatusFields(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.ComboBox cbStatMR = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATMR").Specific;
                SAPbouiCOM.ComboBox cbStatCM = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSTATCM").Specific;

                string mrStatus = cbStatMR.Selected == null ? "" : cbStatMR.Selected.Value.Trim();
                string cmStatus = cbStatCM.Selected == null ? "" : cbStatCM.Selected.Value.Trim();

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
                else if (mrStatus == "C" && cmStatus == "C")
                {
                    oForm.Items.Item("CBSTATMR").Enabled = false;
                    oForm.Items.Item("CBSTATCM").Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Status field control error: " + ex.Message);
            }
        }

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

    }
}
