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
        CelestialBody planet;
        System.Random rnd = new System.Random();
        string curentScene = SceneManager.GetActiveScene().name;
        public void Start()
        {
            //go = new GameObject();
            //light = go.AddComponent<Light>();
            //light.type = LightType.Directional;
            //light.shadows = LightShadows.Hard
            //StartCoroutine(SlowUpdate());
            //go.transform.position = Vector3.zero;

            planet = FlightGlobals.GetBodyByName("Kerbin");
            if (curentScene == "trackingStation")
            {
                GameObject gox = new GameObject();
                Light lightx = gox.AddComponent<Light>();
                lightx.type = LightType.Directional;
                lightx.shadows = LightShadows.Hard;
                lightx.color = new Color(1, 0, 0);
                gox.transform.rotation = Quaternion.Euler(90, 0, 0);

                GameObject goy = new GameObject();
                Light lighty = goy.AddComponent<Light>();
                lighty.type = LightType.Directional;
                lighty.shadows = LightShadows.Hard;
                lighty.color = new Color(0, 1, 0);
                goy.transform.rotation = Quaternion.Euler(0, 90, 0);

                GameObject goz = new GameObject();
                Light lightz = goz.AddComponent<Light>();
                lightz.type = LightType.Directional;
                lightz.shadows = LightShadows.Hard;
                lightz.color = new Color(0, 0, 1);
                goz.transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            FlightGlobals.GetBodyByName("Kerbin").orbit.inclination = 90;
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
                CelestialBody star = FlightGlobals.GetBodyByName("Sun");
                float i = 1;


                Vector3 planetPos = planet.transform.position;
                Vector3 sunPos = star.transform.position;
                Vector3 shipPos = FlightGlobals.ActiveVessel.transform.position;
                double r = planet.Radius;

                double dShip = PythagoreanV3(shipPos,planetPos);
                double sAltitude = FlightGlobals.ActiveVessel.altitude;
                double dSun = PythagoreanV3(sunPos, planetPos);
                float t = (float)Max(RadToDeg(Atan(sAltitude / r)) / 90, 0);

                Vector3 vShip = shipPos - planetPos;
                Vector3 vSun = sunPos - planetPos;
                float a = 1 - (float)RadToDeg(Acos((vShip.x * vSun.x + vShip.y * vSun.y + vShip.z * vSun.z) / (dShip * dSun)) / 180);

                float l1 = (t * a) + 2 * ((1 - t) * (float)Max(a - 0.5, 0));
                float l2 = (float)Min(Pow(0.5, sAltitude / (4f /*<--- slope*/ * r)), 1); ;
                float lightIntensity = l1 * l2 * i;



                //Debug.Log("-------------");
                //Debug.Log("lightIntensity " + Convert.ToString(lightIntensity));
            }
        }
        public static double PythagoreanV3(Vector3 v3a, Vector3 v3b)
        {
            double d = Sqrt(Pow((v3a.x - v3b.x), 2) + Pow((v3a.y - v3b.y), 2) + Pow((v3a.z - v3b.z), 2));
            return d;
        }
        public static double PythagoreanV2(Vector2 v3a, Vector2 v3b)
        {
            double d = Sqrt(Pow((v3a.x - v3b.x), 2) + Pow((v3a.y - v3b.y), 2));
            return d;
        }
        public static double RadToDeg(double x)
        {
            double y = x * 180f / PI;
            return y;
        }
    }
}
