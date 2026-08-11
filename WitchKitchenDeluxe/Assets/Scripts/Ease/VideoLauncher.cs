using UnityEngine;
using UnityEngine.Video;

namespace WitchKitchenDeluxe
{
    public class VideoLauncher : MonoBehaviour
    {
        private void Start()
        {
            var path = System.IO.Path.Combine(Application.streamingAssetsPath, gameObject.name);
            var vid = GetComponent<VideoPlayer>();
            vid.url = path;
            print(path);
            vid.Play();
        }
    }
}
