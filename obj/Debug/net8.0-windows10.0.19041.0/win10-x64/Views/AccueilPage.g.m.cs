//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EXAM_MAUI.Views
{
#nullable disable

	[global::System.CodeDom.Compiler.GeneratedCode("CompiledBindings", null)]
	partial class AccueilPage
	{
		private global::Microsoft.Maui.Controls.Button button1;
		private global::Microsoft.Maui.Controls.Button button2;
		private bool _generatedCodeInitialized;

		private void InitializeAfterConstructor()
		{
			if (_generatedCodeInitialized)
				return;

			_generatedCodeInitialized = true;

			button1 = global::Microsoft.Maui.Controls.NameScopeExtensions.FindByName<global::Microsoft.Maui.Controls.Button>(this, "button1");
			button2 = global::Microsoft.Maui.Controls.NameScopeExtensions.FindByName<global::Microsoft.Maui.Controls.Button>(this, "button2");


			this.BindingContextChanged += this_BindingContextChanged;
			if (this.BindingContext is global::EXAM_MAUI.ViewModels.AccueilViewModel dataRoot0)
			{
				Bindings_this.Initialize(this, dataRoot0);
			}
		}

		private void this_BindingContextChanged(object sender, global::System.EventArgs e)
		{
			Bindings_this.Cleanup();
			if (((global::Microsoft.Maui.Controls.Element)sender).BindingContext is global::EXAM_MAUI.ViewModels.AccueilViewModel dataRoot)
			{
				Bindings_this.Initialize(this, dataRoot);
			}
		}

		AccueilPage_Bindings_this Bindings_this = new AccueilPage_Bindings_this();

		class AccueilPage_Bindings_this
		{
			AccueilPage _targetRoot;
			global::EXAM_MAUI.ViewModels.AccueilViewModel _dataRoot;
			AccueilPage_BindingsTrackings_this _bindingsTrackings;

			public void Initialize(AccueilPage targetRoot, global::EXAM_MAUI.ViewModels.AccueilViewModel dataRoot)
			{
				_targetRoot = targetRoot;
				_dataRoot = dataRoot;
				_bindingsTrackings = new AccueilPage_BindingsTrackings_this(this);

				Update();

				_bindingsTrackings.SetPropertyChangedEventHandler0(dataRoot);
			}

			public void Cleanup()
			{
				if (_targetRoot != null)
				{
					_bindingsTrackings.Cleanup();
					_dataRoot = null;
					_targetRoot = null;
				}
			}

			public void Update()
			{
				var dataRoot = _dataRoot;
				Update0(dataRoot);
			}

			private void Update0(global::EXAM_MAUI.ViewModels.AccueilViewModel value)
			{
				Update0_AgentsCommand(value);
				Update0_EvenementsCommand(value);
			}

			private void Update0_AgentsCommand(global::EXAM_MAUI.ViewModels.AccueilViewModel value)
			{
#line (24, 21) - (24, 52) 24 "..\..\..\..\..\Views\AccueilPage.xaml"
				_targetRoot.button1.Command = value.AgentsCommand;
#line default
			}

			private void Update0_EvenementsCommand(global::EXAM_MAUI.ViewModels.AccueilViewModel value)
			{
#line (33, 21) - (33, 56) 33 "..\..\..\..\..\Views\AccueilPage.xaml"
				_targetRoot.button2.Command = value.EvenementsCommand;
#line default
			}

			class AccueilPage_BindingsTrackings_this
			{
				global::System.WeakReference _bindingsWeakRef;
				global::System.ComponentModel.INotifyPropertyChanged _propertyChangeSource0;

				public AccueilPage_BindingsTrackings_this(AccueilPage_Bindings_this bindings)
				{
					_bindingsWeakRef = new global::System.WeakReference(bindings);
				}

				public void Cleanup()
				{
					SetPropertyChangedEventHandler0(null);
				}

				public void SetPropertyChangedEventHandler0(global::EXAM_MAUI.ViewModels.AccueilViewModel value)
				{
					global::CompiledBindings.MAUI.CompiledBindingsHelper.SetPropertyChangedEventHandler(ref _propertyChangeSource0, value, OnPropertyChanged0);
				}

				private void OnPropertyChanged0(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
				{
					var bindings = global::CompiledBindings.MAUI.CompiledBindingsHelper.TryGetBindings<AccueilPage_Bindings_this>(ref _bindingsWeakRef, Cleanup);
					if (bindings == null)
					{
						return;
					}

					var typedSender = (global::EXAM_MAUI.ViewModels.AccueilViewModel)sender;
					switch (e.PropertyName)
					{
						case null:
						case "":
							bindings.Update0(typedSender);
							break;
						case "AgentsCommand":
							bindings.Update0_AgentsCommand(typedSender);
							break;
						case "EvenementsCommand":
							bindings.Update0_EvenementsCommand(typedSender);
							break;
					}
				}
			}
		}
	}
}
