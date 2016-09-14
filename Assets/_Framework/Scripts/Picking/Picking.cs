using UnityEngine;
using System.Collections;

class PositionNotFound : System.Exception { }

public class Picking : MonoBehaviour {
    public int RayMaxDistance = 5000;

    public Vector3 GetWorldPosition(Vector3 mousePosition, Camera camera, int layerMask = 0xFFFFFF)
    {
        Ray ray =  camera.ScreenPointToRay(mousePosition);

        RaycastHit hits;
        
        if (Physics.Raycast(ray, out hits, RayMaxDistance, layerMask))
        {
            Vector3 distanceFromCamera = ray.direction * hits.distance;

            return distanceFromCamera + camera.transform.position;
        }

        throw new PositionNotFound();
    }
}
