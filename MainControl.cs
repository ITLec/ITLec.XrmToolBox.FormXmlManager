using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using ITLec.FormXmlManager.Forms;
using ITLec.FormXmlManager.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace ITLec.FormXmlManager
{
    public partial class MainControl : PluginControlBase, IHelpPlugin
    {
        private string currentFolder;
        private ListViewItem[] listViewItemsCache;

        public string HelpUrl => "http://www.itlec.com/";

        #region Constructor

        public MainControl()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Main ToolStrip Handlers

        #region Fill Entities

        public void LoadEntities()
        {
            txtSearchEntity.Text = string.Empty;
            lvEntities.Items.Clear();
            gbEntities.Enabled = false;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading entities...",
                Work = (bw, e) =>
                {
                    e.Result = MetadataHelper.RetrieveEntities(Service);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(ParentForm, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        lvEntities.Items.Clear();
                        var list = new List<ListViewItem>();
                        foreach (EntityMetadata emd in (List<EntityMetadata>)e.Result)
                        {
                            var item = new ListViewItem { Text = emd.DisplayName.UserLocalizedLabel.Label, Tag = emd.LogicalName };
                            item.SubItems.Add(emd.LogicalName);
                            list.Add(item);
                        }

                        listViewItemsCache = list.ToArray();
                        lvEntities.Items.AddRange(listViewItemsCache);

                        gbEntities.Enabled = true;
                        tsbImportFormXmls.Enabled = true;
                        tsbExportFormXmls.Enabled = true;
                        tsbEditFormXml.Enabled = true;
                        toolStripButtonOpenCRMEditor.Enabled = true;
                        txtSearchEntity.Focus();
                    }
                }
            });
        }
        public void LoadDashboards()
        {
            txtSearchEntity.Text = string.Empty;
            lvEntities.Items.Clear();
            gbEntities.Enabled = false;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Dashboards...",
                Work = (bw, e) =>
                {
                  //  e.Result = MetadataHelper.RetrieveEntities(Service);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        MessageBox.Show(ParentForm, e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        lvEntities.Items.Clear();


                        var item = new ListViewItem { Text = "Dashboards", Tag = "none" };
                        item.SubItems.Add("none");
                   //     list.Add(item);

                     //   listViewItemsCache = list.ToArray();
                        lvEntities.Items.Add(item);

                        gbEntities.Enabled = true;
                        tsbImportFormXmls.Enabled = true;
                        tsbExportFormXmls.Enabled = true;
                        tsbEditFormXml.Enabled = true;
                        txtSearchEntity.Focus();
                    }
                }
            });
        }

        private void TsbLoadEntitiesClick(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        #endregion Fill Entities

        #endregion Main ToolStrip Handlers

        #region ListViews Handlers

        #region Fill Views

        private void lvEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEntities.SelectedItems.Count > 0)
            {
                string entityLogicalName = lvEntities.SelectedItems[0].Tag.ToString();

                Cursor = Cursors.WaitCursor;
                lvFormXmls.Items.Clear();

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading formXmls...",
                    AsyncArgument = entityLogicalName,
                    Work = (bw, evt) =>
                    {
                        evt.Result = FormXmlHelper.GetFormXmlsByEntity(evt.Argument.ToString(), Service);
                    },
                    PostWorkCallBack = evt =>
                    {
                        if (evt.Error != null)
                        {
                            MessageBox.Show(this, "An error occured: " + evt.Error.Message, "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            var formXmls = (EntityCollection)evt.Result;
                           // lvFormXmls.Items.AddRange(formXmls.Entities.Select(
                           //         c => new ListViewItem(,c.GetAttributeValue<string>("userqueryvisualizationid")) { Tag = c }).ToArray());
                            foreach(var entity in formXmls.Entities)
                            {
                                bool isUser = true;
                              if(  entity.Attributes.Contains("formid"))
                                {
                                    isUser = false;
                                }

                                ListViewItem lvi = new ListViewItem( );
                                lvi.Tag = entity;
                                lvi.SubItems.Add(entity.GetAttributeValue<string>("name"));
                                lvi.SubItems.Add(isUser.ToString());
                                lvi.SubItems.Add(entity.GetAttributeValue<bool>("isdefault").ToString());
                                lvi.SubItems.Add(entity.GetAttributeValue<bool>("isdesktopenabled").ToString());
                                lvi.SubItems.Add(entity.GetAttributeValue<bool>("istabletenabled").ToString());
                                lvi.SubItems.Add(entity.GetAttributeValue<string>("description"));
                                lvFormXmls.Items.Add(lvi);
                            }
                        }
                    }
                });
            }
        }

        #endregion Fill Views

        #endregion ListViews Handlers

        public void ProcessFiles(List<string> files)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Analyzing file(s)...",
                AsyncArgument = files,
                Work = (bw, e) => { e.Result = FormXmlHelper.AnalyzeFiles((List<string>)e.Argument, Service); },
                PostWorkCallBack = evt =>
                {
                    var results = (List<FormXmlDefinition>)evt.Result;
                    if (results.Any(r => r.Errors.Count > 0))
                    {
                        // Display errors
                        var elForm = new ErrorsListForm(results);
                        elForm.ShowDialog(ParentForm);
                    }
                    else
                    {
                        if (results.Any(r => r.Exists))
                        {
                            // Display overwrite confirmation
                            var ocDialog = new OverwriteConfirmationDialog(results);
                            var result = ocDialog.ShowDialog(ParentForm);
                            if (result == DialogResult.Cancel)
                                return;
                        }

                        WorkAsync(new WorkAsyncInfo("Importing file(s)...", (w, evt2) =>
                        {
                            FormXmlHelper.ImportFiles((List<FormXmlDefinition>)evt2.Argument, Service);

                            w.ReportProgress(0, "Publishing entities...");

                            Service.Execute(new PublishXmlRequest
                            {
                                ParameterXml = string.Format("<importexportxml><entities>{0}</entities><nodes/><securityroles/><settings/><workflows/></importexportxml>", string.Join("", results.Select(r => string.Format("<entity>{0}</entity>", r.Entity.GetAttributeValue<string>("primaryentitytypecode")))))
                            });
                        })
                        {
                            AsyncArgument = results,
                            PostWorkCallBack = evt2 =>
                            {
                                if (evt2.Error != null)
                                {
                                    MessageBox.Show(ParentForm, evt2.Error.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show(ParentForm, "FormXml(s) imported!", "Information",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lvEntities_SelectedIndexChanged(null, null);
                                }
                            },
                            ProgressChanged = evt2 =>
                            {
                                SetWorkingMessage(evt2.UserState.ToString());
                            }
                        });
                    }
                }
            });
        }

        private void importFormXmlsFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "XML file|*.xml", InitialDirectory = currentFolder })
            {
                if (ofd.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    ExecuteMethod(ProcessFiles, new List<string> { ofd.FileName });
                }
            }
        }

        private void importFormXmlsFromFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cfbDialog = new CustomFolderBrowserDialog(true) { FolderPath = currentFolder };
            if (cfbDialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                currentFolder = cfbDialog.FolderPath;
                ExecuteMethod(ProcessFiles, new DirectoryInfo(currentFolder).GetFiles("*.xml").Select(f => f.FullName).ToList());
            }
        }

        private void ListViewColumnClick(object sender, ColumnClickEventArgs e)
        {
            var listView = (ListView)sender;

            listView.Sorting = listView.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            listView.ListViewItemSorter = new ListViewItemComparer(e.Column, listView.Sorting);
        }

        private void OnSearchKeyUp(object sender, KeyEventArgs e)
        {
            var entityName = txtSearchEntity.Text;
            if (string.IsNullOrWhiteSpace(entityName))
            {
                lvEntities.BeginUpdate();
                lvEntities.Items.Clear();
                lvEntities.Items.AddRange(listViewItemsCache);
                lvEntities.EndUpdate();
            }
            else
            {
                lvEntities.BeginUpdate();
                lvEntities.Items.Clear();
                var filteredItems = listViewItemsCache
                    .Where(item => item.Text.StartsWith(entityName, StringComparison.OrdinalIgnoreCase))
                    .ToArray();
                lvEntities.Items.AddRange(filteredItems);
                lvEntities.EndUpdate();
            }
        }

        private void TsbCloseThisTabClick(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbEditFormXml_Click(object sender, EventArgs e)
        {
            if (lvFormXmls.SelectedItems.Count == 0)
                return;

            var editor = new FormXmlEditor((Entity)lvFormXmls.SelectedItems[0].Tag, Service);
            editor.ShowDialog(ParentForm);

            if (editor.HasUpdatedContent)
            {
                lvEntities_SelectedIndexChanged(null, null);
            }
        }

        private void tsbExportFormXmls_Click(object sender, EventArgs e)
        {
            var formXmlsToExport = lvFormXmls.CheckedItems.Cast<ListViewItem>().Select(c => (Entity)c.Tag).ToList();

            if (formXmlsToExport.Count > 0)
            {
                try
                {
                    var cfbDialog = new CustomFolderBrowserDialog(false) { FolderPath = currentFolder };
                    if (cfbDialog.ShowDialog(ParentForm) == DialogResult.OK)
                    {
                        currentFolder = cfbDialog.FolderPath;

                        foreach (var formXml in formXmlsToExport)
                        {
                            var doc = new XDocument(
                                new XElement("visualization",
                                    new XElement("visualizationid", formXml.Id.ToString("B")),
                                    new XElement("name", formXml.GetAttributeValue<string>("name")),
                                    new XElement("description", formXml.GetAttributeValue<string>("description")),
                                    new XElement("primaryentitytypecode", formXml.GetAttributeValue<string>("primaryentitytypecode")),
                                    new XElement("datadescription", XElement.Parse(formXml.GetAttributeValue<string>("datadescription"))),
                                    new XElement("presentationdescription", XElement.Parse(formXml.GetAttributeValue<string>("presentationdescription"))),
                                    new XElement("isdefault", formXml.GetAttributeValue<bool>("isdefault"))
                                    ));

                            var filename = string.Format("{0}{1}.xml",
                                formXml.GetAttributeValue<string>("name"),
                                formXml.LogicalName == "savedqueryvisualization" ? "" : "_personal");

                            doc.Save(Path.Combine(cfbDialog.FolderPath, filename));
                        }

                        if (MessageBox.Show(ParentForm, "Would you like to open destination folder?", "Question",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(cfbDialog.FolderPath);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(ParentForm, error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvFormXmls_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLoadDashboard_Click(object sender, EventArgs e)
        {

            ExecuteMethod(LoadDashboards);
        }

        private void toolStripButtonOpenCRMEditor_Click(object sender, EventArgs e)
        {

            if (lvFormXmls.SelectedItems.Count == 0)
                return;

            var entity = (Entity)lvFormXmls.SelectedItems[0].Tag;
            string entityName = entity.GetAttributeValue<string>("objecttypecode");
            string url = "";
            if (entityName != "none")
            {
                url = string.Format("{0}main.aspx?etn={1}&extraqs=formtype={2}&formId={3}&pagetype=formeditor", ConnectionDetail.WebApplicationUrl, entityName, "main", entity.Id);
            }
            else
            {
                url = string.Format("{0}main.aspx?extraqs=%26formId%3d%7b{1}%7d%26dashboardType%3d1030&pagetype=dashboardeditor", ConnectionDetail.WebApplicationUrl, entity.Id);

            }
                ProcessStartInfo sInfo = new ProcessStartInfo(url);
                Process.Start(sInfo);
            //https://itlec.crm4.dynamics.com/
        }
    }
}