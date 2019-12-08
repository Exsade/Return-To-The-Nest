using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OnePF;

public class DemoBilling : MonoBehaviour {

    public const string SKU = "10 gems";
    public const string googleKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApzfI2nK+WSqOqlh7HTXnkK2XB5yKMSzp20OvsiVLztPpRkgWFt2LbtdyQ0kK4uJrz7CV/IfTrBWYP+ZQUt6w9EiJgLAR6T4O+Eu3Wxu2pX0sVYus0+HlRQzMISBs4c38QheipgCUmQv0PTMPFguFeHykHjSmRh9xpT2GEe/Zawle5IanTNeBNPWaGHq/Rh4NV62bme7w3zWQDlNvZYTwpH8rR8Z6ubviGwkqp5k5zEUHGkytE8Py6aYH/yksv5Agu9Gyai+N9nDPjnZsePTSPKhbZNwYGiq1jzapeIRZMyfE6fkAgpXZzmT2ri318oR87UrUF4WRC/UcV0ngjwcaaQIDAQAB";



    void Start () {
        OpenIAB.mapSku(SKU, OpenIAB_Android.STORE_GOOGLE, "10 gems");
        var options = new OnePF.Options();
        options.storeKeys.Add(OpenIAB_Android.STORE_GOOGLE, googleKey);
        OpenIAB.init(options);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
