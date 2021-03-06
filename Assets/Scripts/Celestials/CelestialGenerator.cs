using SpaceCarrier.OrbitalMotion;
using UnityEngine;

namespace SpaceCarrier.Celestials
{
    public class CelestialGenerator : MonoBehaviour
    {
        //Collections of spawnable celestials
        [SerializeField] private CelestialBody[] stars;
        [SerializeField] private CelestialBody[] planets;
        //Difficulty considers how many planets will be generated and other modificators, which will be added in later versions
        [SerializeField, Range(1, 3)] private int difficulty = 1;
        //Range of orbit radius
        [SerializeField] private float minRadius = 50f;
        [SerializeField] private float maxRadius = 120f;
        //Range of orbit oeriods
        [SerializeField] private float minPeriod = 30f;
        [SerializeField] private float maxPeriod = 60f;
        //Range of planet resources amounts
        [SerializeField] private int minResourceAmount = 5;
        [SerializeField] private int maxResourceAmount = 30;

        private void Awake()
        {
            GenerateSystem();
        }

        private CelestialBody GenerateStar()
        {
            CelestialBody star;
            star = Instantiate(stars[Random.Range(0, stars.Length - 1)]);
            return star;
        }

        private void GenerateSystem()
        {
            CelestialBody star = GenerateStar();

            GeneratePlanets(star, difficulty);
        }

        private void GeneratePlanets(CelestialBody centralBody, float planetCount)
        {
            float minRadius = this.minRadius;
            float deltaX = Random.Range(1, 1.5f);

            for (float i = 1; i <= planetCount; i++)
            {
                //Step defines distance between planet orbits
                float step = i / planetCount;
                float maxRadius = Mathf.Min(this.maxRadius, this.minRadius + (this.maxRadius - this.minRadius) * step);

                CelestialBody planet = Instantiate(planets[Random.Range(0, planets.Length)], centralBody.transform);
                SetPlanetPath(planet, Random.Range(minRadius, maxRadius), deltaX);
                SetOrbitMotion(planet);
                SetResourceAmount(planet);

                minRadius = maxRadius + 30f;
            }
        }

        private void SetPlanetPath(CelestialBody planet, float radius, float deltaX)
        {
            var path = planet.GetComponent<OrbitPath>().path;

            float y = radius;
            float x = y * deltaX;

            path.xAxis = x;
            path.yAxis = y;
        }

        //Define period and progress of orbit motion
        private void SetOrbitMotion(CelestialBody planet)
        {
            var motion = planet.GetComponent<OrbitMotion>();
            motion.orbitPeriod = Random.Range(minPeriod, maxPeriod);
            motion.orbitProgress = Random.Range(0, 1f);
        }

        private void SetResourceAmount(CelestialBody planet)
        {
            planet.GetComponent<CelestialResources>().CurrentResource = Random.Range(minResourceAmount, maxResourceAmount);
        }
    }
}
