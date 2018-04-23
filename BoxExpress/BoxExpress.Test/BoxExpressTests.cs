using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxExpress;
using System.Collections.Generic;

namespace BoxExpress.Test
{
    [TestClass]
    public class BoxExpressTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var wtf = new FormSample
            {
                Name = "Misha",
                Date = DateTime.Now,
                Product = new List<Product>()
                {
                    new Product()
                    {
                        Type = Staff.Electronics,
                        ProductName = "Laptop",
                        Description = "Vax nout",
                        Count = 2,
                    }
                },
                Address = new List<Address>()
                {
                    new Address()
                    {
                        Сountry = Сountry.RussianFederation,
                        Region = "Sverdlovskaya obl.",
                        City = "Ekaterinbyrg",
                        Index = 148822,
                        Phone = "+7 (800) 555-35-35",
                    }
                }
            };
            Assert.AreEqual(wtf.Name, "Misha");
        }
    }
}