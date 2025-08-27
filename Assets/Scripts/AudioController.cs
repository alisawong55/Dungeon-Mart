using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //[SerializeField]
    public static AudioController Instance;

    void Awake(){
        if (Instance == null){
            Instance = this;
        }
        else Destroy(gameObject);
    }

    public void CreateSFX(AudioClip clip, Vector3 position){
        GameObject impactSfxInstance = new GameObject();
        impactSfxInstance.transform.position = position;
        AudioSource source = impactSfxInstance.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();

        TimedSelfDestruct timedSelfDestruct = impactSfxInstance.AddComponent<TimedSelfDestruct>();
        timedSelfDestruct.LifeTime = clip.length;
    }
}
