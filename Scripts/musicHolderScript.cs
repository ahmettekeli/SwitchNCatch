using UnityEngine;
using System.Collections;

public class musicHolderScript : MonoBehaviour {

    private static musicHolderScript instance = null;
    public static musicHolderScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
