using UnityEngine;

namespace WitchKitchenDeluxe
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController controller;
        private Transform heading;
        private Transform arrow;
        private IPlayerInput input;
        private Vector3 prevMovement;
        private float rotateSpeed;
        private float tolerance;
        private float speed;

        private void Awake()
        {
            input = GetComponent<IPlayerInput>();
            controller = GetComponent<CharacterController>();
            heading = new GameObject(nameof(heading)).transform;
            arrow = new GameObject(nameof(arrow)).transform;
        }

        private void Start()
        {
            var settings = Settings.main;
            prevMovement = Vector3.forward;
            heading.position = transform.position + prevMovement;
            speed = settings.Get<float>(nameof(speed));
            rotateSpeed = settings.Get<float>(nameof(rotateSpeed));
            tolerance = settings.Get<float>(nameof(tolerance));
        }

        private void Update()
        {
            Vector3 mov = input.GetMovementInput();
            mov = Vector3.ClampMagnitude(mov, 1f);
            if (mov.magnitude > tolerance)
            {
                heading.position = transform.position + mov;
                controller.Move(Time.deltaTime * speed * mov);
                prevMovement = mov;
            }

            heading.position = transform.position + prevMovement;
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
