using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorLogic.Models.Base
{
  public class InvoiceDelivery : BaseItem
  {
    /// <summary>
    /// The display name for the delivery method.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The template associated with the invoice generation.
    /// </summary>
    public int TemplateId { get; set; }

    /// <summary>
    /// The email template associated with the invoice generation.
    /// </summary>
    public int EmailTemplateId { get; set; }

    /// <summary>
    /// The delivery type selection identifier.
    /// </summary>
    public int InvoiceDeliveryTypeId { get; set; }
  }
}
