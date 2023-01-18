using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.Domain.ValueObjects
{
    public class Name
    {
        private const int MaxLength = 30;
        private Name(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public static Name Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("El nombre de la ciudad no puede ser NULO.");
            }

            if (value.Length > MaxLength)
            {
                throw new InvalidOperationException("El nombre de la ciudad no puede superar los 30 caracteres.");
            }

            if (int.TryParse(value, out var nombre))
            {
                throw new InvalidOperationException("El nombre de la ciudad tienen que ser letras.");
            }
            return new Name(value.Trim());
        }
    }
}