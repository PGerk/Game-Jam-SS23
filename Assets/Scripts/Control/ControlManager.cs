using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private GameObject currentObject, selectedObject;

    [Tooltip("Do not use more than 10 Items. The rest will be ignored.")]
    //[SerializeField] GameObject[] items = new GameObject[]{null, null, null, null, null, null, null, null, null, null};
    [SerializeField] GameObject[] items = new GameObject[10];
    private bool controlsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        selectedObject = items[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedObject = items[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedObject = items[1] ?? items[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedObject = items[2] ?? items[1] ?? items[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                selectedObject = items[3] ?? items[2] ?? items[1] ?? items[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                selectedObject = items[4] ?? items[3] ?? items[2] ?? items[1] ?? items[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                selectedObject = items[5] ?? items[4] ?? items[3] ?? items[2] ?? items[1] ?? items[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                selectedObject = items[6] ?? items[5] ?? items[4] ?? items[3] ?? items[2] ?? items[1] ?? items[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                selectedObject = items[7] ?? items[6] ?? items[5] ?? items[4] ?? items[3] ?? items[2] ?? items[1] ?? items[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                selectedObject = items[8] ?? items[7] ?? items[6] ?? items[5] ?? items[4] ?? items[3] ?? items[2] ?? items[1] ?? items[0];
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                selectedObject = items[9] ?? items[8] ?? items[7] ?? items[6] ?? items[5] ?? items[4] ?? items[3] ?? items[2] ?? items[1] ?? items[0];
            }

            if (Input.GetMouseButtonDown(0))
            {
                currentObject = Instantiate(selectedObject, GetMousePos(), Quaternion.identity);
            }

            if (Input.GetMouseButton(0))
            {
                DrawOnMousePosition();
            }

            if (Input.GetMouseButtonUp(0))
            {
                PlaceCurrentObject();
            }

        }
  
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1) && currentObject != null)
        {
            RotateObject(currentObject);
        }
    }

    private void DrawOnMousePosition()
    {
        currentObject.transform.position = GetMousePos();
    }

    private void PlaceCurrentObject()
    {
        currentObject.GetComponent<Collider2D>().enabled = true;
        currentObject.GetComponent<Rigidbody2D>().isKinematic = false;
        currentObject = null;
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    
    private void RotateObject(GameObject _obj)
    {
        _obj.transform.Rotate(new Vector3(0f, 0f, 3f));
    }

    public void DeactivateControls()
    {
        currentObject = null;
        selectedObject = null;
        controlsActive = false;
    }
}
