using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            DealDamage();
            Die();
        }
    }

    private void DealDamage()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerStats stats = Player.GetComponent<PlayerStats>();
        stats.health -= damage;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
