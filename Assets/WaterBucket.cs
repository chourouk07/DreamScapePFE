
using UnityEngine;


namespace StarterAssets
{
    public class WaterBucket : MonoBehaviour, IInteractable
    {
        private PlayerInventory _playerInventory;
        string _prompt = "Water Bucket";
        string IInteractable.InteractionPrompt => _prompt;

        bool IInteractable.Interact(Interactor interactor)
        {
            Debug.Log(_prompt);
            CollectItem();
            return true;
        }
        private void Awake()
        {
            _playerInventory= GameManager.instance.player.GetComponent<PlayerInventory>();
        }
        void CollectItem()
        {
            _playerInventory.PickItem(gameObject);
            gameObject.SetActive(false);
        }

        
    }
}
