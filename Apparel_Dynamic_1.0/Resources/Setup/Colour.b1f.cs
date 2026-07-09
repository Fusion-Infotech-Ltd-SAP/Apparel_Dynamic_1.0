using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;

namespace Apparel_Dynamic_1._0.Resources.Setup
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Setup.Colour", "Resources/Setup/Colour.b1f")]
    class Colour : UserFormBase
    {
        public Colour()
        {
        }

        private SAPbouiCOM.StaticText STCODE, STNAME, STACTIVE, STPANTON;
        private SAPbouiCOM.EditText ETCODE, ETNAME, ETDOCTRY, ETPANTON;
        private SAPbouiCOM.Button ADDButton, CancelButton;
        private SAPbouiCOM.CheckBox CKACTIVE;



        public override void OnInitializeComponent()
        {
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STNAME = ((SAPbouiCOM.StaticText)(this.GetItem("STNAME").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
           
            this.ETNAME = ((SAPbouiCOM.EditText)(this.GetItem("ETNAME").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.STACTIVE = ((SAPbouiCOM.StaticText)(this.GetItem("STACTIVE").Specific));
            this.CKACTIVE = ((SAPbouiCOM.CheckBox)(this.GetItem("CKACTIVE").Specific));
            this.STPANTON = ((SAPbouiCOM.StaticText)(this.GetItem("STPANTON").Specific));
            this.ETPANTON = ((SAPbouiCOM.EditText)(this.GetItem("ETPANTON").Specific));

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
        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            try
            {
                SAPbouiCOM.DBDataSource db =
                    oForm.DataSources.DBDataSources.Item("@FIL_MH_OCOM");

                string code = db.GetValue("Code", 0).Trim();
                string name = db.GetValue("Name", 0).Trim();
                string pantone = db.GetValue("U_PANTONE", 0).Trim();

                code = Global.GFunc.ToUpperCase(code);
                pantone = Global.GFunc.ToUpperCase(pantone);

                db.SetValue("Code", 0, code);
                db.SetValue("U_PANTONE", 0, pantone);

                // Mandatory validation
                if (string.IsNullOrWhiteSpace(code))
                {
                    Global.GFunc.ShowError("Enter Colour Master Code");
                    oForm.ActiveItem = "ETCODE";
                    return BubbleEvent = false;
                }

                if (string.IsNullOrWhiteSpace(pantone))
                {
                    Global.GFunc.ShowError("Enter Pantone Code");
                    oForm.ActiveItem = "ETPANTON";
                    return BubbleEvent = false;
                }

                if (string.IsNullOrWhiteSpace(name))
                {
                    Global.GFunc.ShowError("Enter Colour Master Name");
                    oForm.ActiveItem = "ETNAME";
                    return BubbleEvent = false;
                }

                // Code format validation
                if (!IsValidCode(code, out string codeErr))
                {
                    Global.GFunc.ShowError(codeErr);
                    oForm.ActiveItem = "ETCODE";
                    return BubbleEvent = false;
                }

                // Pantone format validation
                if (!IsValidCode(pantone, out string pantoneErr))
                {
                    Global.GFunc.ShowError(pantoneErr);
                    oForm.ActiveItem = "ETPANTON";
                    return BubbleEvent = false;
                }

                // Duplicate Code check
                if (IsDuplicateColourCode(code, oForm.Mode))
                {
                    Global.GFunc.ShowError("Code already exists!");
                    oForm.ActiveItem = "ETCODE";
                    return BubbleEvent = false;
                }

                // Duplicate Pantone check
                if (IsDuplicatePantoneCode(pantone, code))
                {
                    Global.GFunc.ShowError("Pantone Code already exists!");
                    oForm.ActiveItem = "ETPANTON";
                    return BubbleEvent = false;
                }

                return BubbleEvent;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error: " + ex.Message);
                return BubbleEvent = false;
            }
        }


        private bool IsDuplicateColourCode(string code, SAPbouiCOM.BoFormMode mode)
        {
            if (mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                return false; // Code is disabled after data load, so no need to check same document

            SAPbobsCOM.Recordset oRS =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            string safeCode = code.Replace("'", "''");

            string query = $@"
                            SELECT 1 
                            FROM ""@FIL_MH_OCOM"" 
                            WHERE ""Code"" = '{safeCode}'";

            oRS.DoQuery(query);

            return !oRS.EoF;
        }

        private bool IsDuplicatePantoneCode(string pantone, string currentCode)
        {
            SAPbobsCOM.Recordset oRS =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            string safePantone = pantone.Replace("'", "''");
            string safeCode = currentCode.Replace("'", "''");

            string query = $@"
                            SELECT 1 
                            FROM ""@FIL_MH_OCOM"" 
                            WHERE ""U_PANTONE"" = '{safePantone}'
                              AND ""Code"" <> '{safeCode}'";

            oRS.DoQuery(query);

            return !oRS.EoF;
        }
    }
}
