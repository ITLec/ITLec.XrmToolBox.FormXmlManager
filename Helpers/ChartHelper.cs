using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ITLec.FormXmlManager.Helpers
{
    public class FormXmlDefinition
    {
        public Entity Entity { get; set; }
        public List<string> Errors { get; set; }
        public bool Exists { get; set; }
        public string FileName { get; set; }
        public bool IsValid { get; set; }
        public string Name { get; set; }
        public bool Overwrite { get; set; }
    }

    internal class FormXmlHelper
    {
        public static List<FormXmlDefinition> AnalyzeFiles(List<string> filenames, IOrganizationService service)
        {
            var list = new List<FormXmlDefinition>();

            foreach (var fileName in filenames)
            {
                var fi = new FileInfo(fileName);
                var name = fi.Name.Replace(fi.Extension, "");
                var systemFormXml = !name.EndsWith("_personal");

                var doc = XDocument.Load(fileName);

                var cd = new FormXmlDefinition
                {
                    FileName = fileName,
                    Name = new FileInfo(fileName).Name,
                    IsValid = doc.Element("visualization") != null,
                    Errors = new List<string>()
                };

                if (!cd.IsValid)
                {
                    cd.Errors.Add("Not a formXml definition");
                    list.Add(cd);
                    continue;
                }

                var formXml = new Entity(systemFormXml ? "savedqueryvisualization" : "userqueryvisualization");

                var idElement = doc.Descendants("visualizationid").FirstOrDefault();
                if (idElement != null)
                {
                    formXml.Id = new Guid(idElement.Value);
                }

                var nameElement = doc.Descendants("name").FirstOrDefault();
                if (nameElement == null)
                {
                    cd.Errors.Add("Missing 'name' node");
                }
                else
                {
                    formXml["name"] = nameElement.Value;
                }

                var descriptionElement = doc.Descendants("description").FirstOrDefault();
                if (descriptionElement == null)
                {
                    cd.Errors.Add("Missing 'description' node");
                }
                else
                {
                    formXml["description"] = descriptionElement.Value;
                }

                var primaryentitytypecodeElement = doc.Descendants("primaryentitytypecode").FirstOrDefault();
                if (primaryentitytypecodeElement == null)
                {
                    cd.Errors.Add("Missing 'primaryentitytypecode' node");
                }
                else
                {
                    formXml["primaryentitytypecode"] = primaryentitytypecodeElement.Value;
                }

                var datadescriptionElement = doc.Descendants("datadescription").FirstOrDefault();
                if (datadescriptionElement == null)
                {
                    cd.Errors.Add("Missing 'datadescription' node");
                }
                else
                {
                    formXml["datadescription"] = datadescriptionElement.FirstNode.ToString();
                }

                var presentationdescriptionElement = doc.Descendants("presentationdescription").FirstOrDefault();
                if (presentationdescriptionElement == null)
                {
                    cd.Errors.Add("Missing 'presentationdescription' node");
                }
                else
                {
                    formXml["presentationdescription"] = presentationdescriptionElement.FirstNode.ToString();
                }

                var isdefaultElement = doc.Descendants("isdefault").FirstOrDefault();
                if (isdefaultElement == null)
                {
                    cd.Errors.Add("Missing 'isdefault' node");
                }
                else
                {
                    formXml["isdefault"] = isdefaultElement.Value.ToLower() == "true";
                }

                cd.Entity = formXml;

                if (formXml.Id != Guid.Empty)
                {
                    cd.Exists = service.RetrieveMultiple(new QueryExpression("savedqueryvisualization")
                    {
                        Criteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("savedqueryvisualizationid", ConditionOperator.Equal, formXml.Id)
                            }
                        }
                    }).Entities.Count > 0;
                }

                list.Add(cd);
            }

            return list;
        }

        public static EntityCollection GetFormXmlsByEntity(string entityLogicalName, IOrganizationService service)
        {
            var savedqueries = service.RetrieveMultiple(new QueryExpression("systemform")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("objecttypecode", ConditionOperator.Equal, entityLogicalName)
                    }
                }
            });

            /* var userqueries = service.RetrieveMultiple(new QueryExpression("userqueryvisualization")
             {
                 ColumnSet = new ColumnSet(true),
                 Criteria = new FilterExpression
                 {
                     Conditions =
                     {
                         new ConditionExpression("primaryentitytypecode", ConditionOperator.Equal, entityLogicalName)
                     }
                 }
             });

             savedqueries.Entities.AddRange(userqueries.Entities.ToArray());*/
            return savedqueries;
        }

        public static void ImportFiles(List<FormXmlDefinition> formXmls, IOrganizationService service)
        {
            foreach (var formXml in formXmls)
            {
                if (formXml.Exists)
                {
                    if (!formXml.Overwrite)
                    {
                        formXml.Entity["name"] = string.Format("{0}_{1}", formXml.Entity.GetAttributeValue<string>("name"), DateTime.Now.ToShortTimeString());
                        formXml.Entity.Attributes.Remove("savedqueryvisualizationid");
                        formXml.Entity.Attributes.Remove("userqueryvisualizationid");
                        formXml.Entity.Id = Guid.Empty;

                        service.Create(formXml.Entity);
                    }
                    else
                    {
                        service.Update(formXml.Entity);
                    }
                }
                else
                {
                    service.Create(formXml.Entity);
                }
            }
        }
    }
}