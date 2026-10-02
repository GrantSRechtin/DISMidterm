using System;
using System.Collections;
using UnityEngine;

public class EscalatedMusic : MonoBehaviour
{
    [SerializeField] private float startVolume = 0.1f;
    [SerializeField] private float maxVolume = 1f;
    [SerializeField] private float escalationTime = 12f;
    [SerializeField] private float initialDelay = 0f;

    private AudioSource audioSource;
    private bool started = false;

    void Start()
    {
        PersistantMusic.StopMusic();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = startVolume;
        audioSource.playOnAwake = false;

        StartCoroutine(StartMusic());
    }

    void Update()
    {
        if (started)
        {
            audioSource.volume = Mathf.MoveTowards(
                audioSource.volume,
                maxVolume,
                (maxVolume - startVolume) / escalationTime * Time.deltaTime);
        }
    }

    IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(initialDelay);
        started = true;
        audioSource.Play();
    }
}
