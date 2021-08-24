using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharLizardController : MonoBehaviour
{
    public static CharLizardController Instance { set; get; }
    public bool CharLizardFly=false;
    public bool CharLizardGo = false;
    public float Hp = 100;
    public Image HpBar;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //Fly();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Pikachu")!=null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Pikachu").transform.position);
        }
        if (CharLizardFly)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 1f);
        }

        if(CharLizardGo)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 2f);
        }

    }
    public void Fly()
    {
        CharLizardFly = true;
        StartCoroutine(WaitForFlyAttack());
    }

    IEnumerator WaitForFlyAttack()
    {
        yield return new WaitForSeconds(1f);
        CharLizardFly = false;
        yield return new WaitForSeconds(1f);
        //gameObject.GetComponent<Animator>().Play("flyAttack");
        CharLizardGo = true;
    }

    public void FlameThrower()
    {
        StartCoroutine(CharLizardUsesFlameThrower());
    }

    IEnumerator CharLizardUsesFlameThrower()
    {
        gameObject.GetComponent<Animator>().Play("flamethrower");
        yield return new WaitForSeconds(1);
        pikachuController.Instance.CharLizardUsesFlameThrower(30f);
        GameController.Instance.gameStatus = "";

    }

    public void pikachuUsesQuickAttack(float val,bool pikachuCollision)
    {
        Hp -= val*10;
        HpBar = GameObject.Find("EnemyHP").GetComponent<Image>();
        if(pikachuCollision)
        {
            HpBar.fillAmount = (Hp / 100f);
            Debug.Log((Hp / 100f));
        }
    }

    public void pikachuUsesThunderShock(float val)
    {
        Hp -= val;
        HpBar = GameObject.Find("EnemyHP").GetComponent<Image>();
        HpBar.fillAmount = (Hp / 100f);
        Debug.Log((Hp / 100f));
    }
}
