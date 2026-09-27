using UnityEngine;

namespace Billiards
{
    public class CueController : MonoBehaviour
    {
        [Header("References")]
        public BallController whiteBall;
        public Transform cuePivot;
        public Transform cueAimPoint;
        public float shotPower = 20f;
        public float maxShotPower = 35f;
        public float shotChargeSpeed = 1.5f;

        [Header("Input")]
        public KeyCode shootKey = KeyCode.Space;

        private float currentCharge = 0f;
        private bool isCharging = false;

        private void Update()
        {
            if (whiteBall == null || GameManager.Instance == null)
            {
                return;
            }

            if (GameManager.Instance.currentMode == GameMode.VsAI && GameManager.Instance.currentPlayer == 2)
            {
                return;
            }

            if (Input.GetKey(shootKey))
            {
                isCharging = true;
                currentCharge = Mathf.Clamp(currentCharge + shotChargeSpeed * Time.deltaTime, 0f, maxShotPower);
            }

            if (Input.GetKeyUp(shootKey) && isCharging)
            {
                Shoot();
                isCharging = false;
                currentCharge = 0f;
            }
        }

        public void Shoot()
        {
            if (whiteBall == null)
            {
                return;
            }

            Vector3 direction = (cueAimPoint.position - whiteBall.transform.position).normalized;
            whiteBall.ApplyShot(direction, Mathf.Clamp(currentCharge * shotPower, 10f, maxShotPower));
            GameManager.Instance.OnShotCompleted();
        }

        public void ShootAI(float forceMultiplier)
        {
            if (whiteBall == null)
            {
                return;
            }

            Vector3 direction = (cueAimPoint.position - whiteBall.transform.position).normalized;
            whiteBall.ApplyShot(direction, Mathf.Clamp(forceMultiplier * shotPower, 10f, maxShotPower));
            GameManager.Instance.OnShotCompleted();
        }
    }
}
