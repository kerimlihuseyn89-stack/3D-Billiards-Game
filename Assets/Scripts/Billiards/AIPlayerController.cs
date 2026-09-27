using System.Collections;
using UnityEngine;

namespace Billiards
{
    public class AIPlayerController : MonoBehaviour
    {
        [Header("AI Setup")]
        public CueController cueController;
        public float minAIPower = 12f;
        public float maxAIPower = 28f;
        public float reactionDelay = 1.2f;

        public void ExecuteTurn()
        {
            StartCoroutine(PerformShotRoutine());
        }

        private IEnumerator PerformShotRoutine()
        {
            yield return new WaitForSeconds(reactionDelay);

            if (cueController == null)
            {
                yield break;
            }

            float power = Random.Range(minAIPower, maxAIPower);
            cueController.ShootAI(power);
        }
    }
}
