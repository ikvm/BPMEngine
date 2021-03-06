﻿using Org.Reddragonit.BpmEngine.Attributes;
using Org.Reddragonit.BpmEngine.Elements.Collaborations;
using Org.Reddragonit.BpmEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Org.Reddragonit.BpmEngine.Elements.Processes
{
    [RequiredAttribute("id")]
    internal abstract class AParentFlowNode : AParentElement
    {
        public string name { get { return _GetAttributeValue("name"); } }

        public string[] Incoming
        {
            get
            {
                List<string> ret = new List<string>();
                foreach (XmlNode n in SubNodes)
                {
                    if (n.NodeType == XmlNodeType.Element)
                    {
                        if (n.Name == "bpmn:incoming")
                            ret.Add(n.InnerText);
                    }
                }
                foreach (MessageFlow msgFlow in Definition.MessageFlows)
                {
                    if (msgFlow.targetRef == this.id)
                        ret.Add(msgFlow.id);
                }
                return (ret.Count == 0 ? null : ret.ToArray());
            }
        }

        public string[] Outgoing
        {
            get
            {
                List<string> ret = new List<string>();
                foreach (XmlNode n in SubNodes)
                {
                    if (n.NodeType == XmlNodeType.Element)
                    {
                        if (n.Name == "bpmn:outgoing")
                            ret.Add(n.InnerText);
                    }
                }
                foreach (MessageFlow msgFlow in Definition.MessageFlows)
                {
                    if (msgFlow.sourceRef == this.id)
                        ret.Add(msgFlow.id);
                }
                return (ret.Count == 0 ? null : ret.ToArray());
            }
        }

        public AParentFlowNode(XmlElement elem, XmlPrefixMap map, AElement parent)
            : base(elem, map, parent)
        {
        }
    }
}
