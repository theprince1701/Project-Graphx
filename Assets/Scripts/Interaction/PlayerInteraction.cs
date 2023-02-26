using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Image interactCrosshair;

    [SerializeField] private float interactRange;

    private IInteractable _currentInteractable;

    private void Update()
    {
        if (_currentInteractable != null && Input.GetMouseButtonDown(0))
        {
            _currentInteractable.ButtonInteract();
        }
        
        if (!Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, interactRange))
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.StopLookAt();
                interactCrosshair.color = Color.white;
            }
            
            return;
        }


        if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            interactable.LookAt();
            interactCrosshair.color = Color.red;
            _currentInteractable = interactable;
        }
        else
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.StopLookAt();
                interactCrosshair.color = Color.white;
            }
        }
    }
}
