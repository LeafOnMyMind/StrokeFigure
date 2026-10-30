namespace StrokeFigure {
    internal abstract class Command : Effect {
        protected abstract void Modify(AppState state);

        internal sealed override void ApplyTo(App app) {
            this.Modify(app.CurrentState);
        }
    }
}
