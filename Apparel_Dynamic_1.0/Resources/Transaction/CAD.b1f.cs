using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apparel_Dynamic_1._0.Helper;
using Apparel_Dynamic_1._0.Resources.Master;

namespace Apparel_Dynamic_1._0.Resources.Transaction
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Transaction.CAD", "Resources/Transaction/CAD.b1f")]
    class CAD : UserFormBase
    {
        private static readonly Dictionary<string, string> _cadGridBaseline = new Dictionary<string, string>();
        private static readonly Dictionary<string, Tuple<string, int>> _cadDeleteContext = new Dictionary<string, Tuple<string, int>>();

        public CAD()
        {
        }

        private SAPbouiCOM.StaticText STSTATUS, STREMRKS, STSTYLCD, STSTYLDS, STMERCHN, STDOCNUM, STDOCDAT, STDRFTNO, STSLCLR, STCDCLR;
        private SAPbouiCOM.EditText ETSLCLR, ETREMRKS, ETSTYLCD, ETMERHN, ETSTYLDS, ETDOCNUM, ETMERCNM, ETDONTRY, ETDOCDAT, ETDRFTNO, ETCDCLR, ETDOCTRY, ETSTNTRY;



        private SAPbouiCOM.ComboBox CBSERIES, CBSTATUS;



        private SAPbouiCOM.Folder FOLMERCON, FOLCANCON, FOLTEMP;



        private SAPbouiCOM.Matrix MTXMRCON, MTXCDCLR, MTXCDCON;



        private SAPbouiCOM.Grid GRDCDCON, GRDSIZE, GRDSCLR;

        private SAPbouiCOM.LinkedButton LKSTYLNO, LKDRFTOR, LKMRCHND;



        private SAPbouiCOM.Button ADDButton, CancelButton, BTNFETCH, BTNLDCAD, BTNSAVE, BTNLDCLR;



        public override void OnInitializeComponent()
        {
            //                          Static text
            this.STSTATUS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTATUS").Specific));
            this.STSTYLCD = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLCD").Specific));
            this.STSTYLDS = ((SAPbouiCOM.StaticText)(this.GetItem("STSTYLDS").Specific));
            this.STMERCHN = ((SAPbouiCOM.StaticText)(this.GetItem("STMERHN").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STDOCDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCDAT").Specific));
            this.STDRFTNO = ((SAPbouiCOM.StaticText)(this.GetItem("STDRFTNO").Specific));
            this.STSLCLR = ((SAPbouiCOM.StaticText)(this.GetItem("STSLCLR").Specific));
            this.STCDCLR = ((SAPbouiCOM.StaticText)(this.GetItem("STCDCLR").Specific));
            //                          Edittext
            this.ETSLCLR = ((SAPbouiCOM.EditText)(this.GetItem("ETSLCLR").Specific));
            this.ETSTYLCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLCD").Specific));
            this.ETSTYLCD.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETSTYLCD_ChooseFromListAfter);
            this.ETSTYLDS = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLDS").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETDOCDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCDAT").Specific));
            this.ETDOCDAT.LostFocusAfter += new SAPbouiCOM._IEditTextEvents_LostFocusAfterEventHandler(this.ETDOCDAT_LostFocusAfter);
            this.ETDRFTNO = ((SAPbouiCOM.EditText)(this.GetItem("ETDRFTNO").Specific));
            this.ETDRFTNO.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETDRFTNO_ChooseFromListAfter);
            this.ETDRFTNO.ChooseFromListBefore += new SAPbouiCOM._IEditTextEvents_ChooseFromListBeforeEventHandler(this.ETDRFTNO_ChooseFromListBefore);
            this.ETCDCLR = ((SAPbouiCOM.EditText)(this.GetItem("ETCDCLR").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            //                          Combo box
            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            this.CBSERIES.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.CBSERIES_ComboSelectAfter);
            this.CBSTATUS = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSTATUS").Specific));
            //                          Folder
            //    this.FOLMERCON = ((SAPbouiCOM.Folder)(this.GetItem("FOLMERCON").Specific));
            //    this.FOLCANCON = ((SAPbouiCOM.Folder)(this.GetItem("FOLCANCN").Specific));
            this.FOLMERCON = ((SAPbouiCOM.Folder)(this.GetItem("FOLMERCON").Specific));
            this.FOLMERCON.ClickAfter += new SAPbouiCOM._IFolderEvents_ClickAfterEventHandler(this.CADFolder_ClickAfter);
            this.FOLCANCON = ((SAPbouiCOM.Folder)(this.GetItem("FOLCANCN").Specific));
            this.FOLCANCON.ClickAfter += new SAPbouiCOM._IFolderEvents_ClickAfterEventHandler(this.CADFolder_ClickAfter);
            this.FOLTEMP = ((SAPbouiCOM.Folder)(this.GetItem("FOLTEMP").Specific));
            //                          Matrix
            this.MTXMRCON = ((SAPbouiCOM.Matrix)(this.GetItem("MTXMRCON").Specific));
            this.MTXMRCON.LostFocusAfter += new SAPbouiCOM._IMatrixEvents_LostFocusAfterEventHandler(this.MTXMRCON_LostFocusAfter);
            this.MTXMRCON.ChooseFromListAfter += new SAPbouiCOM._IMatrixEvents_ChooseFromListAfterEventHandler(this.MTXMRCON_ChooseFromListAfter);
            this.MTXMRCON.ChooseFromListBefore += new SAPbouiCOM._IMatrixEvents_ChooseFromListBeforeEventHandler(this.MTXMRCON_ChooseFromListBefore);
            this.MTXCDCLR = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCDCLR").Specific));
            this.MTXCDCLR.DoubleClickAfter += new SAPbouiCOM._IMatrixEvents_DoubleClickAfterEventHandler(this.MTXCDCLR_DoubleClickAfter);
            this.MTXCDCON = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCDCON").Specific));
            //                          Grid
            this.GRDCDCON = ((SAPbouiCOM.Grid)(this.GetItem("GRDCDCON").Specific));
            this.GRDCDCON.ValidateAfter += new SAPbouiCOM._IGridEvents_ValidateAfterEventHandler(this.GRDCDCON_ValidateAfter);
            this.GRDCDCON.ChooseFromListBefore += new SAPbouiCOM._IGridEvents_ChooseFromListBeforeEventHandler(this.GRDCDCON_ChooseFromListBefore);
            this.GRDCDCON.ChooseFromListAfter += new SAPbouiCOM._IGridEvents_ChooseFromListAfterEventHandler(this.GRDCDCON_ChooseFromListAfter);
            this.GRDSIZE = ((SAPbouiCOM.Grid)(this.GetItem("GRDSIZE").Specific));
            //                          Button
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.ADDButton.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.ADDButton_PressedAfter);
            this.ADDButton.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.ADDButton_PressedBefore);
            this.CancelButton = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNFETCH = ((SAPbouiCOM.Button)(this.GetItem("BTNFETCH").Specific));
            this.BTNFETCH.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNFETCH_PressedAfter);
            this.BTNLDCAD = ((SAPbouiCOM.Button)(this.GetItem("BTNLDCAD").Specific));
            this.BTNLDCAD.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNLDCAD_PressedAfter);
            this.BTNSAVE = ((SAPbouiCOM.Button)(this.GetItem("BTNSAVE").Specific));
            this.BTNSAVE.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNSAVE_PressedAfter);
            this.GRDSCLR = ((SAPbouiCOM.Grid)(this.GetItem("GRDSCLR").Specific));
            this.GRDSCLR.DoubleClickAfter += new SAPbouiCOM._IGridEvents_DoubleClickAfterEventHandler(this.GRDSCLR_DoubleClickAfter);
            this.ETSTNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETSTNTRY").Specific));
            this.ETMERCNM = ((SAPbouiCOM.EditText)(this.GetItem("ETMERCNM").Specific));
            this.ETDONTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDONTRY").Specific));
            this.ETMERHN = ((SAPbouiCOM.EditText)(this.GetItem("ETMERHN").Specific));
            this.ETMERHN.ChooseFromListAfter += new SAPbouiCOM._IEditTextEvents_ChooseFromListAfterEventHandler(this.ETMERHN_ChooseFromListAfter);
            this.LKSTYLNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSTYLNO").Specific));
            this.LKSTYLNO.PressedAfter += new SAPbouiCOM._ILinkedButtonEvents_PressedAfterEventHandler(this.LKSTYLNO_PressedAfter);
            this.LKDRFTOR = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKDRFTOR").Specific));
            this.LKMRCHND = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKMRCHND").Specific));
            this.BTNLDCLR = ((SAPbouiCOM.Button)(this.GetItem("BTNLDCLR").Specific));
            this.BTNLDCLR.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.BTNLDCLR_PressedAfter);
            this.STREMRKS = ((SAPbouiCOM.StaticText)(this.GetItem("STREMRKS").Specific));
            this.ETREMRKS = ((SAPbouiCOM.EditText)(this.GetItem("ETREMRKS").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new SAPbouiCOM.Framework.FormBase.ResizeAfterHandler(this.Form_ResizeAfter);
            this.DataLoadAfter += new SAPbouiCOM.Framework.FormBase.DataLoadAfterHandler(this.Form_DataLoadAfter);
            this.RightClickBefore += new SAPbouiCOM.Framework.FormBase.RightClickBeforeHandler(this.Form_RightClickBefore);
            this.DataUpdateAfter += new DataUpdateAfterHandler(this.Form_DataUpdateAfter);

        }


        private void OnCustomInitialize()
        {

        }

        private void Form_DataLoadAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            LoadHeaderColourSizeInfo(pVal.FormUID);
            LoadCADConsumptionDetails(pVal.FormUID);
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM", "CBSERIES", "ETDOCDAT", "ETMERCNM", "ETSTYLDS");
            Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXMRCON", "@FIL_DR_CADMFAB", "U_ITEMCODE");

        }


        private void LKSTYLNO_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.EditText ETSMPLCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific;
            string sampleCode = ETSMPLCD.Value.Trim();
            StyleMaster style = new StyleMaster();
            style.Show();
            //styleMaster. = Global.G_UI_Application.Forms.ActiveForm;
            SAPbouiCOM.Form cForm = Application.SBO_Application.Forms.Item("FIL_FRM_STYLMSTR");
            try
            {
                cForm.Freeze(true);
                cForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                cForm.Items.Item("ETSLCODE").Enabled = true;
                SAPbouiCOM.EditText cETSLCODE = (SAPbouiCOM.EditText)cForm.Items.Item("ETSLCODE").Specific;
                cETSLCODE.Value = sampleCode;
                cForm.Items.Item("1").Click();
                cForm.Items.Item("FOLSIZE").Click();
                cForm.Freeze(false);
            }
            catch (Exception ex)
            {
                cForm.Freeze(false);
            }

        }


        private void CBSERIES_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    return;

                SAPbouiCOM.ComboBox cbSeries = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSERIES").Specific;
                SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCNUM").Specific;

                if (cbSeries.Selected == null ||
                    string.IsNullOrWhiteSpace(cbSeries.Selected.Value))
                    return;

                string seriesValue = cbSeries.Selected.Value.Trim();
                long docNo = oForm.BusinessObject.GetNextSerialNumber(seriesValue, "FIL_D_CADFABCN");

                if (docNo <= 0)
                {
                    Global.GFunc.ShowError("Next document number not found for selected series.");
                    etDocNum.Value = "";
                    return;
                }
                etDocNum.Value = docNo.ToString();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Series change error: " + ex.Message);
            }

        }

        private void ETDOCDAT_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    return;

                string docDate = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(docDate))
                    return;

                SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_CADFABCN");
                Global.GFunc.UpdateSeriesAndDocNumByDate(oForm, oDBH, docDate, "FIL_D_CADFABCN");

            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Doc Date Series Error: " + ex.Message);
            }

        }

        private void Form_RightClickBefore(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(eventInfo.FormUID);
                if (eventInfo.ItemUID == "MTXMRCON" || eventInfo.ItemUID == "GRDCDCON")
                {
                    _cadDeleteContext[oForm.UniqueID] = Tuple.Create(eventInfo.ItemUID, eventInfo.Row);
                    oForm.EnableMenu("1293", true);
                }
                else
                {
                    _cadDeleteContext.Remove(oForm.UniqueID);
                    oForm.EnableMenu("1293", false);
                }
            }
            catch (Exception ex) { Global.GFunc.ShowError($"CAD right click error: {ex.Message}"); }
        }

        private void Form_DataUpdateAfter(ref SAPbouiCOM.BusinessObjectInfo pVal)
        {
            LoadCADConsumptionDetails(pVal.FormUID);

        }

        private void LoadCADConsumptionDetails(string formUID)
        {
            SAPbouiCOM.Form oForm = null;
            try
            {
                oForm = Application.SBO_Application.Forms.Item(formUID);
                oForm.Freeze(true);
                SAPbouiCOM.DataTable dt = EnsureCADGridSchema(oForm);
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCON").Specific;
                mtx.FlushToDataSource();
                var records = ReadStoredCAD(oForm);
                FillCADGrid(oForm, records, false);
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCDCLR").Specific).Value = "ALLColour";
                RememberCADGrid(oForm);
                DisableAllGridColumns((SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific);
            }
            catch (Exception ex) { Global.GFunc.ShowError($"CAD consumption load error: {ex.Message}"); }
            finally { if (oForm != null) oForm.Freeze(false); }
        }

        private void DisableAllGridColumns(SAPbouiCOM.Grid oGrid)
        {
            for (int i = 0; i < oGrid.Columns.Count; i++)
            {
                oGrid.Columns.Item(i).Editable = false;
            }
        }



        private void LoadHeaderColourSizeInfo(string formUID)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(formUID);
                oForm.Freeze(true);

                string docEntry =
                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETDONTRY").Specific).Value.Trim();

                if (string.IsNullOrEmpty(docEntry))
                    return;

                // Set selected colour text
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSLCLR").Specific).Value = "ALL Colour";

                SAPbouiCOM.Grid grdColour = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSCLR").Specific;
                SAPbouiCOM.Grid grdSize = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSIZE").Specific;
                SAPbouiCOM.DataTable dtColour = oForm.DataSources.DataTables.Item("DT_CLR");
                SAPbouiCOM.DataTable dtSize = oForm.DataSources.DataTables.Item("DT_SIZE");

                string colourQuery = $@"
                                        SELECT DISTINCT
                                            T0.""U_FGCOLOUR"" AS ""Colour Code"",
                                            T0.""U_FGCOLRNM"" AS ""Colour Name""
                                        FROM ""QUT1"" T0
                                        WHERE T0.""DocEntry"" = '{docEntry}'
                                          AND IFNULL(T0.""U_FGCOLOUR"", '') <> ''
                                        ORDER BY
                                            T0.""U_FGCOLOUR""";

                string sizeQuery = $@"
                                        SELECT
                                            T0.""U_FGSIZE""        AS ""Size Code"",
                                            T1.""Name""            AS ""Size Name"",
                                            SUM(T0.""Quantity"")   AS ""Quantity""
                                        FROM ""QUT1"" T0
                                        LEFT JOIN ""@FIL_MH_SIZEMSTR"" T1
                                            ON T0.""U_FGSIZE"" = T1.""Code""
                                        WHERE T0.""DocEntry"" = '{docEntry}'
                                          AND IFNULL(T0.""U_FGSIZE"", '') <> ''
                                        GROUP BY
                                            T0.""U_FGSIZE"",
                                            T1.""Name""
                                        ORDER BY
                                            T0.""U_FGSIZE""";

                dtColour.ExecuteQuery(colourQuery);
                grdColour.DataTable = dtColour;

                dtSize.ExecuteQuery(sizeQuery);
                grdSize.DataTable = dtSize;

                grdColour.AutoResizeColumns();
                grdSize.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Header colour/size load error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
            finally
            {
                if (oForm != null)
                    oForm.Freeze(false);
            }
        }

        private void BTNSAVE_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                string colour = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCDCLR").Specific).Value.Trim();
                if (string.IsNullOrWhiteSpace(colour)) 
                { Global.GFunc.ShowError("Please select CAD colour first."); 
                    return; 
                }
                oForm.Freeze(true);
                var gridRows = ReadCADGrid(oForm);
                var scope = IsAllCADColour(colour) ? ReadCADColours((SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCLR").Specific).Where(x => !IsAllCADColour(x)).ToList() : new List<string> { colour };
                if (scope.Count == 0) { Global.GFunc.ShowError("Please click Load Colour first."); return; }
                foreach (var row in gridRows)
                    if (!scope.Any(x => x.Equals(row["BSCLR"], StringComparison.OrdinalIgnoreCase))) { Global.GFunc.ShowError("Grid contains a colour outside the selected scope. Save cancelled."); return; }
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCON").Specific;
                mtx.FlushToDataSource();
                var all = ReadStoredCAD(oForm).Where(x => !scope.Any(y => y.Equals(x["BSCLR"], StringComparison.OrdinalIgnoreCase))).ToList();
                all.AddRange(gridRows);
                WriteStoredCAD(oForm, all);
                RememberCADGrid(oForm);
                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE) oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                Application.SBO_Application.StatusBar.SetText("CAD consumption updated. Click SAP Update/Add to persist changes.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex) { Global.GFunc.ShowError($"CAD save error: {ex.Message}"); }
            finally { if (oForm != null) oForm.Freeze(false); }
        }

        private void SetMatrixValue(SAPbouiCOM.Matrix matrix, string colUID, int row, string value)
        {
            ((SAPbouiCOM.EditText)matrix.Columns.Item(colUID)
                .Cells.Item(row).Specific).Value = value;
        }

        private void ReArrangeMatrixLineId(SAPbouiCOM.Matrix matrix)
        {
            for (int i = 1; i <= matrix.RowCount; i++)
            {
                SetMatrixValue(matrix, "#", i, i.ToString());
            }
        }

        //private void GRDCDCON_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    SAPbouiCOM.Form oForm = null;

        //    try
        //    {
        //        if (pVal.Row < 0)
        //            return;

        //        if (pVal.ColUID != "Cut WD Inch" &&
        //            pVal.ColUID != "Cut WD CM" &&
        //            pVal.ColUID != "Consumption" &&
        //            pVal.ColUID != "Shrinkage" &&
        //            pVal.ColUID != "Wastage")
        //            return;

        //        oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        oForm.Freeze(true);

        //        SAPbouiCOM.Grid oGrid =
        //            (SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific;

        //        SAPbouiCOM.DataTable dtCAD =
        //            oForm.DataSources.DataTables.Item("DT_CADCN");

        //        int dtRow = oGrid.GetDataTableRowIndex(pVal.Row);

        //        if (dtRow < 0)
        //            return;

        //        // =========================
        //        // Negative value protection
        //        // =========================
        //        double enteredValue;

        //        if (double.TryParse(
        //            dtCAD.GetValue(pVal.ColUID, dtRow).ToString().Trim(),
        //            out enteredValue))
        //        {
        //            if (enteredValue < 0)
        //            {
        //                dtCAD.SetValue(pVal.ColUID, dtRow, "0");
        //            }
        //        }

        //        // =========================
        //        // Inch / CM conversion
        //        // =========================
        //        if (pVal.ColUID == "Cut WD Inch")
        //        {
        //            double inch;

        //            if (double.TryParse(
        //                dtCAD.GetValue("Cut WD Inch", dtRow).ToString().Trim(),
        //                out inch))
        //            {
        //                if (inch < 0)
        //                {
        //                    inch = 0;
        //                    dtCAD.SetValue("Cut WD Inch", dtRow, "0");
        //                }

        //                dtCAD.SetValue(
        //                    "Cut WD CM",
        //                    dtRow,
        //                    (inch * 2.54).ToString("0.##")
        //                );
        //            }
        //            else
        //            {
        //                dtCAD.SetValue("Cut WD CM", dtRow, "");
        //            }
        //        }
        //        else if (pVal.ColUID == "Cut WD CM")
        //        {
        //            double cm;

        //            if (double.TryParse(
        //                dtCAD.GetValue("Cut WD CM", dtRow).ToString().Trim(),
        //                out cm))
        //            {
        //                if (cm < 0)
        //                {
        //                    cm = 0;
        //                    dtCAD.SetValue("Cut WD CM", dtRow, "0");
        //                }

        //                dtCAD.SetValue(
        //                    "Cut WD Inch",
        //                    dtRow,
        //                    (cm / 2.54).ToString("0.##")
        //                );
        //            }
        //            else
        //            {
        //                dtCAD.SetValue("Cut WD Inch", dtRow, "");
        //            }
        //        }

        //        // =========================
        //        // Total Consumption
        //        // =========================
        //        double consumption = 0;
        //        double shrinkage = 0;
        //        double wastage = 0;

        //        double.TryParse(
        //            dtCAD.GetValue("Consumption", dtRow).ToString().Trim(),
        //            out consumption);

        //        double.TryParse(
        //            dtCAD.GetValue("Shrinkage", dtRow).ToString().Trim(),
        //            out shrinkage);

        //        double.TryParse(
        //            dtCAD.GetValue("Wastage", dtRow).ToString().Trim(),
        //            out wastage);

        //        if (consumption < 0)
        //        {
        //            consumption = 0;
        //            dtCAD.SetValue("Consumption", dtRow, "0");
        //        }

        //        if (shrinkage < 0)
        //        {
        //            shrinkage = 0;
        //            dtCAD.SetValue("Shrinkage", dtRow, "0");
        //        }

        //        if (wastage < 0)
        //        {
        //            wastage = 0;
        //            dtCAD.SetValue("Wastage", dtRow, "0");
        //        }

        //        double totalConsumption =
        //            consumption +
        //            (consumption * shrinkage) +
        //            (consumption * wastage);

        //        dtCAD.SetValue(
        //            "Total Consumption",
        //            dtRow,
        //            totalConsumption.ToString("0.######")
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            "Grid calculation error: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error
        //        );
        //    }
        //    finally
        //    {
        //        if (oForm != null)
        //            oForm.Freeze(false);
        //    }
        //}

        //private void GRDCDCON_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    SAPbouiCOM.Form oForm = null;

        //    try
        //    {
        //        if (pVal.Row < 0)
        //            return;

        //        if (pVal.ColUID != "Cut WD Inch" &&
        //            pVal.ColUID != "Cut WD CM" &&
        //            pVal.ColUID != "Consumption" &&
        //            pVal.ColUID != "Shrinkage" &&
        //            pVal.ColUID != "Wastage")
        //            return;

        //        oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

        //        SAPbouiCOM.Grid oGrid =
        //            (SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific;

        //        SAPbouiCOM.DataTable dtCAD =
        //            oForm.DataSources.DataTables.Item("DT_CADCN");

        //        if (oGrid.Rows.Count == 0)
        //            return;

        //        if (pVal.Row >= oGrid.Rows.Count)
        //            return;

        //        int dtRow = oGrid.GetDataTableRowIndex(pVal.Row);

        //        if (dtRow < 0 || dtRow >= dtCAD.Rows.Count)
        //            return;

        //        oForm.Freeze(true);

        //        // =========================
        //        // Inch / CM conversion
        //        // =========================
        //        if (pVal.ColUID == "Cut WD Inch")
        //        {
        //            double inch = 0;

        //            if (double.TryParse(
        //                dtCAD.GetValue("Cut WD Inch", dtRow).ToString().Trim(),
        //                out inch))
        //            {
        //                if (inch < 0)
        //                {
        //                    inch = 0;
        //                    dtCAD.SetValue("Cut WD Inch", dtRow, "0");
        //                }

        //                dtCAD.SetValue(
        //                    "Cut WD CM",
        //                    dtRow,
        //                    (inch * 2.54).ToString("0.##")
        //                );
        //            }
        //        }
        //        else if (pVal.ColUID == "Cut WD CM")
        //        {
        //            double cm = 0;

        //            if (double.TryParse(
        //                dtCAD.GetValue("Cut WD CM", dtRow).ToString().Trim(),
        //                out cm))
        //            {
        //                if (cm < 0)
        //                {
        //                    cm = 0;
        //                    dtCAD.SetValue("Cut WD CM", dtRow, "0");
        //                }

        //                dtCAD.SetValue(
        //                    "Cut WD Inch",
        //                    dtRow,
        //                    (cm / 2.54).ToString("0.##")
        //                );
        //            }
        //        }

        //        // =========================
        //        // Total Consumption
        //        // =========================
        //        double consumption = 0;
        //        double shrinkage = 0;
        //        double wastage = 0;

        //        double.TryParse(
        //            dtCAD.GetValue("Consumption", dtRow).ToString().Trim(),
        //            out consumption);

        //        double.TryParse(
        //            dtCAD.GetValue("Shrinkage", dtRow).ToString().Trim(),
        //            out shrinkage);

        //        double.TryParse(
        //            dtCAD.GetValue("Wastage", dtRow).ToString().Trim(),
        //            out wastage);

        //        if (consumption < 0)
        //        {
        //            consumption = 0;
        //            dtCAD.SetValue("Consumption", dtRow, "0");
        //        }

        //        if (shrinkage < 0)
        //        {
        //            shrinkage = 0;
        //            dtCAD.SetValue("Shrinkage", dtRow, "0");
        //        }

        //        if (wastage < 0)
        //        {
        //            wastage = 0;
        //            dtCAD.SetValue("Wastage", dtRow, "0");
        //        }

        //        double totalConsumption =
        //            consumption +
        //            (consumption * shrinkage) +
        //            (consumption * wastage);

        //        dtCAD.SetValue(
        //            "Total Consumption",
        //            dtRow,
        //            totalConsumption.ToString("0.######")
        //        );
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            "Grid calculation error: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error
        //        );
        //    }
        //    finally
        //    {
        //        if (oForm != null)
        //        {
        //            try
        //            {
        //                oForm.Freeze(false);
        //            }
        //            catch
        //            {
        //            }
        //        }
        //    }
        //}
        private void GRDCDCON_ValidateAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                if (pVal.Row < 0)
                    return;

                if (pVal.ColUID != "Cut WD Inch" &&
                    pVal.ColUID != "Cut WD CM" &&
                    pVal.ColUID != "Consumption" &&
                    pVal.ColUID != "Shrinkage" &&
                    pVal.ColUID != "Wastage")
                    return;

                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                SAPbouiCOM.Grid oGrid =
                    (SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific;

                SAPbouiCOM.DataTable dtCAD =
                    oForm.DataSources.DataTables.Item("DT_CADCN");

                if (oGrid.Rows.Count == 0)
                    return;

                if (pVal.Row >= oGrid.Rows.Count)
                    return;

                int dtRow = oGrid.GetDataTableRowIndex(pVal.Row);

                if (dtRow < 0 || dtRow >= dtCAD.Rows.Count)
                    return;

                oForm.Freeze(true);

                if (pVal.ColUID == "Cut WD Inch")
                {
                    double inch = 0;

                    if (double.TryParse(
                        dtCAD.GetValue("Cut WD Inch", dtRow).ToString().Trim(),
                        out inch))
                    {
                        if (inch < 0)
                        {
                            inch = 0;
                            dtCAD.SetValue("Cut WD Inch", dtRow, "0");
                        }

                        dtCAD.SetValue(
                            "Cut WD CM",
                            dtRow,
                            (inch * 2.54).ToString("0.##")
                        );
                    }
                }
                else if (pVal.ColUID == "Cut WD CM")
                {
                    double cm = 0;

                    if (double.TryParse(
                        dtCAD.GetValue("Cut WD CM", dtRow).ToString().Trim(),
                        out cm))
                    {
                        if (cm < 0)
                        {
                            cm = 0;
                            dtCAD.SetValue("Cut WD CM", dtRow, "0");
                        }

                        dtCAD.SetValue(
                            "Cut WD Inch",
                            dtRow,
                            (cm / 2.54).ToString("0.##")
                        );
                    }
                }

                double consumption = 0;
                double shrinkage = 0;
                double wastage = 0;

                double.TryParse(
                    dtCAD.GetValue("Consumption", dtRow).ToString().Trim(),
                    out consumption);

                double.TryParse(
                    dtCAD.GetValue("Shrinkage", dtRow).ToString().Trim(),
                    out shrinkage);

                double.TryParse(
                    dtCAD.GetValue("Wastage", dtRow).ToString().Trim(),
                    out wastage);

                if (consumption < 0)
                {
                    consumption = 0;
                    dtCAD.SetValue("Consumption", dtRow, "0");
                }

                if (shrinkage < 0)
                {
                    shrinkage = 0;
                    dtCAD.SetValue("Shrinkage", dtRow, "0");
                }

                if (wastage < 0)
                {
                    wastage = 0;
                    dtCAD.SetValue("Wastage", dtRow, "0");
                }

                //double totalConsumption =
                //    consumption +
                //    (consumption * shrinkage) +
                //    (consumption * wastage);

                double totalConsumption = consumption + (consumption * wastage / 100);

                dtCAD.SetValue("Total Consumption", dtRow, totalConsumption.ToString("0.######"));
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Grid calculation error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
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
            }
        }

        private void GRDCDCON_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm =
                    Application.SBO_Application.Forms.Item(pVal.FormUID);

                string cflUID = "";

                if (pVal.ColUID == "UseType")
                {
                    cflUID = "CFL_USE2";
                }
                else if (pVal.ColUID == "Position")
                {
                    cflUID = "CFL_POS2";
                }
                else if (pVal.ColUID == "ItemCode")
                {
                    cflUID = "CFL_ITM2";
                }
                else
                {
                    return;
                }

                SAPbouiCOM.ChooseFromList oCFL =
                    oForm.ChooseFromLists.Item(cflUID);

                SAPbouiCOM.Conditions oCons =
                    new SAPbouiCOM.Conditions();

                SAPbouiCOM.Condition oCon1 = oCons.Add();

                if (pVal.ColUID == "ItemCode")
                {
                    oCon1.Alias = "InvntItem";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                }
                else
                {
                    oCon1.Alias = "U_ACTIVE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                }

                oCFL.SetConditions(oCons);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Grid CFL condition error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );

                BubbleEvent = false;
            }
        }

        private void GRDCDCON_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg =
                    (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

                SAPbouiCOM.DataTable selectedDt = cflArg.SelectedObjects;

                if (selectedDt == null || selectedDt.Rows.Count == 0)
                    return;

                SAPbouiCOM.Form oForm =
                    Application.SBO_Application.Forms.Item(pVal.FormUID);

                SAPbouiCOM.Grid oGrid =
                    (SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific;

                SAPbouiCOM.DataTable dtCAD =
                    oForm.DataSources.DataTables.Item("DT_CADCN");

                int dtRow = oGrid.GetDataTableRowIndex(pVal.Row);

                if (dtRow < 0)
                    return;

                if (pVal.ColUID == "UseType")
                {
                    string code = selectedDt.GetValue("Code", 0).ToString().Trim();
                    dtCAD.SetValue("UseType", dtRow, code);
                }
                else if (pVal.ColUID == "Position")
                {
                    string code = selectedDt.GetValue("Code", 0).ToString().Trim();
                    dtCAD.SetValue("Position", dtRow, code);
                }
                else if (pVal.ColUID == "ItemCode")
                {
                    string itemCode = selectedDt.GetValue("ItemCode", 0).ToString().Trim();
                    string itemName = selectedDt.GetValue("ItemName", 0).ToString().Trim();
                    string inventoryUom = selectedDt.GetValue("InvntryUom", 0).ToString().Trim();

                    dtCAD.SetValue("ItemCode", dtRow, itemCode);
                    dtCAD.SetValue("Item Desc", dtRow, itemName);
                    dtCAD.SetValue("UoM", dtRow, inventoryUom);

                    // Add new row only if current row is last row
                    if (dtRow == dtCAD.Rows.Count - 1)
                    {
                        dtCAD.Rows.Add(1);

                        int newRow = dtCAD.Rows.Count - 1;

                        dtCAD.SetValue("UseType", newRow, "");
                        dtCAD.SetValue("Position", newRow, "");
                        dtCAD.SetValue("ItemCode", newRow, "");
                        dtCAD.SetValue("Item Desc", newRow, "");
                        dtCAD.SetValue("UoM", newRow, "");
                        dtCAD.SetValue("Consumption", newRow, 0);
                        dtCAD.SetValue("Shrinkage", newRow, 0);
                        dtCAD.SetValue("Wastage", newRow, 0);
                        dtCAD.SetValue("Cut WD Inch", newRow, 0);
                        dtCAD.SetValue("Cut WD CM", newRow, 0);
                        dtCAD.SetValue("Total Consumption", newRow, 0);
                        dtCAD.SetValue("Remarks", newRow, "");

                        // Keep same colour
                        dtCAD.SetValue("BSCLR", newRow, dtCAD.GetValue("BSCLR", dtRow).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Grid CFL After error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }

        private void BTNLDCAD_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                string colour = ((SAPbouiCOM.EditText)oForm.Items.Item("ETCDCLR").Specific).Value.Trim();
                if (string.IsNullOrWhiteSpace(colour) || colour.Equals("ALL Colour", StringComparison.OrdinalIgnoreCase)) { Global.GFunc.ShowError("Please double-click a CAD colour first."); return; }
                if (!CheckCADGridSaved(oForm)) return;
                int answer = Application.SBO_Application.MessageBox("Load CAD materials for the selected colour? Saved consumption will be preserved.", 1, "OK", "Cancel");
                if (answer != 1) return;
                oForm.Freeze(true);
                LoadCADConsumptionByBaseColour(oForm, colour);
                SetCADConsumptionGridEditableForColour(oForm);
            }
            catch (Exception ex) { Global.GFunc.ShowError($"Load CAD Error: {ex.Message}"); }
            finally { if (oForm != null) oForm.Freeze(false); }
        }

        private void ADDButton_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            //Series Initialization
            SAPbouiCOM.DBDataSource oDBH = (SAPbouiCOM.DBDataSource)oForm.DataSources.DBDataSources.Item("@FIL_DH_CADFABCN");   //DEFINE  DATASOURCES.
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
            {
                SAPbouiCOM.ComboBox ocmb = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBSERIES").Specific;
                Global.GFunc.LoadComboBoxSeries(ocmb, "FIL_D_CADFABCN");  //Object Type
                string ocmbvalue = ocmb.Selected.Value;
                long docno = oForm.BusinessObject.GetNextSerialNumber(ocmbvalue, "FIL_D_CADFABCN");

                oDBH.SetValue("DocNum", 0, docno.ToString()); // only set the value in string.

                //Date
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = DateTime.Now.ToString("yyyyMMdd");
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
        private bool ValidateForm(ref SAPbouiCOM.Form oForm, ref bool BubbleEvent)
        {
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oForm.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                string styleCode = oForm.DataSources.DBDataSources.Item("@FIL_DH_CADFABCN").GetValue("U_STYLECODE", 0).Trim();
                string draftOrder = oForm.DataSources.DBDataSources.Item("@FIL_DH_CADFABCN").GetValue("U_SQNO", 0).Trim();
                string docNum = oForm.DataSources.DBDataSources.Item("@FIL_DH_CADFABCN").GetValue("DocNum", 0).Trim();
                string merc = oForm.DataSources.DBDataSources.Item("@FIL_DH_CADFABCN").GetValue("U_MRCHDNID", 0).Trim();


                if (styleCode == "")
                {
                    Global.GFunc.ShowError("Enter Style Code");
                    oForm.ActiveItem = "ETSTYLCD";
                    return BubbleEvent = false;
                }
                if (draftOrder == "")
                {
                    Global.GFunc.ShowError("Enter Draft Order ");
                    oForm.ActiveItem = "ETDRFTNO";
                    return BubbleEvent = false;
                }
                if (docNum == "")
                {
                    Global.GFunc.ShowError("Enter DocNum ");
                    return BubbleEvent = false;
                }
                if (merc == "")
                {
                    Global.GFunc.ShowError("Enter Merchandiser ");
                    oForm.ActiveItem = "ETDRFTNO";
                    return BubbleEvent = false;
                }


                if (!CheckCADGridSaved(oForm)) return BubbleEvent = false;
                if (!ValidateCADColourConsistency(oForm)) return BubbleEvent = false;

                PreventEmptyLastRow(oForm, "@FIL_DR_CADMFAB", MTXMRCON, "U_ITEMCODE");
                PreventEmptyLastRow(oForm, "@FIL_DR_CADFABCL", MTXCDCLR, "U_COLORCODE");
                PreventEmptyLastRow(oForm, "@FIL_DR_CADFABCN", MTXCDCON, "U_ITEMCODE");

            }

            return BubbleEvent;
        }


        private void MTXMRCON_LostFocusAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (pVal.Row <= 0)
                    return;

                if (pVal.ColUID != "CLCTWDIN" &&
                    pVal.ColUID != "CLCTWDCM")
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMRCON").Specific;
                SAPbouiCOM.EditText txtInch = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCTWDIN").Cells.Item(pVal.Row).Specific;
                SAPbouiCOM.EditText txtCM = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCTWDCM").Cells.Item(pVal.Row).Specific;

                // Inch → CM
                if (pVal.ColUID == "CLCTWDIN")
                {
                    double inch;

                    if (double.TryParse(txtInch.Value.Trim(), out inch))
                    {
                        if (inch < 0)
                        {
                            txtInch.Value = "0";
                            txtCM.Value = "0";
                            return;
                        }

                        txtCM.Value = (inch * 2.54).ToString("0.##");
                    }
                    else
                    {
                        txtCM.Value = "";
                    }
                }

                // CM → Inch
                else if (pVal.ColUID == "CLCTWDCM")
                {
                    double cm;

                    if (double.TryParse(txtCM.Value.Trim(), out cm))
                    {
                        if (cm < 0)
                        {
                            txtCM.Value = "0";
                            txtInch.Value = "0";
                            return;
                        }

                        txtInch.Value = (cm / 2.54).ToString("0.##");
                    }
                    else
                    {
                        txtInch.Value = "";
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Width conversion error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }


        private void MTXCDCLR_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            try
            {
                if (pVal.Row <= 0) return;
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (!CheckCADGridSaved(oForm)) return;
                SAPbouiCOM.Matrix mtx = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCLR").Specific;
                string colour = MatrixText(mtx, "CLCLRCOD", pVal.Row);
                if (string.IsNullOrWhiteSpace(colour)) return;
                oForm.Freeze(true);
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCDCLR").Specific).Value = colour;
                LoadCADConsumptionByBaseColour(oForm, colour);
                SetCADConsumptionGridEditableForColour(oForm);
            }
            catch (Exception ex) { Global.GFunc.ShowError($"MTXCDCLR Double Click Error: {ex.Message}"); }
            finally { if (oForm != null) oForm.Freeze(false); }
        }

        private void SetCADConsumptionGridEditableForColour(SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.Grid oGrid =
                (SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific;

            // First enable all columns
            for (int i = 0; i < oGrid.Columns.Count; i++)
            {
                oGrid.Columns.Item(i).Editable = true;
            }

            // Then disable only these columns
            SetGridColumnEditable(oGrid, "BSCLR", false);
            SetGridColumnEditable(oGrid, "Total Consumption", false);
            SetGridColumnEditable(oGrid, "Item Desc", false);
            SetGridColumnEditable(oGrid, "UoM", false);
        }

        private void SetGridColumnEditable(SAPbouiCOM.Grid oGrid, string colUID, bool editable)
        {
            try
            {
                oGrid.Columns.Item(colUID).Editable = editable;
            }
            catch
            {
                // Column not found, ignore
            }
        }

        private void LoadCADConsumptionByBaseColour(SAPbouiCOM.Form oForm, string colourCode)
        {
            SAPbouiCOM.Matrix merch = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMRCON").Specific;
            SAPbouiCOM.Matrix colours = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCLR").Specific;
            SAPbouiCOM.Matrix stored = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCON").Specific;
            merch.FlushToDataSource(); stored.FlushToDataSource();
            var existing = ReadStoredCAD(oForm);
            var groups = ReadCADColours(colours);
            bool isAll = IsAllCADColour(colourCode);
            var selectedGroups = isAll ? groups.Where(x => !IsAllCADColour(x)).ToList() : new List<string> { colourCode };
            var result = new List<Dictionary<string, string>>();
            foreach (string group in selectedGroups)
            {
                bool wantChecked = !IsNoCADColour(group);
                for (int row = 1; row <= merch.RowCount; row++)
                {
                    string code = MatrixText(merch, "CLITMCOD", row);
                    if (string.IsNullOrWhiteSpace(code) || IsMerchChecked(merch, row) != wantChecked) continue;
                    string position = MatrixText(merch, "CLPOS", row);
                    var saved = existing.FirstOrDefault(x => SameCADKey(x, group, code, position));
                    result.Add(saved != null ? new Dictionary<string, string>(saved) : NewCADFromMerch(merch, row, group));
                }
            }
            FillCADGrid(oForm, result, true);
            RememberCADGrid(oForm);
        }

        private void MTXMRCON_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                string cflUID = "";

                if (pVal.ColUID == "CLUSETYP")
                {
                    cflUID = "CFL_USE";
                }
                else if (pVal.ColUID == "CLPOS")
                {
                    cflUID = "CFL_POS";
                }
                else if (pVal.ColUID == "CLITMCOD")
                {
                    cflUID = "CFL_ITEM";
                }
                else
                {
                    return;
                }

                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);
                SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                SAPbouiCOM.Condition oCon1 = oCons.Add();

                if (pVal.ColUID == "CLITMCOD")
                {
                    oCon1.Alias = "InvntItem";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                }
                else if (pVal.ColUID == "CFL_USE")
                {
                    oCon1.Alias = "U_ACTIVE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                }
                else
                {
                    oCon1.Alias = "U_ACTIVE";
                    oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon1.CondVal = "Y";
                }

                oCFL.SetConditions(oCons);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "CFL condition error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );

                BubbleEvent = false;
            }
        }

        private void MTXMRCON_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg =
                    (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;

                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
                if (dt == null || dt.Rows.Count == 0)
                    return;

                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                SAPbouiCOM.Matrix oMatrix =
                    (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMRCON").Specific;

                string selectedCode = "";
                string selectedName = "";

                if (pVal.ColUID == "CLUSETYP")
                {
                    // From CFL_USE table
                    selectedCode = dt.GetValue("Code", 0).ToString().Trim();
                    selectedName = dt.GetValue("Name", 0).ToString().Trim();

                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLUSETYP")
                        .Cells.Item(pVal.Row).Specific).Value = selectedCode;

                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLUSDESC")
                        .Cells.Item(pVal.Row).Specific).Value = selectedName;
                }
                else if (pVal.ColUID == "CLPOS")
                {
                    // From CFL_POS table
                    selectedCode = dt.GetValue("Code", 0).ToString().Trim();

                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLPOS")
                        .Cells.Item(pVal.Row).Specific).Value = selectedCode;
                }
                //else if (pVal.ColUID == "CLUOM")
                //{
                //    // From CFL_POS table
                //    selectedCode = dt.GetValue("UomCode", 0).ToString().Trim();

                //    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLUOM")
                //        .Cells.Item(pVal.Row).Specific).Value = selectedCode;
                //}
                else if (pVal.ColUID == "CLITMCOD")
                {
                    string itemCode = dt.GetValue("ItemCode", 0).ToString().Trim();
                    string itemDesc = dt.GetValue("ItemName", 0).ToString().Trim();
                    string itemUom = dt.GetValue("InvntryUom", 0).ToString().Trim();


                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLITMCOD").Cells.Item(pVal.Row).Specific).Value = itemCode;
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLITMNAM").Cells.Item(pVal.Row).Specific).Value = itemDesc;
                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("CLUOM").Cells.Item(pVal.Row).Specific).Value = itemUom;

                    AddLineIfLastRowHasValue(oForm, "MTXMRCON", "@FIL_DR_CADMFAB", "U_ITEMCODE");
                }

            }
            //catch (System.Runtime.InteropServices.COMException ex)
            //{
            //    if (ex.Message.Contains("66000-153"))
            //        return;

            //    Global.GFunc.ShowError($"CFL After Error: {ex.Message}");
            //}
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"CFL After Error: {ex.Message}");
            }
        }

        private void PreventEmptyLastRow(SAPbouiCOM.Form oForm, string dbDatasourceUID, SAPbouiCOM.Matrix matrix, string columnName)
        {
            SAPbouiCOM.DBDataSource oDB = oForm.DataSources.DBDataSources.Item(dbDatasourceUID);
            int rowCount = matrix.VisualRowCount;

            if (rowCount > 0)
            {
                string lastValue = oDB.GetValue(columnName, rowCount - 1).Trim();

                if (string.IsNullOrEmpty(lastValue) || lastValue.Equals("0.0"))
                {
                    matrix.DeleteRow(rowCount);
                    oDB.RemoveRecord(rowCount - 1);
                }
            }
        }

        public static void AddLineIfLastRowHasValue(
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


        private void ETMERHN_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                return;
            SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
            SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;
            if (dt == null || dt.Rows.Count == 0)
                return;

            string Code = dt.GetValue("empID", 0).ToString().Trim();
            string Name = dt.GetValue("U_FNAME", 0).ToString().Trim();

            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETMERHN").Specific;
            ETCD.Value = Code;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETMERCNM").Specific;
            ETNM.Value = Name;

        }



        private void GRDSCLR_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);

                if (pVal.Row < 0)
                    return;

                string docEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDONTRY").Specific).Value.Trim();

                if (string.IsNullOrWhiteSpace(docEntry))
                {
                    Application.SBO_Application.MessageBox("Please select Draft Order first.");
                    return;
                }

                SAPbouiCOM.Grid grdClr = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSCLR").Specific;
                int dtRow = grdClr.GetDataTableRowIndex(pVal.Row);

                if (dtRow < 0)
                    return;

                SAPbouiCOM.DataTable dtClr = oForm.DataSources.DataTables.Item("DT_CLR");

                string colourCode = dtClr.GetValue("Colour Code", dtRow).ToString().Trim();

                if (string.IsNullOrWhiteSpace(colourCode))
                {
                    Application.SBO_Application.MessageBox("Colour Code not found.");
                    return;
                }

                // Set selected colour code
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSLCLR").Specific).Value = colourCode;

                string query = $@"
                                SELECT 
                                    T0.""U_FGSIZE"" AS ""Size Code"",
                                    T1.""Name""     AS ""Size Name"",
                                    SUM(T0.""Quantity"") AS ""Quantity""
                                FROM ""QUT1"" T0
                                LEFT JOIN ""@FIL_MH_SIZEMSTR"" T1
                                    ON T0.""U_FGSIZE"" = T1.""Code""
                                WHERE T0.""DocEntry"" = '{docEntry}'
                                  AND IFNULL(T0.""U_FGCOLOUR"", '') = '{colourCode.Replace("'", "''")}'
                                  AND IFNULL(T0.""U_FGSIZE"", '') <> ''
                                GROUP BY 
                                    T0.""U_FGSIZE"",
                                    T1.""Name""
                                ORDER BY 
                                    T0.""U_FGSIZE"" ";

                SAPbouiCOM.DataTable dtSize = oForm.DataSources.DataTables.Item("DT_SIZE");
                dtSize.ExecuteQuery(query);

                SAPbouiCOM.Grid grdSize = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSIZE").Specific;
                grdSize.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Colour selection failed: " + ex.Message);
            }
            finally
            {
                if (oForm != null)
                    oForm.Freeze(false);
            }
        }

        private void BTNFETCH_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                string docEntry = ((SAPbouiCOM.EditText)oForm.Items.Item("ETDONTRY").Specific).Value.Trim();
                if (string.IsNullOrWhiteSpace(docEntry)) { Global.GFunc.ShowError("Please select Draft Order first."); return; }
                oForm.Freeze(true);
                string query = $@"SELECT DISTINCT T0.""U_FGCOLOUR"" AS ""Colour Code"", T0.""U_FGCOLRNM"" AS ""Colour Name"", T0.""U_FGSIZE"" AS ""Size Code"", T1.""Name"" AS ""Size Name"" FROM ""QUT1"" T0 LEFT JOIN ""@FIL_MH_SIZEMSTR"" T1 ON T0.""U_FGSIZE"" = T1.""Code"" WHERE T0.""DocEntry"" = '{docEntry.Replace("'", "''")}' AND IFNULL(T0.""U_FGCOLOUR"", '') <> '' AND IFNULL(T0.""U_FGSIZE"", '') <> '' ORDER BY T0.""U_FGCOLOUR"", T0.""U_FGSIZE""";
                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                rs.DoQuery(query);
                if (rs.EoF) { Global.GFunc.ShowError("No Colour and Size data found for the selected Draft Order."); return; }
                SAPbouiCOM.DataTable dtClr = oForm.DataSources.DataTables.Item("DT_CLR");
                SAPbouiCOM.DataTable dtSize = oForm.DataSources.DataTables.Item("DT_SIZE");
                dtClr.Rows.Clear(); dtSize.Rows.Clear();
                var colourSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var sizeSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                while (!rs.EoF)
                {
                    string colourCode = rs.Fields.Item("Colour Code").Value.ToString().Trim();
                    string colourName = rs.Fields.Item("Colour Name").Value.ToString().Trim();
                    string sizeCode = rs.Fields.Item("Size Code").Value.ToString().Trim();
                    string sizeName = rs.Fields.Item("Size Name").Value.ToString().Trim();
                    if (colourSet.Add(colourCode)) { dtClr.Rows.Add(); int row = dtClr.Rows.Count - 1; dtClr.SetValue("Colour Code", row, colourCode); dtClr.SetValue("Colour Name", row, colourName); }
                    if (!string.IsNullOrWhiteSpace(sizeCode) && sizeSet.Add(sizeCode)) { dtSize.Rows.Add(); int row = dtSize.Rows.Count - 1; dtSize.SetValue("Size Code", row, sizeCode); dtSize.SetValue("Size Name", row, sizeName); dtSize.SetValue("Quantity", row, 0); }
                    rs.MoveNext();
                }
                ((SAPbouiCOM.Grid)oForm.Items.Item("GRDSCLR").Specific).AutoResizeColumns();
                ((SAPbouiCOM.Grid)oForm.Items.Item("GRDSIZE").Specific).AutoResizeColumns();
                Application.SBO_Application.StatusBar.SetText("Colour and Size fetched. Click Load Colour to populate CAD colours.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex) { Global.GFunc.ShowError($"Fetch failed: {ex.Message}"); }
            finally { if (oForm != null) oForm.Freeze(false); }
        }

        private void ETDRFTNO_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
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
            //ETDONTRY ETDRFTNO
            SAPbouiCOM.EditText ETCD = (SAPbouiCOM.EditText)oForm.Items.Item("ETDRFTNO").Specific;
            ETCD.Value = docNum;
            SAPbouiCOM.EditText ETNM = (SAPbouiCOM.EditText)oForm.Items.Item("ETDONTRY").Specific;
            ETNM.Value = docEntry;

        }

        private void ETDRFTNO_ChooseFromListBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                string styleCode = ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific).Value.Trim();

                if (string.IsNullOrEmpty(styleCode))
                {
                    Application.SBO_Application.StatusBar.SetText(
                        "Please Select Style first.",
                        SAPbouiCOM.BoMessageTime.bmt_Short,
                        SAPbouiCOM.BoStatusBarMessageType.smt_Error
                    );
                    BubbleEvent = false;
                    return;
                }

                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                string cflUID = cflArg.ChooseFromListUID;

                if (cflUID == "CFL_DO")
                {
                    SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item(cflUID);

                    SAPbouiCOM.Conditions oCons = new SAPbouiCOM.Conditions();
                    SAPbouiCOM.Condition oCon = oCons.Add();

                    oCon.Alias = "U_STYLECODE";
                    oCon.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    oCon.CondVal = styleCode;

                    oCFL.SetConditions(oCons);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error filtering Style Code: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
                BubbleEvent = false;
            }
        }



        private void ETSTYLCD_ChooseFromListAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                    return;
                SAPbouiCOM.ISBOChooseFromListEventArg cflArg = (SAPbouiCOM.ISBOChooseFromListEventArg)pVal;
                SAPbouiCOM.DataTable dt = cflArg.SelectedObjects;

                if (dt == null || dt.Rows.Count == 0)
                    return;

                string styleCode = dt.GetValue("U_STYLECODE", 0).ToString().Trim();
                string styleDesc = dt.GetValue("U_STYLENM", 0).ToString().Trim();
                string styleEntry = dt.GetValue("DocEntry", 0).ToString().Trim();
                string merCode = dt.GetValue("U_MARCHEN", 0).ToString().Trim();
                string merName = dt.GetValue("U_MARCHENN", 0).ToString().Trim();

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLCD").Specific).Value = styleCode;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLDS").Specific).Value = styleDesc;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSTNTRY").Specific).Value = styleEntry;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETMERHN").Specific).Value = merCode;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETMERCNM").Specific).Value = merName;
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                // Ignore SAP focus issue [66000-153]
                if (ex.Message.Contains("66000-153"))
                    return;

                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }




        //private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    SAPbouiCOM.Form oForm = null;
        //    bool frozen = false;

        //    try
        //    {
        //        oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        oForm.Freeze(true);
        //        frozen = true;

        //        int formHeight = oForm.ClientHeight;
        //        int gap = 10;

        //        // Header Colour and Size Grids
        //        SAPbouiCOM.Item grdClr = oForm.Items.Item("GRDSCLR");
        //        SAPbouiCOM.Item grdSize = oForm.Items.Item("GRDSIZE");
        //        SAPbouiCOM.Item etStntry = oForm.Items.Item("ETSTNTRY");
        //        SAPbouiCOM.Item stDocDate = oForm.Items.Item("STDOCDAT");

        //        grdClr.Top = 31;
        //        grdClr.Left = etStntry.Left + etStntry.Width + 35;
        //        grdClr.Width = 235;
        //        grdClr.Height = 122;

        //        grdSize.Top = 28;
        //        grdSize.Left = grdClr.Left + grdClr.Width + 20;
        //        grdSize.Width = Math.Max(120, stDocDate.Left - grdSize.Left - 15);
        //        grdSize.Height = 130;

        //        // Tab Container
        //        SAPbouiCOM.Item tab = oForm.Items.Item("Item_8");

        //        tab.Width = Math.Max(760, oForm.Width - 38);

        //        int footerTop = formHeight - oForm.Items.Item("1").Height - 12;
        //        tab.Height = Math.Max(190, footerTop - tab.Top - 6);

        //        // Folder Captions
        //        SAPbouiCOM.Item folderMer = oForm.Items.Item("FOLMERCON");
        //        SAPbouiCOM.Item folderCad = oForm.Items.Item("FOLCANCN");

        //        folderMer.Width = 210;
        //        folderCad.Width = 165;

        //        // Common Content Area
        //        int contentTop = tab.Top + 20;
        //        int contentBottom = tab.Top + tab.Height - 12;
        //        int contentHeight = Math.Max(70, contentBottom - contentTop);

        //        // Merchandise Consumption Matrix
        //        SAPbouiCOM.Item mtxMrCon = oForm.Items.Item("MTXMRCON");

        //        mtxMrCon.Top = contentTop;
        //        mtxMrCon.Left = tab.Left + 15;
        //        mtxMrCon.Width = Math.Max(300, tab.Width - 30);
        //        mtxMrCon.Height = contentHeight;

        //        // CAD Consumption Controls
        //        SAPbouiCOM.Item mtxCdClr = oForm.Items.Item("MTXCDCLR");
        //        SAPbouiCOM.Item stCdClr = oForm.Items.Item("STCDCLR");
        //        SAPbouiCOM.Item etCdClr = oForm.Items.Item("ETCDCLR");
        //        SAPbouiCOM.Item grdCdCon = oForm.Items.Item("GRDCDCON");
        //        SAPbouiCOM.Item btnLoadCad = oForm.Items.Item("BTNLDCAD");
        //        SAPbouiCOM.Item btnSave = oForm.Items.Item("BTNSAVE");
        //        SAPbouiCOM.Item btnLoadClr = oForm.Items.Item("BTNLDCLR");

        //        int leftMatrixWidth = 310;
        //        int labelTop = contentTop;
        //        int gridTop = labelTop + 24;
        //        int gridHeight = Math.Max(65, contentBottom - gridTop - 30);

        //        // CAD Colour Matrix
        //        mtxCdClr.Top = labelTop;
        //        mtxCdClr.Left = tab.Left + 10;
        //        mtxCdClr.Width = leftMatrixWidth;
        //        mtxCdClr.Height = gridHeight + 10;

        //        // CAD Consumption Grid
        //        grdCdCon.Top = gridTop;
        //        grdCdCon.Left = mtxCdClr.Left + mtxCdClr.Width + gap;
        //        grdCdCon.Width = Math.Max(140, tab.Left + tab.Width - grdCdCon.Left - 15);
        //        grdCdCon.Height = gridHeight;

        //        // Selected Colour
        //        stCdClr.Top = labelTop;
        //        stCdClr.Left = grdCdCon.Left;
        //        stCdClr.Width = 105;

        //        etCdClr.Top = labelTop;
        //        etCdClr.Left = stCdClr.Left + stCdClr.Width + 5;
        //        etCdClr.Width = 110;

        //        // Load Colour Button
        //        btnLoadClr.Width = 90;
        //        btnLoadClr.Height = etCdClr.Height;
        //        btnLoadClr.Top = etCdClr.Top;
        //        btnLoadClr.Left = etCdClr.Left + etCdClr.Width + 10;

        //        // Load CAD and Save Buttons
        //        btnLoadCad.Width = 75;
        //        btnSave.Width = 65;

        //        btnSave.Top = contentBottom - 18;
        //        btnLoadCad.Top = btnSave.Top;

        //        btnSave.Left = tab.Left + tab.Width - 15 - btnSave.Width;
        //        btnLoadCad.Left = btnSave.Left - gap - btnLoadCad.Width;

        //        // Temporary Matrix
        //        SAPbouiCOM.Item mtxCdCon = oForm.Items.Item("MTXCDCON");

        //        mtxCdCon.Top = contentTop;
        //        mtxCdCon.Left = tab.Left + 15;
        //        mtxCdCon.Width = Math.Max(300, tab.Width - 30);
        //        mtxCdCon.Height = contentHeight;

        //        // Bottom Add / Cancel Buttons
        //        SAPbouiCOM.Item btnAdd = oForm.Items.Item("1");
        //        SAPbouiCOM.Item btnCancel = oForm.Items.Item("2");

        //        btnAdd.Top = footerTop;
        //        btnCancel.Top = footerTop;

        //        btnAdd.Left = 13;
        //        btnCancel.Left = btnAdd.Left + btnAdd.Width + 3;

        //        // Auto Resize Matrix and Grid Columns
        //        AutoResizeAllMatrixAndGridColumns(oForm);
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.GFunc.ShowError($"CAD Form Resize Error: {ex.Message}");
        //    }
        //    finally
        //    {
        //        if (frozen && oForm != null)
        //            oForm.Freeze(false);
        //    }
        //}

        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            bool frozen = false;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);
                frozen = true;

                int formHeight = oForm.ClientHeight;
                int gap = 10;

                // Header Colour and Size Grids
                SAPbouiCOM.Item grdClr = oForm.Items.Item("GRDSCLR");
                SAPbouiCOM.Item grdSize = oForm.Items.Item("GRDSIZE");
                SAPbouiCOM.Item etStntry = oForm.Items.Item("ETSTNTRY");
                SAPbouiCOM.Item stDocDate = oForm.Items.Item("STDOCDAT");

                grdClr.Top = 31;
                grdClr.Left = etStntry.Left + etStntry.Width + 35;
                grdClr.Width = 235;
                grdClr.Height = 122;

                grdSize.Top = 28;
                grdSize.Left = grdClr.Left + grdClr.Width + 20;
                grdSize.Width = Math.Max(120, stDocDate.Left - grdSize.Left - 15);
                grdSize.Height = 130;

                // Footer Controls
                SAPbouiCOM.Item btnAdd = oForm.Items.Item("1");
                SAPbouiCOM.Item btnCancel = oForm.Items.Item("2");
                SAPbouiCOM.Item remarksLabel = oForm.Items.Item("STREMRKS");
                SAPbouiCOM.Item remarksEdit = oForm.Items.Item("ETREMRKS");

                int footerHeight = Math.Max(btnAdd.Height, remarksEdit.Height);
                int footerTop = formHeight - footerHeight - 12;

                // Tab Container
                SAPbouiCOM.Item tab = oForm.Items.Item("Item_8");

                tab.Width = Math.Max(760, oForm.Width - 38);
                tab.Height = Math.Max(190, footerTop - tab.Top - 8);

                // Folder Captions
                SAPbouiCOM.Item folderMer = oForm.Items.Item("FOLMERCON");
                SAPbouiCOM.Item folderCad = oForm.Items.Item("FOLCANCN");

                folderMer.Width = 210;
                folderCad.Width = 165;

                // Common Content Area
                int contentTop = tab.Top + 20;
                int contentBottom = tab.Top + tab.Height - 12;
                int contentHeight = Math.Max(70, contentBottom - contentTop);

                // Merchandise Consumption Matrix
                SAPbouiCOM.Item mtxMrCon = oForm.Items.Item("MTXMRCON");

                mtxMrCon.Top = contentTop;
                mtxMrCon.Left = tab.Left + 15;
                mtxMrCon.Width = Math.Max(300, tab.Width - 30);
                mtxMrCon.Height = contentHeight;

                // CAD Consumption Controls
                SAPbouiCOM.Item mtxCdClr = oForm.Items.Item("MTXCDCLR");
                SAPbouiCOM.Item stCdClr = oForm.Items.Item("STCDCLR");
                SAPbouiCOM.Item etCdClr = oForm.Items.Item("ETCDCLR");
                SAPbouiCOM.Item grdCdCon = oForm.Items.Item("GRDCDCON");
                SAPbouiCOM.Item btnLoadCad = oForm.Items.Item("BTNLDCAD");
                SAPbouiCOM.Item btnSave = oForm.Items.Item("BTNSAVE");
                SAPbouiCOM.Item btnLoadClr = oForm.Items.Item("BTNLDCLR");

                int leftMatrixWidth = 310;
                int labelTop = contentTop;
                int gridTop = labelTop + 24;
                int gridHeight = Math.Max(65, contentBottom - gridTop - 30);

                // CAD Colour Matrix
                mtxCdClr.Top = labelTop;
                mtxCdClr.Left = tab.Left + 10;
                mtxCdClr.Width = leftMatrixWidth;
                mtxCdClr.Height = gridHeight + 10;

                // CAD Consumption Grid
                grdCdCon.Top = gridTop;
                grdCdCon.Left = mtxCdClr.Left + mtxCdClr.Width + gap;
                grdCdCon.Width = Math.Max(140, tab.Left + tab.Width - grdCdCon.Left - 15);
                grdCdCon.Height = gridHeight;

                // Selected Colour
                stCdClr.Top = labelTop;
                stCdClr.Left = grdCdCon.Left;
                stCdClr.Width = 105;

                etCdClr.Top = labelTop;
                etCdClr.Left = stCdClr.Left + stCdClr.Width + 5;
                etCdClr.Width = 110;

                // Load Colour Button
                btnLoadClr.Width = 90;
                btnLoadClr.Height = etCdClr.Height;
                btnLoadClr.Top = etCdClr.Top;
                btnLoadClr.Left = etCdClr.Left + etCdClr.Width + 10;

                // Load CAD and Save Buttons
                btnLoadCad.Width = 75;
                btnSave.Width = 65;

                btnSave.Top = contentBottom - 18;
                btnLoadCad.Top = btnSave.Top;

                btnSave.Left = tab.Left + tab.Width - 15 - btnSave.Width;
                btnLoadCad.Left = btnSave.Left - gap - btnLoadCad.Width;

                // Temporary Matrix
                SAPbouiCOM.Item mtxCdCon = oForm.Items.Item("MTXCDCON");

                mtxCdCon.Top = contentTop;
                mtxCdCon.Left = tab.Left + 15;
                mtxCdCon.Width = Math.Max(300, tab.Width - 30);
                mtxCdCon.Height = contentHeight;

                // Bottom Add / Cancel Buttons
                btnAdd.Left = 13;
                btnCancel.Left = btnAdd.Left + btnAdd.Width + 3;

                btnAdd.Top = footerTop + (footerHeight - btnAdd.Height) / 2;
                btnCancel.Top = footerTop + (footerHeight - btnCancel.Height) / 2;

                // Remarks Footer Controls
                remarksLabel.Left = btnCancel.Left + btnCancel.Width + 90;
                remarksEdit.Left = remarksLabel.Left + remarksLabel.Width + 8;

                remarksEdit.Width = Math.Max(160, Math.Min(407, tab.Left + tab.Width - remarksEdit.Left - 20));
                remarksEdit.Top = footerTop + (footerHeight - remarksEdit.Height) / 2;

                remarksLabel.Top = footerTop + (footerHeight - remarksLabel.Height) / 2;

                // Auto Resize Matrix and Grid Columns
                AutoResizeAllMatrixAndGridColumns(oForm);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"CAD Form Resize Error: {ex.Message}");
            }
            finally
            {
                if (frozen && oForm != null)
                    oForm.Freeze(false);
            }
        }

        private void AutoResizeAllMatrixAndGridColumns(SAPbouiCOM.Form oForm)
        {
            // Header Size Grid
            try
            {
                SAPbouiCOM.Grid grdSize = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSIZE").Specific;
                grdSize.AutoResizeColumns();
            }
            catch { }

            // CAD Consumption Grid
            try
            {
                SAPbouiCOM.Grid grdCad = (SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific;
                grdCad.AutoResizeColumns();
            }
            catch { }

            // Merchandise Consumption Matrix
            try
            {
                SAPbouiCOM.Matrix mtxMer = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMRCON").Specific;
                mtxMer.AutoResizeColumns();
            }
            catch { }

            // CAD Colour Matrix
            try
            {
                SAPbouiCOM.Matrix mtxClr = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCLR").Specific;
                mtxClr.AutoResizeColumns();
            }
            catch { }

            // Temporary Matrix
            try
            {
                SAPbouiCOM.Matrix mtxTemp = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCON").Specific;
                mtxTemp.AutoResizeColumns();
            }
            catch { }

            // Header Colour Grid
            try
            {
                SAPbouiCOM.Grid grdClr = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSCLR").Specific;
                grdClr.Columns.Item("Colour Code").Width = 90;
                grdClr.Columns.Item("Colour Name").Width = 120;
            }
            catch { }

            //// CAD Colour Matrix
            //try
            //{
            //    SAPbouiCOM.Matrix mtxCdClr = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCLR").Specific;
            //    mtxCdClr.Columns.Item("CLCLRCOD").Width = 90;
            //    mtxCdClr.Columns.Item("CLCLRNAM").Width = 125;
            //}
            //catch { }

            // CAD Colour Matrix - Dynamic Column Resize
            try
            {
                SAPbouiCOM.Matrix mtxCdClr = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCLR").Specific;

                int matrixWidth = mtxCdClr.Item.Width;
                int rowNumberWidth = 25;
                int scrollbarSpace = 20;
                int availableWidth = Math.Max(100, matrixWidth - rowNumberWidth - scrollbarSpace);

                int colourCodeWidth = (int)(availableWidth * 0.45);
                int colourNameWidth = availableWidth - colourCodeWidth;

                mtxCdClr.Columns.Item("#").Width = rowNumberWidth;
                mtxCdClr.Columns.Item("CLCLRCOD").Width = colourCodeWidth;
                mtxCdClr.Columns.Item("CLCLRNAM").Width = colourNameWidth;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"CAD Colour Matrix Resize Error: {ex.Message}");
            }
        }

        private void CADFolder_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form oForm = null;
            bool frozen = false;

            try
            {
                oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                oForm.Freeze(true);
                frozen = true;

                SAPbouiCOM.Item folderMer = oForm.Items.Item("FOLMERCON");
                SAPbouiCOM.Item folderCad = oForm.Items.Item("FOLCANCN");

                folderMer.Width = 210;
                folderCad.Width = 165;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError($"CAD Folder Resize Error: {ex.Message}");
            }
            finally
            {
                if (frozen && oForm != null)
                    oForm.Freeze(false);
            }
        }

        //private void AutoResizeAllMatrixAndGridColumns(SAPbouiCOM.Form oForm)
        //{
        //    try
        //    {
        //        ((SAPbouiCOM.Grid)oForm.Items.Item("GRDSCLR").Specific).AutoResizeColumns();
        //        ((SAPbouiCOM.Grid)oForm.Items.Item("GRDSIZE").Specific).AutoResizeColumns();
        //        ((SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific).AutoResizeColumns();

        //        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXMRCON").Specific).AutoResizeColumns();
        //        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCLR").Specific).AutoResizeColumns();
        //        ((SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCON").Specific).AutoResizeColumns();
        //    }
        //    catch
        //    {
        //    }
        //}

        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.LinkedButton LinkedButton1;
        private SAPbouiCOM.LinkedButton LinkedButton2;
        private SAPbouiCOM.Button Button0;

        // ================= CAD COLOUR / CONSUMPTION HELPERS =================
        private static string MatrixText(SAPbouiCOM.Matrix matrix, string column, int row)
        {
            return ((SAPbouiCOM.EditText)matrix.Columns.Item(column).Cells.Item(row).Specific).Value.Trim();
        }

        private static bool IsAllCADColour(string code) { return code.Equals("ALLColour", StringComparison.OrdinalIgnoreCase) || code.Equals("ALL Colour", StringComparison.OrdinalIgnoreCase); }
        private static bool IsNoCADColour(string code) { return code.Equals("NoColour", StringComparison.OrdinalIgnoreCase); }
        private static bool IsMerchChecked(SAPbouiCOM.Matrix matrix, int row)
        {
            return ((SAPbouiCOM.CheckBox)matrix.Columns.Item("CLCLRAPL").Cells.Item(row).Specific).Checked;
        }

        private static readonly string[] CADFields = { "UseType", "Position", "ItemCode", "Item Desc", "UoM", "Consumption", "Shrinkage", "Wastage", "Cut WD Inch", "Cut WD CM", "Total Consumption", "Remarks", "BSCLR" };
        private static readonly string[] CADMatrixFields = { "CLUSETYP", "CLPOSTN", "CLITMCOD", "CLITMNAM", "CLUOM", "CLCNSMPN", "CLSHRKPR", "CLWSTGP", "CLCTWDIN", "CLCTWDCM", "CLTTLCON", "CLRMRKS", "CLBSCLR" };
        private static readonly string[] CADDbFields = { "U_USETYPE", "U_POSITION", "U_ITEMCODE", "U_ITEMNAME", "U_UOM", "U_ACTCONSM", "U_SHRNLPRC", "U_CUTWSTG", "U_CBLWDIN", "U_CBLWDCM", "U_TTLCONSM", "U_REMARKS", "U_BASECLR" };

        private static List<string> ReadCADColours(SAPbouiCOM.Matrix matrix)
        {
            var result = new List<string>();
            for (int i = 1; i <= matrix.RowCount; i++)
            {
                string code = MatrixText(matrix, "CLCLRCOD", i);
                if (!string.IsNullOrWhiteSpace(code) && !result.Any(x => x.Equals(code, StringComparison.OrdinalIgnoreCase))) result.Add(code);
            }
            return result;
        }

        private static SAPbouiCOM.DataTable EnsureCADGridSchema(SAPbouiCOM.Form form)
        {
            SAPbouiCOM.DataTable dt = form.DataSources.DataTables.Item("DT_CADCN");
            // A zero-record query preserves the correct HANA column types and the same aliases for every grid operation.
            if (dt.Columns.Count != CADFields.Length || !Enumerable.Range(0, CADFields.Length).All(i => dt.Columns.Item(i).Name == CADFields[i]))
            {
                string query = @"SELECT ""U_USETYPE"" AS ""UseType"", ""U_POSITION"" AS ""Position"", ""U_ITEMCODE"" AS ""ItemCode"", ""U_ITEMNAME"" AS ""Item Desc"", ""U_UOM"" AS ""UoM"", ""U_ACTCONSM"" AS ""Consumption"", ""U_SHRNLPRC"" AS ""Shrinkage"", ""U_CUTWSTG"" AS ""Wastage"", ""U_CBLWDIN"" AS ""Cut WD Inch"", ""U_CBLWDCM"" AS ""Cut WD CM"", ""U_TTLCONSM"" AS ""Total Consumption"", ""U_REMARKS"" AS ""Remarks"", ""U_BASECLR"" AS ""BSCLR"" FROM ""@FIL_DR_CADFABCN"" WHERE 1 = 0";
                dt.ExecuteQuery(query);
            }
            return dt;
        }

        private static Dictionary<string, string> NewCADFromMerch(SAPbouiCOM.Matrix matrix, int i, string colour)
        {
            var row = CADFields.ToDictionary(x => x, x => "");
            row["UseType"] = MatrixText(matrix, "CLUSETYP", i);
            row["Position"] = MatrixText(matrix, "CLPOS", i);
            row["ItemCode"] = MatrixText(matrix, "CLITMCOD", i);
            row["Item Desc"] = MatrixText(matrix, "CLITMNAM", i);
            row["UoM"] = MatrixText(matrix, "CLUOM", i);
            row["Shrinkage"] = MatrixText(matrix, "CLSHRKPR", i);
            row["Cut WD Inch"] = MatrixText(matrix, "CLCTWDIN", i);
            row["Cut WD CM"] = MatrixText(matrix, "CLCTWDCM", i);
            row["Consumption"] = "0"; row["Wastage"] = "0"; row["Total Consumption"] = "0";
            row["BSCLR"] = colour;
            return row;
        }

        private static bool SameCADKey(Dictionary<string, string> row, string colour, string itemCode, string position)
        {
            return row["BSCLR"].Equals(colour, StringComparison.OrdinalIgnoreCase) && row["ItemCode"].Equals(itemCode, StringComparison.OrdinalIgnoreCase) && row["Position"].Equals(position, StringComparison.OrdinalIgnoreCase);
        }

        private static List<Dictionary<string, string>> ReadStoredCAD(SAPbouiCOM.Form form)
        {
            SAPbouiCOM.DBDataSource db = form.DataSources.DBDataSources.Item("@FIL_DR_CADFABCN");
            var records = new List<Dictionary<string, string>>();
            for (int i = 0; i < db.Size; i++)
            {
                var record = new Dictionary<string, string>();
                for (int j = 0; j < CADFields.Length; j++) record[CADFields[j]] = db.GetValue(CADDbFields[j], i).Trim();
                if (!string.IsNullOrWhiteSpace(record["ItemCode"])) records.Add(record);
            }
            return records;
        }

        private static void WriteStoredCAD(SAPbouiCOM.Form form, List<Dictionary<string, string>> records)
        {
            SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)form.Items.Item("MTXCDCON").Specific;
            SAPbouiCOM.DBDataSource db = form.DataSources.DBDataSources.Item("@FIL_DR_CADFABCN");
            db.Clear();
            for (int i = 0; i < records.Count; i++)
            {
                db.InsertRecord(i);
                db.SetValue("LineId", i, (i + 1).ToString());
                for (int j = 0; j < CADFields.Length; j++) db.SetValue(CADDbFields[j], i, records[i][CADFields[j]]);
            }
            matrix.LoadFromDataSource();
        }

        private static List<Dictionary<string, string>> ReadCADGrid(SAPbouiCOM.Form form)
        {
            SAPbouiCOM.Grid grid = (SAPbouiCOM.Grid)form.Items.Item("GRDCDCON").Specific;
            SAPbouiCOM.DataTable dt = grid.DataTable;
            var rows = new List<Dictionary<string, string>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = new Dictionary<string, string>();
                foreach (string field in CADFields) row[field] = dt.GetValue(field, i).ToString().Trim();
                if (!string.IsNullOrWhiteSpace(row["ItemCode"])) rows.Add(row);
            }
            return rows;
        }

        private static void FillCADGrid(SAPbouiCOM.Form form, List<Dictionary<string, string>> rows, bool addBlankRow)
        {
            SAPbouiCOM.Grid grid = (SAPbouiCOM.Grid)form.Items.Item("GRDCDCON").Specific;
            SAPbouiCOM.DataTable dt = EnsureCADGridSchema(form);
            dt.Rows.Clear();
            foreach (var record in rows)
            {
                dt.Rows.Add(); int index = dt.Rows.Count - 1;
                foreach (string field in CADFields) dt.SetValue(field, index, record[field]);
            }
            if (addBlankRow)
            {
                // Blank rows only for a single colour. A multi-colour blank row cannot be assigned a safe BSCLR.
                string active = ((SAPbouiCOM.EditText)form.Items.Item("ETCDCLR").Specific).Value.Trim();
                if (!IsAllCADColour(active))
                {
                    dt.Rows.Add(); int index = dt.Rows.Count - 1;
                    foreach (string field in CADFields) dt.SetValue(field, index, field == "BSCLR" ? active : (field == "Consumption" || field == "Shrinkage" || field == "Wastage" || field == "Cut WD Inch" || field == "Cut WD CM" || field == "Total Consumption" ? "0" : ""));
                }
            }
            grid.DataTable = dt;
            grid.AutoResizeColumns();
        }

        private static string CADGridSignature(SAPbouiCOM.Form form)
        {
            var dt = ((SAPbouiCOM.Grid)form.Items.Item("GRDCDCON").Specific).DataTable;
            if (dt.Columns.Count != CADFields.Length) return "";
            var lines = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(dt.GetValue("ItemCode", i).ToString())) continue;
                lines.Add(string.Join("\u001f", CADFields.Select(f => dt.GetValue(f, i).ToString().Trim())));
            }
            return string.Join("\u001e", lines);
        }

        private static void RememberCADGrid(SAPbouiCOM.Form form) { _cadGridBaseline[form.UniqueID] = CADGridSignature(form); }
        private static bool CheckCADGridSaved(SAPbouiCOM.Form form)
        {
            if (_cadGridBaseline.TryGetValue(form.UniqueID, out string before) && before != CADGridSignature(form))
            {
                Global.GFunc.ShowError("Unsaved CAD grid changes found. Click SAVE before switching colours or updating the document.");
                return false;
            }
            return true;
        }

        private void BTNLDCLR_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            SAPbouiCOM.Form form = null;
            try
            {
                form = Application.SBO_Application.Forms.Item(pVal.FormUID);
                if (!CheckCADGridSaved(form)) return;
                SAPbouiCOM.DataTable dtClr = form.DataSources.DataTables.Item("DT_CLR");
                SAPbouiCOM.Matrix merch = (SAPbouiCOM.Matrix)form.Items.Item("MTXMRCON").Specific;
                SAPbouiCOM.Matrix colours = (SAPbouiCOM.Matrix)form.Items.Item("MTXCDCLR").Specific;
                var codes = new List<Tuple<string, string>>();
                bool hasUnchecked = false, hasMerch = false;
                for (int i = 1; i <= merch.RowCount; i++)
                {
                    if (string.IsNullOrWhiteSpace(MatrixText(merch, "CLITMCOD", i))) continue;
                    hasMerch = true;
                    if (!IsMerchChecked(merch, i)) hasUnchecked = true;
                }
                if (!hasMerch) { Global.GFunc.ShowError("Please enter Merchandise Consumption items first."); return; }
                for (int i = 0; i < dtClr.Rows.Count; i++)
                {
                    string code = dtClr.GetValue("Colour Code", i).ToString().Trim();
                    string name = dtClr.GetValue("Colour Name", i).ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(code) && !IsAllCADColour(code) && !IsNoCADColour(code) && !codes.Any(x => x.Item1.Equals(code, StringComparison.OrdinalIgnoreCase))) codes.Add(Tuple.Create(code, name));
                }
                if (codes.Count == 0) { Global.GFunc.ShowError("Please click FETCH to load the available colours first."); return; }
                SAPbouiCOM.Matrix storedMatrix = (SAPbouiCOM.Matrix)form.Items.Item("MTXCDCON").Specific;
                storedMatrix.FlushToDataSource();
                var previouslySaved = ReadStoredCAD(form);
                var stale = previouslySaved.Where(x => !codes.Any(c => c.Item1.Equals(x["BSCLR"], StringComparison.OrdinalIgnoreCase)) && !IsNoCADColour(x["BSCLR"]) ||
                    !Enumerable.Range(1, merch.RowCount).Any(i => MatrixText(merch, "CLITMCOD", i).Equals(x["ItemCode"], StringComparison.OrdinalIgnoreCase) && MatrixText(merch, "CLPOS", i).Equals(x["Position"], StringComparison.OrdinalIgnoreCase) && IsMerchChecked(merch, i) != IsNoCADColour(x["BSCLR"]))).ToList();
                if (stale.Count > 0)
                {
                    int answer = Application.SBO_Application.MessageBox($"{stale.Count} previously saved CAD consumption row(s) conflict with the current merchandise colour applicability. Remove those rows from the working document? Values will NOT be transferred. Click SAP Update to commit.", 1, "Remove", "Cancel");
                    if (answer != 1) return;
                }
                form.Freeze(true);
                merch.FlushToDataSource();
                colours.FlushToDataSource();
                if (stale.Count > 0)
                {
                    previouslySaved.RemoveAll(x => stale.Contains(x));
                    WriteStoredCAD(form, previouslySaved);
                    FillCADGrid(form, new List<Dictionary<string, string>>(), false);
                    RememberCADGrid(form);
                    ((SAPbouiCOM.EditText)form.Items.Item("ETCDCLR").Specific).Value = "";
                }
                SAPbouiCOM.DBDataSource db = form.DataSources.DBDataSources.Item("@FIL_DR_CADFABCL");
                db.Clear();
                codes.Add(Tuple.Create("ALLColour", "ALLColour"));
                if (hasUnchecked) codes.Add(Tuple.Create("NoColour", "NoColour"));
                for (int i = 0; i < codes.Count; i++)
                {
                    db.InsertRecord(i); db.SetValue("LineId", i, (i + 1).ToString()); db.SetValue("U_COLORCODE", i, codes[i].Item1); db.SetValue("U_COLORNAME", i, codes[i].Item2);
                }
                colours.LoadFromDataSource(); colours.AutoResizeColumns();
                if (form.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE) form.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
                Application.SBO_Application.StatusBar.SetText("CAD colours loaded successfully.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
            }
            catch (Exception ex) { Global.GFunc.ShowError($"Load Colour Error: {ex.Message}"); }
            finally { if (form != null) form.Freeze(false); }
        }

        private static bool ValidateCADColourConsistency(SAPbouiCOM.Form form)
        {
            SAPbouiCOM.Matrix merch = (SAPbouiCOM.Matrix)form.Items.Item("MTXMRCON").Specific;
            SAPbouiCOM.Matrix colours = (SAPbouiCOM.Matrix)form.Items.Item("MTXCDCLR").Specific;
            SAPbouiCOM.Matrix stored = (SAPbouiCOM.Matrix)form.Items.Item("MTXCDCON").Specific;
            merch.FlushToDataSource(); stored.FlushToDataSource();
            var groups = ReadCADColours(colours);
            bool checkedItems = false, uncheckedItems = false;
            var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string group in groups) if (!IsAllCADColour(group)) allowed.Add(group);
            for (int i = 1; i <= merch.RowCount; i++)
            {
                if (string.IsNullOrWhiteSpace(MatrixText(merch, "CLITMCOD", i))) continue;
                if (IsMerchChecked(merch, i)) checkedItems = true; else uncheckedItems = true;
            }
            if ((checkedItems || uncheckedItems) && !groups.Any(IsAllCADColour)) { Global.GFunc.ShowError("Please click Load Colour before saving the document."); return false; }
            if (uncheckedItems != allowed.Contains("NoColour")) { Global.GFunc.ShowError("Merchandise colour applicability has changed. Please click Load Colour before saving."); return false; }
            var saved = ReadStoredCAD(form);
            foreach (var row in saved)
            {
                if (!allowed.Contains(row["BSCLR"])) { Global.GFunc.ShowError("An outdated CAD consumption colour exists. Review CAD consumption before Update."); return false; }
                bool match = false;
                for (int i = 1; i <= merch.RowCount; i++)
                {
                    if (MatrixText(merch, "CLITMCOD", i).Equals(row["ItemCode"], StringComparison.OrdinalIgnoreCase) && MatrixText(merch, "CLPOS", i).Equals(row["Position"], StringComparison.OrdinalIgnoreCase) && IsMerchChecked(merch, i) != IsNoCADColour(row["BSCLR"])) { match = true; break; }
                }
                if (!match) { Global.GFunc.ShowError("A CAD consumption item no longer matches Merchandise colour applicability. Reconcile the CAD details before Update."); return false; }
            }
            return true;
        }

        // Invoked from Menu.cs MenuUID 1293 BEFORE action. Cancel the SAP default and delete synchronously.
        public static void DeleteCADSelectedRow(SAPbouiCOM.Form form)
        {
            if (!_cadDeleteContext.TryGetValue(form.UniqueID, out var info)) { Global.GFunc.ShowError("Please right-click and select a CAD row to delete."); return; }
            _cadDeleteContext.Remove(form.UniqueID);
            if (form.Mode != SAPbouiCOM.BoFormMode.fm_ADD_MODE && form.Mode != SAPbouiCOM.BoFormMode.fm_UPDATE_MODE && form.Mode != SAPbouiCOM.BoFormMode.fm_OK_MODE) { Global.GFunc.ShowError("Row deletion is not allowed in this form mode."); return; }
            if (!CheckCADGridSaved(form)) return;
            form.Freeze(true);
            try
            {
                SAPbouiCOM.Matrix merch = (SAPbouiCOM.Matrix)form.Items.Item("MTXMRCON").Specific;
                SAPbouiCOM.Matrix stored = (SAPbouiCOM.Matrix)form.Items.Item("MTXCDCON").Specific;
                stored.FlushToDataSource();
                var data = ReadStoredCAD(form);
                if (info.Item1 == "MTXMRCON")
                {
                    int rowIndex = info.Item2;
                    if (rowIndex < 1 || rowIndex > merch.RowCount) { Global.GFunc.ShowError("Please select a valid merchandise row."); return; }
                    string code = MatrixText(merch, "CLITMCOD", rowIndex), position = MatrixText(merch, "CLPOS", rowIndex);
                    if (string.IsNullOrWhiteSpace(code)) return;
                    merch.FlushToDataSource();
                    SAPbouiCOM.DBDataSource db = form.DataSources.DBDataSources.Item("@FIL_DR_CADMFAB");
                    db.RemoveRecord(rowIndex - 1);
                    for (int i = 0; i < db.Size; i++) db.SetValue("LineId", i, (i + 1).ToString());
                    merch.LoadFromDataSource();
                    data.RemoveAll(x => x["ItemCode"].Equals(code, StringComparison.OrdinalIgnoreCase) && x["Position"].Equals(position, StringComparison.OrdinalIgnoreCase));
                    WriteStoredCAD(form, data);
                    RemoveCADGridRows(form, x => x["ItemCode"].Equals(code, StringComparison.OrdinalIgnoreCase) && x["Position"].Equals(position, StringComparison.OrdinalIgnoreCase));
                }
                else if (info.Item1 == "GRDCDCON")
                {
                    SAPbouiCOM.Grid grid = (SAPbouiCOM.Grid)form.Items.Item("GRDCDCON").Specific;
                    if (info.Item2 < 0 || info.Item2 >= grid.Rows.Count) { Global.GFunc.ShowError("Please select a valid CAD grid row."); return; }
                    int dtRow = grid.GetDataTableRowIndex(info.Item2);
                    SAPbouiCOM.DataTable dt = grid.DataTable;
                    string code = dt.GetValue("ItemCode", dtRow).ToString().Trim();
                    string position = dt.GetValue("Position", dtRow).ToString().Trim();
                    string colour = dt.GetValue("BSCLR", dtRow).ToString().Trim();
                    if (string.IsNullOrWhiteSpace(code)) return;
                    data.RemoveAll(x => SameCADKey(x, colour, code, position));
                    WriteStoredCAD(form, data);
                    dt.Rows.Remove(dtRow);
                }
                RememberCADGrid(form);
                if (form.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE) form.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;
            }
            catch (Exception ex) { Global.GFunc.ShowError($"CAD Delete Row Error: {ex.Message}"); }
            finally { form.Freeze(false); }
        }

        private static void RemoveCADGridRows(SAPbouiCOM.Form form, Func<Dictionary<string, string>, bool> remove)
        {
            SAPbouiCOM.DataTable dt = ((SAPbouiCOM.Grid)form.Items.Item("GRDCDCON").Specific).DataTable;
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                var row = new Dictionary<string, string>();
                foreach (string f in CADFields) row[f] = dt.GetValue(f, i).ToString().Trim();
                if (remove(row)) dt.Rows.Remove(i);
            }
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText0;
    }
}
