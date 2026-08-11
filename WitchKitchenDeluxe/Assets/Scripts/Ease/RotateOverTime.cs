using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class RotateOverTime : MonoBehaviour
    {
        [SerializeField] private Vector3 rotation = default;

        private void Start()
        {
            transform.localEulerAngles = new Vector3(
                rotation.x != 0 ? Random.Range(0f, 360f) : 0f,
                rotation.y != 0 ? Random.Range(0f, 360f) : 0f,
                rotation.z != 0 ? Random.Range(0f, 360f) : 0f);
        }

        private void FixedUpdate()
            => transform.Rotate(rotation * Time.fixedDeltaTime, Space.World);
    }
}
