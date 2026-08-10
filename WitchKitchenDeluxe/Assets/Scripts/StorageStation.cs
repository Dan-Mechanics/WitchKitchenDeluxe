using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class StorageStation : MonoBehaviour, IInteractable
    {
        private ItemHolder itemHolder;

        private void Awake()
            => itemHolder = GetComponent<ItemHolder>();

        public Vector3 GetPosition()
            => transform.position;

        public Item Interact(Item input)
        {
            Item temp = itemHolder.GetItem();
            itemHolder.SetItem(input);
            return temp;
        }
    }
}
