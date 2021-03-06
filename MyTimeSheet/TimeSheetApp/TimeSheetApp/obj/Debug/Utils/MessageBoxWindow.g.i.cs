﻿#pragma checksum "..\..\..\Utils\MessageBoxWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1886EC2205FD48516F9B5FD1E062751D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace TimeSheetApp.Util {
    
    
    /// <summary>
    /// MessageBoxWindow
    /// </summary>
    public partial class MessageBoxWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// MainContentControl Name Field
        /// </summary>
        
        #line 41 "..\..\..\Utils\MessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Grid MainContentControl;
        
        #line default
        #line hidden
        
        /// <summary>
        /// TitleBackgroundPanel Name Field
        /// </summary>
        
        #line 48 "..\..\..\Utils\MessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Grid TitleBackgroundPanel;
        
        #line default
        #line hidden
        
        /// <summary>
        /// TxtTitle Name Field
        /// </summary>
        
        #line 55 "..\..\..\Utils\MessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock TxtTitle;
        
        #line default
        #line hidden
        
        /// <summary>
        /// MessageControl Name Field
        /// </summary>
        
        #line 58 "..\..\..\Utils\MessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.ScrollViewer MessageControl;
        
        #line default
        #line hidden
        
        /// <summary>
        /// TxtMessage Name Field
        /// </summary>
        
        #line 59 "..\..\..\Utils\MessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock TxtMessage;
        
        #line default
        #line hidden
        
        /// <summary>
        /// BtnCopyMessage Name Field
        /// </summary>
        
        #line 68 "..\..\..\Utils\MessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Button BtnCopyMessage;
        
        #line default
        #line hidden
        
        /// <summary>
        /// BtnOk Name Field
        /// </summary>
        
        #line 72 "..\..\..\Utils\MessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Button BtnOk;
        
        #line default
        #line hidden
        
        /// <summary>
        /// BtnCancel Name Field
        /// </summary>
        
        #line 73 "..\..\..\Utils\MessageBoxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Button BtnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TimeSheetApp;component/utils/messageboxwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Utils\MessageBoxWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainContentControl = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.TitleBackgroundPanel = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.TxtTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.MessageControl = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.TxtMessage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.BtnCopyMessage = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Utils\MessageBoxWindow.xaml"
            this.BtnCopyMessage.Click += new System.Windows.RoutedEventHandler(this.BtnCopyMessage_OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnOk = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\Utils\MessageBoxWindow.xaml"
            this.BtnOk.Click += new System.Windows.RoutedEventHandler(this.BtnOk_OnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BtnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\Utils\MessageBoxWindow.xaml"
            this.BtnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

