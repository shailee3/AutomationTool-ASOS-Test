using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WinUI
{
    public partial class MainWindow : Window
    {
        IWebDriver driver;
        IWebElement e;
        private bool Signed = false;
        string _driverPath = @"D:\Projects\Merging\AutomationSteps\packages\Selenium.WebDriver.ChromeDriver.2.23.0.1\driver";


        public MainWindow()
        {
            InitializeComponent();

            var listEnv = new List<string>();
            listEnv.Add("Environment 036");
            listEnv.Add("Environment 063");
            listEnv.Add("Environment 071");
            listEnv.Add("Environment 078");
            listEnv.Add("Environment 231");
            listEnv.Add("Pre-Prod 01");
            EnvName.ItemsSource = listEnv;


            var listCountry = new List<string>();
            listCountry.Add("US");
            listCountry.Add("AU");
            listCountry.Add("FR");
            listCountry.Add("DE");
            listCountry.Add("ES");
            listCountry.Add("IT");
            listCountry.Add("RU");
            cb_country.ItemsSource = listCountry;

            var listCurrency = new List<string>();
            listCurrency.Add("GBP");
            listCurrency.Add("AUD");
            listCurrency.Add("USD");
            listCurrency.Add("EUR");
            listCurrency.Add("RUB");
            cb_currency.ItemsSource = listCurrency;

             
        }

        private void Join(object sender, RoutedEventArgs e)
        { GoToSite();
            try
            {
                if (EnvName.SelectedValue.ToString() != "" && UserName.Text != "")
                {
                    CreateUser();
                    System.Threading.Thread.Sleep(300);
                    AddItemToBag();

                    //PlaceOrder();
                    //MessageBox.Show("User Created Successfully. If you see a Holding Page 'Refresh' it 2-3 times" +
                    //                Environment.NewLine +
                    //                Environment.NewLine + "User Name = " + UserName.Text +
                    //                Environment.NewLine + "Password = " + "Password1"
                    //    , "Success");
                }
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message, "error");
            }

            
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            GoToSite();
           // LogIn();
            System.Threading.Thread.Sleep(3000);
            SelectCountry_Currency();
            System.Threading.Thread.Sleep(3000);
          //  AddItemToBag();
          //  Checkout();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            driver.Quit();
        }

    

      //  private void MakePremier_Click(object sender, RoutedEventArgs e)
      //  {
      //     AddItemToBag();
      //  }

        public void CreateUser()
        {
            //Click on Join
            driver.FindElement(By.CssSelector("[data-bind*='click: registerClicked']")).Click();

            //Enter details
            driver.FindElement(By.Id("Email")).SendKeys(UserName.Text);
            driver.FindElement(By.Id("FirstName")).SendKeys(UserName.Text.Split('@')[0]);
            driver.FindElement(By.Id("LastName")).SendKeys("autotestuser");
            driver.FindElement(By.Id("Password")).SendKeys("Password1");

            SelectElement selItem;
            selItem = new SelectElement(driver.FindElement(By.Id("BirthDay")));
            selItem.SelectByValue("12");
            selItem = new SelectElement(driver.FindElement(By.Id("BirthMonth")));
            selItem.SelectByValue("10");
            selItem = new SelectElement(driver.FindElement(By.Id("BirthYear")));
            selItem.SelectByValue("1993");

            //Click register
            driver.FindElement(By.Id("register")).Click();

        }

        public void SelectCountry_Currency()
        {
           
          
            try
            {
                if (cb_country.SelectedValue.ToString() != "")
                {
                    string Country = cb_country.SelectedValue.ToString();
                    driver.FindElement(By.ClassName("currency-locale-link")).Click();
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                    switch (Country)
                    {
                        case "AU":
                           //driver.FindElement(By.ClassName("site-selector-9")).Click();
                            driver.Navigate().GoToUrl("http://test.asosservices.com/pgeSiteRedirect.aspx?referrer=http%3a%2f%2ftest.asosservices.com%2f%3fhrd%3d1%26setPrefSite%3dtrue&to=test.asosservices.com%2fau");
                             break;
                        case "ES":
                            //driver.FindElement(By.ClassName("site-selector-8")).Click();
                             driver.Navigate().GoToUrl("http://test.asosservices.com/pgeSiteRedirect.aspx?referrer=http%3a%2f%2ftest.asosservices.com%2f%3fhrd%3d1%26setPrefSite%3dtrue&to=test.asosservices.com%2fes");
                            break;
                        case "FR":
                            //driver.FindElement(By.ClassName("site-selector-3")).Click();
                            driver.Navigate().GoToUrl("http://test.asosservices.com/pgeSiteRedirect.aspx?referrer=http%3a%2f%2ftest.asosservices.com%2f%3fhrd%3d1%26setPrefSite%3dtrue&to=test.asosservices.fr");
                            break;
                        case "IT":
                            //driver.FindElement(By.ClassName("site-selector-7")).Click();
                            driver.Navigate().GoToUrl("http://test.asosservices.com/pgeSiteRedirect.aspx?referrer=http%3a%2f%2ftest.asosservices.com%2f%3fhrd%3d1%26setPrefSite%3dtrue&to=test.asosservices.com%2fit");
                            break;
                        case "DE":
                            //driver.FindElement(By.ClassName("site-selector-4")).Click();
                            driver.Navigate().GoToUrl("http://test.asosservices.com/pgeSiteRedirect.aspx?referrer=http%3a%2f%2ftest.asosservices.com%2f%3fhrd%3d1%26setPrefSite%3dtrue&to=test.asosservices.de");
                            break;
                        case "RU":
                            //driver.FindElement(By.ClassName("site-selector-12")).Click();
                            driver.Navigate().GoToUrl("http://test.asosservices.com/pgeSiteRedirect.aspx?referrer=http%3a%2f%2ftest.asosservices.com%2f%3fhrd%3d1%26setPrefSite%3dtrue&to=test.asosservices.com%2fru");
                            break;
                        case "US":
                            //driver.FindElement(By.ClassName("site-selector-2")).Click();
                            driver.Navigate().GoToUrl("http://test.asosservices.com/pgeSiteRedirect.aspx?referrer=http%3a%2f%2ftest.asosservices.com%2f%3fhrd%3d1%26setPrefSite%3dtrue&to=ustest.asosservices.com");
                            break;
                        default:
                            break;
                    }
                }



                if (cb_currency.SelectedValue.ToString() != "")
                {
                    string Currency = cb_currency.SelectedValue.ToString();
                                      
                    driver.FindElement(By.ClassName("selected-currency")).Click();
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                                      
                    if (driver.FindElement(By.ClassName("menu")).Displayed)
                    {                       
                        switch (Currency)
                        {
                            case "AUD":
                                driver.FindElement(By.ClassName("currency-list")).Click();
                                driver.FindElement(By.CssSelector("#currencyList > option:nth-child(21)")).Click();
                                break;
                            case "EUR":
                                driver.FindElement(By.ClassName("currency-list")).Click();
                                driver.FindElement(By.CssSelector("#currencyList > option:nth-child(19)")).Click();
                                break;
                            case "GBP":
                                driver.FindElement(By.ClassName("currency-list")).Click();
                                driver.FindElement(By.CssSelector("#currencyList > option:nth-child(1)")).Click();
                                break;
                            case "RUB":
                                driver.FindElement(By.ClassName("currency-list")).Click();
                                driver.FindElement(By.CssSelector("#currencyList > option:nth-child(10123)")).Click();
                                break;
                            case "USD":
                                driver.FindElement(By.CssSelector("#currencyList > option:nth-child(2)")).Click();
                                break;
                            //default:
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public void AddItemToBag()
        {
            var dt = GetIids();

            int iid = int.Parse(dt.Rows[0][0].ToString());
            driver.Navigate().GoToUrl("http://test.asosservices.com/pgeproduct.aspx?iid=" + iid);

            //add to bag
            driver.FindElement(By.Id("ctl00_ContentMainPage_ctlSeparateProduct_btnAddToBasket")).Click();
            
            System.Threading.Thread.Sleep(500);

            //go to basket page
            driver.FindElement(By.Id("ctl00_ctlCustomersAccountMenuO_ctlMiniBag_miniBasketTitle")).Click();

           
            
        }

        public void Checkout()
        {
            System.Threading.Thread.Sleep(3000);
            //pay now
            driver.FindElement(By.Id("ctl00_ContentMainPage_hypProceedToCheckoutTop")).Click();

            //delivery
            driver.FindElement(By.Id("_ctl0_ContentBody_ctlShippingOptions_deliverytabli")).Click();
            driver.FindElement(By.Id("radShippingMethod")).Click();

            System.Threading.Thread.Sleep(300);

            // add cvv
            e = driver.FindElement(By.Id("_ctl0_ContentBody_txtCVV"));
            e.SendKeys("123");

            //done
            driver.FindElement(By.Id("_ctl0_ContentBody_btnSubmit")).Click();
        }
                
        public DataTable GetIids()
        {
            DataTable dt = new DataTable();
            // Open connection to the database
            string envConStr=string.Empty;
            
            #region IF stmt for dynamic con. string

            if (EnvName.SelectedValue.ToString() == "Environment 071")
                envConStr = "asnav-sql-71-02";
            else if (EnvName.SelectedValue.ToString() == "Environment 078")
                envConStr = "asnav-sql-78-02";
            else if (EnvName.SelectedValue.ToString() == "Environment 036")
                envConStr = "asnav-sql-36-02";
            else if (EnvName.SelectedValue.ToString() == "Environment 063")
                envConStr = "asnav-sql-63-02";
            else if (EnvName.SelectedValue.ToString() == "Pre-Prod 01")
                envConStr = "asnav-sql-71-02";

            #endregion

            using (SqlConnection con = new SqlConnection(@"Data Source=" + envConStr + @"\checkout;Initial Catalog=AsosCheckOut;Integrated Security=True"))
            {
                con.Open();
                string sqlquery = "SELECT TOP 1 Inventory.InventoryId as InventoryId, " +
                                  "Inventory.ParentId as ParentId " +
                                  "FROM dbo.Inventory " +
                                  "INNER JOIN dbo.InventoryStock " +
                                  "ON dbo.Inventory.InventoryID = dbo.InventoryStock.InventoryID " +
                                  "where dbo.Inventory.StatusID = 50000 " +
                                  "and dbo.InventoryStock.InStock>= 2 " +
                                  "and dbo.InventoryStock.Allocated < dbo.InventoryStock.InStock " +
                                  "and dbo.Inventory.ShippingRestrictionId = 1 " +
                                  "and NOT EXISTS " +
                                  "(SELECT InventorySiteRestriction.InventoryId FROM InventorySiteRestriction " +
                                  "WHERE InventorySiteRestriction.InventoryId = Inventory.ParentId) " +
                                  "AND NOT EXISTS " +
                                  "(SELECT * FROM Brand " +
                                  "WHERE Brand.BrandId = Inventory.BrandId " +
                                  "AND Brand.ShippingRestrictionId is not NULL) ";
                //string sqlquery2 = "select top 10 * from InventoryStock order by InStock desc,DateLastRefreshed desc";
                using (SqlCommand cmd = new SqlCommand(sqlquery, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
            }

            return dt;
            }

        public void GoToSite()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();

            driver.Navigate().GoToUrl("http://test.asosservices.com");

            e = driver.FindElement(By.Id("ListBoxEnvironments"));
            SelectElement clickEnv = new SelectElement(e);
            clickEnv.SelectByText(EnvName.SelectedValue.ToString());
            driver.FindElement(By.Id("ButtonGo")).Click();
        }

        public void LogIn()
        {
            //Click on Join
            driver.FindElement(By.CssSelector("[data-bind*='click: signInClicked']")).Click();
            driver.FindElement(By.Id("EmailAddress")).SendKeys(LoginUserName.Text);
            driver.FindElement(By.Id("Password")).SendKeys(LoginPassword.Text);
            driver.FindElement(By.Id("signin")).Click();
        }
    }
}




//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using Asos.UI.AcceptanceTests.Common.DataAccess.DataObjects;
//using Asos.Web.AcceptanceTests.DataAccess.DataFiles;
//using Dapper;

//namespace Asos.Web.AcceptanceTests.DataAccess.DataAccess
//{
//    public class ShoppingBagDataAccess
//    {
//        public ProductData AddProductToShoppingBag(string emailAddress)
//        {
//            var product = ProductData.GetProductContext();

//            AddProductsToShoppingBag(emailAddress, new[] { product});

//            return product;
//        }

//        public void AddProductsToShoppingBag(string emailAddress, IList<ProductData> products)
//        {
//            var connectionString = ConfigurationManager.ConnectionStrings["Checkout"].ConnectionString;

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                var customerGuid = CustomerData.GetScenarioAccount().Guid;
//                   /* connection.Query<string>(@"select CustomerGUID from dbo.Customer where Email = @emailAddress",
//                                             new
//                                                 {
//                                                     emailAddress
//                                                 }).First();*/

//                connection.Execute("delete from dbo.BasketItem where CustomerGUID = @customerGuid",
//                                   new { customerGuid });

//                foreach (var productData in products)
//                {
//                connection.Execute(
//                    @"insert into dbo.BasketItem (CustomerGUID, InventoryId, Quantity, DateEntered, DateModified, Title, Colour, Size, ImageLocation, BasePrice, ParentId) " +
//                    "VALUES (@customerGuid, @inventoryId, '1', @dateNow, @dateNow, @productTitle, @colour, @size, 'http://images.asos.com/inv/media/3/3/7/6/1546733/khaki/image1l.jpg', @price, @parentId)",
//                    new
//                        {
//                            customerGuid = customerGuid,
//                            inventoryId = productData.InventoryId,
//                            dateNow = DateTime.Now,
//                            productTitle = productData.InventoryTitle,
//                            price = productData.CurrentPrice,
//                            parentId = productData.ParentId,
//                            colour = productData.Colour,
//                            size = productData.Description,
//                        });
//                }
//            }
//        }

//        public void AddGiftVoucherToShoppingBag(string voucherTitle, decimal voucherValue, string emailAddress, string voucherCode)
//        {
//            var connectionString = ConfigurationManager.ConnectionStrings["Checkout"].ConnectionString;

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                var customerGuid = CustomerData.GetScenarioAccount().Guid;
//                /*    connection.Query<string>(@"select CustomerGUID from dbo.Customer where Email = @emailAddress",
//                                             new
//                                                 {
//                                                     emailAddress
//                                                 }).First();*/

//                connection.Execute("delete from dbo.BasketItem where CustomerGUID = @customerGuid",
//                                   new { customerGuid });

//                var voucherId =
//                    connection.Query<int>("Select voucherId from dbo.Voucher where voucherCode=@voucherCode",
//                                          new
//                                              {
//                                                  voucherCode,
//                                              }).First();

//                connection.Execute(
//                    @"insert into dbo.BasketItem (CustomerGUID, Quantity, DateEntered,VoucherId, DateModified, Title, BasePrice) " +
//                    "VALUES (@customerGuid,'1', @dateNow,@voucherId, @dateNow, @voucherTitle,@voucherValue)",
//                    new
//                        {
//                            customerGuid,
//                            dateNow = DateTime.Now,
//                            voucherId,
//                            voucherTitle,
//                            voucherValue,
//                        });
//            }
//        }

//        public void RemoveProductFromBasket(int parentId)
//        {
//            var connectionString = ConfigurationManager.ConnectionStrings["Checkout"].ConnectionString;

//            using (var connection = new SqlConnection(connectionString))
//            {
//                var now = DateTime.Now;
//                var date = now.AddHours(-2.1);

//                connection.Open();

//                connection.Execute(@"UPDATE dbo.BasketItem "
//                                   + "SET DateEntered = @dateEntered, "
//                                   + "DateModified = @dateEntered " 
//                                   + " WHERE ParentId = @parentId",
//                                   new
//                                   {
//                                       @parentId = parentId,
//                                       @dateEntered = date,
//                                       @dateModified = date
//                                   });

//                // Changed default 30 secs to 2mins
//                connection.Execute(@"dbo.uspBasketEmptyOldContents ",null, null, 120, CommandType.StoredProcedure);
//            }
//        }

//        public void AddPremierToShoppingBag(string emailAddress, int shippingSubscriptionId)
//        {
//            var connectionString = ConfigurationManager.ConnectionStrings["Checkout"].ConnectionString;

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                var customerGuid = CustomerData.GetScenarioAccount().Guid;

//                //var customerGuid =
//                //    connection.Query<string>(@"select CustomerGUID from dbo.Customer where Email = @emailAddress",
//                //                             new
//                //                             {
//                //                                 emailAddress
//                //                             }).First();

//                connection.Execute("delete from dbo.BasketItem where CustomerGUID = @customerGuid",
//                                   new { customerGuid });

//                var templateId =
//                   connection.Query<int>(@"SELECT ShippingSubscriptionTemplateId from ShippingSubscriptionTemplate WHERE  ShippingSubscriptionId=@shippingSubscriptionId",
//                                         new
//                                         {
//                                             @shippingSubscriptionId = shippingSubscriptionId
//                                         }).First();

//                var basePrice =
//                     connection.Query<decimal>(@"SELECT Price from ShippingSubscriptionTemplate WHERE  ShippingSubscriptionId=@shippingSubscriptionId",
//                                           new
//                                           {
//                                               @shippingSubscriptionId = shippingSubscriptionId
//                                           }).First();

//                connection.Execute(
//                    @"insert into dbo.BasketItem (CustomerGUID, Quantity, DateEntered, DateModified, ShippingSubscriptionTemplateId, Title, ImageLocation, BasePrice) " +
//                    "VALUES (@customerGuid, '1', @dateNow, @dateNow, @templateId, 'ASOS Premier', 'http://ptestassets20.asosservices.com/asos-web/images/core/premier-icon.jpg', @basePrice)",
//                    new
//                    {
//                        customerGuid = customerGuid,
//                        dateNow = DateTime.Now,
//                        templateId,
//                        basePrice,


//                    });

//            }
//        }

//        public void AddPremierToShoppingBagAlongWithItem(string emailAddress, int shippingSubscriptionId)
//        {
//            var connectionString = ConfigurationManager.ConnectionStrings["Checkout"].ConnectionString;

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();
//                var customerGuid = CustomerData.GetScenarioAccount().Guid;
//                //var customerGuid =
//                //    connection.Query<string>(@"select CustomerGUID from dbo.Customer where Email = @emailAddress",
//                //                             new
//                //                             {
//                //                                 emailAddress
//                //                             }).First();

//                var templateId =
//                     connection.Query<int>(@"SELECT ShippingSubscriptionTemplateId from ShippingSubscriptionTemplate WHERE  ShippingSubscriptionId=@shippingSubscriptionId and Active=1",
//                                           new
//                                           {
//                                               @shippingSubscriptionId = shippingSubscriptionId
//                                           }).First();

//                var basePrice =
//                     connection.Query<decimal>(@"SELECT Price from ShippingSubscriptionTemplate WHERE  ShippingSubscriptionId=@shippingSubscriptionId",
//                                           new
//                                           {
//                                               @shippingSubscriptionId = shippingSubscriptionId
//                                           }).First();

//                connection.Execute(
//                    @"insert into dbo.BasketItem (CustomerGUID, Quantity, DateEntered, DateModified, ShippingSubscriptionTemplateId, Title, ImageLocation, BasePrice) " +
//                    "VALUES (@customerGuid, '1', @dateNow, @dateNow, @templateId, 'ASOS Premier', 'http://ptestassets20.asosservices.com/asos-web/images/core/premier-icon.jpg', @basePrice)",
//                    new
//                    {
//                        customerGuid = customerGuid,
//                        dateNow = DateTime.Now,
//                        templateId,
//                        basePrice,


//                    });

//            }
//        }

//        public bool CustomerHasInventoryItemInBag(string customerGuid, int inventoryId)
//        {
//            var connectionString = ConfigurationManager.ConnectionStrings["Checkout"].ConnectionString;

//            using (var connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                var results = connection.Query(
//                    @"SELECT COUNT(*) as BasketCount FROM BasketItem WHERE InventoryId = @inventoryId AND CustomerGuid = @customerGuid",

//                    new
//                    {
//                        customerGuid,
//                        inventoryId
//                    });
//                return results.First().BasketCount > 0;
//            }
//        }


//    }
//}

