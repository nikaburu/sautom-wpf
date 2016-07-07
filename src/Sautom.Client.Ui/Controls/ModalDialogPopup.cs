using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace Sautom.Client.Ui.Controls
{
	[TemplatePart(Name = "content", Type = typeof(Grid))]
    [TemplatePart(Name = "contentHost", Type = typeof(ContentPresenter))]
    [TemplatePart(Name = "dialog", Type = typeof(Popup))]
    public class ModalDialogPopup : ContentControl, IModalDialogPopup
    {
		#region Constructors

		static ModalDialogPopup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ModalDialogPopup),
            new FrameworkPropertyMetadata(typeof(ModalDialogPopup)));
        }

		#endregion Constructors

		#region Fields

		public static readonly DependencyProperty IsOpenProperty =
           DependencyProperty.Register("IsOpen", typeof(bool), typeof(ModalDialogPopup),
           new PropertyMetadata(false, OnOpenChanged));

		static AdornerLayer _myAdorner;
		static FrameworkElement _rootElement;

		Grid _content;
		ContentPresenter _contentHost;
		Popup _dialog;
		bool _flagIsLoaded;
		double _oldLeft;
		double _oldTop;
		Window _shell;

		Shader _shader;

		#endregion Fields

		#region Properties

		public Control HostedContent
        {
            get;
            set;
        }

		public bool IsDesignMode
        {
            get
            {
                return DesignerProperties.GetIsInDesignMode(this);
            }
        }

		public bool IsOpen
        {
            get
            {
                return (bool)GetValue(IsOpenProperty);
            }
            set
            {
                SetValue(IsOpenProperty, value);
            }
        }

		public PopupAnimation PopupAnimation { get; set; } = PopupAnimation.Slide;

		public Shader Shader
        {
            get
            {
                if (_shader == null && !IsDesignMode)
                {
                    _shader = new Shader(_rootElement);
                }
                return _shader;
            }
            set
            {
                _shader = value;
            }
        }

		#endregion Properties

		#region Methods

		public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _dialog = GetTemplateChild("dialog") as Popup;
            _content = GetTemplateChild("content") as Grid;
            _contentHost = GetTemplateChild("contentHost") as ContentPresenter;

            if (_dialog != null)
            {
                _dialog.PopupAnimation = PopupAnimation;
                Loaded += ModalDialogHostLoaded;
                Unloaded += ModalDialogHostUnloaded;
            }
            if (_content != null)
            {
                _content.Background = Background;
            }
            if (_contentHost != null)
            {
                _contentHost.Content = HostedContent;
            }
        }

		private static void OnOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var context = (ModalDialogPopup)d;
            if (context.IsDesignMode)
            {
                return;
            }

            //depdendency property changed callback fires
            //too soon, before OnApplyTemplate. so workaround :|
            if (context._flagIsLoaded)
            {
                if ((bool)e.NewValue)
                {
                    context.Show();
                }
                else
                {
                    context.Close();
                }
            }
        }

		void Close()
        {
            if (!IsDesignMode)
            {
                _dialog.IsOpen = false;
                _myAdorner.Visibility = Visibility.Hidden;
            }
        }

		void Show()
        {
            if (!IsDesignMode)
            {
                _dialog.IsOpen = true;
                _myAdorner.Visibility = Visibility.Visible;
                Reposition();
            }
        }

		void EnsureRootElement()
        {
            if (_rootElement != null) return;

            _rootElement = Parent as FrameworkElement;
            while (_rootElement != null)
            {
                if (_rootElement.Parent is Window)
                {
                    //we just want the direct child element of our window
                    //this is our root element.
                    break;
                }
                _rootElement = _rootElement.Parent as FrameworkElement;
            }
        }

		void ModalDialogHostLoaded(object sender, RoutedEventArgs e)
        {
            _flagIsLoaded = true;

            EnsureRootElement();
            if (!IsDesignMode)
            {
                if (_shell == null)
                {
                    _shell = (Window)_rootElement.Parent;
                    _shell.LocationChanged += ShellLocationChanged;
                    _shell.SizeChanged += ShellSizeChanged;
                    _shell.StateChanged += ShellStateChanged;
                    _oldTop = _shell.Top;
                }

                if (_myAdorner == null)
                {
                    _myAdorner = AdornerLayer.GetAdornerLayer(_rootElement);
                    _myAdorner.Visibility = Visibility.Hidden;
                    _myAdorner.Add(Shader);
                }
            }
            //first set PlacementTarget and Placement
            if (_rootElement != null)
            {
                _dialog.PlacementTarget = _rootElement;
                _dialog.Placement = PlacementMode.Relative;
            }

            if (IsOpen)
            {
                Show();   
            }
        }

		void ModalDialogHostUnloaded(object sender, RoutedEventArgs e)
        {
            Close();
        }

		void Reposition()
        {
            EnsureRootElement();
            if (_rootElement == null)
            {
                throw new Exception("ModalDialogPopup was unable to locate the root element.");
            }
            FrameworkElement elem = (FrameworkElement)_dialog.Child;
            double actualX = _rootElement.ActualWidth / 2 - elem.ActualWidth / 2;
            double actualY = _rootElement.ActualHeight / 2 - elem.ActualHeight / 2;

            _dialog.HorizontalOffset = Math.Abs(actualX);
            _dialog.VerticalOffset = Math.Abs(actualY);
        }

		void ShellLocationChanged(object sender, EventArgs e)
        {
            Window s = (Window)sender;

            FrameworkElement elem = (FrameworkElement)_dialog.Child;
            double actualX = _rootElement.ActualWidth / 2 - elem.ActualWidth / 2;
            double actualY = _rootElement.ActualHeight / 2 - elem.ActualHeight / 2;

            double x = Math.Abs(_oldLeft - s.Left);
            double y = Math.Abs(_oldTop - s.Top);

            _dialog.HorizontalOffset = Math.Abs(x - actualX);
            _dialog.VerticalOffset = Math.Abs(y - actualY);

            _oldLeft = s.Left;
            _oldTop = s.Top;
        }

		void ShellSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Window s = (Window)sender;
            Reposition();
        }

		void ShellStateChanged(object sender, EventArgs e)
        {
            Window s = (Window)sender;
            switch (s.WindowState)
            {
                case WindowState.Maximized:
                case WindowState.Normal:
                    if (IsOpen)
                    {
                        Show();
                    }
                    break;
                case WindowState.Minimized:
                    if (IsOpen)
                    {
                        Close();
                    }
                    break;
            }
        }

		#endregion Methods
    }

    public class Shader : Adorner
    {
	    #region Methods

	    protected override void OnRender(DrawingContext drawingContext)
        {
            FrameworkElement elem = (FrameworkElement)AdornedElement;
            Rect adornedElementRect = new Rect(0, 0, elem.ActualWidth, elem.ActualHeight);
            drawingContext.DrawRectangle(Background, StrokeBorder, adornedElementRect);
        }

	    #endregion Methods

	    #region Constructors

	    public Shader(UIElement adornedElement)
            : base(adornedElement)
        {
            Background = new SolidColorBrush(Colors.Black);
            Background.Opacity = 0.5d;
            StrokeBorder = null;
        }

	    public Shader(UIElement adornedElement, SolidColorBrush background, Pen strokeBorder)
            : this(adornedElement)
        {
            //caller needs to have set opacity on background brush
            Background = background;
            StrokeBorder = strokeBorder;
        }

	    #endregion Constructors

	    #region Properties

	    SolidColorBrush Background
        {
            get; }

	    Pen StrokeBorder
        {
            get; }

	    #endregion Properties
    }
}