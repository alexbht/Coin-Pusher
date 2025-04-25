using UnityEngine;
using UnityEngine.EventSystems;

public class ImageClickHandler : MonoBehaviour, IPointerClickHandler
{
    public Camera cameraToActivate;

    public void OnPointerClick(PointerEventData eventData)
    {
        // D�sactiver toutes les cam�ras
        Camera[] allCameras = Camera.allCameras;
        foreach (Camera cam in allCameras)
            cam.gameObject.SetActive(false); // D�sactive l'objet complet

        // Activer la bonne cam�ra
        if (cameraToActivate != null)
        {
            cameraToActivate.gameObject.SetActive(true);
        }
    }
}
