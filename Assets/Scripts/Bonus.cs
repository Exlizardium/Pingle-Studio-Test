using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private float bonusPoints = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            GivePoints();
            Die();
        }
    }

    private void GivePoints()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerStats stats = Player.GetComponent<PlayerStats>();
        stats.points += bonusPoints;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
