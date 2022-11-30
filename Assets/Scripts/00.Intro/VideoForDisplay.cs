using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoForDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.playOnAwake = false;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCameraAlpha = 0.5F;
        videoPlayer.url = "/Assets/StreamingAssets/intro1.mp4";
        videoPlayer.frame = 100;
        videoPlayer.isLooping = true;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.loopPointReached += EndReached;

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
    }
}
