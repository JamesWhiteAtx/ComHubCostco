using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComHub
{
    public partial class FAMessageBatch : MessageBatch
    {
        private List<FAMessageBatchHubFA> hubFAList;

        public FAMessageBatch()
        {
            hubFAList = new List<FAMessageBatchHubFA>();
            xsdFile = "FA.xsd";
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string Merchant { get; set; }

        public void CostcoSetup()
        {
            Merchant = "Costco";
            partnerID = System.Configuration.ConfigurationManager.AppSettings["partnerID" + Merchant];
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string FileName { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public List<FAMessageBatchHubFA> HubFAList { get { return hubFAList; } set { hubFAList = value; } }

        public FAMessageBatchHubFA AddHubFA()
        {
            FAMessageBatchHubFA newHubFA = new FAMessageBatchHubFA(this);
            return AddHubFA(newHubFA);
        }

        public FAMessageBatchHubFA AddHubFA(FAMessageBatchHubFA newHubFA)
        {
            hubFAList.Add(newHubFA);

            hubFA = hubFAList.ToArray();
            messageCount = hubFA.Length.ToString();

            return newHubFA;
        }

        public static FAMessageBatch Deserialize(string path)
        {
            return MessageBatch.Deserialize<FAMessageBatch>(path);
        }
    }

    public partial class FAMessageBatchHubFA
    {
        protected FAMessageBatch faMessageBatch;

        public FAMessageBatchHubFA()
        {
        }

        public FAMessageBatchHubFA(FAMessageBatch faMsgBatch)
            : this()
        {
            faMessageBatch = faMsgBatch;
        }

    }
}
