using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;

namespace Apparel_Dynamic_1._0.Resources.Master
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Master.CPMMaster", "Resources/Master/CPMMaster.b1f")]
    class CPMMaster : UserFormBase
    {
        public CPMMaster()
        {
        }

        private SAPbouiCOM.StaticText STBRNDCD, STPDGPCD, STDOCNUM, STRTSGCD, STFRMDAT, STTODATE, STDOCDAT;

        private SAPbouiCOM.EditText ETBRNDCD, ETBRNDNM, ETDOCTRY, ETPDGPCD, ETRTSGCD, ETPDGPNM, ETDOCDAT,
                    ETRTSGNM, ETDOCNUM, ETFRMDAT, ETTODATE;

        private SAPbouiCOM.ComboBox CBSERIES;

        private SAPbouiCOM.Folder TABSAMRN, TABCPM;

        private SAPbouiCOM.Matrix MTXSAMRN, MTXCPM;

        private SAPbouiCOM.Button ADDButton, CancelButton, BTNWLN, BTNLDCPM;



        private bool _isAddButtonPressed = false;

        public override void OnInitializeComponent()
        {
            //         Static Text
            this.STBRNDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNDCD").Specific));
            this.STPDGPCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDGPCD").Specific));
            this.STRTSGCD = ((SAPbouiCOM.StaticText)(this.GetItem("STRTSGCD").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STFRMDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STFRMDAT").Specific));
            this.STTODATE = ((SAPbouiCOM.StaticText)(this.GetItem("STTODATE").Specific));
            //         Edit text
            this.ETBRNDCD = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDCD").Specific));
            this.ETBRNDCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETBRNDCD_ChooseFromListBefore);
            this.ETBRNDCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETBRNDCD_ChooseFromListAfter);
            this.ETBRNDNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDNM").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETPDGPCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPCD").Specific));
            this.ETPDGPCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETPDGPCD_ChooseFromListBefore);
            this.ETPDGPCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETPDGPCD_ChooseFromListAfter);
            this.ETRTSGCD = ((SAPbouiCOM.EditText)(this.GetItem("ETRTSGCD").Specific));
            this.ETRTSGCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETRTSGCD_ChooseFromListBefore);
            this.ETRTSGCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETRTSGCD_ChooseFromListAfter);
            this.ETPDGPNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPNM").Specific));
            this.ETRTSGNM = ((SAPbouiCOM.EditText)(this.GetItem("ETRTSGNM").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETFRMDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETFRMDAT").Specific));
            this.ETTODATE = ((SAPbouiCOM.EditText)(this.GetItem("ETTODATE").Specific));
            //         Combo box
            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            //         tab
            this.TABSAMRN = ((SAPbouiCOM.Folder)(this.GetItem("TABSAMRN").Specific));
            this.TABCPM = ((SAPbouiCOM.Folder)(this.GetItem("TABCPM").Specific));
            //         Matrix
            this.MTXSAMRN = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSAMRN").Specific));
            this.MTXSAMRN.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXSAMRN_LostFocusAfter);
            this.MTXCPM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCPM").Specific));
            //         Button
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNWLN = ((SAPbouiCOM.Button)(this.GetItem("BTNWLN").Specific));
            this.BTNWLN.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNWLN_PressedAfter);
            this.BTNLDCPM = ((SAPbouiCOM.Button)(this.GetItem("BTNLDCPM").Specific));
            this.BTNLDCPM.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.BTNLDCPM_PressedBefore);
            this.BTNLDCPM.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNLDCPM_PressedAfter);
            this.STDOCDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.ETDOCDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.ActivateAfter += new SAPbouiCOM.Framework.FormBase.ActivateAfterHandler(this.Form_ActivateAfter);
            this.RightClickBefore += new SAPbouiCOM.Framework.FormBase.RightClickBeforeHandler(this.Form_RightClickBefore);
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }



        private void OnCustomInitialize()
        {

        }



        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           

        }
        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);

                SAPbouiCOM.Matrix samMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;
                SAPbouiCOM.Matrix cpmMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPM").Specific;

                // First hide all SAM columns in MTXCPM
                HideSampleRateColumns(oForm);

                // Then show columns based on loaded MTXSAMRN row count
                ShowSampleRateColumns(oForm, samMatrix.VisualRowCount);
                samMatrix.AutoResizeColumns();
                cpmMatrix.AutoResizeColumns();
                SetSAMMatrixEditableAfterLoad(samMatrix);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Form_DataLoadAfter Error: {ex.Message}");
            }
            finally
            {
                if (oForm != null)
                    oForm.Freeze(false);
            }
        }

        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                {
                    HideSampleRateColumns(oForm);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Form_ActivateAfter Error: {ex.Message}");
            }
        }

        private void Form_RightClickBefore(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(eventInfo.FormUID);

                if (eventInfo.ItemUID != "MTXSAMRN" || eventInfo.Row <= 0)
                    return;

                oForm.EnableMenu("1293", true);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Form_RightClickBefore Error: {ex.Message}");
                BubbleEvent = false;
            }
        }
        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

            // Do not validate in OK mode
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                return;

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                ValidateForm(ref oForm, ref BubbleEvent);
            }

        }



        private void BTNLDCPM_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            //Load CPM Button Press Before Event (Validation Check) 

            BubbleEvent = true;
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                string productGroupCode =((SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPCD").Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(productGroupCode))
                {
                    Global.GFunc.ShowError("Please enter Product Group Code.");
                    oForm.Items.Item("ETPDGPCD").Click();
                    BubbleEvent = false;
                    return;
                }

                SAPbouiCOM.Matrix samMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;

                if (samMatrix.RowCount == 0)
                {
                    Global.GFunc.ShowError("Please enter at least one SAM Range row.");
                    BubbleEvent = false;
                    return;
                }

                for (int i = 1; i <= samMatrix.RowCount; i++)
                {
                    string fromQty = ((SAPbouiCOM.EditText)samMatrix.Columns.Item("CLFROM").Cells.Item(i).Specific).Value.Trim();
                    string toQty = ((SAPbouiCOM.EditText)samMatrix.Columns.Item("CLTO").Cells.Item(i).Specific).Value.Trim();

                    if (string.IsNullOrWhiteSpace(fromQty))
                    {
                        Global.GFunc.ShowError($"Please enter From Quantity in SAM Range row {i}.");
                        BubbleEvent = false;
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(toQty))
                    {
                        Global.GFunc.ShowError($"Please enter To Quantity in SAM Range row {i}.");
                        BubbleEvent = false;
                        return;
                    }
                }

                //Check CPM Matrix has data or not

                SAPbouiCOM.Matrix cpmMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPM").Specific;
                bool hasCPMData = false;

                for (int i = 1; i <= cpmMatrix.RowCount; i++)
                {
                    string orderType = ((SAPbouiCOM.EditText)cpmMatrix.Columns.Item("CLORDTYP").Cells.Item(i).Specific).Value.Trim();
                    string minQty = ((SAPbouiCOM.EditText)cpmMatrix.Columns.Item("CLMINQTY").Cells.Item(i).Specific).Value.Trim();
                    string maxQty = ((SAPbouiCOM.EditText)cpmMatrix.Columns.Item("CLMAXQTY").Cells.Item(i).Specific).Value.Trim();

                    if (!string.IsNullOrWhiteSpace(orderType) ||
                        !string.IsNullOrWhiteSpace(minQty) ||
                        !string.IsNullOrWhiteSpace(maxQty))
                    {
                        hasCPMData = true;
                        break;
                    }
                }

                if (hasCPMData)
                {
                    int confirm = Application.SBO_Application.MessageBox(
                        "Existing CPM range data will be lost. Are you sure you want to load new CPM data?",
                        1,
                        "Yes",
                        "No",
                        "");

                    if (confirm != 1)
                    {
                        BubbleEvent = false;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"BTNLDCPM_PressedBefore Error: {ex.Message}");
                BubbleEvent = false;
            }
        }

        private void BTNLDCPM_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            SAPbobsCOM.Recordset rs = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);

                string productGroupCode =((SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPCD").Specific).Value.Trim();
                SAPbouiCOM.Matrix samMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;
                SAPbouiCOM.Matrix cpmMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPM").Specific;
                SAPbouiCOM.DBDataSource db =oForm.DataSources.DBDataSources.Item("@FIL_DR_CPMD");

                // Hide all SAM Range columns first
                //HideSampleRateColumns(oForm);

                // Show only required SAM Range columns
                ShowSampleRateColumns(oForm, samMatrix.RowCount);

                // Clear old CPM matrix data
                db.Clear();
                cpmMatrix.Clear();
                SAPbobsCOM.Company oCompany =(SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany();
                rs = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string query = $@"
                                SELECT
                                    R.""LineId"",
                                    R.""U_OTYPECODE"",
                                    R.""U_MINQTY"",
                                    R.""U_MAXQTY""
                                FROM ""@FIL_MH_ORDRTYPE"" H
                                INNER JOIN ""@FIL_MR_ORDRTYPE"" R
                                    ON H.""Code"" = R.""Code""
                                WHERE H.""Code"" = '{productGroupCode.Replace("'", "''")}'
                                ORDER BY R.""LineId""";

                rs.DoQuery(query);

                int row = 0;
                while (!rs.EoF)
                {
                    db.InsertRecord(row);

                    db.SetValue("LineId", row, (row + 1).ToString());
                    db.SetValue("U_OTYPECODE", row, rs.Fields.Item("U_OTYPECODE").Value.ToString());
                    db.SetValue("U_MINQTY", row, rs.Fields.Item("U_MINQTY").Value.ToString());
                    db.SetValue("U_MAXQTY", row, rs.Fields.Item("U_MAXQTY").Value.ToString());

                    row++;
                    rs.MoveNext();
                }

                cpmMatrix.LoadFromDataSource();
                cpmMatrix.AutoResizeColumns();

                Global.GFunc.ShowSuccess("CPM data loaded successfully.");

                Application.SBO_Application.StatusBar.SetText(
                    "CPM data loaded successfully.",
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Load CPM error: {ex.Message}");

            }
            finally
            {
                try
                {
                    if (rs != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);

                    if (oForm != null)
                        oForm.Freeze(false);
                }
                catch(Exception ex)
                {
                    Global.GFunc.ShowError($"BTNLDCPM_PressedAfter Finally Error: {ex.Message}");
                }
            }
        }


        private void BTNWLN_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);

                // Check Product Group
                SAPbouiCOM.EditText etRouteStage =
                    (SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPCD").Specific;

                if (string.IsNullOrWhiteSpace(etRouteStage.Value))
                {
                    Global.GFunc.ShowError("Please enter the Product Group first.");
                    oForm.Items.Item("ETPDGPCD").Click();
                    return;
                }

                SAPbouiCOM.Matrix oMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;
                SAPbouiCOM.DBDataSource db =oForm.DataSources.DBDataSources.Item("@FIL_DR_SAMRNG");

                int currentRow = oMatrix.RowCount;

                double fromQty = GetMatrixDoubleValue(oMatrix, "CLFROM", currentRow);
                double toQty = GetMatrixDoubleValue(oMatrix, "CLTO", currentRow);

                if (fromQty < 0)
                {
                    SetMatrixValue(oMatrix, "CLFROM", currentRow, "0");
                    Global.GFunc.ShowError("From Quantity cannot be negative.");
                    return;
                }

                if (toQty < 0)
                {
                    SetMatrixValue(oMatrix, "CLTO", currentRow, "");
                    Global.GFunc.ShowError("To Quantity cannot be negative.");
                    return;
                }

                if (toQty == 0)
                {
                    Global.GFunc.ShowError("Enter To Quantity before adding new line.");
                    return;
                }

                if (toQty <= fromQty)
                {
                    SetMatrixValue(oMatrix, "CLTO", currentRow, "");
                    Global.GFunc.ShowError("To Quantity must be greater than From Quantity.");
                    return;
                }

                int nextRow = currentRow + 1;

                oMatrix.FlushToDataSource();
                Global.GFunc.SetNewLine(oMatrix, db, nextRow, "");
                oMatrix.LoadFromDataSource();

                SetMatrixValue(oMatrix, "#", nextRow, nextRow.ToString());
                SetMatrixValue(oMatrix, "CLCODE", nextRow, "SAM Range " + nextRow);
                SetMatrixValue(oMatrix, "CLFROM", nextRow, (toQty + 1).ToString("0"));
                SetMatrixValue(oMatrix, "CLTO", nextRow, "");

                SetSAMMatrixEditableAfterLoad(oMatrix);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError(ex.Message);
            }
            finally
            {
                try
                {
                    _isAddButtonPressed = false;
                    if (oForm != null)
                        oForm.Freeze(false);
                }
                catch { }
            }
        }

        private void MTXSAMRN_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                if (pVal.Row <= 0)
                    return;

                if (pVal.ColUID != "CLFROM" && pVal.ColUID != "CLTO")
                    return;

                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;
                oForm.Freeze(true);

                if (pVal.ColUID == "CLFROM")
                {
                    double fromQty =
                        GetMatrixDoubleValue(oMatrix, "CLFROM", pVal.Row);

                    if (fromQty < 0)
                    {
                        SetMatrixValue(oMatrix, "CLFROM", pVal.Row, "0");
                        Global.GFunc.ShowError("From Quantity cannot be negative.");
                        return;
                    }
                }

                if (pVal.ColUID == "CLTO")
                {
                    double fromQty =GetMatrixDoubleValue(oMatrix, "CLFROM", pVal.Row);
                    double toQty =GetMatrixDoubleValue(oMatrix, "CLTO", pVal.Row);

                    if (toQty < 0)
                    {
                        SetMatrixValue(oMatrix, "CLTO", pVal.Row, "");
                        Global.GFunc.ShowError("To Quantity cannot be negative.");
                        return;
                    }

                    if (toQty != 0 && toQty <= fromQty)
                    {
                        SetMatrixValue(oMatrix, "CLTO", pVal.Row, "");
                        Global.GFunc.ShowError("To Quantity must be greater than From Quantity.");
                        return;
                    }
                }

                SetSAMMatrixEditableAfterLoad(oMatrix);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError(ex.Message);
            }
            finally
            {
                try
                {
                    if (oForm != null)
                        oForm.Freeze(false);
                }
                catch { }
            }
        }

        private void ETRTSGCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            // Route Stage CFL Select Before 
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_RTG")
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
                Global.GFunc.ShowError($"Error filtering Route Stage CFL: {ex.Message}");
                BubbleEvent = false;
            }

        }

        private void ETRTSGCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // Route Stage Code CFL Select After 
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;
                string code = dt.GetValue("Code", 0).ToString().Trim();
                string name = dt.GetValue("Name", 0).ToString().Trim();

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETRTSGCD").Specific).Value = code;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETRTSGNM").Specific).Value = name;

               
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Route Stage Code ChooseFromListAfter Error: {ex.Message}");
            }

        }

        private void ETPDGPCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            // Product Group CFL Select Before 
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_GRP")
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
                Global.GFunc.ShowError($"Error filtering Product Group CFL:  {ex.Message}");
                BubbleEvent = false;
            }
        }

        private void ETPDGPCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg =(SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;

                string code = dt.GetValue("Code", 0).ToString().Trim();
                string name = dt.GetValue("Name", 0).ToString().Trim();
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPCD").Specific).Value = code;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPNM").Specific).Value = name;

                //Adding new line on Matrix
                EnsureLine(oForm, "MTXSAMRN", "@FIL_DR_SAMRNG");
                SAPbouiCOM.Matrix oMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;

                if (oMatrix.RowCount > 0)
                {
                    SAPbouiCOM.EditText txtCode =
                        (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(1).Specific;

                    if (string.IsNullOrWhiteSpace(txtCode.Value))
                    {
                        txtCode.Value = "Sam Range 1";
                    }
                }

                int fromColNo = GetMatrixColumnNumber(oMatrix, "CLFROM");

                if (fromColNo > 0)
                {
                    for (int i = 1; i <= oMatrix.RowCount; i++)
                    {
                        oMatrix.CommonSetting.SetCellEditable(i, fromColNo, i == 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Product Group Code ChooseFromListAfter Error:  {ex.Message}");
            }
            finally
            {
                if (oForm != null)
                    oForm.Freeze(false);
            }
        }

        private void ETBRNDCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            // Brand Code CFL Select Before 
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_OBRM")
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
                Global.GFunc.ShowError($"Error filtering Brand CFL:  {ex.Message}");
                BubbleEvent = false;
            }
        }

        private void ETBRNDCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // Brand Code CFL Select After 
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg =(SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;
                string code = dt.GetValue("Code", 0).ToString().Trim();
                string name = dt.GetValue("Name", 0).ToString().Trim();

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDCD").Specific).Value = code;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETBRNDNM").Specific).Value = name;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"ETBRNDCD_ChooseFromListAfter Error: {ex.Message}");
            }
        }

        //___________________________________________________________________________________________________________ 
        // User Define Function

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string brandCode = oForm.DataSources.DBDataSources.Item("@FIL_DH_CPM").GetValue("U_BRAND", 0).Trim();
            string prdGrpCode = oForm.DataSources.DBDataSources.Item("@FIL_DH_CPM").GetValue("U_PRDGRP", 0).Trim();
            string fromDateText = oForm.DataSources.DBDataSources.Item("@FIL_DH_CPM").GetValue("U_FROMDATE", 0).Trim();
            string toDateText = oForm.DataSources.DBDataSources.Item("@FIL_DH_CPM").GetValue("U_TODATE", 0).Trim();
            string docDate = oForm.DataSources.DBDataSources.Item("@FIL_DH_CPM").GetValue("U_DOCDATE", 0).Trim();

            if (string.IsNullOrWhiteSpace(brandCode))
            {
                Global.GFunc.ShowError("Enter Brand Code");
                oForm.ActiveItem = "ETBRNDCD";
                return BubbleEvent = false;
            }
            if (string.IsNullOrWhiteSpace(prdGrpCode))
            {
                Global.GFunc.ShowError("Enter Product Group Master Code");
                oForm.ActiveItem = "ETPDGPCD";
                return BubbleEvent = false;
            }
            if (string.IsNullOrWhiteSpace(fromDateText))
            {
                Global.GFunc.ShowError("Enter From Date");
                oForm.ActiveItem = "ETFRMDAT";
                return BubbleEvent = false;
            }
            if (string.IsNullOrWhiteSpace(toDateText))
            {
                Global.GFunc.ShowError("Enter DocDate");
                oForm.ActiveItem = "ETDOCDAT";
                return BubbleEvent = false;
            }
            if (string.IsNullOrWhiteSpace(docDate))
            {
                Global.GFunc.ShowError("Enter To Date");
                oForm.ActiveItem = "ETTODATE";
                return BubbleEvent = false;
            }
            DateTime fromDate = DateTime.ParseExact(fromDateText, "yyyyMMdd", null);
            DateTime toDate = DateTime.ParseExact(toDateText, "yyyyMMdd", null);

            if (toDate < fromDate)
            {
                Global.GFunc.ShowError("To Date cannot be before From Date");
                oForm.ActiveItem = "ETTODATE";
                return BubbleEvent = false;
            }

            SAPbouiCOM.Matrix oMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;

            for (int i = 1; i <= oMatrix.VisualRowCount; i++)
            {
                string fromQtyText = GetMatrixStringValue(oMatrix, "CLFROM", i);
                string toQtyText = GetMatrixStringValue(oMatrix, "CLTO", i);

                // Skip only last auto-added empty row
                //if (i == oMatrix.RowCount && string.IsNullOrWhiteSpace(maxQtyText))
                //    continue;

                double fromQty = GetMatrixDoubleValue(oMatrix, "CLFROM", i);
                double toQty = GetMatrixDoubleValue(oMatrix, "CLTO", i);

                if (string.IsNullOrWhiteSpace(fromQtyText) || fromQty <= 0)
                {
                    Global.GFunc.ShowError("From Quantity must have value in row " + i);
                    oMatrix.Columns.Item("CLFROM").Cells.Item(i).Click();
                    return BubbleEvent = false;
                }

                if (string.IsNullOrWhiteSpace(toQtyText) || toQty <= 0)
                {
                    Global.GFunc.ShowError("To Quantity must have value in row " + i);
                    oMatrix.Columns.Item("CLTO").Cells.Item(i).Click();
                    return BubbleEvent = false;
                }

                if (toQty <= fromQty)
                {
                    Global.GFunc.ShowError("TO Quantity must be greater than From Quantity in row " + i);
                    oMatrix.Columns.Item("CLTO").Cells.Item(i).Click();
                    return BubbleEvent = false;
                }
            }

            oMatrix.FlushToDataSource();
            return BubbleEvent;
        }

        private string GetMatrixStringValue(SAPbouiCOM.Matrix oMatrix, string colUID, int row)
        {
            SAPbouiCOM.EditText txt = (SAPbouiCOM.EditText)oMatrix.Columns.Item(colUID).Cells.Item(row).Specific;
            return txt.Value.Trim();
        }

        private void SetSAMMatrixEditableAfterLoad(SAPbouiCOM.Matrix oMatrix)
        {
            int fromQtyColNo = GetMatrixColumnNumber(oMatrix, "CLFROM");
            int totyColNo = GetMatrixColumnNumber(oMatrix, "CLTO");

            if (fromQtyColNo <= 0 || totyColNo <= 0)
                return;

            int rowCount = oMatrix.VisualRowCount;

            if (rowCount <= 0)
                return;

            // Case 1: only one row
            if (rowCount == 1)
            {
                oMatrix.CommonSetting.SetCellEditable(1, fromQtyColNo, true);
                oMatrix.CommonSetting.SetCellEditable(1, totyColNo, true);
                return;
            }

            // Case 2: more than one row
            for (int i = 1; i <= rowCount; i++)
            {
                // CLMINQTY disabled for all rows
                oMatrix.CommonSetting.SetCellEditable(i, fromQtyColNo, false);

                // CLMAXQTY enabled only for last row
                oMatrix.CommonSetting.SetCellEditable(i, totyColNo, i == rowCount);
            }
        }


        private double GetMatrixDoubleValue(SAPbouiCOM.Matrix oMatrix, string colUID, int row)
        {
            SAPbouiCOM.EditText txt =
                (SAPbouiCOM.EditText)oMatrix.Columns.Item(colUID).Cells.Item(row).Specific;

            double value = 0;
            double.TryParse(txt.Value, out value);

            return value;
        }

        private void SetMatrixValue(SAPbouiCOM.Matrix oMatrix, string colUID, int row, string value)
        {
            SAPbouiCOM.EditText txt =
                (SAPbouiCOM.EditText)oMatrix.Columns.Item(colUID).Cells.Item(row).Specific;

            txt.Value = value;
        }

        private void HideSampleRateColumns(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                SAPbouiCOM.Matrix oMatrix =
                    (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPM").Specific;

                for (int i = 1; i <= 10; i++)
                {
                    try
                    {
                        oMatrix.Columns.Item($"CLSAMR{i}").Visible = false;
                    }
                    catch
                    {
                        // Ignore if the column does not exist
                    }
                }

                oMatrix.AutoResizeColumns();
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void ShowSampleRateColumns(SAPbouiCOM.Form oForm, int samRangeCount)
        {
            SAPbouiCOM.Matrix oMatrix =
                (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPM").Specific;

            if (samRangeCount > 10)
                samRangeCount = 10;

            for (int i = 1; i <= samRangeCount; i++)
            {
                try
                {
                    oMatrix.Columns.Item("CLSAMR" + i).Visible = true;
                    oMatrix.Columns.Item("CLSAMR" + i).TitleObject.Caption = "SAM Range " + i;
                }
                catch
                {
                }
            }
        }
        private int GetMatrixColumnNumber(SAPbouiCOM.Matrix oMatrix, string colUID)
        {
            for (int i = 1; i <= oMatrix.Columns.Count; i++)
            {
                if (oMatrix.Columns.Item(i).UniqueID == colUID)
                    return i;
            }

            return -1;
        }

        public static void EnsureLine(SAPbouiCOM.Form oForm, string matrixID, string dbTable)
        {
            SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixID).Specific;
            SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item(dbTable);
            if (matrix.RowCount == 0)
            {
                Global.GFunc.SetNewLine(matrix, db, 1, "");
            }
        }
    }
}
