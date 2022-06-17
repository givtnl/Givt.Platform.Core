﻿using Givt.Domain.Entities.Base;
using Givt.Domain.Interfaces;

namespace Givt.Domain.Entities;

public class PayOut : EntityBase<Int64>, IEntity<Int64>
{
    public DateTime EndDate { get; set; }
    public DateTime ExecutedDate { get; set; }
    public DateTime? PaymentProviderExecutionDate { get; set; }
    public string Currency { get; set; }

    public decimal TransactionCount { get; set; }
    public decimal TransactionCost { get; set; }
    public decimal TransactionTaxes { get; set; }

    public int MandateCostCount { get; set; }
    public decimal MandateCost { get; set; }
    public decimal MandateTaxes { get; set; }

    public decimal RTransactionT1Count { get; set; }
    public decimal RTransactionT1Cost { get; set; }
    public decimal RTransactionT2Count { get; set; }
    public decimal RTransactionT2Cost { get; set; }
    public decimal RTransactionAmount { get; set; }
    public decimal RTransactionTaxes { get; set; }

    public decimal GivtServiceFee { get; set; }
    public decimal GivtServiceFeeTaxes { get; set; }

    public decimal PaymentCost { get; set; }
    public decimal PaymentCostTaxes { get; set; }

    public decimal TotalPaid { get; set; }

    public string PaymentProviderId { get; set; }

    public Int64 CampaignId { get; set; }    
    public Campaign Campaign { get; set; }
 
}