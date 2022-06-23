using DV.Logic.Job;
using UnityEngine;

namespace DvMod.NightLightFix
{
    public static class NightLightFix
    {
        public static void InstallCallbacks()
        {
            CarSpawner.CarSpawned += OnCarSpawned;
        }

        public static void RemoveCallbacks()
        {
            CarSpawner.CarSpawned -= OnCarSpawned;
            foreach (var car in SingletonBehaviour<IdGenerator>.Instance.logicCarToTrainCar.Values)
                car.InteriorPrefabLoaded -= OnInteriorLoaded;
        }

        private static void OnCarSpawned(TrainCar car)
        {
            car.InteriorPrefabLoaded += OnInteriorLoaded;
        }

        private static void OnInteriorLoaded(GameObject loadedInterior)
        {
            if (loadedInterior == null)
                return;
            foreach (var comp in loadedInterior.transform.GetComponentsInChildren<ReflectionProbe>())
                comp.gameObject.SetActive(false);
        }
    }
}
