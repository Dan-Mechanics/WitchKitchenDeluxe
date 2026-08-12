using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class TagRequirement : MonoBehaviour
    {
        [SerializeField] private string requiredTag = default;

        private void Start()
        {
            GameObject tagFound = GameObject.FindWithTag(requiredTag);
            if (tagFound)
            {
                Destroy(tagFound);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
