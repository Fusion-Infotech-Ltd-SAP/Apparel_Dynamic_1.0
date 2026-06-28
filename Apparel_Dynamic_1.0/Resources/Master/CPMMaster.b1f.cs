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
            //Static Text
            this.STBRNDCD = ((SAPbouiCOM.StaticText)(this.GetItem("STBRNDCD").Specific));
            this.STPDGPCD = ((SAPbouiCOM.StaticText)(this.GetItem("STPDGPCD").Specific));
            this.STRTSGCD = ((SAPbouiCOM.StaticText)(this.GetItem("STRTSGCD").Specific));
            this.STDOCNUM = ((SAPbouiCOM.StaticText)(this.GetItem("STDOCNUM").Specific));
            this.STFRMDAT = ((SAPbouiCOM.StaticText)(this.GetItem("STFRMDAT").Specific));
            this.STTODATE = ((SAPbouiCOM.StaticText)(this.GetItem("STTODATE").Specific));

            //Edit text
            this.ETBRNDCD = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDCD").Specific));
            this.ETBRNDNM = ((SAPbouiCOM.EditText)(this.GetItem("ETBRNDNM").Specific));
            this.ETDOCTRY = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.ETPDGPCD = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPCD").Specific));
            this.ETRTSGCD = ((SAPbouiCOM.EditText)(this.GetItem("ETRTSGCD").Specific));
            this.ETPDGPNM = ((SAPbouiCOM.EditText)(this.GetItem("ETPDGPNM").Specific));
            this.ETRTSGNM = ((SAPbouiCOM.EditText)(this.GetItem("ETRTSGNM").Specific));
            this.ETDOCNUM = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCNUM").Specific));
            this.ETFRMDAT = ((SAPbouiCOM.EditText)(this.GetItem("ETFRMDAT").Specific));
            this.ETTODATE = ((SAPbouiCOM.EditText)(this.GetItem("ETTODATE").Specific));

            //Combo box
            this.CBSERIES = ((SAPbouiCOM.ComboBox)(this.GetItem("CBSERIES").Specific));
            
            //tab
            this.TABSAMRN = ((SAPbouiCOM.Folder)(this.GetItem("TABSAMRN").Specific));
            this.TABCPM = ((SAPbouiCOM.Folder)(this.GetItem("TABCPM").Specific));
            //Matrix
            this.MTXSAMRN = ((SAPbouiCOM.Matrix)(this.GetItem("MTXSAMRN").Specific));
            this.MTXCPM = ((SAPbouiCOM.Matrix)(this.GetItem("MTXCPM").Specific));
            
            //Button
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

       
     
       



        
    }
}
