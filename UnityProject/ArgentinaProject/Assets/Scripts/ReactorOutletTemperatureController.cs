using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

public class ReactorOutletTemperatureController : MonoBehaviour
{

    public GameObject Cube;
    public GameObject APIcontroller;
    public float SizeFactor = 0.1f;

    private APIcontroller apiController;
    private float sizeY = 0.1f;
    private int pulse_frequency;


    void Start()
    {
        apiController = APIcontroller.GetComponent<APIcontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        sizeY = apiController.reactor_outlet_temperature;
        Cube.transform.localScale = new Vector3(0.5f, (sizeY * SizeFactor), 0.5f);
        Cube.transform.localPosition = new Vector3(1, (sizeY / 2 * SizeFactor), -1);
    }
}
