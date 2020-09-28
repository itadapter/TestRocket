using System.Collections.Generic;

namespace DecoratorLogic.Models.Base
{
  public class BaseSelection
  {
    /// <summary>
    /// The identifier indicating the selected value.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The display name for the selection.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The ascending sort value.
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    /// An abbreviated or short code for the selection.
    /// </summary>
    public string ShortCode { get; set; }

    /// <summary>
    /// A description of the selection.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Bool value indicating if the selection can be modified.
    /// Used for locking selections.
    /// </summary>
    public bool PreventChanges { get; set; }

    /// <summary>
    /// Indicates if this is the default selection value
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// Indicates if this value is available for selection
    /// on new or updates of records.
    /// </summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Optional collection of allowed next id values.
    /// </summary>
    /// <remarks>
    /// If none are supplied then any Id should be accepted.
    /// </remarks>
    public HashSet<int> AllowedNextValues { get; set; }
  }

  public class DecimalSelection: BaseSelection
  {
    /// <summary>
    /// The decimal value of a selection option
    /// </summary>
    public decimal? Value { get; set; }
  }

  public class SkuChargeSelection : DecimalSelection
  {
    /// <summary>
    /// The decimal value of a selection option
    /// </summary>
    public string Sku { get; set; }
  }

}
