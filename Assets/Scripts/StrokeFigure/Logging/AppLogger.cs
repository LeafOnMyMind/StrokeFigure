using System;
using System.Collections.Generic;
using UnityEngine;

namespace StrokeFigure.Logging {
    internal sealed class AppLogger {
        private readonly List<LogRecord> records = new List<LogRecord>();

        internal void Append(double time, string modeName, Loggable entry) {
            LogFields logFields = new LogFields();
            entry.AppendLogFields(logFields);
            LogRecord logRecord = new LogRecord(
                time, modeName, entry.GetType().Name,
                logFields.Fields.ToArray()
            );
            this.records.Add(logRecord);
            Debug.Log(logRecord.ToString());
        }

        internal void SaveLogFiles() {
            throw new NotImplementedException();
        }

        internal void ClearLog() {
            this.records.Clear();
        }
    }
}
