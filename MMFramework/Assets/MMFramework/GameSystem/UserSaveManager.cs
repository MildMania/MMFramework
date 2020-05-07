using UnityEngine;

public abstract class UserSaveManager : MonoBehaviour
{
    [SerializeField] private bool _loadSave;
    [SerializeField] private int _startingLevelID;

    private const string USER_LEVELID_KEY = "LastCompletedLevelID";

    private void Awake()
    {
        PhaseBaseNode.OnTraverseStarted_Static += OnPhaseTraverseStarted;
    }

    private void Start()
    {
        if (_loadSave)
            LoadSave();
        else
        {
            int managerSceneID = GameManager.Instance.SceneManager.ManagerSceneID;

            GameManager.Instance.SceneManager.LoadSceneWithIndexOf(managerSceneID + _startingLevelID);
        }
    }

    private void OnDestroy()
    {
        PhaseBaseNode.OnTraverseStarted_Static -= OnPhaseTraverseStarted;
    }

    /// <summary>
    /// Check for the phase you would like to trigger save, Then call SaveCurLevel(int) method.
    /// </summary>
    /// <param name="phase"></param>
    protected abstract void OnPhaseTraverseStarted(PhaseBaseNode phase);

    protected void SaveCurLevel(int curLevelID)
    {
        PlayerPrefs.SetInt(USER_LEVELID_KEY, curLevelID);
        PlayerPrefs.Save();
    }

    private void LoadSave()
    {
        bool hasLevelSave = PlayerPrefs.HasKey(USER_LEVELID_KEY);

        if (!hasLevelSave)
            GameManager.Instance.SceneManager.LoadNextScene();
        else
        {
            int lastCompletedLevelID = PlayerPrefs.GetInt(USER_LEVELID_KEY);
            int managerSceneID = GameManager.Instance.SceneManager.ManagerSceneID;

            int nextSceneID = lastCompletedLevelID + managerSceneID + 1;

            GameManager.Instance.SceneManager.LoadSceneWithIndexOf(nextSceneID);
        }
    }
}
