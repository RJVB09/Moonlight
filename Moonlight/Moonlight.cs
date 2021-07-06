using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
        public void Start()
        {
            go = new GameObject();
            light = go.AddComponent<Light>();
            light.type = LightType.Directional;
            light.shadows = LightShadows.Hard;
            StartCoroutine(SlowUpdate());
            go.transform.position = Vector3.zero;

            planet = FlightGlobals.GetBodyByName("Kerbin");
            Debug.Log(Convert.ToString(planet.transform.position));
        }
        public IEnumerator SlowUpdate()
        { 
            while (true)
            {
                light.color = new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1.0F);
                light.intensity = (float)rnd.Next(1, 4);
                yield return new WaitForSeconds(0.5f);
            }
        }

        public void Update()
        {
            go.transform.rotation *= Quaternion.Euler(0.0F, -90 * Time.deltaTime, 0.0F);
        }
    }
}
