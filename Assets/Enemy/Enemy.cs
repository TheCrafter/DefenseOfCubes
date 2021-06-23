using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;

    public float startHealth = 100;
    [HideInInspector] public float health = 100;

    public int bounty = 50;

    public GameObject deathEffect;

    [Header("Unity stuff")]
    public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += bounty;
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }

    internal void Slow(float slowPct)
    {
        speed = startSpeed * (1f - slowPct);
    }
}
