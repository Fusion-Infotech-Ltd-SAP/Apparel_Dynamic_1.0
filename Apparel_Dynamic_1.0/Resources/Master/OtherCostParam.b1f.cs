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
            this.MTXCSPRM.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXCSPRM_ChooseFromListAfter);
            this.MTXCSPRM.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXCSPRM_ChooseFromListBefore);
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ETCRDCOD = ((SAPbouiCOM.EditText)(this.GetItem("ETCRDCOD").Specific));
            this.ETCRDNAM = ((SAPbouiCOM.EditText)(this.GetItem("ETCRDNAM").Specific));
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
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                Global.GFunc.EnsureLine(oForm, "MTXCSPRM", "@FIL_MR_CSOTHCST");
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
                Global.GFunc.ShowError(
                    $"Parameter Master ChooseFromListAfter Error: {ex.Message}");
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
    }
}
