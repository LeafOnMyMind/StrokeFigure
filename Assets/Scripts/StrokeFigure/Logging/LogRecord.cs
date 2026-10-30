using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StrokeFigure.Logging {
    internal readonly struct LogRecord {
        internal readonly double time;
        internal readonly string modeName;
        internal readonly string type;
        internal readonly IReadOnlyList<(string Name, string Value)> fields;

        internal LogRecord(
            double time, string modeName, string type,
            IReadOnlyList<(string Name, string Value)> fields
        ) {
            this.time = time;
            this.modeName = modeName;
            this.type = type;
            this.fields = fields;
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.time.ToString("F3", CultureInfo.InvariantCulture));
            builder.Append("s ");
            builder.Append(this.modeName);
            builder.Append(' ');
            builder.Append(this.type);

            foreach ((string name, string value) in this.fields) {
                builder.Append(' ');
                builder.Append(name);
                builder.Append('=');
                builder.Append(value ?? "null");
            }

            return builder.ToString();
        }
    }
}
