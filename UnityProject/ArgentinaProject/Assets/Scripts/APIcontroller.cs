using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

public class APIcontroller : MonoBehaviour
{
    public string URL = "http://127.0.0.1:8000/raw_data";

    public int pulse_frequency;
    public int reactor_inlet_temperature;
    public int reactor_outlet_temperature;
    public float coolant_pressure;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WebRequest request = WebRequest.Create("http://127.0.0.1:8000/raw_data");
        WebResponse response = request.GetResponse();
        try 
        { 

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
        }
        catch
        {
            Debug.Log("None");
            pulse_frequency = 1;
            reactor_inlet_temperature = 1;
            reactor_outlet_temperature = 1;
            coolant_pressure = 1.0f;
        }
    }

    class Translation
    {
        public int pulse_frequency;
        public int reactor_inlet_temperature;
        public int reactor_outlet_temperature;
        public float coolant_pressure;
    }
}
