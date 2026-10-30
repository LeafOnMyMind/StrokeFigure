using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace StrokeFigure.Logging {
    internal readonly struct LogRecord {
        internal readonly double Time;
        internal readonly string ModeName;
        internal readonly string Type;
        internal readonly IReadOnlyList<(string Name, string Value)> Fields;

        internal LogRecord(
            double time, string modeName, string type,
            IReadOnlyList<(string Name, string Value)> fields
        ) {
            this.Time = time;
            this.ModeName = modeName;
            this.Type = type;
            this.Fields = fields;
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.Time.ToString("F3", CultureInfo.InvariantCulture));
            builder.Append("s ");
            builder.Append(this.ModeName);
            builder.Append(' ');
            builder.Append(this.Type);

            foreach ((string name, string value) in this.Fields) {
                builder.Append(' ');
                builder.Append(name);
                builder.Append('=');
                builder.Append(value ?? "null");
            }

            return builder.ToString();
        }
    }
}
