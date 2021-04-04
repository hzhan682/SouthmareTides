using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision enemy)
    {
        if(enemy.gameObject.name == "PlayerObject")
        {
            enemy.gameObject.GetComponent<CharacterStats>().TakeDamage(1);
        }
    }
}
