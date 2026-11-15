using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;

namespace Apparel_Dynamic_1._0.Resources.Setup
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Setup.CostElement", "Resources/Setup/CostElement.b1f")]
    class CostElement : UserFormBase
    {
        public CostElement()
        {
        }

        private SAPbouiCOM.StaticText STCODE, STNAME, STACTIVE;
        private SAPbouiCOM.EditText ETCODE, ETNAME, ETDOCTRY;
        private SAPbouiCOM.Button ADDButton, CancelButton;
        private SAPbouiCOM.CheckBox CKACTIVE;

        public override void OnInitializeComponent()
        {
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STNAME = ((SAPbouiCOM.StaticText)(this.GetItem("STNAME").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETCODE.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETCODE_LostFocusAfter);
            this.ETNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETNAME").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.STACTIVE = ((SAPbouiCOM.StaticText)(this.GetItem("STACTIVE").Specific));
            this.CKACTIVE = ((SAPbouiCOM.CheckBox)(this.GetItem("CKACTIVE").Specific));
            this.OnCustomInitialize();
        }

        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }
        private void OnCustomInitialize()
        {

        }


        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            oForm.Freeze(true);
            try
            {
                SetItemsEnabled(oForm, false, "ETCODE");
            }
            finally
            {
                oForm.Freeze(false);
            }

        }
        private void SetItemsEnabled(SAPbouiCOM.Form oForm, bool enabled, params string[] itemIds)
        {
            foreach (string itemId in itemIds)
            {
                try
                {
                    oForm.Items.Item(itemId).Enabled = enabled;
                }
                catch
                {

                }
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

        private void ETCODE_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE) return;

                string code = ETCODE.Value.Trim();
                string UCode = Global.GFunc.ToUpperCase(code);

                if (ETCODE.Value != UCode) ETCODE.Value = UCode;
                if (string.IsNullOrEmpty(UCode)) return;

                if (!ValidateCostElementCode(oForm, UCode, out string err))
                {
                    Global.GFunc.ShowError(err);
                    ETCODE.Value = "";
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError(ex.Message);
            }
        }

        private bool IsValidCode(string code, out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrWhiteSpace(code))
            {
                errorMessage = "Code cannot be empty.";
                return false;
            }

            if (code.Contains(" "))
            {
                errorMessage = "Code cannot contain spaces.";
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(code, @"^[A-Za-z0-9]+$"))
            {
                errorMessage = "Code contains invalid characters. Only letters and numbers are allowed.";
                return false;
            }

            return true;
        }

        private bool ValidateCostElementCode(SAPbouiCOM.Form oForm, string code, out string errorMessage)
        {
            errorMessage = "";

            if (!IsValidCode(code, out errorMessage)) return false;

            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE && IsDuplicateCode(code))
            {
                errorMessage = "Cost Element Code already exists.";
                return false;
            }

            return true;
        }

        private bool IsDuplicateCode(string code)
        {
            SAPbobsCOM.Recordset oRS = null;

            try
            {
                oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string query = $@"SELECT 1 FROM ""@FIL_MH_CSTELEMT"" WHERE UPPER(""Code"") = '{code.ToUpperInvariant().Replace("'", "''")}'";
                oRS.DoQuery(query);

                return !oRS.EoF;
            }
            finally
            {
                if (oRS != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(oRS);
            }
        }

        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string code = ETCODE.Value.Trim().ToUpperInvariant();
            string name = ETNAME.Value.Trim();

            if (!ValidateCostElementCode(oForm, code, out string errorMessage))
            {
                Global.GFunc.ShowError(errorMessage);
                if (oForm.Items.Item("ETCODE").Enabled) oForm.ActiveItem = "ETCODE";
                return BubbleEvent = false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                Global.GFunc.ShowError("Enter Cost Element Name.");
                oForm.ActiveItem = "ETNAME";
                return BubbleEvent = false;
            }

            return BubbleEvent;
        }
    }
}
