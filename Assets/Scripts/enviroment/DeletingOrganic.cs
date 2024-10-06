using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingOrganic : DeletingWaste
{
    private static bool isFirst = true;
    protected override void GiveResource()
    {
        Game.Instance.ShowMessage("+3 biomas!");
        Game.Instance.ChangeBiomass(3);
        if (isFirst)
        {
            Game.Instance.ShowInfoMessage(" Кучи гниющей пищи, овощных отходов, остатков животных – всё это вызывает " +
                "неприятный запах и привлекает нежелательных гостей.", 7f);
            isFirst = false;
        }
    }
}
