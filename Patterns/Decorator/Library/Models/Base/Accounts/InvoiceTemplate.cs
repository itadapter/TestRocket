using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorLogic.Models.Base.Accounts
{
  public class InvoiceTemplate : BaseItem
  {
    /// <summary>
    /// The display name of the entity
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The display format for Dates
    /// </summary>
    public string DateFormat { get; set; }

    /// <summary>
    /// The display format for DateTimes
    /// </summary>
    public string DateTimeFormat { get; set; }

    /// <summary>
    /// The template description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The template file name
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// UTC DateTime when the template was created
    /// </summary>
    public DateTime? CreatedUtc { get; set; }


  }
}