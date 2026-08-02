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
            this.FOLCPM.PressedAfter += new SAPbouiCOM._IFolderEvents_PressedAfterEventHandler(this.FOLCPM_PressedAfter);
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
            this.ActivateAfter += new SAPbouiCOM.Framework.FormBase.ActivateAfterHandler(this.Form_ActivateAfter);
            this.DataLoadAfter += new DataLoadAfterHandler(this.Form_DataLoadAfter);

        }

        private void Form_ActivateAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            EnableFormSettings();

        }



        private void OnCustomInitialize()
        {

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

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            SAPbouiCOM.Form oForm = null;
            SAPbobsCOM.Recordset oRecordset = null;

            try
            {
                oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(pVal.FormUID);
                ResetSAMRowColors(oForm);
                string styleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(styleCode))
                {
                    return;
                }

                string safeStyleCode = styleCode.Replace("'", "''");

                oRecordset = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string query = $@"SELECT TOP 1 C.""DocEntry"" FROM ""@FIL_DH_OPSM"" O INNER JOIN ""@FIL_DH_CPM"" C ON IFNULL(C.""U_BRAND"",'')=IFNULL(O.""U_BRAND"",'') AND IFNULL(C.""U_PRDGRP"",'')=IFNULL(O.""U_PRGROUP"",'') AND IFNULL(C.""U_RSTGECODE"",'')=IFNULL(O.""U_ROUTESTAGE"",'') WHERE O.""U_STYLECODE""='{safeStyleCode}' ORDER BY C.""DocEntry"" DESC";

                oRecordset.DoQuery(query);

                if (oRecordset.RecordCount == 0)
                {
                    Global.GFunc.ShowError("No CPM Master entry was found for this Style's Brand, Product Group and Route Stage.");
                    return;
                }

                int cpmDocEntry = Convert.ToInt32(oRecordset.Fields.Item("DocEntry").Value);

                HighlightSAMOutOfRangeRows(oForm, cpmDocEntry);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Failed to validate SAM ranges: " + ex.Message);
            }
            finally
            {
                if (oRecordset != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordset);
                    oRecordset = null;
                }
            }
        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            

        }

        private void FOLCPM_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            SAPbobsCOM.Recordset oRecordset = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);

                string styleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCODE").Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(styleCode))
                {
                    Global.GFunc.ShowError("Please select a Style Code first.");
                    ClearCPMGrid(oForm);
                    return;
                }

                string safeStyleCode = styleCode.Replace("'", "''");
                oRecordset = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string styleQuery = $@"SELECT TOP 1 IFNULL(""U_ROUTESTAGE"",'') AS ""RouteStage"",IFNULL(""U_PRGROUP"",'') AS ""ProductGroup"",IFNULL(""U_BRAND"",'') AS ""Brand"" FROM ""@FIL_DH_OPSM"" WHERE ""U_STYLECODE""='{safeStyleCode}'";

                oRecordset.DoQuery(styleQuery);

                if (oRecordset.RecordCount == 0)
                {
                    Global.GFunc.ShowError("No Operation Style Master entry was found for Style Code " + styleCode + ".");
                    ClearCPMGrid(oForm);
                    return;
                }

                string routeStage = Convert.ToString(oRecordset.Fields.Item("RouteStage").Value).Trim();
                string productGroup = Convert.ToString(oRecordset.Fields.Item("ProductGroup").Value).Trim();
                string brand = Convert.ToString(oRecordset.Fields.Item("Brand").Value).Trim();

                if (string.IsNullOrWhiteSpace(routeStage) || string.IsNullOrWhiteSpace(productGroup) || string.IsNullOrWhiteSpace(brand))
                {
                    Global.GFunc.ShowError("Brand, Product Group or Route Stage is missing in the Operation Style Master.");
                    ClearCPMGrid(oForm);
                    return;
                }

                string safeRouteStage = routeStage.Replace("'", "''");
                string safeProductGroup = productGroup.Replace("'", "''");
                string safeBrand = brand.Replace("'", "''");

                string cpmMasterQuery = $@"SELECT TOP 1 ""DocEntry"" FROM ""@FIL_DH_CPM"" WHERE IFNULL(""U_BRAND"",'')='{safeBrand}' AND IFNULL(""U_PRDGRP"",'')='{safeProductGroup}' AND IFNULL(""U_RSTGECODE"",'')='{safeRouteStage}' ORDER BY ""DocEntry"" DESC";

                oRecordset.DoQuery(cpmMasterQuery);

                if (oRecordset.RecordCount == 0)
                {
                    Global.GFunc.ShowError("There is no entry in the CPM Master for Brand " + brand + ", Product Group " + productGroup + " and Route Stage " + routeStage + ".");
                    ClearCPMGrid(oForm);
                    return;
                }

                int cpmDocEntry = Convert.ToInt32(oRecordset.Fields.Item("DocEntry").Value);

                string stageRangeQuery = $@"
                                            SELECT
                                                S.""LineId"" AS ""StageLineId"",
                                                S.""U_STAGENAME"" AS ""StageName"",
                                                S.""U_SAM"" AS ""SAMValue"",
                                                R.""U_SAMCODE"" AS ""SAMCode"",
                                                CASE UPPER(TRIM(IFNULL(R.""U_SAMCODE"",'')))
                                                    WHEN 'SAM RANGE 1' THEN 1
                                                    WHEN 'SAM RANGE 2' THEN 2
                                                    WHEN 'SAM RANGE 3' THEN 3
                                                    WHEN 'SAM RANGE 4' THEN 4
                                                    WHEN 'SAM RANGE 5' THEN 5
                                                    WHEN 'SAM RANGE 6' THEN 6
                                                    WHEN 'SAM RANGE 7' THEN 7
                                                    WHEN 'SAM RANGE 8' THEN 8
                                                    WHEN 'SAM RANGE 9' THEN 9
                                                    WHEN 'SAM RANGE 10' THEN 10
                                                    ELSE 0
                                                END AS ""RangeNo""
                                            FROM ""@FIL_MR_SAM"" S
                                            LEFT JOIN ""@FIL_DR_SAMRNG"" R
                                                ON R.""DocEntry""={cpmDocEntry}
                                               AND IFNULL(S.""U_SAM"",0) BETWEEN IFNULL(R.""U_SAMFROM"",0) AND IFNULL(R.""U_SAMTO"",0)
                                            WHERE S.""Code""='{safeStyleCode}'
                                              AND IFNULL(TRIM(S.""U_STAGENAME""),'')<>''
                                            ORDER BY S.""LineId""";

                oRecordset.DoQuery(stageRangeQuery);

                if (oRecordset.RecordCount == 0)
                {
                    Global.GFunc.ShowError("No Stage SAM data was found for Style Code " + styleCode + ".");
                    ClearCPMGrid(oForm);
                    return;
                }

                List<string> dynamicColumns = new List<string>();
                HashSet<string> addedStages = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                while (!oRecordset.EoF)
                {
                    string stageName = Convert.ToString(oRecordset.Fields.Item("StageName").Value).Trim();
                    int rangeNo = Convert.ToInt32(oRecordset.Fields.Item("RangeNo").Value);

                    if (!string.IsNullOrWhiteSpace(stageName) && !addedStages.Contains(stageName))
                    {
                        string safeColumnAlias = stageName.Replace("\"", "\"\"");

                        if (rangeNo >= 1 && rangeNo <= 10)
                        {
                            dynamicColumns.Add($@"IFNULL(A.""U_CPM{rangeNo}"",0) AS ""{safeColumnAlias}""");
                        }
                        else
                        {
                            dynamicColumns.Add($@"0 AS ""{safeColumnAlias}""");
                        }

                        addedStages.Add(stageName);
                    }

                    oRecordset.MoveNext();
                }

                if (dynamicColumns.Count == 0)
                {
                    Global.GFunc.ShowError("No applicable Stage columns were found for Style Code " + styleCode + ".");
                    ClearCPMGrid(oForm);
                    return;
                }

                string finalQuery = $@"
            SELECT
                A.""LineId"" AS ""LineId"",
                A.""U_OTYPECODE"" AS ""Order Type"",
                A.""U_MINQTY"" AS ""Min Qty"",
                A.""U_MAXQTY"" AS ""Max Qty"",
                {string.Join(",", dynamicColumns)}
            FROM ""@FIL_DR_CPMD"" A
            WHERE A.""DocEntry""={cpmDocEntry}
            ORDER BY A.""LineId""";

                SAPbouiCOM.DataTable dtCPM = oForm.DataSources.DataTables.Item("DT_CPM");
                SAPbouiCOM.Grid grdCPM = (SAPbouiCOM.Grid)oForm.Items.Item("GRDCPM").Specific;

                dtCPM.Clear();
                dtCPM.ExecuteQuery(finalQuery);

                grdCPM.DataTable = dtCPM;
                grdCPM.SelectionMode = SAPbouiCOM.BoMatrixSelect.ms_Single;
                grdCPM.RowHeaders.TitleObject.Caption = "#";

                for (int i = 0; i < grdCPM.Columns.Count; i++)
                {
                    grdCPM.Columns.Item(i).Editable = false;
                }

                grdCPM.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Failed to load CPM data: " + ex.Message);
            }
            finally
            {
                if (oForm != null)
                {
                    try
                    {
                        oForm.Freeze(false);
                    }
                    catch
                    {
                    }
                }

                if (oRecordset != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordset);
                    oRecordset = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
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
        private void ResetSAMRowColors(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix =
                    (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAM").Specific;

                for (int row = 1; row <= oMatrix.RowCount; row++)
                {
                    // -1 restores the normal SAP/theme background color
                    oMatrix.CommonSetting.SetRowBackColor(row, -1);

                    // Reset font color too, in case it was changed earlier
                    oMatrix.CommonSetting.SetRowFontColor(row, -1);
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Failed to reset SAM row colors: " + ex.Message);
            }
        }
        private void HighlightSAMOutOfRangeRows(SAPbouiCOM.Form oForm, int cpmDocEntry)
        {
            SAPbobsCOM.Recordset oRecordset = null;

            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAM").Specific;

                oRecordset = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string query = $@"SELECT IFNULL(""U_SAMFROM"",0) AS ""SAMFrom"",IFNULL(""U_SAMTO"",0) AS ""SAMTo"" FROM ""@FIL_DR_SAMRNG"" WHERE ""DocEntry""={cpmDocEntry} ORDER BY ""LineId""";

                oRecordset.DoQuery(query);

                List<Tuple<double, double>> samRanges = new List<Tuple<double, double>>();

                while (!oRecordset.EoF)
                {
                    double samFrom = Convert.ToDouble(oRecordset.Fields.Item("SAMFrom").Value);
                    double samTo = Convert.ToDouble(oRecordset.Fields.Item("SAMTo").Value);

                    samRanges.Add(new Tuple<double, double>(samFrom, samTo));

                    oRecordset.MoveNext();
                }

                for (int row = 1; row <= oMatrix.RowCount; row++)
                {
                    string stageName = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSTNAME").Cells.Item(row).Specific).Value.Trim();
                    string samText = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLSAM").Cells.Item(row).Specific).Value.Trim();

                    if (string.IsNullOrWhiteSpace(stageName) && string.IsNullOrWhiteSpace(samText))
                    {
                        oMatrix.CommonSetting.SetRowBackColor(row, -1);
                        continue;
                    }

                    double samValue;
                    bool validNumber = double.TryParse(samText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out samValue);
                    bool isWithinRange = validNumber && samRanges.Any(x => samValue >= x.Item1 && samValue <= x.Item2);

                    if (!isWithinRange)
                    {
                        oMatrix.CommonSetting.SetRowBackColor(row, System.Drawing.Color.LightBlue.ToArgb());

                    }
                    else
                    {
                        oMatrix.CommonSetting.SetRowBackColor(row, -1);
                    }
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Failed to highlight SAM rows: " + ex.Message);
            }
            finally
            {
                if (oRecordset != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordset);
                    oRecordset = null;
                }
            }
        }


        private void ClearCPMGrid(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.DataTable dtCPM = oForm.DataSources.DataTables.Item("DT_CPM");
                dtCPM.Clear();
            }
            catch
            {
            }
        }

        private void EnableFormSettings()
        {
            SAPbouiCOM.Form oForm = null;
            bool isFrozen = false;

            try
            {
                oForm = (SAPbouiCOM.Form)this.UIAPIRawForm;

                oForm.Freeze(true);
                isFrozen = true;

                if (!oForm.Settings.Enabled)
                {
                    oForm.Settings.MatrixUID = "MTXSAM";
                    oForm.Settings.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Failed to enable Form Settings.\n" + ex.Message);
            }
            finally
            {
                if (oForm != null && isFrozen)
                {
                    oForm.Freeze(false);
                }
            }
        }



        private bool CheckDuplicateStyleCode(SAPbouiCOM.Form oForm, string styleCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(styleCode))
                    return true;

                string safeStyleCode = styleCode.Replace("'", "''");
                string query = $@"SELECT COUNT(*) AS ""Total"" FROM ""@FIL_MH_SAM"" WHERE ""Code"" = '{safeStyleCode}'";

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(query);

                int count = Convert.ToInt32(rs.Fields.Item("Total").Value);

                if (count > 0)
                {
                    Global.GFunc.ShowError("Style Code '" + styleCode + "' already exists.");
                    oForm.ActiveItem = "ETCODE";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("CheckDuplicateStyleCode : " + ex.Message);
                return false;
            }
        }



        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            try
            {
                string styleCode = oForm.DataSources.DBDataSources.Item("@FIL_MH_SAM").GetValue("Code", 0).Trim();

                if (string.IsNullOrWhiteSpace(styleCode))
                {
                    Global.GFunc.ShowError("Enter Style Code");
                    oForm.ActiveItem = "ETCODE";
                    return BubbleEvent = false;
                }

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE && !CheckDuplicateStyleCode(oForm, styleCode))
                    return BubbleEvent = false;


                SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAM").Specific;
                for (int row = 1; row <= matrix.RowCount; row++)
                {
                    string samValue = ((SAPbouiCOM.EditText)matrix.Columns.Item("CLSAM").Cells.Item(row).Specific).Value.Trim();

                    double sam = 0;
                    double.TryParse(samValue, out sam);

                    if (sam <= 0)
                    {
                        Global.GFunc.ShowError("SAM value must be greater than 0 at row " + row);
                        matrix.Columns.Item("CLSAM").Cells.Item(row).Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                        return BubbleEvent = false;
                    }
                }

                return BubbleEvent;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("ValidateForm : " + ex);
                return BubbleEvent = false;
            }
        }



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
