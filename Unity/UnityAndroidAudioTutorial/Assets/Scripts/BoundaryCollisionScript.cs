using UnityEngine;

namespace Assets.Scripts
{
    public class BoundaryCollisionScript : MonoBehaviour
    {
        public GameAudioControllerScript.AudioClips HitAudioClip;

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Ball"))
            {
                // Play our audio... Don't forget to cast HitAudioClip as an int
                GameAudioControllerScript.GameAudioController.PlayAudio((int)HitAudioClip);
            }
        }
    }
}
