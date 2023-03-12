using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoEnd : MonoBehaviour
{
    public VideoPlayer videoGlitch;
 void Awake()
 {
    videoGlitch = GetComponent<VideoPlayer>();
    videoGlitch.Play();
    videoGlitch.loopPointReached += CheckOver;
 }

 void CheckOver(VideoPlayer vp)
 {
    gameObject.SetActive(false);
 }

}
