using UnityEngine;
using UnityEngine.SceneManagement;

namespace WitchKitchenDeluxe
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void Switch(string sceneName)
            => SceneManager.LoadScene(sceneName);
    }
}
