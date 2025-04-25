using UnityEngine;
using UnityEngine.EventSystems;

public class ImageClickHandler : MonoBehaviour, IPointerClickHandler
{
    public Camera cameraToActivate;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Désactiver toutes les caméras
        Camera[] allCameras = Camera.allCameras;
        foreach (Camera cam in allCameras)
            cam.gameObject.SetActive(false); // Désactive l'objet complet

        // Activer la bonne caméra
        if (cameraToActivate != null)
        {
            cameraToActivate.gameObject.SetActive(true);
        }
    }
}
