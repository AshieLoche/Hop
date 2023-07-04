using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManagerScript : MonoBehaviour
{
    //Animator access our animator to play animation
    private Animator anim;
    public PlayerMovement player;
    public int trapDamage;
    public bool isPlayerOnTop;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsActive", true);
            isPlayerOnTop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("IsActive", false);
            isPlayerOnTop = false;
        }
    }

    public void PlayerDamage()
    {
        if(isPlayerOnTop)
            player.healthPoints -= trapDamage;
    }
}
