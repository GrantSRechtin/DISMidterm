using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNumber : MonoBehaviour
{
    [SerializeField] private string levelLabel;
    [SerializeField] private bool overrideLevelLabel = false;

    private TextMeshPro textMesh;
    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    void Start()
    {
        if (overrideLevelLabel)
        {
            textMesh.text = levelLabel;
        }
        else
        {
            textMesh.text = SceneManager.GetActiveScene().buildIndex.ToString();
        }
    }
}
