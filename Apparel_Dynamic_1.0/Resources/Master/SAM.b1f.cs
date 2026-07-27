using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;

namespace Apparel_Dynamic_1._0.Resources.Master
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Master.SAM", "Resources/Master/SAM.b1f")]
    class SAM : UserFormBase
    {
        public SAM()
        {
        }

        private SAPbouiCOM.StaticText STCODE, STDESC;
        private SAPbouiCOM.EditText ETCODE, ETDESC, ETDOCTRY, ETSLNTRY, ETSLCODE, ETSLDESC;
        private SAPbouiCOM.Folder FOLSAM, FOLCPM;
        private SAPbouiCOM.Button ADDButton, CancelButton;



        private SAPbouiCOM.Matrix MTXSAM;
        private SAPbouiCOM.Grid GRDCPM;

        public override void OnInitializeComponent()
        {
            this.STCODE = ((SAPbouiCOM.StaticText)(this.GetItem("STCODE").Specific));
            this.STDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STDESC").Specific));
            this.ETCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETCODE").Specific));
            this.ETCODE.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCODE_ChooseFromListAfter);
            this.ETDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETDESC").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.FOLSAM = ((SAPbouiCOM.Folder)(this.GetItem("FOLSAM").Specific));
            this.FOLCPM = ((SAPbouiCOM.Folder)(this.GetItem("FOLCPM").Specific));
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.MTXSAM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSAM").Specific));
            this.GRDCPM = ((SAPbouiCOM.Grid)(this.GetItem("GRDCPM").Specific));
            this.ETSLNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETSLNTRY").Specific));
            this.ETSLCODE = ((SAPbouiCOM.EditText)(this.GetItem("ETSLCODE").Specific));
            this.ETSLDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETSLDESC").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
        }



        private void OnCustomInitialize()
        {

        }

        private void ADDButton_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            throw new System.NotImplementedException();

        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            throw new System.NotImplementedException();

        }

        private void ETCODE_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                    return;

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg =
                    (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

                SAPbouiCOM.DataTable selectedData = cflArg.SelectedObjects;

                if (selectedData == null || selectedData.Rows.Count == 0)
                    return;

                oForm.Freeze(true);

                string styleCode = Convert.ToString(selectedData.GetValue("U_STYLECODE", 0)).Trim();
                string styleName = Convert.ToString(selectedData.GetValue("U_STYLENM", 0)).Trim();
                string prdGrp = Convert.ToString(selectedData.GetValue("U_PRGROUP", 0)).Trim();
                string routeCode = Convert.ToString(selectedData.GetValue("U_ROUTESTAGE", 0)).Trim();
                string docEntry = Convert.ToString(selectedData.GetValue("DocEntry", 0)).Trim();

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value = styleCode;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDESC").Specific).Value = styleName;

                ETSLCODE.Value = styleCode;
                ETSLDESC.Value = styleName;
                ETSLNTRY.Value = docEntry;

                LoadRouteStagesToMatrix(oForm, routeCode);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Style selection error: " + ex);
            }
            finally
            {
                if (oForm != null)
                    oForm.Freeze(false);
            }
        }

        //________________________________________________________________ User Defined Method____________________________________________________
        private void LoadRouteStagesToMatrix(SAPbouiCOM.Form oForm, string routeCode)
        {
            try
            {
                SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAM").Specific;
                SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item("@FIL_MR_SAM");

                matrix.FlushToDataSource();
                db.Clear();

                if (string.IsNullOrWhiteSpace(routeCode))
                {
                    matrix.LoadFromDataSource();
                    return;
                }

                string query = $@"
                                SELECT ""LineId"",""U_STAGECODE"", ""U_STAGENAME""
                                FROM ""@FIL_MR_RSM1""
                                WHERE ""Code"" = '{routeCode.Replace("'", "''")}'
                                ORDER BY ""LineId""";

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(query);

                int row = 0;

                while (!rs.EoF)
                {
                    db.InsertRecord(row);
                    db.SetValue("LineId", row, rs.Fields.Item("LineId").Value.ToString());
                    db.SetValue("U_STAGECODE", row, rs.Fields.Item("U_STAGECODE").Value.ToString());
                    db.SetValue("U_STAGENAME", row, rs.Fields.Item("U_STAGENAME").Value.ToString());

                    row++;
                    rs.MoveNext();
                }

                matrix.LoadFromDataSource();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("LoadRouteStagesToMatrix :"+ ex);
            }
        }
    }
}
