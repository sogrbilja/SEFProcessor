using System;
using System.ComponentModel;

namespace SEFProcessor
{

  public class sefSuccess
  {
    public sefSuccess()
    {
      invoiceId = 0;
      purchaseInvoiceId = 0;
      salesInvoiceId = 0;
      requestId = "";
    }
    public int invoiceId;
    public int purchaseInvoiceId;
    public int salesInvoiceId;
    public string requestId;
  }

  public class sefFailure
  {
    public sefFailure()
    {
      Message = "";
      FieldName = "";
      ErrorCode = "";
      requestId = "";
    }
    public string Message;
    public string FieldName;
    public string ErrorCode;
    public string requestId;
  }

  public class getInvoiceResponse
  {

    public string status;
    public Int64 invoiceId;
    public string globUniqId;
    public string comment;
    public string cirStatus;
    public string cirInvoiceId;
    public Int64 version;
    public string lastModifiedUtc;
    public double cirSettledAmount;
    public string vatNumberFactoringCompany;
    public string factoringContractNumber;
    public string cancelComment;
    public string stornoComment;
  }

  public class UnitMeasuresResponse
  {
    public string Code;
    public string Symbol;
    public string NameEng;
    public string NameSrbLtn;
    public string NameSrbCyr;
    public bool IsOnShortList;
  }

  public class salesInvoiceCancelRequest
  {
    [DescriptionAttribute("Broj računa")]
    public Int64 invoiceId { get; set; }
    [DescriptionAttribute("Razlog otkazivanja ovog računa")]
    public string cancelComments { get; set; }
  }
  public class salesInvoiceStornoRequest
  {
    [DescriptionAttribute("Broj računa")]
    public Int64 invoiceId { get; set; }
    [DescriptionAttribute("Razlog storniranja ovog računa")]
    public string stornoNumber { get; set; }
    [DescriptionAttribute("Razlog storniranja ovog računa")]
    public string stornoComment { get; set; }
  }

  public class salesInvoiceChangesResponse
  {
    public int eventId { get; set; }
    public string date { get; set; }
    public string newInvoiceStatus { get; set; }
    public int? salesInvoiceId { get; set; }
    public string comment { get; set; }
    public string cirInvoiceId { get; set; }
    public string subscriptionKey { get; set; }
    public string stornoNumber { get; set; }
    public string cirAssignmentChange { get; set; }
    public bool? isSigned { get; set; }
  }
  public class purchaseInvoiceChangesResponse
  {
    public int eventId { get; set; }
    public string date { get; set; }
    public string newInvoiceStatus { get; set; }
    public int? purchaseInvoiceId { get; set; }
    public string comment { get; set; }
    public string cirInvoiceId { get; set; }
    public string subscriptionKey { get; set; }
    public string stornoNumber { get; set; }
    public string cirAssignmentChange { get; set; }
    public bool? isSigned { get; set; }
  }

}
