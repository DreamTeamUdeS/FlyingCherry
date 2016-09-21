using UnityEngine;
using System.Collections;

public class MapVisualSelector : MonoBehaviour {
    public GameObject m_cursorPrefab;

    private GameObject m_cursor;

	// Use this for initialization
	void Start () {
        m_cursor = Instantiate(m_cursorPrefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setVisible(bool value) {
        m_cursor.SetActive(value);
    }

    public void setPosition(Vector3 position) {
        m_cursor.transform.position = position;
    }
}
