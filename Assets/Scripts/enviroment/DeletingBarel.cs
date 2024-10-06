using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingBarel : DeletingWaste
{
    private static bool isFirst = true;

    protected override void GiveResource()
    {
        Game.Instance.ShowMessage("+3 metal!");
        Game.Instance.ChangeMetal(3);
        if (isFirst)
        {
            Game.Instance.ShowInfoMessage("Ржавая, побитая временем бочка, из которой сочится ядовитая жидкость, " +
                "распространяя едкий запах." +
                "Бочка просачивает в землю токсичные вещества, отравляя почву и убивая растения.", 7f);
            isFirst = false;
        }
    }
}
