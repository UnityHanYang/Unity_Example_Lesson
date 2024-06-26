using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster, IHitable
{
    void Start()
    {
        maxHp = currenteHp = 100;
    }
}
