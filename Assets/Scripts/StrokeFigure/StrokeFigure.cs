using UnityEngine;

namespace StrokeFigure {
    internal sealed class StrokeFigure : MonoBehaviour {
        private App app;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void CreateHost() {
            GameObject host = new GameObject("StrokeFigure App Host");
            host.AddComponent<StrokeFigure>();
        }

        private void Start() {
            this.app = new App();
            this.app.Start();
        }

        private void Update() {
            this.app.Update();
        }
    }
}
