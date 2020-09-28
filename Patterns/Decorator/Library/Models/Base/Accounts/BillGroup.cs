namespace DecoratorLogic.Models.Base
{
  public class BillGroup : BaseItem
  {
    /// <summary>
    /// The name of the entity
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The billing invoice day of billing cycle
    /// </summary>
    public int? BillDay { get; set; }

    /// <summary>
    /// The selected invoice date process type identifier
    /// </summary>
    public int? InvoiceDateProcessTypeId { get; set; }

    /// <summary>
    /// The selected usage billing type identifier
    /// </summary>
    public int? UsageBillingTypeId { get; set; }

    /// <summary>
    /// The selected invoice due date type identifier
    /// </summary>
    public int? InvoiceDueDateTypeId { get; set; }

    /// <summary>
    /// The billing day of usage billing
    /// </summary>
    public int? UsageBillDay { get; set; }

    /// <summary>
    /// The invoice delivery mapping identifier
    /// </summary>
    public int? InvoiceDeliveryId { get; set; }
  }
}
