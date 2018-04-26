using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableEntity : MonoBehaviour, Idamageable {

    [SerializeField] int maxHealthPoints = 3;
    int currentHealthPoints;

    bool bHasBeenKilled = false;

	void Start () {
        currentHealthPoints = maxHealthPoints;
	}
    
    public void TakeDamage(int damageAmount)
    {
        currentHealthPoints -= damageAmount;
        if (currentHealthPoints <= 0)
        {
            currentHealthPoints = 0;
            if ( !bHasBeenKilled)
            {
                Die();
            }
        }
    }

    void Die()
    {
        gameObject.SetActive(false);

    }
}
