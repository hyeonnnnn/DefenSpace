using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private DefenserSpawner defenserSpawner;
    [SerializeField] private DefenserDataViewer defenserDataViewer;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;
    private Transform hitTransform = null;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
     
    private void Update()
    {
        /*
        if (EventSystem.current.IsPointerOverGameObject() == true)
        {
            return;
        }
        */

        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                hitTransform = hit.transform;
                if (hit.transform.CompareTag("Tile"))
                {
                    defenserSpawner.SpawnDenfenser(hit.transform);
                }
                else if (hit.transform.CompareTag("Defenser"))
                {
                    defenserDataViewer.OnPanel(hit.transform);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (hitTransform == null || hitTransform.CompareTag("Defenser") == false)
            {
                defenserDataViewer.OffPanel();
            }
            hitTransform = null;
        }
    }
}
