﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using IllyaVirych.Core.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace IllyaVirych.Droid.ViewModels
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, false)]
    public class MapsView : BaseFragment<MapsViewModel>, IOnMapReadyCallback
    {
        protected override int FragmentId => Resource.Layout.MapsView1;
        private GoogleMap _googleMap;
        private MapView _mapView;
        private MarkerOptions _markerOptions;
        private LatLng _latLng;
        private double _lalitude;
        private double _longitude;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            
            _mapView = (MapView)view.FindViewById(Resource.Id.map);
            _mapView.OnCreate(savedInstanceState);
            _mapView.OnResume();
            _mapView.GetMapAsync(this);            

            GoogleMapOptions mapOptions = new GoogleMapOptions()
            .InvokeMapType(GoogleMap.MapTypeSatellite)
            .InvokeZoomControlsEnabled(false)
            .InvokeCompassEnabled(true);           

            return view;
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _googleMap = googleMap;
            _googleMap.UiSettings.ZoomControlsEnabled = true;
            _googleMap.UiSettings.CompassEnabled = true;
            
            LatLng location = new LatLng(49.99181, 36.23572);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(15); 
            CameraPosition cameraPosition = builder.Build();

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            _googleMap.MoveCamera(cameraUpdate);

            _markerOptions = new MarkerOptions();                       
            _markerOptions.Draggable(true);             
            _googleMap.MapClick += MapOptionsClick;            
            _googleMap.MarkerDragEnd += MarkerOptionLongClick;

            this.ViewModel.LalitudeGoogleMarker = _lalitude;
            this.ViewModel.LongitudeGoogleMarker = _longitude;
        }
        private void MarkerOptionLongClick(object sender, GoogleMap.MarkerDragEndEventArgs e)
        {
            var latitude = e.Marker.Position.Latitude;
            var longitude = e.Marker.Position.Longitude;
            _lalitude = latitude;
            _longitude = longitude;
            this.ViewModel.LalitudeGoogleMarker = _lalitude;
            this.ViewModel.LongitudeGoogleMarker = _longitude;
        }

        private void MapOptionsClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            var latitude = e.Point.Latitude;
            var longitude = e.Point.Longitude;
            _lalitude = latitude;
            _longitude = longitude;
            this.ViewModel.LalitudeGoogleMarker = _lalitude;
            this.ViewModel.LongitudeGoogleMarker = _longitude;
            _googleMap.Clear();
            _latLng = new LatLng(latitude, longitude);
            _markerOptions.SetPosition(_latLng);
            _googleMap.AddMarker(_markerOptions);
            _googleMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(_latLng, _googleMap.CameraPosition.Zoom));
        }

        public override void OnLowMemory()
        {
            _mapView.OnLowMemory();
            base.OnLowMemory();
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnPause()
        {
            base.OnPause();
        }
    }
}