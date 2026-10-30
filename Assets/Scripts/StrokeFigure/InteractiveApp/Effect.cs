using StrokeFigure.Logging;

namespace StrokeFigure.InteractiveApp {
    internal abstract class Effect : Loggable {
        internal abstract void ApplyTo(App app);

        internal virtual void AppendLogFields(LogFields fields) { }

        void Loggable.AppendLogFields(LogFields fields) {
            this.AppendLogFields(fields);
        }
    }
}
