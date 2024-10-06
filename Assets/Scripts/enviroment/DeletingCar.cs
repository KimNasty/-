using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingCar : DeletingWaste
{
    private static bool isFirst = true;
    protected override void GiveResource()
    {
        Game.Instance.ShowMessage("+4 metal,+2 rubber");
        Game.Instance.ChangeMetal(4);
        Game.Instance.ChangeRubber(2);
        if (isFirst)
        {
            Game.Instance.ShowInfoMessage("Стальная громадина, покрытая ржавчиной и паутиной, застыла в ожидании. Лопнувшие шины, " +
                "разбитые фары, ржавые детали – машина давно покинута своим хозяином, но ее присутствие несет опасность.", 7f);
            isFirst = false;
        }
    }
}
