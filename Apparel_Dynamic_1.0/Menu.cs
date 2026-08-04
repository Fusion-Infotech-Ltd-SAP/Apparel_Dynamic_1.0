using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Apparel_Dynamic_1._0.Helper;
using Apparel_Dynamic_1._0.Resources.Setup;
using Apparel_Dynamic_1._0.Resources.Master;
using Apparel_Dynamic_1._0.Resources.Transaction;

namespace Apparel_Dynamic_1._0
{
    class Menu
    {
        public void BasicStart()
        {
            string _AddonId = "2001";
            if (CompanyConnection(_AddonId))
            {
                //Main Module
                CreateMainMenu("43520", "APP", "Apparel", 18, 2, true);

                //Parent Section
                CreateMainMenu("APP", "APP_STP", "Setup", 0, 2, false);
                CreateMainMenu("APP", "APP_MST", "Master", 1, 2, false);
                CreateMainMenu("APP", "APP_TRN", "Transaction", 2, 2, false);

                //Apparel -> Setup
                CreateMainMenu("APP_STP", "APP_STP_SMPLTYPE", "Sample Type",1,1, false);
                CreateMainMenu("APP_STP", "APP_STP_GENTYMSTR", "Gender Master",2,1, false);
                CreateMainMenu("APP_STP", "APP_STP_CLRMSTR", "Color Master ",3,1, false);
                CreateMainMenu("APP_STP", "APP_STP_SIZEMSTR", "Size Master",4,1, false);
                CreateMainMenu("APP_STP", "APP_STP_PSTNMSTR", "Position Master ", 5, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SMPLSTUS", "Sample Status", 6, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_COMSTGES", "Components Stages", 7, 1, false);

                CreateMainMenu("APP_STP", "APP_STP_PRODLN", "Product Line ", 8, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_PRODTYPE", "Product Type", 9, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_PRODGRP", "Product Group ", 10, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_BRAND", "Brand", 11, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_SBDVSN", "Sub Division", 12, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_DEPT", "Department", 13, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_USETYPE", "Use Type", 14, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_ORDRTYPE", "Order Type", 15, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_LEADTIME", "Lead Time", 16, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_PARAMSTR", "Parameter Master", 17, 1, false);
                CreateMainMenu("APP_STP", "APP_STP_INCOTRMS", "Inco Terms", 18, 1, false);


                //Apparel ->  Master
                CreateMainMenu("APP_MST", "APP_MST_ROUTNG", "Route Master", 1, 1, false);
                CreateMainMenu("APP_MST", "APP_MST_SZTPMSTR", "Size Type Master", 2, 1, false);
                CreateMainMenu("APP_MST", "APP_MST_CPM", "CPM Master", 3, 1, false);
                CreateMainMenu("APP_MST", "APP_MST_OTHCSTPRM", "Other Cost Parameter", 3, 1, false);
                CreateMainMenu("APP_MST", "APP_MST_SAM", "SAM", 4, 1, false);


                //Apparel -> Transcation
                CreateMainMenu("APP_TRN", "APP_TRN_COM", "Commercial ", 0, 2, false);
                CreateMainMenu("APP_TRN", "APP_TRN_SAM", "Sampling", 1, 2, false);
                CreateMainMenu("APP_TRN", "APP_TRN_MRD", "Merchandising ", 2, 2, false);

                //Apparel -> Transaction -> Commercial
                CreateMainMenu("APP_TRN_COM", "APP_TRN_COM_EXP", "Export LC ", 0, 2, false);
                CreateMainMenu("APP_TRN_COM", "APP_TRN_COM_IMP", "Import LC ", 1, 2, false);

                //Apparel -> Transaction -> Commercial -> Export LC
                CreateMainMenu("APP_TRN_COM_EXP", "APP_TRN_COM_EXP_MLC", "Master LC", 1, 1, false);
                CreateMainMenu("APP_TRN_COM_EXP", "APP_TRN_COM_EXP_AMD", "Master LC Amendment", 2, 1, false);

                //Apparel -> Transaction -> Commercial -> Import  LC
                CreateMainMenu("APP_TRN_COM_IMP", "APP_TRN_COM_IMP_B2B_LC", "Import LC/TT/RTGS LC(B2B)", 0, 1, false);
                CreateMainMenu("APP_TRN_COM_IMP", "APP_TRN_COM_IMP_B2B_AMD", "Import LC/TT/RTGS LC Ammendment (B2B)", 1, 1, false);

                //Apparel -> Transaction -> Sampling
                CreateMainMenu("APP_TRN_SAM", "APP_TRN_SAM_SM", "Sample Master", 1, 1, false);
                CreateMainMenu("APP_TRN_SAM", "APP_TRN_SAM_SPC", "Sample PreCositng", 2, 1, false);

                //Apparel -> Transaction -> Merchandising 
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_SM", "Style Master", 1, 1, false);
                //CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_SCON", "Sales Contract ", 2, 2, false);
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_SCON_SC", "Sales Contract", 2, 1, false);

                //Apparel -> Transaction -> Merchandising->Sales Contract
                //CreateMainMenu("APP_TRN_MRD_SCON", "APP_TRN_MRD_SCON_SC", "Sales Contract", 1, 1, false);
                //CreateMainMenu("APP_TRN_MRD_SCON", "APP_TRN_MRD_SCON_SC_AMD", "Sales Contract Ammendment", 2, 1, false);

                //Apparel -> Transaction -> Merchandising -> OTT
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_OTT", "OTT", 3, 1, false);

                //Apparel -> Transaction -> Merchandising -> Draft Order
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_DRO", "Draft Order", 4, 1, false);

                //Apparel -> Transaction -> Merchandising -> CAD Fabric Consuption - FHR
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_CAD", "CAD", 5, 1, false);

                //Apparel -> Transaction -> Merchandising -> Costing
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_CST", "Procurement Costing", 6, 1, false);

                //Apparel -> Transaction -> Merchandising -> Material requirements planning  - FHR
                CreateMainMenu("APP_TRN_MRD", "APP_TRN_MRD_MRP", "MRP", 7, 1, false);


            }

        }

        public void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                //___________________________________________________________Setup_______________________________________________
                
                //Sample Type
                if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SMPLTYPE")
                {
                        string formUID = "FIL_FRM_SMPLTYPE";
                        if (IsFormOpen(formUID))
                        {
                            Global.G_UI_Application.Forms.Item(formUID).Select();
                            Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                                SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                            return;
                        }
                    SampleType activeForm = new SampleType();
                    activeForm.Show();
                }
                // Gender 
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_GENTYMSTR")
                {
                    string formUID = "FIL_FRM_GENTYMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    Gender activeForm = new Gender();
                    activeForm.Show();
                }
                //Size
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SIZEMSTR")
                {
                    string formUID = "FIL_FRM_SIZE";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    Size activeForm = new Size();
                    activeForm.Show();
                }
                //Colour
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_CLRMSTR")
                {
                    string formUID = "FIL_FRM_CLR_MSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    Colour activeForm = new Colour();
                    activeForm.Show();
                }
                //Component Stages
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_COMSTGES")
                {
                    string formUID = "FIL_FRM_COMSTG";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ComponentStages activeForm = new ComponentStages();
                    activeForm.Show();
                }
                //Sample Status
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SMPLSTUS")
                {
                    string formUID = "FIL_FRM_SMPLSTAT";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SampleStatus activeForm = new SampleStatus();
                    activeForm.Show();
                }
                // Positon
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PSTNMSTR")
                {
                    string formUID = "FIL_FRM_PSTN_MSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    Position activeForm = new Position();
                    activeForm.Show();
                }
                // Product Line 
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PRODLN")
                {
                    string formUID = "FIL_FRM_PRDLINE";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ProductLine activeForm = new ProductLine();
                    activeForm.Show();
                }
                // Product Type 
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PRODTYPE")
                {
                    string formUID = "FIL_FRM_PRDTYPE";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ProductType activeForm = new ProductType();
                    activeForm.Show();
                }
                // Product Group
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PRODGRP")
                {
                    string formUID = "FIL_FRM_PRDGRP";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ProductGroup activeForm = new ProductGroup();
                    activeForm.Show();
                }
                //Brand Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_BRAND")
                {
                    string formUID = "FIL_FRM_BRNDMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    Brand activeForm = new Brand();
                    activeForm.Show();
                }
                //Sub Division
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_SBDVSN")
                {
                    string formUID = "FIL_FRM_SUBDVSN";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SubDivision activeForm = new SubDivision();
                    activeForm.Show();
                }
                //Dept
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_DEPT")
                {
                    string formUID = "FIL_FRM_DEPT";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    Department activeForm = new Department();
                    activeForm.Show();
                }
                // Use Type 
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_USETYPE")
                {
                    string formUID = "FIL_FRM_USETYPE";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    UseType activeForm = new UseType();
                    activeForm.Show();
                }
                //ORDER TYPE
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_ORDRTYPE")
                {
                    string formUID = "FIL_FRM_ORDRTYPE";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    try
                    {
                        OrderType activeForm = new OrderType();
                        activeForm.Show();
                        SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_ORDRTYPE");
                        SAPbouiCOM.Matrix MTXORDR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXORDR").Specific;
                        MTXORDR.AutoResizeColumns();

                    }
                    catch(Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + ex.Message);
                    }
                   
                }
                //Lead Time
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_LEADTIME")
                {
                    string formUID = "FIL_FRM_LEADTIME";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    try
                    {
                        LeadTime activeForm = new LeadTime();
                        activeForm.Show();
                        SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_LEADTIME");
                        SAPbouiCOM.Matrix MTXLEDTM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXLEDTM").Specific;
                        MTXLEDTM.AutoResizeColumns();

                        //Series Initialization
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            string today = DateTime.Now.ToString("yyyyMMdd");
                            SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_LEADTMST");
                            oDBH.SetValue("U_DOCDATE", 0, today);
                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;

                            UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_LEADTMST");
                            LoadMatrixCombos(oForm);
                            EnsureLine(oForm, "MTXLEDTM", "@FIL_DR_LEADTMST");
                        }
                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + ex.Message);
                    }

                }
                // Parameter Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_PARAMSTR")
                {
                    string formUID = "FIL_FRM_PARAMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    ParameterMaster activeForm = new ParameterMaster();
                    activeForm.Show();
                }
                //APP_STP_INCOTRMS
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_STP_INCOTRMS")
                {
                    string formUID = "FIL_FRM_INCOTRMS";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    IncoTerms activeForm = new IncoTerms();
                    activeForm.Show();
                }

                //___________________________________________________________Master________________________________________________
                //Sample Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_SAM_SM")
                {
                    string formUID = "FIL_FRM_SMPLMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SampleMaster activeForm = new SampleMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SMPLMSTR");
                    try
                    {
                        SAPbouiCOM.Matrix MTSZ = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSIZE").Specific;
                        SAPbouiCOM.Matrix MTXCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                        SAPbouiCOM.Matrix MTXITM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                        SAPbouiCOM.Matrix MTXBYRS = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXBUYER").Specific;
                        SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                        MTSZ.AutoResizeColumns();
                        MTXCLR.AutoResizeColumns();
                        MTXITM.AutoResizeColumns();
                        MTXBYRS.AutoResizeColumns();
                        MTXATTAC.AutoResizeColumns();

                        // Series Initialization
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM");
                            Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                            string today = DateTime.Now.ToString("yyyyMMdd");
                            SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_SMPLMAST");
                            oDBH.SetValue("U_DOCDATE", 0, today);

                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                            UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_SMPLMAST");

                        }
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                // Route Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_ROUTNG")
                {
                    string formUID = "FIL_FRM_ROUTEMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    RouteMaster activeForm = new RouteMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_ROUTEMSTR");
                    try
                    {
                        SAPbouiCOM.Matrix MTSTG = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTAGE").Specific;
                        MTSTG.AutoResizeColumns();
                        EnsureLine(oForm, "MTXSTAGE", "@FIL_MR_RSM1");
                    }
                    catch(Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + ex.Message);
                    }
                }
                //Size Type Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_SZTPMSTR")
                {
                    string formUID = "FIL_FRM_SZTPMSTR";
                    if (IsFormOpen(formUID)) 
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                   
                    try
                    {
                        SizeTypeMaster activeForm = new SizeTypeMaster();
                        activeForm.Show();
                        SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SZTPMSTR");
                        SAPbouiCOM.Matrix MTSIZE = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSIZE").Specific;
                        MTSIZE.AutoResizeColumns();
                        EnsureLine(oForm, "MTXSIZE", "@FIL_MR_STM1");
                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + ex.Message);
                    }
                }
                //Style Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_SM")
                {
                    string formUID = "FIL_FRM_STYLMSTR";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    StyleMaster activeForm = new StyleMaster();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_STYLMSTR");
                    try
                    {
                        SAPbouiCOM.Matrix MTSZ = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSIZE").Specific;
                        SAPbouiCOM.Matrix MTXCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                        SAPbouiCOM.Matrix MTXSBCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSBCLR").Specific;
                        SAPbouiCOM.Matrix MTXITM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                        SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                        MTSZ.AutoResizeColumns();
                        MTXCLR.AutoResizeColumns();
                        MTXSBCLR.AutoResizeColumns();
                        MTXITM.AutoResizeColumns();
                        MTXATTAC.AutoResizeColumns();

                        EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_PSMCO");
                        EnsureLine(oForm, "MTXSBCLR", "@FIL_DR_SUBCLR");

                        // Series Initialization
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM");
                            Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                            string today = DateTime.Now.ToString("yyyyMMdd");
                            SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_OPSM");
                            oDBH.SetValue("U_DOCDATE", 0, today);

                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                            UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_OPSM");

                        }
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }       
                //Sales Quotation
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_DRO")
                {
                    try
                    {
                        string formType = "2049";
                        foreach (SAPbouiCOM.Form form in Application.SBO_Application.Forms)
                        {
                            if (form.TypeEx == formType)
                            {
                                form.Select();
                                Application.SBO_Application.StatusBar.SetText("Sales Order Draft form is already open.",
                                    SAPbouiCOM.BoMessageTime.bmt_Short,
                                    SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                                return;
                            }
                        }

                        // Activate (open) the Sales Order Draft form
                        Application.SBO_Application.ActivateMenuItem("2049");
                        
                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error while opening Sales Order Draft form: " + ex.Message);
                    }
                }
                //CPM Master
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_CPM")
                { 
                    try
                    {
                        string formUID = "FIL_FRM_CPM";
                        if (IsFormOpen(formUID))
                        {
                            Global.G_UI_Application.Forms.Item(formUID).Select();
                            Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                                SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                            return;
                        }

                        CPMMaster activeForm = new CPMMaster();
                        activeForm.Show();
                        SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_CPM");
                        SAPbouiCOM.Matrix MTXSAMRN = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;
                        MTXSAMRN.AutoResizeColumns();

                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            string today = DateTime.Now.ToString("yyyyMMdd");
                            SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_CPM");
                            oDBH.SetValue("U_DOCDATE", 0, today);

                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                            UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_CPM");
                        }
                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + ex.Message);
                    }

                }
                //Other Cost Parameter 
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_OTHCSTPRM")
                {
                    try
                    {
                        string formUID = "FIL_FRM_OCSTPRM";
                        if (IsFormOpen(formUID))
                        {
                            Global.G_UI_Application.Forms.Item(formUID).Select();
                            Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                                SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                            return;
                        }

                        OtherCostParam activeForm = new OtherCostParam();
                        activeForm.Show();
                        SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_OCSTPRM");
                        SAPbouiCOM.Matrix MTXCSPRM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCSPRM").Specific;
                        MTXCSPRM.AutoResizeColumns();
                        
                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + ex.Message);
                    }

                }
                //SAM
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_MST_SAM")
                {
                    string formUID = "APP_MST_SAM";

                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText(
                            "Form is already open.",
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

                        return;
                    }
                    try
                    {
                        SAM activeForm = new SAM();
                        activeForm.Show();
                        SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SAM");
                        SAPbouiCOM.Matrix MTXSAM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAM").Specific;
                        MTXSAM.AutoResizeColumns();

                        //oForm.Freeze(true);
                        //oForm.Settings.MatrixUID = "MTXSAM";
                        //oForm.Settings.Enabled = true;
                        //oForm.Freeze(false);
                    }
                    catch (Exception ex)
                    {
                        Global.GFunc.ShowError("Failed to open SAM form.\n" + ex.Message);
                    }
                }
                //___________________________________________________________Transaction________________________________________________
                //Sample PreCositng
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_SAM_SPC")
                {
                    string formUID = "FIL_FRM_SMPLPCST";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    SamplePreCosting activeForm = new SamplePreCosting();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_SMPLPCST");
                    try
                    {
                        //Component Matrix
                        SAPbouiCOM.Matrix oMTXCMP = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;
                        oMTXCMP.AutoResizeColumns();

                        //Other Cost Matrix
                        SAPbouiCOM.Matrix oMTXOTCST = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTCST").Specific;
                        oMTXOTCST.AutoResizeColumns();

                        // Series Initialization
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");
                            Global.GFunc.SetItemsEnabled(oForm, false, "ETSMPLNM", "ETBUYER", "ETBYRNM", "ETDOCNUM", "ETVERSON");

                            string today = DateTime.Now.ToString("yyyyMMdd");
                            SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING");
                            oDBH.SetValue("U_DOCDATE", 0, today);

                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                            UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_PRECOSTING");
                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value = "1"; //Default version 
                        }

                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + e.Message);
                    }
                }
                //OTT
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_OTT")
                {
                    string formUID = "FIL_FRM_OTT";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }
                    OTT activeForm = new OTT();
                    activeForm.Show();
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item("FIL_FRM_OTT");
                    try
                    {
                        SAPbouiCOM.Matrix MTXOTT = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXOTDTL").Specific;                       
                        MTXOTT.AutoResizeColumns();

                        //New Line
                        EnsureLine(oForm, "MTXOTDTL", "@FIL_DR_TT1");

                        // Series Initialization
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM", "ETMERCNM");
                            Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                            string today = DateTime.Now.ToString("yyyyMMdd");
                            SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_OTT");
                            oDBH.SetValue("U_DOCDATE", 0, today);

                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                            //Date
                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETOTDATE").Specific).Value = today;
                            UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_OTT");

                        }
                    }
                    catch (Exception e)
                    {
                        Application.SBO_Application.MessageBox("Error Found OTT : " + e.Message);
                    }
                }
                //Sales Contract
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_SCON_SC")
                {
                    string formUID = "FIL_FRM_SLCNTRCT";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }

                    SalesContract activeForm = new SalesContract();
                    activeForm.Show();

                    SAPbouiCOM.Form oForm = null;

                    try
                    {
                        oForm = Application.SBO_Application.Forms.Item("FIL_FRM_SLCNTRCT");
                        oForm.Freeze(true);

                        SAPbouiCOM.Matrix MTXORDTL = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXORDTL").Specific;
                        SAPbouiCOM.Matrix MTXB2BDL = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXB2BDL").Specific;
                        SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                        MTXORDTL.AutoResizeColumns();
                        MTXB2BDL.AutoResizeColumns();
                        MTXATTCH.AutoResizeColumns();

                        // Series Initialization
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM");
                            Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                            string today = DateTime.Now.ToString("yyyyMMdd");
                            SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM");
                            oDBH.SetValue("U_DOCDATE", 0, today);

                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                            UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_OSCM");

                        }

                        // Branch combo
                        LoadUserBranches(oForm, "CBBRANCH");

                        //Amendment No
                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMNDNO").Specific).Value = "1";

                        //Payment Terms
                        string payTerms = @"SELECT ""GroupNum"", ""PymntGroup"" FROM ""OCTG""";
                        SAPbouiCOM.ComboBox CBPYTRMS = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPYTRMS").Specific;
                        Global.GFunc.setComboBoxValue(CBPYTRMS, payTerms);

                        //Shipping Type
                        string shipType = @"SELECT ""TrnspCode"", ""TrnspName"" FROM ""OSHP""";
                        SAPbouiCOM.ComboBox CBMDSHIP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMDSHIP").Specific;
                        Global.GFunc.setComboBoxValue(CBMDSHIP, shipType);

                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + ex.Message);
                    }
                    finally
                    {
                        if (oForm != null)
                        {
                            try
                            {
                                oForm.Freeze(false);
                            }
                            catch { }
                        }
                    }
                }
                //CAD
                else if (pVal.BeforeAction && pVal.MenuUID == "APP_TRN_MRD_CAD")
                {
                    string formUID = "FIL_FRM_CAD";
                    if (IsFormOpen(formUID))
                    {
                        Global.G_UI_Application.Forms.Item(formUID).Select();
                        Global.G_UI_Application.StatusBar.SetText("Form already opened once.",
                            SAPbouiCOM.BoMessageTime.bmt_Short,
                            SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                        return;
                    }

                    CAD activeForm = new CAD();
                    activeForm.Show();

                    SAPbouiCOM.Form oForm = null;

                    try
                    {
                        oForm = Application.SBO_Application.Forms.Item("FIL_FRM_CAD");
                        oForm.Freeze(true);

                        SAPbouiCOM.Matrix MTXCDCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCLR").Specific;
                        SAPbouiCOM.Matrix MTXMRCON = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMRCON").Specific;
                        SAPbouiCOM.Grid GRDSCLR = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSCLR").Specific;
                        SAPbouiCOM.Grid GRDSIZE = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSIZE").Specific;
                        SAPbouiCOM.Grid GRDCDCON = (SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific;


                        MTXCDCLR.AutoResizeColumns();
                        MTXMRCON.AutoResizeColumns();
                        GRDSCLR.AutoResizeColumns();
                        GRDSIZE.AutoResizeColumns();
                        GRDCDCON.AutoResizeColumns();

                        EnsureLine(oForm, "MTXMRCON", "@FIL_DR_CADMFAB");

                        // Series Initialization
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM");
                            Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                            string today = DateTime.Now.ToString("yyyyMMdd");
                            SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_CADFABCN");
                            oDBH.SetValue("U_DOCDATE", 0, today);

                            ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                            UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_CADFABCN");
                        }

                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.MessageBox("Error Found : " + ex.Message);
                    }
                    finally
                    {
                        if (oForm != null)
                        {
                            try
                            {
                                oForm.Freeze(false);
                            }
                            catch { }
                        }
                    }
                }
                //___________________________________________________________Standard______________________________________________
                //ADD
                else if (!pVal.BeforeAction && pVal.MenuUID == "1282")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_COMSTG":
                            {
                                SetComStageEnable(oForm);
                                break;
                            }
                        case "FIL_FRM_GENTYMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_SMPLMSTR":
                            {
                                //Initial State
                                SAPbouiCOM.Matrix MTSZ = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSIZE").Specific;
                                SAPbouiCOM.Matrix MTXCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                                SAPbouiCOM.Matrix MTXITM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                                SAPbouiCOM.Matrix MTXBYRS = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXBUYER").Specific;
                                SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                                MTSZ.AutoResizeColumns();
                                MTXCLR.AutoResizeColumns();
                                MTXITM.AutoResizeColumns();
                                MTXBYRS.AutoResizeColumns();
                                MTXATTAC.AutoResizeColumns();

                                // Series Initialization
                                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                {
                                    Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                                    string today = DateTime.Now.ToString("yyyyMMdd");
                                    SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_SMPLMAST");
                                    oDBH.SetValue("U_DOCDATE", 0, today);

                                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                                    UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_SMPLMAST");

                                }

                                //Sample Code Enable
                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = true;
                                //button disable 
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM", "ETSLTYNM", "ETITMGNM", "ETRUTSNM", "ETMERNAM", "ETCRDNAM");
                                break;
                            }
                        case "FIL_FRM_SMPLPCST":
                            {
                                // Series Initialization
                                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                {
                                    Global.GFunc.SetItemsEnabled(oForm, true, "ETSMPLCD", "CBSERIES", "ETDOCDAT");
                                    Global.GFunc.SetItemsEnabled(oForm, false, "ETSMPLNM", "ETBUYER", "ETBYRNM", "ETTCNAMT", "ETDOCNUM", "ETVERSON");
                                    Global.GFunc.ReEnableChooseFromList(oForm, "ETSMPLCD", "CFL_SMPL", "U_SMPLCODE");
                                    string today = DateTime.Now.ToString("yyyyMMdd");
                                    SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING");
                                    oDBH.SetValue("U_DOCDATE", 0, today);

                                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                                    UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_PRECOSTING");
                                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETVERSON").Specific).Value = "1"; //Default version 
                                }
                                
                                break;
                            }
                        case "FIL_FRM_ROUTEMSTR":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSTAGE").Specific;
                                oMatrix.Columns.Item("CLSTGCOD").Editable = true;
                                EnsureLine(oForm, "MTXSTAGE", "@FIL_MR_RSM1");
                                break;
                            }
                        case "FIL_FRM_SMPLTYPE":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                break;
                            }
                        case "FIL_FRM_CLR_MSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_SIZE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_USETYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_PRDLINE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_PRDTYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_PRDGRP":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_BRNDMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_SUBDVSN":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_SZTPMSTR":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSIZE").Specific;
                                oMatrix.Columns.Item("CLSZCODE").Editable = true;
                                EnsureLine(oForm, "MTXSIZE", "@FIL_MR_STM1");
                                break;
                            }
                        case "FIL_FRM_SMPLSTAT":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                break;
                            }
                        case "FIL_FRM_STYLMSTR":
                            {

                                    SAPbouiCOM.Matrix MTSZ = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSIZE").Specific;
                                    SAPbouiCOM.Matrix MTXCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCOLOR").Specific;
                                    SAPbouiCOM.Matrix MTXSBCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSBCLR").Specific;
                                    SAPbouiCOM.Matrix MTXITM = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                                    SAPbouiCOM.Matrix MTXATTAC = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                                    MTSZ.AutoResizeColumns();
                                    MTXCLR.AutoResizeColumns();
                                    MTXSBCLR.AutoResizeColumns();
                                    MTXITM.AutoResizeColumns();
                                    MTXATTAC.AutoResizeColumns();

                                    EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_PSMCO");
                                    EnsureLine(oForm, "MTXSBCLR", "@FIL_DR_SUBCLR");
                                    
                                    // Series Initialization
                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                    {
                                        Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM");
                                        Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                                        string today = DateTime.Now.ToString("yyyyMMdd");
                                        SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_OPSM");
                                        oDBH.SetValue("U_DOCDATE", 0, today);

                                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                                        UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_OPSM");

                                    }

                                Global.GFunc.SetItemsEnabled(oForm, false, "ETGENAME", "ETPDGPNM", "ETPDTPNM", "ETPDLNNM",
                                "ETBRNDNM", "ETDEPTNM", "ETSDSNNM", "ETPDTPCD", "ETPDLNCD","ETSMPLCD",
                                "ETDOCNUM", "ETSMPLNM", "ETSMTPNM", "ETRTSGNM", "ETMERDNM", "ETBUYRNM", "ETSMTPCD");

                                break;
                            }
                        case "FIL_FRM_OTT":
                            {
                                try
                                {
                                    oForm.Freeze(true);

                                    // Series Initialization
                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                    {
                                        Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM", "ETMERCNM");
                                        Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                                        string today = DateTime.Now.ToString("yyyyMMdd");
                                        SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_OTT");
                                        oDBH.SetValue("U_DOCDATE", 0, today);
                                        //DocDate
                                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                                        //OTT Date
                                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETOTDATE").Specific).Value = today;
                                        UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_OTT");
                                       
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Global.GFunc.ShowError("OTT initialization failed. " + ex.Message);
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
                                            // Ignore unfreeze exceptions
                                        }
                                    }
                                }
                               
                                break;
                            }
                        case "FIL_FRM_SLCNTRCT":
                            {
                                try
                                {
                                    oForm.Freeze(true);

                                    //Disable Field
                                    Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM", "ETCUSTNM", "ETBRNDNM", "ETDOVAL",
                                                    "CBDSNBNK", "ETCUSBNK", "ETOWNBNK", "ETAMNDNO");

                                    Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETCUSTMR", "CBDSNBNK", "CBMRSTAT", "CBCMSTAT", "ETBRNDCD", "ETSCNO", "ETISUDAT");
                                    ReBindCustomerCFL(oForm);

                                    SAPbouiCOM.Matrix MTXORDTL = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXORDTL").Specific;
                                    SAPbouiCOM.Matrix MTXB2BDL = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXB2BDL").Specific;
                                    SAPbouiCOM.Matrix MTXATTCH = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXATTCH").Specific;

                                    MTXORDTL.AutoResizeColumns();
                                    MTXB2BDL.AutoResizeColumns();
                                    MTXATTCH.AutoResizeColumns();

                                    // Series Initialization
                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                    {
                                        Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM");
                                        Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                                        string today = DateTime.Now.ToString("yyyyMMdd");
                                        SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_OSCM");
                                        oDBH.SetValue("U_DOCDATE", 0, today);

                                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                                        UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_OSCM");

                                    }

                                    LoadUserBranches(oForm, "CBBRANCH");

                                    //Amendment No
                                    ((SAPbouiCOM.EditText)oForm.Items.Item("ETAMNDNO").Specific).Value = "1";
                                    
                                    //Payment Terms
                                    string payTerms = @"SELECT ""GroupNum"", ""PymntGroup"" FROM ""OCTG""";
                                    SAPbouiCOM.ComboBox CBPYTRMS = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBPYTRMS").Specific;
                                    Global.GFunc.setComboBoxValue(CBPYTRMS, payTerms);

                                    //Shipping Type
                                    string shipType = @"SELECT ""TrnspCode"", ""TrnspName"" FROM ""OSHP""";
                                    SAPbouiCOM.ComboBox CBMDSHIP = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBMDSHIP").Specific;
                                    Global.GFunc.setComboBoxValue(CBMDSHIP, shipType);
                                }
                                catch (Exception ex)
                                {
                                    Application.SBO_Application.StatusBar.SetText(
                                        "Error: " + ex.Message,
                                        SAPbouiCOM.BoMessageTime.bmt_Short,
                                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                }
                                finally
                                {
                                    oForm.Freeze(false);
                                }

                                break;
                            }
                        case "FIL_FRM_ORDRTYPE":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, false, "BTNEWLN", "ETPRDNAM");
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETPRDCOD");
                                Global.GFunc.ReEnableChooseFromList(oForm, "ETPRDCOD", "CFL_PRD", "Code");
                                break;
                            }
                        case "FIL_FRM_LEADTIME":
                            {
                                try
                                {
                                    oForm.Freeze(true);

                                    // Series Initialization
                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                    {
                                        Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM");
                                        Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                                        string today = DateTime.Now.ToString("yyyyMMdd");
                                        SAPbouiCOM.DBDataSource oDBH =oForm.DataSources.DBDataSources.Item("@FIL_DH_LEADTMST");
                                        oDBH.SetValue("U_DOCDATE", 0, today);

                                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;

                                        UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_LEADTMST");
                                        LoadMatrixCombos(oForm);
                                        EnsureLine(oForm, "MTXLEDTM", "@FIL_DR_LEADTMST");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Global.GFunc.ShowError("Lead Time initialization failed. " + ex.Message);
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
                                            // Ignore unfreeze exceptions
                                        }
                                    }
                                }

                                break;
                            }
                        case "FIL_FRM_CPM":
                            {
                                try
                                {
                                    oForm.Freeze(true);
                                    Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");
                                    Global.GFunc.SetItemsEnabled(oForm, false, "ETBRNDNM", "ETPDGPNM", "ETRTSGNM", "ETDOCNUM");

                                    SAPbouiCOM.Matrix MTXSAMRN =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;
                                    MTXSAMRN.AutoResizeColumns();

                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                    {
                                        string today = DateTime.Now.ToString("yyyyMMdd");

                                        SAPbouiCOM.DBDataSource oDBH =oForm.DataSources.DBDataSources.Item("@FIL_DH_CPM");
                                        oDBH.SetValue("U_DOCDATE", 0, today);

                                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                                        UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_CPM");
                                    }

                                    HideSampleRateColumns(oForm);

                                }
                                catch (Exception ex)
                                {
                                    Global.GFunc.ShowError("CPM form initialization failed. " + ex.Message);
                                }
                                finally
                                {
                                    try
                                    {
                                        oForm.Freeze(false);
                                    }
                                    catch
                                    {
                                        // Ignore unfreeze exceptions
                                    }
                                }

                                break;
                            }
                        case "FIL_FRM_CAD":
                            {
                                try
                                {
                                    oForm.Freeze(true);

                                    SAPbouiCOM.Matrix MTXCDCLR = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCDCLR").Specific;
                                    SAPbouiCOM.Matrix MTXMRCON = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXMRCON").Specific;
                                    SAPbouiCOM.Grid GRDSCLR = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSCLR").Specific;
                                    SAPbouiCOM.Grid GRDSIZE = (SAPbouiCOM.Grid)oForm.Items.Item("GRDSIZE").Specific;
                                    SAPbouiCOM.Grid GRDCDCON = (SAPbouiCOM.Grid)oForm.Items.Item("GRDCDCON").Specific;


                                    MTXCDCLR.AutoResizeColumns();
                                    MTXMRCON.AutoResizeColumns();
                                    GRDSCLR.AutoResizeColumns();
                                    GRDSIZE.AutoResizeColumns();
                                    GRDCDCON.AutoResizeColumns();

                                    EnsureLine(oForm, "MTXMRCON", "@FIL_DR_CADMFAB");

                                    // Series Initialization
                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                                    {
                                        Global.GFunc.SetItemsEnabled(oForm, false, "ETDOCNUM", "ETSTYLDS", "ETMERCNM");
                                        Global.GFunc.SetItemsEnabled(oForm, true, "CBSERIES", "ETDOCDAT");

                                        string today = DateTime.Now.ToString("yyyyMMdd");
                                        SAPbouiCOM.DBDataSource oDBH = oForm.DataSources.DBDataSources.Item("@FIL_DH_CADFABCN");
                                        oDBH.SetValue("U_DOCDATE", 0, today);

                                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETDOCDAT").Specific).Value = today;
                                        UpdateSeriesAndDocNumByDate(oForm, oDBH, today, "FIL_D_CADFABCN");

                                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETSLCLR").Specific).Value = "";
                                        ((SAPbouiCOM.EditText)oForm.Items.Item("ETCDCLR").Specific).Value = "";
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Application.SBO_Application.MessageBox("Error Found : " + ex.Message);
                                }
                                finally
                                {
                                    if (oForm != null)
                                    {
                                        try
                                        {
                                            oForm.Freeze(false);
                                        }
                                        catch { }
                                    }
                                }
                                break;
                            }
                        case "FIL_FRM_PARAMSTR":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                break;
                            }
                        case "FIL_FRM_OCSTPRM":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCUSCOD");
                                Global.GFunc.SetItemsEnabled(oForm, false, "ETCUSNAM");
                                break;
                            }
                        case "FIL_FRM_INCOTRMS":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                break;
                            }
                        case "FIL_FRM_SAM":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, false, "ETDESC");
                                break;
                            }
                    }
                }
                //Find Mode
                else if (!pVal.BeforeAction && pVal.MenuUID == "1281")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_SMPLTYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;

                                break;
                            }
                        case "FIL_FRM_SMPLMSTR":
                            {
                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = true;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                Global.GFunc.SetItemsEnabled(oForm, false, "CBSERIES");
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETDOCNUM", "ETSLTYNM", "ETITMGNM", 
                                                            "ETRUTSNM", "ETMERNAM", "ETCRDNAM","ETDOCDAT");
                                SampleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLPCST":
                            {
                                //Enable off
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETSMPLNM", "ETBUYER", "ETBYRNM", "ETDOCNUM", "ETSMPLCD",
                                                                          "ETVERSON", "ETTCNAMT", "ETDOCDAT");
                                Global.GFunc.SetItemsEnabled(oForm, false,"CBSERIES");

                                break;
                            }
                        case "FIL_FRM_ROUTEMSTR":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                break;
                            }
                        case "FIL_FRM_CLR_MSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;

                                break;
                            }
                        case "FIL_FRM_GENTYMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_PSTN_MSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_SIZE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_COMSTG":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_PRDLINE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_PRDTYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_PRDGRP":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE", "ETGENDER", "ETPDTPNM", "ETPDLNNM");
                                break;
                            }
                        case "FIL_FRM_BRNDMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_SUBDVSN":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_SZTPMSTR":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_SMPLSTAT":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                break;
                            }
                        case "FIL_FRM_STYLMSTR":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETSLCODE", "ETGENAME", "ETPDGPNM", "ETPDTPNM", "ETPDLNNM", 
                                "ETBRNDNM", "ETDEPTNM", "ETSDSNNM", "ETPDTPCD", "ETPDLNCD", "ETSMPLCD",
                                "ETDOCNUM", "ETSMPLNM", "ETSMTPNM", "ETRTSGNM", "ETMERDNM", "ETBUYRNM","ETSMTPCD");
                                Global.GFunc.SetItemsEnabled(oForm, false, "CBSERIES");
                                break;
                            }
                        case "FIL_FRM_OTT":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETDOCNUM", "ETMERCNM");
                                Global.GFunc.SetItemsEnabled(oForm, false, "CBSERIES");
                                break;
                            }
                        case "FIL_FRM_SLCNTRCT":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true,  "ETDOCNUM", "ETCUSTNM", "ETBRNDNM", "CBMRSTAT", "CBCMSTAT", 
                                                                           "ETCUSTMR", "ETBRNDNM", "ETSCNO", "ETBRNDCD",
                                                                           "ETISUDAT", "ETDOVAL", "CBDSNBNK", "ETCUSBNK", "ETOWNBNK", "ETAMNDNO") ;
                                Global.GFunc.SetItemsEnabled(oForm,false,"CBSERIES");
                                break;
                            }
                        case "FIL_FRM_USETYPE":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = true;
                                break;
                            }
                        case "FIL_FRM_ORDRTYPE":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETPRDNAM");
                                Global.GFunc.SetItemsEnabled(oForm, false, "BTNEWLN");
                                break;
                            }
                        case "FIL_FRM_LEADTIME":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETDOCNUM", "ETDOCDAT");

                                break;
                            }
                        case "FIL_FRM_CPM":
                            {
                                HideSampleRateColumns(oForm);
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETDOCNUM", "ETBRNDNM", "ETPDGPNM", "ETRTSGNM", "ETDOCDAT");
                                Global.GFunc.SetItemsEnabled(oForm, false, "CBSERIES");

                                break;
                            }
                        case "FIL_FRM_CAD":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETDOCNUM", "ETDOCDAT", "ETMERCNM", "ETSTYLDS");
                                Global.GFunc.SetItemsEnabled(oForm, false, "CBSERIES");
                                ((SAPbouiCOM.EditText)oForm.Items.Item("ETSLCLR").Specific).Value = "";
                                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCDCLR").Specific).Value = "";
                                break;
                            }
                        case "FIL_FRM_PARAMSTR":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                break;
                            }
                        case "FIL_FRM_OCSTPRM":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCUSNAM", "ETCUSCOD");
                                break;
                            }
                        case "FIL_FRM_INCOTRMS":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETCODE");
                                break;
                            }
                        case "FIL_FRM_SAM":
                            {
                                Global.GFunc.SetItemsEnabled(oForm, true, "ETDESC");
                                break;
                            }
                    }
                }
                //First
                else if (!pVal.BeforeAction && pVal.MenuUID == "1288")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_COMSTG":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                SetComStageEnable(oForm);
                                break;
                            }
                        case "FIL_FRM_SMPLMSTR":
                            {
                                //Matrix Open 
                                EnsureLine(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE");
                                EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO");
                                EnsureLine(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER");
                                AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO", "U_COLOCODE");
                                AddLineIfLastRowHasValue(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE", "U_SIZECODE");
                                AddLineIfLastRowHasValue(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER", "U_CARDCODE");

                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = false;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                SampleEnableButtons(oForm);
                                break;
                            }

                    }
                }
                //Previous
                else if (!pVal.BeforeAction && pVal.MenuUID == "1289")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                       
                        case "FIL_FRM_SMPLMSTR":
                            {
                                //Matrix Open 
                                EnsureLine(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE");
                                EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO");
                                EnsureLine(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER");
                                AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO", "U_COLOCODE");
                                AddLineIfLastRowHasValue(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE", "U_SIZECODE");
                                AddLineIfLastRowHasValue(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER", "U_CARDCODE");

                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = false;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                SampleEnableButtons(oForm);
                                break;
                            }

                        case "FIL_FRM_COMSTG":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                SetComStageEnable(oForm);
                                break;
                            }
                        
                       
                    }
                }
                //Next
                else if (!pVal.BeforeAction && pVal.MenuUID == "1290")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        
                        case "FIL_FRM_SMPLMSTR":
                            {
                                //Matrix Open 
                                EnsureLine(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE");
                                EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO");
                                EnsureLine(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER");
                                AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO", "U_COLOCODE");
                                AddLineIfLastRowHasValue(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE", "U_SIZECODE");
                                AddLineIfLastRowHasValue(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER", "U_CARDCODE");

                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = false;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                SampleEnableButtons(oForm);
                                break;
                            }
                        case "FIL_FRM_COMSTG":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                SetComStageEnable(oForm);
                                break;
                            }
                    }
                }
                //Last
                else if (!pVal.BeforeAction && pVal.MenuUID == "1291")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        
                        case "FIL_FRM_SMPLMSTR":
                            {
                                //Matrix Open 
                                EnsureLine(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE");
                                EnsureLine(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO");
                                EnsureLine(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER");
                                AddLineIfLastRowHasValue(oForm, "MTXCOLOR", "@FIL_DR_SMPLCOLO", "U_COLOCODE");
                                AddLineIfLastRowHasValue(oForm, "MTXSIZE", "@FIL_DR_SMPLSIZE", "U_SIZECODE");
                                AddLineIfLastRowHasValue(oForm, "MTXBUYER", "@FIL_DR_SMPLBUYER", "U_CARDCODE");

                                SAPbouiCOM.Item oSampleCode = oForm.Items.Item("ETSLCODE");
                                oSampleCode.Enabled = false;
                                //button  
                                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");
                                oBtnItmCr.Enabled = false;
                                oBtnItmTx.Enabled = false;
                                SampleEnableButtons(oForm);
                                break;
                            }

                        case "FIL_FRM_COMSTG":
                            {
                                SAPbouiCOM.Item oUomItem = oForm.Items.Item("ETCODE");
                                oUomItem.Enabled = false;
                                SetComStageEnable(oForm);
                                break;
                            }                  
                    }
                }
                //duplicate
                else if (!pVal.BeforeAction && pVal.MenuUID == "1287")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {


                    }
                }
                else if (pVal.BeforeAction && pVal.MenuUID == "FIL_DUPL")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                       
                    }
                }
                //Delete Row 
                else if (pVal.BeforeAction && pVal.MenuUID == "1293")
                {
                    SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;
                    string formtype = oForm.UniqueID.ToString();
                    switch (formtype)
                    {
                        case "FIL_FRM_ORDRTYPE":
                            {
                                SAPbouiCOM.Matrix matrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXORDR").Specific;
                                int lastRow = matrix.VisualRowCount;
                                int currentRow =matrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                                if (currentRow <= 0)
                                {
                                    SAPbouiCOM.CellPosition cellPos = matrix.GetCellFocus();
                                    currentRow = cellPos.rowIndex;
                                }

                                if (currentRow != lastRow)
                                {
                                    Application.SBO_Application.StatusBar.SetText(
                                        "Only last row can be deleted.",
                                        SAPbouiCOM.BoMessageTime.bmt_Short,
                                        SAPbouiCOM.BoStatusBarMessageType.smt_Error
                                    );

                                    BubbleEvent = false;
                                    return;
                                }

                                break;
                            }
                        case "FIL_FRM_CPM":
                            {
                                SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;
                                int lastRow = matrix.VisualRowCount;
                                int currentRow = matrix.GetNextSelectedRow(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                                if (currentRow <= 0)
                                {
                                    SAPbouiCOM.CellPosition cellPos = matrix.GetCellFocus();
                                    currentRow = cellPos.rowIndex;
                                }

                                if (currentRow != lastRow)
                                {
                                    Application.SBO_Application.StatusBar.SetText(
                                        "Only last row can be deleted.",
                                        SAPbouiCOM.BoMessageTime.bmt_Short,
                                        SAPbouiCOM.BoStatusBarMessageType.smt_Error
                                    );

                                    BubbleEvent = false;
                                    return;
                                }

                                break;
                            }
                    }
                }
                else if (!pVal.BeforeAction && pVal.MenuUID == "1293")
                {
                    SAPbouiCOM.Form oForm = null;

                    try
                    {
                        oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.ActiveForm;

                        if (oForm == null)
                            return;

                        string formtype = oForm.UniqueID.ToString();

                        switch (formtype)
                        {
                            case "FIL_FRM_ORDRTYPE":
                                {
                                    oForm.Freeze(true);

                                    SAPbouiCOM.Matrix matrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXORDR").Specific;
                                    SAPbouiCOM.DBDataSource db =oForm.DataSources.DBDataSources.Item("@FIL_MR_ORDRTYPE");
                                    matrix.FlushToDataSource();

                                    // Remove ghost rows after SAP 1293 delete
                                    for (int i = db.Size - 1; i >= 0; i--)
                                    {
                                        string minQtyText = db.GetValue("U_MINQTY", i).Trim();
                                        string maxQtyText = db.GetValue("U_MAXQTY", i).Trim();

                                        double minQty = 0;
                                        double maxQty = 0;

                                        double.TryParse(minQtyText, out minQty);
                                        double.TryParse(maxQtyText, out maxQty);

                                        if (minQty <= 0 && maxQty <= 0)
                                        {
                                            db.RemoveRecord(i);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    matrix.LoadFromDataSource();

                                    // Re-number rows
                                    for (int i = 1; i <= matrix.VisualRowCount; i++)
                                    {
                                        ((SAPbouiCOM.EditText)matrix.Columns.Item("#").Cells.Item(i).Specific).Value =
                                            i.ToString();

                                        ((SAPbouiCOM.EditText)matrix.Columns.Item("CLCODE").Cells.Item(i).Specific).Value =
                                            "Code " + i;
                                    }

                                    matrix.FlushToDataSource();

                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                        oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                                    SetOrderTypeMatrixEditableAfterDelete(matrix);
                                    matrix.AutoResizeColumns();

                                    break;
                                }
                            case "FIL_FRM_LEADTIME":
                                {
                                    HandleLeadTimeDeleteAfter(oForm);
                                    break;
                                }
                            case "FIL_FRM_CPM":
                                {
                                    oForm.Freeze(true);

                                    SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXSAMRN").Specific;
                                    SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item("@FIL_DR_SAMRNG");
                                    matrix.FlushToDataSource();

                                    // Remove ghost rows after SAP 1293 delete
                                    for (int i = db.Size - 1; i >= 0; i--)
                                    {
                                        string fromQtyText = db.GetValue("U_SAMFROM", i).Trim();
                                        string toQtyText = db.GetValue("U_SAMTO", i).Trim();

                                        double fromQty = 0;
                                        double toQty = 0;

                                        double.TryParse(fromQtyText, out fromQty);
                                        double.TryParse(toQtyText, out toQty);

                                        if (fromQty <= 0 && toQty <= 0)
                                        {
                                            db.RemoveRecord(i);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    matrix.LoadFromDataSource();

                                    // Re-number rows
                                    for (int i = 1; i <= matrix.VisualRowCount; i++)
                                    {
                                        ((SAPbouiCOM.EditText)matrix.Columns.Item("#").Cells.Item(i).Specific).Value =
                                            i.ToString();

                                        ((SAPbouiCOM.EditText)matrix.Columns.Item("CLCODE").Cells.Item(i).Specific).Value =
                                            "SAM Range " + i;
                                    }

                                    matrix.FlushToDataSource();

                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                        oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                                    SetCPMMatrixEditableAfterDelete(matrix);
                                    matrix.AutoResizeColumns();
                                    break;
                                }

                            case "FIL_FRM_OCSTPRM":
                                {
                                    oForm.Freeze(true);

                                    SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCSPRM").Specific;
                                    SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item("@FIL_MR_CSOTHCST");

                                    matrix.FlushToDataSource();

                                    // Remove ghost rows
                                    for (int i = db.Size - 1; i >= 0; i--)
                                    {
                                        if (string.IsNullOrWhiteSpace(db.GetValue("U_PRMCODE", i).Trim()))
                                            db.RemoveRecord(i);
                                    }

                                    // Reset LineId
                                    for (int i = 0; i < db.Size; i++)
                                    {
                                        db.SetValue("LineId", i, (i + 1).ToString());
                                    }

                                    matrix.LoadFromDataSource();

                                    if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                                        oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                                    // Add a new blank row at the end
                                    Global.GFunc.AddLineIfLastRowHasValue(oForm,"MTXCSPRM","@FIL_MR_CSOTHCST","U_PRMCODE");
                                    matrix.AutoResizeColumns();

                                    break;
                                }
                            case "FIL_FRM_SMPLPCST":
                                {
                                    try
                                    {
                                        oForm.Freeze(true);

                                        HandleSamplePreCostingDeleteAfter(oForm);
                                    }
                                    catch (Exception ex)
                                    {
                                        Global.GFunc.ShowError("Sample PreCosting Delete Error: " + ex.Message);
                                    }
                                    finally
                                    {
                                        try
                                        {
                                            oForm.Freeze(false);
                                        }
                                        catch
                                        {
                                        }
                                    }

                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        Application.SBO_Application.StatusBar.SetText(
                            "Delete Row After Error: " + ex.Message,
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
                            catch { }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }

        //_____________________________________________________ Method for Working Purpose________________________________________
        private void HandleSamplePreCostingDeleteAfter(SAPbouiCOM.Form oForm)
        {
            try
            {

                SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCMPNT").Specific;
                SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item("@FIL_DR_PRECOSTCOMP");

                matrix.FlushToDataSource();

                for (int i = db.Size - 1; i >= 0; i--)
                {
                    string routeStage = db.GetValue("U_ROUTSTAG", i).Trim();
                    string componentStage = db.GetValue("U_COMPSTAG", i).Trim();

                    if (string.IsNullOrWhiteSpace(routeStage) && string.IsNullOrWhiteSpace(componentStage))
                        db.RemoveRecord(i);
                }

                for (int i = 0; i < db.Size; i++)
                    db.SetValue("LineId", i, (i + 1).ToString());

                matrix.LoadFromDataSource();

                for (int i = 1; i <= matrix.VisualRowCount; i++)
                    ((SAPbouiCOM.EditText)matrix.Columns.Item("#").Cells.Item(i).Specific).Value = i.ToString();

                matrix.FlushToDataSource();

                UpdateSamplePreCostingTotalsAfterDelete(oForm);

                Global.GFunc.AddLineIfLastRowHasValue(oForm, "MTXCMPNT", "@FIL_DR_PRECOSTCOMP", "U_ROUTSTAG");

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                matrix.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sample PreCosting Row Delete Error: " + ex.Message);
            }
        }
        private void UpdateSamplePreCostingTotalsAfterDelete(SAPbouiCOM.Form oForm)
        {
            try
            {
                double componentTotal = GetSamplePreCostingMatrixSum(oForm, "MTXCMPNT", true);
                double otherCostTotal = GetSamplePreCostingMatrixSum(oForm, "MTXOTCST", false);
                double totalCost = componentTotal + otherCostTotal;

                SAPbouiCOM.EditText etProfitPercent = (SAPbouiCOM.EditText)oForm.Items.Item("ETPRFPER").Specific;

                double profitPercent = GetSamplePreCostingValue(etProfitPercent.Value);

                if (profitPercent < 0)
                    profitPercent = 0;

                double profitAmount = totalCost * profitPercent / 100;
                double fobAmount = totalCost + profitAmount;

                string componentValue = componentTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                string otherCostValue = otherCostTotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                string totalCostValue = totalCost.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                string profitPercentValue = profitPercent.ToString("0.####", System.Globalization.CultureInfo.InvariantCulture);
                string profitAmountValue = profitAmount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                string fobAmountValue = fobAmount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                SAPbouiCOM.DBDataSource headerDB = oForm.DataSources.DBDataSources.Item("@FIL_DH_PRECOSTING");

                headerDB.SetValue("U_TOTCAMNT", 0, componentValue);
                headerDB.SetValue("U_TOTOAMNT", 0, otherCostValue);
                headerDB.SetValue("U_TOTCONAMT", 0, totalCostValue);
                headerDB.SetValue("U_PROFITPC", 0, profitPercentValue);
                headerDB.SetValue("U_PROFITAM", 0, profitAmountValue);
                headerDB.SetValue("U_FOBAMUNT", 0, fobAmountValue);

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETCMTAMT").Specific).Value = componentValue;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETOCTAMT").Specific).Value = otherCostValue;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETTCNAMT").Specific).Value = totalCostValue;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETPRFPER").Specific).Value = profitPercentValue;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETPRFAMT").Specific).Value = profitAmountValue;
                ((SAPbouiCOM.EditText)oForm.Items.Item("ETFOBAMT").Specific).Value = fobAmountValue;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Sample PreCosting Total Calculation Error: " + ex.Message);
            }
        }
        private double GetSamplePreCostingMatrixSum(SAPbouiCOM.Form oForm, string matrixId, bool checkRouteStage)
        {
            double total = 0;

            SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixId).Specific;

            for (int i = 1; i <= matrix.VisualRowCount; i++)
            {
                if (checkRouteStage)
                {
                    string routeStage = ((SAPbouiCOM.ComboBox)matrix.Columns.Item("CLRSTGCD").Cells.Item(i).Specific).Value.Trim();

                    if (string.IsNullOrWhiteSpace(routeStage))
                        continue;
                }

                string amountText = ((SAPbouiCOM.EditText)matrix.Columns.Item("CLAMT").Cells.Item(i).Specific).Value;

                total += GetSamplePreCostingValue(amountText);
            }

            return total;
        }
        private double GetSamplePreCostingValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            value = value.Trim().Replace(",", "");

            if (double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double result))
                return result;

            if (double.TryParse(value, out result))
                return result;

            return 0;
        }
        private void UpdateSeriesAndDocNumByDate(
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
            for (int i = combo.ValidValues.Count - 1; i >= 0; i--)
            {
                try
                {
                    combo.ValidValues.Remove(i, SAPbouiCOM.BoSearchKey.psk_Index);
                }
                catch { }
            }
        }

        private void HideSampleRateColumns(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                SAPbouiCOM.Matrix oMatrix =
                    (SAPbouiCOM.Matrix)oForm.Items.Item("MTXCPM").Specific;

                for (int i = 1; i <= 10; i++)
                {
                    try
                    {
                        oMatrix.Columns.Item($"CLSAMR{i}").Visible = false;
                    }
                    catch
                    {
                        // Ignore if the column does not exist
                    }
                }

                oMatrix.AutoResizeColumns();
            }
            finally
            {
                oForm.Freeze(false);
            }
        }

        private void HandleLeadTimeDeleteAfter(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                SAPbouiCOM.Matrix oMatrix =(SAPbouiCOM.Matrix)oForm.Items.Item("MTXLEDTM").Specific;
                SAPbouiCOM.DBDataSource db =oForm.DataSources.DBDataSources.Item("@FIL_DR_LEADTMST");
                oMatrix.FlushToDataSource();

                // Remove fully blank/ghost rows after SAP 1293 delete
                for (int i = db.Size - 1; i >= 0; i--)
                {
                    string vendorCode = db.GetValue("U_CARDCODE", i).Trim();
                    string country = db.GetValue("U_CONTRYCODE", i).Trim();
                    string shipMode = db.GetValue("U_SHIPMODE", i).Trim();
                    string incoterms = db.GetValue("U_INCOTRMS", i).Trim();
                    string itemGroup = db.GetValue("U_ITMGRPCD", i).Trim();
                    string leadDays = db.GetValue("U_LEADDAYS", i).Trim();

                    if (string.IsNullOrWhiteSpace(vendorCode) &&
                        string.IsNullOrWhiteSpace(country) &&
                        string.IsNullOrWhiteSpace(shipMode) &&
                        string.IsNullOrWhiteSpace(incoterms) &&
                        string.IsNullOrWhiteSpace(itemGroup) &&
                        string.IsNullOrWhiteSpace(leadDays))
                    {
                        db.RemoveRecord(i);
                    }
                }

                // Case 1: all rows deleted
                if (db.Size == 0)
                {
                    oMatrix.LoadFromDataSource();
                    EnsureLine(oForm, "MTXLEDTM", "@FIL_DR_LEADTMST");
                }
                else
                {
                    // Maintain LineId
                    for (int i = 0; i < db.Size; i++)
                    {
                        db.SetValue("LineId", i, (i + 1).ToString());
                    }

                    oMatrix.LoadFromDataSource();

                    // Maintain visual row number
                    for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                    {
                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("#").Cells.Item(i).Specific).Value =
                            i.ToString();
                    }

                    oMatrix.FlushToDataSource();

                    // Optional: if last row has data, add new blank line
                    AddLineIfLastRowHasValue(oForm,"MTXLEDTM","@FIL_DR_LEADTMST","U_CARDCODE");
                }

                if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_UPDATE_MODE;

                oMatrix.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Lead Time Delete Row Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                try { oForm.Freeze(false); } catch { }
            }
        }

        private void LoadMatrixCombos(SAPbouiCOM.Form oForm)
        {
            try
            {
                oForm.Freeze(true);

                SAPbouiCOM.Matrix oMatrix =
                    (SAPbouiCOM.Matrix)oForm.Items.Item("MTXLEDTM").Specific;

                // Shipping Mode
                Global.GFunc.SetMatrixComboValue(
                    oMatrix,
                    "CLSHPMOD",
                    @"SELECT
                ""TrnspCode"",
                ""TrnspName""
              FROM ""OSHP""
              ORDER BY ""TrnspName"""
                );

                // Incoterms
                Global.GFunc.SetMatrixComboValue(
                    oMatrix,
                    "CLINTRMS",
                    @"SELECT
                ""Code"",
                ""Name""
              FROM ""@FIL_MH_INCOTRMS""
              WHERE ""U_ACTIVE"" = 'Y'
              ORDER BY ""Name"""
                );
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Matrix Combo Load Error : " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
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



        


        private void LoadUserBranches(SAPbouiCOM.Form oForm, string comboId)
        {
            try
            {
                int userSign = Global.oComp.UserSignature;

                string sql = $@"
                                SELECT DISTINCT
                                    T0.""BPLId"",
                                    T0.""BPLName""
                                FROM ""OBPL"" T0
                                INNER JOIN ""USR6"" T1
                                    ON T0.""BPLId"" = T1.""BPLId""
                                WHERE T1.""UserID"" = {userSign}
                                ORDER BY T0.""BPLName""";

                SAPbouiCOM.ComboBox oCombo =
                    (SAPbouiCOM.ComboBox)oForm.Items.Item(comboId).Specific;

                Global.GFunc.setComboBoxValue(oCombo, sql);

                if (oCombo.ValidValues.Count == 1)
                {
                    oCombo.Select(
                        oCombo.ValidValues.Item(0).Value,
                        SAPbouiCOM.BoSearchKey.psk_ByValue);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "LoadUserBranches Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        private void ReBindCustomerCFL(SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.EditText txtCustomer =
                (SAPbouiCOM.EditText)oForm.Items.Item("ETCUSTMR").Specific;

            txtCustomer.ChooseFromListUID = "CFL_OCRD";
            txtCustomer.ChooseFromListAlias = "CardCode";
        }

        private bool ValidValueExists(SAPbouiCOM.Column col, string value)
        {
            for (int i = 0; i < col.ValidValues.Count; i++)
            {
                if (col.ValidValues.Item(i).Value == value)
                    return true;
            }
            return false;
        }

        private void SetCPMMatrixEditableAfterDelete(SAPbouiCOM.Matrix matrix)
        {
            int fromQtyColNo = GetMatrixColumnNumber(matrix, "CLFROM");
            int toQtyColNo = GetMatrixColumnNumber(matrix, "CLTO");

            if (fromQtyColNo <= 0 || toQtyColNo <= 0)
                return;

            int rowCount = matrix.VisualRowCount;

            if (rowCount <= 0)
                return;

            // If only one row remains:
            // CLMINQTY and CLMAXQTY both editable
            if (rowCount == 1)
            {
                matrix.CommonSetting.SetCellEditable(1, fromQtyColNo, true);
                matrix.CommonSetting.SetCellEditable(1, toQtyColNo, true);
                return;
            }

            // If more than one row:
            // CLMINQTY disabled for all rows
            // CLMAXQTY enabled only for last row
            for (int i = 1; i <= rowCount; i++)
            {
                matrix.CommonSetting.SetCellEditable(i, fromQtyColNo, false);
                matrix.CommonSetting.SetCellEditable(i, toQtyColNo, i == rowCount);
            }
        }

        private void SetOrderTypeMatrixEditableAfterDelete(SAPbouiCOM.Matrix matrix)
        {
            int minQtyColNo = GetMatrixColumnNumber(matrix, "CLMINQTY");
            int maxQtyColNo = GetMatrixColumnNumber(matrix, "CLMAXQTY");

            if (minQtyColNo <= 0 || maxQtyColNo <= 0)
                return;

            int rowCount = matrix.VisualRowCount;

            if (rowCount <= 0)
                return;

            // If only one row remains:
            // CLMINQTY and CLMAXQTY both editable
            if (rowCount == 1)
            {
                matrix.CommonSetting.SetCellEditable(1, minQtyColNo, true);
                matrix.CommonSetting.SetCellEditable(1, maxQtyColNo, true);
                return;
            }

            // If more than one row:
            // CLMINQTY disabled for all rows
            // CLMAXQTY enabled only for last row
            for (int i = 1; i <= rowCount; i++)
            {
                matrix.CommonSetting.SetCellEditable(i, minQtyColNo, false);
                matrix.CommonSetting.SetCellEditable(i, maxQtyColNo, i == rowCount);
            }
        }

        private int GetMatrixColumnNumber(SAPbouiCOM.Matrix oMatrix, string colUID)
        {
            for (int i = 1; i <= oMatrix.Columns.Count; i++)
            {
                if (oMatrix.Columns.Item(i).UniqueID == colUID)
                    return i;
            }

            return -1;
        }

        private void SampleEnableButtons(SAPbouiCOM.Form oForm)
        {
            try
            {
                // Only run in VIEW or OK mode
                if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_VIEW_MODE &&
                    oForm.Mode != SAPbouiCOM.BoFormMode.fm_OK_MODE)
                    return;

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("MTXITEM").Specific;
                SAPbouiCOM.EditText oSampleId = (SAPbouiCOM.EditText)oForm.Items.Item("ETSLCODE").Specific;
                SAPbouiCOM.EditText oDocEntry = (SAPbouiCOM.EditText)oForm.Items.Item("ETDOCTRY").Specific;
                string sampleId = oSampleId.Value.Trim();
                string docEntry = oDocEntry.Value.Trim();

                SAPbouiCOM.Item oBtnItmTx = oForm.Items.Item("BTNITMTX");
                SAPbouiCOM.Item oBtnItmCr = oForm.Items.Item("BTNITMCR");

                bool matrixEmpty = false;

                // --- Check if matrix is empty or has only 1 blank row ---
                if (oMatrix.RowCount == 0 || oMatrix.VisualRowCount == 0)
                {
                    matrixEmpty = true;
                }
                else if (oMatrix.RowCount == 1)
                {
                    SAPbouiCOM.EditText cell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("CLCLRCOD").Cells.Item(1).Specific;
                    if (string.IsNullOrEmpty(cell.Value.Trim()))
                        matrixEmpty = true;
                }

                // --- Case 1: Matrix empty or one blank row ---
                if (matrixEmpty)
                {
                    oBtnItmCr.Enabled = false;

                    // Must have SampleId first
                    if (string.IsNullOrEmpty(sampleId))
                    {
                        oBtnItmTx.Enabled = false;
                        return;
                    }

                    // Must have DocEntry to validate color/size
                    if (string.IsNullOrEmpty(docEntry))
                    {
                        oBtnItmTx.Enabled = false;
                        return;
                    }

                    // Validate: at least 1 color + 1 size exists for this DocEntry
                    SAPbobsCOM.Recordset oRecVal = (SAPbobsCOM.Recordset)
                        Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                   string validateQuery = $@"
                                        SELECT 
                                            (SELECT COUNT(*) 
                                               FROM ""@FIL_DR_SMPLCOLO"" 
                                              WHERE ""DocEntry"" = '{docEntry}'
                                                AND IFNULL(""U_COLOCODE"", '') <> '') AS ""ColorCnt"",
                                            (SELECT COUNT(*) 
                                               FROM ""@FIL_DR_SMPLSIZE"" 
                                              WHERE ""DocEntry"" = '{docEntry}'
                                                AND IFNULL(""U_SIZECODE"", '') <> '') AS ""SizeCnt""
                                        FROM ""DUMMY""";

                    oRecVal.DoQuery(validateQuery);

                    int colorCnt = 0, sizeCnt = 0;
                    if (!oRecVal.EoF)
                    {
                        colorCnt = Convert.ToInt32(oRecVal.Fields.Item("ColorCnt").Value);
                        sizeCnt = Convert.ToInt32(oRecVal.Fields.Item("SizeCnt").Value);
                    }

                    // Enable BTNITMTX only if both exist
                    oBtnItmTx.Enabled = (colorCnt >= 1 && sizeCnt >= 1);

                    return;
                }

                // --- Case 2: Matrix has data ---
                oBtnItmTx.Enabled = false;
                bool enableBtnItmCr = false;

                // 1️⃣ Check DB only if StyleID is not empty //****need to verify****
                if (!string.IsNullOrEmpty(sampleId))
                {
                    SAPbobsCOM.Recordset oRec = (SAPbobsCOM.Recordset)
                        Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                    string query = $"SELECT 1 FROM \"@FIL_DR_SMPLITEM\" WHERE \"DocEntry\" = '{docEntry}'";
                    oRec.DoQuery(query);
                    enableBtnItmCr = !oRec.EoF; // True if record exists
                }

                // 2️⃣ Check if all checkboxes in CLCREAT column are checked
                bool allChecked = true;
                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    SAPbouiCOM.CheckBox chk = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("CLCREAT").Cells.Item(i).Specific;
                    if (!chk.Checked)
                    {
                        allChecked = false;
                        break;
                    }
                }

                // Final decision for BTNITMCR
                oBtnItmCr.Enabled = enableBtnItmCr && !allChecked;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in StyleEnableButtons: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                );
            }
        }


        public bool IsFormOpen(string formUID)
        {
            try
            {
                foreach (SAPbouiCOM.Form form in Application.SBO_Application.Forms)
                {
                    if (form.UniqueID == formUID)
                    {
                        // Check if it's visible and not closed
                        if (form.Visible)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.G_UI_Application.StatusBar.SetText("Error checking form: " + ex.Message,
                   SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            return false; // Form is not open
        }



       
        public static void EnsureLine(SAPbouiCOM.Form oForm, string matrixID, string dbTable)
        {
            SAPbouiCOM.Matrix matrix = (SAPbouiCOM.Matrix)oForm.Items.Item(matrixID).Specific;
            SAPbouiCOM.DBDataSource db = oForm.DataSources.DBDataSources.Item(dbTable);
            if (matrix.RowCount == 0)
            {
                Global.GFunc.SetNewLine(matrix, db, 1, "");
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

        private void SetComStageEnable(SAPbouiCOM.Form oForm)
        {
            if (oForm == null)
                return;

            SAPbouiCOM.Item itmCode = oForm.Items.Item("ETCODE");
            SAPbouiCOM.Item itmUOM = oForm.Items.Item("ETUOM");
            SAPbouiCOM.ComboBox cbUOMApply = (SAPbouiCOM.ComboBox)oForm.Items.Item("CBUOMAPL").Specific;


            itmCode.Enabled = (oForm.Mode != SAPbouiCOM.BoFormMode.fm_OK_MODE);


            string uomApplyVal = "";

            if (cbUOMApply.Selected != null)
                uomApplyVal = cbUOMApply.Selected.Value;

            if (uomApplyVal == "Y")
            {
                itmUOM.Enabled = true;
            }
            else
            {
                itmUOM.Enabled = false;
                ((SAPbouiCOM.EditText)itmUOM.Specific).Value = "";
            }
        }

        //________________________________________________________ Connection Related Method_____________________________________________ 

        private bool CompanyConnection(string _AddonId)
        {

            try
            {
                string sErrorMsg;
                string cookie;
                string connStr;
                // Global.ocomp.
                Global.oComp = new SAPbobsCOM.Company();
                cookie = Global.oComp.GetContextCookie();
                //    Global.oCompany = new SAPbobsCOM.Company();
                //   cookie =Global.oCompany.GetContextCookie();
                connStr = Application.SBO_Application.Company.GetConnectionContext(cookie);
                Global.oComp.SetSboLoginContext(connStr);
                ////   if (Global.CF.IsSAPHANA())
                ////  {
                ////   Global.oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
                //// }
                //// else
                //// {
                //Global.ocomp.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2019;
                // }
                // Global.oCompany.Connect();
                Global.G_UI_Application = Application.SBO_Application;
                Global.oComp = (SAPbobsCOM.Company)Application.SBO_Application.Company.GetDICompany(); // Reassign the ocomp with the session we conencted with sap b1
                                                                                                       // sErrorMsg = Global.oCompany.GetLastErrorDescription();
                if (!ValidateLicense(_AddonId))
                {
                    //Application.SBO_Application.StatusBar.SetText("License validation failed for Apparel Dynsmic", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    //System.Windows.Forms.Application.Exit();
                    //return false;


                    Application.SBO_Application.StatusBar.SetText("Apparel Dynamic Connected Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                    return true;
                }
                else
                {
                    Application.SBO_Application.StatusBar.SetText("Apparel Dynamic Connected Successfully", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                    return true;
                }
            }
            catch
            {
                Application.SBO_Application.MessageBox(Global.oComp.GetLastErrorDescription().ToString(), 1, "OK", "", "");
                return false;
            }
        }

        private static bool ValidateLicense(string addonId)
        {
            try
            {
                // Example: license info stored in custom UDT [@MYADDON_LICENSE]
                // Fields: U_AddonId, U_CompanyDB, U_LicenseKey, U_ExpiryDate

                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sql = string.Format("SELECT A.{0}U_LICSEKEY{0},A.{0}U_EXPIRDATE{0} from {0}@FIL_MH_LICENSE{0} A  Where A.{0}U_ADDONID{0}='" + addonId + "' AND A.{0}U_COMNYDB{0}='" + Global.oComp.CompanyDB.ToString() + "' ", '"');
                rs.DoQuery(sql);

                if (rs.RecordCount == 0)
                    return false;

                string licenseKey = rs.Fields.Item("U_LICSEKEY").Value.ToString();
                DateTime expiryDate = Convert.ToDateTime(rs.Fields.Item("U_EXPIRDATE").Value);

                // Validate Expiry
                if (DateTime.Now > expiryDate)
                    return false;

                // Validate Key (example check — implement your own hash/algorithm)
                string expectedKey = GenerateExpectedKey(Global.oComp.CompanyDB.ToString(), addonId);
                if (licenseKey != expectedKey)
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string GenerateExpectedKey(string companyDb, string addonId)
        {
            // Example license key algorithm (you can implement stronger encryption)
            return (companyDb + "_" + addonId + "_2025").ToUpper();
        }

        public void CreateMainMenu(string ParentMenuID, string MenuID, string MenuName, int Position, int imenutype, bool flgimg)
        {
            try
            {
                SAPbouiCOM.Menus oMenus = null;
                SAPbouiCOM.MenuItem oMenuItem = null;
                oMenus = Application.SBO_Application.Menus;
                // ✅ Skip if already exists
                if (oMenus.Exists(MenuID))
                {
                    return;
                }
                SAPbouiCOM.MenuCreationParams oCreationPackage = null;
                oCreationPackage = (SAPbouiCOM.MenuCreationParams)Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams);
                oMenuItem = Application.SBO_Application.Menus.Item(ParentMenuID);

                switch (imenutype)
                {
                    case 2:
                        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
                        break;
                    case 1:
                        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                        break;
                    case 3:
                        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_SEPERATOR;
                        break;
                }

                oCreationPackage.UniqueID = MenuID;
                oCreationPackage.String = MenuName;
                oCreationPackage.Enabled = true;
                oCreationPackage.Position = Position;

                string path = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath).ToString();
                if (flgimg == true)
                {
                    string Apparel = string.Concat(path, @"AddFiles\Logo\test.jpg");
                    oCreationPackage.Image = Apparel;
                }

                oMenus = oMenuItem.SubMenus;

                try
                {
                    oMenus.AddEx(oCreationPackage);
                }
                catch (Exception ex)
                {
                    Application.SBO_Application.MessageBox("Menu already Exists " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox("Unexpected error in CreateMainMenu: " + ex.Message);
            }
        }

    }
}
