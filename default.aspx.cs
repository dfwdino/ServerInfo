﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerInfo
{
    public partial class _default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblErrorMessage.Text = "";

                txtServerName.Text = "Masochist;masochista";
            }
        }

        protected void btnGetServerInfo_Click(object sender, EventArgs e)
        {   
            if (txtServerName.Text.Length.Equals(0))
            {
                lblErrorMessage.Text = "No Servers Listed.";
                return;
            }

            if (Properties.Settings.Default.WMIQuery.Length.Equals(0))
            {
                lblErrorMessage.Text = "No Query's could be found.";
                return;
            }

           

            string[] arrServers = txtServerName.Text.Split(';');
            AppCode.ProgramHelp PH = new AppCode.ProgramHelp();
            ManagementScope scope;

            string OutputCol = string.Empty;

            OutputCol = "<table>";
            
            OutputCol += "<tr>";
            foreach (string server in arrServers)
            {
                
                scope = new ManagementScope("\\\\" + server + "\\root\\cimv2");
                try
                {
                    scope.Connect();
                }
                catch (Exception ex)
                {
                    string servererror = string.Format("{0} - {1}", server, ex.Message);

                    OutputCol += "<td><h2>" + servererror + "<h2>";
                    continue;
                }
                

                
                int breakloop = 0;
                OutputCol += "<td><h2>" + server + "<h2>";
                foreach (string query in Properties.Settings.Default.WMIQuery.Split(';'))
                {
                    
                    System.Web.UI.WebControls.GridView GVData = PH.CreateGridView();

                    GVData.DataSource = PH.OutPutAllwmiSelect(query);
                    GVData.DataBind();
                    OutputCol += GridViewToHtml(GVData);
                   
                    ///Testing... remove after testing.
                #if DEBUG
                    if (breakloop.Equals(1))
                        break;
                    else
                        breakloop++;
                #endif

                }
 OutputCol += "</td>";
                


            }
OutputCol += "</tr>";

            testp.InnerHtml = OutputCol;
            
           

            scope = null;
            PH.Dispose();
            PH = null;
           
            return;
        }

        


       
        public void CreateHeaderAddLabel(string WhatToSay)
        {
            System.Web.UI.WebControls.Label lblHeadline = new Label();
            lblHeadline.Text = WhatToSay;
            form1.Controls.Add(lblHeadline);
        }

        private string GridViewToHtml(GridView gv)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gv.RenderControl(hw);
            return sb.ToString();
        }
       


    }
}