using UnityEngine;
using UnityEngine.Events;

namespace WitchKitchenDeluxe
{
    public class AwakeTimer : MonoBehaviour
    {
        [SerializeField] private float waitTime = default;
        [SerializeField] private UnityEvent onTimerDone = default;

        private void Start()
            => Invoke(nameof(TimerDone), waitTime);

        private void TimerDone()
            => onTimerDone?.Invoke();
    }
}
