using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pikachuController : MonoBehaviour
{
    public static pikachuController Instance { set; get; }
    public bool pikachumove =false;
    public Image HpBar;
    public float Hp;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Charlizard")!=null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Charlizard").transform.position);
            //var qTo = Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Charlizard").transform.position - transform.position);
            //qTo = Quaternion.Slerp(transform.rotation, qTo, 10 * Time.deltaTime);
            //GetComponent<Rigidbody>().MoveRotation(qTo);
        }
        if(pikachumove)
        {
            transform.Translate(Vector3.forward*Time.deltaTime * 3f);
        }
    }

    public void Growl()
    {
        gameObject.GetComponent<Animator>().Play("Attack");
        GameController.Instance.gameStatus = "pikachuUsesTackle";
        GameController.Instance.GameStatusInfoBar();
        pikachumove = true;
    }

    public void ThunderShock()
    {
        GameController.Instance.gameStatus = "pikachuUsesThunderShock";
        GameController.Instance.GameStatusInfoBar();
        StartCoroutine(PikachuUsesThunderShock());
    }
    
    IEnumerator PikachuUsesThunderShock()
    {
        gameObject.GetComponent<Animator>().Play("electro");
        yield return new WaitForSeconds(1);
        CharLizardController.Instance.pikachuUsesThunderShock(30);
        GameController.Instance.gameStatus = "enemyAttack";

    }

    public void CharLizardUsesFlyAttack(float val, bool CharLizardCollision)
    {
        Hp -= val * 10;
        HpBar = GameObject.Find("MyHP").GetComponent<Image>();
        if (CharLizardCollision)
        {
            HpBar.fillAmount = (Hp / 100f);
            Debug.Log((Hp / 100f));
        }
    }

    public void CharLizardUsesFlameThrower(float val)
    {
        Hp -= val;
        HpBar = GameObject.Find("MyHP").GetComponent<Image>();
        HpBar.fillAmount = (Hp / 100f);
        Debug.Log((Hp / 100f));
    }


}
