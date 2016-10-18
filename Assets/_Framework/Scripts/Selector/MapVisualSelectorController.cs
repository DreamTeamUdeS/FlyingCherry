using UnityEngine;
using System.Collections;

public class MapVisualSelectorController : MonoBehaviour {

    public Picking m_picking;
    public Camera m_camera;
    public LayerMask m_collisionLayerMask;
    public GridSettings m_gridSettings;

    public MapVisualSelector m_cursorSelector;

    const float HEIGHT_OFFSET = 0.05f;
    
	// Update is called once per frame
	void Update () {
        Vector3 position;

        try
        {
            position = m_picking.GetWorldPosition(Input.mousePosition, m_camera, m_collisionLayerMask);

            position = m_gridSettings.SnapWorldPositionToGrid(position);
            
            position = new Vector3(position.x, HEIGHT_OFFSET, position.z);

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
