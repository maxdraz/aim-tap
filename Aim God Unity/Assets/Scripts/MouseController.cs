using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject bulletHolePrefab;
    public bool cursorVisible;
    public bool followMouse;

    public List<int> soundIndexes;

    private void Awake()
    {
       
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (followMouse)
        {
            transform.position = mousePos;
        }

        if (!cursorVisible)
        {
            Cursor.visible = false;
        }
       
        if (Input.GetMouseButtonDown(0))
        {            
            GameObject bulletHoleGO = ObjectPooler.SharedInstance.GetPooledObject("Bullet Hole");
            bulletHoleGO.transform.position = mousePos;
            bulletHoleGO.SetActive(true);
           // AudioManager.SharedInstance.PlayClip(0, "Gun Shot", false);
        }
    }
}
