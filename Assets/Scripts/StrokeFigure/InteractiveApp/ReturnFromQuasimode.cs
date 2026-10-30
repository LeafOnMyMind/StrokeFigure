namespace StrokeFigure.InteractiveApp {
    internal sealed class ReturnFromQuasimode : Effect {
        internal override void ApplyTo(App app) {
            app.ReturnFromQuasimode();
        }
    }
}
