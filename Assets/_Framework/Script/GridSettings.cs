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
}
