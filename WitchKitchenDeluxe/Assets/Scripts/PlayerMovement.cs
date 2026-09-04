using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController controller;
        private Transform heading;
        private Transform arrow;
        private IPlayerInput input;
        private float speed;
        private float rotateSpeed;
        private float tolerance;

        private void Awake()
        {
            input = GetComponent<IPlayerInput>();
            controller = GetComponent<CharacterController>();
            heading = new GameObject(nameof(heading)).transform;
            arrow = new GameObject(nameof(arrow)).transform;
        }

        private void Start()
        {
            var settings = Settings.Current;
            heading.position = transform.position + Vector3.forward;
            speed = settings.Get<float>(nameof(speed));
            rotateSpeed = settings.Get<float>(nameof(rotateSpeed));
            tolerance = settings.Get<float>(nameof(tolerance));
        }

        private void Update()
        {
            Vector3 mov = input.GetMovementInput();
            if (mov.magnitude > tolerance)
                heading.position = transform.position + mov;

            controller.Move(Time.deltaTime * speed * mov);
            controller.Move(Physics.gravity * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            arrow.position = transform.position;
            arrow.LookAt(heading);
            transform.rotation = Quaternion.Lerp(transform.rotation, arrow.rotation, rotateSpeed);
        }
    }
}
