﻿using Org.Reddragonit.BpmEngine.Attributes;
using Org.Reddragonit.BpmEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Org.Reddragonit.BpmEngine.Elements.Processes
{
    [XMLTag("bpmn","lane")]
    [RequiredAttribute("id")]
    internal class Lane : AElement
    {
        public string[] Nodes
        {
            get
            {
                List<string> ret = new List<string>();
                foreach (XmlNode n in SubNodes)
                {
                    if (n.NodeType == XmlNodeType.Element)
                    {
                        if (n.Name == "bpmn:flowNodeRef")
                            ret.Add(n.InnerText);
                    }
                }
                return ret.ToArray();
            }
        }

        public string name { get { return _GetAttributeValue("name"); } }

        public Lane(XmlElement elem, XmlPrefixMap map, AElement parent)
            : base(elem, map,parent) { }
    }
}
