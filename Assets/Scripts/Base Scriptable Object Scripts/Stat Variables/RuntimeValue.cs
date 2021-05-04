using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class FloatVariable2 : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;

    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
