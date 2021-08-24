using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectOptions : MonoBehaviour
{
   public GameObject FightButtons;
    public GameObject SelectButtons;
    public GameObject ItemButtons;

    void Start()
    {
        FightButtons.SetActive(false);
        ItemButtons.SetActive(false);
    }
    public void OnFight()
    {

        FightButtons.SetActive(true);
        ItemButtons.SetActive(false);
        SelectButtons.SetActive(false);
    }

    public void OnItems()
    {

        FightButtons.SetActive(false);
        ItemButtons.SetActive(true);
        SelectButtons.SetActive(false);
    }


}

