using UnityEngine;

namespace WitchKitchenDeluxe
{
    public interface IInteractable
    {
        Vector3 GetPosition();
        Item Interact(Item input);
    }
}
