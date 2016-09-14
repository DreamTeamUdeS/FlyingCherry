using UnityEngine;
using System.Collections;

public class GridPlane : MonoBehaviour {
	public GridSettings Settings;

	private Material m_material;

	// Use this for initialization
	void Start () {
		if (Settings == null) {
			GameObject settingsObj = GameObject.Find ("GridSettings");

			if (settingsObj) {
				Settings = settingsObj.GetComponent<GridSettings> ();
			}
		}

		Renderer renderer = gameObject.GetComponent<Renderer> ();
		if (renderer) {
			m_material = renderer.material;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Settings != null) {
			m_material.SetFloat ("_Spacing", Settings.Spacing);
		}
	}
}
