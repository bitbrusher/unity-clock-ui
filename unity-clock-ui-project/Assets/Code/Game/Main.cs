using UnityEngine;

namespace Code.Game
{
    [RequireComponent(typeof(InUnitySceneReferences))]
    public class Main : MonoBehaviour
    {
        private Game _game;

        private void Start()
        {
            var inUnitySceneReferences = GetComponent<InUnitySceneReferences>();

            _game = new Game(inUnitySceneReferences);
        }

        private void Update()
        {
            _game.Update(Time.deltaTime);
        }
    }
}