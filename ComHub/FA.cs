﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.33440.
// 
namespace ComHub {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class FAMessageBatch {
        
        private string partnerIDField;
        
        private FAMessageBatchHubFA[] hubFAField;
        
        private string messageCountField;
        
        private string typeField;
        
        private string batchNumberField;
        
        /// <remarks/>
        public string partnerID {
            get {
                return this.partnerIDField;
            }
            set {
                this.partnerIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("hubFA")]
        public FAMessageBatchHubFA[] hubFA {
            get {
                return this.hubFAField;
            }
            set {
                this.hubFAField = value;
            }
        }
        
        /// <remarks/>
        public string messageCount {
            get {
                return this.messageCountField;
            }
            set {
                this.messageCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string batchNumber {
            get {
                return this.batchNumberField;
            }
            set {
                this.batchNumberField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class FAMessageBatchHubFA {
        
        private FAMessageBatchHubFAMessageBatchLink messageBatchLinkField;
        
        private FAMessageBatchHubFAMessageAck[] messageAckField;
        
        private FAMessageBatchHubFAMessageBatchDisposition messageBatchDispositionField;
        
        /// <remarks/>
        public FAMessageBatchHubFAMessageBatchLink messageBatchLink {
            get {
                return this.messageBatchLinkField;
            }
            set {
                this.messageBatchLinkField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("messageAck")]
        public FAMessageBatchHubFAMessageAck[] messageAck {
            get {
                return this.messageAckField;
            }
            set {
                this.messageAckField = value;
            }
        }
        
        /// <remarks/>
        public FAMessageBatchHubFAMessageBatchDisposition messageBatchDisposition {
            get {
                return this.messageBatchDispositionField;
            }
            set {
                this.messageBatchDispositionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class FAMessageBatchHubFAMessageBatchLink {
        
        private string trxSetIDField;
        
        /// <remarks/>
        public string trxSetID {
            get {
                return this.trxSetIDField;
            }
            set {
                this.trxSetIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class FAMessageBatchHubFAMessageAck {
        
        private string trxIDField;
        
        private FAMessageBatchHubFAMessageAckDetailException[] detailExceptionField;
        
        private FAMessageBatchHubFAMessageAckMessageDisposition messageDispositionField;
        
        private FAMessageBatchHubFAMessageAckType typeField;
        
        /// <remarks/>
        public string trxID {
            get {
                return this.trxIDField;
            }
            set {
                this.trxIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("detailException")]
        public FAMessageBatchHubFAMessageAckDetailException[] detailException {
            get {
                return this.detailExceptionField;
            }
            set {
                this.detailExceptionField = value;
            }
        }
        
        /// <remarks/>
        public FAMessageBatchHubFAMessageAckMessageDisposition messageDisposition {
            get {
                return this.messageDispositionField;
            }
            set {
                this.messageDispositionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public FAMessageBatchHubFAMessageAckType type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class FAMessageBatchHubFAMessageAckDetailException {
        
        private string detailIDField;
        
        private string[] exceptionDescField;
        
        /// <remarks/>
        public string detailID {
            get {
                return this.detailIDField;
            }
            set {
                this.detailIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("exceptionDesc")]
        public string[] exceptionDesc {
            get {
                return this.exceptionDescField;
            }
            set {
                this.exceptionDescField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class FAMessageBatchHubFAMessageAckMessageDisposition {
        
        private FAMessageBatchHubFAMessageAckMessageDispositionStatus statusField;
        
        private bool statusFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public FAMessageBatchHubFAMessageAckMessageDispositionStatus status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool statusSpecified {
            get {
                return this.statusFieldSpecified;
            }
            set {
                this.statusFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum FAMessageBatchHubFAMessageAckMessageDispositionStatus {
        
        /// <remarks/>
        R,
        
        /// <remarks/>
        A,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum FAMessageBatchHubFAMessageAckType {
        
        /// <remarks/>
        msg,
        
        /// <remarks/>
        order,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class FAMessageBatchHubFAMessageBatchDisposition {
        
        private string trxReceivedCountField;
        
        private string trxAcceptedCountField;
        
        private string[] exceptionDescField;
        
        private FAMessageBatchHubFAMessageBatchDispositionStatus statusField;
        
        private bool statusFieldSpecified;
        
        /// <remarks/>
        public string trxReceivedCount {
            get {
                return this.trxReceivedCountField;
            }
            set {
                this.trxReceivedCountField = value;
            }
        }
        
        /// <remarks/>
        public string trxAcceptedCount {
            get {
                return this.trxAcceptedCountField;
            }
            set {
                this.trxAcceptedCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("exceptionDesc")]
        public string[] exceptionDesc {
            get {
                return this.exceptionDescField;
            }
            set {
                this.exceptionDescField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public FAMessageBatchHubFAMessageBatchDispositionStatus status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool statusSpecified {
            get {
                return this.statusFieldSpecified;
            }
            set {
                this.statusFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum FAMessageBatchHubFAMessageBatchDispositionStatus {
        
        /// <remarks/>
        P,
        
        /// <remarks/>
        R,
        
        /// <remarks/>
        A,
    }
}