using UnityEngine;
using System.Collections;

/**
 * Stores all grids settings
 */
public class GridSettings : MonoBehaviour {
	/**
	 * The width of a cell
	 */
	public float Spacing = 1.0f;

	/**
	 * Snaps a world position to the grid
	 * 
	 * @param worldPos The world position to snap on the grid
	 * @return The snapped position onto the grid
	 */
	public Vector3 SnapWorldPositionToGrid(Vector3 worldPos) {
		Vector3 gridPosition = new Vector3 ();

		gridPosition.x = (int)(worldPos.x / Spacing);
		gridPosition.y = worldPos.y;
		gridPosition.z = (int)(worldPos.z / Spacing);

		return gridPosition;
	}
}
