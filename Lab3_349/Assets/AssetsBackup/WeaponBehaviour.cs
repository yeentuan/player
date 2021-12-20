using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float accuracy;
    public float secondsBetweenShots;
    public float numberOfProjectiles;
    float secondsSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShot = secondsBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        //Firing
        secondsSinceLastShot += Time.deltaTime;

    }

    public void Fire(Vector3 targetPosition)
    {
        if (secondsSinceLastShot >= secondsBetweenShots)
        {
            //Ready to fire
            for (
                int iterationCount = 0; //Declare a variable to keep track of how many iterations we've done
                iterationCount < numberOfProjectiles; //Set a limit for how high this variable can go
                iterationCount++ //Run this after each time we iterate - increase the iteration count
            )
            {
                GameObject newBullet = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
                //Offset that target position by a random amount, according to our inaccuracy
                float inaccuracy = Vector3.Distance(transform.position, targetPosition) / accuracy;
                Vector3 inaccuratePosition = targetPosition;
                inaccuratePosition.x += Random.Range(-inaccuracy, inaccuracy);
                inaccuratePosition.z += Random.Range(-inaccuracy, inaccuracy);
                newBullet.transform.LookAt(inaccuratePosition);
                secondsSinceLastShot = 0;
                newBullet.name = iterationCount.ToString();
            }
        }

    }

}
