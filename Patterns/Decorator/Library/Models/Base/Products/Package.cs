using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorLogic.Models.Base
{
  public class Package : BaseItem
  {
    /// <summary>
    /// The parent account identifier
    /// </summary>
    public int? AccountId { get; set; }

    /// <summary>
    /// UTC DateTime when the package was created
    /// </summary>
    public DateTime? CreatedUtc { get; set; }

    /// <summary>
    /// UTC DateTime when the package should be billed
    /// </summary>
    public DateTime? NextBillUtc { get; set; }

    /// <summary>
    /// The name of the entity
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A collection of one time charge identifiers to apply
    /// </summary>
    public int[] OneTimeChargeIds { get; set; }

    /// <summary>
    /// UTC DateTime when the package is effective
    /// </summary>
    public DateTime? EffectiveUtc { get; set; }

    /// <summary>
    /// UTC DateTime when the package is cancelled
    /// </summary>
    public DateTime? CancelUtc { get; set; }

    /// <summary>
    /// The package frequency identifier
    /// </summary>
    public int? FrequencyTypeId { get; set; }

    /// <summary>
    /// The package frequency SKU
    /// </summary>
    public string FrequencySku { get; set; }

    /// <summary>
    /// The package frequency value
    /// </summary>
    public int? Frequency { get; set; }

    /// <summary>
    /// The package count remaining unbilled
    /// </summary>
    public int? CountRemaining { get; set; }

    /// <summary>
    /// Indicates if package is enabled on the account
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// Indicates if the remainder of the charges are applicable upon cancellation
    /// </summary>
    public bool? ChargeRemainder { get; set; }

    /// <summary>
    /// The service identifier used on early cancellation
    /// </summary>
    public int? PenaltyServiceId { get; set; }

    /// <summary>
    /// The billing invoice day of billing cycle
    /// </summary>
    public int? BillDay { get; set; }

    /// <summary>
    /// The billing day of usage billing
    /// </summary>
    public int? UsageBillDay { get; set; }

    /// <summary>
    /// UTC DateTime when the package is activated
    /// </summary>
    public DateTime? ActivationUtc { get; set; }

    /// <summary>
    /// UTC DateTime of the scheduled final bill
    /// </summary>
    public DateTime? FinalBillUtc { get; set; }

    /// <summary>
    /// UTC DateTime of the last bill date
    /// </summary>
    public DateTime? LastBilledUtc { get; set; }

    /// <summary>
    /// UTC DateTime of the last bill date
    /// </summary>
    public DateTime? LastUsageBilledUtc { get; set; }

    /// <summary>
    /// The account product identifier
    /// </summary>
    public int? AccountProductCodeId { get; set; }

    /// <summary>
    /// The package category identifier
    /// </summary>
    public int? PackageCategoryId { get; set; }


  }
}
