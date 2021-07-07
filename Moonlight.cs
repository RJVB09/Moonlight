using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Reflection;

namespace Moonlight
{
    [KSPAddon(KSPAddon.Startup.AllGameScenes,false)]
    public class Moonlight : MonoBehaviour
    {
        GameObject go;
        Light light;
        CelestialBody planet;
        System.Random rnd = new System.Random();

        public static Vector3
        public void Start()
        {
            //go = new GameObject();
            //light = go.AddComponent<Light>();
            //light.type = LightType.Directional;
            //light.shadows = LightShadows.Hard;
            //StartCoroutine(SlowUpdate());
            //go.transform.position = Vector3.zero;

            planet = FlightGlobals.GetBodyByName("Kerbin");
            string curentScene = SceneManager.GetActiveScene().name;
        }
        public IEnumerator SlowUpdate()
        { 
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
            }
        }

        public void Update()
        {
            //light.intensity = (float)rnd.Next(1, 4);
            //light.color = new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1.0F);
            //go.transform.rotation *= Quaternion.Euler(0.0F, -90 * Time.deltaTime, 0.0F);

            if (FlightGlobals.ActiveVessel)
            {
                CelestialBody planet = FlightGlobals.GetBodyByName("Kerbin");
                Vector3 planetPos = planet.transform.position;
                Vector3 sunPos = FlightGlobals.GetBodyByName("Sun").transform.position;
                Vector3 shipPos = FlightGlobals.ActiveVessel.transform.position;
                double r = planet.Radius;

                double dShip = Math.Pythagoran;




                Debug.Log("Kerbin: " + Convert.ToString(FlightGlobals.GetBodyByName("Kerbin").transform.position) + " Kerbol: " + Convert.ToString(FlightGlobals.GetBodyByName("Sun").transform.position) + " Vessel: " + Convert.ToString(FlightGlobals.ActiveVessel.transform.position));
            }
        }
    }
}
