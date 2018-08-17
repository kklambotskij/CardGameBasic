using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : PlayerController  {

    public HandModel model;

    private void Awake()
    {
        model = GetComponent<HandModel>();
    }

    public void getCard()
    {
        
    }
}
