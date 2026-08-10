using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class TrashCan : MonoBehaviour, IInteractable
    {
        public Vector3 GetPosition()
            => transform.position;
        
        public Item Interact(Item input)
            => null;
    }
}
