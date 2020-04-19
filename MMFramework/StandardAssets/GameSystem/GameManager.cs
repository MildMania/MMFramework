using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();

            return _instance;
        }
    }

    public SceneManager SceneManager { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        SceneManager = new SceneManager(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

        SceneManager.LoadNextScene();
    }

    private void OnDestroy()
    {
        SceneManager.Dispose();
    }
}
