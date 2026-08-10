using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class ItemHolder : MonoBehaviour
    {
        [SerializeField] private Transform holder = default;
        [SerializeField] private Item item = default;

        private void Start()
            => RefreshVisual();

        public void SetItem(Item item)
        {
            this.item = item;
            RefreshVisual();
        }

        public Item GetItem()
            => item;

        private void RefreshVisual()
        {
            if (holder.childCount > 0)
                Destroy(holder.GetChild(0).gameObject);

            if (item == null)
                return;

            Transform visual = Instantiate(item.graphic, holder).transform;
            visual.localPosition = Vector3.zero;
        }
    }
}
