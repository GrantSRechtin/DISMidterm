using UnityEngine;

public class PersistantMusic : MonoBehaviour
{

    [Header("Playlist")]
    [SerializeField] private AudioClip[] normalPlaylist;
    [SerializeField] private AudioClip[] secretPlaylist;

    private float normalPitch = 1;
    private float secretPitch = 0.5f;

    private float secretVolume = 0.8f;

    private AudioClip[] currentPlaylist;
    private static PersistantMusic instance;
    private int playlistIndex;
    private AudioSource audioSource;

    private void Awake()
    {
        currentPlaylist = normalPlaylist;
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
        audioSource.pitch = normalPitch != 0 ? normalPitch : audioSource.pitch;

        if (currentPlaylist.Length > 0)
        {
            PlayTrack(playlistIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && currentPlaylist.Length > 0)
        {
            NextTrack();
        }

        SecretPitchCheck();
    }

    private void SecretPitchCheck()
    {
        LevelController levelController = FindFirstObjectByType<LevelController>();
        if (levelController != null && levelController.IsSecretActive())
        {
            currentPlaylist = secretPlaylist;
            if (audioSource.pitch != secretPitch)
            {
                PlayTrack(playlistIndex);
            }

            audioSource.pitch = secretPitch != 0 ? secretPitch : audioSource.pitch;
            audioSource.volume = secretVolume != 0 ? secretVolume : audioSource.pitch;
        }
    }

    private void PlayTrack(int index)
    {
        audioSource.clip = currentPlaylist[index];
        audioSource.Play();
    }

    private void NextTrack()
    {
        playlistIndex = (playlistIndex + 1) % currentPlaylist.Length;
        PlayTrack(playlistIndex);
    }
}
