using UnityEngine;
using System.Collections;

/**
 * Stores all grids settings
 */
public class GridSettings : MonoBehaviour {
	public const int InfiniteSize = 0;

	/**
	 * The width of a cell
	 */
	public float CellWidth = 1.0f;

	/**
	 * The depth of a cell
	 */
	public float CellDepth = 1.0f;

	public int MaxWidth = InfiniteSize;
	public int MaxDepth = InfiniteSize;

	/**
	 * Snaps a world position to the grid
	 * 
	 * @param worldPos The world position to snap on the grid
	 * @return The snapped position onto the grid
	 */
	public Vector3 SnapWorldPositionToGrid(Vector3 worldPos) {
		Vector3 gridPosition = new Vector3 ();

		gridPosition.x = (int)(worldPos.x / CellWidth);
		gridPosition.y = worldPos.y;
		gridPosition.z = (int)(worldPos.z / CellDepth);

		return gridPosition;
	}
}
