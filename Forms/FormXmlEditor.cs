using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using XrmToolBox.Extensibility;
using ICSharpCode.TextEditor.Document;
using System.Collections.Generic;

namespace ITLec.FormXmlManager.Forms
{
    public partial class FormXmlEditor : Form
    {
        private Panel infoPanel;

        private readonly Entity formXml;

        private readonly IOrganizationService service;

        public FormXmlEditor(Entity formXml, IOrganizationService service)
        {
            InitializeComponent();
            this.formXml = formXml;
            this.service = service;
            
        }

        public bool HasUpdatedContent { get; private set; }

        private void FormXmlEditor_Load(object sender, EventArgs e)
        {
            txtName.Text = formXml.GetAttributeValue<string>("name");
            txtDescription.Text = formXml.GetAttributeValue<string>("description");
      //      tecDataDescription.Text = formXml.GetAttributeValue<string>("datadescription");
            tecVisualizationDescription.Text = formXml.GetAttributeValue<string>("formxml");

      //      tecDataDescription.Text = IndentXmlString(tecDataDescription.Text);
            tecVisualizationDescription.Text = IndentXmlString(tecVisualizationDescription.Text);

            //tecDataDescription.SetHighlighting("XML");
            tecVisualizationDescription.SetHighlighting("XML");
            
            Size = new Size(Size.Width + 1, Size.Height);



            this.tecVisualizationDescription.Document.FoldingManager.FoldingStrategy = new ICSharpCode.TextEditor.Src.Document.FoldingStrategy.XmlFoldingStrategy();
            // Update folding markers, call whenever you need to update the folding markers.
            // Especially when the text in the texteditor has been changed.
            this.tecVisualizationDescription.Document.FoldingManager.UpdateFoldings(null, null);

            /*     bool isSystemFormXml = true;
                 if (formXml.Attributes.Contains("userqueryvisualizationid"))
                 {
                     isSystemFormXml = false;
                 }

                 btnUpdatePublish.Visible = isSystemFormXml;
                 btnUpdate.Visible = !isSystemFormXml;

                 txtFormXmlType.Text = isSystemFormXml ? "System" : "User";*/


            bool isUser = true;
            if (formXml.Attributes.Contains("formid"))
            {
                isUser = false;
            }

            btnUpdate.Visible = isUser;
            btnUpdatePublish.Visible = !isUser;

            UpdateStatisticsPanel();

        }

        private void UpdateStatisticsPanel()
        {

            var xmlStr = tecVisualizationDescription.Text.ToLower();

            List<KeyValuePair<string, int>>  controlRepeatedDictionary = new List<KeyValuePair<string, int>>();



            foreach (var item in getControlsGuidType())
            {

               int repeatedTimes =  System.Text.RegularExpressions.Regex.Matches(xmlStr, item.Key.ToLower()).Count;

                if(repeatedTimes>0)
                {
                    controlRepeatedDictionary.Add(new KeyValuePair<string, int>(item.Key, repeatedTimes));
                }
            }

            controlRepeatedDictionary.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

                listViewControlsAnalysis.Items.Clear();
                var list = new List<ListViewItem>();
            foreach(var item in controlRepeatedDictionary)
            {
                
          //      listViewControlsAnalysis.Items.Add(new ListViewItem(getControlsGuidType()[item.Key].ToString(), item.Value));
          
                    var listViewItem = new ListViewItem { Text = getControlsGuidType()[item.Key].ToString(), Tag = getControlsGuidType()[item.Key].ToString() };
                    listViewItem.SubItems.Add(item.Value.ToString());
                    list.Add(listViewItem);
            }
              var  listViewItemsCache = list.ToArray();
                listViewControlsAnalysis.Items.AddRange(listViewItemsCache);

        }
        private Dictionary<string, string> getControlsGuidType()
        {
            Dictionary<string, string> controlsDic = new Dictionary<string, string>(); controlsDic.Add("{F93A31B2-99AC-4084-8EC2-D4027C31369A}", "AccessPrivilegeControl");

            controlsDic.Add("<tab", "Tab");
            controlsDic.Add("<section", "Section");
            controlsDic.Add("<section", "Section");
            controlsDic.Add("<row", "Section");
            controlsDic.Add("<cell", "Section");
            controlsDic.Add("<label", "Section");
            controlsDic.Add("{3F4E2A56-F102-4B4D-AB9C-F1574CA5BFDA}", "AccessTeamEntityPicker");
            controlsDic.Add("{C72511AB-84E5-4FB7-A543-25B4FC01E83E}", "ActivitiesContainerControl");
            controlsDic.Add("{6636847D-B74D-4994-B55A-A6FAF97ECEA2}", "ActivitiesWallControl");
            controlsDic.Add("{F02EF977-2564-4B9A-B2F0-DF083D8A019B}", "ArticleContentControl");
            controlsDic.Add("{00AD73DA-BD4D-49C6-88A8-2F4F4CAD4A20}", "ButtonControl");
            controlsDic.Add("{B0C6723A-8503-4FD7-BB28-C8A06AC933C2}", "CheckBoxControl");
            controlsDic.Add("{DB1284EF-9FFC-4E99-B382-0CC082FE2364}", "CompositionLinkControl");
            controlsDic.Add("{3246F906-1F71-45F7-B11F-D7BE0F9D04C9}", "ConnectionControl");
            controlsDic.Add("{821ACF1A-7E46-4A0C-965D-FE14A57D78C7}", "ConnectionRoleObjectTypeListControl");
            controlsDic.Add("{4168A05C-D857-46AF-8457-5BB47EB04EA1}", "CoverPagePicklistControl");
            controlsDic.Add("{F9A8A302-114E-466A-B582-6771B2AE0D92}", "CustomControl");
            controlsDic.Add("{5B773807-9FB2-42DB-97C3-7A91EFF8ADFF}", "DateTimeControl");
            controlsDic.Add("{C3EFE0C3-0EC6-42BE-8349-CBD9079DFD8E}", "DecimalControl");
            controlsDic.Add("{AA987274-CE4E-4271-A803-66164311A958}", "DurationControl");
            controlsDic.Add("{6896F004-B17A-4202-861E-8B7EA2080E0B}", "DynamicPropertyListControl");
            controlsDic.Add("{ADA2203E-B4CD-49BE-9DDF-234642B43B52}", "EmailAddressControl");
            controlsDic.Add("{6F3FB987-393B-4D2D-859F-9D0F0349B6AD}", "EmailBodyControl");
            controlsDic.Add("{F4C16ECA-CA81-4E39-9448-834B8378721E}", "ErrorStatusControl");
            controlsDic.Add("{0D2C745A-E5A8-4C8F-BA63-C6D3BB604660}", "FloatControl");
            controlsDic.Add("{FD2A7985-3187-444E-908D-6624B21F69C0}", "FrameControl");
            controlsDic.Add("{E7A81278-8635-4D9E-8D4D-59480B391C5B}", "GridControl");
            controlsDic.Add("{5546E6CD-394C-4BEE-94A8-4425E17EF6C6}", "HiddenInputControl");
            controlsDic.Add("{C6D124CA-7EDA-4A60-AEA9-7FB8D318B68F}", "IntegerControl");
            controlsDic.Add("{A62B6FA9-169E-406C-B1AA-EAB828CB6026}", "KBViewerControl");
            controlsDic.Add("{5635c4df-1453-413e-b213-e81b65411150}", "LabelControl");
            controlsDic.Add("{671A9387-CA5A-4D1E-8AB7-06E39DDCF6B5}", "LanguagePicker");
            controlsDic.Add("{DFDF1CDE-837B-4AC9-98CF-AC74361FD89D}", "LinkControl");
            controlsDic.Add("{270BD3DB-D9AF-4782-9025-509E298DEC0A}", "LookupControl");
            controlsDic.Add("{B634828E-C390-444A-AFE6-E07315D9D970}", "MailMergeLanguagePicker");
            controlsDic.Add("{91DC0675-C8B9-4421-B1E0-261CEBF02BAC}", "MapLinkControl");
            controlsDic.Add("{62B0DF79-0464-470F-8AF7-4483CFEA0C7D}", "MapsControl");
            controlsDic.Add("{533B9E00-756B-4312-95A0-DC888637AC78}", "MoneyControl");
            controlsDic.Add("{06375649-C143-495E-A496-C962E5B4488E}", "NotesControl");
            controlsDic.Add("{CBFB742C-14E7-4A17-96BB-1A13F7F64AA2}", "PartyListControl");
            controlsDic.Add("{8C10015A-B339-4982-9474-A95FE05631A5}", "PhoneNumberControl");
            controlsDic.Add("{3EF39988-22BB-4F0B-BBBE-64B5A3748AEE}", "PicklistControl");
            controlsDic.Add("{2305E33A-BAD3-4022-9E15-1856CF218333}", "PicklistLookupControl");
            controlsDic.Add("{5D68B988-0661-4DB2-BC3E-17598AD3BE6C}", "PicklistStatusControl");
            controlsDic.Add("{06E9F7AF-1F54-4681-8EEC-1E21A1CEB465}", "ProcessControl");
            controlsDic.Add("{5C5600E0-1D6E-4205-A272-BE80DA87FD42}", "QuickFormCollectionControl");
            controlsDic.Add("{69AF7DCA-2E3B-4EE7-9201-0DA731DD2413}", "QuickFormControl");
            controlsDic.Add("{67FAC785-CD58-4F9F-ABB3-4B7DDC6ED5ED}", "RadioControl");
            controlsDic.Add("{F3015350-44A2-4AA0-97B5-00166532B5E9}", "RegardingControl");
            controlsDic.Add("{163B90A6-EB64-49D2-9DF8-3C84A4F0A0F8}", "RelatedInformationControl");
            controlsDic.Add("{5F986642-5961-4D9F-AB5E-643D71E231E9}", "RelationshipRolePicklist");
            controlsDic.Add("{A28F441B-916C-4865-87FD-0C5D53BD59C9}", "ReportControl");
            controlsDic.Add("{E616A57F-20E0-4534-8662-A101B5DDF4E0}", "SearchWidget");
            controlsDic.Add("{86B9E25E-695E-4FEF-AC69-F05CFA96739C}", "SocialInsightControl");
            controlsDic.Add("{E0DECE4B-6FC8-4A8F-A065-082708572369}", "TextAreaControl");
            controlsDic.Add("{4273EDBD-AC1D-40D3-9FB2-095C621B552D}", "TextBoxControl");
            controlsDic.Add("{1E1FC551-F7A8-43AF-AC34-A8DC35C7B6D4}", "TickerControl");
            controlsDic.Add("{9C5CA0A1-AB4D-4781-BE7E-8DFBE867B87E}", "TimerControl");
            controlsDic.Add("{7C624A0B-F59E-493D-9583-638D34759266}", "TimeZonePicklistControl");
            controlsDic.Add("{71716B6C-711E-476C-8AB8-5D11542BFB47}", "UrlControl");
            controlsDic.Add("{9FDF5F91-88B1-47F4-AD53-C11EFC01A01D}", "WebResourceHtmlControl");
            controlsDic.Add("{587CDF98-C1D5-4BDE-8473-14A0BC7644A7}", "WebResourceImageControl");
            controlsDic.Add("{080677DB-86EC-4544-AC42-F927E74B491F}", "WebResourceSilverlightControl");

            return controlsDic;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string IndentXmlString(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
            {
                MemoryStream ms = new MemoryStream();
                XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode);
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.LoadXml(xml);

                    xtw.Formatting = Formatting.Indented;
                    doc.WriteContentTo(xtw);
                    xtw.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    StreamReader sr = new StreamReader(ms);
                    return sr.ReadToEnd();
                }
                catch (Exception error)
                {
                    MessageBox.Show(string.Format("An error occured while identing XML: {0}", error));
                    return null;
                }
            }
            return "";
        }


        private void btnlVisualEditor_Click(object sender, EventArgs e)
        {
            var pos = tecVisualizationDescription.ActiveTextAreaControl.Caret.Position;

            //  tecVisualizationDescription.ActiveTextAreaControl.TextArea.ge
            //  var dd = tecVisualizationDescription.Document.GetLineNumberForOffset(rr);

            tecVisualizationDescription.ActiveTextAreaControl.SelectionManager.SetSelection(new ICSharpCode.TextEditor.TextLocation(0, pos.Line), new ICSharpCode.TextEditor.TextLocation(1000000000, pos.Line));

            var str = tecVisualizationDescription.ActiveTextAreaControl.SelectionManager.SelectedText;

            str = tecVisualizationDescription.Text;
            var frm = new FormXmlEditorHelper(str);
           if ( frm.ShowDialog() ==  DialogResult.OK)
            {
                string formXmlXML = frm.FormXmlXML;

                if (!string.IsNullOrEmpty(formXmlXML))
                {
                    formXmlXML = ITLec.CRMFormXml.AppCode.TreeNodeHelper.GetFormatedXML(formXmlXML);
                    tecVisualizationDescription.Text = formXmlXML;
                }
            }
        }

        private void btnUpdatePublish_Click(object sender, EventArgs e)
        {

            formXml["name"] = txtName.Text;
            formXml["description"] = txtDescription.Text;
         //   formXml["datadescription"] = tecDataDescription.Text;
            formXml["formxml"] = tecVisualizationDescription.Text;


            infoPanel = InformationPanel.GetInformationPanel(this, "Updating formXml...", 350, 150);


            string objectType = formXml.GetAttributeValue<string>("objecttypecode");

            string paramXml = "";
            string xmlType = "Entity";
            if (objectType == "none")
            {
                xmlType = "Dashboard";
                var dashboardId = formXml.Id;
                paramXml = string.Format(@"<importexportxml>
 <dashboards>
  <dashboard>{0}</dashboard>
 </dashboards>
</importexportxml>", dashboardId);
            }
            else
            {
                paramXml = string.Format(" <importexportxml><entities><entity>{0}</entity></entities><nodes/><securityroles/><settings/><workflows/></importexportxml>", objectType);
            }


            var worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += (w, evt) =>
            {
                service.Update((Entity)evt.Argument);

                ((BackgroundWorker)w).ReportProgress(0, "Publishing " + xmlType +"...");


                service.Execute(new PublishXmlRequest
                {
                    ParameterXml = paramXml
                });
            };
            worker.ProgressChanged += (w, evt) =>
            {
                InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
            };
            worker.RunWorkerCompleted += (w, evt) =>
            {
                if (evt.Error != null)
                {
                    MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HasUpdatedContent = true;
                }

                Controls.Remove(infoPanel);
                infoPanel.Dispose();
            };
            worker.RunWorkerAsync(formXml);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            formXml["name"] = txtName.Text;
            formXml["description"] = txtDescription.Text;
         //   formXml["datadescription"] = tecDataDescription.Text;
            formXml["formxml"] = tecVisualizationDescription.Text;


            infoPanel = InformationPanel.GetInformationPanel(this, "Updating formXml...", 350, 150);

            var worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += (w, evt) =>
            {
                service.Update((Entity)evt.Argument);
            };
            worker.ProgressChanged += (w, evt) =>
            {
                InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
            };
            worker.RunWorkerCompleted += (w, evt) =>
            {
                if (evt.Error != null)
                {
                    MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HasUpdatedContent = true;
                }

                Controls.Remove(infoPanel);
                infoPanel.Dispose();
            };
            worker.RunWorkerAsync(formXml);
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {




            Entity newformXml = formXml;
            string newFormXmlName = ITLec.CRMFormXml.AppCode.Common.ShowDialog("New FormXml Name:", "FormXml Name", txtName.Text+" - COPY");

            if (!string.IsNullOrEmpty(newFormXmlName))
            {
                newformXml["name"] = newFormXmlName;
                newformXml["description"] = txtDescription.Text;
               // newformXml["datadescription"] = tecDataDescription.Text;
                newformXml["formxml"] = tecVisualizationDescription.Text;
                newformXml.Attributes.Remove(newformXml.LogicalName + "id");
             /*       newformXml.Id = Guid.NewGuid();

            if (newformXml.Attributes.Contains("savedqueryvisualizationid"))
                {
                    newformXml["savedqueryvisualizationid"] = newformXml.Id;
                }
                else
                {
                    newformXml["userqueryvisualizationid"] = newformXml.Id;
                }*/

                infoPanel = InformationPanel.GetInformationPanel(this, "Save As formXml...", 350, 150);

                var worker = new BackgroundWorker { WorkerReportsProgress = true };
                worker.DoWork += (w, evt) =>
                {
                    service.Create((Entity)evt.Argument);
                };
                worker.ProgressChanged += (w, evt) =>
                {
                    InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
                };
                worker.RunWorkerCompleted += (w, evt) =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        HasUpdatedContent = true;
                    }

                    Controls.Remove(infoPanel);
                    infoPanel.Dispose();
                    this.Close();
                };
                worker.RunWorkerAsync(newformXml);
            }
        }

        private void buttonDeleteFormXml_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure to delete this formXml ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                infoPanel = InformationPanel.GetInformationPanel(this, "Deleting formXml...", 350, 150);

                var worker = new BackgroundWorker { WorkerReportsProgress = true };
                worker.DoWork += (w, evt) =>
                {
                    service.Delete(((Entity)evt.Argument).LogicalName, ((Entity)evt.Argument).Id);
                };
                worker.ProgressChanged += (w, evt) =>
                {
                    InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
                };
                worker.RunWorkerCompleted += (w, evt) =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        HasUpdatedContent = true;
                    }

                    Controls.Remove(infoPanel);
                    infoPanel.Dispose();

                    this.Close();
                };
                worker.RunWorkerAsync(formXml);
            }
        }

        private void tecVisualizationDescription_Load(object sender, EventArgs e)
        {

        }

        private void txtFormXmlType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonUpdateStatistics_Click(object sender, EventArgs e)
        {
            UpdateStatisticsPanel();
        }

        private void listViewControlsAnalysis_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            var listView = (ListView)sender;

            listView.Sorting = listView.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            listView.ListViewItemSorter = new ListViewItemComparer(e.Column, listView.Sorting);
        }

        private void btnGenerateNewGuid_Click(object sender, EventArgs e)
        {
            string xml = tecVisualizationDescription.Text;
            string newXml = ReplaceGuids(xml);
            tecVisualizationDescription.Text = newXml;
        }

        static Dictionary<string, string> guidReplacements;
        public  string ReplaceGuids(string xmlData)
        {
            guidReplacements = new Dictionary<string, string>();
            string alphanum = "[0-9a-fA-F]";
            string expression = string.Format(
                @"<{1}.*[ ][i][d][=].*{0}{0}{0}{0}{0}{0}{0}{0}\-{0}{0}{0}{0}\-{0}{0}{0}{0}\-{0}{0}{0}{0}\-{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}",
                alphanum, ddlNewGuid.Text);
            return System.Text.RegularExpressions.Regex.Replace(xmlData, expression, new System.Text.RegularExpressions.MatchEvaluator(ReplaceGuid));
        }

        public  string ReplaceGuid(System.Text.RegularExpressions.Match m)
        {
            //<section name="ACCOUNT_INFORMATION" showlabel="true" showbar="false" id="{0eb92e6c-bcb8-0d52-a188-d81543ddb7cd
          //  if guidReplacements.Keys.!=m.Value)
            {
                string str = m.Value;

                string alphanum = "[0-9a-fA-F]";
                string expression = string.Format(
                    @"[ ][i][d][=].*{0}{0}{0}{0}{0}{0}{0}{0}\-{0}{0}{0}{0}\-{0}{0}{0}{0}\-{0}{0}{0}{0}\-{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}",
                    alphanum);
                string newGuid = " id=\"{" + Guid.NewGuid().ToString();
                string finalStr = System.Text.RegularExpressions.Regex.Replace(str, expression, newGuid);

                guidReplacements[m.Value] = finalStr;// Guid.NewGuid().ToString();
            }
            return guidReplacements[m.Value];
        }

    }
    /*
        public class VariXFolding : IFoldingStrategy
        {
            /// <summary>
            /// Generates the foldings for our document.
            /// </summary>
            /// <param name="document">The current document.</param>
            /// <param name="fileName">The filename of the document.</param>
            /// <param name="parseInformation">Extra parse information, not used in this sample.</param>
            /// <returns>A list of FoldMarkers.</returns>
             List<FoldMarker> IFoldingStrategy.GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
            {
                List<FoldMarker> list = new List<FoldMarker>();

                int start = 0;

                // Create foldmarkers for the whole document, enumerate through every line.
                for (int i = 0; i < document.TotalNumberOfLines; i++)
                {
                    // Get the text of current line.
                    string text = document.GetText(document.GetLineSegment(i));

                    if (text.StartsWith("<form") || text.Replace(" ","").StartsWith("<tab")) // Look for method starts
                        start = i;
                    if (text.StartsWith("</form>") || text.Replace(" ", "").StartsWith("</tab>")) // Look for method endings
                                                    // Add a new FoldMarker to the list.
                                                    // document = the current document
                                                    // start = the start line for the FoldMarker
                                                    // document.GetLineSegment(start).Length = the ending of the current line = the start column of our foldmarker.
                                                    // i = The current line = end line of the FoldMarker.
                                                    // 7 = The end column
                        list.Add(new FoldMarker(document, start, document.GetLineSegment(start).Length, i, 7));
                }

                return list;
            }

        }
    */

}
