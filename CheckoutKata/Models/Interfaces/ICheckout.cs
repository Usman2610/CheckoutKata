﻿namespace CheckoutKata.Models.Interfaces
{
    public interface ICheckout
    {
        void Scan(string item);
        decimal GetTotalPrice();

    }

}