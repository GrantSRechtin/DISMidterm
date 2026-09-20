using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class OneShotSpriteAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] frames;
    [SerializeField] private float frameRate = 12f;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(PlayAndDestroy());
    }

    private IEnumerator PlayAndDestroy()
    {
        float frameDelay = 1f / frameRate;

        foreach (Sprite frame in frames) {
            spriteRenderer.sprite = frame;
            yield return new WaitForSeconds(frameDelay);
        }

        Destroy(gameObject);
    }
}
