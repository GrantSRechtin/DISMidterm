using System.Collections;
using UnityEngine;

public class Carpet : MonoBehaviour, IInteractable
{
    [Header("Objects hidden by the carpet")]
    [SerializeField] private GameObject[] hiddenGameObjects;
    
    [Header("Flipped carpet sprite")]
    [SerializeField] private Sprite flippedCarpet;

    [Header("Delay on use before carpet flips")]
    [SerializeField] private float waitTime;

    [Header("Object audio")]
    [SerializeField] private AudioClip carpetSound;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        foreach (GameObject hiddenObject in hiddenGameObjects)
        {
            hiddenObject.GetComponent<IHidden>().Hide();
        }
    }

    public void Interact()
    {
        GetComponent<AudioSource>().PlayOneShot(carpetSound);
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(UncoverDelay());
    }

    private void FlipCarpet()
    {
        foreach (GameObject hiddenObject in hiddenGameObjects)
        {
            hiddenObject.GetComponent<IHidden>().Show();
        }
        sr.sprite = flippedCarpet;
    }

    IEnumerator UncoverDelay()
    {
        yield return new WaitForSeconds(waitTime);
        FlipCarpet();
    }
}
