using System.Collections;
using UnityEngine;

public class SpriteAnimationCoroutine : MonoBehaviour
{
    [SerializeField] float animationFPS;
    [SerializeField] Sprite[] spriteAnimation;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(AnimationRoutine());
    }

    private IEnumerator AnimationRoutine()
    {
        float animationTimer = 1f / animationFPS;
        int currentFrame = 0;
        while (true) { // endless loop coroutine
            currentFrame++;
            sr.sprite = spriteAnimation[currentFrame];
            if (currentFrame >= spriteAnimation.Length) {
                currentFrame = 0;
            }
            yield return new WaitForSeconds(animationTimer);
        }
    }
}
