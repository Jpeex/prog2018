﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BoxExpress
{
    public interface IBoxi
    {
        void SaveContent(string content, string filePath);
        void SaveContent(string content, string filePath, Encoding encoding);
        bool IsExist(string filePath);
    }

    // Заявка на покупку товара в онлайн-магазине

    public class FormSample
    {
        // Имя получателя
        public string Name { get; set; }

        // Время подачи заявки
        public DateTime Date { get; set; }

        // Желаемый Товар
        public List<Product> Product { get; set; }

        // Адрес получателя
        public List<Address> Address { get; set; }
    }

    // Информация о товаре
    public class Product
    {
        // Тип
        public Staff Type { get; set; }

        // Наименование
        public string ProductName { get; set; }

        // Описание
        public string Description { get; set; }

        // Количество
        public int Count { get; set; }

    }

    // Информация об адресе
    public class Address
    {
        // Страна получателя
        public Сountry Сountry { get; set; }

        // Область получателя
        public string Region { get; set; }

        // Город получателя
        public string City { get; set; }

        // Почтовый индекс
        public int Index { get; set; }

        // Контактный телефон
        public string Phone { get; set; }
    }
    public enum Сountry
    {
        RussianFederation,
        China,
        India,
    }
    public enum Staff
    {
        Electronics,
        Clothes,
        Cosmetics,
    }
        public class MainBox: IBoxi
        {
            private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

            public bool IsExist(string filePath)
            {
                bool isExist = File.Exists(filePath);
                return isExist;
            }
            public void SaveContent(string content, string filePath)
            {
                SaveContent(content, filePath, _defaultEncoding);
            }
            public void SaveContent(string content, string filePath, Encoding encoding)
            {
                File.WriteAllText(filePath, content, encoding);
            }
        }
}