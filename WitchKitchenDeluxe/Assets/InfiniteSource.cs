using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class InfiniteSource : MonoBehaviour, IInteractable
    {
        private ItemHolder itemHolder;

        private void Awake()
            => itemHolder = GetComponent<ItemHolder>();

        public Vector3 GetPosition()
            => transform.position;

        public Item Interact(Item input)
        {
            if (input == null)
                return itemHolder.GetItem();

            return input;
        }
    }
}
