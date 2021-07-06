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

    public class Moonlight : MonoBehaviour
    {
        GameObject go;
        Light light;

        System.Random rnd = new System.Random();
        public void Start()
        {
            
            GameObject go = new GameObject();
            light = go.AddComponent<Light>();
            while(true) light.type = LightType.Directional;
            StartCoroutine(SlowUpdate());
            go.transform.position = Vector3.zero;
        }

        public IEnumerator SlowUpdate()
        { 
            while (true)
            {
                light.color = new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1.0F);
                yield return new WaitForSeconds(0.5f);
            }
        }

        public void Update()
        {
            light.color = new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1.0F);
            go.transform.rotation *= Quaternion.Euler(0.0F, 60.0F * Time.deltaTime, 0.0F);
        }
    }
}
