namespace CompiledBindings.MAUI
{
	public class CompiledBindingsHelper
	{
		public static void SetPropertyChangedEventHandler(ref global::System.ComponentModel.INotifyPropertyChanged? cache, global::System.ComponentModel.INotifyPropertyChanged? source, global::System.ComponentModel.PropertyChangedEventHandler handler)
		{
			if (cache != null && !object.ReferenceEquals(cache, source))
			{
				cache.PropertyChanged -= handler;
				cache = null;
			}
			if (cache == null && source != null)
			{
				cache = source;
				cache.PropertyChanged += handler;
			}
		}

		public static void SetPropertyChangedEventHandler(ref global::System.ComponentModel.INotifyPropertyChanged? cache, object? source, global::System.ComponentModel.PropertyChangedEventHandler handler)
		{
			if (cache != null && !object.ReferenceEquals(cache, source))
			{
				cache.PropertyChanged -= handler;
				cache = null;
			}
			if (cache == null && source is System.ComponentModel.INotifyPropertyChanged npc)
			{
				cache = npc;
				cache.PropertyChanged += handler;
			}
		}

		public static T? TryGetBindings<T>(ref global::System.WeakReference? bindingsWeakReference, global::System.Action cleanup)
			where T : class
		{
			T? bindings = null;
			if (bindingsWeakReference != null)
			{
				bindings = (T?)bindingsWeakReference.Target;
				if (bindings == null)
				{
					bindingsWeakReference = null;
					cleanup();
				}
			}
			return bindings;
		}

		public static readonly global::Microsoft.Maui.Controls.BindableProperty BindingsProperty =
			global::Microsoft.Maui.Controls.BindableProperty.CreateAttached("Bindings", typeof(IGeneratedDataTemplate), typeof(CompiledBindingsHelper), null, propertyChanged: BindingsChanged);

		public static IGeneratedDataTemplate GetBindings(global::Microsoft.Maui.Controls.BindableObject @object)
		{
			return (IGeneratedDataTemplate)@object.GetValue(BindingsProperty);
		}

		public static void SetBindings(global::Microsoft.Maui.Controls.BindableObject @object, IGeneratedDataTemplate value)
		{
			@object.SetValue(BindingsProperty, value);
		}

		static void BindingsChanged(global::Microsoft.Maui.Controls.BindableObject bindable, object oldValue, object newValue)
		{
			if (oldValue != null)
			{
				((IGeneratedDataTemplate)oldValue).Cleanup((global::Microsoft.Maui.Controls.Element)bindable);
			}
			if (newValue != null)
			{
				((IGeneratedDataTemplate)newValue).Initialize((global::Microsoft.Maui.Controls.Element)bindable);
			}
		}
	}

	public interface IGeneratedDataTemplate
	{
		void Initialize(global::Microsoft.Maui.Controls.Element rootElement);
		void Cleanup(global::Microsoft.Maui.Controls.Element rootElement);
	}
}