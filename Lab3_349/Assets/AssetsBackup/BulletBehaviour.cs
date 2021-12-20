using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float bulletSpeed;
    public float secondsUntilDestroyed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        secondsUntilDestroyed -= Time.deltaTime;

        if (secondsUntilDestroyed < 1)
        {
            transform.localScale *= secondsUntilDestroyed;
        }

        if (secondsUntilDestroyed < 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision thisCollision)
    {

        GameObject theirGameObject = thisCollision.gameObject;

        if (theirGameObject.GetComponent<EnemyBehaviour>() != null)
        {
            HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();
            if (theirHealthSystem != null)
            {
                theirHealthSystem.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

    }

}
