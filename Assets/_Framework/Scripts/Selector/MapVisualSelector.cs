using UnityEngine;
using System.Collections;

public class MapVisualSelector : MonoBehaviour {
    public GameObject m_cursorPrefab;

    private GameObject m_cursor;
    private Vector3 m_offset = new Vector3(0.5f, 0.0f, 0.5f);

	// Use this for initialization
	void Start () {
        m_cursor = Instantiate(m_cursorPrefab);
	}

    public void setVisible(bool value) {
        m_cursor.SetActive(value);
    }

    public void setPosition(Vector3 position) {
        m_cursor.transform.position = position + m_offset;
    }

    public void setOffset(Vector3 offset) {
        m_offset = offset;
    }
}
