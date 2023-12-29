using UnityEngine;
#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
#if ENABLE_INPUT_SYSTEM 
    [RequireComponent(typeof(PlayerInput))]
#endif

    public class PlayerSlowTime : MonoBehaviour
    {
        [Header("Player Special Ability")]
        [Tooltip("Time Dilation factor that affects the moving objects")]
        public float TimeDilationFactor = 0.2f;
        [Tooltip("The duration of the Special Ability")]
        public float SpecialAbilityDuration = 2.0f;
        [Tooltip("Time required to pass before beign able to use special ability again")]
        public float SpecialAbilityTimeout = 1.0f;

        //array conatains objects affected with slow motion
       [SerializeField] private GameObject[] movingObjects; 


        // timeout deltatime
        private float _specialAbilityTimeout;
        private float _specialAbilityDuration;

#if ENABLE_INPUT_SYSTEM 
        private PlayerInput _playerInput;
#endif
        private StarterAssetsInputs _input;
        private void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM 
            _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif
            //reset timeout
            _specialAbilityTimeout = SpecialAbilityTimeout;
            _specialAbilityDuration= SpecialAbilityDuration;

            //movingObjects = GameObject.FindGameObjectsWithTag("MovingObjects");
        }

        private void Update()
        {
            ToggleTimeDilation();
        }

        private void ToggleTimeDilation()
        {
            movingObjects = GameObject.FindGameObjectsWithTag("MovingObjects");
            if (_input.specialAbility && _specialAbilityTimeout > 0 && _specialAbilityDuration > 0)
            {
                SlowDownMovingObjects();
                _specialAbilityDuration -= Time.deltaTime;
            }
            else
            {
                ResetMovingObjects();
                _specialAbilityTimeout -= Time.deltaTime;
                if (_specialAbilityTimeout <= 0)
                {
                    _specialAbilityTimeout = SpecialAbilityTimeout;
                    _specialAbilityDuration = SpecialAbilityDuration;
                }
                _input.specialAbility = false;
            }
        }

        void SlowDownMovingObjects()
        {
           
            foreach (GameObject obj in movingObjects)
            {
                MovingPlatform movingPlatform = obj.GetComponent<MovingPlatform>();
                movingPlatform.OnSlowed();
            }
        }

        void ResetMovingObjects()
        {
            foreach (GameObject obj in movingObjects)
            {
                
                MovingPlatform movingPlatform = obj.GetComponent<MovingPlatform>();
                movingPlatform.OnEndSlowed();
            }
        }

    }
}
