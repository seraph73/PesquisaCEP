﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PesquisaCEP.Behaviours
{
    public class ApenasNumeros : Behavior<Entry>
    {
        /// <summary>
        /// Check about value entered in the entry and convert it
        /// </summary>
        protected Action<Entry, string> AdditionalCheck;

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += TextChanged_Handler;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        protected virtual void TextChanged_Handler(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                (sender as Entry).Text = "";
                return;
            }

            double _;
            if (!double.TryParse(e.NewTextValue, out _) || e.NewTextValue[e.NewTextValue.Length - 1] == '.')
                (sender as Entry).Text = e.OldTextValue;
            else
                AdditionalCheck?.Invoke(((Entry)sender), e.OldTextValue);
        }
    }
}
