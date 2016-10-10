using UnityEngine;
using System.Collections;
using System;

public class S_Health : IGameSystem {

    private Engine engine;

    public S_Health(Engine engine)
    {
        this.engine = engine;
    }

    void IGameSystem.SystemStart()
    {
        Debug.Log("S_Health started");
    }

	void IGameSystem.SystemUpdate ()
    {
        Debug.Log("S_Health updated");
	}

    void IGameSystem.SystemEnd()
    {
        Debug.Log("S_Health ended");
    }

    public void IncreaseAllHealth(int health)
    {
        foreach(Entity e in engine.GetNodeList(C_Health.ClassID))
        {
            C_Health h = (C_Health) e.Get(C_Health.ClassID);
            h.Health++;
        }
        
    }
}
