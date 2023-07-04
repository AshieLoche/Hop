using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public bool speed, health;
    public int healthBoost;
    public float speedBoost;
    public int duration;
    private float baseMoveSpeed;
    public PlayerMovement player;

    
    // Start is called before the first frame update
    void Start()
    {
        baseMoveSpeed = player.moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (speed)
        {
            player.moveSpeed += speedBoost;
            StartCoroutine(BackToBaseSpeed());
        }
        if (health)
        {
            player.healthPoints += healthBoost;
        }
    }

    IEnumerator BackToBaseSpeed()
    {
        yield return new WaitForSeconds(duration);
        player.moveSpeed = baseMoveSpeed;
    }
}
