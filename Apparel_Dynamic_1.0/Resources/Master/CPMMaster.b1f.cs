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

        private SAPbouiCOM.StaticText STBRNDCD, STPDGPCD, STDOCNUM, STRTSGCD, STFRMDAT, STTODATE;

        private SAPbouiCOM.EditText ETBRNDCD, ETBRNDNM, ETDOCTRY, ETPDGPCD, ETRTSGCD, ETPDGPNM, 
                    ETRTSGNM, ETDOCNUM, ETFRMDAT, ETTODATE;

        private SAPbouiCOM.ComboBox CBSERIES;

        private SAPbouiCOM.Folder TABSAMRN, TABCPM;

        private SAPbouiCOM.Matrix MTXSAMRN, MTXCPM;

        private SAPbouiCOM.Button ADDButton, CancelButton, BTNWLN, BTNLDCPM;



        private bool _isAddButtonPressed = false;

        public override void OnInitializeComponent()
        {
            //    Static Text
            this.STBRNDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNDCD").Specific));
            this.STPDGPCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDGPCD").Specific));
            this.STRTSGCD = ((SAPbouiCOM.StaticText)(this.GetItem("STRTSGCD").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STFRMDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STFRMDAT").Specific));
            this.STTODATE = ((SAPbouiCOM.StaticText)(this.GetItem("STTODATE").Specific));
            //    Edit text
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
            //    Combo box
            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            //    tab
            this.TABSAMRN = ((SAPbouiCOM.Folder)(this.GetItem("TABSAMRN").Specific));
            this.TABCPM = ((SAPbouiCOM.Folder)(this.GetItem("TABCPM").Specific));
            //    Matrix
            this.MTXSAMRN = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSAMRN").Specific));
            this.MTXSAMRN.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXSAMRN_LostFocusAfter);
            this.MTXCPM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCPM").Specific));
            //    Button
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNWLN = ((SAPbouiCOM.Button)(this.GetItem("BTNWLN").Specific));
            this.BTNWLN.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNWLN_PressedAfter);
            this.BTNLDCPM = ((SAPbouiCOM.Button)(this.GetItem("BTNLDCPM").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.ActivateAfter += new ActivateAfterHandler(this.Form_ActivateAfter);

        }



        private void OnCustomInitialize()
        {

        }

        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode ==SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                HideSampleRateColumns(oForm);
            }
        }
        private void BTNWLN_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);

                // Check Route Stage
                SAPbouiCOM.EditText etRouteStage =
                    (SAPbouiCOM.EditText)oForm.Items.Item("ETRTSGCD").Specific;

                if (string.IsNullOrWhiteSpace(etRouteStage.Value))
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Please enter the Route Stage first.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                    oForm.Items.Item("ETRTSGCD").Click();
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
                    Application.SBO_Application.StatusBar.SetText(
                        "From Quantity cannot be negative.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return;
                }

                if (toQty < 0)
                {
                    SetMatrixValue(oMatrix, "CLTO", currentRow, "");
                    Application.SBO_Application.StatusBar.SetText(
                        "To Quantity cannot be negative.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return;
                }

                if (toQty == 0)
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Enter To Quantity before adding new line.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    return;
                }

                if (toQty <= fromQty)
                {
                    SetMatrixValue(oMatrix, "CLTO", currentRow, "");
                    Application.SBO_Application.StatusBar.SetText(
                        "To Quantity must be greater than From Quantity.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
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
                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
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

                        Application.SBO_Application.StatusBar.SetText(
                            "From Quantity cannot be negative.",
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Error);

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

                        Application.SBO_Application.StatusBar.SetText(
                            "To Quantity cannot be negative.",
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                        return;
                    }

                    if (toQty != 0 && toQty <= fromQty)
                    {
                        SetMatrixValue(oMatrix, "CLTO", pVal.Row, "");

                        Application.SBO_Application.StatusBar.SetText(
                            "To Quantity must be greater than From Quantity.",
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                        return;
                    }
                }

                SetSAMMatrixEditableAfterLoad(oMatrix);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
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
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering Route Stage CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
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

                // adding new line on the matrix and assign Code column a default value 
                EnsureLine(oForm, "MTXSAMRN", "@FIL_DR_SAMRNG");
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;

                // Only first line, only first time
                if (oMatrix.RowCount > 0)
                {
                    SAPbouiCOM.EditText txtCode = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCODE").Cells.Item(1).Specific;
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
                Application.SBO_Application.StatusBar.SetText(
                    $"Route Stage Code ChooseFromListAfter Error: {ex.Message}",
                    SAPbouiCOM.BoMessageTime.bmt_Long,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
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
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering Product Group CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }
        }

        private void ETPDGPCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // Product Group Code CFL Select After 
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;
                string code = dt.GetValue("Code", 0).ToString().Trim();
                string name = dt.GetValue("Name", 0).ToString().Trim();

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPCD").Specific).Value = code;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETPDGPNM").Specific).Value = name;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    $"Product Group Code ChooseFromListAfter Error: {ex.Message}",
                    SAPbouiCOM.BoMessageTime.bmt_Long,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
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
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering Brand CFL: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
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
                Application.SBO_Application.StatusBar.SetText(
                    $"ETBRNDCD_ChooseFromListAfter Error: {ex.Message}",
                    SAPbouiCOM.BoMessageTime.bmt_Long,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
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
