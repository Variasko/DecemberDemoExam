using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MAAANSPRANDING.Model
{
    class Base
    {
        public string[] models = { "Модель 1", "Модель 2", "Модель 3", "Модель 4" };
        public string[] types = { "Тип 1", "Тип 2", "Тип 3", "Тип 4" };
        public string[] deffects = { "Деффект 1", "Деффект 2", "Деффект 3", "Деффект 4" };
        public string[] priorities = { "Приоритет 1", "Приоритет 2", "Приоритет 3", "Приоритет 4" };
        public string[] statuses = { "Статус 1", "Статус 2", "Статус 3", "Статус 4" };
        public string filePath = "C:\\Users\\caxac\\source\\repos\\MAAANSPRANDING\\MAAANSPRANDING\\Data\\data.json";

        public void WriteObjectToFile(object orders)
        {
            var jsonObject = JsonSerializer.Serialize(orders as List<Order>);

            File.WriteAllText(filePath, jsonObject);
        }

        public List<Order> ReadObjectFromFile()
        {
            try
            {
                var jsonObject = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Order>>(jsonObject);
            } catch (Exception ex)
            {
                return null;
            }

        }

        public List<Order> GenerateOrders()
        {
            List<Order> _orders = new List<Order>();

            for (int i = 0; i < 20; i++)
            {
                Order newOrder = new Order
                {
                    Id = i + 1,
                    Model = models[i % 4],
                    Type = types[i % 4],
                    Deffect = deffects[i % 4],
                    ClientName = "Alex",
                    Comment = "Оно сломалось!"
                };

                _orders.Add(newOrder);
            }

            return _orders;
        }
    }
}