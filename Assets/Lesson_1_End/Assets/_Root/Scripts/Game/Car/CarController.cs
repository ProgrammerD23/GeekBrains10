using Tool;
using UnityEngine;
using Features.AbilitySystem;

namespace Game.Car
{
    internal class CarController : BaseControllerContext, IAbilityActivator
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Car");
        private readonly CarView _view;
        private readonly CarModel _model;

        public float JumpHeight => _model.JumpHeight;
        public GameObject ViewGameObject => _view.gameObject;

        public CarController(CarModel model)
        {
            _view = LoadView();
            _model = model;
        }

        private CarView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            return objectView.GetComponent<CarView>();
        }
    }
}
