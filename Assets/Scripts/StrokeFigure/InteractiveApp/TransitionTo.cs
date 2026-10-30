using StrokeFigure.Logging;

namespace StrokeFigure.InteractiveApp {
    internal sealed class TransitionTo<NextMode> : Effect where NextMode : Mode, new() {
        internal override void ApplyTo(App app) {
            app.TransitionTo<NextMode>();
        }

        internal override void AppendLogFields(LogFields fields) {
            fields.Append("targetMode", typeof(NextMode).Name);
        }
    }
}
