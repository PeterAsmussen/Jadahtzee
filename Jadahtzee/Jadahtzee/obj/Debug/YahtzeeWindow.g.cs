﻿#pragma checksum "..\..\YahtzeeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F32731E823D79DC154806F9EDC9F3BFD39A997BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Jadahtzee;
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


namespace Jadahtzee {
    
    
    /// <summary>
    /// YahtzeeWindow
    /// </summary>
    public partial class YahtzeeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\YahtzeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewGame;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\YahtzeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddPlayer;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\YahtzeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemovePlayer;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\YahtzeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNewGame;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\YahtzeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn2NewGame;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\YahtzeeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox grpbNewGame;
        
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
            System.Uri resourceLocater = new System.Uri("/Jadahtzee;component/yahtzeewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\YahtzeeWindow.xaml"
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
            this.btnNewGame = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\YahtzeeWindow.xaml"
            this.btnNewGame.Click += new System.Windows.RoutedEventHandler(this.btnNewGame_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnAddPlayer = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\YahtzeeWindow.xaml"
            this.btnAddPlayer.Click += new System.Windows.RoutedEventHandler(this.btnAddPlayer_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnRemovePlayer = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\YahtzeeWindow.xaml"
            this.btnRemovePlayer.Click += new System.Windows.RoutedEventHandler(this.btnRemovePlayer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtNewGame = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\YahtzeeWindow.xaml"
            this.txtNewGame.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn2NewGame = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\YahtzeeWindow.xaml"
            this.btn2NewGame.Click += new System.Windows.RoutedEventHandler(this.btn2NewGame_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.grpbNewGame = ((System.Windows.Controls.GroupBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
