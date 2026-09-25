using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNumber : MonoBehaviour
{
    private TextMeshPro textMesh;
    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    void Start()
    {
        textMesh.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }
}
