using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController Instance { set; get; }
    public Text InfoText;
    public string gameStatus;
    public GameObject Buttons;
    public GameObject okButton;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        InfoText.text = "";
        okButton.SetActive(false);
    }

    public void GameStatusInfoBar()
    {
        switch(gameStatus)
        {

            case "enemyAppeared":
                {
                    InfoText.text = "A Wild CharLizard has appeared";
                    break;
                }

            case "enemyAttack":
                {
                    int p = Random.Range(0, 2);
                    if (p == 0)
                    {
                        InfoText.text = "CharLizard uses Fly Attack";
                        CharLizardController.Instance.Fly();
                        gameStatus = "";
                        GameStatusInfoBar();
                    }
                    else
                    {

                        InfoText.text = "CharLizard used Flame Thrower";
                        CharLizardController.Instance.FlameThrower();
                        gameStatus = "";
                        GameStatusInfoBar();
                    }
                    break;
                }

            case "ChoosePokemon":
                {
                    InfoText.text = "Ash Chooses PIKACHU";
                    break;
                }

            case "pikachuUsesGrowl":
                {
                    InfoText.text = "Pikachu used Tackle";

                    break;
                }

            case "pikachuUsesThunderShock":
                {
                    InfoText.text = "Pikachu used ThunderShock";
                    Buttons.SetActive(false);
                    okButton.SetActive(true);
                    break;
                }

            case "pikachuUsesThunderBolt":
                {
                    InfoText.text = "Pikachu used ThunderBolt";
                    break;
                }

            case "pikachuUsesTackle":
                {
                    InfoText.text = "Pikachu used Tackle";
                    Buttons.SetActive(false);
                    okButton.SetActive(true);
                    break;
                }
            case "fightHasStarted": 
              {
                    InfoText.text = "FIGHT";
                    break;
              }

            default:
                {
                    InfoText.text = "";
                    Buttons.SetActive(true);
                    okButton.SetActive(false);
                    break;
                }

        }
    }
}
