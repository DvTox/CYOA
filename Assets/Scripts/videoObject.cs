using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "video{V$}", menuName = "videoObject")]
public class videoObject : ScriptableObject
{
    public VideoClip Video;
    public int ChoiceTime;
    public List<choice> choices;
}

[Serializable]
public class choice
{
    public string Text;
    public int NextVideo;
}
