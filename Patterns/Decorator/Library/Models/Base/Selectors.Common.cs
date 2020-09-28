using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorLogic.Models.Base
{
  /// <summary>
  /// The generalized account status details to be referenced by Id
  /// </summary>
  /// <remarks>Active, Inactive, Demo etc.</remarks>
  public class AccountStatus : BaseSelection { }

  /// <summary>
  /// Selection to describe the type of account
  /// </summary>
  /// <remarks>Credit Card, Prepay</remarks>
  public class AccountType : BaseSelection { }

  /// <summary>
  /// The generalized billing status details to be referenced by Id.
  /// </summary>
  /// <remarks>Billable, Non-Billable, Closed, etc.</remarks>
  public class BillingStatus : BaseSelection { }

  /// <summary>
  /// Selection to describe the type of invoice delivery for an account
  /// </summary>
  /// <remarks>Email, Mail, etc</remarks>
  public class InvoiceDeliveryType : BaseSelection { }

  /// <summary>
  /// Selection to describe the type of template for an invoice
  /// </summary>
  /// <remarks>Email, Mail, etc</remarks>
  public class InvoiceTemplateType : BaseSelection { }

  /// <summary>
  /// Selection to describe the type of entity an OwnerEntity is
  /// </summary>
  /// <remarks>Individual, Enterprise, Government, Reseller, Partner, Internal, Trial, Demo, etc.</remarks>
  public class OwnerType : BaseSelection { }

  /// <summary>
  /// Selection to describe the type of AR terms for an invoice
  /// </summary>
  /// <remarks>Email, Mail, etc</remarks>
  public class TermsType : BaseSelection { }

  /// <summary>
  /// Selection to describe the auto pay type of account
  /// </summary>
  /// <remarks>CC, Bank Account, None</remarks>
  public class AutoPayType : BaseSelection { }

  /// <summary>
  /// Selection to describe the auto pay type of account
  /// </summary>
  /// <remarks>CC, Bank Account, None</remarks>
  public class AccountTaxCategory : BaseSelection { }

  /// <summary>
  /// Selection to describe the invoice date processing type of a bill group
  /// </summary>
  /// <remarks>???</remarks>
  public class InvoiceDateProcessType : BaseSelection { }

  /// <summary>
  /// Selection to describe the invoice date processing type of a bill group
  /// </summary>
  /// <remarks>???</remarks>
  public class UsageBillingType : BaseSelection { }

  /// <summary>
  /// Selection to describe the invoice due date type of a bill group
  /// </summary>
  /// <remarks>???</remarks>
  public class InvoiceDueDateType : BaseSelection { }

  /// <summary>
  /// Selection to describe the frequncy of package cycle
  /// </summary>
  /// <remarks>Unit, Day, Month, etc</remarks>
  public class FrequencyType : BaseSelection { }

  /// <summary>
  /// Selection to describe a one time charge with a value and SKU
  /// </summary>
  /// <remarks>Unit, Day, Month, etc</remarks>
  public class OneTimeChargeType : SkuChargeSelection { }

  /// <summary>
  /// Selection to describe the frequncy of package cycle
  /// </summary>
  /// <remarks>Unit, Day, Month, etc</remarks>
  public class PackageCategory : BaseSelection { }

  //
}
