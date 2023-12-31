using System.Collections;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
#if ENABLE_INPUT_SYSTEM
    [RequireComponent(typeof(PlayerInput))]
#endif
    public class InteractionController : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private StarterAssetsInputs _input;

        [SerializeField] private bool isColliding = false;
        [SerializeField] public bool isMoving = false;
        [SerializeField] private RotationController interactionScript;
        [SerializeField] private CheckMatch checkMatch;
        private void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
            _playerInput = GetComponent<PlayerInput>();


        }
        private void Update()
        {
            if (_input.interact && isColliding && !isMoving)
            {
                interactionScript.enabled = true;
                _input.interact= false;
                StartCoroutine(WaitTime());
            }
            if (_input.interact && checkMatch.canPlaceItem) 
            {
                checkMatch.OnPlaceItem();
            }
            
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Interactable"))
            {
                isColliding = true;
                interactionScript = other.GetComponent<RotationController>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Interactable"))
            {
                isColliding = false;
            }
        }
        public void SetMoving(bool moving)
        {
            isMoving = moving;
        }


        private IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(1f);
           // interactionScript.SetTargetRotation(90f);
        }
    }
}
