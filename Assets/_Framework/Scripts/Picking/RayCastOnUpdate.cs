using UnityEngine;
using System.Collections;

public class RayCastOnUpdate : MonoBehaviour {

    public Picking m_picking;
    public Camera m_camera;
    public LayerMask m_collisionLayerMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        try { 
            Vector3 position = m_picking.GetWorldPosition(Input.mousePosition, m_camera, m_collisionLayerMask);
            Debug.LogWarning("Object found at " + position.ToString());
        }
        catch (PositionNotFound e) {
            Debug.LogWarning("No object found");
        }

    }
}
