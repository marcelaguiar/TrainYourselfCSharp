﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace KinectMvvm
{
    public class ViewModelLoader
    {
        static ViewModel viewModelStatic;
        static IKinectService kinectService;

        public ViewModelLoader()
        {
            
            kinectService = new ConcreteKinectService();

            var prop = DesignerProperties.IsInDesignModeProperty;
            var isInDesignMode =
                (bool)DependencyPropertyDescriptor
                .FromProperty(prop, typeof(FrameworkElement))
                .Metadata.DefaultValue;
        }

        public static ViewModel ViewModelStatic
        {
            get
            {
                if (viewModelStatic == null)
                {
                    viewModelStatic = new ViewModel(kinectService);
                }
                return viewModelStatic;
            }
        }

        public ViewModel ViewModel
        {
            get
            {
                return ViewModelStatic;
            }
        }

        public static void Cleanup()
        {
            if (viewModelStatic != null)
            {
                viewModelStatic.Cleanup();
            }
        }
    }
}
