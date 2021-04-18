using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

public class APIresize : MonoBehaviour
{
    public GameObject Cube;
    public string URL = "http://127.0.0.1:8000/raw_data";
    public float SizeFactor = 1;

    private float sizeY = 0.1f;
    private int pulse_frequency;
    private int reactor_inlet_temperature;
    private int reactor_outlet_temperature;
    private float coolant_pressure;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WebRequest request = WebRequest.Create("http://127.0.0.1:8000/raw_data");
        WebResponse response = request.GetResponse();

        using (Stream stream = response.GetResponseStream())
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    Translation dataf = JsonConvert.DeserializeObject<Translation>(line);
                    pulse_frequency = dataf.pulse_frequency;
                    reactor_inlet_temperature = dataf.reactor_inlet_temperature;
                    reactor_outlet_temperature = dataf.reactor_outlet_temperature;
                    coolant_pressure = dataf.coolant_pressure;
}
            }
        }
        sizeY = pulse_frequency;
        Cube.transform.localScale = new Vector3(1, (sizeY * SizeFactor), 1);
        Cube.transform.localPosition = new Vector3(0, (sizeY / 2 * SizeFactor), 0);
    }

    class Translation
    {
        public int pulse_frequency;
        public int reactor_inlet_temperature;
        public int reactor_outlet_temperature;
        public float coolant_pressure;
    }
}
