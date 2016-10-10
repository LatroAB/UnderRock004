using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


// given this structure, entities must define their components before
public class Engine  {

    List<Entity> entityList;
    List<IGameSystem> gameSystemList;
    Dictionary<Guid, List<Entity>> componentNodeLists;

    public Engine()
    {
        entityList = new List<Entity>();
        gameSystemList = new List<IGameSystem>();
        componentNodeLists = new Dictionary<Guid, List<Entity>>();
    }

    public void AddEntity(Entity entity)
    {
        entityList.Add(entity);
    }

    public void RemoveEntity(Entity entity)
    {
        entityList.Remove(entity);
    }

    public void UpdateEntity(Entity entity)
    {
        RemoveEntity(entity);
        AddEntity(entity);
    }

    public void AddSystem(IGameSystem system)
    {
        gameSystemList.Add(system);
        system.SystemStart();
    }

    public void RemoveSystem(IGameSystem system)
    {
        gameSystemList.Remove(system);
        system.SystemEnd();
    }

    public List<Entity> GetNodeList(Guid componentClass)
    {
        List<Entity> entitiesWithComponent = new List<Entity>();
        foreach(Entity e in entityList)
        {
            if (e.Get(componentClass) != null)
            {
                entitiesWithComponent.Add(e);
            }
        }

        return entitiesWithComponent;
    }

    private void NodeListAddEntity(Entity e)
    {
        List<Guid> components = e.GetClasses();
        foreach(Guid g in components)
        {
            if(!componentNodeLists.ContainsKey(g))
            {
                componentNodeLists[g] = new List<Entity>();
            }
            

        }
    }

    private void NodeListRemoveEntity(Entity e)
    {
        List<Guid> components = e.GetClasses();
        foreach (Guid g in components)
        {
            componentNodeLists[g].Remove(e);
            if (componentNodeLists[g].Count == 0)
            {
                componentNodeLists.Remove(g);
            }
        }
    }

    public void EngineUpdate()
    {
        foreach (IGameSystem s in gameSystemList)
        {
            s.SystemUpdate();
        }
    }

}
