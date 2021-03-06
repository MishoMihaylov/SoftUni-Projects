﻿using PizzaMore.Utility.Classes;

namespace PizzaMore.Utility.Interfaces
{
    public interface ICookieCollection
    {
        void AddCookie(Cookie cookie);

        void RemoveCookie(string cookieName);

        bool ContainsKey(string key);

        int Count { get; }

        Cookie this[string key] { get; set; }
    }
}
