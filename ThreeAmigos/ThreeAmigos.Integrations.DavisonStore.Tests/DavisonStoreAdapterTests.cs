using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ThreeAmigos.Integrations.DavisonStore.Tests
{ 

[TestClass]
public class DavisonStoreAdapterTests
{
    [TestMethod]
    public void TestSearchProducts()
    {
        var proxy = new DavisonStoreAdapter("http://davisonstore.azurewebsites.net/");
        var products = proxy.SearchProducts(1, null, 1);
    }

    [TestMethod]
    public void TestGetProductById()
    {
        var proxy = new DavisonStoreAdapter("http://davisonstore.azurewebsites.net/");
        var product = proxy.GetProductById(1);
    }

    [TestMethod]
    public void TestGetAllCategories()
    {
        var proxy = new DavisonStoreAdapter("http://davisonstore.azurewebsites.net/");
        var categories = proxy.GetAllCategories();
    }
}
}
