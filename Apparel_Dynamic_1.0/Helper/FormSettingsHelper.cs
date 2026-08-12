using System;
using SAPbouiCOM.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apparel_Dynamic_1._0.Helper
{
    public static class FormSettingsHelper
    {
        private static string _sourceFormUID = "";
        private static string _sourceMatrixUID = "";
        private static bool _settingsOkClicked = false;
        private static bool _initialized = false;

        public static void Initialize()
        {
            try
            {
                if (_initialized)
                    return;

                Application.SBO_Application.MenuEvent += SBO_Application_MenuEvent;
                Application.SBO_Application.ItemEvent += SBO_Application_ItemEvent;

                _initialized = true;
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Form Settings Initialize Error: " + ex.Message);
            }
        }

        public static void Enable(SAPbouiCOM.Form oForm, string matrixUID)
        {
            try
            {
                if (oForm == null || string.IsNullOrWhiteSpace(matrixUID))
                    return;

                oForm.Settings.MatrixUID = matrixUID;
                oForm.Settings.Enabled = true;
                oForm.EnableMenu("5890", true);
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Enable Form Settings Error: " + ex.Message);
            }
        }

        private static void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction && pVal.MenuUID == "5890")
                {
                    SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.ActiveForm;

                    if (oForm == null)
                        return;

                    string matrixUID = oForm.Settings.MatrixUID;

                    if (string.IsNullOrWhiteSpace(matrixUID))
                        return;

                    _sourceFormUID = oForm.UniqueID;
                    _sourceMatrixUID = matrixUID;
                    _settingsOkClicked = false;
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Form Settings Menu Error: " + ex.Message);
            }
        }

        private static void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.FormTypeEx == "998" && pVal.ItemUID == "1" && pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.BeforeAction)
                {
                    _settingsOkClicked = true;
                }

                if (pVal.FormTypeEx == "998" && pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD && !pVal.BeforeAction)
                {
                    if (_settingsOkClicked)
                        ResizeMatrix();

                    Clear();
                }
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Form Settings Item Event Error: " + ex.Message);
            }
        }

        private static void ResizeMatrix()
        {
            SAPbouiCOM.Form oForm = null;

            try
            {
                if (string.IsNullOrWhiteSpace(_sourceFormUID) || string.IsNullOrWhiteSpace(_sourceMatrixUID))
                    return;

                if (!IsFormOpen(_sourceFormUID))
                    return;

                oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(_sourceFormUID);

                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(_sourceMatrixUID).Specific;

                oForm.Freeze(true);
                oMatrix.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                Global.GFunc.ShowError("Matrix Auto Resize Error: " + ex.Message);
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

        private static bool IsFormOpen(string formUID)
        {
            try
            {
                SAPbouiCOM.Form oForm = (SAPbouiCOM.Form)Application.SBO_Application.Forms.Item(formUID);
                return oForm != null;
            }
            catch
            {
                return false;
            }
        }

        private static void Clear()
        {
            _sourceFormUID = "";
            _sourceMatrixUID = "";
            _settingsOkClicked = false;
        }
    }
}
