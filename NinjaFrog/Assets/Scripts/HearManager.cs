using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HearManager : MonoBehaviour
{
    int h =20;
    [SerializeField]
    private TextMeshProUGUI hearts;


    private void Start()
    {
        RefreshHearts();
    }

    void RefreshHearts()
    {
        hearts.text = "" + h;
    }
    public void MinusHearts(int HeartsToMinus)
    {
        h -= HeartsToMinus;
        RefreshHearts();
    }

}
