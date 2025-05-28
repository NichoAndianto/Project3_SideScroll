using UnityEngine;

public class PlayerPositionHandle : MonoBehaviour
{
    #region Condition
    Vector2 playerCurrentPosition;
    [SerializeField] Vector2 currentCheckpointPosition;


    public void onCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
    }

    public void OnEnemy()
    {
        ChangePlayerPosition(currentCheckpointPosition);
    }
    public void OnFinish()
    {
        playerPositionData.ResetData();
    }

    #endregion


    #region SaveLoad
    public TransformData playerPositionData;
    private void LoadPosition()
    {
        transform.position = playerPositionData.position;
    }

    private void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }
    #endregion

    #region Instruction
    private void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    #endregion
    
    
}
    