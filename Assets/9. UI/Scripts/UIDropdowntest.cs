using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDropdowntest : MonoBehaviour
{
    private Dropdown dropdown;

    private void Awake()
    {
        dropdown = GetComponent<Dropdown>();

    }

    public void OnDropdownValueChange(int value)
    {
        print($"{dropdown.options[value].text} selected.");
                
    }

    private char charTemp = 'E';
    public void OnAddOptionButtonClick()
    {
        charTemp =  (char)((int)charTemp + 1);
        string optionName = $"Option {charTemp}";

        Dropdown.OptionData data = new Dropdown.OptionData();
        data.text = optionName;

        dropdown.options.Add(data);
    }
}
