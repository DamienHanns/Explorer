using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] Transform forwardDirecitionAssist;
    [SerializeField] Projectile shot;
    [SerializeField] float projectileSpeed;
    [SerializeField] float shotsPerSecond;
    [SerializeField] int baseDamage = 1;
    float timeBetweenShots, nextShotTime;

    private void Start()
    {
        CalculateShotTiming();
        //TODO have a radius from which all the shots come out, introducing fun randomness
    }

    void CalculateShotTiming()
    {
        nextShotTime = 0.0f;
        timeBetweenShots = 1 / shotsPerSecond;
    }

    public void UseWeapon()
    {
        if (Time.time > nextShotTime)
        {
            Vector2 forward = CalculateForwardVector();
            Projectile newProjectile = Instantiate(shot, transform.position, transform.rotation) as Projectile;
            newProjectile.SetForwardVecocity(forward, projectileSpeed);
            newProjectile.SetDamge(baseDamage);

            nextShotTime = Time.time + timeBetweenShots;
        }
    }

    Vector2 CalculateForwardVector()
    {
        return (forwardDirecitionAssist.position - transform.position);
    }
}
