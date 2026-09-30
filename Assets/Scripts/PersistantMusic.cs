using UnityEngine;

public class PersistantMusic : MonoBehaviour
{

    [Header("Playlist")]
    [SerializeField] private AudioClip[] playlist;
    private static PersistantMusic instance;
    private int playlistIndex;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.loop = false;

        if (playlist.Length > 0)
        {
            PlayTrack(playlistIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && playlist.Length > 0)
        {
            NextTrack();
        }
    }

    private void PlayTrack(int index)
    {
        audioSource.clip = playlist[index];
        audioSource.Play();
    }

    private void NextTrack()
    {
        playlistIndex = (playlistIndex + 1) % playlist.Length;
        PlayTrack(playlistIndex);
    }
}
