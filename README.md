# SEFProcessor

Slanje racuna prodaje:


    private void btInvoice_Click(object sender, RibbonControlEventArgs e)
    {

      if (!PublicApi.checkAPIKeys())
      {
        PublicApi.PropertyEditor(DDCommon.Language.srb, (IWin32Window)this.Parent);
        return;
      }

      Excel.Worksheet sht = _app.ActiveSheet;

      DateTime today = DateTime.Today.Date;

      sht.Range[Properties.Settings.Default.Cell_IssueDate].Value = today;

      var invoice = new InvoiceType()
      {
        CustomizationID = new CustomizationIDType()
        {
          Value = Properties.Settings.Default.Value_CustomizationID
        },
        ID = new IDType()
        {
          Value = sht.Range[Properties.Settings.Default.Cell_ID].Value
        },
        IssueDate = new IssueDateType()
        {
          Value = Convert.ToDateTime(sht.Range[Properties.Settings.Default.Cell_IssueDate].Value)
        },
        DueDate = new DueDateType()
        {
          Value = Convert.ToDateTime(sht.Range[Properties.Settings.Default.Cell_DueDate].Value)
        },
        InvoiceTypeCode = new InvoiceTypeCodeType()
        {
          Value = Properties.Settings.Default.Value_InvoiceTypeCode
        },
        DocumentCurrencyCode = new DocumentCurrencyCodeType()
        {
          Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
        },
        ContractDocumentReference = new DocumentReferenceType[1]
        {
          new DocumentReferenceType()
          {
            ID = new IDType()
            {
              Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_ContractDocumentReference_ID].Value)
            }
          }
        },
        InvoicePeriod = new PeriodType[1]
        {
          new PeriodType()
          {
            DescriptionCode = new DescriptionCodeType[1]
            {
              new DescriptionCodeType()
              {
                Value =  Properties.Settings.Default.Value_InvoicePeriod_DescriptionCode
              }
            }
          }
        },
        AccountingSupplierParty = new SupplierPartyType()
        {
          Party = new PartyType()
          {
            EndpointID = new EndpointIDType()
            {
              Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierPIB].Value),
              schemeID = "9948"
            },
            PartyIdentification = new PartyIdentificationType[1]
            {
              new PartyIdentificationType()
              {
                ID = new IDType(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierPIB].Value)
                }
              }
            },
            PartyName = new PartyNameType[1]
            {
              new PartyNameType()
              {
                Name = new NameType1(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierName].Value)
                }
              }
            },
            PostalAddress = new AddressType()
            {
              CityName = new CityNameType()
              {
                Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierCity].Value)
              },
              PostalZone = new PostalZoneType()
              {
                Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierPostalZone].Value)
              },
              AddressLine = new AddressLineType[1]
              {
                new AddressLineType()
                {
                  Line = new LineType()
                  {
                    Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierStreet].Value)
                  }
                }
              },
              Country = new CountryType()
              {
                IdentificationCode = new IdentificationCodeType()
                {
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierCountryCode].Value)
                }
              }
            },
            PartyTaxScheme = new PartyTaxSchemeType[1]
            {
              new PartyTaxSchemeType()
              {
                CompanyID = new CompanyIDType(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierCountryCode].Value) + Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierPIB].Value)
                },
                TaxScheme = new TaxSchemeType()
                {
                  ID = new IDType()
                  {
                    Value = Properties.Settings.Default.Value_TaxCategory_TaxScheme_ID
                  }
                }
              }
            },
            WebsiteURI = new WebsiteURIType()
            {
              Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_WebsiteURI].Value)
            },
            PartyLegalEntity = new PartyLegalEntityType[1]
            {
              new PartyLegalEntityType()
              {
                RegistrationName = new RegistrationNameType(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierName].Value)
                },
                CompanyID = new CompanyIDType(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierMB].Value)
                }
              }
            }
          }
        },
        AccountingCustomerParty = new CustomerPartyType()
        {
          Party = new PartyType()
          {
            EndpointID = new EndpointIDType()
            {
              Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_CustomerPIB].Value),
              schemeID = "9948"
            },
            PartyIdentification = new PartyIdentificationType[1]
            {
              new PartyIdentificationType()
              {
                ID = new IDType(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_CustomerPIB].Value)
                }
              }
            },
            PartyName = new PartyNameType[1]
            {
              new PartyNameType()
              {
                Name = new NameType1(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_CustomerName].Value)
                }
              }
            },
            PostalAddress = new AddressType()
            {
              CityName = new CityNameType()
              {
                Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_CustomerCity].Value)
              },
              AddressLine = new AddressLineType[1]
              {
                new AddressLineType()
                {
                  Line = new LineType()
                  {
                    Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_CustomerStreet].Value)
                  }
                }
              },
              Country = new CountryType()
              {
                IdentificationCode = new IdentificationCodeType()
                {
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierCountryCode].Value)
                }
              }
            },
            PartyTaxScheme = new PartyTaxSchemeType[1]
            {
              new PartyTaxSchemeType()
              {
                CompanyID = new CompanyIDType(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_SupplierCountryCode].Value) + Convert.ToString(sht.Range[Properties.Settings.Default.Cell_CustomerPIB].Value)
                },
                TaxScheme = new TaxSchemeType()
                {
                  ID = new IDType()
                  {
                    Value = Properties.Settings.Default.Value_TaxCategory_TaxScheme_ID
                  }
                }
              }
            },
            PartyLegalEntity = new PartyLegalEntityType[1]
            {
              new PartyLegalEntityType()
              {
                RegistrationName = new RegistrationNameType(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_CustomerName].Value)
                },
                CompanyID = new CompanyIDType(){
                  Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_CustomerID].Value)
                }
              }
            }
          }
        },
        Delivery = new DeliveryType[1]
        {
          new DeliveryType()
          {
            ActualDeliveryDate = new ActualDeliveryDateType()
            {
              Value = Convert.ToDateTime(sht.Range[Properties.Settings.Default.Cell_DeliveryDate].Value)
            }
          }
        },
        PaymentMeans = new PaymentMeansType[1]
        {
          new PaymentMeansType()
          {
            //https://docs.peppol.eu/poacc/billing/3.0/codelist/UNCL4461/
            PaymentMeansCode = new PaymentMeansCodeType()
            {
              Value = Properties.Settings.Default.Value_PaymentMeansCode
            },
            PayeeFinancialAccount = new FinancialAccountType()
            {
              ID = new IDType{
                Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_PayeeFinancialAccountID].Value)
              }
            }
          }
        },
        TaxTotal = new TaxTotalType[1]
        {
          new TaxTotalType()
          {
            TaxAmount = new TaxAmountType()
            {
              Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Cell_TaxAmount].Value),
              currencyID = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
            },
            TaxSubtotal = new TaxSubtotalType[1]
            {
              new TaxSubtotalType()
              {
                TaxableAmount = new TaxableAmountType()
                {
                  Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Cell_TaxableAmount].Value),
                  currencyID = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
                },
                TaxAmount = new TaxAmountType()
                {
                  Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Cell_TaxAmount].Value),
                  currencyID = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
                },
                TaxCategory = new TaxCategoryType()
                {
                  ID = new IDType()
                  {
                    Value = Properties.Settings.Default.Value_TaxCategory_ID
                  },
                  Percent = new PercentType1()
                  {
                    Value = Properties.Settings.Default.Value_TaxCategory_Percent
                  },
                  TaxExemptionReasonCode = new TaxExemptionReasonCodeType()
                  {
                    Value = Properties.Settings.Default.Value_TaxCategory_TaxExemptionReasonCode
                  },
                  TaxScheme = new TaxSchemeType()
                  {
                    ID = new IDType()
                    {
                      Value = Properties.Settings.Default.Value_TaxCategory_TaxScheme_ID
                    }
                  }
                }
              }
            }
          }
        },
        LegalMonetaryTotal = new MonetaryTotalType()
        {
          LineExtensionAmount = new LineExtensionAmountType()
          {
            Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Cell_TaxableAmount].Value),
            currencyID = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
          },
          TaxExclusiveAmount = new TaxExclusiveAmountType()
          {
            Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Cell_TaxableAmount].Value),
            currencyID = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
          },
          TaxInclusiveAmount = new TaxInclusiveAmountType()
          {
            Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Cell_TaxableAmount].Value),
            currencyID = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
          },
          PayableAmount = new PayableAmountType()
          {
            Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Cell_TaxableAmount].Value),
            currencyID = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
          }
        },

      };

      var InvoiceLines = new List<InvoiceLineType>();

      for (var row = Properties.Settings.Default.Row_InvoiceLine_Start; row <= Properties.Settings.Default.Row_InvoiceLine_End; row++)
      {
        if (sht.Range[Properties.Settings.Default.Column_InvoiceLine_Item_Name + row.ToString()].Value == null)
          continue;
        var inv = new InvoiceLineType()
        {
          ID = new IDType()
          {
            Value = Convert.ToString(sht.Range[Properties.Settings.Default.Column_InvoiceLine_Invoice_ID + row.ToString()].Value)
          },
          InvoicedQuantity = new InvoicedQuantityType()
          {
            Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Column_InvoiceLine_InvoicedQuantity + row.ToString()].Value),
            unitCode = Convert.ToString(sht.Range[Properties.Settings.Default.Column_InvoiceLine_InvoicedQuantity_unitCode + row.ToString()].Value)
          },
          LineExtensionAmount = new LineExtensionAmountType()
          {
            Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Column_InvoiceLine_LineExtensionAmount + row.ToString()].Value),
            currencyID = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
          },
          Item = new ItemType()
          {
            Name = new NameType1()
            {
              Value = Convert.ToString(sht.Range[Properties.Settings.Default.Column_InvoiceLine_Item_Name + row.ToString()].Value)
            },
            ClassifiedTaxCategory = new TaxCategoryType[1]
            {
                new TaxCategoryType()
                {
                  ID = new IDType()
                  {
                    Value = Properties.Settings.Default.Value_TaxCategory_ID
                  },
                  Percent = new PercentType1()
                  {
                    Value = Properties.Settings.Default.Value_TaxCategory_Percent
                  },
                  TaxScheme = new TaxSchemeType()
                  {
                    ID = new IDType()
                    {
                      Value = Properties.Settings.Default.Value_TaxCategory_TaxScheme_ID
                    }
                  }
                }
            }
          },
          Price = new PriceType()
          {
            PriceAmount = new PriceAmountType()
            {
              Value = Convert.ToDecimal(sht.Range[Properties.Settings.Default.Column_InvoiceLine_LineExtensionAmount + row.ToString()].Value),
              currencyID = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_DocumentCurrencyCode].Value)
            }
          }
        };

        InvoiceLines.Add(inv);
      }

      invoice.InvoiceLine = InvoiceLines.ToArray();

      if (sht.Range[Properties.Settings.Default.Cell_CustomerPostalZone].Value != null)
      {
        invoice.AccountingCustomerParty.Party.PostalAddress.PostalZone = new PostalZoneType()
        {
          Value = Convert.ToString(sht.Range[Properties.Settings.Default.Cell_CustomerPostalZone].Value)
        };
      }

      if (sht.Range[Properties.Settings.Default.Cell_JBKJS].Value != null)
      {
        invoice.AccountingCustomerParty.Party.PartyIdentification[0].ID.Value = "JBKJS:" + Convert.ToString(sht.Range[Properties.Settings.Default.Cell_JBKJS].Value);
      }


      XmlSerializer serializer = new XmlSerializer(typeof(InvoiceType));

      string utf8;

      using (StringWriter writer = new Utf8StringWriter())
      {
        serializer.Serialize(writer, invoice);
        utf8 = writer.ToString();
      }

      (sefSuccess, sefFailure) data = UploadInvoice(utf8, sht.Range[Properties.Settings.Default.Cell_ID].Value);

      if (data.Item1 != null)
      {

        sht.Range[Properties.Settings.Default.Cell_SEF_Broj].Value = data.Item1.salesInvoiceId;
        _app.ActiveWorkbook.Save();
        MessageBox.Show("Račun je uspešno poslat na SEF!", "Slanje računa", MessageBoxButtons.OK, MessageBoxIcon.Information);

      }
      else if (data.Item2 != null)
      {
        MessageBox.Show(string.Format("{0}\n\n{1}\n\n{2}", data.Item2.requestId, data.Item2.Message, data.Item2.FieldName), data.Item2.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
    
