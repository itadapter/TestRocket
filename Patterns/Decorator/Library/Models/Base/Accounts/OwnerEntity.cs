namespace DecoratorLogic.Models.Base
{
  /// <summary>
  /// An entity associated as an owner of an account
  /// </summary>
  public class OwnerEntity : BaseItem
  {
    /// <summary>
    /// The parent owner entity id for composite ownership models
    /// </summary>
    public int ParentOwnerEntityId { get; set; }

    /// <summary>
    /// The partner or reseller owner entity id
    /// </summary>
    public int PartnerEntityId { get; set; }

    /// <summary>
    /// The type of owning entity (Enterprise, Individual, etc.)
    /// </summary>
    public int OwnerTypeId { get; set; }

    /// <summary>
    /// The display name of the entity
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Large logo or photo associated with the owner entity
    /// </summary>
    public string LargeLogo { get; set; }

    /// <summary>
    /// Small logo or photo associated with the owner entity
    /// </summary>
    public string SmallLogo { get; set; }

    /// <summary>
    /// Primary UX color RGB hex value
    /// </summary>
    public string PrimaryColor { get; set; }

    /// <summary>
    /// Secondary UX color RGB hex value
    /// </summary>
    public string SecondaryColor { get; set; }
  }
}
