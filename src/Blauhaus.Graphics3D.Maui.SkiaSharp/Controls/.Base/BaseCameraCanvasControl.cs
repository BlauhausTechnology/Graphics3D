﻿using System.Numerics;

namespace Blauhaus.Graphics3D.Maui.SkiaSharp.Controls.Base
{
    public abstract class BaseCameraCanvasControl : BaseCanvasControl
    {
        protected readonly Camera Camera;

        protected BaseCameraCanvasControl()
        {
            Camera = new Camera(0, 0, Vector3.One, Vector3.Zero, Vector3.UnitZ);

            DimensionsChangedHandler = dimensions => Camera.SetDimensions(dimensions.X, dimensions.Y);

            ZoomHandler = zoom =>
            {
                Camera.Zoom(zoom);
                Redraw();
            };

        }
        
        public Vector3 CameraPosition { set => Camera.Position = value; }
        public Vector3 CameraLookingAt { set => Camera.SetLookAt(value); }
    }
}