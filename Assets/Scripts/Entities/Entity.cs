using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Entity
{
    Dictionary<Guid, IGameComponent> components;
    Guid entityID;

    public Entity()
    {
        components = new Dictionary<Guid, IGameComponent>();
        entityID = Guid.NewGuid();
        Debug.Log("New Entity Created: "+entityID);
    }
    
    public void Add(IGameComponent component)
    {
        if(components.ContainsKey(component.GetClassID()))
        {
            throw new System.ArgumentException("Entity already contains this component.");
        }  

        components.Add(component.GetClassID(), component);
    }

    public void Remove(Guid componentClass)
    {
        if(!components.ContainsKey(componentClass))
        {
            throw new System.ArgumentException("Entity not found in this component.");
        }
        components.Remove(componentClass);
    }

    public IGameComponent Get(Guid componentClass)
    {
        if (components.ContainsKey(componentClass))
            return components[componentClass];
        else
            return null;
    }

    public List<Guid> GetClasses()
    {
        return new List<Guid>(components.Keys);
    }
}
