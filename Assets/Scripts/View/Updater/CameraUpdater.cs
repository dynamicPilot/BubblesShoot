using BubblesShoot.Model.Grids;
using UnityEngine;

namespace BubblesShoot.View.Updaters
{
    public class CameraUpdater
    {
        private Transform[] _transform;
        private float _height;
        private float _gridOriginY;
        public CameraUpdater(Transform[] transform)
        {
            _transform = transform;

        }

        public Vector2 SetCameraAndGetSize(CoordinateGrid grid, Camera camera)
        {
            var width = grid.Width;
            _height = grid.Width * 1 / camera.aspect;
            _gridOriginY = grid.OriginPoint.y;

            camera.orthographic = true;
            camera.orthographicSize = _height / 2;
            UpdateYPosition(CalculateCorrectPosition(grid.OriginPoint.y, grid.OriginPoint.y - grid.Height + grid.CellSize));

            return new Vector2(width, _height);
        }

        public void UpdateCameraPosition(float yBottomBorder)
        {
            UpdateYPosition(CalculateCorrectPosition(_gridOriginY, yBottomBorder));
        }

        private void UpdateYPosition(float posY)
        {
            for(int i = 0; i < _transform.Length; i++)
            {
                _transform[i].position = new Vector3(_transform[i].position.x, posY, _transform[i].position.z);
            }
        }

        private float CalculateCorrectPosition(float up, float bottom)
        {
            float currentPosition = _transform[0].position.y;
            float newYPos = bottom;
            //Debug.Log($"Bottom position {bottom}. Up position {up}.");
            //Debug.Log($"Camera up position {newYPos + _height / 2}.");
            if (newYPos + _height / 2 > up) newYPos = up - _height / 2;

            return newYPos;
        }
    }
}
