using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorLogic.Models.Base
{
  /// <summary>
  /// Interface used to load Selection options into the application.
  /// </summary>
  public interface ISelectorsLoader
  {
    SelectorConfig Load();
  }

  /// <summary>
  /// Class used to store Available Selection types in the application
  /// </summary>
  public class Selectors
  {
    private readonly ISelectorsLoader m_Loader;

    /// <summary>
    /// The default constructor for Selections for the application
    /// </summary>
    /// <remarks>
    /// This should be added to the IServicesCollection as a singleton.
    /// </remarks>
    public Selectors(ISelectorsLoader loader)
    {
      m_Loader = loader;
      if (!SelectorSettings.IsValueCreated) SelectorSettings.Instance.Selections = m_Loader.Load();
    }

    /// <summary>
    /// Retrieves the available Selection collection
    /// </summary>
    public SelectorConfig Config => SelectorSettings.Instance.Selections;
  }

  /// <summary>
  /// A lazy initialized singleton to store available Selection options loaded through DI
  /// </summary>
  internal sealed class SelectorSettings
  {
    private static readonly Lazy<SelectorSettings> m_Lazy = new Lazy<SelectorSettings>(() => new SelectorSettings());

    internal static SelectorSettings Instance { get { return m_Lazy.Value; } }

    internal static bool IsValueCreated => m_Lazy.IsValueCreated;

    internal SelectorSettings() { }

    internal SelectorConfig Selections { get; set; }
  }

  public class SelectorConfig
  {
    internal HashSet<AccountStatus> AccountStatuses { get; set; }
    internal HashSet<AccountType> AccountTypes { get; set; }
    internal HashSet<BillingStatus> BillingStatuses { get; set; }
    internal HashSet<InvoiceDeliveryType> InvoiceDeliveryTypes { get; set; }
    internal HashSet<InvoiceTemplateType> InvoiceTemplateTypes { get; set; }
    internal HashSet<OwnerType> OwnerTypes { get; set; }
    internal HashSet<TermsType> TermTypes { get; set; }
    internal HashSet<AutoPayType> AutoPayTypes { get; set; }
    internal HashSet<AccountTaxCategory> AccountTaxCategories { get; set; }
    internal HashSet<InvoiceDateProcessType> InvoiceDateProcessTypes { get; set; }
    internal HashSet<UsageBillingType> UsageBillingTypes { get; set; }
    internal HashSet<InvoiceDueDateType> InvoiceDueDateTypes { get; set; }
    internal HashSet<InvoiceDueDateType> FrequencyTypes { get; set; }
    internal HashSet<OneTimeChargeType> OneTimeChargeTypes { get; set; }
    internal HashSet<PackageCategory> PackageCategories { get; set; }

    // PackageCategory
  }
}
