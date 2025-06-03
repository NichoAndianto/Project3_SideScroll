using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    private int mylevelCurrent;
    public Button[] levelButtons;
    private  int sceneIndex;
    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        mylevelCurrent = GameManager.Instance.levelCurrent;
        //AddChangeSceneListeners();
        DisableLockedLevel();
        levelButtons[0].onClick.AddListener(() => GameManager.Instance.ChangeScene(1));
    }

    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {

            levelButtons[i].onClick.AddListener(() => GameManager.Instance.ChangeScene(i));
            
        }
    }
    private void DisableLockedLevel()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > mylevelCurrent)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
