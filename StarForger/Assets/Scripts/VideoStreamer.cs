using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added Library
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoStreamer : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();

#if UNITY_WEBGL
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "BUV Splashscreen.mp4");
#endif

        StartCoroutine(PlayVideo());

        //Link up with another function and execute when that video end
        videoPlayer.loopPointReached += OnLoopPointReached;
    }

    private void OnLoopPointReached(VideoPlayer source)
    {
        RemoveBackground();
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return new WaitForSeconds(1.0f);
            break;
        }

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }

    void RemoveBackground()
    {
        rawImage.gameObject.SetActive(false);

        //Load to the next scene
        SceneManager.LoadScene(1);
    }
}