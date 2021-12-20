using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthSystem : MonoBehaviour
{


    [FormerlySerializedAs("health")] //We write this to tell Unity not to lose our data when we rename a variable. This was its old name
    public float maxHealth;
    
    float currentHealth;

    public GameObject healthBarPrefab;

    public GameObject deathEffectPrefab;

    HealthBar myHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //Create our health panel ON the canvas References.canvas
        GameObject healthBarObject = Instantiate(healthBarPrefab, References.canvas.transform);
        myHealthBar = healthBarObject.GetComponent<HealthBar>();

    }

    public void TakeDamage(float damageAmount)
    {

        if (currentHealth > 0)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                if (deathEffectPrefab != null)
                {
                    Instantiate(deathEffectPrefab, transform.position, transform.rotation);
                }
                Destroy(gameObject);

            }
        }

    }

    private void OnDestroy()
    {
        //Don't create anything in the ondestroy event - it's only for cleaning up after yourself
        if (myHealthBar != null)
        {
            Destroy(myHealthBar.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Make our healthbar reflect our health - 
        myHealthBar.ShowHealthFraction(currentHealth / maxHealth);
        //Make our healthbar follow us - move it to our current position
        myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 2);


    }
}
