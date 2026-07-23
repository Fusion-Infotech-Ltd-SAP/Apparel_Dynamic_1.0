using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;

namespace Apparel_Dynamic_1._0.Resources.Master
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Master.OtherCostParam", "Resources/Master/OtherCostParam.b1f")]
    class OtherCostParam : UserFormBase
    {
        public OtherCostParam()
        {
        }

        private SAPbouiCOM.StaticText STCUSCOD, STCUSNAM;
        private SAPbouiCOM.EditText ETCUSCOD, ETDOCTRY, ETCUSNAM, ETCRDCOD, ETCRDNAM;

        private SAPbouiCOM.Matrix MTXCSPRM;
        private SAPbouiCOM.Button ADDButton, CancelButton;



        public override void OnInitializeComponent()
        {
            this.STCUSCOD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSCOD").Specific));
            this.STCUSNAM = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSNAM").Specific));
            this.ETCUSCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSCOD").Specific));
            this.ETCUSCOD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETCUSCOD_ChooseFromListBefore);
            this.ETCUSCOD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSCOD_ChooseFromListAfter);
            this.ETCUSNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSNAM").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.MTXCSPRM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCSPRM").Specific));
            this.MTXCSPRM.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXCSPRM_LostFocusAfter);
            this.MTXCSPRM.ComboSelectAfter += new SAPbouiCOM._IMatrixEvents_ComboSelectAfterEventHandler(this.MTXCSPRM_ComboSelectAfter);
            this.MTXCSPRM.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXCSPRM_ChooseFromListAfter);
            this.MTXCSPRM.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXCSPRM_ChooseFromListBefore);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ETCRDCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETCRDCOD").Specific));
            this.ETCRDNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETCRDNAM").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.ActivateAfter += new SAPbouiCOM.Framework.FormBase.ActivateAfterHandler(this.Form_ActivateAfter);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.RightClickBefore += new RightClickBeforeHandler(this.Form_RightClickBefore);

        }


        private void OnCustomInitialize()
        {

        }

        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                Global.GFunc.EnsureLine(oForm, "MTXCSPRM", "@FIL_MR_CSOTHCST");
            }
        }

        private void MTXCSPRM_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.ColUID != "CLBSDON")
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCSPRM").Specific;
                SAPbouiCOM.ComboBox cbBasedOn = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLBSDON").Cells.Item(pVal.Row).Specific;

                if (cbBasedOn.Selected == null)
                    return;

                string basedOn = cbBasedOn.Selected.Value.Trim();
                EnableDisableColumns(oForm, oMatrix, pVal.Row, basedOn);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Based On ComboSelectAfter Error: {ex.Message}");
            }
        }

        private void MTXCSPRM_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //Negative Check
            try
            {
                if (pVal.Row <= 0)
                    return;

                if (pVal.ColUID != "CLPERCN" && pVal.ColUID != "CLVALUE")
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCSPRM").Specific;
                SAPbouiCOM.EditText editText = (SAPbouiCOM.EditText)oMatrix.Columns.Item(pVal.ColUID).Cells.Item(pVal.Row).Specific;

                double value;
                if (!double.TryParse(editText.Value.Trim(), out value))
                    value = 0;

                if (value < 0)
                {
                    editText.Value = "0.0";
                    Global.GFunc.ShowError("Percentage or Value cannot be negative.");
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Matrix LostFocusAfter Error: {ex.Message}");
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

        private void MTXCSPRM_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            // Parameter Master CFL Select Before
            BubbleEvent = true;
            try
            {
                if (pVal.ColUID != "CLPRMCOD")
                    return;

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                // Only apply for Parameter Master CFL
                if (cflUID != "CFL_PRM")
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                SAPbouiCOM.Conditions oConditions = new SAPbouiCOM.Conditions();
                SAPbouiCOM.Condition oCondition = oConditions.Add();

                oCondition.Alias = "U_ACTIVE";
                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                oCondition.CondVal = "Y";

                oCFL.SetConditions(oConditions);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Error filtering Parameter CFL: {ex.Message}");
                BubbleEvent = false;
            }
        }

        private void MTXCSPRM_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // Parameter Master CFL Select After
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCSPRM").Specific;

                if (pVal.ColUID != "CLPRMCOD" || pVal.Row <= 0)
                    return;
                if (cflArg.ChooseFromListUID != "CFL_PRM")
                    return;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string code = dt.GetValue("Code", 0).ToString().Trim();
                string basedOn = dt.GetValue("U_BASEDON", 0).ToString().Trim();

                if (IsDuplicateParameterCode(oMatrix, pVal.Row, code))
                {
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPRMCOD").Cells.Item(pVal.Row).Specific).Value = "";
                    Global.GFunc.ShowError($"Parameter Code '{code}' already exists in another row.");
                    return;
                }

                SAPbouiCOM.EditText etParameterCode = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPRMCOD").Cells.Item(pVal.Row).Specific;
                etParameterCode.Value = code;
                SAPbouiCOM.ComboBox cbBasedOn = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLBSDON").Cells.Item(pVal.Row).Specific;

                if (!string.IsNullOrWhiteSpace(basedOn))
                {
                    cbBasedOn.Select(basedOn, SAPbouiCOM.BoSearchKey.psk_ByValue);
                }
                // Enable Percentage or Value column
                EnableDisableColumns(oForm, oMatrix, pVal.Row, basedOn);
                Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXCSPRM", "@FIL_MR_CSOTHCST", "U_PRMCODE");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Parameter Master ChooseFromListAfter Error: {ex.Message}");
            }
        }


        private void ETCUSCOD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            // Customer Code CFL Select Before 
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_OCRD")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "CardType";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "C";
                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Error filtering Customer CFL:  {ex.Message}");
                BubbleEvent = false;
            }

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCSPRM").Specific;

                Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXCSPRM", "@FIL_MR_CSOTHCST", "U_PRMCODE");
                Global.GFunc.SetItemsEnabled(oForm, false, "ETCUSNAM", "ETCUSCOD");

                // Enable/Disable columns based on Based On value
                for (int row = 1; row <= oMatrix.RowCount; row++)
                {
                    SAPbouiCOM.ComboBox cbBasedOn = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item("CLBSDON").Cells.Item(row).Specific;

                    if (cbBasedOn.Selected == null)
                        continue;

                    string basedOn = cbBasedOn.Selected.Value.Trim();
                    EnableDisableColumns(oForm, oMatrix, row, basedOn);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Form_DataLoadAfter Error: {ex.Message}");
            }
        }

        private void Form_RightClickBefore(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(eventInfo.FormUID);

                if (eventInfo.ItemUID != "MTXCSPRM" || eventInfo.Row <= 0)
                    return;

                oForm.EnableMenu("1293", true);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Form_RightClickBefore Error: {ex.Message}");
                BubbleEvent = false;
            }

        }

        private void ETCUSCOD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            // Customer Code CFL Select After 
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                    return;

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;
                string code = dt.GetValue("CardCode", 0).ToString().Trim();
                string name = dt.GetValue("CardName", 0).ToString().Trim();

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCUSCOD").Specific).Value = code;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCUSNAM").Specific).Value = name;

                //Setting same value on CardCode UDF
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCRDCOD").Specific).Value = code;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCRDNAM").Specific).Value = name;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Customer ChooseFromListAfter Error: {ex.Message}");
            }

        }


        //____________________________________________________________________________Custom Method__________________________________________________________________
        private bool ValidateMatrixRows(SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCSPRM").Specific;
            HashSet<string> parameterCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            for (int row = 1; row <= oMatrix.RowCount; row++)
            {
                string parameterCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPRMCOD").Cells.Item(row).Specific).Value.Trim();
                string percentageText = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPERCN").Cells.Item(row).Specific).Value.Trim();
                string valueText = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVALUE").Cells.Item(row).Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(parameterCode))
                    continue;

                if (!parameterCodes.Add(parameterCode))
                {
                    Global.GFunc.ShowError($"Duplicate Parameter Code found: {parameterCode}");
                    oMatrix.Columns.Item("CLPRMCOD").Cells.Item(row).Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                    return false;
                }

                double percentage;
                if (!double.TryParse(percentageText, out percentage))
                    percentage = 0;

                double amount;
                if (!double.TryParse(valueText, out amount))
                    amount = 0;

                if (percentage < 0)
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPERCN").Cells.Item(row).Specific).Value = "0.0";

                if (amount < 0)
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVALUE").Cells.Item(row).Specific).Value = "0.0";
            }

            oMatrix.FlushToDataSource();
            return true;
        }
        private bool IsDuplicateParameterCode(SAPbouiCOM.Matrix oMatrix, int currentRow, string parameterCode)
        {
            for (int row = 1; row <= oMatrix.RowCount; row++)
            {
                if (row == currentRow)
                    continue;

                string existingCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPRMCOD").Cells.Item(row).Specific).Value.Trim();

                if (existingCode.Equals(parameterCode, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string cusCode = oForm.DataSources.DBDataSources.Item("@FIL_MH_CSOTHCST").GetValue("Code", 0).Trim();
           
            if (string.IsNullOrWhiteSpace(cusCode))
            {
                Global.GFunc.ShowError("Enter Customer Code");
                oForm.ActiveItem = "ETCUSCOD";
                return BubbleEvent = false;
            }

            // Customer duplicate check only in Add mode
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE && IsCustomerAlreadyExists(cusCode))
            {
                Global.GFunc.ShowError($"Customer '{cusCode}' already exists in Other Cost Parameter.");
                oForm.ActiveItem = "ETCUSCOD";
                return BubbleEvent = false;
            }

            // Matrix must contain at least one Parameter Code
            if (MTXCSPRM.RowCount == 0)
            {
                Global.GFunc.ShowError("Enter at least one Parameter Code.");
                return BubbleEvent = false;
            }

            //Single row without paramcode check
            string firstParamCode = ((SAPbouiCOM.EditText)MTXCSPRM.Columns.Item("CLPRMCOD").Cells.Item(1).Specific).Value.Trim();
            if (MTXCSPRM.RowCount == 1 && string.IsNullOrWhiteSpace(firstParamCode))
            {
                Global.GFunc.ShowError("Enter at least one Parameter Code.");
                return BubbleEvent = false;
            }
            //Dupliucate ParamCode Check
            if (!ValidateMatrixRows(oForm))
                return BubbleEvent = false;
            
            Global.GFunc.PreventEmptyLastRow(oForm, "@FIL_MR_CSOTHCST", MTXCSPRM, "U_PRMCODE");
            return BubbleEvent;
        }


        private void EnableDisableColumns(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix, int row, string value)
        {
            try
            {
                oForm.Freeze(true);

                bool enablePercentage = value.Equals("Percentage", StringComparison.OrdinalIgnoreCase);
                bool enableValue = value.Equals("Value", StringComparison.OrdinalIgnoreCase);

                int percentageColumnIndex = GetColumnIndex(oMatrix, "CLPERCN");
                int valueColumnIndex = GetColumnIndex(oMatrix, "CLVALUE");

                oMatrix.CommonSetting.SetCellEditable(row, percentageColumnIndex, enablePercentage);
                oMatrix.CommonSetting.SetCellEditable(row, valueColumnIndex, enableValue);

                if (enablePercentage)
                {
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVALUE").Cells.Item(row).Specific).Value = "";
                }
                else if (enableValue)
                {
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPERCN").Cells.Item(row).Specific).Value = "";
                }
                else
                {
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPERCN").Cells.Item(row).Specific).Value = "";
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLVALUE").Cells.Item(row).Specific).Value = "";
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"EnableDisableColumns Error: {ex.Message}");
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private int GetColumnIndex(SAPbouiCOM.Matrix matrix,string columnId)
        {
            for (int i = 1; i <= matrix.Columns.Count; i++)
            {
                if (matrix.Columns.Item(i).UniqueID == columnId)
                    return i;
            }

            throw new Exception("Column not found: " + columnId);
        }

        private bool IsCustomerAlreadyExists(string customerCode)
        {
            SAPbobsCOM.Recordset recordset = null;

            try
            {
                string safeCustomerCode = customerCode.Replace("'", "''");

                string query = $@"
                                SELECT COUNT(*) AS ""Total""
                                FROM ""@FIL_MH_CSOTHCST"" H
                                INNER JOIN ""@FIL_MR_CSOTHCST"" R
                                    ON H.""Code"" = R.""Code""
                                WHERE H.""Code"" = '{safeCustomerCode}'";

                recordset = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                recordset.DoQuery(query);

                int total = Convert.ToInt32(recordset.Fields.Item("Total").Value);
                return total > 0;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Customer existence check error: {ex.Message}");
                return false;
            }
            finally
            {
                if (recordset != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(recordset);
            }
        }
    }
}
