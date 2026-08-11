using UnityEngine;
using UnityEngine.Events;

namespace WitchKitchenDeluxe
{
    public class AnyKey : MonoBehaviour
    {
        [SerializeField] private UnityEvent anyKeyPressed = default;

        private void Update()
        {
            if (Input.anyKeyDown)
                anyKeyPressed?.Invoke();
        }
    }
}
