using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;

namespace Apparel_Dynamic_1._0.Resources.Setup
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Setup.ParameterMaster", "Resources/Setup/ParameterMaster.b1f")]
    class ParameterMaster : UserFormBase
    {
        public ParameterMaster()
        {
        }

        private SAPbouiCOM.Grid GRDPARAM;
        private SAPbouiCOM.ComboBox CBBSDON;
        private SAPbouiCOM.CheckBox CKACTIVE;
        private SAPbouiCOM.StaticText STCODE, STBSDON;
        private SAPbouiCOM.EditText ETCODE, ETDOCTRY;
        private SAPbouiCOM.Button ADDButton, CancelButton;



        public override void OnInitializeComponent()
        {
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STBSDON = ((SAPbouiCOM.StaticText)(this.GetItem("STBSDON").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETCODE.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETCODE_LostFocusAfter);
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.CKACTIVE = ((SAPbouiCOM.CheckBox)(this.GetItem("CKACTIVE").Specific));
            this.GRDPARAM = ((SAPbouiCOM.Grid)(this.GetItem("GRDPARAM").Specific));
            this.CBBSDON = ((SAPbouiCOM.ComboBox)(this.GetItem("CBBSDON").Specific));
            this.OnCustomInitialize();
        }

        public override void OnInitializeFormEvents()
        {
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private void OnCustomInitialize()
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
            oForm.Freeze(true);
            try
            {
                Global.GFunc.SetItemsEnabled(oForm, false, "ETCODE");
                LoadGridData(oForm,
                                "DT_PARAMST",
                                "GRDPARAM",
                                "@FIL_MH_PARMMAST",
                                "\"Code\", \"U_BASEDON\", \"U_ACTIVE\""
                            );
            }
            finally
            {
                oForm.Freeze(false);
            }

        }

        private void LoadGridData(
            SAPbouiCOM.Form oForm,
            string dataTableUid,
            string gridUid,
            string tableName,
            string columnNames)
        {
            SAPbouiCOM.DataTable dt = oForm.DataSources.DataTables.Item(dataTableUid);

            dt.ExecuteQuery($@"SELECT {columnNames} FROM ""{tableName}""");

            SAPbouiCOM.Grid grid = (SAPbouiCOM.Grid)oForm.Items.Item(gridUid).Specific;
            grid.DataTable = dt;
            grid.AutoResizeColumns();
        }


        private void ETCODE_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
                {

                    string code = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value.Trim();
                    string UCode = Global.GFunc.ToUpperCase(code);
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value = UCode;

                    if (!string.IsNullOrEmpty(UCode))
                    {

                        if (!IsValidCode(UCode, out string err))
                        {
                            Application.SBO_Application.StatusBar.SetText(err,
                                SAPbouiCOM.BoMessageTime.bmt_Short,
                                SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value = "";
                            return;
                        }

                        SAPbobsCOM.Recordset oRS =
                            (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                        string query = $@"SELECT 1 FROM ""@FIL_MH_PARMMAST"" WHERE ""Code"" = '{UCode.Replace("'", "''")}'";
                        oRS.DoQuery(query);

                        if (!oRS.EoF)
                        {
                            Application.SBO_Application.StatusBar.SetText("Code already exists!",
                                SAPbouiCOM.BoMessageTime.bmt_Short,
                                SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
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

            return true;
        }


        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            string code = oForm.DataSources.DBDataSources.Item("@FIL_MH_PARMMAST").GetValue("Code", 0);
            string basedOn = oForm.DataSources.DBDataSources.Item("@FIL_MH_PARMMAST").GetValue("U_BASEDON", 0);
            if (code == "")
            {
                Global.GFunc.ShowError("Enter Parameter Master Code");
                oForm.ActiveItem = "ETCODE";
                return BubbleEvent = false;
            }
            else if (basedOn == "")
            {
                Global.GFunc.ShowError("Select Based On");
                oForm.ActiveItem = "CBBSDON";
                return BubbleEvent = false;
            }
            return BubbleEvent;
        }
    }
}
