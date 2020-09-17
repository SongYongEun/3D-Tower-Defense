using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMoveMent = true;
    private bool cameraEvent = false;
    private bool isEvent = false;

    public float panSpeed = 30f;
    public float pansBorderThickness = 10f;
    public float minY = 10f;
    public float maxY = 80f;

    public Transform enemyTransform;
    public Transform target; // 타겟 위치
    public float firingAngle = 45.0f;
    public float gravity = 7.8f;

    public Transform Projectile; // 발사체 위치


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
            if(!isEvent)
            {
                isEvent = true;
                StartCoroutine(SimulateProjectile());
            }
        }
    }


    IEnumerator SimulateProjectile()
    {
        Projectile.position = transform.position;

        float target_Distance = Vector3.Distance(Projectile.position, target.position);

        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);


        float flightDuration = target_Distance / Vx;

        //Projectile.rotation = Quaternion.LookRotation(target.position - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            
            transform.LookAt(enemyTransform);

            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime * 1.2f;

            yield return null;
        }

        isEvent = false;
        cameraEvent = false;
    }
}
