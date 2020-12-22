using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppTest1.DAL
{
    public class DaoData
    {
        public DaoData()
        {

            id = "100";
        }

        public string id { get; set; }
    }

    public class SingleTranRequest
    {
        public SingleTranRequest()
        {
            header = new Header();
            body = new List<Body>();
        }

        public Header header { get; set; }
        public List<Body> body { get; set; }
    }

    public class MultiTranRequest
    {
        public MultiTranRequest()
        {
            invoiceList =new  List<InvoiceInfo >();
        }


        public List<InvoiceInfo> invoiceList { get; set; }
    }

    public class SingleTranResponse
    {
        public SingleTranResponse()
        {
            challanInfo = new ChallanInfo();
        }
        public string status_code { get; set; }
        public string status_msg { get; set; }
        public string batch_no { get; set; }
        public string batch_date { get; set; }
        public ChallanInfo challanInfo { get; set; }
    }

    public class MultiTranResponse
    {
        public MultiTranResponse()
        {
            challanList = new List<ChallanInfo>();
        }
        public string status_code { get; set; }
        public string status_msg { get; set; }
        public string batch_no { get; set; }
        public string batch_date { get; set; }
        public List<ChallanInfo> challanList { get; set; }
    }


    public class InvoiceInfo
    {
        public InvoiceInfo()
        {
            header = new Header();
            body = new List<Body>();
        }

        public Header header { get; set; }
        public List<Body> body { get; set; }
    }

    public class Header
    {
        public string invoiceId { get; set; }
        public string invoiceBuyerName { get; set; }
        public string invoiceTime { get; set; }
        public string challanNo { get; set; }
        public string totalSaleAmount { get; set; }
        public string totalSdAmount { get; set; }
        public string totalVatAmount { get; set; }
        public string orgBinCode { get; set; }
        public string vatChallCode { get; set; }
        public string sdChallCode { get; set; }
        public string orgCode { get; set; }
        public string orgName { get; set; }
        public string requestDate { get; set; }
    }

    public class Body
    {
        public string itemLineId { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public string itemQty { get; set; }
        public string unitPrice { get; set; }
        public string saleAmount { get; set; }
        public string sdAmount { get; set; }
        public string vatAmount { get; set; }
    }



    public class ChallanInfo
    {
        public string invoiceId { get; set; }
        public string invoiceTime { get; set; }
        public string requestDate { get; set; }
        public string challanNo { get; set; }
        public string totalSaleAmount { get; set; }
        public string totalSdAmount { get; set; }
        public string totalVatAmount { get; set; }
        public string scroll_vat { get; set; }
        public string scroll_sd { get; set; }
        public string scrollsd_ac { get; set; }
        public string scrollvat_ac { get; set; }
        public string scroll_date { get; set; }
    }

    public class ScrollInfo
    {
        internal string scrollsd { get; set; }
        internal string scrollvat { get; set; }
        internal string scrollsd_ac { get; set; }
        internal string scrollvat_ac { get; set; }
    }

    public class QueryTranRequest
    {
        public string batch_no { get; set; }
        public string batch_date { get; set; }
    }

}
