using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMoveMent = true;
    private bool cameraEvent = false;
    private bool returnCamera = false;
    private float returnTimer = 0;

    public float panSpeed = 30f;
    public float pansBorderThickness = 10f;
    public float minY = 10f;
    public float maxY = 80f;

    public Transform enemyTransform; // 카메라 LookAt 객체
    public Transform target; // 카메라 이동 위치
    public Transform returnTransform;


    void Update()
    {
        if (!cameraEvent)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                cameraEvent = true;
                return;
            }

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

            if (scroll > 0)
            {
                if (transform.position.y > minY)
                    transform.Translate(Vector3.down * panSpeed * 3 * Time.deltaTime, Space.World);
                else transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            }

            if (scroll < 0)
            {
                if (transform.position.y < maxY)
                    transform.Translate(Vector3.up * panSpeed * 3 * Time.deltaTime, Space.World);
                else transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            }
        }

        else
        {
            if (!returnCamera)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 1.5f);
                transform.LookAt(enemyTransform);

                returnTimer += Time.deltaTime;

                if (returnTimer > 4)
                    returnCamera = true;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, returnTransform.position, Time.deltaTime * 1.5f);
                transform.rotation = returnTransform.rotation;

                if (Vector3.Distance(transform.position,returnTransform.position) < 0.3f)
                    cameraEvent = false;
            }
        }
    }

    public void SetCameraEvent(bool _arg) { cameraEvent = _arg; }
    public bool GetCameraEvent() { return cameraEvent; }

}
