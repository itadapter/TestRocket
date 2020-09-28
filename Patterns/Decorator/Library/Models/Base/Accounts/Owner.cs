namespace DecoratorLogic.Models.Base
{
  /// <summary>
  /// An account(s) owner identity mapping used to attach services and
  /// if appropriate a bill group account
  /// </summary>
  public class Owner
  {
    /// <summary>
    /// The primary ownership identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The identifier of the owning entity (Enterprise, Individual, etc.)
    /// </summary>
    public int OwnerEntityId { get; set; }
  }
}
