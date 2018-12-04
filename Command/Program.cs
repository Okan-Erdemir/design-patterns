﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            // yapılan işlemleri hafızaya alma
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);
            StockController stockController = new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(sellStock);
            stockController.PlaceOrders();
            Console.ReadLine();
        }
    }

    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;
        public void buy()
        {
            Console.WriteLine("Stock:{0} - {1} bought!", _name, _quantity);

        }

        public void Sell()
        {
            Console.WriteLine("Stock:{0} - {1} sold!", _name, _quantity);
        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        StockManager _stockManager;
        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;

        }
        public void Execute()
        {
            _stockManager.buy();
        }
    }
    class SellStock : IOrder
    {
        StockManager _stockManager;
        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;

        }
        public void Execute()
        {
            _stockManager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var item in _orders)
            {
                item.Execute();
            }

            _orders.Clear();
        }
    }
}
