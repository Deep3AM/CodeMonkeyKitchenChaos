using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //there is no kitchenobject here
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //player not carrying anything
            }
        }
        else
        {
            //there is a kitchenobject here
            if (player.HasKitchenObject())
            {
                //player is carrying something
            }
            else
            {
                //player not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
