using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegressionUI : MonoBehaviour
{
    [SerializeField] private GameObject[] regressions;
    [SerializeField] private Player player;

    void Start()
    {
        player.regressionsLeft = player.regressionAmount;
        for (int i = 0; i < player.regressionsLeft; i++)
        {
            regressions[i].SetActive(true);
        }
    }

    void Update()
    {
        if(player.regressionsLeft==6)
        {
            regressions[6].SetActive(false);
        }
        if(player.regressionsLeft==5)
        {
            regressions[5].SetActive(false);
        }
        if(player.regressionsLeft==4)
        {
            regressions[4].SetActive(false);
        }
        if(player.regressionsLeft==3)
        {
            regressions[3].SetActive(false);
        }
        if(player.regressionsLeft==2)
        {
            regressions[2].SetActive(false);
        }
        if(player.regressionsLeft==1)
        {
            regressions[1].SetActive(false);
        }
        if(player.regressionsLeft==0)
        {
            regressions[0].SetActive(false);
        }
    }
}
