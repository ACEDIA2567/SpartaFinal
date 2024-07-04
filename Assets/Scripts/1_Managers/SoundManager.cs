using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    AudioSource[] audioSources = new AudioSource[(int)Define.Sounds.Count];
    public Dictionary<string,AudioClip> audioClips = new Dictionary<string, AudioClip> ();

    GameObject root = null;

    public void Init()
    {
        if(root == null)
        {
            root = GameObject.Find("@SoundRoot");
            if (root == null)
            {
                root = new GameObject { name = "@SoundRoot" };
                UnityEngine.Object.DontDestroyOnLoad(root);

                string[] soundTypeName = Enum.GetNames(typeof(Define.Sounds));
                for (int i = 0; i < (int)Define.Sounds.Count; i++)
                {
                    GameObject go = new GameObject { name = soundTypeName[i] };
                    if (go == null)
                        continue;
                    audioSources[i] = go.AddComponent<AudioSource>();
                    go.transform.parent = root.transform;
                }
                LoadClips();
//                audioSources[(int)Define.Sound.BGM].loop = true;
            }
        }
    }

    private void LoadClips()
    {
        string[] clipNames = Enum.GetNames (typeof(Define.Clips));
        for(int i=0; i<clipNames.Length; i++)
        {
            AudioClip clip = Managers.Resource.Load<AudioClip>($"Audio/Clips/{clipNames[i]}");
            if (clip == null) continue;
            AudioSource source = audioSources[i];
            source.clip = clip;
        }
    }
    public bool Play(Define.Sounds type, bool oneshot = false)
    {
        if(audioSources[(int)type])
        {
            if(!oneshot)
                audioSources[(int)type].Play();
            else
                audioSources[(int)type].PlayOneShot(audioSources[(int)type].clip);
            return true;
        }
        return false;
    }
    public void Stop(Define.Sounds type)
    {
        if (audioSources[(int)type])
        {
            audioSources[(int)type].Stop();
        }
    }

//    public bool Play(Sounds type, string path = "", float volume = 1.0f, float pitch = 1.0f)
//    {
//        if (string.IsNullOrEmpty(path))
//            return false;
//        AudioSource src = audioSources[(int)type];
//        if (path.Contains("Audio/") == false)
//            path = string.Format($"Audio/{path}");
//
//        src.volume = volume;
//        if(type == Sounds.BGM)
//        {
//            AudioClip clip = Managers.Resource.Load<AudioClip>(path);
////            AudioClip clip = audioClips[nameof(type)];
//            if (clip == null)
//                return false;
//
//            if(src.isPlaying)
//                src.Stop();
//
//            src.clip = clip;
//            src.pitch = pitch;
//            return true;
//        }
//        else
//        {
//            AudioClip clip = GetAudioClip(path);
//            //AudioClip clip = audioClips[nameof(type)];
//            if (clip == null)
//                return false;
//            src.pitch = pitch;
//
//            src.PlayOneShot(clip);
//            return true;
//        }
//        return false;
//    }
    private AudioClip GetAudioClip(string path)
    {
        AudioClip clip = null;
        if (audioClips.TryGetValue(path, out clip))
            return clip;
        clip = Managers.Resource.Load<AudioClip>(path);
        audioClips.Add(path, clip);
        return clip;
    }
}