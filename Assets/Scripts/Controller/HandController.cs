using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : PlayerController  {

    HandModel model = new HandModel("player1");

    public void getCard()
    {
        model.GiveCard(target.TakeCard());
    }
}
