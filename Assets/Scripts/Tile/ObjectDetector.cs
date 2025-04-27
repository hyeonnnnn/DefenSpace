using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private DefenserSpawner defenserSpawner;
    [SerializeField] private DefenserDataViewer defenserDataViewer;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        mainCamera = Camera.main;
    }
     
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
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
    }
}
