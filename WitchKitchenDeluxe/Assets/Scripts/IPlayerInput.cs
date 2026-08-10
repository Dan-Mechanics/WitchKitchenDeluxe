using UnityEngine;

namespace WitchKitchenDeluxe
{
    /// <summary>
    /// Because I might add controller support in future.
    /// </summary>
    public interface IPlayerInput
    {
        Vector3 GetMovementInput();
        bool InteractWasPressed();
    }
}