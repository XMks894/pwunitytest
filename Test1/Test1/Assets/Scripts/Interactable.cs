using UnityEngine;

public class Interactable : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private const float MAX_DISTANCE_TO_PLAYER = 1.5f;

    private PlayerInteractionScript _player;
    private Vector3 _playerPosition;

    public virtual void Interact()
    {
        _player.InteractWithInteractable();
    }

    public bool CanInteract()
    {
        if(_player == null)
        {
            Debug.Log("Can't interact with player");
            return false;
        }

        var result = Vector3.Distance(_playerPosition, transform.position);

        Debug.Log($"### distance = {result}");

        if(result <= MAX_DISTANCE_TO_PLAYER) return true;

        Debug.Log("Can't interact with player");

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag(PLAYER_TAG)) return;

        _playerPosition = collision.gameObject.GetComponent<Transform>().position;
        _player = collision.gameObject.GetComponent<PlayerInteractionScript>();
        _player.SubscribeInteractable(this);
    }

    private void OnCollisionExit(Collision collision)
    {
        if(!collision.gameObject.CompareTag(PLAYER_TAG)) return;

        _player.UnsubscribeInteractable();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(CanInteract()) Interact();
        }
    }
}
