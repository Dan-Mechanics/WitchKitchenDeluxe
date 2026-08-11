using UnityEngine;
using UnityEngine.UI;

namespace WitchKitchenDeluxe
{
    [RequireComponent(typeof(Image))]
    public class FillImage : MonoBehaviour
    {
        [SerializeField] private Image image = default;

        public void SetFill(float amount)
            => image.fillAmount = amount;

        private void OnValidate()
            => image = GetComponent<Image>();
    }
}
