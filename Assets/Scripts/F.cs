using System.Collections;
using UnityEngine;

public class F : MonoBehaviour
{

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.simulated = false;
    }

    public void Fall()
    {
        rb.simulated = true;
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
