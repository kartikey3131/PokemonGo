using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndThrow : MonoBehaviour
{
    bool dragging = false;
    float distance;
    public float throwspeed;
    public float ArchSpeed;
    public float speed;
    
    void OnMouseDown()
    {
        //GameObject.FindGameObjectWithTag("Player")
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().velocity+= this.transform.forward * throwspeed;
        this.GetComponent<Rigidbody>().velocity+= this.transform.up * ArchSpeed;
        dragging = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = Vector3.Lerp(this.transform.position, rayPoint,speed*Time.deltaTime);
        }

    }
}
