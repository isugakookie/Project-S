using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
{
    
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        chp = 10;
        mp = 6;
        cmp = 6;
        spe = 1;
        ran = 5;
        dmg = 6;
        mdmg = 2;
        def = 10;
        mdef = 8;
        lvl = 0;
        sprite = GameObject.Find("Knight");
        //weapon = ;
        //wa1 = ;
        //wa2 = ;
        //wa3 = ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
