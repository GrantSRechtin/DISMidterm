using UnityEngine;

public class SpriteAnimationLoop : MonoBehaviour
{
    public float animationFPS;
    public Sprite[] spriteAnimation;
    SpriteRenderer sr;
    int currentFrame;
    float animationTimer;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        currentFrame = 0;
        animationTimer = 1f / animationFPS;
    }

    private void Update()
    {
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0) {
            animationTimer = 1f / animationFPS;
            currentFrame++;
            if(currentFrame >= spriteAnimation.Length) {
                currentFrame = 0;
            }
            sr.sprite = spriteAnimation[currentFrame];
        }
    }
}
