using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxhp;
    public Text hplabel;
    private int currenthp;
    public int startingcoins;
    public Text coinslabel;
    public Text coinslabel2;
    public Text maxhealthlbl;
    public Text healthshoplbl;
    private int currentcoins;
    // Start is called before the first frame update
    void Start()
    {
        currenthp = maxhp;
        currentcoins = startingcoins;
        UpdateGUI();
    }
    void UpdateGUI()
    {
        hplabel.text = currenthp.ToString();
        coinslabel.text = currentcoins.ToString();
        coinslabel2.text = currentcoins.ToString();
        healthshoplbl.text = currenthp.ToString();
        maxhealthlbl.text = maxhp.ToString();
    }

    // Update is called once per frame
    public void Alterhealth(int amount)
    {
        currenthp += amount;
        currenthp = Mathf.Clamp(currenthp, 0, maxhp);
        UpdateGUI();
    }
    public void AlterCoins(int amount)
    {
        currentcoins += amount;
        currentcoins = Mathf.Clamp(currentcoins, 0, 10000);
        UpdateGUI();
    }
    public void ChangespeedPlayer()
    {
        PlayerMovement player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (currentcoins >= 100)
        {
            currentcoins -= 100;
            player.Changespeed();
        }
        UpdateGUI();
    }
    public void Heal()
    {
        if (currentcoins >= 100)
        {
            currentcoins -= 100;
            currentcoins = Mathf.Clamp(currentcoins, 0, 10000);
            currenthp = maxhp;
        }
        UpdateGUI();
    }
    public void AlterMaxhealth()
    {
        if (currentcoins >= 100)
        {
            currentcoins -= 100;
            maxhp = maxhp + 10;
        
        }
        UpdateGUI();
    }


}
