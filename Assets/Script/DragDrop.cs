using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 _cursorPos;
    private Camera _cam;
    private GameObject _selectedObject;
    private Vector3 _originalPos;
    private string destinationTag = "DropArea";
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _selectedObject = null;

    }

    // Update is called once per frame
    void Update()
    {

        HitAtMousePos();
    }

    void HitAtMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // left click with no object selected
            if (_selectedObject == null)
            {
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.transform != null)
                    {
                        if (hit.collider.CompareTag("Drag_Cover"))
                        {
                            _originalPos = hit.collider.gameObject.transform.position;
                            _selectedObject = hit.collider.gameObject;
                            Cursor.visible = false;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            // left click when object selected
            else
            {

                Vector3 mousePosition = GetMousePosition();
                var rayDirection = mousePosition - _cam.transform.position;
                RaycastHit hitObject;
                if(Physics.Raycast(mousePosition, rayDirection, out hitObject))
                {
                    if(hitObject.transform.tag == destinationTag)
                    {
                        _selectedObject.transform.position = hitObject.transform.position;
                        _selectedObject.tag = "UnDraggable";
                    }
                    else
                    {
                        _selectedObject.transform.position = _originalPos;
                    }
                }
                _selectedObject = null;
                Cursor.visible = true;
            }
        }
        // no click when object selected (move with mouse)
        if (_selectedObject != null)
        {
            _selectedObject.transform.position = GetMousePosition();

        }
    }

    Vector3 GetMousePosition()
    {
        Vector3 mousePosition = _cam.ScreenToWorldPoint(new Vector3(
               Input.mousePosition.x,
               Input.mousePosition.y,
               Mathf.Abs(_cam.transform.position.z)
           ));
        return mousePosition;
    }
}
