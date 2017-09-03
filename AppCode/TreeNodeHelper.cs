using ITLec.FormXmlManager.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ITLec.CRMFormXmlGuy.AppCode
{

    internal class TreeNodeHelper
    {
        #region Methods

        /// <summary>
        /// Adds a context menu to a TreeNode control
        /// </summary>
        /// <param name="node">TreeNode where to add the context menu</param>
        /// <param name="form">Current application form</param>
        public static void AddContextMenu(TreeNode node, FormXmlEditorHelper form)
        {
            var collec = (Dictionary<string, ITLec.CRMFormXmlGuy.Property>)node.Tag;

            HideAllContextMenuItems(form.nodeMenu);
            string nodeFullName = TreeNodeHelper.FullNodeName(node);
            ///////////////////////////
           var currentSection = Common.FormXmlStructure.Sections.Where(e => e.Name == nodeFullName).FirstOrDefault();

            if (currentSection != null)
            {
                var subSections = currentSection.SubSections;
                foreach (var subSection in subSections)
                {
                    // node.
                    XmlNode formXmlEditorXmlNode = form.siteMapDoc.DocumentElement;
                    bool existedSubSection = true;
                    //Add Annotation
                    foreach (XmlNode _node in formXmlEditorXmlNode.ChildNodes)
                    {
                        if (_node.Name.ToLower() == subSection.Name)
                        {
                            existedSubSection = false;
                            break;
                        }
                    }
                    if (existedSubSection)
                    {
                        ToolStripItem tsi = new ToolStripMenuItem(subSection.Name);
                        tsi.Name = subSection.Name;
                        ////  tsi.Click += Tsi_Click;

                        tsi.Click += delegate (object sender, EventArgs e)
                        {
                            subSectionMenuOnClick(sender, e, node);
                        };

                        form.nodeMenu.Items.Add(tsi);
                        //form.nodeMenu.Items.Add(subSection.Name, null, delegate (object sender, EventArgs e)
                        //{
                        //    subSectionMenuOnClick(sender, e, node);
                        //});
                    }

                    /*  if (addAnotationsNode)
                      {

                          XmlNode annotationNode = siteMapDoc.CreateElement("Annotations");
                          XmlNode textAnnotation = siteMapDoc.CreateElement("TextAnnotation");
                          annotationNode.AppendChild(textAnnotation);

                          formXmlEditorXmlNode.AppendChild(annotationNode);
                      }*/
                }

            }
            ////////////////////////////////




            switch (node.Text.Split(' ')[0])
            {


                case "Title":
                case "Description":
                    {
                        form.deleteToolStripMenuItem.Visible = true;
                        form.toolStripSeparatorAction.Visible = true;

                        form.toolStripSeparatorBeginOfEdition.Visible = false;
                        form.cutToolStripMenuItem.Enabled = true;
                        form.copyToolStripMenuItem.Enabled = true;

                        if (node.Parent != null && node.Parent.Nodes.Count == 1)
                            form.deleteToolStripMenuItem.Enabled = false;
                    }
                    break;
            }

            node.ContextMenuStrip = form.nodeMenu;
        }

        private static void subSectionMenuOnClick(object sender, EventArgs eventArgs, TreeNode node)
        {
            var item = (ToolStripItem)sender;


            string[] strs  = item.Name.Split('.');

            string nodeName = strs[strs.Length - 1];

            TreeNode subNode = new TreeNode(nodeName);

            /*subNode.Tag*/ var section = Common.FormXmlStructure.Sections.Where(e => e.Name == item.Name).FirstOrDefault();

            if (section != null)
            {

                var properties = section.Properties;
                Dictionary<string, ITLec.CRMFormXmlGuy.Property> arr = new Dictionary<string, Property>();


                subNode.Tag = arr;
                node.Nodes.Add(subNode);
                /* if (addAnotationsNode)
                 {

                     XmlNode annotationNode = siteMapDoc.CreateElement("Annotations");
                     XmlNode textAnnotation = siteMapDoc.CreateElement("TextAnnotation");
                     annotationNode.AppendChild(textAnnotation);

                     formXmlEditorXmlNode.AppendChild(annotationNode);
                 }*/
            }
        }

        private static void Tsi_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        

        /// <summary>
        /// Adds a new TreeNode to the parent object from the XmlNode information
        /// </summary>
        /// <param name="parentObject">Object (TreeNode or TreeView) where to add a new TreeNode</param>
        /// <param name="xmlNode">Xml node from the sitemap</param>
        /// <param name="form">Current application form</param>
        /// <param name="isDisabled"> </param>
        public static void AddTreeViewNode(object parentObject, XmlNode xmlNode, FormXmlEditorHelper form, bool isDisabled = false)
        {
            TreeNode node = new TreeNode(xmlNode.Name);

            Dictionary<string, ITLec.CRMFormXmlGuy.Property> attributes = new Dictionary<string,  ITLec.CRMFormXmlGuy.Property>();

            if (xmlNode.NodeType != XmlNodeType.Text)
            {
                foreach (XmlAttribute attr in xmlNode.Attributes)
                {
                    if (attr.Name == "CustomProperties")
                    {
                        TreeNode customNode = new TreeNode("CustomProperties");
                        Dictionary <string, ITLec.CRMFormXmlGuy.Property> customAttributes = new Dictionary<string, ITLec.CRMFormXmlGuy.Property>();

                        string[] propertyItems = attr.Value.Replace(" ","").Split(',');

                        foreach (string propertyItem in propertyItems)
                        {
                            if (!string.IsNullOrEmpty(propertyItem))
                            {
                                string[] propertyItemStrs = propertyItem.Split('=');
                                string propertyItemKey = propertyItemStrs[0];
                                string propertyItemValue = propertyItemStrs[1];

                                ITLec.CRMFormXmlGuy.Property pro = new Property() { Value = propertyItemValue, Name = propertyItemKey };

                                customAttributes.Add(propertyItemKey, pro);
                            }
                        }
                        customNode.Tag = customAttributes;
                        node.Nodes.Add(customNode);
                    }
                    else
                    {
                        ITLec.CRMFormXmlGuy.Property pro = new Property() {Value= attr.Value, Name = attr.Name};
                        attributes.Add(attr.Name, pro);
                    }
                    if(attr.Name == "FormXmlType")
                    {
                        FormXmlEditorHelper.FormXmlType = attr.Value;
                    }
                }

                if (xmlNode.Attributes["Id"] != null)
                {
                    node.Text += " (" + xmlNode.Attributes["Id"].Value + ")";
                }
                if (xmlNode.Attributes["LCID"] != null)
                {
                    node.Text += " (" + xmlNode.Attributes["LCID"].Value + ")";
                }
                if (node.Text.ToLower() == "comment")
                {
                    node.Text = string.Format("# - {0}", xmlNode.InnerText);
                }
            }
            else
            {
                node.Text = String.Format("# {0}", xmlNode.InnerText);
            }

            node.Name = node.Text.Replace(" ", "");

         /*   if (isDisabled)
            {
                if (node.Text.StartsWith("#"))
                {
                    node.ToolTipText = "This is a comment in SiteMap";
                }
                else
                {
                    node.ToolTipText =
                        "This node is disabled and won't appear in Microsoft Dynamics CRM 2011. Right click this node and enable it and make it appear on Microsoft Dynamics CRM 2011";
                    node.Text += " - disabled";
                    attributes.Add("_disabled", "true");
                }
                node.ForeColor = Color.Gray;
            }*/

            node.Tag = attributes;

            AddContextMenu(node, form);

            if (parentObject is TreeView)
            {
                ((TreeView)parentObject).Nodes.Add(node);
            }
            else if (parentObject is TreeNode)
            {
                ((TreeNode)parentObject).Nodes.Add(node);
            }
            else
            {
                throw new Exception("AddTreeViewNode: Unsupported control type");
            }

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Comment)
                {
                    var commentDoc = new XmlDocument();

                    try
                    {
                        commentDoc.LoadXml(childNode.InnerText);
                        AddTreeViewNode(node, commentDoc.DocumentElement, form, true);
                    }
                    catch
                    {
                        commentDoc.LoadXml("<comment>" + childNode.InnerText + "</comment>");

                        foreach (XmlNode commentChildNode in commentDoc.DocumentElement.ChildNodes)
                        {
                            AddTreeViewNode(node, commentChildNode, form, true);
                        }
                    }
                }
                else if (childNode.NodeType == XmlNodeType.Element)
                {
                    AddTreeViewNode(node, childNode, form);
                }
                else if (childNode.NodeType == XmlNodeType.Text)
                {
                    var tvChildNode = new TreeNode("#" + childNode.InnerText);
                    node.Nodes.Add(tvChildNode);
                }
            }
        }

        /// <summary>
        /// Hides all items from a context menu
        /// </summary>
        /// <param name="cm">Context menu to clean</param>
        public static void HideAllContextMenuItems(ContextMenuStrip cm)
        {
            foreach (ToolStripItem o in cm.Items)
            {
                if (o.Text == "Cut" || o.Text == "Copy" || o.Text == "Paste")
                {
                    o.Enabled = false;
                }
                else if (o.Name == "toolStripSeparatorBeginOfEdition" || o is ToolStripSeparator)
                {
                    o.Visible = true;
                }
                else
                {
                    o.Visible = false;
                }
            }
        }


        public static string FullNodeName(TreeNode node, string name="")
        {
            
            if(node.Parent ==null)
            {
                return name;
            }
            string nodeName = (string.IsNullOrEmpty(name))? node.Text : node.Text + "." + name;
            return FullNodeName(node.Parent, nodeName);
        }


        static public string GetFormatedXML(string xmlStr)
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlStr);

            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };

            settings.OmitXmlDeclaration = true;
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }
        #endregion Methods
    }
}
