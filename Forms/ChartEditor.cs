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
                    formXmlXML = ITLec.CRMFormXmlGuy.AppCode.TreeNodeHelper.GetFormatedXML(formXmlXML);
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

            var worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += (w, evt) =>
            {
                service.Update((Entity)evt.Argument);

                ((BackgroundWorker)w).ReportProgress(0, "Publishing entity...");

                service.Execute(new PublishXmlRequest
                {
                    ParameterXml = string.Format("<importexportxml><entities><entity>{0}</entity></entities><nodes/><securityroles/><settings/><workflows/></importexportxml>", formXml.GetAttributeValue<string>("objecttypecode"))
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
            string newFormXmlName = ITLec.CRMFormXmlGuy.AppCode.Common.ShowDialog("New FormXml Name:", "FormXml Name", txtName.Text+" - COPY");

            if (!string.IsNullOrEmpty(newFormXmlName))
            {
                newformXml["name"] = newFormXmlName;
                newformXml["description"] = txtDescription.Text;
               // newformXml["datadescription"] = tecDataDescription.Text;
                newformXml["formxml"] = tecVisualizationDescription.Text;

                newformXml.Id = Guid.NewGuid();

                if (newformXml.Attributes.Contains("savedqueryvisualizationid"))
                {
                    newformXml["savedqueryvisualizationid"] = newformXml.Id;
                }
                else
                {
                    newformXml["userqueryvisualizationid"] = newformXml.Id;
                }

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
