using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateMachine : MonoBehaviour
{
    public enum State
    {
        Idle,
        Running,
        Jumping,
        Dying
    }
    State state = State.Idle;

    Dictionary<State, Sprite[]> animations = new Dictionary<State, Sprite[]>();

    [SerializeField] Sprite[] idleAnimation;
    [SerializeField] Sprite[] runningAnimation;
    [SerializeField] Sprite[] jumpingAnimation;
    [SerializeField] Sprite[] dyingAnimation;

    [SerializeField] float animationFPS;
    SpriteRenderer sr;
    Coroutine coroutine;

    private void Awake()
    {
        animations.Add(State.Idle, idleAnimation);
        animations.Add(State.Running, runningAnimation);
        animations.Add(State.Jumping, jumpingAnimation);
        animations.Add(State.Dying, dyingAnimation);
    }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        coroutine = StartCoroutine(AnimationRoutine(animations[state]));
    }

    public void SetState(State nextState)
    {
        state = nextState;
        StopCoroutine(coroutine);
        coroutine = StartCoroutine(AnimationRoutine(animations[state]));
    }

    private IEnumerator AnimationRoutine(Sprite[] animation)
    {
        float animationTimer = 1f / animationFPS;
        int currentFrame = 0;
        while (true) { // endless loop coroutine
            currentFrame++;
            sr.sprite = animation[currentFrame];
            if (currentFrame >= animation.Length) {
                currentFrame = 0;
            }
            yield return new WaitForSeconds(animationTimer);
        }
    }
}
