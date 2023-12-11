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
#if ENABLE_INPUT_SYSTEM
        private PlayerInput _playerInput;
#endif
        private StarterAssetsInputs _input;

        [SerializeField] private bool isColliding = false;
        [SerializeField] public bool isMoving = false;
        [SerializeField] private RotationController interactionScript;
        [SerializeField] private CheckMatch checkMatch;
        private void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM 
            _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif

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
            interactionScript.SetTargetRotation(90f);
        }
    }
}
