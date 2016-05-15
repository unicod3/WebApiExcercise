﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiExcercise.Models;

namespace WebApiExcercise
{
    public static class TestDataHelper
    { 

        public static List<Product> Chocolate = new List<Product>() {
                new Product { Id = 1, Name="Aero", Price = 5, SupplierId = 1},
                new Product { Id = 2, Name="Aero Caramel", Price = 10, SupplierId = 1 },
                new Product { Id = 3, Name="Aero Mint", Price = 15,SupplierId = 1 }
            };

        public static List<Product> Tea = new List<Product>() {
                new Product { Id = 1, Name="Blueberry", Price = 5, SupplierId = 2 },
                new Product { Id = 2, Name="Chai", Price = 10, SupplierId = 2 },
                new Product { Id = 3, Name="Cinnamon", Price = 15, SupplierId = 2 }
            };

        public static List<Supplier> GetMySuppliers = new List<Supplier>() {
                 new Supplier { Id = 1,  Name = "Nestle", PaymentDay = DateTime.Now.AddMonths(1), Products = Chocolate },
                 new Supplier { Id = 2,  Name = "Lipton", PaymentDay = DateTime.Now.AddMonths(2), Products = Tea }
            };

        public static List<Product> GetMyProducts() {
            List<Product> NewList = new List<Product>();
            NewList.Concat(Chocolate).Concat(Tea);
            return NewList;
        }
        

    }
}