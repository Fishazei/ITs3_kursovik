﻿#pragma checksum "..\..\..\..\menu\DifficultyWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FFF42CFA1DF284843B0D1F0947F026025C61F9F2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using IT_3S_Kursovik;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace IT_3S_Kursovik {
    
    
    /// <summary>
    /// DifficultyWindow
    /// </summary>
    public partial class DifficultyWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 113 "..\..\..\..\menu\DifficultyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton evening;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\menu\DifficultyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton morning;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\menu\DifficultyWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton night;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/IT_3S_Kursovik;component/menu/difficultywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\menu\DifficultyWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.evening = ((System.Windows.Controls.RadioButton)(target));
            
            #line 117 "..\..\..\..\menu\DifficultyWindow.xaml"
            this.evening.Checked += new System.Windows.RoutedEventHandler(this.Difficulty_Check);
            
            #line default
            #line hidden
            return;
            case 2:
            this.morning = ((System.Windows.Controls.RadioButton)(target));
            
            #line 124 "..\..\..\..\menu\DifficultyWindow.xaml"
            this.morning.Checked += new System.Windows.RoutedEventHandler(this.Difficulty_Check);
            
            #line default
            #line hidden
            return;
            case 3:
            this.night = ((System.Windows.Controls.RadioButton)(target));
            
            #line 130 "..\..\..\..\menu\DifficultyWindow.xaml"
            this.night.Checked += new System.Windows.RoutedEventHandler(this.Difficulty_Check);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 141 "..\..\..\..\menu\DifficultyWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Back_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 150 "..\..\..\..\menu\DifficultyWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Start_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

