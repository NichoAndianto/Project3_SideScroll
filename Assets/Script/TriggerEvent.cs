using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{

    public enum TypeTag
    {
        Player,
        Trap,
        Enemy,
        Checkpoint,
        Finish,
        Trigger,
    }
    public UnityEvent<GameObject> OnTrigger;
    public TypeTag targetTag;
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.tag == targetTag.ToString())
        {
            OnTrigger?.Invoke(col.gameObject);
        }
        
    }
}
