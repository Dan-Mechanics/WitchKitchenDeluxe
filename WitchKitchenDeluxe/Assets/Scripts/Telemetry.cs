using UnityEngine;
using TMPro;

namespace WitchKitchenDeluxe
{
    [RequireComponent(typeof(TMP_Text))]
    public class Telemetry : MonoBehaviour
    {
        [SerializeField] private TMP_Text text = default;

        private void Start()
            => Application.targetFrameRate = EasySettings.Current.Get<int>(nameof(Application.targetFrameRate));

        private void Update()
            => text.text = Mathf.Round(1f / Time.smoothDeltaTime).ToString();

        private void OnValidate()
            => text = GetComponent<TMP_Text>();
    }
}
