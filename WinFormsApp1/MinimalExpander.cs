using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace WinFormsApp1
{
    public partial class MinimalExpander : ContentControl
    {
        public object? Header 
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
        public DataTemplate? HeaderTemplate
        {
            get => GetValue(HeaderTemplateProperty) as DataTemplate;
            set => SetValue(HeaderTemplateProperty, value);
        }
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }
        public double NegativeContentHeight
        {
            get => (double)GetValue(NegativeContentHeightProperty);
        }

        public static DependencyProperty HeaderProperty { get; }
            = DependencyProperty.Register(
                nameof(Header), typeof(object), typeof(MinimalExpander), new PropertyMetadata(null));
        public static DependencyProperty HeaderTemplateProperty { get; }
            = DependencyProperty.Register(
                nameof(HeaderTemplate), typeof(DataTemplate), typeof(MinimalExpander), new PropertyMetadata(null));
        public static DependencyProperty IsExpandedProperty { get; }
            = DependencyProperty.Register(
                nameof(IsExpanded), typeof(bool), typeof(MinimalExpander), 
                new PropertyMetadata(false, (s, e) =>
                {
                    (s as MinimalExpander)?.UpdateExpandState(true);
                }));
        public static DependencyProperty NegativeContentHeightProperty { get; }
            = DependencyProperty.Register(
                nameof(NegativeContentHeight), typeof(double), typeof(MinimalExpander), new PropertyMetadata(0.0));

        void UpdateExpandState(bool useTransitions)
        {
            if (IsExpanded)
            {
                VisualStateManager.GoToState(this, "ExpandDown", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "CollapseUp", useTransitions);
            }
        }

        protected override void OnApplyTemplate()
        {
            var expanderContentClip = GetTemplateChild("ExpanderContentClip") as Border;
            if (expanderContentClip != null)
            {
                var visual = ElementCompositionPreview.GetElementVisual(expanderContentClip);
                visual.Clip = visual.Compositor.CreateInsetClip();
            }

            var expanderContent = GetTemplateChild("ExpanderContent") as Border;
            if (expanderContent != null)
            {
                expanderContent.SizeChanged += (s, e) =>
                {
                    var self = s as MinimalExpander;
                    self?.SetValue(NegativeContentHeightProperty, -1.0 * e.NewSize.Height);
                };
            }

            UpdateExpandState(false);
        }
    }
}
