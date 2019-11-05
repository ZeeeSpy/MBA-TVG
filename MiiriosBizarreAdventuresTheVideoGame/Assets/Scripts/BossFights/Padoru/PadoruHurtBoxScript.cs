using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadoruHurtBoxScript : MonoBehaviour, Shootable
{
    private int HP = 30;
    public GameObject HPBAR;
    public GameObject PadoruParent;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetShot()
    {
        HP--;
        HPBAR.transform.localScale = new Vector3(HP*2, 2, 0.5f);
        if (HP < 0)
        {
            Destroy(PadoruParent);
        }
    }
}
