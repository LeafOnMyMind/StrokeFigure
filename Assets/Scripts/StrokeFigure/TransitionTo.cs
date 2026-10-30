namespace StrokeFigure {
    internal sealed class TransitionTo<NextMode> : Effect where NextMode : Mode, new() {
        internal override void ApplyTo(App app) {
            app.TransitionTo<NextMode>();
        }
    }
}
