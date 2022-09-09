using UnityEngine;

public static class ExtensionMethods
{
    public static void RemoveComponent<Component>(this GameObject obj, bool immediate = false)
    {
        Component component = obj.GetComponent<Component>();

        if (component != null)
        {
            if (immediate)
            {
                Object.DestroyImmediate(component as Object, true);
            }
            else
            {
                Object.Destroy(component as Object);
            }

        }
    }
}

public static class GlobalVariables
{

    public static bool TimeRun = false; // ���� �� ����� � ����

    public static bool Rotate = false;
    public static bool Fire   = false;
    public static bool Move   = false;
}