using UnityEngine;

namespace Billiards
{
    public class BallController : MonoBehaviour
    {
        [Header("Ball Settings")]
        public int ballId;
        public bool isWhiteBall;
        public Vector3 initialPosition;

        [Header("Physics")]
        public float minimumVelocityForMovement = 0.02f;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
                rb.useGravity = false;
                rb.drag = 0.1f;
                rb.angularDrag = 0.1f;
            }

            initialPosition = transform.position;
        }

        public void ResetBall()
        {
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            transform.position = initialPosition;
        }

        public bool IsMoving()
        {
            if (rb == null)
            {
                return false;
            }

            return rb.velocity.magnitude > minimumVelocityForMovement;
        }

        public void ApplyShot(Vector3 direction, float force)
        {
            if (rb == null)
            {
                return;
            }

            rb.AddForce(direction.normalized * force, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pocket"))
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.OnBallPocketed(this);
                }

                gameObject.SetActive(false);
            }
        }
    }
}
