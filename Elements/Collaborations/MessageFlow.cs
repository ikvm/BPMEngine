﻿using Org.Reddragonit.BpmEngine.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Org.Reddragonit.BpmEngine.Elements.Collaborations
{
    [XMLTag("bpmn","messageFlow")]
    [RequiredAttribute("sourceRef")]
    [RequiredAttribute("targetRef")]
    [RequiredAttribute("id")]
    internal class MessageFlow : AElement
    {
        public string sourceRef { get { return _GetAttributeValue("sourceRef"); } }
        public string targetRef { get { return _GetAttributeValue("targetRef"); } }

        public MessageFlow(XmlElement elem, XmlPrefixMap map,AElement parent)
            : base(elem, map,parent) { }
    }
}
