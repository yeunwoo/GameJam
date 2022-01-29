using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
     [SerializeField] GameObject AnglePrefab = null;
        private Camera _cam = null;
    // Start is called before the first frame update
    void Start()
    {
      _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAtMousePos();
    }

    void SpawnAtMousePos(){
        if(Input.GetMouseButtonDown(0)){
            // // Mouse.current.position.ReadValue()
            Vector3 position = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
            // Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            // RaycastHit hit;
            // if(Physics.Raycast(ray, out hit)){
            Instantiate(AnglePrefab, position, Quaternion.identity);
                
            // }

        }
    }
}
