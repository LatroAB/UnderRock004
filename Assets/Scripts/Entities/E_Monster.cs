using UnityEngine;
using System.Collections;

public class E_Monster {

    public void CreateMonster()
    {
        Entity monster = new Entity();
        monster.Add(new C_Health());
    }
}
