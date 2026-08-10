using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class PitchOverTime : MonoBehaviour
    {
        private AudioSource source;
        private float pitchScaling;
        private float startingPitch;
        private float maxPitch;

        private void Awake()
            => source = GetComponent<AudioSource>();

        private void Start()
        {
            var easySettings = EasySettings.Current;
            pitchScaling = easySettings.Get<float>(nameof(pitchScaling));
            startingPitch = easySettings.Get<float>(nameof(startingPitch));
            maxPitch = easySettings.Get<float>(nameof(maxPitch));
        }

        private void FixedUpdate()
        {
            float pitch = Mathf.Min(startingPitch + Time.time * pitchScaling, maxPitch);
            source.pitch = pitch;
        }
    }
}
