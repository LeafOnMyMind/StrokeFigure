using System;
using System.Collections.Generic;
using System.Globalization;

namespace StrokeFigure.Logging {
    public sealed class LogFields {
        private List<(string, string)> fields = new List<(string, string)>();

        public void Append<Value>(string name, Value value) where Value : IFormattable {
            this.fields.Add((name, value.ToString(null, CultureInfo.InvariantCulture)));
        }

        public void Append(string name, string value) {
            this.fields.Add((name, value));
        }
    }
}
