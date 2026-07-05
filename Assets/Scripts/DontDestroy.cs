using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] Dont = new GameObject[2];
    public int Index;
   void Awake()
    {
        if (Dont[Index] == null)
        {
            Dont[Index] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (Dont[Index] != gameObject) 
        {
            Destroy(gameObject);
        }
    }
}
