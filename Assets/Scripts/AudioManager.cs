using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance = null;
    AudioSource audioSource;

    public AudioClip snareClip, kickClip;

    void Awake()
    {
        if (instance == null) instance = this;
    }

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void PlaySnare()
    {
        audioSource.PlayOneShot(snareClip);
    }

    public void PlayKick()
    {
        audioSource.PlayOneShot(kickClip);
    }
}
