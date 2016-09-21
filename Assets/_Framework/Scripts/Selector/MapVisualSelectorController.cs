using UnityEngine;
using System.Collections;

public class MapVisualSelectorController : MonoBehaviour {

    public Picking m_picking;
    public Camera m_camera;
    public LayerMask m_collisionLayerMask;
    public GridSettings m_gridSettings;

    public MapVisualSelector m_cursorSelector;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position;

        try
        {
            position = m_picking.GetWorldPosition(Input.mousePosition, m_camera, m_collisionLayerMask);

            position = m_gridSettings.SnapWorldPositionToGrid(position);
            
            position = new Vector3(position.x + 0.5f, 0.05f, position.z - 0.5f);

            m_cursorSelector.setPosition(position);

            m_cursorSelector.setVisible(true);

            Debug.LogWarning("Position : " + position.ToString());
        }
        catch (PositionNotFound e)
        {
            Debug.LogWarning("No object found");

            m_cursorSelector.setVisible(false);
        }

    }
}
