namespace Panda.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Package
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public string ShippingAddress { get; set; }
        public string StatusId { get; set; }

        public PackageStatus Status { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; } = DateTime.UtcNow;
        public string RecipientId { get; set; }
        public PandaUser Recipient { get; set; }
        public string ReceiptId { get; set; }
        public Receipt Receipt { get; set;  }
    }
}