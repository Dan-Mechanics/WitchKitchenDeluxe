using UnityEngine;
using UnityEngine.UI;

namespace WitchKitchenDeluxe
{
    public class HealthDisplay : MonoBehaviour
    {
        private Image[] images;

        private void Awake()
        {
            images = new Image[transform.childCount];
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = transform.GetChild(i).GetComponent<Image>();
            }

        }
        public void DisplayHealth(int health)
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].color = i < health ? Color.white : Color.black;
            }
        }
    }
}
