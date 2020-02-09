using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using EpaycoSdk.Models;
using EpaycoSdk.Models.Bank;
using EpaycoSdk.Models.Cash;
using EpaycoSdk.Models.Charge;
using EpaycoSdk.Models.Plans;
using EpaycoSdk.Models.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace test_sdk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EpaycoController : ControllerBase
    {
        
        EpaycoSdk.Epayco epayco = new EpaycoSdk.Epayco(
            "d7aae6aebc15f77bb434f42c26450d6e",
            "0242dfaf1e866bb2830f8915b4f1efdd",
            "ES",
            true); 
        [HttpGet]
        public IActionResult Get()
        {
            
            // return Ok(AESEncrypt("1022", "0242dfaf1e866bb2830f8915b4f1efdd"));
            return Ok("ePayco sdk .Net");
        }

        [HttpGet, Route("create/token")]
        public IActionResult CreateToken()
        {
            TokenModel token = epayco.CreateToken(
                "4575623182290326",
                "2019",
                "12",
                "123");
            return Ok(token);
        }
        
        [HttpGet, Route("create/customer")]
        public IActionResult CreateCustomer()
        {
            CustomerCreateModel customer = epayco.CustomerCreate(
                "vDCnfNXzepWb7W8Ht",
                "alejo desde .net",
                ".net",
                "alejonetsdk898@gmail.com",
                true,
                "caldas",
                "calle falsa",
                "3032546",
                "3146254435");
            return Ok(customer);
        }
        
        [HttpGet, Route("find/customer")]
        public IActionResult FindCustomer()
        {
            CustomerFindModel customer = epayco.FindCustomer("cLhn4cc4n8fCCLR4A");
            return Ok(customer);
        }
        [HttpGet, Route("customer/update")]
        public IActionResult CustomerUpdate()
        {
            CustomerEditModel customer = epayco.CustomerUpdate("cLhn4cc4n8fCCLR4A", "pepito perez");
            return Ok(customer);
        }
        
        [HttpGet, Route("customer/token/delete")]
        public IActionResult CustomerTokenDelete()
        {
            CustomerTokenDeleteModel customer = epayco.CustomerDeleteToken(
                "visa", 
                "457562******0326", 
                "cLhn4cc4n8fCCLR4A");
            return Ok(customer);
        }
        
        [HttpGet, Route("customers")]
        public IActionResult GetAllCustomers()
        {
            CustomerListModel customer = epayco.CustomerGetList();
            return Ok(customer);
        }
        
        /*
         * PLANS
         */
        [HttpGet, Route("plans/create")]
        public IActionResult CreatePlan()
        {
            CreatePlanModel plan = epayco.PlanCreate(
                "pago_.net_sdk_prueba", 
                "prueba 3",
                "prueba sdk .net",
                5000,
                "cop",
                "month",
                1,
                0);
            return Ok(plan);
        }
        
        [HttpGet, Route("plans/get")]
        public IActionResult GetPlan()
        {
            FindPlanModel plan = epayco.GetPlan("mi_plan_2_sdk.net");
            return Ok(plan);
        }
        
        [HttpGet, Route("plans/get/all")]
        public IActionResult GetAllPlans()
        {
            FindAllPlansModel plan = epayco.GetAllPlans();
            return Ok(plan);
        }
        
        [HttpGet, Route("plans/remove")]
        public IActionResult RemovePlan()
        {
            RemovePlanModel plan = epayco.RemovePlan("00");
            return Ok(plan);
        }
        
        /*
         * SUBSCRIPTIONS
         */
        [HttpGet, Route("subscriptions/create")]
        public IActionResult CreateSubscription()
        {
            CreateSubscriptionModel subscription = epayco.SubscriptionCreate("prueba_charge_subscription_.net",
                "eBk2d4ubDAXETsg2e",
                "2CeoeeoWZBCZRAJ7p",
                "cc",
                "1026150802",
                "https://holapapi.com.co",
                "POST");
            return Ok(subscription);
        }
        
        [HttpGet, Route("subscriptions/find")]
        public IActionResult FindSubscription()
        {
            FindSusbscriptionModel subscription = epayco.getSubscription(
                "KY7J8KvAa7Xu5hze9");
            return Ok(subscription);
        }
        
        [HttpGet, Route("subscriptions/all")]
        public IActionResult GetSubscription()
        {
            AllSubscriptionModel subscription = epayco.getAllSubscription();
            return Ok(subscription);
        }
        
        [HttpGet, Route("subscriptions/cancel")]
        public IActionResult CancelSubscription()
        {
            CancelSubscriptionModel subscription = epayco.cancelSubscription("KY7J8KvAa7Xu5hze9");
            return Ok(subscription);
        }
        
        [HttpGet, Route("subscriptions/charge")]
        public IActionResult ChargeSubscription()
        {
            ChargeSubscriptionModel subscription = epayco.ChargeSubscription(
                "prueba_charge_subscription_.net2",
                "yf9zh6xkFjiS2yvM9",
                "3m7gqWQLoceaCZRvs",
                "CC",
                "1026150902",
                "0.0.0.0",
                "calle falsa",
                "3146254435",
                "3146254435");
            return Ok(subscription);
        }
        
        [HttpGet, Route("pse/create")]
        public IActionResult CreatePse()
        {
            PseModel response = epayco.BankCreate(
                "1051",
                "1472050778",
                "pago de pruebas",
                "10000",
                "0",
                "0",
                "COP",
                "0",
                "CC",
                "1026150902",
                "alejandro",
                "castañeda",
                "alejandro.casta3447@gmail.com",
                "CO",
                "3146254435",
                "https:/secure.payco.co/restpagos/testRest/endpagopse.php",
                "https:/secure.payco.co/restpagos/testRest/endpagopse.php",
                "GET");
            return Ok(response);
        }
        
        [HttpGet, Route("get/transaction")]
        public IActionResult GetTransaction()
        {
            TransactionModel transaction = epayco.GetTransaction("48771581125902");
            return Ok(transaction);
        }
        
        [HttpGet, Route("get/banks")]
        public IActionResult GetBanks()
        {
            BanksModel banks = epayco.GetBanks();
            return Ok(banks);
        }
        
        /*
         * CASH
         */
        [HttpGet, Route("cash/create")]
        public IActionResult CashCreate()
        {
            CashModel response = epayco.CashCreate("efecty",
                "1472050778",
                "pago de pruebas",
                "1000",
                "0",
                "0",
                "COP",
                "0",
                "CC",
                "1026150902",
                "alejandro",
                "castañeda",
                "alejandro.casta3447@gmail.com",
                "3146254435",
                "2020-09-20",
                "https:/secure.payco.co/restpagos/testRest/endpagopse.php",
                "https:/secure.payco.co/restpagos/testRest/endpagopse.php",
                "GET");
            return Ok(response);
        }
        
        [HttpGet, Route("cash/transaction")]
        public IActionResult GetCashTransactiom()
        {
            CashTransactionModel cash = epayco.GetCashTransaction("14925792");
            return Ok(cash);
        }
         
        /*
         * PAYMENT
         */
        [HttpGet, Route("payment/create")]
        public IActionResult ChargeCreate()
        {
            ChargeModel response = epayco.ChargeCreate(
                "2CeoeeoWZBCZRAJ7p",
                "2CeoeeoWZBCZRAJ7p",
                "CC",
                "1026150902",
                "Alejandro",
                "castañeda",
                "alejandro.casta3447@gmail.com",
                "OR-4154754",
                "pago de prueba",
                "150000",
                "0",
                "0",
                "COP",
                "6",
                "calle falsa",
                "3146254435",
                "3146254435",
                "https:/secure.payco.co/restpagos/testRest/endpagopse.php",
                "https:/secure.payco.co/restpagos/testRest/endpagopse.php",
                "0.0.0.0");
            return Ok(response);
        }
        
        [HttpGet, Route("charge/transaction")]
        public IActionResult GetChargeTransaction()
        {
            ChargeTransactionModel cash = epayco.GetChargeTransaction("14925792");
            return Ok(cash);
        }
    }
}