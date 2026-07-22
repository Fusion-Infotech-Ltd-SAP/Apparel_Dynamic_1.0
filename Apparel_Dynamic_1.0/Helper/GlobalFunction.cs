using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;

namespace Apparel_Dynamic_1._0.Helper
{
    class GlobalFunction
    {
        //For DocNum (CBSeries) DropDown Select After Event
        public void UpdateDocNumberBySeries(SAPbouiCOM.Form oForm, string objectCode)
        {
            try
            {
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    return;

                SAPbouiCOM.ComboBox cbSeries =
                    (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSERIES").Specific;

                SAPbouiCOM.EditText etDocNum =
                    (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;

                if (cbSeries.Selected == null ||
                    string.IsNullOrWhiteSpace(cbSeries.Selected.Value))
                    return;

                string seriesValue = cbSeries.Selected.Value.Trim();

                long docNo = oForm.BusinessObject.GetNextSerialNumber(seriesValue, objectCode);

                if (docNo <= 0)
                {
                    Global.GFunc.ShowError("Next document number not found for selected series.");
                    etDocNum.Value = string.Empty;
                    return;
                }

                etDocNum.Value = docNo.ToString();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"UpdateDocNumberBySeries Error: {ex.Message}");
            }
        }


        public void UpdateSeriesAndDocNumByDate(
        SAPbouiCOM.Form oForm,
        SAPbouiCOM.DBDataSource oDBH,
        string docDate,
        string objectCode)
        {
            try
            {
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    return;

                SAPbouiCOM.ComboBox cbSeries = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSERIES").Specific;
                SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;

                oForm.Freeze(true);

                ClearComboBox(cbSeries);

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string query = $@"
                                SELECT
                                    T0.""Series"",
                                    T0.""SeriesName"",
                                    T0.""NextNumber""
                                FROM ""NNM1"" T0
                                INNER JOIN ""OFPR"" T1
                                    ON T0.""Indicator"" = T1.""Indicator""
                                WHERE T0.""ObjectCode"" = '{objectCode}'
                                  AND T0.""Locked"" = 'N'
                                  AND TO_DATE('{docDate}', 'YYYYMMDD')
                                        BETWEEN T1.""F_RefDate"" AND T1.""T_RefDate""
                                ORDER BY T0.""Series""";

                rs.DoQuery(query);

                if (rs.RecordCount == 0)
                {
                    ClearComboBox(cbSeries);

                    oDBH.SetValue("Series", 0, "");
                    oDBH.SetValue("DocNum", 0, "");
                    etDocNum.Value = "";

                    Global.GFunc.ShowError("No valid document numbering series found for selected Doc Date.");
                    return;
                }

                string firstSeries = "";
                string firstNextNumber = "";

                while (!rs.EoF)
                {
                    string series = rs.Fields.Item("Series").Value.ToString();
                    string seriesName = rs.Fields.Item("SeriesName").Value.ToString();
                    string nextNumber = rs.Fields.Item("NextNumber").Value.ToString();

                    cbSeries.ValidValues.Add(series, seriesName);

                    if (string.IsNullOrWhiteSpace(firstSeries))
                    {
                        firstSeries = series;
                        firstNextNumber = nextNumber;
                    }

                    rs.MoveNext();
                }

                cbSeries.Select(firstSeries, SAPbouiCOM.BoSearchKey.psk_ByValue);

                long docNo = oForm.BusinessObject.GetNextSerialNumber(firstSeries, objectCode);

                if (docNo <= 0)
                {
                    if (!string.IsNullOrWhiteSpace(firstNextNumber))
                        etDocNum.Value = firstNextNumber;
                    else
                        Global.GFunc.ShowError("Next document number not found for selected series.");

                    return;
                }

                etDocNum.Value = docNo.ToString();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Series update error: " + ex.Message);
            }
            finally
            {
                try
                {
                    oForm.Freeze(false);
                }
                catch { }
            }
        }

        public void ClearComboBox(SAPbouiCOM.ComboBox combo)
        {
            try
            {
                // First deselect current selected value
                try
                {
                    combo.Select("", SAPbouiCOM.BoSearchKey.psk_ByValue);
                }
                catch { }

                for (int i = combo.ValidValues.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        combo.ValidValues.Remove(i, SAPbouiCOM.BoSearchKey.psk_Index);
                    }
                    catch { }
                }
            }
            catch { }
        }
        //Item Enable Disable
        public void SetItemsEnabled(SAPbouiCOM.Form oForm, bool enabled, params string[] itemIds)
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

        //Matrix New Line Add
        public  void EnsureLine(SAPbouiCOM.Form oForm, string matrixID, string dbTable)
        {
            SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixID).Specific;
            SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item(dbTable);
            if (matrix.RowCount == 0)
            {
                Global.GFunc.SetNewLine(matrix, db, 1, "");
            }
        }

        public  void AddLineIfLastRowHasValue(
           SAPbouiCOM.Form oForm,
           string matrixID,
           string dbTable,
           string columnName
           )
        {
            try
            {
                SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixID).Specific;
                SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item(dbTable);
                matrix.FlushToDataSource();
                int dbRowCount = db.Size;
                if (dbRowCount == 0)
                {
                    Global.GFunc.SetNewLine(matrix, db, 1, "");
                    return;
                }
                int lastDbRow = dbRowCount - 1;
                string lastValue = db.GetValue(columnName, lastDbRow).Trim();
                if (!string.IsNullOrEmpty(lastValue) && !lastValue.Equals("0.0"))
                {
                    Global.GFunc.SetNewLine(matrix, db, dbRowCount + 1, "");
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("AddLineIfLastRowHasValue Error: " + ex.Message);
            }
        }



        public string ToUpperCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            return input.ToUpper();
        }

        public  void ReleaseComObject(object comObject)
        {
            try
            {
                if (comObject != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(comObject);
                }
            }
            catch
            {
                // Ignore release exceptions
            }
            finally
            {
                comObject = null;
            }
        }

        public  void SetMatrixComboValue(SAPbouiCOM.Matrix matrix,string columnID,string query)
        {
            SAPbobsCOM.Recordset rs = null;

            try
            {
                SAPbouiCOM.Column column = matrix.Columns.Item(columnID);

                // Remove old values
                for (int i = column.ValidValues.Count - 1; i >= 0; i--)
                {
                    column.ValidValues.Remove(i, SAPbouiCOM.BoSearchKey.psk_Index);
                }

                rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(
                    SAPbobsCOM.BoObjectTypes.BoRecordset);

                rs.DoQuery(query);

                while (!rs.EoF)
                {
                    string code = rs.Fields.Item(0).Value.ToString();
                    string name = rs.Fields.Item(1).Value.ToString();

                    column.ValidValues.Add(code, name);

                    rs.MoveNext();
                }
            }
            finally
            {
                if (rs != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(rs);
                    rs = null;
                }
            }
        }

        


        public bool setComboBoxValue(SAPbouiCOM.ComboBox oComboBox, string strQry)
        {
            bool flag;
            try
            {

                int count = oComboBox.ValidValues.Count;//0
                if (count > 0)
                {
                    while (true)
                    {
                        if (count <= 0)
                        {
                            break;
                        }
                        oComboBox.ValidValues.Remove(count - 1, SAPbouiCOM.BoSearchKey.psk_Index);
                        count--;
                    }
                }
                //IN VS-CORE DOTNET WE USE DATASET- AS LIKE SAME FUNCTIONALITY, IT WILL USING RECORDSET IN SAP
                SAPbobsCOM.Recordset businessObject = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string str = Convert.ToString(oComboBox.ValidValues.Count);
                if (oComboBox.ValidValues.Count == 0)
                {

                    businessObject.DoQuery(strQry); //doquery means- executinga query
                    businessObject.MoveFirst();
                    int num2 = businessObject.RecordCount - 1; //linelevel count 
                    int num = 0;
                    while (true)
                    {
                        int num3 = num2;
                        if (num > num3)
                        {
                            break;
                        }
                        oComboBox.ValidValues.Add(Convert.ToString(businessObject.Fields.Item(0).Value), Convert.ToString(businessObject.Fields.Item(1).Value));

                        businessObject.MoveNext(); // it will move to next cursor to recordset
                        num++;
                    }
                }
                oComboBox.ExpandType = SAPbouiCOM.BoExpandType.et_ValueDescription;
                oComboBox.Item.DisplayDesc = true;
                flag = true;
            }
            catch (Exception exception1)
            {

                Application.SBO_Application.StatusBar.SetText("setComboBoxValue Function Failed:" + exception1.ToString(), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                flag = true;

            }
            return flag;
        }
        SAPbouiCOM.EditText omatcol;
        SAPbouiCOM.ComboBox omatcolb;
        public void SetNewLine(SAPbouiCOM.Matrix oMatrix, SAPbouiCOM.DBDataSource oDBDSDetail, int RowID = 1, string ColumnUID = "")
        {
            try
            {

                if (ColumnUID != "")
                {
                    omatcolb = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item(ColumnUID).Cells.Item(RowID).Specific;
                }

                if (ColumnUID.Equals(""))  //no column assign ; eventhough no values exist in previous column then also can add new lines.
                {
                    oMatrix.FlushToDataSource();
                    oMatrix.AddRow(1, -1);
                    oDBDSDetail.InsertRecord(oDBDSDetail.Size);
                    oDBDSDetail.Offset = oMatrix.VisualRowCount - 1;
                    oDBDSDetail.SetValue("LineId", oDBDSDetail.Offset, Convert.ToString(oMatrix.VisualRowCount));
                    oMatrix.SetLineData(oMatrix.VisualRowCount);
                    oMatrix.FlushToDataSource();
                }
                else if (oMatrix.VisualRowCount <= 0)  //1st time row creation
                {
                    oMatrix.FlushToDataSource();
                    oMatrix.AddRow(1, -1);//1-1=4
                    oDBDSDetail.InsertRecord(oDBDSDetail.Size);
                    oDBDSDetail.Offset = oMatrix.VisualRowCount - 1; //starting index from 0
                    oDBDSDetail.SetValue("LineId", oDBDSDetail.Offset, Convert.ToString(oMatrix.VisualRowCount));
                    oMatrix.SetLineData(oMatrix.VisualRowCount);
                    oMatrix.FlushToDataSource();
                }
                else if (!(omatcolb.Value).Equals("") && (RowID == oMatrix.VisualRowCount))  // column assigned ; only add a row when present column value is not null.
                {
                    oMatrix.FlushToDataSource();
                    oMatrix.AddRow(1, -1);
                    oDBDSDetail.InsertRecord(oDBDSDetail.Size);
                    oDBDSDetail.Offset = oMatrix.VisualRowCount - 1;
                    oDBDSDetail.SetValue("LineId", oDBDSDetail.Offset, Convert.ToString(oMatrix.VisualRowCount));
                    oMatrix.SetLineData(oMatrix.VisualRowCount);
                    //oMatrix.LoadFromDataSource();
                    oMatrix.FlushToDataSource();
                }
            }
            catch (Exception exception1)
            {

            }
        }
        public void ShowError(string ErrorMessage)
        {
            Application.SBO_Application.StatusBar.SetText(ErrorMessage, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        }
        public void ShowSuccess(string ErrorMessage)
        {
            Application.SBO_Application.StatusBar.SetText(ErrorMessage, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
        }
        public void AddRow(SAPbouiCOM.Matrix oMatrix, SAPbouiCOM.DBDataSource oDataSource)
        {

            oMatrix.FlushToDataSource();
            oDataSource.InsertRecord(oDataSource.Size);
            if (oDataSource.Size > 1)
                for (int i = oDataSource.Size - 2; i >= 0; i--)
                {
                    if (oDataSource.GetValue("U_CHARCODE", i) == "")
                        oDataSource.RemoveRecord(i);
                    else
                        break;
                }
            for (int i = 0; i < oDataSource.Size; i++)
            {
                oDataSource.SetValue("LineId", i, (i + 1).ToString());
            }
            oMatrix.Clear();
            oMatrix.LoadFromDataSource();
        }

        public int GetCodeGeneration(string TableName)
        {
            int num;
            try
            {
                SAPbobsCOM.Recordset businessObject = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                // businessObject.DoQuery("Select IFNULL(Max(IFNULL(\"DocEntry\",0)),0) + 1 Code From \"" + Global.oCompany.CompanyDB + "\".\"" + TableName.Trim().ToString().Replace("[", "").Replace("]", "") + "\"");
                //   if (Global.CF.IsSAPHANA() == true)
                //  {
                //     businessObject.DoQuery(@"Select IFNULL(Max(IFNULL(""DocEntry"",0)),0) + 1 Code From " + TableName.Trim().ToString());
                //  }
                //  else
                //  {
                string sqlQuery = string.Format("SELECT ifnull(Max({0}DocEntry{0}),0) + 1 as  {0}Code{0} from {0}" + TableName.Trim().ToString() + "{0}", '"');
                businessObject.DoQuery(sqlQuery);
                //  }
                //num=Convert.ToInt32(businessObject.Fields.Item("Code").Value)-vb.net
                num = Convert.ToInt32(businessObject.Fields.Item("Code").Value.ToString());//c# -we need to convert from object to String , then able to change whatver type of data required.

            }
            catch (Exception exception1)
            {

                Application.SBO_Application.StatusBar.SetText("GetCodeGeneration Function Failed:" + exception1.ToString(), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                num = -1;

            }
            return num;
        }

        public int GetDocNum(string TableName) //- FHR
        {
            int num;
            try
            {
                SAPbobsCOM.Recordset businessObject = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sqlQuery = string.Format("SELECT ifnull(Max({0}DocEntry{0}),0) + 1 as  {0}Code{0} from {0}" + TableName.Trim().ToString() + "{0}", '"');
                businessObject.DoQuery(sqlQuery);
                num = Convert.ToInt32(businessObject.Fields.Item("Code").Value.ToString());//c# -we need to convert from object to String , then able to change whatver type of data required.

            }
            catch (Exception exception1)
            {

                Application.SBO_Application.StatusBar.SetText("GetCodeGeneration Function Failed:" + exception1.ToString(), SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                num = -1;

            }
            return num;
        }

        public bool LoadComboBoxSeries(SAPbouiCOM.ComboBox oComboBox, string UDOID)  // tow generate a series in document type UDO.- paarmeter will be combobox and the UDO ID.
        {
            bool flag;
            try
            {
                oComboBox.ExpandType = SAPbouiCOM.BoExpandType.et_DescriptionOnly;
                oComboBox.ValidValues.LoadSeries(UDOID, SAPbouiCOM.BoSeriesMode.sf_Add);  // ONLY TO LOAD A COMBOBOX
                oComboBox.Select(0, SAPbouiCOM.BoSearchKey.psk_Index);
                oComboBox.Item.DisplayDesc = true;
                flag = true;
            }
            catch (Exception exception1)
            {
                Application.SBO_Application.SetStatusBarMessage("error");
                flag = false;

            }
            return flag;
        }
    }
}
