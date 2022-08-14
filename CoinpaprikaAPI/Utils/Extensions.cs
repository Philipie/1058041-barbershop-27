
﻿using CoinpaprikaAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinpaprikaAPI.Utils
{
    public static class Extensions
    {
        public static string ToArrayString(this string[] array)
        {
            if (array.Length == 1)
                return array[0].ToString();

            if (array.Length > 1)
            {
                var sb = new StringBuilder();

                array.ToList().ForEach(i => sb
                    .Append(i)
                    .Append(","));

                var result = sb.ToString();

                return result.EndsWith(",") ? result.Substring(0, result.Length - 1) : result;
            }

            return string.Empty;
        }

        public static string ToIntervalString(this TickerInterval interval)
        {
            switch (interval)
            {
                case TickerInterval.FiveMinutes:
                    return "5m";
                case TickerInterval.TenMinutes:
                    return "10m";
                case TickerInterval.FifteenMinutes:
                    return "15m";
                case TickerInterval.ThirtyMinutes:
                    return "30m";
                case TickerInterval.FourtyFiveMinutes:
                    return "45m";
                case TickerInterval.OneHour: