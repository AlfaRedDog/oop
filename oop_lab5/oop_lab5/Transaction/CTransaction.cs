using System;
using System.Collections.Generic;
using System.Text;
using oop_lab5.Client;
namespace oop_lab5.Transaction
{
    class CTransaction
    {
        protected double Money { get; }
        protected ClientC recipient { get; }
        protected ClientC sender { get; }
        protected Guid recepientID {get;}
        protected Guid senderID { get; }
        public CTransaction(double money, ClientC rec, ClientC send, Guid id1, Guid id2)
        {
            Money = money;
            recipient = rec;
            sender = send;
            recepientID = id1;
            senderID = id2;
        }
        public double TakeMoney()
        {
            return Money;
        }
        public ClientC TakeRecepient()
        {
            return recipient;
        }
        public ClientC TakeSender()
        {
            return sender;
        }
        public Guid TakeRecepientId()
        {
            return recepientID;
        }
        public Guid TakeSendertId()
        {
            return senderID;
        }
    }
}
