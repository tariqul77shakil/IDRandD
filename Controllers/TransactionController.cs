using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebAppTest1.DAL;

namespace WebAppTest1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly IConfiguration _config;

        public TransactionController(ILogger<TransactionController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        // POST: api/ProcessFundTransferRequest
        [HttpPost]
        public void Post22([FromBody] string xml)
        {
            // var lst = xml.Elements().Where(x => x.Name.LocalName == "Body").ToList();

            var strval = xml;
        }


        [HttpPost]
        [Authorize]
        public async Task<SingleTranResponse> SinglePost(SingleTranRequest tranRequest)
        {
            var objSingleTranResponse = new SingleTranResponse();
            var rng = new Random();
            var scrollInfo = new ScrollInfo();
            var batchNo= "B"+rng.Next().ToString().PadLeft(9, '0');

            scrollInfo.scrollsd = "V" + rng.Next().ToString().PadLeft(9, '0');
            scrollInfo.scrollvat = "V" + rng.Next().ToString().PadLeft(9, '0');
            scrollInfo.scrollvat_ac = "1-1111-1111-1001";
            scrollInfo.scrollsd_ac = "1-1111-1111-1002";

            objSingleTranResponse.status_code = "1";
            objSingleTranResponse.status_msg = "Success";
            objSingleTranResponse.batch_no = batchNo;
            objSingleTranResponse.batch_date = DateTime.Now.ToString("yyyy-MM-dd");

            objSingleTranResponse.challanInfo.scroll_sd = scrollInfo.scrollsd;
            objSingleTranResponse.challanInfo.scroll_vat = scrollInfo.scrollvat;
            objSingleTranResponse.challanInfo.scrollsd_ac = scrollInfo.scrollsd_ac;
            objSingleTranResponse.challanInfo.scrollvat_ac = scrollInfo.scrollvat_ac;
            objSingleTranResponse.challanInfo.scroll_date = tranRequest.header.requestDate;
            objSingleTranResponse.challanInfo.invoiceId = tranRequest.header.invoiceId;
            objSingleTranResponse.challanInfo.invoiceTime = tranRequest.header.invoiceTime;
            objSingleTranResponse.challanInfo.challanNo = tranRequest.header.challanNo;
            objSingleTranResponse.challanInfo.totalSdAmount = tranRequest.header.totalSdAmount;
            objSingleTranResponse.challanInfo.totalVatAmount = tranRequest.header.totalVatAmount;
            objSingleTranResponse.challanInfo.totalSaleAmount = tranRequest.header.totalSaleAmount;
            objSingleTranResponse.challanInfo.requestDate = tranRequest.header.requestDate;

            return await Task.FromResult(objSingleTranResponse);
        }

        [HttpPost]
        [Authorize]
        public async Task<MultiTranResponse> MultiPost(MultiTranRequest tranRequest)
        {
            var objMultiTranResponse = new MultiTranResponse();
            var challanList = new List<ChallanInfo>();
            var challanInfo = new ChallanInfo();
            var rng = new Random();
            var scrollInfo = new ScrollInfo();
            var maxInvoice= _config["Fixed-param:MaxInvoice"];
            var batchNo = "B" + rng.Next().ToString().PadLeft(9, '0');

            if (Convert.ToInt32(maxInvoice) <= 100)
            {
                foreach (var invoice in tranRequest.invoiceList)
                {
                    challanInfo = new ChallanInfo();
                    scrollInfo = new ScrollInfo();
                    scrollInfo.scrollsd = "V" + rng.Next().ToString().PadLeft(9, '0');
                    scrollInfo.scrollvat = "V" + rng.Next().ToString().PadLeft(9, '0');
                    scrollInfo.scrollvat_ac = "1-1111-1111-1001";
                    scrollInfo.scrollsd_ac = "1-1111-1111-1002";
                    challanInfo.scroll_sd = scrollInfo.scrollsd;
                    challanInfo.scroll_vat = scrollInfo.scrollvat;
                    challanInfo.scrollsd_ac = scrollInfo.scrollsd_ac;
                    challanInfo.scrollvat_ac = scrollInfo.scrollvat_ac;
                    challanInfo.scroll_date = invoice.header.requestDate;
                    challanInfo.invoiceId = invoice.header.invoiceId;
                    challanInfo.invoiceTime = invoice.header.invoiceTime;
                    challanInfo.challanNo = invoice.header.challanNo;
                    challanInfo.totalSdAmount = invoice.header.totalSdAmount;
                    challanInfo.totalVatAmount = invoice.header.totalVatAmount;
                    challanInfo.totalSaleAmount = invoice.header.totalSaleAmount;
                    challanInfo.requestDate = invoice.header.requestDate;

                    challanList.Add(challanInfo);
                }


                objMultiTranResponse.status_code = "1";
                objMultiTranResponse.status_msg = "Success";
                objMultiTranResponse.batch_no = batchNo;
                objMultiTranResponse.batch_date = DateTime.Now.ToString("yyyy-MM-dd");
                objMultiTranResponse.challanList = challanList;
            }
            else
            {
                objMultiTranResponse.status_code = "3";
                objMultiTranResponse.batch_no ="";
                objMultiTranResponse.batch_date = DateTime.Now.ToString("yyyy-MM-dd");
                objMultiTranResponse.status_msg = "does not support >100";
                objMultiTranResponse.challanList = challanList;
            }


            return await Task.FromResult(objMultiTranResponse);
        }

        [HttpPost]
        [Authorize]
        public async Task<MultiTranResponse> QueryTran(QueryTranRequest queryRequest)
        {
            var objMultiTranResponse = new MultiTranResponse();
            var challanList = new List<ChallanInfo>();

            objMultiTranResponse.status_code = "1";
            objMultiTranResponse.status_msg = "Success";

            objMultiTranResponse.challanList = challanList;

            return await Task.FromResult(objMultiTranResponse);
        }

    }
}
