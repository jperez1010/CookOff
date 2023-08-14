using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChefButtonData : MonoBehaviour
{
    public int id;
    public string chefName;
    public int cost;

    public Button button;

    void Start()
    {
        button = GetComponent<Button>();
        GetComponentInChildren<TMP_Text>().text = chefName;
    }

    public void DeactivateButton()
    {
        button.interactable = false;
    }
}
