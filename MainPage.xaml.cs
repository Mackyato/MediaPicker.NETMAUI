namespace onlineActSept18
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public async Task CheckAndRequestPermissions()
        {
            
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();

            
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            
            if (status == PermissionStatus.Granted)
            {
               
                await AccessCamera();
            }
            else
            {
                
                await DisplayAlert("Permission Denied", "Camera access is required.", "OK");
            }
        }

        public async Task AccessCamera()
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                var stream = await photo.OpenReadAsync();
                
            }
        }
    }

}
