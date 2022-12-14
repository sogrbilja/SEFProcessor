using DDCommonLibrary;
using Newtonsoft.Json;
using SEFProcessor.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SEFProcessor
{
  public static class PublicApi
  {

    public static bool _isSandbox { get; set; }

    public static string _salesInvoicesSentPath { get; set; }
    public static string _salesInvoicesCanceledPath { get; set; }
    public static string _salesInvoicesStornoPath { get; set; }

    public static void setAPIKeys(string APIKey_, string sandboxAPIKey_)
    {
      Properties.Settings.Default.APIKey = APIKey_;
      Properties.Settings.Default.sandboxAPIKey = sandboxAPIKey_;
    }

    static sefFailure processError(WebException e)
    {
      if (e.Status == WebExceptionStatus.ProtocolError)
      {
        using (StreamReader r = new StreamReader(((HttpWebResponse)e.Response).GetResponseStream()))
        {
          var ra = r.ReadToEnd();
          return JsonConvert.DeserializeObject<sefFailure>(ra);
        }
      }
      else
      {
        return new sefFailure()
        {
          Message = e.Message
        };
      }
    }

    static void setWebClient(WebClient webClient_, string ContentType_ = "application/xml")
    {
      if (_isSandbox)
      {
        webClient_.BaseAddress = Properties.Settings.Default.sandboxApiEndpoint;
        webClient_.Headers.Add("ApiKey", Properties.Settings.Default.sandboxAPIKey);
      }
      else
      {
        webClient_.BaseAddress = Properties.Settings.Default.publicApiEndpoint;
        webClient_.Headers.Add("ApiKey", Properties.Settings.Default.APIKey);
      }
      webClient_.Headers[HttpRequestHeader.ContentType] = ContentType_;
      webClient_.Encoding = Encoding.UTF8;
    }

    public static bool checkAPIKeys()
    {
      return (_isSandbox && Properties.Settings.Default.sandboxAPIKey != "" || !_isSandbox && Properties.Settings.Default.APIKey != "");
    }

    public static (UnitMeasuresResponse data, sefFailure error) getUnitMeasures()
    {
      UnitMeasuresResponse data = null;
      sefFailure error = null;
      try
      {
        using (WebClient webClient = new WebClient())
        {
          setWebClient(webClient);
          var response = webClient.DownloadString(Properties.Settings.Default.API_getUnitMeasures);

          data = JsonConvert.DeserializeObject<UnitMeasuresResponse>(response);

        }
      }
      catch (WebException e)
      {
        error = processError(e);
      }
      catch (Exception ex)
      {
        error = new sefFailure()
        {
          Message = ex.Message
        };
      }
      return (data, error);
    }

    public static (getInvoiceResponse data, sefFailure error) salesInvoiceGet(Int64 InvoiceID_)
    {
      getInvoiceResponse data = null;
      sefFailure error = null;
      try
      {
        using (WebClient webClient = new WebClient())
        {
          setWebClient(webClient, "text/plain");
          var response = webClient.DownloadString(string.Format(Properties.Settings.Default.API_salesInvoiceGet, InvoiceID_));
          data = JsonConvert.DeserializeObject<getInvoiceResponse>(response);
        }
      }
      catch (WebException e)
      {
        error = processError(e);
      }
      catch (Exception ex)
      {
        error = new sefFailure()
        {
          Message = ex.Message
        };
      }
      return (data, error);
    }

    public static (dynamic data, sefFailure error) salesInvoiceCancel(salesInvoiceCancelRequest data_)
    {
      dynamic data = null;
      sefFailure error = null;
      try
      {
        using (WebClient webClient = new WebClient())
        {
          setWebClient(webClient, "application/json");
          var response = webClient.UploadString(Properties.Settings.Default.API_salesInvoice_cancel, JsonConvert.SerializeObject(data_));

          if (Directory.Exists(_salesInvoicesCanceledPath))
            File.WriteAllText(Path.Combine(_salesInvoicesCanceledPath, data_.invoiceId.ToString() + ".json"), response);

          data = JsonConvert.DeserializeObject(response);

        }
      }
      catch (WebException e)
      {
        error = processError(e);
      }
      catch (Exception ex)
      {
        error = new sefFailure()
        {
          Message = ex.Message
        };
      }
      return (data, error);
    }

    public static (dynamic data, sefFailure error) salesInvoiceStorno(salesInvoiceStornoRequest data_)
    {
      dynamic data = null;
      sefFailure error = null;
      try
      {
        using (WebClient webClient = new WebClient())
        {
          setWebClient(webClient, "application/json");
          var response = webClient.UploadString(Properties.Settings.Default.API_salesInvoice_storno, JsonConvert.SerializeObject(data_));

          if (Directory.Exists(_salesInvoicesStornoPath))
            File.WriteAllText(Path.Combine(_salesInvoicesStornoPath, data_.invoiceId.ToString() + ".json"), response);

          data = JsonConvert.DeserializeObject(response);

        }
      }
      catch (WebException e)
      {
        error = processError(e);
      }
      catch (Exception ex)
      {
        error = new sefFailure()
        {
          Message = ex.Message
        };
      }
      return (data, error);
    }
    public static (sefSuccess data, sefFailure error) UploadInvoice(string XML_, string requestId = null)
    {
      sefSuccess data = null;
      sefFailure error = null;
      try
      {
        requestId = requestId != null ? requestId : (Guid.NewGuid()).ToString();
        using (WebClient webClient = new WebClient())
        {
          setWebClient(webClient);
          var response = webClient.UploadString(Properties.Settings.Default.API_salesInvoice_ubl + "?requestId=" + requestId, XML_);

          data = JsonConvert.DeserializeObject<sefSuccess>(response);

          if (Directory.Exists(_salesInvoicesSentPath))
            File.WriteAllText(Path.Combine(_salesInvoicesSentPath, data.salesInvoiceId.ToString() + ".xml"), XML_);

          data.requestId = requestId;

        }
      }
      catch (WebException e)
      {
        error = processError(e);
      }
      catch (Exception ex)
      {
        error = new sefFailure()
        {
          Message = ex.Message
        };
      }
      return (data, error);
    }


    public static (salesInvoiceChangesResponse[] data, sefFailure error) salesInvoiceChanges(string Date_)
    {
      salesInvoiceChangesResponse[] data = null;
      sefFailure error = null;
      try
      {
        using (WebClient webClient = new WebClient())
        {
          setWebClient(webClient, "text/plain");
          var response = webClient.UploadString(string.Format(Properties.Settings.Default.Api_salesInvoice_changes, Date_), "");
          data = JsonConvert.DeserializeObject<salesInvoiceChangesResponse[]>(response);
        }
      }
      catch (WebException e)
      {
        error = processError(e);
      }
      catch (Exception ex)
      {
        error = new sefFailure()
        {
          Message = ex.Message
        };
      }
      return (data, error);
    }

    public static (purchaseInvoiceChangesResponse[] data, sefFailure error) purchaseInvoiceChanges(string Date_)
    {
      purchaseInvoiceChangesResponse[] data = null;
      sefFailure error = null;
      try
      {
        using (WebClient webClient = new WebClient())
        {
          setWebClient(webClient, "text/plain");
          var response = webClient.UploadString(string.Format(Properties.Settings.Default.Api_purchaseInvoice_changes, Date_), "");
          data = JsonConvert.DeserializeObject<purchaseInvoiceChangesResponse[]>(response);
        }
      }
      catch (WebException e)
      {
        error = processError(e);
      }
      catch (Exception ex)
      {
        error = new sefFailure()
        {
          Message = ex.Message
        };
      }
      return (data, error);
    }

    public static void PropertyEditor(DDCommon.Language lang_, IWin32Window form_owner_)
    {
      var result = DDCommon.PropertyEditor(Properties.Settings.Default, DDCommon.Language.srb, form_owner_);
      if (result.changed)
      {
        Properties.Settings.Default.Save();
      }
    }
  }

}
