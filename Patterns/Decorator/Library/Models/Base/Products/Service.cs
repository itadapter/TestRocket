using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorLogic.Models.Base
{
  public class Service : BaseItem
  {
    /// <summary>
    /// The service identifier
    /// </summary>
    public int? ServiceId { get; set; }

    ///// <summary>
    ///// The parent account identifier
    ///// </summary>
    //public int? AccountId { get; set; }

    /// <summary>
    /// UTC DateTime when the package was created
    /// </summary>
    public DateTime? CreatedUtc { get; set; }

    /// <summary>
    /// The active package identifier
    /// </summary>
    public int? AccountPackageId { get; set; }

    /// <summary>
    /// The name of the entity
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The billing day of usage billing
    /// </summary>
    public int? UsageBillDay { get; set; }

    /// <summary>
    /// The accrued billed amount excluding one time charges
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// The total one time charges
    /// </summary>
    public decimal? OneTimeAmount { get; set; }

    /// <summary>
    /// UTC DateTime when the amounts were updated
    /// </summary>
    public DateTime? UpdatedUtc { get; set; }

    /// <summary>
    /// UTC DateTime when the service is effective
    /// </summary>
    public DateTime? EffectiveUtc { get; set; }

    /// <summary>
    /// UTC DateTime when the service was last posted
    /// </summary>
    public DateTime? PostedUtc { get; set; }

    /// <summary>
    /// UTC DateTime when the package is cancelled
    /// </summary>
    public DateTime? CancelUtc { get; set; }

    /// <summary>
    /// UTC DateTime of the scheduled final bill
    /// </summary>
    public DateTime? UsageNextBillUtc { get; set; }

    /// <summary>
    /// UTC DateTime of the scheduled final bill
    /// </summary>
    public DateTime? UsageFinalBillUtc { get; set; }

    /// <summary>
    /// UTC DateTime of the scheduled final bill
    /// </summary>
    public DateTime? FinalBillUtc { get; set; }

    /// <summary>
    /// UTC DateTime of the scheduled final bill
    /// </summary>
    public DateTime? LastBilledUtc { get; set; }

    /// <summary>
    /// UTC DateTime of the scheduled final bill
    /// </summary>
    public DateTime? LastUsageBilledUtc { get; set; }
  }
}
