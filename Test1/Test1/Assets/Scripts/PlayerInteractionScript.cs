using UnityEngine;

public class PlayerInteractionScript : MonoBehaviour
{
    private Interactable _objectToInteract;

    public void SubscribeInteractable(Interactable obj)
    {
        _objectToInteract = obj;
    }

    public void UnsubscribeInteractable()
    {
        _objectToInteract = null;
    }

    public void InteractWithInteractable()
    {
        if (_objectToInteract == null)
        {
            Debug.Log("objectToInteract is null");
        }
        else
        {
            Debug.Log($"### OK: {_objectToInteract.gameObject.name}  ###");
        }
    }
}
