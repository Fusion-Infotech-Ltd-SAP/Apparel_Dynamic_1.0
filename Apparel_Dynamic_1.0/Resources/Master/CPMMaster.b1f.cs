using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


        public override void OnInitializeComponent()
        {
            // Static Text
            this.STBRNDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNDCD").Specific));
            this.STPDGPCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDGPCD").Specific));
            this.STRTSGCD = ((SAPbouiCOM.StaticText)(this.GetItem("STRTSGCD").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STFRMDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STFRMDAT").Specific));
            this.STTODATE = ((SAPbouiCOM.StaticText)(this.GetItem("STTODATE").Specific));
            // Edit text
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
            // Combo box
            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            // tab
            this.TABSAMRN = ((SAPbouiCOM.Folder)(this.GetItem("TABSAMRN").Specific));
            this.TABCPM = ((SAPbouiCOM.Folder)(this.GetItem("TABCPM").Specific));
            // Matrix
            this.MTXSAMRN = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSAMRN").Specific));
            this.MTXCPM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCPM").Specific));
            // Button
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNWLN = ((SAPbouiCOM.Button)(this.GetItem("BTNWLN").Specific));
            this.BTNLDCPM = ((SAPbouiCOM.Button)(this.GetItem("BTNLDCPM").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
        }

        

        private void OnCustomInitialize()
        {

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

    }
}
