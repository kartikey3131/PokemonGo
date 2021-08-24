using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharLizardCollision : MonoBehaviour
{
    public float flyAttackValue = 20f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pikachu")
        {
            Debug.Log("Hello");
            pikachuController.Instance.CharLizardUsesFlyAttack(flyAttackValue, true);
            CharLizardController.Instance.CharLizardGo = false;
            GameObject.Find("Charlizard").transform.position = GameObject.Find("CharizardPosition").transform.position;
            GameObject.Find("Charlizard").GetComponent<Animator>().Play("CharizardIDLE");
            GameObject.Find("Pikachu").GetComponent<Animator>().Play("attackFromCharizard");
        }
    }
}
