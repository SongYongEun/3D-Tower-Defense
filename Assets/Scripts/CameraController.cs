using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMoveMent = true;

    public float panSpeed = 30f;
    public float pansBorderThickness = 10f;
    public float minY = 10f;
    public float maxY = 80f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMoveMent = !doMoveMent;

        if (!doMoveMent)
            return;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if(scroll > 0)
        {
            if(transform.position.y > minY)
                transform.Translate(Vector3.down * panSpeed * 10 * Time.deltaTime, Space.World);
        }

        if(scroll < 0)
        {
            if(transform.position.y < maxY)
                transform.Translate(Vector3.up * panSpeed * 10 * Time.deltaTime, Space.World);
        }
    }
}
