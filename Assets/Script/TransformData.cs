using UnityEngine;

[CreateAssetMenu(fileName ="newTransformData",menuName = "Transform Data")]
public class TransformData : ScriptableObject
{
    public Vector2 position;
    public void ResetData()
    {
        position = Vector2.zero;
    }
}
