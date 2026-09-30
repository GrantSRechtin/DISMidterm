using UnityEngine;

public class Step : MonoBehaviour
{
    [Header("Step Sound Clip")]
    [SerializeField] private AudioClip stepSound;

    public void PlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot(stepSound);
    }
}

