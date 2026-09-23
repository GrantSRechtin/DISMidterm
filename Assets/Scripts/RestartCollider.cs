using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(DelayedRestart());
    }

    IEnumerator DelayedRestart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
