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
            Merchant = MessageBatch.Costco;
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
        protected List<FAMessageBatchHubFAMessageAck> messageAckList;

        public FAMessageBatchHubFA()
        {
            messageBatchLink = new FAMessageBatchHubFAMessageBatchLink();
            messageBatchDisposition = new FAMessageBatchHubFAMessageBatchDisposition();
            
            messageAckList = new List<FAMessageBatchHubFAMessageAck>();
            AssignMessageAcks();
        }

        public FAMessageBatchHubFA(FAMessageBatch faMsgBatch)
            : this()
        {
            faMessageBatch = faMsgBatch;
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public List<FAMessageBatchHubFAMessageAck> MessageAckList { get { return messageAckList; } }        

        public void AssignMessageAcks()
        {
            messageAckField = messageAckList.ToArray();
            int acks = messageAckField.Length;
            int acpts = messageAckField.Count(ack => ack.messageDisposition.status == FAMessageBatchHubFAMessageAckMessageDispositionStatus.A);

            messageBatchDisposition.trxReceivedCount = acks.ToString();
            messageBatchDisposition.trxAcceptedCount = acpts.ToString();
        }

        public FAMessageBatchHubFAMessageAck AddMessageAck()
        {
            FAMessageBatchHubFAMessageAck newAck = new FAMessageBatchHubFAMessageAck();
            return AddMessageAck(newAck);
        }

        public FAMessageBatchHubFAMessageAck AddMessageAck(FAMessageBatchHubFAMessageAck newAck)
        {
            messageAckList.Add(newAck);
            AssignMessageAcks();
            return newAck;
        }
    }

    public partial class FAMessageBatchHubFAMessageBatchDisposition
    {
        public FAMessageBatchHubFAMessageBatchDisposition()
        {

        }
    }
}
