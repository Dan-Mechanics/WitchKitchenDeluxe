using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class ScenePersistent : MonoBehaviour
    {
        public void KeepInNextScene()
            => DontDestroyOnLoad(gameObject);
    }
}
