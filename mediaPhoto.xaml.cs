namespace onlineActSept18;

public partial class mediaPhoto : ContentPage
{
	public mediaPhoto()
	{
		InitializeComponent();
	}

    //THIS FOR SKELETAL WITH OUT PERMISSIONS
    //private async void OnCapturePhotoButtonClicked(object sender, EventArgs e)
    //{
    //    var photo = await MediaPicker.CapturePhotoAsync();
    //    if (photo != null)
    //    {
    //        var stream = await photo.OpenReadAsync();
    //        // Use the photo stream (e.g., display or save the image)
    //    }
    //}
    private async void OnCapturePhotoButtonClicked(object sender, EventArgs e)
    {
        try
        {
            // Capture the photo using the MediaPicker
            var photo = await MediaPicker.CapturePhotoAsync();

            if (photo != null)
            {
                // Open the photo stream
                var stream = await photo.OpenReadAsync();

                //unnecessary
                // Use the photo stream (e.g., display the image)
                var imageSource = ImageSource.FromStream(() => stream);

                //unnecessary
                // Assuming you have an Image control in XAML named 'CapturedImage'
                CapturedImage.Source = imageSource;

                //unnecessary
                // Optionally, save the photo to the local file system
                var filePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using var fileStream = File.Create(filePath);
                stream.Seek(0, SeekOrigin.Begin); // Reset stream position
                await stream.CopyToAsync(fileStream);

                await DisplayAlert("Success", "Photo captured and saved successfully!", "OK");
            }
        }
        catch (FeatureNotSupportedException)
        {
            await DisplayAlert("Error", "This device does not support photo capture.", "OK");
        }
        catch (PermissionException)
        {
            await DisplayAlert("Error", "Camera permission is required.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}