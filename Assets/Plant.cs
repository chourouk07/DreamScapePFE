using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour, IInteractable
{
    public string _prompt = "Plant";
    [SerializeField] private Water _water;
    private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _waterBucket;
    [SerializeField] private float scaleMultiplier = 2f;
    public float yScaleMultiplier;
    float _maxScale;
    float yPos;
    public float offset = 0.15f;
    public float growDuration = 2f;
    Vector3 _initialScale;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log(_prompt);
        StartCoroutine(GrowAndShrinkPlant());
        return true;
    }

    private void Start()
    {
        _playerInventory = GameManager.instance.player.GetComponent<PlayerInventory>();
        _maxScale = transform.localScale.x * scaleMultiplier;
        yPos = transform.position.y + offset;
        _initialScale = transform.localScale;
    }

    IEnumerator GrowAndShrinkPlant()
    {
        if (_playerInventory.collectedItem == _waterBucket && _water.GetIsFilled())
        {
            Debug.Log("Grow Plant");
            Vector3 targetScale = new Vector3(_maxScale, _maxScale*yScaleMultiplier, _maxScale);
            float timer = 0f;

            // Grow
            while (timer < growDuration)
            {
                transform.localScale = Vector3.Lerp(_initialScale, targetScale, timer / growDuration);
                timer += Time.deltaTime;
                yield return null;
            }

            transform.localScale = targetScale; // Ensure it reaches the target scale
            //transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

            // Wait for a moment
            yield return new WaitForSeconds(3f);

            // Shrink
            timer = 0f;
            while (timer < growDuration)
            {
                transform.localScale = Vector3.Lerp(targetScale, _initialScale, timer / growDuration);
                timer += Time.deltaTime;
                yield return null;
            }

            transform.localScale = _initialScale; // Ensure it returns to the initial scale
            transform.position = new Vector3(transform.position.x, yPos - offset, transform.position.z);
        }
        else
        {
            Debug.Log("Plant is not watered");
        }
    }
}
