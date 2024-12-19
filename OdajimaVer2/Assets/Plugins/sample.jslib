mergeInto(LibraryManager.library, {
  
  WatchDeviceorientation: function () {
    window.addEventListener("deviceorientation", function(event) { // ①
      xy = event.alpha + "," + event.beta + "," + event.gamma; // ②
      SendMessage('CameraGyro', 'ShowRotation', xy); // ③
    });
  },  

})