using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate = .25f;
    public float weaponRange = 100f;
    public float hitForce = 150f;
    public Transform spawnPoint;
    public int gunDamage = 1;

    private Camera myCam;
    private WaitForSeconds shotDUration = new WaitForSeconds(.07f);
    private LineRenderer laserLine;
    private float nextFire;

    // Use this for initialization
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        myCam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(rayOrigin, myCam.transform.forward * weaponRange, Color.red);
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            RaycastHit hit;
            Ray shootingRay = new Ray(myCam.transform.position, Vector3.forward);
            laserLine.SetPosition(0, spawnPoint.position);
            if (Physics.Raycast(rayOrigin, myCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

                DeadBOx health = hit.collider.GetComponent<DeadBOx>();

                if (health != null)
                {
                    health.Damage(gunDamage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin+myCam.transform.forward * weaponRange);
            }


        }

    }


    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDUration;
        laserLine.enabled = false;
    }


}