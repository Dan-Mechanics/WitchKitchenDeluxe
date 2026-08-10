using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class KeyboardInput : MonoBehaviour, IPlayerInput
    {
        [SerializeField] private EasyBinding forward = default;
        [SerializeField] private EasyBinding backward = default;
        [SerializeField] private EasyBinding left = default;
        [SerializeField] private EasyBinding right = default;
        [SerializeField] private EasyBinding interact = default;
        
        /// <summary>
        /// According to Unity space standard.
        /// </summary>
        public Vector3 GetMovementInput()
        {
            float z = 0f;
            float x = 0f;
            if (forward.IsHeld)
                z++;

            if (backward.IsHeld)
                z--;

            if (left.IsHeld)
                x--;

            if (right.IsHeld)
                x++;

            return new Vector3(x, 0f, z).normalized;
        }

        public bool InteractWasPressed()
            => interact.WasPressed;
    }
}
