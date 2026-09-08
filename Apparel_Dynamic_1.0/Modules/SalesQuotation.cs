using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;
using Apparel_Dynamic_1._0.Helper;
using Apparel_Dynamic_1._0.Resources.Master;
using Apparel_Dynamic_1._0.Resources.Transaction;

namespace Apparel_Dynamic_1._0.Modules
{
    class SalesQuotation
    {
        public SalesQuotation()
        {
            Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
            Application.SBO_Application.FormDataEvent += new SAPbouiCOM._IApplicationEvents_FormDataEventEventHandler(SBO_Application_FormDataEvent);
            Application.SBO_Application.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(SBO_Application_MenuEvent);
        }

        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (pVal.FormTypeEx == "149" && pVal.EventType != SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD)
                {
                    Global.G_Form = Application.SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);
                    if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD && pVal.BeforeAction == true)
                    {
                        try
                        {
                            Global.G_Form.Freeze(true);

                            // *** OTT *****

                            //Static Text
                            Global.G_Form.Items.Add("STOTTNO", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STOTTNO").Specific;
                            Global.oStatic.Caption = "OTT";
                            Global.G_Form.Items.Item("STOTTNO").Top = Global.G_Form.Items.Item("2002").Top + 16;
                            Global.G_Form.Items.Item("STOTTNO").Left = Global.G_Form.Items.Item("2002").Left;
                            Global.G_Form.Items.Item("STOTTNO").Width = Global.G_Form.Items.Item("2002").Width;
                            Global.G_Form.Items.Item("STOTTNO").FromPane = 0;
                            Global.G_Form.Items.Item("STOTTNO").ToPane = 0;


                            // EditText (ETOTTNTRY)
                            Global.G_Form.Items.Add("ETOTTNO", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETOTTNO").Top = Global.G_Form.Items.Item("STOTTNO").Top;
                            Global.G_Form.Items.Item("ETOTTNO").Left = Global.G_Form.Items.Item("2003").Left;
                            Global.G_Form.Items.Item("ETOTTNO").Width = (Global.G_Form.Items.Item("2003").Width / 2) - 5;
                            Global.G_Form.Items.Item("ETOTTNO").FromPane = 0;
                            Global.G_Form.Items.Item("ETOTTNO").ToPane = 0;

                            //Global.G_Form.Items.Item("ETOTTNO").SetAutoManagedAttribute(
                            //    SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTTNO").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_OTTNO");
                            Global.G_Form.Items.Item("STOTTNO").LinkTo = "ETOTTNO";

                            // Linked Button
                            Global.G_Form.Items.Add("LNOTNTRY", SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON);
                            Global.oLinkButton = (SAPbouiCOM.LinkedButton)Global.G_Form.Items.Item("LNOTNTRY").Specific;
                            // Global.oLinkButton.LinkedObjectType = "ESPL_UDO_DD_GATENTRY";
                            Global.G_Form.Items.Item("LNOTNTRY").Top = Global.G_Form.Items.Item("STOTTNO").Top;
                            Global.G_Form.Items.Item("LNOTNTRY").Left = Global.G_Form.Items.Item("ETOTTNO").Left - 19;
                            Global.G_Form.Items.Item("LNOTNTRY").Height = Global.G_Form.Items.Item("LNOTNTRY").Height - 1;
                            Global.G_Form.Items.Item("LNOTNTRY").LinkTo = "ETOTTNO";

                            // EditText (ETOTNTRY)

                            Global.G_Form.Items.Add("ETOTNTRY", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETOTNTRY").Top = Global.G_Form.Items.Item("STOTTNO").Top;
                            Global.G_Form.Items.Item("ETOTNTRY").Left = Global.G_Form.Items.Item("ETOTTNO").Left + Global.G_Form.Items.Item("ETOTTNO").Width + 2;
                            Global.G_Form.Items.Item("ETOTNTRY").Width = (Global.G_Form.Items.Item("2003").Width / 2) + 5;
                            Global.G_Form.Items.Item("ETOTNTRY").FromPane = 0;
                            Global.G_Form.Items.Item("ETOTNTRY").ToPane = 0;
                            Global.G_Form.Items.Item("ETOTNTRY").Enabled = false;

                            //Global.G_Form.Items.Item("ETOTNTRY").SetAutoManagedAttribute(
                            //    SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTNTRY").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_OTTENTRY");
                            Global.G_Form.Items.Item("ETOTTNO").LinkTo = "ETOTNTRY";

                            // Choose From List (CFL)
                            Global.oCfls = Global.G_Form.ChooseFromLists;
                            Global.oCFLCreationParams = (SAPbouiCOM.ChooseFromListCreationParams)
                                Global.G_UI_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);

                            Global.oCFLCreationParams.MultiSelection = false;
                            Global.oCFLCreationParams.ObjectType = "FIL_D_OTT";
                            Global.oCFLCreationParams.UniqueID = "CFL_OTT";

                            Global.oCfl = Global.oCfls.Add(Global.oCFLCreationParams);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTTNO").Specific;
                            Global.oEdit.ChooseFromListUID = "CFL_OTT";
                            Global.oEdit.ChooseFromListAlias = "DocNum";

                            //***** Sales Contract***** 

                            //Static Text
                            Global.G_Form.Items.Add("STSCNO", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STSCNO").Specific;
                            Global.oStatic.Caption = "Sales Contract";
                            Global.G_Form.Items.Item("STSCNO").Top = Global.G_Form.Items.Item("STOTTNO").Top + 16;
                            Global.G_Form.Items.Item("STSCNO").Left = Global.G_Form.Items.Item("STOTTNO").Left;
                            Global.G_Form.Items.Item("STSCNO").Width = Global.G_Form.Items.Item("STOTTNO").Width;
                            Global.G_Form.Items.Item("STSCNO").FromPane = 0;
                            Global.G_Form.Items.Item("STSCNO").ToPane = 0;


                            // EditText (ETSCNO)

                            Global.G_Form.Items.Add("ETSCNO", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETSCNO").Top = Global.G_Form.Items.Item("STSCNO").Top;
                            Global.G_Form.Items.Item("ETSCNO").Left = Global.G_Form.Items.Item("ETOTTNO").Left;
                            Global.G_Form.Items.Item("ETSCNO").Width = Global.G_Form.Items.Item("ETOTTNO").Width;
                            Global.G_Form.Items.Item("ETSCNO").FromPane = 0;
                            Global.G_Form.Items.Item("ETSCNO").ToPane = 0;

                            //Global.G_Form.Items.Item("ETSCNO").SetAutoManagedAttribute(
                            //    SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSCNO").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_SCNO");
                            Global.G_Form.Items.Item("STSCNO").LinkTo = "ETSCNO";

                            // Linked Button
                            Global.G_Form.Items.Add("LNSCNTRY", SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON);
                            Global.oLinkButton = (SAPbouiCOM.LinkedButton)Global.G_Form.Items.Item("LNSCNTRY").Specific;
                            // Global.oLinkButton.LinkedObjectType = "ESPL_UDO_DD_GATENTRY";
                            Global.G_Form.Items.Item("LNSCNTRY").Top = Global.G_Form.Items.Item("STSCNO").Top;
                            Global.G_Form.Items.Item("LNSCNTRY").Left = Global.G_Form.Items.Item("ETSCNO").Left - 19;
                            Global.G_Form.Items.Item("LNSCNTRY").Height = Global.G_Form.Items.Item("LNSCNTRY").Height - 1;
                            //Global.G_Form.Items.Item("LNSCNTRY").LinkTo = "ETSCNTRY";
                            Global.G_Form.Items.Item("LNSCNTRY").LinkTo = "ETSCNO";

                            // EditText (ETSCNTRY)

                            Global.G_Form.Items.Add("ETSCNTRY", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETSCNTRY").Top = Global.G_Form.Items.Item("STSCNO").Top;
                            Global.G_Form.Items.Item("ETSCNTRY").Left = Global.G_Form.Items.Item("ETSCNO").Left + Global.G_Form.Items.Item("ETSCNO").Width + 2;
                            Global.G_Form.Items.Item("ETSCNTRY").Width = Global.G_Form.Items.Item("ETOTNTRY").Width;
                            Global.G_Form.Items.Item("ETSCNTRY").FromPane = 0;
                            Global.G_Form.Items.Item("ETSCNTRY").ToPane = 0;
                            Global.G_Form.Items.Item("ETSCNTRY").Enabled = false;

                            //Global.G_Form.Items.Item("ETSCNTRY").SetAutoManagedAttribute(
                            //    SAPbouiCOM.BoAutoManagedAttr.ama_Editable, -1, SAPbouiCOM.BoModeVisualBehavior.mvb_False);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSCNTRY").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_SCNTRY");
                            Global.G_Form.Items.Item("ETSCNO").LinkTo = "ETSCNTRY";

                            // Choose From List (CFL)
                            Global.oCfls = Global.G_Form.ChooseFromLists;
                            Global.oCFLCreationParams = (SAPbouiCOM.ChooseFromListCreationParams)
                                Global.G_UI_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);

                            Global.oCFLCreationParams.MultiSelection = false;
                            Global.oCFLCreationParams.ObjectType = "FIL_D_OSCM";
                            Global.oCFLCreationParams.UniqueID = "CFL_SLCN";

                            Global.oCfl = Global.oCfls.Add(Global.oCFLCreationParams);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSCNO").Specific;
                            Global.oEdit.ChooseFromListUID = "CFL_SLCN";
                            Global.oEdit.ChooseFromListAlias = "U_SCNO";

                            //// ************** Style No. **************

                            //Global.G_Form.Items.Add("STSTYLNO", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            //Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STSTYLNO").Specific;
                            //Global.oStatic.Caption = "Style No.*";

                            //Global.G_Form.Items.Item("STSTYLNO").Top = Global.G_Form.Items.Item("70").Top + 16 ;
                            //Global.G_Form.Items.Item("STSTYLNO").Left = Global.G_Form.Items.Item("70").Left + 10;
                            //Global.G_Form.Items.Item("STSTYLNO").Width =Global.G_Form.Items.Item("254000012").Width;
                            //Global.G_Form.Items.Item("STSTYLNO").Height = Global.G_Form.Items.Item("254000012").Height;
                            //Global.G_Form.Items.Item("STSTYLNO").FromPane = 0;
                            //Global.G_Form.Items.Item("STSTYLNO").ToPane = 0;

                            ////// Linked Button
                            //Global.G_Form.Items.Add("LNSTYLNO", SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON);

                            //// EditText (ETStyleNo)
                            //Global.G_Form.Items.Add("ETSTYLNO", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            //Global.G_Form.Items.Item("ETSTYLNO").Top = (Global.G_Form.Items.Item("70").Top) + 15;
                            //Global.G_Form.Items.Item("ETSTYLNO").Left = Global.G_Form.Items.Item("114").Left + Global.G_Form.Items.Item("114").Width +5;
                            //Global.G_Form.Items.Item("ETSTYLNO").Width = (Global.G_Form.Items.Item("14").Width / 2) - 5;
                            //Global.G_Form.Items.Item("ETSTYLNO").Height = Global.G_Form.Items.Item("14").Height;
                            //Global.G_Form.Items.Item("ETSTYLNO").FromPane = 0;
                            //Global.G_Form.Items.Item("ETSTYLNO").ToPane = 0;

                            ////Global.G_Form.Items.Item("ETSTYLNO").SetAutoManagedAttribute(
                            ////    SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 1,
                            ////    SAPbouiCOM.BoModeVisualBehavior.mvb_False);

                            //Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;
                            //Global.oEdit.DataBind.SetBound(true, "OQUT", "U_STYLECODE");
                            //Global.G_Form.Items.Item("STSTYLNO").LinkTo = "ETSTYLNO";

                            //// Linked Button Setup
                            //Global.oLinkButton = (SAPbouiCOM.LinkedButton)Global.G_Form.Items.Item("LNSTYLNO").Specific;
                            //// Global.oLinkButton.LinkedObjectType = "ESPL_UDO_DD_GATENTRY"; // Optional
                            //Global.G_Form.Items.Item("LNSTYLNO").Top = Global.G_Form.Items.Item("STSTYLNO").Top;
                            //Global.G_Form.Items.Item("LNSTYLNO").Left = Global.G_Form.Items.Item("ETSTYLNO").Left - 19;
                            //Global.G_Form.Items.Item("LNSTYLNO").Height = Global.G_Form.Items.Item("LNSTYLNO").Height - 1;
                            //Global.G_Form.Items.Item("LNSTYLNO").LinkTo = "ETSTYLNO";

                            //// Choose From List (CFL)
                            //Global.oCfls = Global.G_Form.ChooseFromLists;
                            //Global.oCFLCreationParams = (SAPbouiCOM.ChooseFromListCreationParams)
                            //    Global.G_UI_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);

                            //Global.oCFLCreationParams.MultiSelection = false;
                            //Global.oCFLCreationParams.ObjectType = "FIL_D_OPSM";
                            //Global.oCFLCreationParams.UniqueID = "CFL_OPSM";

                            //Global.oCfl = Global.oCfls.Add(Global.oCFLCreationParams);

                            //Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;
                            //Global.oEdit.ChooseFromListUID = "CFL_OPSM";
                            //Global.oEdit.ChooseFromListAlias = "U_STYLECODE";

                            //// Button (BTNSTYLD)
                            //Global.G_Form.Items.Add("BTNSTYLD", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
                            //Global.G_Form.Items.Item("BTNSTYLD").Top = Global.G_Form.Items.Item("STSTYLNO").Top;
                            //Global.G_Form.Items.Item("BTNSTYLD").Left = Global.G_Form.Items.Item("ETSTYLNO").Left + Global.G_Form.Items.Item("ETSTYLNO").Width + 5;
                            //Global.G_Form.Items.Item("BTNSTYLD").Width = (Global.G_Form.Items.Item("14").Width / 2) - 5;
                            //Global.G_Form.Items.Item("BTNSTYLD").Height = Global.G_Form.Items.Item("ETSTYLNO").Height;
                            //Global.G_Form.Items.Item("BTNSTYLD").FromPane = 0;
                            //Global.G_Form.Items.Item("BTNSTYLD").ToPane = 0;

                            //Global.oButton = (SAPbouiCOM.Button)Global.G_Form.Items.Item("BTNSTYLD").Specific;
                            //Global.oButton.Caption = "Load Info";

                            ////Global.G_Form.Items.Item("BTNSTYLD").SetAutoManagedAttribute(
                            ////    SAPbouiCOM.BoAutoManagedAttr.ama_Editable, 1,
                            ////    SAPbouiCOM.BoModeVisualBehavior.mvb_False);
                            ///
                            // ************** STYLE NO **************

                            // Static Text
                            Global.G_Form.Items.Add("STSTYLNO", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STSTYLNO").Specific;
                            Global.oStatic.Caption = "Style No.*";

                            Global.G_Form.Items.Item("STSTYLNO").Top = Global.G_Form.Items.Item("70").Top + 17;
                            Global.G_Form.Items.Item("STSTYLNO").Left = Global.G_Form.Items.Item("70").Left;
                            Global.G_Form.Items.Item("STSTYLNO").Width = 80;
                            Global.G_Form.Items.Item("STSTYLNO").Height = Global.G_Form.Items.Item("70").Height;
                            Global.G_Form.Items.Item("STSTYLNO").FromPane = 0;
                            Global.G_Form.Items.Item("STSTYLNO").ToPane = 0;


                            // Style No EditText
                            Global.G_Form.Items.Add("ETSTYLNO", SAPbouiCOM.BoFormItemTypes.it_EDIT);

                            Global.G_Form.Items.Item("ETSTYLNO").Top = Global.G_Form.Items.Item("STSTYLNO").Top;
                            Global.G_Form.Items.Item("ETSTYLNO").Left = Global.G_Form.Items.Item("14").Left;
                            Global.G_Form.Items.Item("ETSTYLNO").Width = 120;
                            Global.G_Form.Items.Item("ETSTYLNO").Height = Global.G_Form.Items.Item("70").Height;
                            Global.G_Form.Items.Item("ETSTYLNO").FromPane = 0;
                            Global.G_Form.Items.Item("ETSTYLNO").ToPane = 0;

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_STYLECODE");

                            Global.G_Form.Items.Item("STSTYLNO").LinkTo = "ETSTYLNO";


                            // Linked Button
                            Global.G_Form.Items.Add("LNSTYLNO", SAPbouiCOM.BoFormItemTypes.it_LINKED_BUTTON);

                            Global.oLinkButton = (SAPbouiCOM.LinkedButton)Global.G_Form.Items.Item("LNSTYLNO").Specific;

                            Global.G_Form.Items.Item("LNSTYLNO").Top = Global.G_Form.Items.Item("ETSTYLNO").Top;
                            Global.G_Form.Items.Item("LNSTYLNO").Left = Global.G_Form.Items.Item("ETSTYLNO").Left - 19;
                            Global.G_Form.Items.Item("LNSTYLNO").Height = Global.G_Form.Items.Item("ETSTYLNO").Height;
                            Global.G_Form.Items.Item("LNSTYLNO").FromPane = 0;
                            Global.G_Form.Items.Item("LNSTYLNO").ToPane = 0;
                            Global.G_Form.Items.Item("LNSTYLNO").LinkTo = "ETSTYLNO";


                            // Choose From List
                            Global.oCfls = Global.G_Form.ChooseFromLists;

                            Global.oCFLCreationParams = (SAPbouiCOM.ChooseFromListCreationParams)Global.G_UI_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);

                            Global.oCFLCreationParams.MultiSelection = false;
                            Global.oCFLCreationParams.ObjectType = "FIL_D_OPSM";
                            Global.oCFLCreationParams.UniqueID = "CFL_OPSM";

                            Global.oCfl = Global.oCfls.Add(Global.oCFLCreationParams);

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;
                            Global.oEdit.ChooseFromListUID = "CFL_OPSM";
                            Global.oEdit.ChooseFromListAlias = "U_STYLECODE";


                            // ************** STYLE ENTRY **************

                            Global.G_Form.Items.Add("ETSLNTRY", SAPbouiCOM.BoFormItemTypes.it_EDIT);

                            Global.G_Form.Items.Item("ETSLNTRY").Top = Global.G_Form.Items.Item("ETSTYLNO").Top;
                            Global.G_Form.Items.Item("ETSLNTRY").Left = Global.G_Form.Items.Item("ETSTYLNO").Left + Global.G_Form.Items.Item("ETSTYLNO").Width;
                            Global.G_Form.Items.Item("ETSLNTRY").Width = 10;
                            Global.G_Form.Items.Item("ETSLNTRY").Height = Global.G_Form.Items.Item("ETSTYLNO").Height;
                            Global.G_Form.Items.Item("ETSLNTRY").FromPane = 0;
                            Global.G_Form.Items.Item("ETSLNTRY").ToPane = 0;
                            Global.G_Form.Items.Item("ETSLNTRY").Enabled = false;

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSLNTRY").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_STYLENTRY");


                            // ************** LOAD INFO BUTTON **************

                            Global.G_Form.Items.Add("BTNSTYLD", SAPbouiCOM.BoFormItemTypes.it_BUTTON);

                            Global.G_Form.Items.Item("BTNSTYLD").Top = Global.G_Form.Items.Item("ETSTYLNO").Top;
                            Global.G_Form.Items.Item("BTNSTYLD").Left = Global.G_Form.Items.Item("ETSLNTRY").Left + Global.G_Form.Items.Item("ETSLNTRY").Width + 5;
                            Global.G_Form.Items.Item("BTNSTYLD").Width = 80;
                            Global.G_Form.Items.Item("BTNSTYLD").Height = Global.G_Form.Items.Item("ETSTYLNO").Height;
                            Global.G_Form.Items.Item("BTNSTYLD").FromPane = 0;
                            Global.G_Form.Items.Item("BTNSTYLD").ToPane = 0;

                            Global.oButton = (SAPbouiCOM.Button)Global.G_Form.Items.Item("BTNSTYLD").Specific;
                            Global.oButton.Caption = "Load Info";


                            // ************** STYLE DESCRIPTION **************

                            Global.G_Form.Items.Add("STSTYLDS", SAPbouiCOM.BoFormItemTypes.it_STATIC);

                            Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STSTYLDS").Specific;
                            Global.oStatic.Caption = "Style Desc.";

                            Global.G_Form.Items.Item("STSTYLDS").Top = Global.G_Form.Items.Item("254000012").Top + 17;
                            Global.G_Form.Items.Item("STSTYLDS").Left = Global.G_Form.Items.Item("254000012").Left;
                            Global.G_Form.Items.Item("STSTYLDS").Width = Global.G_Form.Items.Item("254000012").Width;
                            Global.G_Form.Items.Item("STSTYLDS").Height = Global.G_Form.Items.Item("STSTYLNO").Height;
                            Global.G_Form.Items.Item("STSTYLDS").FromPane = 0;
                            Global.G_Form.Items.Item("STSTYLDS").ToPane = 0;


                            // Style Description EditText
                            Global.G_Form.Items.Add("ETSTYLDS", SAPbouiCOM.BoFormItemTypes.it_EDIT);

                            Global.G_Form.Items.Item("ETSTYLDS").Top = Global.G_Form.Items.Item("STSTYLDS").Top;
                            Global.G_Form.Items.Item("ETSTYLDS").Left = Global.G_Form.Items.Item("254000015").Left;
                            Global.G_Form.Items.Item("ETSTYLDS").Width = Global.G_Form.Items.Item("ETSTYLNO").Width;
                            Global.G_Form.Items.Item("ETSTYLDS").Height = Global.G_Form.Items.Item("STSTYLNO").Height;
                            Global.G_Form.Items.Item("ETSTYLDS").FromPane = 0;
                            Global.G_Form.Items.Item("ETSTYLDS").ToPane = 0;
                            Global.G_Form.Items.Item("ETSTYLDS").Enabled = false;

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLDS").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_STYLENM");

                            Global.G_Form.Items.Item("STSTYLDS").LinkTo = "ETSTYLDS";


                            // ************** CUSTOMER STYLE NAME **************

                            Global.G_Form.Items.Add("ETCUSLNM", SAPbouiCOM.BoFormItemTypes.it_EDIT);

                            Global.G_Form.Items.Item("ETCUSLNM").Top = Global.G_Form.Items.Item("ETSTYLDS").Top;
                            Global.G_Form.Items.Item("ETCUSLNM").Left = Global.G_Form.Items.Item("ETSTYLDS").Left + Global.G_Form.Items.Item("ETSTYLDS").Width + 5;
                            Global.G_Form.Items.Item("ETCUSLNM").Width = 120;
                            Global.G_Form.Items.Item("ETCUSLNM").Height = Global.G_Form.Items.Item("ETSTYLDS").Height;
                            Global.G_Form.Items.Item("ETCUSLNM").FromPane = 0;
                            Global.G_Form.Items.Item("ETCUSLNM").ToPane = 0;

                            Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCUSLNM").Specific;
                            Global.oEdit.DataBind.SetBound(true, "OQUT", "U_BURSNAME");
                            //// ************ BUYER'S STYLE NO ************

                            //// ************* TYPE ********************
                            //Global.G_Form.Items.Add("STTYPE", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            //Global.oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STTYPE").Specific;
                            //Global.oStatic.Caption = "Order Type.";

                            //Global.G_Form.Items.Item("STTYPE").Top = Global.G_Form.Items.Item("254000012").Top + 18;  // - 2000
                            //Global.G_Form.Items.Item("STTYPE").Left = Global.G_Form.Items.Item("254000012").Left;
                            //Global.G_Form.Items.Item("STTYPE").Width = Global.G_Form.Items.Item("254000012").Width;
                            //Global.G_Form.Items.Item("STTYPE").FromPane = 0;
                            //Global.G_Form.Items.Item("STTYPE").ToPane = 0;

                            //// Add ComboBox for Type
                            //Global.G_Form.Items.Add("CBTYPE", SAPbouiCOM.BoFormItemTypes.it_COMBO_BOX);
                            //Global.G_Form.Items.Item("CBTYPE").Top = Global.G_Form.Items.Item("STTYPE").Top;
                            //Global.G_Form.Items.Item("CBTYPE").Left = Global.G_Form.Items.Item("254000015").Left;
                            //Global.G_Form.Items.Item("CBTYPE").Width = Global.G_Form.Items.Item("254000015").Width;
                            //Global.G_Form.Items.Item("CBTYPE").FromPane = 0;
                            //Global.G_Form.Items.Item("CBTYPE").ToPane = 0;
                            //Global.G_Form.Items.Item("CBTYPE").DisplayDesc = true;
                            //Global.G_Form.Items.Item("CBTYPE").SetAutoManagedAttribute(
                            //    SAPbouiCOM.BoAutoManagedAttr.ama_Editable,
                            //    1,
                            //    SAPbouiCOM.BoModeVisualBehavior.mvb_False
                            //);

                            //Global.oCombo = (SAPbouiCOM.ComboBox)Global.G_Form.Items.Item("CBTYPE").Specific;
                            //Global.oCombo.DataBind.SetBound(true, "OQUT", "U_TYPE");
                            //Global.G_Form.Items.Item("STTYPE").LinkTo = "CBTYPE";
                            //// ************* TYPE ********************///
                            ///

                            // ********** CREATE FOLDER TAB21 *************
                            Global.G_Form.Items.Add("TAB21", SAPbouiCOM.BoFormItemTypes.it_FOLDER);
                            SAPbouiCOM.Folder oFolder = (SAPbouiCOM.Folder)Global.G_Form.Items.Item("TAB21").Specific;
                            oFolder.Caption = "Size and Colour";
                            //G_Form.DataSources.UserDataSources.Add("FolderDS", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 1);
                            try
                            {
                                oFolder.DataBind.SetBound(true, "", "FolderDS");
                            }
                            catch (Exception)
                            {
                            }
                            oFolder.AutoPaneSelection = false;
                            oFolder.Pane = 21;
                            oFolder.GroupWith("112");

                            Global.G_Form.Items.Item("112").Width = 80;
                            Global.G_Form.Items.Item("114").Width = 80;
                            Global.G_Form.Items.Item("138").Width = 80;
                            Global.G_Form.Items.Item("2013").Width = 150;
                            Global.G_Form.Items.Item("1320002137").Width = 80;
                            Global.G_Form.Items.Item("TAB21").Width = 80;

                            Global.G_Form.Items.Item("TAB21").Left = Global.G_Form.Items.Item("112").Left + Global.G_Form.Items.Item("112").Width;
                            Global.G_Form.Items.Item("TAB21").Top = Global.G_Form.Items.Item("112").Top;
                            Global.G_Form.Items.Item("TAB21").Visible = true;

                            Global.G_Form.Items.Item("114").Left = Global.G_Form.Items.Item("TAB21").Left + Global.G_Form.Items.Item("TAB21").Width;
                            Global.G_Form.Items.Item("138").Left = Global.G_Form.Items.Item("114").Left + Global.G_Form.Items.Item("114").Width;
                            Global.G_Form.Items.Item("2013").Left = Global.G_Form.Items.Item("138").Left + Global.G_Form.Items.Item("138").Width;
                            Global.G_Form.Items.Item("1320002137").Left = Global.G_Form.Items.Item("2013").Left + Global.G_Form.Items.Item("2013").Width;

                            // ********** GRID **********
                            Global.G_Form.Items.Add("SCGrid", SAPbouiCOM.BoFormItemTypes.it_GRID);
                            SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)Global.G_Form.Items.Item("SCGrid").Specific;
                            Global.G_Form.Items.Item("SCGrid").Width = (Global.G_Form.Items.Item("118").Left - 10) - (Global.G_Form.Items.Item("117").Left + 10);
                            Global.G_Form.Items.Item("SCGrid").Top = Global.G_Form.Items.Item("44").Top;
                            Global.G_Form.Items.Item("SCGrid").Left = Global.G_Form.Items.Item("44").Left + 15;
                            Global.G_Form.Items.Item("SCGrid").Height = (Global.G_Form.Items.Item("116").Top - 10) - Global.G_Form.Items.Item("38").Top;
                            Global.G_Form.Items.Item("SCGrid").FromPane = 21;
                            Global.G_Form.Items.Item("SCGrid").ToPane = 21;

                            // Add DataTable
                            Global.G_Form.DataSources.DataTables.Add("DT_0");

                            // ********** Qty Static **********
                            Global.G_Form.Items.Add("STQty", SAPbouiCOM.BoFormItemTypes.it_STATIC);
                            SAPbouiCOM.StaticText oStatic = (SAPbouiCOM.StaticText)Global.G_Form.Items.Item("STQty").Specific;
                            oStatic.Caption = "Total Qty.";

                            Global.G_Form.Items.Item("STQty").Top = Global.G_Form.Items.Item("38").Top + Global.G_Form.Items.Item("38").Height + 5;
                            Global.G_Form.Items.Item("STQty").Left = Global.G_Form.Items.Item("86").Left;
                            Global.G_Form.Items.Item("STQty").Width = Global.G_Form.Items.Item("86").Width;
                            Global.G_Form.Items.Item("STQty").FromPane = 1;
                            Global.G_Form.Items.Item("STQty").ToPane = 1;

                            // ********** Qty EditText **********
                            Global.G_Form.Items.Add("ETQty", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETQty").Top = Global.G_Form.Items.Item("STQty").Top;
                            Global.G_Form.Items.Item("ETQty").Left = Global.G_Form.Items.Item("STQty").Left + Global.G_Form.Items.Item("STQty").Width;
                            Global.G_Form.Items.Item("ETQty").Width = Global.G_Form.Items.Item("ETSTYLNO").Width;
                            Global.G_Form.Items.Item("ETQty").FromPane = 1;
                            Global.G_Form.Items.Item("ETQty").ToPane = 1;
                            Global.G_Form.Items.Item("ETQty").Enabled = false;

                            Global.G_Form.Items.Item("ETQty").SetAutoManagedAttribute(
                                SAPbouiCOM.BoAutoManagedAttr.ama_Editable,
                                -1,
                                SAPbouiCOM.BoModeVisualBehavior.mvb_False
                            );
                            SAPbouiCOM.EditText oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETQty").Specific;
                            oEdit.DataBind.SetBound(true, "OQUT", "U_TOTALQTY");
                            Global.G_Form.Items.Item("STQty").LinkTo = "ETQty";

                            // ********** Get Item Button **********
                            Global.G_Form.Items.Add("BTQty", SAPbouiCOM.BoFormItemTypes.it_BUTTON);
                            //Global.G_Form.Items.Item("BTQty").Top = Global.G_Form.Items.Item("ETQty").Top;
                            Global.G_Form.Items.Item("BTQty").Top = Global.G_Form.Items.Item("3").Top;
                            Global.G_Form.Items.Item("BTQty").Left = Global.G_Form.Items.Item("3").Left + Global.G_Form.Items.Item("3").Width + 5;
                            Global.G_Form.Items.Item("BTQty").Width = (Global.G_Form.Items.Item("46").Width / 2) - 5;
                            Global.G_Form.Items.Item("BTQty").Height = Global.G_Form.Items.Item("ETQty").Height;
                            Global.G_Form.Items.Item("BTQty").FromPane = 1;
                            Global.G_Form.Items.Item("BTQty").ToPane = 1;

                            SAPbouiCOM.Button oButton = (SAPbouiCOM.Button)Global.G_Form.Items.Item("BTQty").Specific;
                            oButton.Caption = "Get Item";

                            //Global.G_Form.Items.Item("BTQty").SetAutoManagedAttribute(
                            //    SAPbouiCOM.BoAutoManagedAttr.ama_Editable,
                            //    1,
                            //    SAPbouiCOM.BoModeVisualBehavior.mvb_False
                            //);

                            // ********** Size Colour ENTRY Hidden EditText **********
                            Global.G_Form.Items.Add("ETCRSZNTRY", SAPbouiCOM.BoFormItemTypes.it_EDIT);
                            Global.G_Form.Items.Item("ETCRSZNTRY").Top = -2000;
                            Global.G_Form.Items.Item("ETCRSZNTRY").Enabled = false;
                            oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCRSZNTRY").Specific;
                            oEdit.DataBind.SetBound(true, "OQUT", "U_CRSZNTRY");

                            // Click to refresh form state
                            Global.G_Form.Items.Item("4").Click();


                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            Global.G_Form.Freeze(false);
                        }

                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD && pVal.BeforeAction == false)
                    {
                        SetCustomItemState(Global.G_Form);
                        if (!string.IsNullOrWhiteSpace(Global.G_Form.DataSources.DBDataSources.Item("OQUT").GetValue("U_CRSZNTRY", 0).ToString().Trim()))
                        {
                            LoadGrid(ref Global.G_Form, true);
                        }

                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_RESIZE && pVal.BeforeAction == false)
                    {
                        try
                        {
                            Global.G_Form.Freeze(true);

                            // Adjust Grid Size
                            Global.G_Form.Items.Item("SCGrid").Width =
                                    (Global.G_Form.Items.Item("118").Left - 10) - (Global.G_Form.Items.Item("117").Left + 10);
                            Global.G_Form.Items.Item("SCGrid").Height =
                                    (Global.G_Form.Items.Item("116").Top - 10) - Global.G_Form.Items.Item("38").Top;

                            // FILENTRY Row
                            //oForm.Items.Item("STFILENTRY").Top = oForm.Items.Item("86").Top + 18;
                            //oForm.Items.Item("ETFILENTRY").Top = oForm.Items.Item("STFILENTRY").Top;
                            //oForm.Items.Item("ETFILENO").Top = oForm.Items.Item("STFILENTRY").Top;
                            //oForm.Items.Item("LNFILENTRY").Top = oForm.Items.Item("STFILENTRY").Top;
                            //oForm.Items.Item("LNFILENTRY").Left = oForm.Items.Item("2003").Left - 20;

                            // Second Row
                            //Global.G_Form.Items.Item("2002").Top = Global.G_Form.Items.Item("STFILENTRY").Top + 18;
                            //Global.G_Form.Items.Item("2003").Top = Global.G_Form.Items.Item("2002").Top;

                            // ************** STYLE RESIZE **************

                            // Style No Row
                            Global.G_Form.Items.Item("STSTYLNO").Top = Global.G_Form.Items.Item("70").Top + 17;
                            Global.G_Form.Items.Item("STSTYLNO").Left = Global.G_Form.Items.Item("70").Left;

                            Global.G_Form.Items.Item("ETSTYLNO").Top = Global.G_Form.Items.Item("STSTYLNO").Top;
                            Global.G_Form.Items.Item("ETSTYLNO").Left = Global.G_Form.Items.Item("14").Left;

                            Global.G_Form.Items.Item("LNSTYLNO").Top = Global.G_Form.Items.Item("ETSTYLNO").Top;
                            Global.G_Form.Items.Item("LNSTYLNO").Left = Global.G_Form.Items.Item("ETSTYLNO").Left - 19;

                            Global.G_Form.Items.Item("ETSLNTRY").Top = Global.G_Form.Items.Item("ETSTYLNO").Top;
                            Global.G_Form.Items.Item("ETSLNTRY").Left = Global.G_Form.Items.Item("ETSTYLNO").Left + Global.G_Form.Items.Item("ETSTYLNO").Width;

                            Global.G_Form.Items.Item("BTNSTYLD").Top = Global.G_Form.Items.Item("ETSTYLNO").Top;
                            Global.G_Form.Items.Item("BTNSTYLD").Left = Global.G_Form.Items.Item("ETSLNTRY").Left + Global.G_Form.Items.Item("ETSLNTRY").Width + 5;


                            // Style Description Row
                            Global.G_Form.Items.Item("STSTYLDS").Top = Global.G_Form.Items.Item("254000012").Top + 17;
                            Global.G_Form.Items.Item("STSTYLDS").Left = Global.G_Form.Items.Item("254000012").Left;

                            Global.G_Form.Items.Item("ETSTYLDS").Top = Global.G_Form.Items.Item("STSTYLDS").Top;
                            Global.G_Form.Items.Item("ETSTYLDS").Left = Global.G_Form.Items.Item("254000015").Left;

                            Global.G_Form.Items.Item("ETCUSLNM").Top = Global.G_Form.Items.Item("ETSTYLDS").Top;
                            Global.G_Form.Items.Item("ETCUSLNM").Left = Global.G_Form.Items.Item("ETSTYLDS").Left + Global.G_Form.Items.Item("ETSTYLDS").Width + 2;

                            //// Buyer Style No Row
                            //Global.G_Form.Items.Item("STBSTYLENO").Top = Global.G_Form.Items.Item("STStyleNo").Top + 18;
                            //Global.G_Form.Items.Item("ETBSTYLENO").Top = Global.G_Form.Items.Item("STBSTYLENO").Top;
                            //Global.G_Form.Items.Item("ETBSTYLENM").Top = Global.G_Form.Items.Item("STBSTYLENO").Top;
                        }
                        catch (Exception ex)
                        {
                            Application.SBO_Application.StatusBar.SetText("Resize error: " + ex.Message,
                                 SAPbouiCOM.BoMessageTime.bmt_Short,
                                 SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        }
                        finally
                        {
                            Global.G_Form.Freeze(false);
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK
                           && pVal.ItemUID == "TAB21" && pVal.BeforeAction == false)
                    {
                        Global.G_Form.PaneLevel = 21;

                    }
                    //else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK
                    //       && pVal.ItemUID == "LNSTYLNO" && pVal.BeforeAction == true)
                    //{
                    //    Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;
                    //    OpenStyleMaster(Global.oEdit.Value);
                    //    Global.G_Form = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    //    BubbleEvent = false;
                    //    return;
                    //}
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK && pVal.ItemUID == "LNSTYLNO" &&
                            pVal.BeforeAction == true)
                    {
                        try
                        {
                            SAPbouiCOM.Form salesQuotationForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                            SAPbouiCOM.EditText etStyleNo = (SAPbouiCOM.EditText)salesQuotationForm.Items.Item("ETSTYLNO").Specific;
                            string styleCode = etStyleNo.Value.Trim();

                            if (string.IsNullOrWhiteSpace(styleCode))
                            {
                                Application.SBO_Application.StatusBar.SetText(
                                    "Please select Style No. first.",
                                    SAPbouiCOM.BoMessageTime.bmt_Short,
                                    SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

                                BubbleEvent = false;
                                return;
                            }

                            OpenStyleMaster(styleCode);
                            BubbleEvent = false;
                            return;
                        }
                        catch (Exception ex)
                        {
                            Application.SBO_Application.StatusBar.SetText(
                                "Error opening Style Master: " + ex.Message,
                                SAPbouiCOM.BoMessageTime.bmt_Short,
                                SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                            BubbleEvent = false;
                            return;
                        }
                    }
                    //else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK
                    //        && pVal.ItemUID == "LNOTNTRY" && pVal.BeforeAction == true)
                    //{
                    //    Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTTNO").Specific;
                    //    OpenOTT(Global.oEdit.Value);
                    //    Global.G_Form = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    //    BubbleEvent = false;
                    //    return;
                    //}
                    //else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK
                    //        && pVal.ItemUID == "LNSCNTRY" && pVal.BeforeAction == true)
                    //{
                    //    Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSCNO").Specific;
                    //    OpenSalesContract(Global.oEdit.Value);
                    //    Global.G_Form = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    //    BubbleEvent = false;
                    //    return;
                    //}
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK &&
                        pVal.ItemUID == "LNOTNTRY" &&
                        pVal.BeforeAction == true)
                    {
                        try
                        {
                            SAPbouiCOM.Form salesQuotationForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                            SAPbouiCOM.EditText etOttNo = (SAPbouiCOM.EditText)salesQuotationForm.Items.Item("ETOTTNO").Specific;
                            string ottDocNo = etOttNo.Value.Trim();

                            if (string.IsNullOrWhiteSpace(ottDocNo))
                            {
                                Application.SBO_Application.StatusBar.SetText(
                                    "Please select OTT first.",
                                    SAPbouiCOM.BoMessageTime.bmt_Short,
                                    SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

                                BubbleEvent = false;
                                return;
                            }

                            OpenOTT(ottDocNo);
                            BubbleEvent = false;
                            return;
                        }
                        catch (Exception ex)
                        {
                            Application.SBO_Application.StatusBar.SetText(
                                "Error opening OTT: " + ex.Message,
                                SAPbouiCOM.BoMessageTime.bmt_Short,
                                SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                            BubbleEvent = false;
                            return;
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CLICK &&
                             pVal.ItemUID == "LNSCNTRY" &&
                             pVal.BeforeAction == true)
                    {
                        try
                        {
                            SAPbouiCOM.Form salesQuotationForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                            SAPbouiCOM.EditText etSalesContractNo = (SAPbouiCOM.EditText)salesQuotationForm.Items.Item("ETSCNO").Specific;
                            string salesContractNo = etSalesContractNo.Value.Trim();

                            if (string.IsNullOrWhiteSpace(salesContractNo))
                            {
                                Application.SBO_Application.StatusBar.SetText(
                                    "Please select Sales Contract first.",
                                    SAPbouiCOM.BoMessageTime.bmt_Short,
                                    SAPbouiCOM.BoStatusBarMessageType.smt_Warning);

                                BubbleEvent = false;
                                return;
                            }

                            OpenSalesContract(salesContractNo);
                            BubbleEvent = false;
                            return;
                        }
                        catch (Exception ex)
                        {
                            Application.SBO_Application.StatusBar.SetText(
                                "Error opening Sales Contract: " + ex.Message,
                                SAPbouiCOM.BoMessageTime.bmt_Short,
                                SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                            BubbleEvent = false;
                            return;
                        }
                    }

                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_VALIDATE
                       && pVal.ItemUID == "SCGrid"
                       && pVal.BeforeAction == false)
                     {
                        try
                        {
                            Global.G_Form.Freeze(true);

                            if (pVal.Row < 0 || string.IsNullOrWhiteSpace(pVal.ColUID))
                                return;

                            Global.oGrid = (SAPbouiCOM.Grid)Global.G_Form.Items.Item("SCGrid").Specific;
                            Global.oDataTable = Global.G_Form.DataSources.DataTables.Item("DT_0");

                            int dtRow = Global.oGrid.GetDataTableRowIndex(pVal.Row);
                            if (dtRow < 0)
                                return;

                            if (pVal.ColUID == "Total" ||
                                pVal.ColUID == "Colour Name" ||
                                pVal.ColUID == "Colour Code")
                                return;

                            // ==============================
                            // Negative value validation
                            // ==============================
                            object currentValueObj =
                                Global.oDataTable.Columns.Item(pVal.ColUID).Cells.Item(dtRow).Value;

                            double currentValue = 0;

                            if (currentValueObj != null &&
                                !string.IsNullOrWhiteSpace(currentValueObj.ToString()))
                            {
                                double.TryParse(currentValueObj.ToString(), out currentValue);
                            }

                            if (currentValue < 0)
                            {
                                Application.SBO_Application.StatusBar.SetText(
                                    "Negative quantity is not allowed.",
                                    SAPbouiCOM.BoMessageTime.bmt_Short,
                                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                                Global.oDataTable.Columns.Item(pVal.ColUID).Cells.Item(dtRow).Value = "0";

                                Global.G_Form.Freeze(false);
                                return;
                            }

                            // ==============================
                            // Total calculation
                            // ==============================
                            double total = 0;

                            for (int j = 0; j < Global.oDataTable.Columns.Count; j++)
                            {
                                string currentCol = Global.oDataTable.Columns.Item(j).Name;

                                if (currentCol == "Colour Name" ||
                                    currentCol == "Colour Code" ||
                                    currentCol == "Total" ||
                                    currentCol == "RCount")
                                    continue;

                                object val = Global.oDataTable.Columns.Item(j).Cells.Item(dtRow).Value;

                                double cellValue = 0;

                                if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
                                    double.TryParse(val.ToString(), out cellValue);

                                total += cellValue;
                            }

                            Global.oDataTable.Columns.Item("Total").Cells.Item(dtRow).Value = total.ToString();

                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            try { Global.G_Form.Freeze(false); } catch { }

                            Application.SBO_Application.StatusBar.SetText(
                                "Error in SCGrid Validate: " + ex.Message,
                                SAPbouiCOM.BoMessageTime.bmt_Short,
                                SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_VALIDATE && pVal.ItemUID == "38" && pVal.ColUID == "11" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            UpdateTotalQtyFromMatrix(Global.G_Form);
                        }
                        catch (Exception ex)
                        {
                            Global.GFunc.ShowError("Error updating total quantity: " + ex.Message);
                        }
                    }
                    //else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETOTTNO" && pVal.BeforeAction)
                    //{
                    //    try
                    //    {
                    //        SAPbouiCOM.IChooseFromListEvent cflEvent = (SAPbouiCOM.IChooseFromListEvent)pVal;
                    //        if (cflEvent.ChooseFromListUID == "CFL_OTT")
                    //        {
                    //            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                    //            SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFL_OTT");

                    //            SAPbouiCOM.Conditions oCons = (SAPbouiCOM.Conditions)
                    //                Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_Conditions);

                    //            SAPbouiCOM.Condition oCon1 = oCons.Add();
                    //            oCon1.Alias = "U_OTTSTTS";
                    //            oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    //            oCon1.CondVal = "C";

                    //            oCFL.SetConditions(oCons);
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Application.SBO_Application.StatusBar.SetText(
                    //            "Error filtering OTT CFL: " + ex.Message,
                    //            SAPbouiCOM.BoMessageTime.bmt_Short,
                    //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    //        BubbleEvent = false;
                    //    }
                    //}
                    //else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETOTTNO" && pVal.BeforeAction == true)
                    //{
                    //    SAPbobsCOM.Recordset oRecordset = null;

                    //    try
                    //    {
                    //        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                    //        SAPbouiCOM.EditText etStyleNo = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNO").Specific;
                    //        string styleCode = etStyleNo.Value.Trim();

                    //        if (string.IsNullOrWhiteSpace(styleCode))
                    //        {
                    //            BubbleEvent = false;
                    //            Global.GFunc.ShowError("Please select Style No. first.");
                    //            return;
                    //        }

                    //        SAPbouiCOM.IChooseFromListEvent cflEvent = (SAPbouiCOM.IChooseFromListEvent)pVal;

                    //        if (cflEvent.ChooseFromListUID != "CFL_OTT")
                    //            return;

                    //        string safeStyleCode = styleCode.Replace("'", "''");

                    //        string query = @"SELECT DISTINCT H.""DocNum""
                    //                         FROM ""@FIL_DH_OTT"" H
                    //                         INNER JOIN ""@FIL_DR_TT1"" D ON D.""DocEntry"" = H.""DocEntry""
                    //                         WHERE D.""U_STYLECODE"" = '" + safeStyleCode + @"'
                    //                         AND H.""U_OTTSTTS"" = 'C'
                    //                         ORDER BY H.""DocNum""";

                    //        oRecordset = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    //        oRecordset.DoQuery(query);

                    //        if (oRecordset.EoF)
                    //        {
                    //            BubbleEvent = false;
                    //            Global.GFunc.ShowError("No OTT found for Style No. " + styleCode + ".");
                    //            return;
                    //        }

                    //        SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFL_OTT");

                    //        SAPbouiCOM.Conditions oConditions = (SAPbouiCOM.Conditions)Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_Conditions);

                    //        while (!oRecordset.EoF)
                    //        {
                    //            string docNum = oRecordset.Fields.Item("DocNum").Value.ToString().Trim();

                    //            SAPbouiCOM.Condition oCondition = oConditions.Add();
                    //            oCondition.Alias = "DocNum";
                    //            oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                    //            oCondition.CondVal = docNum;

                    //            oRecordset.MoveNext();

                    //            if (!oRecordset.EoF)
                    //                oCondition.Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                    //        }

                    //        oCFL.SetConditions(oConditions);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        BubbleEvent = false;
                    //        Global.GFunc.ShowError("Error filtering OTT CFL: " + ex.Message);
                    //    }
                    //    finally
                    //    {
                    //        if (oRecordset != null)
                    //        {
                    //            try
                    //            {
                    //                System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordset);
                    //                oRecordset = null;
                    //            }
                    //            catch
                    //            {
                    //            }
                    //        }
                    //    }
                    //}
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETOTTNO" && pVal.BeforeAction == true)
                    {
                        SAPbobsCOM.Recordset oRecordset = null;

                        try
                        {
                            SAPbouiCOM.IChooseFromListEvent cflEvent = (SAPbouiCOM.IChooseFromListEvent)pVal;

                            if (cflEvent.ChooseFromListUID != "CFL_OTT")
                                return;

                            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                            SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFL_OTT");
                            SAPbouiCOM.EditText etStyleNo = (SAPbouiCOM.EditText)oForm.Items.Item("ETSTYLNO").Specific;

                            string styleCode = etStyleNo.Value.Trim();

                            if (string.IsNullOrWhiteSpace(styleCode))
                            {
                                SAPbouiCOM.Conditions oEmptyConditions = (SAPbouiCOM.Conditions)Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_Conditions);
                                SAPbouiCOM.Condition oEmptyCondition = oEmptyConditions.Add();

                                oEmptyCondition.Alias = "DocNum";
                                oEmptyCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                                oEmptyCondition.CondVal = "-999999999";

                                oCFL.SetConditions(oEmptyConditions);

                                BubbleEvent = false;

                                Global.GFunc.ShowError("Please select Style No. first.");

                                return;
                            }

                            string safeStyleCode = styleCode.Replace("'", "''");

                            string query = @"SELECT DISTINCT H.""DocNum""
                                             FROM ""@FIL_DH_OTT"" H
                                             INNER JOIN ""@FIL_DR_TT1"" D ON D.""DocEntry"" = H.""DocEntry""
                                             WHERE D.""U_STYLECODE"" = '" + safeStyleCode + @"'
                                             AND H.""U_OTTSTTS"" = 'C'
                                             ORDER BY H.""DocNum""";

                            oRecordset = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                            oRecordset.DoQuery(query);

                            if (oRecordset.EoF)
                            {
                                SAPbouiCOM.Conditions oEmptyConditions = (SAPbouiCOM.Conditions)Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_Conditions);
                                SAPbouiCOM.Condition oEmptyCondition = oEmptyConditions.Add();

                                oEmptyCondition.Alias = "DocNum";
                                oEmptyCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                                oEmptyCondition.CondVal = "-999999999";

                                oCFL.SetConditions(oEmptyConditions);

                                Global.GFunc.ShowError("No OTT found for Style No. " + styleCode + ".");

                                return;
                            }

                            SAPbouiCOM.Conditions oConditions = (SAPbouiCOM.Conditions)Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_Conditions);

                            while (!oRecordset.EoF)
                            {
                                string docNum = oRecordset.Fields.Item("DocNum").Value.ToString().Trim();

                                SAPbouiCOM.Condition oCondition = oConditions.Add();

                                oCondition.Alias = "DocNum";
                                oCondition.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                                oCondition.CondVal = docNum;

                                oRecordset.MoveNext();

                                if (!oRecordset.EoF)
                                    oCondition.Relationship = SAPbouiCOM.BoConditionRelationship.cr_OR;
                            }

                            oCFL.SetConditions(oConditions);
                        }
                        catch (Exception ex)
                        {
                            BubbleEvent = false;
                            Global.GFunc.ShowError("Error filtering OTT CFL: " + ex.Message);
                        }
                        finally
                        {
                            if (oRecordset != null)
                            {
                                try
                                {
                                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordset);
                                    oRecordset = null;
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETOTTNO" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            SAPbouiCOM.IChooseFromListEvent oCFLEvento = (SAPbouiCOM.IChooseFromListEvent)pVal;
                            SAPbouiCOM.DataTable oDataTable;
                            oDataTable = oCFLEvento.SelectedObjects;

                            if (oDataTable != null)
                            {
                                //Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item(pVal.ItemUID).Specific;
                                //Global.oEdit.Value = oDataTable.GetValue(Global.oEdit.ChooseFromListAlias, 0).ToString().Trim();

                                try
                                {
                                    Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTTNO").Specific;
                                    Global.oEdit.Value = oDataTable.GetValue("DocNum", 0).ToString().Trim();

                                    Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETOTNTRY").Specific;
                                    Global.oEdit.Value = oDataTable.GetValue("DocEntry", 0).ToString().Trim();
                                }
                                catch { }
                            }
                        }
                        catch { }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETSCNO" && pVal.BeforeAction)
                    {
                        try
                        {
                            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);

                            string customerCode = ((SAPbouiCOM.EditText)oForm.Items.Item("4").Specific).Value.Trim();

                            if (string.IsNullOrEmpty(customerCode))
                            {
                                Application.SBO_Application.StatusBar.SetText(
                                    "Please select Customer first.",
                                    SAPbouiCOM.BoMessageTime.bmt_Short,
                                    SAPbouiCOM.BoStatusBarMessageType.smt_Error
                                );
                                BubbleEvent = false;
                                return;
                            }


                            SAPbouiCOM.IChooseFromListEvent cflEvent = (SAPbouiCOM.IChooseFromListEvent)pVal;
                            if (cflEvent.ChooseFromListUID == "CFL_SLCN")
                            {

                                SAPbouiCOM.ChooseFromList oCFL = oForm.ChooseFromLists.Item("CFL_SLCN");

                                SAPbouiCOM.Conditions oCons = (SAPbouiCOM.Conditions)
                                    Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_Conditions);

                                SAPbouiCOM.Condition oCon1 = oCons.Add();
                                oCon1.Alias = "U_CARDCODE";
                                oCon1.Operation = SAPbouiCOM.BoConditionOperation.co_EQUAL;
                                oCon1.CondVal = customerCode;

                                oCFL.SetConditions(oCons);
                            }
                        }
                        catch (Exception ex)
                        {
                            Application.SBO_Application.StatusBar.SetText(
                                "Error filtering OTT CFL: " + ex.Message,
                                SAPbouiCOM.BoMessageTime.bmt_Short,
                                SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            BubbleEvent = false;
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETSCNO" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            SAPbouiCOM.IChooseFromListEvent oCFLEvento = (SAPbouiCOM.IChooseFromListEvent)pVal;
                            SAPbouiCOM.DataTable oDataTable;
                            oDataTable = oCFLEvento.SelectedObjects;

                            if (oDataTable != null)
                            {
                                Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item(pVal.ItemUID).Specific;
                                Global.oEdit.Value = oDataTable.GetValue(Global.oEdit.ChooseFromListAlias, 0).ToString().Trim();

                                try
                                {
                                    Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSCNO").Specific;
                                    Global.oEdit.Value = oDataTable.GetValue("U_SCNO", 0).ToString().Trim();

                                    Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSCNTRY").Specific;
                                    Global.oEdit.Value = oDataTable.GetValue("DocEntry", 0).ToString().Trim();
                                }
                                catch { }
                            }
                        }
                        catch { }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.ItemUID == "ETSTYLNO" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            SAPbouiCOM.IChooseFromListEvent oCFLEvento = (SAPbouiCOM.IChooseFromListEvent)pVal;
                            SAPbouiCOM.DataTable oDataTable;
                            oDataTable = oCFLEvento.SelectedObjects;

                            if (oDataTable != null)
                            {
                                Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item(pVal.ItemUID).Specific;
                                Global.oEdit.Value = oDataTable.GetValue(Global.oEdit.ChooseFromListAlias, 0).ToString().Trim();


                                Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLDS").Specific;
                                Global.oEdit.Value = oDataTable.GetValue("U_STYLENM", 0).ToString().Trim();

                                Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSLNTRY").Specific;
                                Global.oEdit.Value = oDataTable.GetValue("DocEntry", 0).ToString().Trim();

                                Global.oEdit = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCUSLNM").Specific;
                                Global.oEdit.Value = oDataTable.GetValue("U_BURSNAME", 0).ToString().Trim();

                            }
                        }
                        catch { }
                    }
                    //tHIS IS PREV 
                    //else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "BTNSTYLD" && pVal.BeforeAction == false)
                    //{
                    //    try
                    //    {
                    //        SAPbouiCOM.EditText oETSTYLNO =(SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;
                    //        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)Global.G_Form.Items.Item("38").Specific;
                    //        if (string.IsNullOrWhiteSpace(oETSTYLNO.Value))
                    //        {
                    //            Application.SBO_Application.StatusBar.SetText(
                    //                "Please select a Style Master.",
                    //                SAPbouiCOM.BoMessageTime.bmt_Short,
                    //                SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                    //            return;
                    //        }

                    //        Global.G_Form.Freeze(true);
                    //        // First clear matrix 38 if it already has rows/item codes
                    //        ClearQuotationMatrix(ref Global.G_Form);
                    //        // Then load grid
                    //        LoadGrid(ref Global.G_Form, false);
                    //        Global.G_Form.Freeze(false);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        try
                    //        {
                    //            Global.G_Form.Freeze(false);
                    //        }
                    //        catch { }

                    //        Application.SBO_Application.StatusBar.SetText(
                    //            "Error in BTNSTYLD: " + ex.Message,
                    //            SAPbouiCOM.BoMessageTime.bmt_Short,
                    //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                    //    }
                    //}

                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "BTNSTYLD" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            SAPbouiCOM.EditText oETSTYLNO = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;

                            if (string.IsNullOrWhiteSpace(oETSTYLNO.Value))
                            {
                                Global.GFunc.ShowError("Please select a Style Master.");
                                return;
                            }

                            Global.G_Form.Freeze(true);

                            RefreshGridPreserveQty(ref Global.G_Form);

                            Global.G_Form.Freeze(false);

                            Global.GFunc.ShowSuccess("Style information loaded successfully.");
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                Global.G_Form.Freeze(false);
                            }
                            catch
                            {
                            }

                            Global.GFunc.ShowError("Error in Load Info: " + ex.Message);
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "BTQty" && pVal.BeforeAction == false)
                    {
                        try
                        {
                            SAPbouiCOM.EditText etStyleNo = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;

                            if (string.IsNullOrWhiteSpace(etStyleNo.Value))
                            {
                                Global.GFunc.ShowError("Please select Style No. first.");
                                return;
                            }

                            Global.G_Form.Freeze(true);

                            LoadMatrix(ref Global.G_Form);

                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                Global.G_Form.Freeze(false);
                            }
                            catch
                            {
                            }

                            Global.GFunc.ShowError("Error in Get Item: " + ex.Message);
                        }
                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "1" && pVal.BeforeAction == true
       &&
       (
           Global.G_Form.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE ||
           Global.G_Form.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE
       ))
                    {
                        try
                        {
                            // =========================
                            // 1. Style Code Validation
                            // =========================
                            SAPbouiCOM.EditText etStyleNo =
                                (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;

                            if (string.IsNullOrWhiteSpace(etStyleNo.Value))
                            {
                                Application.SBO_Application.StatusBar.SetText(
                                    "Please enter the Style Code first.",
                                    SAPbouiCOM.BoMessageTime.bmt_Short,
                                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                                BubbleEvent = false;
                                return;
                            }

                          
                            Global.G_Form.Freeze(true);

                            // =========================
                            // 3. Insert / Update Size Details
                            // =========================
                            int SizeEntry = 0;

                            var oItem =
                                (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCRSZNTRY").Specific;

                            if (!string.IsNullOrWhiteSpace(oItem.Value))
                                SizeEntry = Convert.ToInt32(oItem.Value);

                            try
                            {
                                if (!Global.oComp.InTransaction)
                                    Global.oComp.StartTransaction();

                                InsertSizeDetails(Global.G_Form, "", "", SizeEntry);

                                if (Global.oComp.InTransaction)
                                    Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    if (Global.oComp.InTransaction)
                                        Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                }
                                catch { }

                                Application.SBO_Application.StatusBar.SetText(
                                    "Error saving Size-Colour details: " + ex.Message,
                                    SAPbouiCOM.BoMessageTime.bmt_Short,
                                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                                BubbleEvent = false;
                                return;
                            }

                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            try { Global.G_Form.Freeze(false); } catch { }

                            Application.SBO_Application.StatusBar.SetText(
                                "Error before saving document: " + ex.Message,
                                SAPbouiCOM.BoMessageTime.bmt_Short,
                                SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                            BubbleEvent = false;
                            return;
                        }
                    }
                    //else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "1" && pVal.BeforeAction == true && (Global.G_Form.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || Global.G_Form.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE))
                    //{
                    //    try
                    //    {
                    //        SAPbouiCOM.EditText etStyleNo = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSTYLNO").Specific;

                    //        if (string.IsNullOrWhiteSpace(etStyleNo.Value))
                    //        {
                    //            BubbleEvent = false;
                    //            Global.GFunc.ShowError("Please enter the Style Code first.");
                    //            return;
                    //        }

                    //        if (!ValidateMatrixAndGridQty(Global.G_Form))
                    //        {
                    //            BubbleEvent = false;

                    //            Application.SBO_Application.MessageBox("VALIDATION FAILED - BUBBLE EVENT FALSE");

                    //            return;
                    //        }

                    //        Global.G_Form.Freeze(true);

                    //        int sizeEntry = 0;

                    //        SAPbouiCOM.EditText etSizeEntry = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCRSZNTRY").Specific;

                    //        if (!string.IsNullOrWhiteSpace(etSizeEntry.Value))
                    //            sizeEntry = Convert.ToInt32(etSizeEntry.Value);

                    //        try
                    //        {
                    //            if (!Global.oComp.InTransaction)
                    //                Global.oComp.StartTransaction();

                    //            InsertSizeDetails(Global.G_Form, "", "", sizeEntry);

                    //            if (Global.oComp.InTransaction)
                    //                Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            if (Global.oComp.InTransaction)
                    //                Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);

                    //            BubbleEvent = false;

                    //            Global.GFunc.ShowError("Error saving Size-Colour details: " + ex.Message);

                    //            return;
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        BubbleEvent = false;
                    //        Global.GFunc.ShowError("Error before saving document: " + ex.Message);
                    //        return;
                    //    }
                    //    finally
                    //    {
                    //        try
                    //        {
                    //            Global.G_Form.Freeze(false);
                    //        }
                    //        catch
                    //        {
                    //        }
                    //    }
                    //}
                    //Test

                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "1" && pVal.BeforeAction == false && Global.G_Form.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                    {
                        try
                        {
                            Global.G_Form.Freeze(true);
                            LoadGrid(ref Global.G_Form, false);
                            Global.G_Form.Freeze(false);
                        }
                        catch (Exception ex)
                        {
                            Global.G_Form.Freeze(false);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage("Error in Draft Order for SAP Screen - " + ex.ToString(), SAPbouiCOM.BoMessageTime.bmt_Medium, true);
            }
        }
        private void SBO_Application_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (BusinessObjectInfo.BeforeAction == false &&
                    BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_LOAD)
                {
                    Global.G_Form = Global.G_UI_Application.Forms.Item(BusinessObjectInfo.FormUID);

                    switch (BusinessObjectInfo.FormTypeEx)
                    {
                        case "149":
                            {
                                try
                                {
                                    Global.G_Form.Freeze(true);

                                    LoadGrid(ref Global.G_Form, true);

                                    SetCustomItemState(Global.G_Form);

                                    Global.G_Form.Freeze(false);
                                }
                                catch (Exception ex)
                                {
                                    Global.G_Form.Freeze(false);
                                    Application.SBO_Application.StatusBar.SetText(
                                        "Error in FORM_DATA_LOAD: " + ex.Message,
                                        SAPbouiCOM.BoMessageTime.bmt_Short,
                                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                }

                                break;
                            }
                    }
                }
                else if (BusinessObjectInfo.BeforeAction == true &&
                         BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD)
                {
                    Global.G_Form = Global.G_UI_Application.Forms.Item(BusinessObjectInfo.FormUID);

                    switch (BusinessObjectInfo.FormTypeEx)
                    {
                        case "149":
                            {
                                try
                                {
                                    Global.G_Form.Freeze(true);

                                    string ObjectType = BusinessObjectInfo.Type;

                                    int SizeEntry = string.IsNullOrEmpty(((SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCRSZNTRY").Specific).Value)
                                        ? 0
                                        : Convert.ToInt32(((SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETCRSZNTRY").Specific).Value);

                                    try
                                    {
                                        if (!Global.oComp.InTransaction)
                                            Global.oComp.StartTransaction();

                                        if (ObjectType == "112")
                                        {
                                            InsertSizeDetails(Global.G_Form, "", "", SizeEntry);
                                        }

                                        if (Global.oComp.InTransaction)
                                            Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                                    }
                                    catch (Exception ex)
                                    {
                                        try
                                        {
                                            if (Global.oComp.InTransaction)
                                                Global.oComp.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                                        }
                                        catch { }

                                        Application.SBO_Application.StatusBar.SetText(
                                            "Error in FORM_DATA_ADD: " + ex.Message,
                                            SAPbouiCOM.BoMessageTime.bmt_Short,
                                            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                    }

                                    Global.G_Form.Freeze(false);
                                }
                                catch (Exception ex)
                                {
                                    Global.G_Form.Freeze(false);
                                    Application.SBO_Application.StatusBar.SetText(
                                        "Error in FORM_DATA_ADD Outer: " + ex.Message,
                                        SAPbouiCOM.BoMessageTime.bmt_Short,
                                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                }

                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    Global.G_Form.Freeze(false);
                }
                catch { }

                Application.SBO_Application.StatusBar.SetText(
                    "Error in SBO_Application_FormDataEvent: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction == false)
                {
                    if (pVal.MenuUID == "1281" ||   // Find
                        pVal.MenuUID == "1282" ||   // Add
                        pVal.MenuUID == "1288" ||   // First
                        pVal.MenuUID == "1289" ||   // Previous
                        pVal.MenuUID == "1290" ||   // Next
                        pVal.MenuUID == "1291")     // Last
                    {
                        SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.ActiveForm;

                        if (oForm != null && oForm.TypeEx == "149")
                        {
                            SetCustomItemState(oForm);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "MenuEvent Error: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        //prev workkable field diable enable except styleno
        //private void SetCustomItemState(SAPbouiCOM.Form oForm)
        //{
        //    try
        //    {
        //        bool isFindMode = oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE;

        //        // Editable fields
        //        oForm.Items.Item("ETSTYLNO").Enabled = true;
        //        oForm.Items.Item("ETOTTNO").Enabled = true;
        //        oForm.Items.Item("ETSCNO").Enabled = true;
        //        oForm.Items.Item("BTNSTYLD").Enabled = true;
        //        oForm.Items.Item("BTQty").Enabled = true;

        //        // Always disabled except FIND mode
        //        SetEditable(oForm, "ETOTNTRY", isFindMode);
        //        SetEditable(oForm, "ETSCNTRY", isFindMode);
        //        SetEditable(oForm, "ETSTYLDS", isFindMode);
        //        SetEditable(oForm, "ETSLNTRY", isFindMode);
        //        SetEditable(oForm, "ETCRSZNTRY", isFindMode);
        //        SetEditable(oForm, "ETCUSLNM", isFindMode);

        //        // Always disabled
        //        SetEditable(oForm, "ETQty", false);
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            "SetCustomItemState Error: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

        private void SetCustomItemState(SAPbouiCOM.Form oForm)
        {
            try
            {
                bool isFindMode = oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                bool isAddMode = oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE;

                bool canChangeStyle = isAddMode || isFindMode;

                // ************** STYLE NO **************
                SetEditable(oForm, "ETSTYLNO", canChangeStyle);

                if (isAddMode)
                {
                    Global.GFunc.ReEnableChooseFromList(oForm,"ETSTYLNO","CFL_OPSM","U_STYLECODE");
                }

                // ************** OTHER CONTROLS **************
                oForm.Items.Item("ETOTTNO").Enabled = true;
                oForm.Items.Item("ETSCNO").Enabled = true;
                oForm.Items.Item("BTNSTYLD").Enabled = true;
                oForm.Items.Item("BTQty").Enabled = true;

                SetEditable(oForm, "ETOTNTRY", isFindMode);
                SetEditable(oForm, "ETSCNTRY", isFindMode);
                SetEditable(oForm, "ETSTYLDS", isFindMode);
                SetEditable(oForm, "ETSLNTRY", isFindMode);
                SetEditable(oForm, "ETCRSZNTRY", isFindMode);
                SetEditable(oForm, "ETCUSLNM", isFindMode);

                SetEditable(oForm, "ETQty", false);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("SetCustomItemState Error: " + ex.Message);
            }
        }

        private void SetEditable(SAPbouiCOM.Form oForm, string itemId, bool editable)
        {
            oForm.Items.Item(itemId).SetAutoManagedAttribute(
                SAPbouiCOM.BoAutoManagedAttr.ama_Editable,
                -1,
                editable
                    ? SAPbouiCOM.BoModeVisualBehavior.mvb_True
                    : SAPbouiCOM.BoModeVisualBehavior.mvb_False
            );

            oForm.Items.Item(itemId).Enabled = editable;
        }

        //public void OpenStyleMaster(string styleCode)
        //{
        //    try
        //    {
        //        StyleMaster styleMaster = new StyleMaster();
        //        styleMaster.Show();
        //        Global.G_Form = Application.SBO_Application.Forms.Item("FIL_FRM_STYLMSTR");
        //        Global.G_Form.Freeze(true);
        //        Global.G_Form.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
        //        Global.G_Form.Items.Item("ETSLCODE").Enabled = true;
        //        SAPbouiCOM.EditText cETSLCODE = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETSLCODE").Specific;
        //        cETSLCODE.Value = styleCode;
        //        Global.G_Form.Items.Item("1").Click();
        //        Global.G_Form.Items.Item("FOLSIZE").Click();
        //        Global.G_Form.Freeze(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.G_Form.Freeze(false);

        //        Application.SBO_Application.StatusBar.SetText("Error in open StyleMaster: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

        public void OpenStyleMaster(string styleCode)
        {
            SAPbouiCOM.Form styleMasterForm = null;
            bool isFrozen = false;

            try
            {
                if (string.IsNullOrWhiteSpace(styleCode))
                    return;

                StyleMaster styleMaster = new StyleMaster();
                styleMaster.Show();

                styleMasterForm = Application.SBO_Application.Forms.Item("FIL_FRM_STYLMSTR");

                styleMasterForm.Freeze(true);
                isFrozen = true;

                styleMasterForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                styleMasterForm.Items.Item("ETSLCODE").Enabled = true;

                SAPbouiCOM.EditText etStyleCode = (SAPbouiCOM.EditText)styleMasterForm.Items.Item("ETSLCODE").Specific;
                etStyleCode.Value = styleCode.Trim();

                styleMasterForm.Items.Item("1").Click();

                if (styleMasterForm.Mode != SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                    styleMasterForm.Items.Item("FOLSIZE").Click();
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in OpenStyleMaster: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                if (styleMasterForm != null && isFrozen)
                {
                    try
                    {
                        styleMasterForm.Freeze(false);
                    }
                    catch
                    {
                    }
                }
            }
        }


        ////infuture
        //public void OpenOTT(string OTTDOC)
        //{
        //    try
        //    {
        //        OTT oTT = new OTT();
        //        oTT.Show();
        //        Global.G_Form = Application.SBO_Application.Forms.Item("FIL_FRM_OTT");
        //        Global.G_Form.Freeze(true);
        //        Global.G_Form.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
        //        Global.G_Form.Items.Item("ETDOCNUM").Enabled = true;
        //        SAPbouiCOM.EditText cETOTTID = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETDOCNUM").Specific;
        //        cETOTTID.Value = OTTDOC;
        //        Global.G_Form.Items.Item("1").Click();
        //        Global.G_Form.Mode = SAPbouiCOM.BoFormMode.fm_VIEW_MODE;
        //        Global.G_Form.Freeze(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.G_Form.Freeze(false);

        //        Application.SBO_Application.StatusBar.SetText("Error in open OTT: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

        public void OpenOTT(string ottDocNo)
        {
            SAPbouiCOM.Form ottForm = null;
            bool isFrozen = false;

            try
            {
                if (string.IsNullOrWhiteSpace(ottDocNo))
                    return;

                OTT ott = new OTT();
                ott.Show();

                ottForm = Application.SBO_Application.Forms.Item("FIL_FRM_OTT");

                ottForm.Freeze(true);
                isFrozen = true;

                ottForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                ottForm.Items.Item("ETDOCNUM").Enabled = true;

                SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)ottForm.Items.Item("ETDOCNUM").Specific;
                etDocNum.Value = ottDocNo.Trim();

                ottForm.Items.Item("1").Click();

                if (ottForm.Mode != SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                    ottForm.Mode = SAPbouiCOM.BoFormMode.fm_VIEW_MODE;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in OpenOTT: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                if (ottForm != null && isFrozen)
                {
                    try
                    {
                        ottForm.Freeze(false);
                    }
                    catch
                    {
                    }
                }
            }
        }
        //public void OpenSalesContract(string OTTEntry)
        //{
        //    try
        //    {
        //        SalesContract sc = new SalesContract();
        //        sc.Show();
        //        Global.G_Form = Application.SBO_Application.Forms.Item("FIL_FRM_SLCNTRCT");
        //        Global.G_Form.Freeze(true);
        //        Global.G_Form.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
        //        Global.G_Form.Items.Item("ETDOCNUM").Enabled = true;
        //        SAPbouiCOM.EditText cETOTTID = (SAPbouiCOM.EditText)Global.G_Form.Items.Item("ETDOCNUM").Specific;
        //        cETOTTID.Value = OTTEntry;
        //        Global.G_Form.Items.Item("1").Click();
        //        Global.G_Form.Mode = SAPbouiCOM.BoFormMode.fm_VIEW_MODE;
        //        Global.G_Form.Freeze(false);
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.G_Form.Freeze(false);

        //        Application.SBO_Application.StatusBar.SetText("Error in open OTT: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

        public void OpenSalesContract(string salesContractNo)
        {
            SAPbouiCOM.Form salesContractForm = null;
            bool isFrozen = false;

            try
            {
                if (string.IsNullOrWhiteSpace(salesContractNo))
                    return;

                SalesContract salesContract = new SalesContract();
                salesContract.Show();

                salesContractForm = Application.SBO_Application.Forms.Item("FIL_FRM_SLCNTRCT");

                salesContractForm.Freeze(true);
                isFrozen = true;

                salesContractForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
                salesContractForm.Items.Item("ETSCNO").Enabled = true;

                SAPbouiCOM.EditText etDocNum = (SAPbouiCOM.EditText)salesContractForm.Items.Item("ETSCNO").Specific;
                etDocNum.Value = salesContractNo.Trim();

                salesContractForm.Items.Item("1").Click();

                if (salesContractForm.Mode != SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                    salesContractForm.Mode = SAPbouiCOM.BoFormMode.fm_VIEW_MODE;
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in OpenSalesContract: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
            finally
            {
                if (salesContractForm != null && isFrozen)
                {
                    try
                    {
                        salesContractForm.Freeze(false);
                    }
                    catch
                    {
                    }
                }
            }
        }



        //private void LoadGrid(ref SAPbouiCOM.Form pform, bool FromDataEvent)
        //{
        //    try
        //    {
        //        string qStr = string.Empty;

        //        if (FromDataEvent == false)
        //        {
        //            SAPbouiCOM.EditText oETSLNTRY =
        //                (SAPbouiCOM.EditText)pform.Items.Item("ETSLNTRY").Specific;

        //            qStr = @"
        //                    SELECT A.""U_SIZECODE""
        //                    FROM ""@FIL_DR_PSMST"" A
        //                    INNER JOIN ""@FIL_MR_STM1"" B ON B.""U_SIZECODE"" = A.""U_SIZECODE""
        //                    WHERE A.""DocEntry"" = '" + oETSLNTRY.Value.Trim() + @"'
        //                    AND A.""U_SIZEAPPL"" = 'Y'
        //                    GROUP BY A.""U_SIZECODE""
        //                    ORDER BY A.""U_SIZECODE""";

        //            SAPbobsCOM.Recordset SizerSet =
        //                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        //            SizerSet.DoQuery(qStr);

        //            string SizeString = "";

        //            while (!SizerSet.EoF)
        //            {
        //                string sizeCode = SizerSet.Fields.Item("U_SIZECODE").Value.ToString().Trim();
        //                string safeSizeCodeAlias = sizeCode.Replace("\"", "");

        //                SizeString += @"0 AS """ + safeSizeCodeAlias + @"""";

        //                SizerSet.MoveNext();

        //                if (!SizerSet.EoF)
        //                    SizeString += ",";
        //            }

        //            //qStr = @"
        //            //        SELECT ""U_COLORNAME"" AS ""Colour Name"",
        //            //               ""U_COLORCODE"" AS ""Colour Code"""
        //            //               + (string.IsNullOrWhiteSpace(SizeString) ? "" : "," + SizeString) + @",
        //            //               ""Total"" AS ""Total""
        //            //                FROM
        //            //                (
        //            //                        SELECT 0 AS ""LineId"",
        //            //                               B.""LineId"" AS ""RCount"",
        //            //                               B.""U_COLORCODE"",
        //            //                               B.""U_COLORNAME"",
        //            //                               0 AS ""Total""
        //            //                        FROM ""@FIL_DR_PSMST"" A
        //            //                        INNER JOIN ""@FIL_DR_PSMCO"" B
        //            //                            ON A.""DocEntry"" = B.""DocEntry""
        //            //                        WHERE A.""DocEntry"" = '" + oETSLNTRY.Value.Trim() + @"'
        //            //                        GROUP BY B.""LineId"", B.""U_COLORCODE"", B.""U_COLORNAME""
        //            //                ) V1
        //            //                ORDER BY V1.""RCount""";
        //            qStr = @"
        //                    SELECT ""U_COLORNAME"" AS ""Colour Name"",
        //                           ""U_COLORCODE"" AS ""Colour Code"""
        //                           + (string.IsNullOrWhiteSpace(SizeString) ? "" : "," + SizeString) + @",
        //                           ""Total"" AS ""Total""
        //                    FROM
        //                    (
        //                        SELECT 0 AS ""LineId"",
        //                               B.""LineId"" AS ""RCount"",
        //                               B.""U_COLORCODE"",
        //                               B.""U_COLORNAME"",
        //                               0 AS ""Total""
        //                        FROM ""@FIL_DR_PSMST"" A
        //                        INNER JOIN ""@FIL_DR_PSMCO"" B
        //                            ON A.""DocEntry"" = B.""DocEntry""
        //                        WHERE A.""DocEntry"" = '" + oETSLNTRY.Value.Trim() + @"'
        //                          AND A.""U_SIZEAPPL"" = 'Y'
        //                        GROUP BY B.""LineId"",
        //                                 B.""U_COLORCODE"",
        //                                 B.""U_COLORNAME""
        //                    ) V1
        //                    ORDER BY V1.""RCount""";
        //        }
        //        else
        //        {
        //            string docEntry = pform.DataSources.DBDataSources.Item("OQUT")
        //                              .GetValue("U_CRSZNTRY", 0).ToString().Trim();

        //            if (string.IsNullOrWhiteSpace(docEntry))
        //                return;

        //            string styleEntry = pform.DataSources.DBDataSources.Item("OQUT")
        //             .GetValue("U_STYLENTRY", 0)
        //             .ToString()
        //             .Trim();

        //            qStr = @"
        //                    SELECT A.""U_SIZECODE""
        //                    FROM ""@FIL_DR_OQUT"" A
        //                    INNER JOIN ""@FIL_DR_PSMST"" S
        //                        ON S.""DocEntry"" = '" + styleEntry + @"'
        //                       AND S.""U_SIZECODE"" = A.""U_SIZECODE""
        //                       AND S.""U_SIZEAPPL"" = 'Y'
        //                    WHERE A.""DocEntry"" = '" + docEntry + @"'
        //                    GROUP BY A.""U_SIZECODE""
        //                    ORDER BY A.""U_SIZECODE""";

        //            SAPbobsCOM.Recordset SizerSet1 =
        //                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        //            SizerSet1.DoQuery(qStr);

        //            string SizeString = "";

        //            while (!SizerSet1.EoF)
        //            {
        //                string sizeCode = SizerSet1.Fields.Item("U_SIZECODE").Value.ToString().Trim();
        //                string safeSizeCodeValue = sizeCode.Replace("'", "''");
        //                string safeSizeCodeAlias = sizeCode.Replace("\"", "");

        //                SizeString += @"SUM(CASE
        //                    WHEN A.""U_SIZECODE"" = '" + safeSizeCodeValue + @"'
        //                    THEN A.""U_QTY""
        //                    ELSE 0
        //                END) AS """ + safeSizeCodeAlias + @"""";

        //                SizerSet1.MoveNext();

        //                if (!SizerSet1.EoF)
        //                    SizeString += ",";
        //            }

        //            qStr = @"
        //                    SELECT A.""U_COLORNAME"" AS ""Colour Name"",
        //                           A.""U_COLORCODE"" AS ""Colour Code"""
        //                            + (string.IsNullOrWhiteSpace(SizeString) ? "" : "," + SizeString) + @",
        //                           SUM(A.""U_QTY"") AS ""Total""
        //                    FROM ""@FIL_DR_OQUT"" A
        //                    INNER JOIN ""@FIL_DR_PSMST"" S
        //                        ON S.""DocEntry"" = '" + styleEntry + @"'
        //                       AND S.""U_SIZECODE"" = A.""U_SIZECODE""
        //                       AND S.""U_SIZEAPPL"" = 'Y'
        //                    WHERE A.""DocEntry"" = '" + docEntry + @"'
        //                    GROUP BY A.""U_COLORNAME"",
        //                             A.""U_COLORCODE""
        //                    ORDER BY A.""U_COLORCODE""";
        //        }

        //        Global.oGrid = (SAPbouiCOM.Grid)pform.Items.Item("SCGrid").Specific;
        //        Global.oDataTable = pform.DataSources.DataTables.Item("DT_0");

        //        Global.oDataTable.ExecuteQuery(qStr);
        //        Global.oGrid.DataTable = Global.oDataTable;

        //        Global.oGrid.Columns.Item("Colour Name").Editable = false;
        //        Global.oGrid.Columns.Item("Colour Code").Editable = false;
        //        Global.oGrid.Columns.Item("Total").Editable = false;

        //        Global.oGrid.AutoResizeColumns();
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            "Error in LoadGrid: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

        private void RefreshGridPreserveQty(ref SAPbouiCOM.Form pForm)
        {
            try
            {
                SAPbouiCOM.DataTable oldDataTable = pForm.DataSources.DataTables.Item("DT_0");
                Dictionary<string, double> oldQty = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);

                if (oldDataTable != null && oldDataTable.Rows.Count > 0)
                {
                    for (int row = 0; row < oldDataTable.Rows.Count; row++)
                    {
                        string colourCode = "";

                        try
                        {
                            object colourObj = oldDataTable.Columns.Item("Colour Code").Cells.Item(row).Value;

                            if (colourObj != null)
                                colourCode = colourObj.ToString().Trim();
                        }
                        catch
                        {
                            colourCode = "";
                        }

                        if (string.IsNullOrWhiteSpace(colourCode))
                            continue;

                        for (int col = 0; col < oldDataTable.Columns.Count; col++)
                        {
                            string columnName = oldDataTable.Columns.Item(col).Name;

                            if (columnName == "Colour Name" || columnName == "Colour Code" || columnName == "Total")
                                continue;

                            double qty = 0;

                            try
                            {
                                object qtyObj = oldDataTable.Columns.Item(columnName).Cells.Item(row).Value;

                                if (qtyObj != null && !string.IsNullOrWhiteSpace(qtyObj.ToString()))
                                    double.TryParse(qtyObj.ToString(), out qty);
                            }
                            catch
                            {
                                qty = 0;
                            }

                            string key = colourCode + "|" + columnName;

                            if (oldQty.ContainsKey(key))
                                oldQty[key] = qty;
                            else
                                oldQty.Add(key, qty);
                        }
                    }
                }

                LoadGrid(ref pForm, false);

                SAPbouiCOM.DataTable newDataTable = pForm.DataSources.DataTables.Item("DT_0");

                if (newDataTable == null || newDataTable.Rows.Count == 0)
                    return;

                for (int row = 0; row < newDataTable.Rows.Count; row++)
                {
                    string colourCode = "";

                    try
                    {
                        object colourObj = newDataTable.Columns.Item("Colour Code").Cells.Item(row).Value;

                        if (colourObj != null)
                            colourCode = colourObj.ToString().Trim();
                    }
                    catch
                    {
                        colourCode = "";
                    }

                    if (string.IsNullOrWhiteSpace(colourCode))
                        continue;

                    double rowTotal = 0;

                    for (int col = 0; col < newDataTable.Columns.Count; col++)
                    {
                        string columnName = newDataTable.Columns.Item(col).Name;

                        if (columnName == "Colour Name" || columnName == "Colour Code" || columnName == "Total")
                            continue;

                        string key = colourCode + "|" + columnName;
                        double qty = 0;

                        if (oldQty.ContainsKey(key))
                        {
                            qty = oldQty[key];
                            newDataTable.Columns.Item(columnName).Cells.Item(row).Value = qty.ToString();
                        }

                        rowTotal += qty;
                    }

                    newDataTable.Columns.Item("Total").Cells.Item(row).Value = rowTotal.ToString();
                }

                SAPbouiCOM.Grid oGrid = (SAPbouiCOM.Grid)pForm.Items.Item("SCGrid").Specific;

                oGrid.DataTable = newDataTable;
                oGrid.Columns.Item("Colour Name").Editable = false;
                oGrid.Columns.Item("Colour Code").Editable = false;
                oGrid.Columns.Item("Total").Editable = false;
                oGrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error refreshing Size-Colour grid: " + ex.Message);
            }
        }

        private void LoadGrid(ref SAPbouiCOM.Form pform, bool FromDataEvent)
        {
            try
            {
                string qStr = string.Empty;
                string SizeString = string.Empty;

                Global.oGrid = (SAPbouiCOM.Grid)pform.Items.Item("SCGrid").Specific;
                Global.oDataTable = pform.DataSources.DataTables.Item("DT_0");

                // ============================================================
                // LOAD INFO / NEW DATA
                // Structure comes from CURRENT STYLE MASTER
                // ============================================================
                if (FromDataEvent == false)
                {
                    string styleEntry = pform.DataSources.DBDataSources.Item("OQUT").GetValue("U_STYLENTRY", 0).ToString().Trim();

                    if (string.IsNullOrWhiteSpace(styleEntry))
                    {
                        SAPbouiCOM.EditText oETSLNTRY = (SAPbouiCOM.EditText)pform.Items.Item("ETSLNTRY").Specific;
                        styleEntry = oETSLNTRY.Value.Trim();
                    }

                    if (string.IsNullOrWhiteSpace(styleEntry))
                    {
                        Global.GFunc.ShowError("Style Entry is missing.");
                        return;
                    }

                    string safeStyleEntry = styleEntry.Replace("'", "''");

                    qStr = @"
                            SELECT A.""U_SIZECODE"",
                                   A.""LineId""
                            FROM ""@FIL_DR_PSMST"" A
                            WHERE A.""DocEntry"" = '" + safeStyleEntry + @"'
                              AND A.""U_SIZEAPPL"" = 'Y'
                            ORDER BY A.""LineId""";

                    SAPbobsCOM.Recordset sizeSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    sizeSet.DoQuery(qStr);

                    while (!sizeSet.EoF)
                    {
                        string sizeCode = sizeSet.Fields.Item("U_SIZECODE").Value.ToString().Trim();
                        string safeSizeCodeAlias = sizeCode.Replace("\"", "");

                        SizeString += @"0 AS """ + safeSizeCodeAlias + @"""";

                        sizeSet.MoveNext();

                        if (!sizeSet.EoF)
                            SizeString += ",";
                    }

                    qStr = @"
                    SELECT B.""U_COLORNAME"" AS ""Colour Name"",
                           B.""U_COLORCODE"" AS ""Colour Code"""
                                   + (string.IsNullOrWhiteSpace(SizeString) ? "" : "," + SizeString) + @",
                           0 AS ""Total""
                    FROM ""@FIL_DR_PSMCO"" B
                    WHERE B.""DocEntry"" = '" + safeStyleEntry + @"'
                    ORDER BY B.""LineId""";
                }

                // ============================================================
                // PREVIOUS / DRAFT / SAVED DATA
                // EVERYTHING comes ONLY from @FIL_DR_OQUT
                // Do NOT take new Size or Colour from Style Master
                // ============================================================
                else
                {
                    string sizeEntry = pform.DataSources.DBDataSources.Item("OQUT").GetValue("U_CRSZNTRY", 0).ToString().Trim();

                    if (string.IsNullOrWhiteSpace(sizeEntry))
                        return;

                    string safeSizeEntry = sizeEntry.Replace("'", "''");

                    // ========================================================
                    // Saved Size columns only
                    // ========================================================

                    qStr = @"
                    SELECT A.""U_SIZECODE"",
                           MIN(A.""LineId"") AS ""RCount""
                    FROM ""@FIL_DR_OQUT"" A
                    WHERE A.""DocEntry"" = '" + safeSizeEntry + @"'
                    GROUP BY A.""U_SIZECODE""
                    ORDER BY ""RCount""";

                    SAPbobsCOM.Recordset sizeSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    sizeSet.DoQuery(qStr);

                    while (!sizeSet.EoF)
                    {
                        string sizeCode = sizeSet.Fields.Item("U_SIZECODE").Value.ToString().Trim();
                        string safeSizeCodeValue = sizeCode.Replace("'", "''");
                        string safeSizeCodeAlias = sizeCode.Replace("\"", "");

                        SizeString += @"SUM(CASE
                                    WHEN A.""U_SIZECODE"" = '" + safeSizeCodeValue + @"'
                                    THEN IFNULL(A.""U_QTY"", 0)
                                    ELSE 0
                                END) AS """ + safeSizeCodeAlias + @"""";

                        sizeSet.MoveNext();

                        if (!sizeSet.EoF)
                            SizeString += ",";
                    }

                    // ========================================================
                    // Saved Colours only
                    // ========================================================
                    qStr = @"
                    SELECT A.""U_COLORNAME"" AS ""Colour Name"",
                           A.""U_COLORCODE"" AS ""Colour Code"""
                                   + (string.IsNullOrWhiteSpace(SizeString) ? "" : "," + SizeString) + @",
                           SUM(IFNULL(A.""U_QTY"", 0)) AS ""Total"",
                           MIN(A.""LineId"") AS ""RCount""
                    FROM ""@FIL_DR_OQUT"" A
                    WHERE A.""DocEntry"" = '" + safeSizeEntry + @"'
                    GROUP BY A.""U_COLORNAME"",
                             A.""U_COLORCODE""
                    ORDER BY ""RCount""";
                }

                Global.oDataTable.ExecuteQuery(qStr);
                Global.oGrid.DataTable = Global.oDataTable;

                Global.oGrid.Columns.Item("Colour Name").Editable = false;
                Global.oGrid.Columns.Item("Colour Code").Editable = false;
                Global.oGrid.Columns.Item("Total").Editable = false;

                try
                {
                    Global.oGrid.Columns.Item("RCount").Visible = false;
                }
                catch
                {
                }

                Global.oGrid.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error in LoadGrid: " + ex.Message);
            }
        }

        private void LoadMatrix(ref SAPbouiCOM.Form pForm)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)pForm.Items.Item("38").Specific;
                SAPbouiCOM.DataTable oDataTable = pForm.DataSources.DataTables.Item("DT_0");

                string styleEntry = pForm.DataSources.DBDataSources.Item("OQUT").GetValue("U_STYLENTRY", 0).Trim();
                string styleCode = pForm.DataSources.DBDataSources.Item("OQUT").GetValue("U_STYLECODE", 0).Trim();

                if (string.IsNullOrWhiteSpace(styleEntry) || string.IsNullOrWhiteSpace(styleCode))
                {
                    Global.GFunc.ShowError("Style Entry / Style Code is missing.");
                    return;
                }

                if (oDataTable == null || oDataTable.Rows.Count == 0)
                {
                    Global.GFunc.ShowError("Size and Colour grid has no data.");
                    return;
                }

                Global.oColumn = oMatrix.Columns.Item("U_FGCOLOUR");
                Global.oColumn.Editable = true;

                Global.oColumn = oMatrix.Columns.Item("U_FGSIZE");
                Global.oColumn.Editable = true;

                Global.oColumn = oMatrix.Columns.Item("U_STYLECODE");
                Global.oColumn.Editable = true;

                HashSet<string> existingItemCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    try
                    {
                        string existingItemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(i).Specific).Value.Trim();

                        if (!string.IsNullOrWhiteSpace(existingItemCode))
                            existingItemCodes.Add(existingItemCode);
                    }
                    catch
                    {
                    }
                }

                int addedCount = 0;
                int skippedCount = 0;

                for (int j = 0; j < oDataTable.Rows.Count; j++)
                {
                    string colourCode = "";

                    try
                    {
                        object colourObj = oDataTable.Columns.Item("Colour Code").Cells.Item(j).Value;

                        if (colourObj != null)
                            colourCode = colourObj.ToString().Trim();
                    }
                    catch
                    {
                        colourCode = "";
                    }

                    if (string.IsNullOrWhiteSpace(colourCode))
                        continue;

                    string safeStyleEntry = styleEntry.Replace("'", "''");
                    string safeStyleCode = styleCode.Replace("'", "''");
                    string safeColourCode = colourCode.Replace("'", "''");

                    string qStr = @"
                                    SELECT A.""ItemCode"",
                                           A.""U_COLORCODE"",
                                           B.""U_COLORNAME"",
                                           A.""U_SIZECODE"",
                                           C.""U_SIZENAME""
                                    FROM ""OITM"" A
                                    INNER JOIN ""@FIL_DR_PSMCO"" B
                                        ON B.""DocEntry"" = '" + safeStyleEntry + @"'
                                       AND B.""U_COLORCODE"" = A.""U_COLORCODE""
                                    INNER JOIN ""@FIL_DR_PSMST"" C
                                        ON C.""DocEntry"" = '" + safeStyleEntry + @"'
                                       AND C.""U_SIZECODE"" = A.""U_SIZECODE""
                                       AND C.""U_SIZEAPPL"" = 'Y'
                                    WHERE A.""U_STYLECODE"" = '" + safeStyleCode + @"'
                                      AND A.""U_COLORCODE"" = '" + safeColourCode + @"'
                                    ORDER BY B.""LineId"",
                                             C.""LineId""";

                    SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    rs.DoQuery(qStr);

                    while (!rs.EoF)
                    {
                        string itemCode = rs.Fields.Item("ItemCode").Value.ToString().Trim();
                        string sizeCode = rs.Fields.Item("U_SIZECODE").Value.ToString().Trim();
                        string colorCode = rs.Fields.Item("U_COLORCODE").Value.ToString().Trim();
                        string colorName = rs.Fields.Item("U_COLORNAME").Value.ToString().Trim();

                        double cellValue = 0;

                        try
                        {
                            object cellObj = oDataTable.Columns.Item(sizeCode).Cells.Item(j).Value;

                            if (cellObj != null && !string.IsNullOrWhiteSpace(cellObj.ToString()))
                                double.TryParse(cellObj.ToString(), out cellValue);
                        }
                        catch
                        {
                            cellValue = 0;
                        }

                        // Qty zero or negative means do nothing.
                        if (cellValue <= 0)
                        {
                            rs.MoveNext();
                            continue;
                        }

                        // Existing Matrix 38 item must remain completely untouched.
                        if (existingItemCodes.Contains(itemCode))
                        {
                            skippedCount++;
                            rs.MoveNext();
                            continue;
                        }

                        AddMatrixRowIfNeeded(oMatrix);

                        int newRow = oMatrix.RowCount;

                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(newRow).Specific).Value = itemCode;
                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGCOLOUR").Cells.Item(newRow).Specific).Value = colorCode;
                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGCOLRNM").Cells.Item(newRow).Specific).Value = colorName;
                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGSIZE").Cells.Item(newRow).Specific).Value = sizeCode;
                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_STYLECODE").Cells.Item(newRow).Specific).Value = styleCode;
                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_STYLENTRY").Cells.Item(newRow).Specific).Value = styleEntry;
                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(newRow).Specific).Value = cellValue.ToString();

                        existingItemCodes.Add(itemCode);
                        addedCount++;

                        rs.MoveNext();
                    }
                }

                //double totalQty = 0;

                //for (int i = 1; i <= oMatrix.RowCount; i++)
                //{
                //    try
                //    {
                //        string itemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(i).Specific).Value.Trim();

                //        if (string.IsNullOrWhiteSpace(itemCode))
                //            continue;

                //        double rowQty = 0;
                //        double.TryParse(((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(i).Specific).Value.Trim(), out rowQty);

                //        totalQty += rowQty;
                //    }
                //    catch
                //    {
                //    }
                //}

                //((SAPbouiCOM.EditText)pForm.Items.Item("ETQty").Specific).Value = totalQty.ToString();
                UpdateTotalQtyFromMatrix(pForm);
                if (addedCount > 0)
                    Global.GFunc.ShowSuccess(addedCount + " new item(s) added successfully.");
                else
                    Global.GFunc.ShowSuccess("No new item found to add.");
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error in Load Matrix: " + ex.Message);
            }
        }


        //pREV WORKING LOAD GRID
        //private void LoadGrid(ref SAPbouiCOM.Form pform, bool FromDataEvent)
        //{
        //    try
        //    {
        //        string qStr = string.Empty;
        //        string SizeString = string.Empty;

        //        string styleEntry = pform.DataSources.DBDataSources.Item("OQUT").GetValue("U_STYLENTRY", 0).ToString().Trim();

        //        if (string.IsNullOrWhiteSpace(styleEntry))
        //        {
        //            SAPbouiCOM.EditText oETSLNTRY = (SAPbouiCOM.EditText)pform.Items.Item("ETSLNTRY").Specific;
        //            styleEntry = oETSLNTRY.Value.Trim();
        //        }

        //        if (string.IsNullOrWhiteSpace(styleEntry))
        //            return;

        //        // ============================================================
        //        // SIZE COLUMNS
        //        // Always take Size from Style Master.
        //        // Always order Size by @FIL_DR_PSMST.LineId.
        //        // ============================================================
        //        qStr = @"
        //                SELECT A.""U_SIZECODE"", A.""LineId""
        //                FROM ""@FIL_DR_PSMST"" A
        //                WHERE A.""DocEntry"" = '" + styleEntry.Replace("'", "''") + @"'
        //                  AND A.""U_SIZEAPPL"" = 'Y'
        //                ORDER BY A.""LineId""";

        //        SAPbobsCOM.Recordset sizeSet = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        //        sizeSet.DoQuery(qStr);

        //        while (!sizeSet.EoF)
        //        {
        //            string sizeCode = sizeSet.Fields.Item("U_SIZECODE").Value.ToString().Trim();
        //            string safeSizeCodeValue = sizeCode.Replace("'", "''");
        //            string safeSizeCodeAlias = sizeCode.Replace("\"", "");

        //            if (FromDataEvent == false)
        //            {
        //                SizeString += @"0 AS """ + safeSizeCodeAlias + @"""";
        //            }
        //            else
        //            {
        //                SizeString += @"SUM(CASE WHEN A.""U_SIZECODE"" = '" + safeSizeCodeValue + @"' THEN IFNULL(A.""U_QTY"", 0) ELSE 0 END) AS """ + safeSizeCodeAlias + @"""";
        //            }

        //            sizeSet.MoveNext();

        //            if (!sizeSet.EoF)
        //                SizeString += ",";
        //        }

        //        // ============================================================
        //        // NEW / LOAD INFO
        //        // Color always comes from Style Master.
        //        // Color order = @FIL_DR_PSMCO.LineId.
        //        // ============================================================
        //        if (FromDataEvent == false)
        //        {
        //            qStr = @"
        //                    SELECT B.""U_COLORNAME"" AS ""Colour Name"",
        //                           B.""U_COLORCODE"" AS ""Colour Code"""
        //                                   + (string.IsNullOrWhiteSpace(SizeString) ? "" : "," + SizeString) + @",
        //                           0 AS ""Total""
        //                    FROM ""@FIL_DR_PSMCO"" B
        //                    WHERE B.""DocEntry"" = '" + styleEntry.Replace("'", "''") + @"'
        //                    ORDER BY B.""LineId""";
        //        }
        //        else
        //        {
        //            // ============================================================
        //            // PREVIOUS SAVED DATA
        //            // Grid structure still comes from Style Master, not OQUT.
        //            // Therefore blank/zero Size columns do not disappear.
        //            // Color rows also remain in Style Master LineId order.
        //            // ============================================================
        //            string sizeEntry = pform.DataSources.DBDataSources.Item("OQUT").GetValue("U_CRSZNTRY", 0).ToString().Trim();

        //            if (string.IsNullOrWhiteSpace(sizeEntry))
        //                return;

        //            qStr = @"
        //                    SELECT B.""U_COLORNAME"" AS ""Colour Name"",
        //                           B.""U_COLORCODE"" AS ""Colour Code"""
        //                                   + (string.IsNullOrWhiteSpace(SizeString) ? "" : "," + SizeString) + @",
        //                           SUM(IFNULL(A.""U_QTY"", 0)) AS ""Total""
        //                    FROM ""@FIL_DR_PSMCO"" B
        //                    LEFT JOIN ""@FIL_DR_OQUT"" A
        //                        ON A.""DocEntry"" = '" + sizeEntry.Replace("'", "''") + @"'
        //                       AND A.""U_COLORCODE"" = B.""U_COLORCODE""
        //                       AND A.""U_SIZECODE"" IN
        //                       (
        //                           SELECT S.""U_SIZECODE""
        //                           FROM ""@FIL_DR_PSMST"" S
        //                           WHERE S.""DocEntry"" = '" + styleEntry.Replace("'", "''") + @"'
        //                             AND S.""U_SIZEAPPL"" = 'Y'
        //                       )
        //                    WHERE B.""DocEntry"" = '" + styleEntry.Replace("'", "''") + @"'
        //                    GROUP BY B.""LineId"", B.""U_COLORNAME"", B.""U_COLORCODE""
        //                    ORDER BY B.""LineId""";
        //        }

        //        Global.oGrid = (SAPbouiCOM.Grid)pform.Items.Item("SCGrid").Specific;
        //        Global.oDataTable = pform.DataSources.DataTables.Item("DT_0");

        //        Global.oDataTable.ExecuteQuery(qStr);
        //        Global.oGrid.DataTable = Global.oDataTable;

        //        Global.oGrid.Columns.Item("Colour Name").Editable = false;
        //        Global.oGrid.Columns.Item("Colour Code").Editable = false;
        //        Global.oGrid.Columns.Item("Total").Editable = false;

        //        Global.oGrid.AutoResizeColumns();
        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            "Error in LoadGrid: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

        // prev load Grid
        //private void LoadMatrix(ref SAPbouiCOM.Form pForm)
        //{
        //    try
        //    {
        //        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)pForm.Items.Item("38").Specific;
        //        SAPbouiCOM.DataTable oDataTable = pForm.DataSources.DataTables.Item("DT_0");

        //        double TotalQty = 0;

        //        string styleEntry = pForm.DataSources.DBDataSources.Item("OQUT").GetValue("U_STYLENTRY", 0).Trim();
        //        string styleCode = pForm.DataSources.DBDataSources.Item("OQUT").GetValue("U_STYLECODE", 0).Trim();

        //        if (string.IsNullOrWhiteSpace(styleEntry) || string.IsNullOrWhiteSpace(styleCode))
        //        {
        //            Application.SBO_Application.StatusBar.SetText(
        //                "Style Entry / Style Code is missing.",
        //                SAPbouiCOM.BoMessageTime.bmt_Short,
        //                SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //            return;
        //        }

        //        Global.oColumn = oMatrix.Columns.Item("U_FGCOLOUR");
        //        Global.oColumn.Editable = true;

        //        Global.oColumn = oMatrix.Columns.Item("U_FGSIZE");
        //        Global.oColumn.Editable = true;

        //        Global.oColumn = oMatrix.Columns.Item("U_STYLECODE");
        //        Global.oColumn.Editable = true;

        //        for (int j = 0; j <= oDataTable.Rows.Count - 1; j++)
        //        {
        //            string qStr = @"SELECT A.""ItemCode"",
        //                           A.""U_COLORCODE"",
        //                           B.""U_COLORNAME"",
        //                           A.""U_SIZECODE"",
        //                           C.""U_SIZENAME""
        //                    FROM ""OITM"" A
        //                    INNER JOIN ""@FIL_DR_PSMCO"" B
        //                        ON B.""DocEntry"" = '" + styleEntry + @"'
        //                       AND B.""U_COLORCODE"" = A.""U_COLORCODE""
        //                    INNER JOIN ""@FIL_DR_PSMST"" C
        //                        ON C.""DocEntry"" = '" + styleEntry + @"'
        //                       AND C.""U_SIZECODE"" = A.""U_SIZECODE""
        //                       AND C.""U_SIZEAPPL"" = 'Y'
        //                    WHERE A.""U_STYLECODE"" = '" + styleCode + @"'
        //                      AND A.""U_COLORCODE"" = '" + oDataTable.Columns.Item("Colour Code").Cells.Item(j).Value.ToString().Trim() + @"'
        //                    ORDER BY B.""LineId"", C.""LineId""";

        //            SAPbobsCOM.Recordset rs =
        //                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        //            rs.DoQuery(qStr);

        //            while (!rs.EoF)
        //            {
        //                double cellValue = 0;
        //                string sizeCode = rs.Fields.Item("U_SIZECODE").Value.ToString().Trim();
        //                string itemCode = rs.Fields.Item("ItemCode").Value.ToString().Trim();
        //                string colorCode = rs.Fields.Item("U_COLORCODE").Value.ToString().Trim();
        //                string colorName = rs.Fields.Item("U_COLORNAME").Value.ToString().Trim();

        //                object cellObj = null;
        //                try
        //                {
        //                    cellObj = oDataTable.Columns.Item(sizeCode).Cells.Item(j).Value;
        //                }
        //                catch
        //                {
        //                    cellObj = null;
        //                }

        //                if (cellObj != null && cellObj.ToString().Trim() != "")
        //                    double.TryParse(cellObj.ToString(), out cellValue);

        //                int existingRow = FindMatrixRowByItemCode(oMatrix, itemCode);

        //                if (cellValue > 0)
        //                {
        //                    if (existingRow > 0)
        //                    {
        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(existingRow).Specific).Value =
        //                            cellValue.ToString();

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGCOLOUR").Cells.Item(existingRow).Specific).Value =
        //                            colorCode;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGCOLRNM").Cells.Item(existingRow).Specific).Value =
        //                            colorName;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGSIZE").Cells.Item(existingRow).Specific).Value =
        //                            sizeCode;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_STYLECODE").Cells.Item(existingRow).Specific).Value =
        //                            styleCode;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_STYLENTRY").Cells.Item(existingRow).Specific).Value =
        //                            styleEntry;
        //                    }
        //                    else
        //                    {
        //                        AddMatrixRowIfNeeded(oMatrix);

        //                        int newRow = oMatrix.RowCount;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(newRow).Specific).Value =
        //                            itemCode;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGCOLOUR").Cells.Item(newRow).Specific).Value =
        //                            colorCode;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGCOLRNM").Cells.Item(newRow).Specific).Value =
        //                            colorName;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_FGSIZE").Cells.Item(newRow).Specific).Value =
        //                            sizeCode;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_STYLECODE").Cells.Item(newRow).Specific).Value =
        //                            styleCode;

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(newRow).Specific).Value =
        //                            cellValue.ToString();

        //                        ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_STYLENTRY").Cells.Item(newRow).Specific).Value =
        //                            styleEntry;
        //                    }
        //                }
        //                else
        //                {
        //                    // Qty 0 hole existing row delete
        //                    if (existingRow > 0)
        //                    {
        //                        try
        //                        {
        //                            oMatrix.DeleteRow(existingRow);
        //                        }
        //                        catch
        //                        {
        //                        }
        //                    }
        //                }

        //                rs.MoveNext();
        //            }
        //        }

        //        // Remove duplicate ItemCode rows if any
        //        RemoveDuplicateMatrixRows(oMatrix);
        //        // Remove rows where qty = 0 or itemcode blank
        //        RemoveZeroQtyAndBlankRows(oMatrix);
        //        // Recalculate total qty from matrix
        //        TotalQty = 0;
        //        for (int i = 1; i <= oMatrix.RowCount; i++)
        //        {
        //            string itemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(i).Specific).Value.Trim();
        //            if (!string.IsNullOrWhiteSpace(itemCode))
        //            {
        //                double rowQty = 0;
        //                double.TryParse(((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(i).Specific).Value, out rowQty);
        //                TotalQty += rowQty;
        //            }
        //        }
        //        ((SAPbouiCOM.EditText)pForm.Items.Item("ETQty").Specific).Value = TotalQty.ToString();

        //    }
        //    catch (Exception ex)
        //    {
        //        Application.SBO_Application.StatusBar.SetText(
        //            "Error in Load Matrix: " + ex.Message,
        //            SAPbouiCOM.BoMessageTime.bmt_Short,
        //            SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

        private void InsertSizeDetails(SAPbouiCOM.Form pForm, string ObjType, string ObjEntry, int SizeEntry)
        {
            SAPbobsCOM.Recordset rSet =
                (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            SAPbouiCOM.DataTable oDataTable = pForm.DataSources.DataTables.Item("DT_0");

            string styleEntry = pForm.DataSources.DBDataSources.Item("OQUT").GetValue("U_STYLENTRY", 0).Trim();
            string styleCode = pForm.DataSources.DBDataSources.Item("OQUT").GetValue("U_STYLECODE", 0).Trim();

            if (string.IsNullOrWhiteSpace(styleEntry) || string.IsNullOrWhiteSpace(styleCode))
                throw new Exception("Style Entry / Style Code is missing.");

            if (oDataTable == null || oDataTable.Rows.Count == 0)
                throw new Exception("Size and Colour grid has no data.");

            string qStr = string.Empty;
            string qStr1 = string.Empty;
            int lineId = 1;

            // 1. Get new SizeEntry if blank
            if (SizeEntry == 0)
            {
                qStr = @"SELECT IFNULL(MAX(""DocEntry""), 0) + 1 AS ""SizeEntry""
                 FROM ""@FIL_DR_OQUT""";
                rSet.DoQuery(qStr);
                SizeEntry = Convert.ToInt32(rSet.Fields.Item("SizeEntry").Value);
            }

            // 2. Always clear old rows for this entry first
            qStr = $@"DELETE FROM ""@FIL_DR_OQUT""
              WHERE ""DocEntry"" = '{SizeEntry}'";
            rSet.DoQuery(qStr);

            // 3. Build insert rows from grid + style master mapping
            for (int j = 0; j < oDataTable.Rows.Count; j++)
            {
                string colourCode = oDataTable.Columns.Item("Colour Code").Cells.Item(j).Value.ToString().Trim();
                string colourName = oDataTable.Columns.Item("Colour Name").Cells.Item(j).Value.ToString().Trim();
                string totalQty = oDataTable.Columns.Item("Total").Cells.Item(j).Value == null
                    ? "0"
                    : oDataTable.Columns.Item("Total").Cells.Item(j).Value.ToString().Trim();

                qStr = @"
                        SELECT A.""ItemCode"",
                               A.""U_COLORCODE"",
                               B.""U_COLORNAME"",
                               A.""U_SIZECODE"",
                               C.""U_SIZENAME""
                        FROM ""OITM"" A
                        INNER JOIN ""@FIL_DR_PSMCO"" B
                            ON B.""DocEntry"" = '" + styleEntry + @"'
                           AND B.""U_COLORCODE"" = A.""U_COLORCODE""
                        INNER JOIN ""@FIL_DR_PSMST"" C
                            ON C.""DocEntry"" = '" + styleEntry + @"'
                           AND C.""U_SIZECODE"" = A.""U_SIZECODE""
                           AND C.""U_SIZEAPPL"" = 'Y'
                        WHERE A.""U_STYLECODE"" = '" + styleCode + @"'
                          AND A.""U_COLORCODE"" = '" + colourCode + @"'
                        ORDER BY B.""LineId"", C.""LineId""";

                SAPbobsCOM.Recordset colourSizeSet =
                    (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                colourSizeSet.DoQuery(qStr);

                while (!colourSizeSet.EoF)
                {
                    string sizeCode = colourSizeSet.Fields.Item("U_SIZECODE").Value.ToString().Trim();

                    string qty = "0";
                    try
                    {
                        object qtyObj = oDataTable.Columns.Item(sizeCode).Cells.Item(j).Value;
                        qty = qtyObj == null || string.IsNullOrWhiteSpace(qtyObj.ToString())
                            ? "0"
                            : qtyObj.ToString().Trim();
                    }
                    catch
                    {
                        qty = "0";
                    }

                    // Only save rows where qty > 0
                    double dQty = 0;
                    double.TryParse(qty, out dQty);

                    if (dQty >= 0)
                    {
                        string safeColourCode = colourCode.Replace("'", "''");
                        string safeColourName = colourName.Replace("'", "''");
                        string safeSizeCode = sizeCode.Replace("'", "''");
                        string safeQty = qty.Replace("'", "''");
                        string safeTotalQty = totalQty.Replace("'", "''");

                        qStr1 += Environment.NewLine +
                            $@"INSERT INTO ""@FIL_DR_OQUT""
                       (""DocEntry"", ""LineId"", ""Object"", ""U_COLORCODE"", ""U_COLORNAME"", ""U_SIZECODE"", ""U_QTY"", ""U_TOTALQTY"")
                       VALUES
                       ('{SizeEntry}', '{lineId}', '23', '{safeColourCode}', '{safeColourName}', '{safeSizeCode}', '{safeQty}', '{safeTotalQty}');";

                        lineId++;
                    }

                    colourSizeSet.MoveNext();
                }
            }

            // 4. Execute insert block
            if (!string.IsNullOrWhiteSpace(qStr1))
            {
                SAPbobsCOM.Recordset execSet =
                    (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

                string finalSql = "DO " + Environment.NewLine +
                                  "BEGIN " + Environment.NewLine +
                                  qStr1 + Environment.NewLine +
                                  "END;";

                execSet.DoQuery(finalSql);
            }

             // 5. Push entry back to hidden bound field
             ((SAPbouiCOM.EditText)pForm.Items.Item("ETCRSZNTRY").Specific).Value = SizeEntry.ToString();
        }

        private void ClearQuotationMatrix(ref SAPbouiCOM.Form pForm)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)pForm.Items.Item("38").Specific;

                for (int i = oMatrix.VisualRowCount; i >= 2; i--)
                {
                    try
                    {
                        oMatrix.DeleteRow(i);
                    }
                    catch
                    {
                    }
                }

                try
                {
                    if (oMatrix.VisualRowCount >= 1)
                        oMatrix.ClearRowData(1);
                }
                catch
                {
                }

                // Clear Total Qty edittext also
                try
                {
                    ((SAPbouiCOM.EditText)pForm.Items.Item("ETQty").Specific).Value = "";
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.StatusBar.SetText(
                    "Error in ClearQuotationMatrix: " + ex.Message,
                    SAPbouiCOM.BoMessageTime.bmt_Short,
                    SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }

        private int FindMatrixRowByItemCode(SAPbouiCOM.Matrix oMatrix, string itemCode)
        {
            try
            {
                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    string existingItemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(i).Specific).Value.Trim();

                    if (existingItemCode == itemCode.Trim())
                        return i;
                }
            }
            catch { }

            return -1;
        }


        //private bool ValidateMatrixAndGridQty(SAPbouiCOM.Form oForm)
        //{
        //    SAPbouiCOM.Matrix oMatrix =
        //        (SAPbouiCOM.Matrix)oForm.Items.Item("38").Specific;

        //    SAPbouiCOM.DataTable oDataTable =
        //        oForm.DataSources.DataTables.Item("DT_0");

        //    double matrixQty = 0;
        //    double gridQty = 0;

        //    // Matrix 38 qty column = "11"
        //    for (int i = 1; i <= oMatrix.RowCount; i++)
        //    {
        //        string itemCode = "";
        //        string qtyText = "";

        //        try
        //        {
        //            itemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(i).Specific).Value.Trim();
        //            qtyText = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(i).Specific).Value.Trim();
        //        }
        //        catch { }

        //        if (!string.IsNullOrWhiteSpace(itemCode))
        //        {
        //            double qty = 0;
        //            double.TryParse(qtyText, out qty);
        //            matrixQty += qty;
        //        }
        //    }

        //    // SCGrid total column = "Total"
        //    for (int i = 0; i < oDataTable.Rows.Count; i++)
        //    {
        //        double qty = 0;
        //        object val = oDataTable.Columns.Item("Total").Cells.Item(i).Value;

        //        if (val != null && !string.IsNullOrWhiteSpace(val.ToString()))
        //            double.TryParse(val.ToString(), out qty);

        //        gridQty += qty;
        //    }

        //    if (matrixQty != gridQty)
        //    {
        //        Global.GFunc.ShowValidationError("Item quantity and Size-Colour quantity are not matched.\n\nItem Qty: " + matrixQty + "\nSize-Colour Qty: " + gridQty);
        //        return false;
        //    }

        //    return true;
        //}

        private bool ValidateMatrixAndGridQty(SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("38").Specific;
            SAPbouiCOM.DataTable oDataTable = oForm.DataSources.DataTables.Item("DT_0");

            double matrixQty = 0;
            double gridQty = 0;

            for (int i = 1; i <= oMatrix.RowCount; i++)
            {
                string itemCode = "";
                string qtyText = "";

                try
                {
                    itemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(i).Specific).Value.Trim();
                    qtyText = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(i).Specific).Value.Trim();
                }
                catch
                {
                }

                if (!string.IsNullOrWhiteSpace(itemCode))
                {
                    double qty = 0;
                    double.TryParse(qtyText, out qty);
                    matrixQty += qty;
                }
            }

            for (int i = 0; i < oDataTable.Rows.Count; i++)
            {
                double qty = 0;
                object value = oDataTable.Columns.Item("Total").Cells.Item(i).Value;

                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    double.TryParse(value.ToString(), out qty);
                }

                gridQty += qty;
            }

            if (Math.Abs(matrixQty - gridQty) > 0.0001)
            {
                Global.GFunc.ShowValidationError("Item quantity and Size-Colour quantity are not matched.\n\nItem Qty: " + matrixQty + "\nSize-Colour Qty: " + gridQty);
                return false;
            }

            return true;
        }

        private void AddMatrixRowIfNeeded(SAPbouiCOM.Matrix oMatrix)
        {
            try
            {
                if (oMatrix.RowCount == 0)
                {
                    oMatrix.AddRow();
                    return;
                }

                string lastItemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(oMatrix.RowCount).Specific).Value.Trim();

                if (!string.IsNullOrWhiteSpace(lastItemCode))
                    oMatrix.AddRow();
            }
            catch
            {
                oMatrix.AddRow();
            }
        }

        private void RemoveDuplicateMatrixRows(SAPbouiCOM.Matrix oMatrix)
        {
            try
            {
                HashSet<string> itemCodes = new HashSet<string>();

                for (int i = oMatrix.RowCount; i >= 1; i--)
                {
                    string itemCode = "";
                    try
                    {
                        itemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(i).Specific).Value.Trim();
                    }
                    catch
                    {
                        itemCode = "";
                    }

                    if (string.IsNullOrWhiteSpace(itemCode))
                        continue;

                    if (itemCodes.Contains(itemCode))
                    {
                        try
                        {
                            oMatrix.DeleteRow(i);
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        itemCodes.Add(itemCode);
                    }
                }
            }
            catch
            {
            }
        }

        private void UpdateTotalQtyFromMatrix(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("38").Specific;

                double totalQty = 0;

                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    string itemCode = "";
                    double rowQty = 0;

                    try
                    {
                        itemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(i).Specific).Value.Trim();

                        if (string.IsNullOrWhiteSpace(itemCode))
                            continue;

                        string qtyText = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(i).Specific).Value.Trim();

                        double.TryParse(qtyText, out rowQty);
                    }
                    catch
                    {
                        rowQty = 0;
                    }

                    totalQty += rowQty;
                }

                ((SAPbouiCOM.EditText)oForm.Items.Item("ETQty").Specific).Value = totalQty.ToString();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Error calculating total quantity: " + ex.Message);
            }
        }

        private void RemoveZeroQtyAndBlankRows(SAPbouiCOM.Matrix oMatrix)
        {
            try
            {
                for (int i = oMatrix.RowCount; i >= 1; i--)
                {
                    string itemCode = "";
                    double qty = 0;

                    try
                    {
                        itemCode = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("1").Cells.Item(i).Specific).Value.Trim();
                    }
                    catch
                    {
                        itemCode = "";
                    }

                    try
                    {
                        double.TryParse(((SAPbouiCOM.EditText)oMatrix.Columns.Item("11").Cells.Item(i).Specific).Value.Trim(), out qty);
                    }
                    catch
                    {
                        qty = 0;
                    }

                    if (string.IsNullOrWhiteSpace(itemCode) || qty <= 0)
                    {
                        if (oMatrix.RowCount > 1)
                        {
                            try
                            {
                                oMatrix.DeleteRow(i);
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                oMatrix.ClearRowData(i);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
