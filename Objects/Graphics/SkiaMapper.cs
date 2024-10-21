using CityScapeApp.Objects.Entities;
using CityScapeApp.Views;
using CityScapeApp.Views.Controls.Business;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Graphics
{
    internal class SkiaMapper
    {
        //public delegate void StatusUpdateHandler(object sender, SkiaMapperEventArgs e);
        //public event StatusUpdateHandler OnLoadVisualContent;
        public event EventHandler<SkiaMapperEventArgs> OnLoadVisualContent;
        private SKPaintSurfaceEventArgs _args;
        private MapPositionEntity _mapPosition;
        private LotHelper lotHelper;
        private SKRect RoadskrectTop;
        private SKRect RoadskrectLeft;
        private SKRect RoadskrecBottom;
        private SKRect RoadskrecMid;
        private SKRect RoadskrecRight;
        SKImageInfo info;
        SKCanvas canvas;
        SKSurface surface;
        int skcanvaswidth;
        int skcanvaheight;
        private bool _VisualContentLoaded;
        internal SkiaMapper(SKPaintSurfaceEventArgs args,
            MapPositionEntity mapPosition, bool VisualContentLoaded,
            CityscapeStreets view)
        {
            lotHelper = new LotHelper(view);
            _VisualContentLoaded = VisualContentLoaded;
            _args = args;
            _mapPosition = mapPosition;
            info = args.Info;
            surface = args.Surface;
            canvas = surface.Canvas;
            skcanvaswidth = info.Width;
            skcanvaheight = info.Height;
        }
        internal void Draw()
        {
            canvas.Clear();
            SkiaSharp.SKPaint roadsideLinePaint = new SkiaSharp.SKPaint
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = SkiaSharp.SKColors.DarkGray,
                StrokeWidth = 2
            };
            SkiaSharp.SKPaint yellowLinePaint = new SkiaSharp.SKPaint
            {
                Style = SkiaSharp.SKPaintStyle.Stroke,
                Color = SkiaSharp.SKColors.Yellow,
                StrokeWidth = 2
            };
            SkiaSharp.SKPaint roadbedPaint = new SkiaSharp.SKPaint
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = SkiaSharp.SKColors.Gray,
                StrokeWidth = 2
            };
            SkiaSharp.SKPaint testPaint = new SkiaSharp.SKPaint
            {
                Style = SkiaSharp.SKPaintStyle.Fill,
                Color = SkiaSharp.SKColors.Red,
                StrokeWidth = 2
            };
            int bottomheightfudge = 0;
            _mapPosition.StreetBottomYSkia = info.Height - (bottomheightfudge + Global.StreetOuterOffset + Global.StreetWidth + Global.LotSizeNormal);
            _mapPosition.LeftStreetInnerSkia = Global.StreetOuterOffset + Global.StreetWidth;
            _mapPosition.RightStreetOuterXSkia = skcanvaswidth - Global.StreetOuterOffset;
            _mapPosition.RightStreetInnerXSkia = _mapPosition.RightStreetOuterXSkia - Global.StreetWidth;
            _mapPosition.MooStreetLeftXSkia = _mapPosition.LeftStreetInnerSkia + 400;
            _mapPosition.MidStreetTopRightSkia = _mapPosition.MooStreetLeftXSkia + Global.StreetWidth;

            //canvas.DrawRect(new SKRect(300, testrect1y, 400, testrect1y+20), testPaint);
            //canvas.DrawRect(new SKRect(300, testrect2y, 400, testrect2y + 20), testPaint);
            //canvas.DrawRect(new SKRect(300, testrect3y, 400, testrect3y + 20), testPaint);

            //   Global.WriteDebutOutput("streetouteroffset, StreetTopOffset" + Global.StreetOuterOffset + Global.StreetTopOffset);

            RoadskrectTop = new SKRect(Global.StreetOuterOffset, Global.StreetTopOffset, _mapPosition.RightStreetOuterXSkia, Global.StreetTopOffset + Global.StreetWidth);
            RoadskrectLeft = new SKRect(Global.StreetOuterOffset, Global.StreetTopOffset, Global.StreetOuterOffset + Global.StreetWidth, _mapPosition.StreetBottomYSkia);

            Global.WriteDebugOutput("rect bottom " + _mapPosition.StreetBottomYSkia + "  " + _mapPosition.StreetBottomYSkia + Global.StreetWidth);
            RoadskrecBottom = new SKRect(Global.StreetOuterOffset, _mapPosition.StreetBottomYSkia, _mapPosition.RightStreetOuterXSkia, _mapPosition.StreetBottomYSkia + Global.StreetWidth);

            RoadskrecMid = new SKRect(_mapPosition.MooStreetLeftXSkia, Global.StreetTopOffset, _mapPosition.MidStreetTopRightSkia, _mapPosition.StreetBottomYSkia);
            RoadskrecRight = new SKRect(_mapPosition.RightStreetInnerXSkia, Global.StreetTopOffset, _mapPosition.RightStreetOuterXSkia, _mapPosition.StreetBottomYSkia);

            canvas.DrawRect(RoadskrectTop, roadbedPaint);
            canvas.DrawRect(RoadskrectLeft, roadbedPaint);
            canvas.DrawRect(RoadskrecBottom, roadbedPaint);
            canvas.DrawRect(RoadskrecMid, roadbedPaint);
            canvas.DrawRect(RoadskrecRight, roadbedPaint);

            //top roadside
            canvas.DrawLine(Global.StreetOuterOffset, Global.StreetTopOffset, _mapPosition.RightStreetOuterXSkia, Global.StreetTopOffset, roadsideLinePaint);
            //left top roadside
            canvas.DrawLine(Global.StreetOuterOffset, Global.StreetTopOffset, Global.StreetOuterOffset, _mapPosition.StreetBottomYSkia, roadsideLinePaint);
            //top inner roadside
            canvas.DrawLine(Global.StreetOuterOffset + Global.StreetWidth, Global.StreetTopOffset + Global.StreetWidth, _mapPosition.MooStreetLeftXSkia, Global.StreetTopOffset + Global.StreetWidth, roadsideLinePaint);
            //left inner roadside
            canvas.DrawLine(Global.StreetOuterOffset + Global.StreetWidth, Global.StreetTopOffset + Global.StreetWidth, Global.StreetOuterOffset + Global.StreetWidth, _mapPosition.StreetBottomYSkia, roadsideLinePaint);

            //left mid roadside
            canvas.DrawLine(_mapPosition.MooStreetLeftXSkia, Global.StreetTopOffset + Global.StreetWidth, _mapPosition.MooStreetLeftXSkia, _mapPosition.StreetBottomYSkia, roadsideLinePaint);

            Global.WriteDebugOutput("rect bottom " + _mapPosition.StreetBottomYSkia + "  " + _mapPosition.StreetBottomYSkia + Global.StreetWidth);

            //inner bottom roadside
            canvas.DrawLine(_mapPosition.MooStreetLeftXSkia, _mapPosition.StreetBottomYSkia, Global.StreetOuterOffset + Global.StreetWidth, _mapPosition.StreetBottomYSkia, roadsideLinePaint);
            //bottom roadside
            canvas.DrawLine(Global.StreetOuterOffset, _mapPosition.StreetBottomYSkia + Global.StreetWidth, _mapPosition.RightStreetOuterXSkia, _mapPosition.StreetBottomYSkia + Global.StreetWidth, roadsideLinePaint);

            //right roadside
            canvas.DrawLine(_mapPosition.RightStreetOuterXSkia, _mapPosition.StreetBottomYSkia + Global.StreetWidth, _mapPosition.RightStreetOuterXSkia, Global.StreetTopOffset, roadsideLinePaint);
            //bottom right inner roadside
            canvas.DrawLine(_mapPosition.RightStreetOuterXSkia - Global.StreetWidth, _mapPosition.StreetBottomYSkia, _mapPosition.RightStreetOuterXSkia, _mapPosition.StreetBottomYSkia, roadsideLinePaint);

            //right inner roadside
            canvas.DrawLine(_mapPosition.RightStreetOuterXSkia - Global.StreetWidth, _mapPosition.StreetBottomYSkia, _mapPosition.RightStreetOuterXSkia - Global.StreetWidth, Global.StreetTopOffset + Global.StreetWidth, roadsideLinePaint);
            // right inner top roadside
            canvas.DrawLine(_mapPosition.RightStreetOuterXSkia - Global.StreetWidth, Global.StreetTopOffset + Global.StreetWidth, _mapPosition.RightStreetOuterXSkia, Global.StreetTopOffset + Global.StreetWidth, roadsideLinePaint);
            //right inner roadside
            canvas.DrawLine(_mapPosition.RightStreetOuterXSkia, Global.StreetTopOffset + Global.StreetWidth, _mapPosition.RightStreetOuterXSkia, _mapPosition.StreetBottomYSkia, roadsideLinePaint);

            //YELLOW center lines
            int topcenter = Global.StreetTopOffset + (Global.StreetWidth / 2);
            int bottomcenter = _mapPosition.StreetBottomYSkia + (Global.StreetWidth / 2);
            int leftcenter = Global.StreetOuterOffset + (Global.StreetWidth / 2);
            int midcenter = _mapPosition.MooStreetLeftXSkia + (Global.StreetWidth / 2);
            int rightcenter = _mapPosition.RightStreetOuterXSkia - (Global.StreetWidth / 2);
            //TOP YELLOW
            canvas.DrawLine(leftcenter, topcenter, rightcenter, topcenter, yellowLinePaint);
            //bottom yellow
            canvas.DrawLine(leftcenter, bottomcenter, rightcenter, bottomcenter, yellowLinePaint);
            //left yellow
            canvas.DrawLine(leftcenter, topcenter, leftcenter, bottomcenter, yellowLinePaint);
            //right yellow
            canvas.DrawLine(rightcenter, topcenter, rightcenter, bottomcenter, yellowLinePaint);
            //mid yellow
            canvas.DrawLine(midcenter, topcenter, midcenter, bottomcenter, yellowLinePaint);

            //if (Global.ShowLotOutlines)
            //ShowLots(canvas);
            if (_VisualContentLoaded == false)
            {
                lotHelper.CreateStreetLotInfo(info.Width, info.Height, _mapPosition);
                
                
                FireLoadVisualContent(new SkiaMapperEventArgs());
            }

        }
        public void FireLoadVisualContent(SkiaMapperEventArgs e)
        {
            if (OnLoadVisualContent != null)
            {
                OnLoadVisualContent(this, e);
            }
        }

    }
}
