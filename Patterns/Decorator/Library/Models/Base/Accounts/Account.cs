using System;

namespace DecoratorLogic.Models.Base
{
  /// <summary>
  /// An container for attaching products and services to that is owned by
  /// and Owner Entity and is optionally assigned to an AR billing group account
  /// </summary>
  /// <remarks>
  /// Attempt to provide model compatibility with https://www.logisense.com/learn/api/v1/Account/
  /// </remarks>
  public class Account : BaseItem
  {
    /// <summary>
    /// The default currency identifier
    /// </summary>
    public int? CurrencyId { get; set; }

    /// <summary>
    /// The name of the entity
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The display name of the entity
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// UTC DateTime when the account was created
    /// </summary>
    public DateTime? CreatedUtc { get; set; }

    /// <summary>
    /// The selected identifier indicating a state of an account
    /// </summary>
    public int? AccountStatusId { get; set; }

    /// <summary>
    /// The identifier of the bill group this account belongs to.
    /// </summary>
    public int? BillGroupId { get; set; }

    /// <summary>
    /// The acting owner identifier
    /// </summary>
    public int? ActingOwnerId { get; set; }

    /// <summary>
    /// UTC DateTime when the account is cancelled
    /// </summary>
    public DateTime? CancelUtc { get; set; }

    /// <summary>
    /// The invoice delivery mapping identifier
    /// </summary>
    public int? InvoiceDeliveryId { get; set; }

    /// <summary>
    /// The selected AR terms type identifier
    /// </summary>
    public int? TermsTypeId { get; set; }

    /// <summary>
    /// The selected account type identifier
    /// </summary>
    public int? AccountTypeId { get; set; }

    /// <summary>
    /// The selected auto pay type identifier
    /// </summary>
    public int? AutoPayTypeId { get; set; }

    /// <summary>
    /// Indicates if auto pay is enabled on the account
    /// </summary>
    public bool? IsAutoPayEnabled { get; set; }

    /// <summary>
    /// The auto pay day of billing cycle
    /// </summary>
    public int? AutoPayDay { get; set; }

    /// <summary>
    /// The billing invoice day of billing cycle
    /// </summary>
    public int? BillDay { get; set; }

    /// <summary>
    /// The selected account tax category type identifier
    /// </summary>
    public int? AccountTaxCategoryId { get; set; }

    /// <summary>
    /// The acting invoicer account identifier
    /// </summary>
    public int? InvoicerAccountId { get; set; }
  }
}
