using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorLogic.Models.Base
{
  /// <summary>
  /// Base model item with ID and Parent ID reference
  /// </summary>
  public class BaseItem
  {
    /// <summary>
    /// The item identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The item's owner identifier
    /// </summary>
    public int OwnerId { get; set; }
  }
}
