using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apparel_Dynamic_1._0.Resources.Transaction
{
    [FormAttribute("Apparel_Dynamic_1._0.Resources.Transaction.ProcurementCosting", "Resources/Transaction/ProcurementCosting.b1f")]
    class ProcurementCosting : UserFormBase
    {
        public ProcurementCosting()
        {
        }



        private SAPbouiCOM.StaticText STSTYLCD, STYLDESC, STCUSTCD, STCUSTNM, STDRFTNO, STCADNO, STDOCNUM, STDOCDAT, STVERSON, STODRQTY, STOLRNCE, STTLQTY, STFOB, STREMRKS, STCOLOR, STCONTNT, STSLFOB, STSLCLR, STLPRCST, STTLCSEL;

       

        private SAPbouiCOM.EditText ETSTYLCD, ETYLDESC, ETSLNTRY, ETCUSTCD, ETCUSTNM, ETDRFTNO, ETDFNTRY, ETCADNO, ETCDNTRY, ETDOCNUM, ETDOCDAT, ETVERSON, ETODRQTY, ETOLRNCE, ETTLQTY, ETDOCTRY, ETREMRKS, ETSLFOB, ETSLCLR, ETLPRCST, ETTLCSEL;

        private SAPbouiCOM.ComboBox CBSERIES;

        private SAPbouiCOM.LinkedButton LKSTYLCD, LKCUSTCD, LKCADNO, LKDRFTNO;

        private SAPbouiCOM.Folder TABFAB, TABTRMS, TABOTCST, TABPRCST, TABCSTEL, TABCOMM, TABSUMM, TABVRSN, TABTMFAB, TABTPTRM;

        private SAPbouiCOM.Matrix MTXFOB, MTXCOLOR, MTXTMFAB, MTXTRMS, MTXOTCST, MTXPRCST, MTXCSTEL, MTXSUMRY, MTXCOMSN, MTXTMTRM;

        private SAPbouiCOM.Grid GRDFAB, GRDVRSN;

        private SAPbouiCOM.Button ADDButton, BTNCANCEL, BTNLDFAB, BTNLDCEL, BTNSAVE, BTVRSN;


        public override void OnInitializeComponent()
        {
            //   StaticText
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
            this.STSLFOB = ((SAPbouiCOM.StaticText)(this.GetItem("STSLFOB").Specific));
            this.STSLCLR = ((SAPbouiCOM.StaticText)(this.GetItem("STSLCLR").Specific));
            this.STLPRCST = ((SAPbouiCOM.StaticText)(this.GetItem("STLPRCST").Specific));
            this.STTLCSEL = ((SAPbouiCOM.StaticText)(this.GetItem("STTLCSEL").Specific));
            //   EditText
            this.ETSTYLCD = ((SAPbouiCOM.EditText)(this.GetItem("ETSTYLCD").Specific));
            this.ETYLDESC = ((SAPbouiCOM.EditText)(this.GetItem("ETYLDESC").Specific));
            this.ETSLNTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETSLNTRY").Specific));
            this.ETCUSTCD = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTCD").Specific));
            this.ETCUSTNM = ((SAPbouiCOM.EditText)(this.GetItem("ETCUSTNM").Specific));
            this.ETDRFTNO = ((SAPbouiCOM.EditText)(this.GetItem("ETDRFTNO").Specific));
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
            this.ETSLFOB = ((SAPbouiCOM.EditText)(this.GetItem("ETSLFOB").Specific));
            this.ETSLCLR = ((SAPbouiCOM.EditText)(this.GetItem("ETSLCLR").Specific));
            this.ETLPRCST = ((SAPbouiCOM.EditText)(this.GetItem("ETLPRCST").Specific));
            this.ETTLCSEL = ((SAPbouiCOM.EditText)(this.GetItem("ETTLCSEL").Specific));
            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            //    LinkedButton
            this.LKSTYLCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKSTYLCD").Specific));
            this.LKCUSTCD = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCUSTCD").Specific));
            this.LKCADNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKCADNO").Specific));
            this.LKDRFTNO = ((SAPbouiCOM.LinkedButton)(this.GetItem("LKDRFTNO").Specific));
            //   Folder
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
            //   Matrix
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
            //   Grid
            this.GRDFAB = ((SAPbouiCOM.Grid)(this.GetItem("GRDFAB").Specific));
            this.GRDVRSN = ((SAPbouiCOM.Grid)(this.GetItem("GRDVRSN").Specific));
            //   Button
            this.ADDButton = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.BTNCANCEL = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.BTNLDFAB = ((SAPbouiCOM.Button)(this.GetItem("BTNLDFAB").Specific));
            this.BTNLDCEL = ((SAPbouiCOM.Button)(this.GetItem("BTNLDCEL").Specific));
            this.BTNSAVE = ((SAPbouiCOM.Button)(this.GetItem("BTNSAVE").Specific));
            this.BTVRSN = ((SAPbouiCOM.Button)(this.GetItem("BTVRSN").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("FOLATTCH").Specific));
            this.Matrix0 = ((SAPbouiCOM.Matrix)(this.GetItem("MTXATTCH").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("BRWSBTN").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("DISPBTN").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("DELBTN").Specific));
            this.OnCustomInitialize();

        }

        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new ResizeAfterHandler(this.Form_ResizeAfter);

        }



        private void OnCustomInitialize()
        {

        }

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

                // The first row: FOB + Color + selection controls.
                int fobLeft = areaLeft + 17;
                int matrixTop = areaTop + 42;
                int rowHeight = Math.Max(45, (int)Math.Round(tabArea.Height * 61.0 / 277.0));
                int fobWidth = Math.Max(120, 150 + (int)Math.Round(widthDifference * 0.20));
                int rightLabelLeft = areaRight - 287;
                int rightEditLeft = rightLabelLeft + 86;
                int fobColorGap = tabArea.Width >= 850 ? 64 : 25;
                int colorRightGap = tabArea.Width >= 850 ? 129 : 50;
                int colorLeft = fobLeft + fobWidth + fobColorGap;
                int colorWidth = rightLabelLeft - colorRightGap - colorLeft;

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

                // Keep FOB/Color selection fields and Load Fabrics button on the right.
                oForm.Items.Item("STSLFOB").Left = rightLabelLeft;
                oForm.Items.Item("STSLCLR").Left = rightLabelLeft + 1;
                oForm.Items.Item("ETSLFOB").Left = rightEditLeft;
                oForm.Items.Item("ETSLCLR").Left = rightEditLeft;
                oForm.Items.Item("BTNLDFAB").Left = areaRight - 228;

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

        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Matrix Matrix0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.Button Button3;

        //private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        //{
        //    SAPbouiCOM.Form oForm = null;
        //    bool frozen = false;

        //    try
        //    {
        //        oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
        //        oForm.Freeze(true);
        //        frozen = true;

        //        SAPbouiCOM.Item tabArea = oForm.Items.Item("Item_34");
        //        tabArea.Width = Math.Max(760, oForm.Width - 38);
        //        tabArea.Height = Math.Max(210, oForm.Height - 193);

        //        int areaLeft = tabArea.Left;
        //        int areaTop = tabArea.Top;
        //        int areaRight = areaLeft + tabArea.Width;
        //        int areaBottom = areaTop + tabArea.Height;
        //        int widthDifference = tabArea.Width - 976;

        //        // FOB and Color layout
        //        int fobLeft = areaLeft + 17;
        //        int matrixTop = areaTop + 42;
        //        int rowHeight = Math.Max(45, (int)Math.Round(tabArea.Height * 61.0 / 277.0));
        //        int fobWidth = Math.Max(120, 150 + (int)Math.Round(widthDifference * 0.20));

        //        int rightLabelLeft = areaRight - 287;
        //        int rightEditLeft = rightLabelLeft + 86;
        //        int fobColorGap = tabArea.Width >= 850 ? 64 : 25;
        //        int colorRightGap = tabArea.Width >= 850 ? 129 : 50;

        //        int colorLeft = fobLeft + fobWidth + fobColorGap;
        //        int colorWidth = rightLabelLeft - colorRightGap - colorLeft;

        //        SAPbouiCOM.Item fobItem = oForm.Items.Item("MTXFOB");
        //        fobItem.Left = fobLeft;
        //        fobItem.Top = matrixTop;
        //        fobItem.Width = fobWidth;
        //        fobItem.Height = rowHeight;

        //        SAPbouiCOM.Item colorItem = oForm.Items.Item("MTXCOLOR");
        //        colorItem.Left = colorLeft;
        //        colorItem.Top = matrixTop - 1;
        //        colorItem.Width = colorWidth;
        //        colorItem.Height = rowHeight + 1;

        //        oForm.Items.Item("STFOB").Left = fobLeft;
        //        oForm.Items.Item("STFOB").Top = areaTop + 25;

        //        oForm.Items.Item("STCOLOR").Left = colorLeft + 3;
        //        oForm.Items.Item("STCOLOR").Top = areaTop + 24;

        //        // Right-side selection controls
        //        oForm.Items.Item("STSLFOB").Left = rightLabelLeft;
        //        oForm.Items.Item("STSLCLR").Left = rightLabelLeft + 1;
        //        oForm.Items.Item("ETSLFOB").Left = rightEditLeft;
        //        oForm.Items.Item("ETSLCLR").Left = rightEditLeft;
        //        oForm.Items.Item("BTNLDFAB").Left = areaRight - 228;

        //        // Content label and Fabrics grid
        //        int contentTop = matrixTop + rowHeight + 5;
        //        int gridTop = contentTop + 19;
        //        int saveTop = areaBottom - 35;
        //        int gridHeight = saveTop - gridTop - 8;

        //        oForm.Items.Item("STCONTNT").Left = fobLeft;
        //        oForm.Items.Item("STCONTNT").Top = contentTop;

        //        SAPbouiCOM.Item gridItem = oForm.Items.Item("GRDFAB");
        //        gridItem.Left = fobLeft;
        //        gridItem.Top = gridTop;
        //        gridItem.Width = tabArea.Width - 35;
        //        gridItem.Height = gridHeight;

        //        // Save button always stays below the grid
        //        SAPbouiCOM.Item saveItem = oForm.Items.Item("BTNSAVE");
        //        saveItem.Left = areaLeft + 39;
        //        saveItem.Top = saveTop;

        //        // Keep form buttons and Remarks below the tab
        //        oForm.Items.Item("1").Top = areaBottom + 6;
        //        oForm.Items.Item("2").Top = areaBottom + 6;
        //        oForm.Items.Item("STREMRKS").Top = areaBottom + 8;
        //        oForm.Items.Item("ETREMRKS").Top = areaBottom + 7;

        //        // Adjust column widths
        //        MTXFOB.AutoResizeColumns();
        //        MTXCOLOR.AutoResizeColumns();
        //        GRDFAB.AutoResizeColumns();
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText("Procurement Costing resize error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //    finally
        //    {
        //        if (frozen && oForm != null) oForm.Freeze(false);
        //    }
        //}
    }
}
