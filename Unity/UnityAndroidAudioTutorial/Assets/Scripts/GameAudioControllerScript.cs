using System.Diagnostics;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameAudioControllerScript : MonoBehaviour
    {
        private static GameAudioControllerScript _gameAudioController;

        // DO NOT add && UNITY_EDITOR here. You WILL get an ERROR!!!
#if UNITY_ANDROID
        private AndroidJavaClass _androidJavaClass;
        private AndroidJavaObject _androidJavaObject;
#endif

#if UNITY_EDITOR
        public GameObject EditorAudio;
        public AudioClip[] Clips;

        private GameObject _editorGameAudio;
#endif

        public static GameAudioControllerScript GameAudioController
        {
            get { return _gameAudioController; }
        }

        // Use this for initialization
        void Awake()
        {
            // We perform a check to see if there is an instance and if
            // there isn't, we create one and set it to this specific instance
            // of this specific object
            if (GameAudioController == null)
            {
                // This persists the object through scene changes
                DontDestroyOnLoad(gameObject);
                // Set the singleton to this instance of this object
                _gameAudioController = this;
            }
            else if (GameAudioController != this)
            {
                // If there is another instance of this object, we simply
                // destroy it because there can be only one!
                Destroy(gameObject);
            }

            // Initialize the audio objects
            initAudio();
        }

        // This will be called from Awake()
        private void initAudio()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _androidJavaClass = new AndroidJavaClass("com.rf3studios.tutoriallibrary.TutorialActivity");
            _androidJavaObject = _androidJavaClass.GetStatic<AndroidJavaObject>("ctx");
#endif

#if UNITY_EDITOR
            _editorGameAudio = Instantiate(EditorAudio, transform.position, Quaternion.identity) as GameObject;
#endif
        }

        // This will be called from wherever we need it in our scripts
        public void PlayAudio(int audioId)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            PlayAndroidAudio(audioId);
#endif

#if UNITY_EDITOR
            PlayEditorAudio(audioId);
#endif
        }

#if UNITY_EDITOR
        private void PlayEditorAudio(int audioId)
        {
            _editorGameAudio.GetComponent<AudioSource>().clip = Clips[audioId];
            _editorGameAudio.GetComponent<AudioSource>().Play();
        }
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        private void PlayAndroidAudio(int audioId)
        {
            int _audioId = _androidJavaObject.Call<int>("playAudio", new object[] { audioId, false });
        }
#endif

        // Audio clips that we will reference and will coorespond to the indexes that
        // we set in our arrays
        // Audio01 == 0, Audio02 == 1, etc..
        public enum AudioClips
        {
            Audio01, Audio02, Audio03
        }
    }
}
