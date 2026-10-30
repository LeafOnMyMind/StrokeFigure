using StrokeFigure.InteractiveApp;
using StrokeFigure.Modes;
using UnityEngine;

namespace StrokeFigure {
    internal sealed class AppHost : MonoBehaviour {
        private App app;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void CreateHost() {
            GameObject host = new GameObject("StrokeFigure App Host");
            host.AddComponent<AppHost>();
        }

        private void Start() {
            EffectQueue startEffects = this.CreateStartEffects();
            this.app = new App(startEffects);
        }


        private EffectQueue CreateStartEffects() {
            EffectQueue startEffects = new EffectQueue();
            startEffects.Enqueue(new TransitionTo<Idle>());
            return startEffects;
        }

        private void Update() {
            this.app.Update();
        }
    }
}
