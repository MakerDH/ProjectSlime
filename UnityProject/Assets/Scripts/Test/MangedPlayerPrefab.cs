using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangedPlayerPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EncryptedPlayerPrefs.keys = new string[5];
        EncryptedPlayerPrefs.keys[0] = "23Wrudre";
        EncryptedPlayerPrefs.keys[1] = "SP9DupHa";
        EncryptedPlayerPrefs.keys[2] = "frA5rAS3";
        EncryptedPlayerPrefs.keys[3] = "tHat2epr";
        EncryptedPlayerPrefs.keys[4] = "jaw3eDAs";
    }


    public bool check = false;

    // Update is called once per frame
    void Update()
    {
    }
}
