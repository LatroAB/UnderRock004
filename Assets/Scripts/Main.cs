using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
    Engine engine;
    S_Health healthSystem;

    void Start()
    {
        engine = new Engine();
        healthSystem = new S_Health(engine);

        engine.AddSystem(healthSystem);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // add a new entity with a health component
            C_Health healthComponent = new C_Health();
            healthComponent.Health = 5;

            Entity healthEntity = new Entity();
            healthEntity.Add(healthComponent);

            engine.AddEntity(healthEntity);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            // add health to all entities
            healthSystem.IncreaseAllHealth(1);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            // remove health from all entities
        }

        engine.EngineUpdate();  
    }
}
