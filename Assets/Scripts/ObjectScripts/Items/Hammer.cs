using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Hammer : MonoBehaviour, IInteractable, IItem, IHidden
{
    public void Interact()
    {
        GetComponent<Collider2D>().enabled = false;
        transform.rotation = quaternion.identity;
    }

    public void PutDown()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    public void Hide()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sortingLayerName = "Hidden";
    }

    public void Show()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
    }

    public void Swing()
    {
        StartCoroutine(SwingMotion());
    }

    IEnumerator SwingMotion()
    {
        Quaternion target = Quaternion.Euler(0f, 0f, 90f);
        for (int i = 0; i < 5; i++)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target, 0.4f);
            yield return new WaitForFixedUpdate();
        }

        for (int i = 0; i < 5; i++)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion.identity, 0.4f);
            yield return new WaitForFixedUpdate();
        }
    }

    void Awake(){}
    void Start(){}
    void Update(){}
    void FixedUpdate(){}
}
