using UnityEngine;
using System;
using System.Collections;

public class C_Health : IGameComponent
{
    /*
     * This is the standard block that needs to appear in each Component 
     * 
     * It would be better if this could somehow be encapsulated in the interface or a 
     * parent class, but I haven't seen any elegant way to handle that.
     * 
     */
    static Guid classID = Guid.Empty;
    static string componentName = "";

    public static Guid ClassID { get { return classID; } }

    public static string ComponentName
    {
        get { return componentName; }
        set { componentName = value; }
    }

    public C_Health()
    {
        // If this is the first instance of this class, set a static classID to serve as an index into this
        // specific component type
        if (classID == Guid.Empty) { classID = Guid.NewGuid(); }
        if (componentName == "") { componentName = "Health"; }

        Debug.Log("Component: " + ComponentName + " initialized. classID: " + classID + " Health: " + Health);
    }
    /*
     * End of the standard component block
     */

    /* 
     * Interface definitions
     */
    Guid IGameComponent.GetClassID()
    {
        return ClassID;
    }

    string IGameComponent.GetComponentName()
    {
        return ComponentName;
    }

    /*
     * Start of the specific component data
     */

    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            Debug.Log("Component: " + ComponentName + " initialized. classID: " + classID + " Health: " + Health);
        }
    }
}
