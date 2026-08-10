using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class CombiningStation : MonoBehaviour, IInteractable
    {
        [SerializeField] private Item requiredItem = default;
        [SerializeField] private Item outputItem = default;
        private ItemHolder itemHolder;

        private void Awake()
            => itemHolder = GetComponent<ItemHolder>();

        public Vector3 GetPosition()
            => transform.position;

        public Item Interact(Item input)
        {
            if (input == requiredItem)
                return outputItem;
            
            if (input == null)
                return itemHolder.GetItem();

            return input;
        }
    }
}
