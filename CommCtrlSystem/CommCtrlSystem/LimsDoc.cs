using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace CommCtrlSystem
{
    class LimsDocHeader
    {
        XmlElement xe_header;
        public LimsDocHeader(XmlDocument xmldoc, string user, string pass)
        {
            xe_header = xmldoc.CreateElement("header");//创建一个<Node>节点 
            XmlElement xe_header_paramuser = xmldoc.CreateElement("parameter");
            xe_header_paramuser.SetAttribute("name", "USER");
            xe_header_paramuser.InnerText = user;
            XmlElement xe_header_parampass = xmldoc.CreateElement("parameter");
            xe_header_parampass.SetAttribute("name", "PASSWORD");
            xe_header_parampass.InnerText = pass;
            xe_header.AppendChild(xe_header_paramuser);
            xe_header.AppendChild(xe_header_parampass);
        }

        public XmlElement getElement()
        {
            return xe_header;
        }
    }

    class LimsDocBody
    {
        XmlElement xe_body;
        XmlElement xe_transation;
        XmlElement xe_system;
        public LimsDocBody(XmlDocument xmldoc, string response_type)
        {
            xe_body = xmldoc.CreateElement("body");//创建一个<Node>节点 
            xe_transation = xmldoc.CreateElement("transaction");//创建一个<Node>节点 
            xe_system = xmldoc.CreateElement("system");//创建一个<Node>节点 
            xe_system.SetAttribute("response_type", "system");
            xe_transation.AppendChild(xe_system);
            xe_body.AppendChild(xe_transation);
        }

        public void addEntity(XmlElement entity)
        {
            xe_system.AppendChild(entity);
        }

        public XmlElement getElement()
        {
            return xe_body;
        }
    }

    class LimsDocEntity
    {
        XmlElement xe_entity;
        XmlElement xe_actions;

        XmlElement xe_action;
        XmlElement xe_command;
        XmlElement xe_fields;
        
        XmlElement xe_children;
        XmlDocument xmldoc;
        public LimsDocEntity(XmlDocument xmldoc, string type, string command)
        {
            xe_entity = xmldoc.CreateElement("entity");
            xe_entity.SetAttribute("type", type);
            xe_actions = xmldoc.CreateElement("actions");
            this.xmldoc = xmldoc;
            if (command != null)
            {
                xe_action = xmldoc.CreateElement("action");
                xe_command = xmldoc.CreateElement("command");
                xe_command.InnerText = command;
                xe_action.AppendChild(xe_command);
                xe_actions.AppendChild(xe_action);
            }
           
            xe_fields = xmldoc.CreateElement("fields");
            xe_children = xmldoc.CreateElement("children");

            xe_entity.AppendChild(xe_actions);
            xe_entity.AppendChild(xe_fields);
            xe_entity.AppendChild(xe_children);
        }

        public void addFields(string fieldid, string field_dir, string field_text)
        {
            XmlElement xe_field = xmldoc.CreateElement("field"); ;
            xe_field.SetAttribute("id", fieldid);
            xe_field.SetAttribute("direction", field_dir);
            xe_field.InnerText = field_text;
            xe_fields.AppendChild(xe_field);
        }

        public void addChild(XmlElement child)
        {
            xe_children.AppendChild(child);
        }

        public XmlElement getElement()
        {
            return xe_entity;
        }
    }

    class LimsDoc
    {
        XmlElement xmlelem = null;
        XmlDocument xmldoc = new XmlDocument();
        XmlDeclaration xmldecl;
        LimsDocHeader header;
        LimsDocBody body;

        public LimsDoc(string user, string password, string response_type)
        {
            xmldoc = new XmlDocument();
            xmldecl = xmldoc.CreateXmlDeclaration("1.0", null, null);
            xmldoc.AppendChild(xmldecl);
            xmlelem = xmldoc.CreateElement("", "limsml", "");
            xmlelem.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            xmlelem.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlelem.SetAttribute("xmlns", "http://www.thermo.com/informatics/xmlns/limsml/1.0");
            xmldoc.AppendChild(xmlelem);
            header = new LimsDocHeader(xmldoc, user, password);
            body = new LimsDocBody(xmldoc, response_type);
        }

        public LimsDocEntity createEntity(string type, string command)
        {
            LimsDocEntity entity = new LimsDocEntity(xmldoc, type, command);
            return entity;
        }

        public LimsDocBody getBody()
        {
            return body;
        }

        public bool createdoc(string docpath)
        {
            XmlNode root = xmldoc.SelectSingleNode("limsml");
            root.AppendChild(header.getElement());//添加到<Employees>节点中 
            root.AppendChild(body.getElement());//添加到<Employees>节点中 
            xmldoc.Save(docpath);
            return true;
        }
  
    }
}
