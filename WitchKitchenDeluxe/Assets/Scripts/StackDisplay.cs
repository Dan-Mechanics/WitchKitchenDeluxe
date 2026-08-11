using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WitchKitchenDeluxe
{
    public class StackDisplay : MonoBehaviour
    {
        [SerializeField] private Image icon = default;
        [SerializeField] private TMP_Text count = default;

        public void SetStack(Stack stack)
        {
            icon.sprite = stack.item.icon;
            count.text = stack.count.ToString();
        }
    }
}
