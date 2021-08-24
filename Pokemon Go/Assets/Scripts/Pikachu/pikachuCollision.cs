using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pikachuCollision : MonoBehaviour
{
    public float quickAttackValue = 20f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Charlizard")
        {
            CharLizardController.Instance.pikachuUsesQuickAttack(quickAttackValue, true);
            pikachuController.Instance.pikachumove = false;
            GameObject.Find("Pikachu").transform.position = GameObject.Find("MyPokemons").transform.position;
            GameObject.Find("Pikachu").GetComponent<Animator>().Play("pikashuIDLE");
            GameObject.Find("Charlizard").GetComponent<Animator>().Play("collisionWithPikashu");
            GameController.Instance.gameStatus = "enemyAttack";
        }
    }
}
