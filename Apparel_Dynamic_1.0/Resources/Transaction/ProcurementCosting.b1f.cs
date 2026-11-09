using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;

namespace Apparel_Dynamic_1._0.Resources.Transaction
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Transaction.ProcurementCosting", "Resources/Transaction/ProcurementCosting.b1f")]
    class ProcurementCosting : UserFormBase
    {
        public ProcurementCosting()
        {
        }



        private SAPbouiCOM.StaticText STSTYLCD, STYLDESC, STCUSTCD, STCUSTNM, STDRFTNO, STCADNO, STDOCNUM, STDOCDAT, STVERSON, STODRQTY, STOLRNCE, STTLQTY, STFOB, STREMRKS, STCOLOR, STCONTNT, STLPRCST, STTLCSEL;

       

        private SAPbouiCOM.EditText ETSTYLCD, ETYLDESC, ETSLNTRY, ETCUSTCD, ETCUSTNM, ETDRFTNO, ETDFNTRY, ETCADNO, ETCDNTRY, ETDOCNUM, ETDOCDAT, ETVERSON, ETODRQTY, ETOLRNCE, ETTLQTY, ETDOCTRY, ETREMRKS, ETLPRCST, ETTLCSEL;



        private SAPbouiCOM.ComboBox CBSERIES;

        private SAPbouiCOM.LinkedButton LKSTYLCD, LKCUSTCD, LKCADNO, LKDRFTNO;

        private SAPbouiCOM.Folder TABFAB, TABTRMS, TABOTCST, TABPRCST, TABCSTEL, TABCOMM, TABSUMM, TABVRSN, TABTMFAB, TABTPTRM, TABATTCH;

        private SAPbouiCOM.Matrix MTXFOB, MTXATTCH, MTXCOLOR, MTXTMFAB, MTXTRMS, MTXOTCST, MTXPRCST, MTXCSTEL, MTXSUMRY, MTXCOMSN, MTXTMTRM;

        private SAPbouiCOM.Grid GRDFAB, GRDVRSN;

        private SAPbouiCOM.Button ADDButton, BTNCANCEL, BTNLDFAB, BTNLDCEL, BTNSAVE, BTVRSN, BRWSBTN, DISPBTN, DELBTN;


        public override void OnInitializeComponent()
        {
            //        StaticText
            this.STSTYLCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLCD").Specific));
            this.STYLDESC = ((SAPbouiCOM.StaticText)(this.GetItem("STYLDESC").Specific));
            this.STCUSTCD = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTCD").Specific));
            this.STCUSTNM = ((SAPbouiCOM.StaticText)(this.GetItem("STCUSTNM").Specific));
            this.STDRFTNO = ((SAPbouiCOM.StaticText)(this.GetItem("STDRFTNO").Specific));
            this.STCADNO = ((SAPbouiCOM.StaticText)(this.GetItem("STCADNO").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STDOCDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.STVERSON = ((SAPbouiCOM.StaticText)(this.GetItem("STVERSON").Specific));
            this.STODRQTY = ((SAPbouiCOM.StaticText)(this.GetItem("STODRQTY").Specific));
            this.STOLRNCE = ((SAPbouiCOM.StaticText)(this.GetItem("STOLRNCE").Specific));
            this.STTLQTY = ((SAPbouiCOM.StaticText)(this.GetItem("STTLQTY").Specific));
            this.STFOB = ((SAPbouiCOM.StaticText)(this.GetItem("STFOB").Specific));
            this.STREMRKS = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRKS").Specific));
            this.STCOLOR = ((SAPbouiCOM.StaticText)(this.GetItem("STCOLOR").Specific));
            this.STCONTNT = ((SAPbouiCOM.StaticText)(this.GetItem("STCONTNT").Specific));
            this.STLPRCST = ((SAPbouiCOM.StaticText)(this.GetItem("STLPRCST").Specific));
            this.STTLCSEL = ((SAPbouiCOM.StaticText)(this.GetItem("STTLCSEL").Specific));
            //        EditText
            this.ETSTYLCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLCD").Specific));
            this.ETSTYLCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSTYLCD_ChooseFromListAfter);
            this.ETYLDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETYLDESC").Specific));
            this.ETSLNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETSLNTRY").Specific));
            this.ETCUSTCD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTCD").Specific));
            this.ETCUSTCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETCUSTCD_ChooseFromListAfter);
            this.ETCUSTCD.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETCUSTCD_ChooseFromListBefore);
            this.ETCUSTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTNM").Specific));
            this.ETDRFTNO = ((SAPbouiCOM.EditText)(this.GetItem("ETDRFTNO").Specific));
            this.ETDRFTNO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETDRFTNO_ChooseFromListAfter);
            this.ETDRFTNO.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETDRFTNO_ChooseFromListBefore);
            this.ETDFNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDFNTRY").Specific));
            this.ETCADNO = ((SAPbouiCOM.EditText)(this.GetItem("ETCADNO").Specific));
            this.ETCDNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETCDNTRY").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETDOCDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.ETVERSON = ((SAPbouiCOM.EditText)(this.GetItem("ETVERSON").Specific));
            this.ETODRQTY = ((SAPbouiCOM.EditText)(this.GetItem("ETODRQTY").Specific));
            this.ETOLRNCE = ((SAPbouiCOM.EditText)(this.GetItem("ETOLRNCE").Specific));
            this.ETTLQTY = ((SAPbouiCOM.EditText)(this.GetItem("ETTLQTY").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETREMRKS = ((SAPbouiCOM.EditText)(this.GetItem("ETREMRKS").Specific));
            this.ETLPRCST = ((SAPbouiCOM.EditText)(this.GetItem("ETLPRCST").Specific));
            this.ETTLCSEL = ((SAPbouiCOM.EditText)(this.GetItem("ETTLCSEL").Specific));
            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            //         LinkedButton
            this.LKSTYLCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSTYLCD").Specific));
            this.LKCUSTCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCUSTCD").Specific));
            this.LKCADNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCADNO").Specific));
            this.LKDRFTNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKDRFTNO").Specific));
            //        Folder
            this.TABFAB = ((SAPbouiCOM.Folder)(this.GetItem("TABFAB").Specific));
            this.TABTRMS = ((SAPbouiCOM.Folder)(this.GetItem("TABTRMS").Specific));
            this.TABOTCST = ((SAPbouiCOM.Folder)(this.GetItem("TABOTCST").Specific));
            this.TABPRCST = ((SAPbouiCOM.Folder)(this.GetItem("TABPRCST").Specific));
            this.TABCSTEL = ((SAPbouiCOM.Folder)(this.GetItem("TABCSTEL").Specific));
            this.TABCOMM = ((SAPbouiCOM.Folder)(this.GetItem("TABCOMM").Specific));
            this.TABSUMM = ((SAPbouiCOM.Folder)(this.GetItem("TABSUMM").Specific));
            this.TABVRSN = ((SAPbouiCOM.Folder)(this.GetItem("TABVRSN").Specific));
            this.TABTMFAB = ((SAPbouiCOM.Folder)(this.GetItem("TABTMFAB").Specific));
            this.TABTPTRM = ((SAPbouiCOM.Folder)(this.GetItem("TABTPTRM").Specific));
            //        Matrix
            this.MTXFOB = ((SAPbouiCOM.Matrix)(this.GetItem("MTXFOB").Specific));
            this.MTXCOLOR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCOLOR").Specific));
            this.MTXTMFAB = ((SAPbouiCOM.Matrix)(this.GetItem("MTXTMFAB").Specific));
            this.MTXTRMS = ((SAPbouiCOM.Matrix)(this.GetItem("MTXTRMS").Specific));
            this.MTXOTCST = ((SAPbouiCOM.Matrix)(this.GetItem("MTXOTCST").Specific));
            this.MTXPRCST = ((SAPbouiCOM.Matrix)(this.GetItem("MTXPRCST").Specific));
            this.MTXCSTEL = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCSTEL").Specific));
            this.MTXSUMRY = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSUMRY").Specific));
            this.MTXCOMSN = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCOMSN").Specific));
            this.MTXTMTRM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXTMTRM").Specific));
            //        Grid
            this.GRDFAB = ((SAPbouiCOM.Grid)(this.GetItem("GRDFAB").Specific));
            this.GRDVRSN = ((SAPbouiCOM.Grid)(this.GetItem("GRDVRSN").Specific));
            //        Button
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.BTNCANCEL = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNLDFAB = ((SAPbouiCOM.Button)(this.GetItem("BTNLDFAB").Specific));
            this.BTNLDCEL = ((SAPbouiCOM.Button)(this.GetItem("BTNLDCEL").Specific));
            this.BTNSAVE = ((SAPbouiCOM.Button)(this.GetItem("BTNSAVE").Specific));
            this.BTVRSN = ((SAPbouiCOM.Button)(this.GetItem("BTVRSN").Specific));
            this.TABATTCH = ((SAPbouiCOM.Folder)(this.GetItem("TABATTCH").Specific));
            this.MTXATTCH = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTCH").Specific));
            this.BRWSBTN = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.DISPBTN = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.DELBTN = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new SAPbouiCOM.Framework.FormBase.ResizeAfterHandler(this.Form_ResizeAfter);
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }



        private void OnCustomInitialize()
        {

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = null;
            bool frozen = false;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                oForm.Freeze(true);
                frozen = true;

                RefreshOtherCostMatrixEditability(oForm);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Procurement Costing DataLoadAfter Error: {ex.Message}");
            }
            finally
            {
                if (frozen)
                    oForm.Freeze(false);
            }
        }


        //_____________________________________________________________________CFL__________________________________________________________



        private void ETDRFTNO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbobsCOM.Recordset oRS = null;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                    return;

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                string docNum = dt.GetValue("DocNum", 0).ToString().Trim();
                string docEntry = dt.GetValue("DocEntry", 0).ToString().Trim();
                string styleCode = dt.GetValue("U_STYLECODE", 0).ToString().Trim();
               

                SAPbouiCOM.EditText ETDRFTNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETDRFTNO").Specific;
                ETDRFTNO.Value = docNum;

                SAPbouiCOM.EditText ETDFNTRY = (SAPbouiCOM.EditText)oForm.Items.Item("ETDFNTRY").Specific;
                ETDFNTRY.Value = docEntry;

                SAPbouiCOM.EditText ETCADNO = (SAPbouiCOM.EditText)oForm.Items.Item("ETCADNO").Specific;
                SAPbouiCOM.EditText ETCDNTRY = (SAPbouiCOM.EditText)oForm.Items.Item("ETCDNTRY").Specific;

                ETCADNO.Value = "";
                ETCDNTRY.Value = "";

                string safeStyleCode = styleCode.Replace("'", "''");
               

                string query = $@"SELECT TOP 1 ""DocNum"", ""DocEntry"" FROM ""@FIL_DH_CADFABCN"" WHERE ""U_STYLECODE"" = '{safeStyleCode}' AND ""U_SQNO"" = '{docNum}' ORDER BY ""DocEntry"" DESC";

                oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                oRS.DoQuery(query);

                if (!oRS.EoF)
                {
                    ETCADNO.Value = oRS.Fields.Item("DocNum").Value.ToString();
                    ETCDNTRY.Value = oRS.Fields.Item("DocEntry").Value.ToString();
                }
                else
                {
                    Global.GFunc.ShowWarning("No CAD Fabric Consumption record found for the selected Draft.");
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Draft ChooseFromListAfter Error: {ex.Message}");
            }
            finally
            {
                if (oRS != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRS);
            }
        }

        private void ETDRFTNO_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_DRFT")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                    string styleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific).Value.Trim();
                    string customerCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCUSTCD").Specific).Value.Trim();

                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();

                    SAPbouiCOM.Condition oCon1 = oCons.Add();
                    oCon1.Alias = "U_STYLECODE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = styleCode;
                    oCon1.Relationship = SAPbouiCOM.BoConditionRelationship.cr_AND;

                    SAPbouiCOM.Condition oCon2 = oCons.Add();
                    oCon2.Alias = "CardCode";
                    oCon2.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon2.CondVal = customerCode;

                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Error filtering Draft CFL: {ex.Message}");
                BubbleEvent = false;
            }
        }


        private void ETCUSTCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;

            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string cusCode = dt.GetValue("CardCode", 0).ToString();
            string cusDesc = dt.GetValue("CardName", 0).ToString();
            

            SAPbouiCOM.EditText ETCUSTCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSTCD").Specific;
            ETCUSTCD.Value = cusCode;

            SAPbouiCOM.EditText ETCUSTNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSTNM").Specific;
            ETCUSTNM.Value = cusDesc;

            LoadOtherCostParameters(oForm, cusCode);
        }

        private void ETCUSTCD_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
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

        private void ETSTYLCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string styleCode = dt.GetValue("U_STYLECODE", 0).ToString();
            string styleDesc = dt.GetValue("U_STYLENM", 0).ToString();
            string stylEntry = dt.GetValue("DocEntry", 0).ToString();

            SAPbouiCOM.EditText ETSTYLCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific;
            ETSTYLCD.Value = styleCode;

            SAPbouiCOM.EditText ETYLDESC = (SAPbouiCOM.EditText)oForm.Items.Item("ETYLDESC").Specific;
            ETYLDESC.Value = styleDesc;

            SAPbouiCOM.EditText ETSLNTRY = (SAPbouiCOM.EditText)oForm.Items.Item("ETSLNTRY").Specific;
            ETSLNTRY.Value = stylEntry;

        }

      

       

        //_________________________________________________________User Define Function___________________________________________________________________________________________________________________________

        private void LoadOtherCostParameters(SAPbouiCOM.Form oForm, string customerCode)
        {
            SAPbobsCOM.Recordset oRS = null;
            bool frozen = false;

            try
            {
                if (string.IsNullOrWhiteSpace(customerCode))
                    return;

                string safeCustomerCode = customerCode.Replace("'", "''");
                string version = ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value.Trim();
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;
                SAPbouiCOM.DBDataSource oDBDataSource = oForm.DataSources.DBDataSources.Item("@FIL_DR_PCSOTCST");

                string query = $@"
                                SELECT
                                    R.""U_PRMCODE"",
                                    R.""U_BASEDON"",
                                    R.""U_EDITABLE"",
                                    R.""U_PRCNTG"",
                                    R.""U_VALUE""
                                FROM ""@FIL_MH_CSOTHCST"" H
                                INNER JOIN ""@FIL_MR_CSOTHCST"" R ON H.""Code"" = R.""Code""
                                WHERE H.""Code"" = '{safeCustomerCode}'
                                AND IFNULL(R.""U_PRMCODE"", '') <> ''
                                ORDER BY R.""LineId""";

                oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                oRS.DoQuery(query);

                if (oRS.RecordCount == 0)
                {
                    oForm.Freeze(true);
                    frozen = true;

                    oMatrix.Clear();
                    oDBDataSource.Clear();

                    Global.GFunc.ShowError($"No Other Cost Parameters found for customer '{customerCode}'.");
                    return;
                }

                oForm.Freeze(true);
                frozen = true;

                oMatrix.Clear();
                oDBDataSource.Clear();

                int row = 0;

                while (!oRS.EoF)
                {
                    oDBDataSource.InsertRecord(row);

                    oDBDataSource.SetValue("LineId", row, (row + 1).ToString());
                    oDBDataSource.SetValue("U_PARAMTR", row, Convert.ToString(oRS.Fields.Item("U_PRMCODE").Value).Trim());
                    oDBDataSource.SetValue("U_BASEDON", row, Convert.ToString(oRS.Fields.Item("U_BASEDON").Value).Trim());
                    oDBDataSource.SetValue("U_EDITABLE", row, Convert.ToString(oRS.Fields.Item("U_EDITABLE").Value).Trim());
                    oDBDataSource.SetValue("U_PRCNTG", row, Convert.ToString(oRS.Fields.Item("U_PRCNTG").Value).Trim());
                    oDBDataSource.SetValue("U_VALUE", row, Convert.ToString(oRS.Fields.Item("U_VALUE").Value).Trim());
                    oDBDataSource.SetValue("U_VERSION", row, version);

                    row++;
                    oRS.MoveNext();
                }

                oMatrix.LoadFromDataSource();
                RefreshOtherCostMatrixEditability(oForm);

                Application.SBO_Application.StatusBar.SetText($"{row} Other Cost Parameters loaded successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Load Other Cost Parameters Error: {ex.Message}");
            }
            finally
            {
                if (frozen)
                    oForm.Freeze(false);

                if (oRS != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRS);
            }
        }

        private void RefreshOtherCostMatrixEditability(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;

                int paramColumn = GetOtherCostColumnIndex(oMatrix, "CLPARAM");
                int basedOnColumn = GetOtherCostColumnIndex(oMatrix, "CLBASDON");
                int editableColumn = GetOtherCostColumnIndex(oMatrix, "CLEDITBL");
                int percentageColumn = GetOtherCostColumnIndex(oMatrix, "CLPERCN");
                int valueColumn = GetOtherCostColumnIndex(oMatrix, "CLVALUE");
                int versionColumn = GetOtherCostColumnIndex(oMatrix, "CLVERSN");

                for (int row = 1; row <= oMatrix.RowCount; row++)
                {
                    string basedOn = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLBASDON").Cells.Item(row).Specific).Value.Trim();
                    string editable = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLEDITBL").Cells.Item(row).Specific).Value.Trim();

                    bool isEditable = editable.Equals("Y", StringComparison.OrdinalIgnoreCase);
                    bool isPercentage = basedOn.Equals("P", StringComparison.OrdinalIgnoreCase) || basedOn.Equals("Percentage", StringComparison.OrdinalIgnoreCase);
                    bool isValue = basedOn.Equals("V", StringComparison.OrdinalIgnoreCase) || basedOn.Equals("Value", StringComparison.OrdinalIgnoreCase);

                    bool enablePercentage = isEditable && isPercentage;
                    bool enableValue = isEditable && isValue;

                    oMatrix.CommonSetting.SetCellEditable(row, paramColumn, false);
                    oMatrix.CommonSetting.SetCellEditable(row, basedOnColumn, false);
                    oMatrix.CommonSetting.SetCellEditable(row, editableColumn, false);
                    oMatrix.CommonSetting.SetCellEditable(row, percentageColumn, enablePercentage);
                    oMatrix.CommonSetting.SetCellEditable(row, valueColumn, enableValue);
                    oMatrix.CommonSetting.SetCellEditable(row, versionColumn, false);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"Refresh Other Cost Matrix Editability Error: {ex.Message}");
            }
        }

        private int GetOtherCostColumnIndex(SAPbouiCOM.Matrix oMatrix, string columnUID)
        {
            for (int i = 1; i <= oMatrix.Columns.Count; i++)
            {
                if (oMatrix.Columns.Item(i).UniqueID == columnUID)
                    return i;
            }

            throw new Exception($"Matrix column '{columnUID}' not found.");
        }




        //_________________________________________________________________________Form Resize ______________________________________________
        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            bool frozen = false;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);
                frozen = true;

                // Original B1F: form = 1014 x 470, folder container Item_34 = 976 x 277.
                SAPbouiCOM.Item tabArea = oForm.Items.Item("Item_34");
                tabArea.Width = Math.Max(760, oForm.Width - 38);

                // Reserve space for the Add/Cancel buttons and Remarks (outside the tab).
                // ClientHeight excludes the window title bar; Height does not.
                int footerHeight = Math.Max(oForm.Items.Item("ETREMRKS").Height, oForm.Items.Item("1").Height);
                int footerTop = oForm.ClientHeight - footerHeight - 12;
                tabArea.Height = Math.Max(210, footerTop - tabArea.Top - 6);

                int areaLeft = tabArea.Left;
                int areaTop = tabArea.Top;
                int areaRight = areaLeft + tabArea.Width;
                int areaBottom = areaTop + tabArea.Height;
                int widthDifference = tabArea.Width - 976;

                // The first row: FOB + Color.
                int fobLeft = areaLeft + 17;
                int matrixTop = areaTop + 42;
                int rowHeight = Math.Max(45, (int)Math.Round(tabArea.Height * 61.0 / 277.0));
                int fobWidth = Math.Max(120, 150 + (int)Math.Round(widthDifference * 0.20));
                int colorBoundary = areaRight - 287;
                int fobColorGap = tabArea.Width >= 850 ? 64 : 25;
                int colorRightGap = tabArea.Width >= 850 ? 129 : 50;
                int colorLeft = fobLeft + fobWidth + fobColorGap;
                int colorWidth = colorBoundary - colorRightGap - colorLeft;

                SAPbouiCOM.Item fobItem = oForm.Items.Item("MTXFOB");
                fobItem.Left = fobLeft;
                fobItem.Top = matrixTop;
                fobItem.Width = fobWidth;
                fobItem.Height = rowHeight;

                SAPbouiCOM.Item colorItem = oForm.Items.Item("MTXCOLOR");
                colorItem.Left = colorLeft;
                colorItem.Top = matrixTop - 1;
                colorItem.Width = colorWidth;
                colorItem.Height = rowHeight + 1;

                oForm.Items.Item("STFOB").Left = fobLeft;
                oForm.Items.Item("STFOB").Top = areaTop + 25;
                oForm.Items.Item("STCOLOR").Left = colorLeft + 3;
                oForm.Items.Item("STCOLOR").Top = areaTop + 24;

                // The second row begins below the first row, never inside it.
                int contentTop = matrixTop + rowHeight + 5;
                int gridTop = contentTop + 19;
                int saveTop = areaBottom - 35;
                int gridHeight = saveTop - gridTop - 8;

                oForm.Items.Item("STCONTNT").Left = fobLeft;
                oForm.Items.Item("STCONTNT").Top = contentTop;

                SAPbouiCOM.Item gridItem = oForm.Items.Item("GRDFAB");
                gridItem.Left = fobLeft;
                gridItem.Top = gridTop;
                gridItem.Width = tabArea.Width - 35;
                gridItem.Height = gridHeight;

                SAPbouiCOM.Item saveItem = oForm.Items.Item("BTNSAVE");
                saveItem.Left = areaLeft + 39;
                saveItem.Top = saveTop;

                // Load Fabrics button: bottom-right, aligned with Save button.
                SAPbouiCOM.Item loadFabricsItem = oForm.Items.Item("BTNLDFAB");
                loadFabricsItem.Left = areaRight - loadFabricsItem.Width - 28;
                loadFabricsItem.Top = saveTop;

                // Place footer items within the usable client area, below the tab.
                oForm.Items.Item("1").Top = footerTop;
                oForm.Items.Item("2").Top = footerTop;
                oForm.Items.Item("STREMRKS").Top = footerTop + 2;
                oForm.Items.Item("ETREMRKS").Top = footerTop;

                MTXFOB.AutoResizeColumns();
                MTXCOLOR.AutoResizeColumns();
                GRDFAB.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText("Procurement Costing resize error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                if (frozen && oForm != null) oForm.Freeze(false);
            }
        }

    }
}
