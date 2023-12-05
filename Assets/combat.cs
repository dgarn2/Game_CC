using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attckDamage = 40;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)){
            Debug.Log("f");
            Attack();
        }
    }


    void Attack(){

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("hit"+enemy.name);
            enemy.GetComponent<enemy>().TakeDamage(attckDamage);


        }
    }

    void onDrawGizmosSelected()
    {
        if( attackPoint == null){
            Debug.Log("null");
            return;
        }
        Debug.Log("1");
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

  }  


