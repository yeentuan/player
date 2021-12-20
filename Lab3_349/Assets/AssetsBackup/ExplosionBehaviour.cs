using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{

    public float secondsToExist;
    float secondsWeveBeenAlive;

    void Start()
    {
        secondsWeveBeenAlive = 0;
    }

    private void FixedUpdate()
    {
        secondsWeveBeenAlive += Time.deltaTime;

        float lifeFraction = secondsWeveBeenAlive / secondsToExist;
        Vector3 maxScale = Vector3.one * 5;
        transform.localScale = Vector3.Lerp(Vector3.zero, maxScale, lifeFraction);

        if (secondsWeveBeenAlive >= secondsToExist)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Look for a health system on the thing we collided with
        HealthSystem theirHealthSystem = other.gameObject.GetComponent<HealthSystem>();
        if (theirHealthSystem != null)
        {
            //If we found one, give it a lot of damage
            theirHealthSystem.TakeDamage(10);
        }
    }

}
