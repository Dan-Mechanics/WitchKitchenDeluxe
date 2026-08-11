using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class CustomerRandomizer : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] renderers = default;
        [SerializeField] private GameObject[] accessories = default;

        private void Start()
        {
            Color color = Random.ColorHSV();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = color;
            }

            for (int i = 0; i < accessories.Length; i++)
            {
                if (Random.value > 0.5f)
                    Destroy(accessories[i]);
            }

            Destroy(this);
        }
    }
}
