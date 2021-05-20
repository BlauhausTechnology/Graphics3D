﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Blauhaus.Graphics3D.Runner.Maui.Pages.Base;
using Blauhaus.Graphics3d.ViewModels;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace Blauhaus.Graphics3D.Runner.Maui.Pages
{
    public class FourDotsPage : BaseGraphics3DPage<FourDotsViewModel>
    {
        public FourDotsPage(FourDotsViewModel viewModel) : base(viewModel)
        {
            BackgroundColor = Color.LightSlateGray;
            
            var canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        private static void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {

            var info = args.Info;
            var surface = args.Surface;
            var canvas = surface.Canvas;
            canvas.Clear();

            var pointsToShow = new Vector3[]
            {
                new (0, 0, 0),   //middle of screen, middle distance
                new (2, 0, 0),   //right of screen, middle distance
                new (-1, 1, 2),  //top left of screen, far distance
                new (1, -1, -2)   //botth right of screen, near distance
            };

            var camera = new Camera(info.Width, info.Height, new Vector3(0, 0, -5), Vector3.Zero, Vector3.UnitY);
            var viewToProjectionCanvas = camera.GetScreenCoordinates(pointsToShow);

            var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 25
            };

            for (var i = 0; i < viewToProjectionCanvas.Count(); i++)
            {
                paint.Color = Colors[i];
                canvas.DrawCircle(viewToProjectionCanvas[i].X, viewToProjectionCanvas[i].Y, 10, paint);
            } 
        }

        private static readonly SKColor[] Colors = 
        {
            Color.Red.ToSKColor(),
            Color.Green.ToSKColor(),
            Color.Blue.ToSKColor(),
            Color.Yellow.ToSKColor(),
        };
         
    }
}