using System;
using System.Collections.Generic;
using System.Globalization;

namespace StrokeFigure.Logging {
    public sealed class LogFields {
        private readonly List<(string Name, string Value)> fields = new List<(string, string)>();
        internal List<(string Name, string Value)> Fields {
            get {
                return this.fields;
            }
        }

        public void Append(string name, string value) {
            this.fields.Add((name, value));
        }

        public void Append(string name, bool value) {
            this.fields.Add((name, value ? "true" : "false"));
        }

        public void Append(string name, char value) {
            this.fields.Add((name, value.ToString()));
        }

        public void Append(string name, int value) {
            this.fields.Add((name, value.ToString(CultureInfo.InvariantCulture)));
        }

        public void Append(string name, long value) {
            this.fields.Add((name, value.ToString(CultureInfo.InvariantCulture)));
        }

        public void Append(string name, float value) {
            this.fields.Add((name, value.ToString("G9", CultureInfo.InvariantCulture)));
        }

        public void Append(string name, double value) {
            this.fields.Add((name, value.ToString("G17", CultureInfo.InvariantCulture)));
        }

        public void Append<Value>(string name, Value value) where Value : IFormattable {
            if (value is null) {
                this.fields.Add((name, null));
                return;
            }

            this.fields.Add((name, value.ToString(null, CultureInfo.InvariantCulture)));
        }
    }
}
