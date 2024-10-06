using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingMunicipalWaste : DeletingWaste
{
    private static bool isFirst = true;
    protected override void GiveResource()
    {
        Game.Instance.ShowMessage("+2 rubber +1 biomas!");
        Game.Instance.ChangeBiomass(1);
        Game.Instance.ChangeRubber(2);
        if (isFirst)
        {
            Game.Instance.ShowInfoMessage("Горы мусора, разбросанного по всей округе. Пластиковые бутылки," +
                " бумажные пакеты, остатки пищи, стеклянные осколки – все это свидетельствует о бездумном" +
                "потреблении и небрежении к окружающей среде.", 7f);
            isFirst = false;
        }
    }

}
