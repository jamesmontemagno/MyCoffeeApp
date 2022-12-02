using MyCoffeeApp.ViewModels;

namespace MyCoffeeApp.Views;
public partial class AnimationPage : ContentPage
{
    ImageCacheViewModel vm;

    readonly Animation rotation;

    public AnimationPage(ImageCacheViewModel vm)
    {
        InitializeComponent();

        rotation = new Animation(v => LabelLoad.Rotation = v,
            0, 360, Easing.Linear);

        BindingContext = this.vm = vm;

        vm.PropertyChanged += Vm_PropertyChanged;
    }

    private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if(e.PropertyName == nameof(vm.IsBusy))
        {
            if(vm.IsBusy)
            {
                //animate
                rotation.Commit(this, "rotate", 16, 1000, Easing.Linear,
                    (v, c) => LabelLoad.Rotation = 0,
                    () => true);
            }
            else
            {
                //stop

                this.AbortAnimation("rotate");
            }
        }
    }
}