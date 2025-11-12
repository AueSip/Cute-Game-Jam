using System;
using System.IO;
using NUnit.Framework.Internal;
using UnityEngine;


public static class JsonLoader
{
    public static T LoadFromJson<T>(TextAsset jsonFile)
    {
        if(jsonFile == null)
        {
            Debug.LogError($"JsonLoader: Missing Json File");
            return default;
        }
    }
    }

}

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
