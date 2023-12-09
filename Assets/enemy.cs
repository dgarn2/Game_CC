using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int maxHealth = 4;
    int curHealth;
    public GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;

        a = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamage(int Damage){
        curHealth -= Damage;
        if(curHealth<=0){
            Die();
        }
    }

    void Die(){
        Debug.Log("dd");
        a.GetComponent<CharacterController2D>().Respawn();
        //audio

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
